using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

	void Start()
	{

	}

	void Update()
	{

	}

	public void LoadGameScene()
	{
		SceneManager.LoadScene("Estagio1");
	}

	public void Instrucoes()
	{
		SceneManager.LoadScene("Instrucoes");
	}

	public void Creditos()
	{
		SceneManager.LoadScene("Creditos");
	}

	public void FecharJogo()
	{
		Application.Quit();
	}
}