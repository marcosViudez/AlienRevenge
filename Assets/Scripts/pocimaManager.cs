using UnityEngine;
using System.Collections;

public class pocimaManager : MonoBehaviour {

	private float velocidadPocima;
	private float limiteUp;
	private float limiteDown;
	private float valorSubida;

	private bool estadoPocima;

	// Use this for initialization
	void Start () 
	{
		// Debug.Log (transform.position.y);
		velocidadPocima = 20f;
		valorSubida = 10f;
		limiteUp = transform.position.y + valorSubida;
		limiteDown = transform.position.y - valorSubida;
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
			estadoPocima = true;
		}

		if (transform.position.y >= limiteUp) 
		{
			estadoPocima = false;
		}

		if (estadoPocima) {
			subirPocima ();
		} else {
			bajarPocima ();
		}
	}

	void subirPocima()
	{
		transform.position += new Vector3 (0, velocidadPocima * Time.deltaTime, 0);
	}

	void bajarPocima()
	{
		transform.position -=  new Vector3 (0, velocidadPocima * Time.deltaTime, 0);
	}
}
