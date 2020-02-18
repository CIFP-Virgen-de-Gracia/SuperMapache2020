using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	// para mover el fondo
	public float velocidad = 0f;
	private bool enMovimiento = false;

	private float tiempoInicio = 0f;

	// Para pantalla Main
	public bool iniciarEnMovimiento = false;


	// Use this for initialization
	void Start () {
		// Para notificar que empeiza a coorrer
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer");

		// Para morir
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");

		// Para pantalla de inicio
		if (iniciarEnMovimiento) {
			PersonajeEmpiezaACorrer();
		}
	}

	void PersonajeEmpiezaACorrer () {
		enMovimiento = true;
		// Para evitar el golpe de fondo
		tiempoInicio = Time.time;
	}

	void PersonajeHaMuerto () {
		enMovimiento = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enMovimiento) {
			// UNITY 4 renderer.material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);

			// Para evitar que de golpe del fondo usamos el tiempo de inicio
			// Probar primero así y luego de la otra manera
			//GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (Time.time * velocidad, 0);
			// El modulo es para evitar problemas con Android
			GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (((Time.time-tiempoInicio) * velocidad)%1, 0);
		}
	}
}
