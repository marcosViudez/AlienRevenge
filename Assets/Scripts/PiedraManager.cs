using UnityEngine;
using System.Collections;

public class PiedraManager : MonoBehaviour {

	public float velocidadPiedra;
	public float limiteUp;
	public float limiteDown;

	private bool estadoPiedra;

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

		if (transform.position.y <= limiteDown) 
		{
			estadoPiedra = true;
		}

		if (transform.position.y >= limiteUp) 
		{
			estadoPiedra = false;
		}

		if (estadoPiedra) {
			subirPiedra ();
		} else {
			bajarPiedra ();
		}
	}

	void subirPiedra()
	{
		transform.position += new Vector3 (0, velocidadPiedra * Time.deltaTime, 0);
	}

	void bajarPiedra()
	{
		transform.position -=  new Vector3 (0, velocidadPiedra * Time.deltaTime, 0);
	}
}
