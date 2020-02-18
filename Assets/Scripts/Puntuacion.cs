using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;

	// para puntuacion
	public TextMesh marcador;


	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "IncrementarPuntos");
		// Para las puntuaciones mas altas
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
		ActualizarMarcador ();
	}

	// Almacenamos solo si superamos la puntuación máxima
	void PersonajeHaMuerto () {
		if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima) {
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion; // Actualizamos la puntuacin máxima
			Debug.Log ("Puntuacion maxima SI superada. Maxima: "+EstadoJuego.estadoJuego.puntuacionMaxima+ " Actual: "+puntuacion);
			EstadoJuego.estadoJuego.GuardarDatos ();
		} else {
			Debug.Log ("Puntuacion maxima NO superada. Maxima: "+EstadoJuego.estadoJuego.puntuacionMaxima+ " Actual: "+puntuacion);
		}
	}

	void IncrementarPuntos (Notification notificacion) {
		int puntosAIncrementar = (int) notificacion.data;
		puntuacion += puntosAIncrementar;
		//Debug.Log ("Incrementados: " + puntosAIncrementar + ". Total: " + puntuacion);
		ActualizarMarcador ();
	}

	// para actualizar marcador
	void ActualizarMarcador () {
		marcador.text = puntuacion.ToString ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
