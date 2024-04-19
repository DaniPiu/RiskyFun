using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarinaVida : MonoBehaviour
{

    public GameObject[] hearts;
    private int vida;
    private bool morto;

    // Start is called before the first frame update
    void Start()
    {
        vida = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (morto == true)
        {
            Debug.Log("Está morta, Karina! É impossível! Não dá!");
            morto = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projetil")
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
