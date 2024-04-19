using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Magico : MonoBehaviour
{
    int VidaMagico;

    // Start is called before the first frame update
    void Start()
    {
        VidaMagico = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pino")
        {
            VidaMagico--;
        }
        if (VidaMagico == 0)
        {
            Destroy(this.gameObject, 2.5f);
            StartCoroutine("Passou");
        }
    }

    IEnumerator Passou()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Vitoria5");
    }
}
