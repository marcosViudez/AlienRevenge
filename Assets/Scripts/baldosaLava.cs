using UnityEngine;
using System.Collections;

public class baldosaLava : MonoBehaviour {

	public float velocidadBaldosa;
	public bool moverDerecha;

	public float maxDerecho;
	public float maxIzquierdo;

	// Use this for initialization
	void Start () 
	{
		// velocidadBaldosa = 50.0f;
		// maxDerecho = 1250;
		// maxIzquierdo = 1046;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Debug.Log (transform.position);

		moverPlataforma ();
	}

	void moverPlataforma()
	{
		if (transform.position.x <= maxIzquierdo) 
		{
			moverDerecha = true;
		}

		if (transform.position.x >= maxDerecho) 
		{
			moverDerecha = false;
		}

		if (moverDerecha) {
			transform.position += new Vector3(velocidadBaldosa * Time.deltaTime,0,0);
		} else {
			transform.position -= new Vector3(velocidadBaldosa * Time.deltaTime,0,0);
		}


	}
}
