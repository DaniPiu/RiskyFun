using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicaVida : MonoBehaviour
{
    public GameObject[] hearts;
    private int vida;
    private bool morto;

    void Start()
    {
        vida = hearts.Length;
    }

    void Update()
    {
        if (morto == true)
        {
            Debug.Log("Está morto, Inimigo! É impossível! Não dá!");
            morto = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            Dano(1);
        }
    }

    public void Dano(int d)
    {
        if (vida >= 1)
        {
            vida -= d;
            Destroy(hearts[vida].gameObject);
            if (vida < 1)
            {
                morto = true;
            }
        }
    }
}
