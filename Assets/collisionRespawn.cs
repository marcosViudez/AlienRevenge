using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionRespawn : MonoBehaviour {

	public bool respawnCollision;
	public string nameRespawn;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			// Debug.Log (nameRespawn);
			respawnCollision = true;
		}
	}

}
