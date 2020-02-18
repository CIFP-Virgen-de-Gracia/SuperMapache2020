using UnityEngine;
using System.Collections;

public class SeguirPersonaje : MonoBehaviour {

	// Necestamos saber la posicion del personaje
	public Transform personaje;

	// para que el personaje no esté en el centro centro
	public float separacion = 3f;

	/*
	// Use this for initialization
	void Start () {
	
	}

	*/
	
	// Update is called once per frame
	void Update () {
		// Actualizo la posición de la cama con la posicion del perosnaje
		// uso el this para decirle que es un propio objeto de la camara si nome sale sugerido
		this.transform.position = new Vector3 (personaje.position.x+separacion, this.transform.position.y, this.transform.position.z);
	}
}
