using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarinaAnimacao : MonoBehaviour
{
    private const int KarinaIdle = 0;
    private const int KarinaPreparando = 1;
    private const int KarinaAtirando = 2;
    private const int KarinaApanhando = 3;
    private const int KarinaMorte = 4;

    private float Contador = 0f;
    private float tempoTiro = 2f;

    int Hp = 3;

    Animator anima;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        Contador += Time.deltaTime;
        if (Contador >= tempoTiro)
        {
            if (Input.GetMouseButton(0))
            {
                Preparar();
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            Atirar();
            Contador = 0f;
        }
    }

    void Preparar()
    {
        anima.SetInteger("state", KarinaPreparando);
    }

    void Atirar()
    {
        anima.SetInteger("state", KarinaAtirando);
        StartCoroutine("Cooldown");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projetil")
        {
            Hp--;
            anima.SetInteger("state", KarinaApanhando);
            StartCoroutine("Retorno");
            if (Hp == 0)
            {
                Morte();
            }
        }
    }

    void Morte()
    {
        anima.SetInteger("state", KarinaMorte);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.05f);
        anima.SetInteger("state", KarinaIdle);
    }

    IEnumerator Retorno()
    {
        yield return new WaitForSeconds(1.0f);
        anima.SetInteger("state", KarinaIdle);
    }
}
