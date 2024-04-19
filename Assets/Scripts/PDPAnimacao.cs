using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDPAnimacao : MonoBehaviour
{
    private const int PdpIdle = 0;
    private const int PdpAtirando = 1;
    private const int PdpApanhando = 2;
    private const int PdpMorte = 3;

    int Hp = 4;

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
        anima.SetInteger("state", PdpAtirando);
        StartCoroutine("Trocar");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            Hp--;
            anima.SetInteger("state", PdpApanhando);
            StartCoroutine("Retorno");
            if (Hp == 0)
            {
                Morte();
            }
        }
    }

    void Morte()
    {
        anima.SetInteger("state", PdpMorte);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(3.5f);
        bloqueio = false;
    }

    IEnumerator Trocar()
    {
        yield return new WaitForSeconds(1.0f);
        anima.SetInteger("state", PdpIdle);
    }

    IEnumerator Retorno()
    {
        yield return new WaitForSeconds(0.5f);
        anima.SetInteger("state", PdpIdle);
    }
}
