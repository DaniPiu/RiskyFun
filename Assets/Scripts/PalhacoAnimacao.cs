using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalhacoAnimacao : MonoBehaviour
{
    private const int PalhacoIdle = 0;
    private const int PalhacoAtirando = 1;
    private const int PalhacoApanhando = 2;
    private const int PalhacoMorte = 3;

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
        anima.SetInteger("state", PalhacoAtirando);
        StartCoroutine("Trocar");
    }

    void Morte()
    {
        anima.SetInteger("state", PalhacoMorte);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            Hp--;
            anima.SetInteger("state", PalhacoApanhando);
            StartCoroutine("Retorno");
            if (Hp == 0)
            {
                Morte();
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(5.0f);
        bloqueio = false;
    }

    IEnumerator Trocar()
    {
        yield return new WaitForSeconds(1.0f);
        anima.SetInteger("state", PalhacoIdle);
    }

    IEnumerator Retorno()
    {
        yield return new WaitForSeconds(0.5f);
        anima.SetInteger("state", PalhacoIdle);
    }
}
