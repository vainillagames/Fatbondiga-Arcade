using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroGame : MonoBehaviour 
{
	public float cooldown;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("TranscursoIntro");
	}
	
	IEnumerator TranscursoIntro()
	{
		
		yield return new WaitForSeconds (cooldown);
		//aki posem k carregui la pantalla de titul
		SceneManager.LoadScene ("Pantalla de Titulo");
	}
}
