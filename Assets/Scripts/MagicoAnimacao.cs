using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicoAnimacao : MonoBehaviour
{
    private const int MagicoIdle = 0;
    private const int MagicoAtirando = 1;
    private const int MagicoApanhando = 2;
    private const int MagicoMorte = 3;

    int Hp = 5;

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
        anima.SetInteger("state", MagicoAtirando);
        StartCoroutine("Trocar");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            Hp--;
            anima.SetInteger("state", MagicoApanhando);
            StartCoroutine("Retorno");
            if (Hp == 0)
            {
                Morte();
            }
        }
    }

    void Morte()
    {
        anima.SetInteger("state", MagicoMorte);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(4.0f);
        bloqueio = false;
    }

    IEnumerator Trocar()
    {
        yield return new WaitForSeconds(1.0f);
        anima.SetInteger("state", MagicoIdle);
    }

    IEnumerator Retorno()
    {
        yield return new WaitForSeconds(0.5f);
        anima.SetInteger("state", MagicoIdle);
    }
}
