using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sueloColisionScript : MonoBehaviour {

	public bool estoyEnSuelo;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "suelo") 
		{
			estoyEnSuelo = true;
			// Debug.Log("estas en el suelo");
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "suelo" || other.gameObject.tag == "sueloCaer" || other.gameObject.tag == "sueloOculto") 
		{
			estoyEnSuelo = true;
			// Debug.Log("estas en el suelo");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "suelo" || other.gameObject.tag == "sueloCaer" || other.gameObject.tag == "sueloOculto") 
		{
			estoyEnSuelo = false;
			// Debug.Log(" NO estas en el suelo");
		}
	}
}
