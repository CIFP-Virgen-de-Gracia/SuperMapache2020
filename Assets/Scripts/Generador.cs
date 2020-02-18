using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	// Una lista a los prefabs para acceder a ellos
	// en nuestro caso los suelos
	public GameObject[] obj;
	public float tiempoMin = 1.5f; // tiempo mínimo en que aparecen
	public float tiempoMax = 2.5f; // tiempo máximo.

	private bool fin = false;


	// Use this for initialization
	void Start () {
		// Generamos los bloques
		//Generar ();

		// Paso con notificaciones
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer");
		// Para dejar de generar cosas
		// Para morir
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
	}

	// Solo si usamos notificaciones.
	void PersonajeEmpiezaACorrer (Notification notificacion) {
		// Generamos bloques.
		Generar ();
	}

	void PersonajeHaMuerto () {
		fin = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// para crear e instanciar objetos
	void Generar () {
		// si no ha muerto
		if (!fin) {
			//Inicializamos un objeto del vector en la posicion 0 o longitud
			// hay que indicarle su posición y su rotación
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);

			// Para que lo haga cada cierto tiempo
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
		}
	}
}
