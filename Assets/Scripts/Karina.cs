using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Karina : MonoBehaviour
{
    int VidaKarina;

    // Start is called before the first frame update
    void Start()
    {
        VidaKarina = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projetil")
        {
            VidaKarina--;
        }
        if (VidaKarina == 0)
        {
            Destroy(this.gameObject, 2.5f);
            StartCoroutine("Morreu");
        }
    }

    IEnumerator Morreu()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }
}