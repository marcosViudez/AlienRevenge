using UnityEngine;
using System.Collections;

public class piedrasLava : MonoBehaviour {

	public float velocidadPiedraLava;
	public float limiteUpLava;
	public float limiteDownLava;

	private bool estadoPiedraLava;

	// Use this for initialization
	void Start () 
	{
		// Debug.Log (transform.position.y);

	}

	// Update is called once per frame
	void Update () 
	{

		moverPiedra ();

	}

	void moverPiedra()
	{

		if (transform.position.y <= limiteDownLava) 
		{
			estadoPiedraLava = true;
		}

		if (transform.position.y >= limiteUpLava) 
		{
			estadoPiedraLava = false;
		}

		if (estadoPiedraLava) {
			subirPiedraLava ();
		} else {
			bajarPiedraLava ();
		}
	}

	void subirPiedraLava()
	{
		transform.position += new Vector3 (0, velocidadPiedraLava * Time.deltaTime, 0);
	}

	void bajarPiedraLava()
	{
		transform.position -=  new Vector3 (0, velocidadPiedraLava * Time.deltaTime, 0);
	}
}
