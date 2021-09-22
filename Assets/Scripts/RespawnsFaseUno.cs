using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnsFaseUno : MonoBehaviour {

	public GameObject respawnUno;
	public GameObject respawnDos;
	public GameObject respawnTres;
	public GameObject respawnCuatro;

	public GameObject hero;
	private int vidas;
	private int vidahero;

	public bool estoyRespawnUno; 
	public bool estoyRespawnDos; 
	public bool estoyRespawnTres; 
	public bool estoyRespawnCuatro; 

	// Use this for initialization
	void Start () 
	{
		estoyRespawnUno = false;
		estoyRespawnDos = false;
		estoyRespawnTres = false;
		estoyRespawnCuatro = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		respawnVida ();

		estoyRespawnUno = respawnUno.GetComponent<collisionRespawn> ().respawnCollision;
		estoyRespawnDos = respawnDos.GetComponent<collisionRespawn> ().respawnCollision;
		estoyRespawnTres = respawnTres.GetComponent<collisionRespawn> ().respawnCollision;
		estoyRespawnCuatro = respawnCuatro.GetComponent<collisionRespawn> ().respawnCollision;

		if (estoyRespawnDos) 
		{
			estoyRespawnUno = false;
		}

		if (estoyRespawnTres) 
		{
			estoyRespawnDos = false;
		}

		if (estoyRespawnCuatro) 
		{
			estoyRespawnTres = false;
		}
	}

	void respawnVida()
	{
		vidahero = hero.GetComponent<heroMovement> ().vidaRestante;
		vidas = hero.GetComponent<heroMovement> ().numeroVidas;

		// Debug.Log (vidahero);


		if (vidahero == -1 && vidas > 0) 
		{
			// Debug.Log ("renacido");
			hero.GetComponent<heroMovement> ().numeroVidas --;
			hero.GetComponent<heroMovement> ().vidaRestante = 8;
			hero.GetComponent<heroMovement> ().vidaInicial ();

			if (estoyRespawnUno) {
				hero.transform.position = respawnUno.transform.position;
			}
			if (estoyRespawnDos) {
				hero.transform.position = respawnDos.transform.position;
			}
			if (estoyRespawnTres) {
				hero.transform.position = respawnTres.transform.position;
			}
			if (estoyRespawnCuatro) {
				hero.transform.position = respawnCuatro.transform.position;
			}
		}

		if (vidahero == -1 && vidas <= 0) 
		{
			// acaba el juego devuelve a menu
			hero.GetComponent<heroMovement> ().EndGame ();
		}

	}
}
