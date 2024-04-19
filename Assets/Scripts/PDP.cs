using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PDP : MonoBehaviour
{
    int VidaPdp;

    void Start()
    {
        VidaPdp = 4;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            VidaPdp--;
        }
        if (VidaPdp == 0)
        {
            Destroy(this.gameObject, 2.5f);
            StartCoroutine("Passou");
        }
    }

    IEnumerator Passou()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Vitoria4");
    }
}
