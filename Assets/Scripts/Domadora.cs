using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Domadora : MonoBehaviour
{
    int VidaDomadora;

    // Start is called before the first frame update
    void Start()
    {
        VidaDomadora = 4;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            VidaDomadora--;
        }
        if (VidaDomadora == 0)
        {
            Destroy(this.gameObject, 1.5f);
            StartCoroutine("Passou");
        }
    }

    IEnumerator Passou()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Vitoria3");
    }
}