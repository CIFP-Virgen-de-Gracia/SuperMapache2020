using UnityEngine;
using System.Collections;

public class ActualizarValoresGameOver : MonoBehaviour {

	// para actulaizar valores
	public TextMesh total;
	public TextMesh record;
	public Puntuacion puntuacion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Para saber si está activo
	void OnEnable () {
		total.text = puntuacion.puntuacion.ToString ();
		if (EstadoJuego.estadoJuego != null) {
			record.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString ();
		}
	}
}
