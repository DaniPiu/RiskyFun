using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalhacoArma : MonoBehaviour
{
	public Rigidbody2D projectile;
	bool bloqueio = true;

	void Start()
    {
		StartCoroutine("Atraso");
	}
	void Update()
	{
		if (bloqueio == false)
        {
			Atirar();
			StartCoroutine("Cooldown");
		}

	}

	void Atirar()
	{
		bloqueio = true;
		Rigidbody2D clone;
		clone = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody2D;
		clone.mass = Random.Range(0.01f, 1.5f);
		clone.velocity = clone.transform.TransformDirection(Random.Range(-8.0f, -11.0f), Random.Range(7.0f, 11.0f), 0f);
		Destroy(clone.gameObject, 5.0f);

	}

	IEnumerator Atraso()
    {
		yield return new WaitForSeconds(1.0f);
		bloqueio = false;
    }

	IEnumerator Cooldown()
    {
		yield return new WaitForSeconds(5.0f);
		bloqueio = false;
	}
}