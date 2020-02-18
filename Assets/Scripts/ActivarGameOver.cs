using UnityEngine;
using System.Collections;

public class ActivarGameOver : MonoBehaviour {

	// Referencia a camara Game Over
	public GameObject camaraGameOver;

	// musica
	public AudioClip gameOverClip;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
		camaraGameOver.SetActive (false);
	
	}

	void PersonajeHaMuerto () {
		// Detenemos la música
		// UNITY 4: 
		//audio.Stop();
		//audio.clip = gameOverClip;
		//audio.loop = false;
		//audio.Play();
		// UNITY 5:
		GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().clip = gameOverClip;
		GetComponent<AudioSource>().loop = false;
		GetComponent<AudioSource>().Play();
		camaraGameOver.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
