using UnityEngine;
using System.Collections;

public class BotonCargarEscena : MonoBehaviour {

	public string nombreEscenaCargar = "GameScene";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Clic o tocado con el objeto
	// Cargamos escena
	void OnMouseDown () {
		//Debug.Log ("Click");
		// Que suene el sonido
		// UNITY 4
		//Camera.main.audio.Stop();
		//audio.Play();
		//Invoke("CargarNivelJuego", audio.clip.length);
		//Application.LoadLevel("GameScene");

		//UNITY 5
		Camera.main.GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().Play();
		// Para que no se corte a la mitad lo paralizamos hasta la duracion del sonido.
		Invoke("CargarNivelJuego", GetComponent<AudioSource>().clip.length);

		// para salir del juego
		//Application.Quit ();
	}

	void CargarNivelJuego() {
		Application.LoadLevel(nombreEscenaCargar);
	}
}
