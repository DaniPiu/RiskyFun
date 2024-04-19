using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicaAnimacao : MonoBehaviour
{
    private const int MimicaIdle = 0;
    private const int MimicaAtirando = 1;
    private const int MimicaApanhando = 2;
    private const int MimicaMorte = 3;

    int Hp = 3;

    Animator anima;
    Rigidbody2D rigid;

    bool bloqueio = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        if (bloqueio == false)
        {
            Atirar();
            StartCoroutine("Cooldown");
        }
    }

    void Atirar()
    {
        bloqueio = true;
        anima.SetInteger("state", MimicaAtirando);
        StartCoroutine("Trocar");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            Hp--;
            anima.SetInteger("state", MimicaApanhando);
            StartCoroutine("Retorno");
            if (Hp == 0)
            {
                Morte();
            }
        }
    }

    void Morte()
    {
        anima.SetInteger("state", MimicaMorte);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(4.0f);
        bloqueio = false;
    }

    IEnumerator Trocar()
    {
        yield return new WaitForSeconds(1.0f);
        anima.SetInteger("state", MimicaIdle);
    }

    IEnumerator Retorno()
    {
        yield return new WaitForSeconds(0.5f);
        anima.SetInteger("state", MimicaIdle);
    }
}
