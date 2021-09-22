using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class opcionesManager : MonoBehaviour {

	public AudioClip sonidoBoton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void volverMenu()
	{
		GetComponent<AudioSource> ().PlayOneShot (sonidoBoton);
		SceneManager.LoadScene ("intro");	//volvemos al menu principal
	}
}
