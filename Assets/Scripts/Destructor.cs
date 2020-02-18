using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	public GameObject personaje;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// metodo especial para detectar colisiones
	void OnTriggerEnter2D (Collider2D other) {
		// destruimos el objeto con el que hemos colisonado porque sabemos su collider
		// si es el jugador
		if (other.tag == "Player") {
			// muerte, por hacer
			NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");

			//Debug.Break ();

			//GameObject personaje = GameObject.Find("Personaje");
			personaje.SetActive(false);

		} else {
			Destroy (other.gameObject);
		}
	}
}
