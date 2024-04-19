using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomadoraAnimacao : MonoBehaviour
{
    private const int DomadoraIdle = 0;
    private const int DomadoraAtirando = 1;
    private const int DomadoraApanhando = 2;
    private const int DomadoraMorte = 3;

    int Hp = 4;

    Animator anima;
    Rigidbody2D rigid;

    bool bloqueio = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
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
        anima.SetInteger("state", DomadoraAtirando);
        StartCoroutine("Trocar");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            Hp--;
            anima.SetInteger("state", DomadoraApanhando);
            StartCoroutine("Retorno");
            if (Hp == 0)
            {
                Morte();
            }
        }
    }

    void Morte()
    {
        anima.SetInteger("state", DomadoraMorte);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(3.0f);
        bloqueio = false;
    }

    IEnumerator Trocar()
    {
        yield return new WaitForSeconds(1.0f);
        anima.SetInteger("state", DomadoraIdle);
    }

    IEnumerator Retorno()
    {
        yield return new WaitForSeconds(0.5f);
        anima.SetInteger("state", DomadoraIdle);
    }
}
