using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilDestruir : MonoBehaviour
{
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Mapa")
        {
            Destroy(this.gameObject, 0.25f);
        }
    }
   
}
