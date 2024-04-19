using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDPArma : MonoBehaviour
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
		clone.mass = Random.Range(0.1f, 0.3f);
		clone.velocity = clone.transform.TransformDirection(Random.Range(-13.0f, -13.1f), Random.Range(4.5f, 4.6f), 0f);
		Destroy(clone.gameObject, 5.0f);

	}

	IEnumerator Atraso()
	{
		yield return new WaitForSeconds(1f);
		bloqueio = false;
	}

	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(3.5f);
		bloqueio = false;
	}
}