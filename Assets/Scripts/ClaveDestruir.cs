using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaveDestruir : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Projetil")
        {
            Destroy(coll.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Inimigo")
        {
            Destroy(this.gameObject);
        }
    }
}
