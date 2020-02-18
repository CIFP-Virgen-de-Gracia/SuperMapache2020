using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto = 600f; // fuerza paara saltar.

	// para ver si estamos en el suelo
	private bool enSuelo = true; 
	public Transform comprobadorSuelo; // le pasamos el objeto que nos ayudará a comprobar
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo; // LayerSuelo para saber donde puede estar de pie y colisona

	// Solo para el doble salto
	private bool dobleSalto = false;


	// para modificar el animador
	private Animator animator;


	// Codigo para empezar a correr
	private bool corriendo = false;
	public float velocidad = 1f;


	// funcion Awake, se llama una sola vez al inicializar el objeto 
	// y aquí se obtienen las referencias a elementos del juego, ya sean del mismo objeto
	// o de otros

	void Awake () {
		animator = GetComponent<Animator> ();
	}


	// Use this for initialization
	void Start () {
	
	}

	// Para tratar cosas con la fisica hay que hacerlo desde esta función
	// no se hace cada fotograma si no cada cierto tiempoq ue el motor lo estime
	void FixedUpdate () {
		// PASO 4
		if (corriendo) {
			// UNITY 4 rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
		}
		// Actualizamos el animador para decir que corre
		// UNITY 4 animator.SetFloat("VelX", rigidbody2D.velocity.x);
		animator.SetFloat ("VelX", GetComponent<Rigidbody2D> ().velocity.x);

		// estaremos en suelo, si la posición del comprobador del suelo
		// en el radio de acción que hemos definido
		// colisionan con algún objeto del tipo definido por la mascara
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);

		// Animador, si estamos en el suelo para cambiar el estado
		animator.SetBool ("isGrounded", enSuelo);

		if (enSuelo) {
			dobleSalto = false;
		}
	}
	
	// Update is called once per frame
	// para comprobar en cada frame
	void Update () {

		// PASO 04 .- Estamos corriendo - primero pulsamos la pantalla
		if (Input.GetMouseButtonDown (0)) {
			if(corriendo) {
				// Hacemos que salte si puede saltar
				if ((enSuelo || !dobleSalto)) {

					// Para hacer que suene
					// UNITY 4: audio.Play();
					// UNITy 5
					GetComponent<AudioSource>().Play();

					// hacer que salte, es aplicar una fuerza en el eje Y.
					// se hace a través del rigidBody.
					// Cuando hacemos el segundo salto reiniciamos la velocidad  (PASO 03)
					// UNITY 4 rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
					
					// PASO 01
					//UNITY 4 rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
					//UNITY 5, usamos get component que nos da la componente del objeto
					//GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
					
					// si no hemos hecho el doble salto ni estamos en el suelo
					if(!dobleSalto && !enSuelo) {
						dobleSalto = true; // no se vuelve a utilizar 
					}
				}
			}else{
				corriendo = true;
				// Notificaciones
				NotificationCenter.DefaultCenter().PostNotification(this,"PersonajeEmpiezaACorrer");
			}
		}

		// PASO 4 comento todo esto, porque me lo llevo arriva
		/*
		// comprobamos si se ha tocado la pantalla
		// boton clic izquierdo o tocado la panntalla
		// solo saltamos en el suelo y como máximo doble salto (false)
		if ((enSuelo || !dobleSalto) && Input.GetMouseButtonDown (0)) {
			// hacer que salte, es aplicar una fuerza en el eje Y.
			// se hace a través del rigidBody.

			// Cuando hacemos el segundo salto reiniciamos la velocidad  (PASO 03)
			// UNITY 4 rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);

			// PASO 01
			//UNITY 4 rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
			//UNITY 5, usamos get component que nos da la componente del objeto
			//GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));

			// si no hemos hecho el doble salto ni estamos en el suelo
			if(!dobleSalto && !enSuelo) {
				dobleSalto = true; // no se vuelve a utilizar 
			}
		}
		*/
	}



}
