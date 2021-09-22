using UnityEngine;
using System.Collections;

public class destroyMe : MonoBehaviour {

	public float destroyTime;

	// Update is called once per frame
	void Update () 
	{
		Destroy (gameObject, destroyTime * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "suelo") 
		{
			// si chocamos con algun muro se elimina automaticamente
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			// si los disparos impactan con el player se destruye laser
			Destroy (gameObject);
			// Debug.Log ("te quito vida");
		}
	}
}
