using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Para pasarnos información al juego
public class EstadoJuego : MonoBehaviour {

	// Patron en Singleton
	public static EstadoJuego estadoJuego;
	// La puntuación máxima
	public int puntuacionMaxima = 0;
	// Para salvar el fichero
	private string rutaArchivo;


	// Antes de Start se suele usar para inicilizar a lo primero.
	// Así no se destruye 
	void Awake () {
		// Para salvar el juego
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} else if (estadoJuego!=this) {
			Destroy(gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		// Cargamos Datos
		CargarDatos ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Guardar Estado del juego
	public void GuardarDatos () {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(rutaArchivo);
		
		DatosAGuardar datos = new DatosAGuardar();
		datos.puntuacionMaxima = puntuacionMaxima;
		
		bf.Serialize(file, datos);
		
		file.Close();

	}

	// Cargar Estado de Juego
	public void CargarDatos () {
		if(File.Exists(rutaArchivo)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(rutaArchivo, FileMode.Open);
			
			DatosAGuardar datos = (DatosAGuardar) bf.Deserialize(file);
			
			puntuacionMaxima = datos.puntuacionMaxima;
			
			file.Close();
		}else{
			puntuacionMaxima = 0;
		}

	}
}

// Para grabar en disco
[Serializable]
class DatosAGuardar {
	public int puntuacionMaxima;

}
