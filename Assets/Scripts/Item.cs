using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public int puntosGanados = 5;
	//private bool haColisonadoJugador = false;

	// Sonido
	public AudioClip itemSoundClip;
	public float itemSoundVolume = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			Debug.Log ("Tocado");
			//haColisonadoJugador = true;
			//Debug.Log ("Una colision detectada");
			
			//Solo contamos si es una pata
			NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
			// Sonamos
			AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
		
		}
		// autodestruimos Item
		Destroy(gameObject);
	}
}
