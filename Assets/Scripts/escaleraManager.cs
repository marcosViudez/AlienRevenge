using UnityEngine;
using System.Collections;

public class escaleraManager : MonoBehaviour {
	
	public static bool subiendoEscalera;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
				// subir escalera
				subiendoEscalera = true;
			} 

			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
				// bajamos escalera
				subiendoEscalera = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				// subir escalera
				subiendoEscalera = true;
			}

			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
			{
				// bajamos escalera
				subiendoEscalera = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			// estamos fuera de la escalera
			subiendoEscalera = false;
			sueloManager.grounded = false;
		} 
	}

}
