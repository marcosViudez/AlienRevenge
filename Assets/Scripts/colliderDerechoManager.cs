using UnityEngine;
using System.Collections;

public class colliderDerechoManager : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "maloVerde") 
		{
			// Debug.Log ("hay agujero");
			// me doy la vuelta a derechas
			GameObject.FindGameObjectWithTag ("maloVerde").GetComponent<verdeManager> ().vigilandoIzquierdaVerde();
		}
	}
}
