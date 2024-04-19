using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarinaArma : MonoBehaviour
{
    public GameObject municao;
    public float forca = 10, distanciaMax = 2;
    Vector3 posicMouse;
    GameObject instanciaTemp;
    bool instanciou = false;
    public bool gatilho = false;
    public GameObject temporizador;

    private float Contador = 0f;
    private float tempoTiro = 2f;

    void Start()
    {
        gatilho = false;
    }

    void Update()
    {
        if (gatilho == false)
        {
            temporizador.SetActive(false);
        }

        Contador += Time.deltaTime;
        if (Contador >= tempoTiro)
        {
            gatilho = true;
            Lancar();
        }

        if (gatilho == true)
        {
            temporizador.SetActive(true);
        }
    }

    void Lancar()
    {
        if (Input.GetMouseButton(0))
        {
            gatilho = false;
            posicMouse = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0);
            posicMouse.z = transform.position.z;
            if (instanciou == false)
            {
                instanciou = true;
                instanciaTemp = Instantiate(municao, posicMouse, transform.rotation) as GameObject;
                instanciaTemp.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            if (Vector3.Distance(transform.position, posicMouse) < distanciaMax)
            {
                instanciaTemp.transform.position = posicMouse;
            }
            else
            {
                Vector3 lugarCorreto = transform.position + (posicMouse - transform.position).normalized * distanciaMax;
                instanciaTemp.transform.position = lugarCorreto;
            }
            instanciaTemp.GetComponent<Collider2D>().enabled = false;
        }

        if (Input.GetMouseButtonUp(0) && instanciou == true)
        {
            gatilho = false;
            instanciaTemp.GetComponent<Collider2D>().enabled = true;
            Vector3 direcao = transform.position - instanciaTemp.transform.position;
            instanciaTemp.GetComponent<Rigidbody2D>().isKinematic = false;
            instanciaTemp.GetComponent<Rigidbody2D>().AddForce(direcao * forca, ForceMode2D.Impulse);
            instanciou = false;
            Contador = 0f;
            Destroy(instanciaTemp, 5.0f);
        }
    }
}