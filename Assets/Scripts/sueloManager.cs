using UnityEngine;
using System.Collections;

public class sueloManager : MonoBehaviour {

	public static bool grounded;

	
	void Update()
	{
		

		if (escaleraManager.subiendoEscalera) 
		{
			// quito collision del bloque de la escalera
			this.GetComponent<BoxCollider2D> ().enabled = false;
		} else{
			this.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}

	//metodos de colision con suelo escalera
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			// Debug.Log ("colision");
			grounded = true;
		} 
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			// Debug.Log ("colision");
			grounded = true;
		} 
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			// Debug.Log ("grounded false");
			grounded = false;
		} 
	}


}
