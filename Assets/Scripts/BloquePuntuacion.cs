using UnityEngine;
using System.Collections;

public class BloquePuntuacion : MonoBehaviour {

	//para que solo se tenga en cuenta una colision (problemas de fotogramas)
	private bool haColisonadoJugador = false;
	public int puntosGanados = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Para saber si hay una colision
	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log (collision.gameObject.name);
		//Solo queremos que seael personaje
		if (!haColisonadoJugador && 
		    ((collision.collider.gameObject.name == "PataInferiorDerechaB" 
		  	|| collision.collider.gameObject.name == "PataInferiorIzquierdaB"))) {
			haColisonadoJugador = true;
			//Debug.Log ("Una colision detectada");

			//Solo contamos si es una pata
			NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
		}
	}
}
