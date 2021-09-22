using UnityEngine;
using System.Collections;

public class disparoPerdigonManager : MonoBehaviour {

	public GameObject disparoPerdigon;
	private Canvas miCanvasPerdigon;
	public int velocidadPerdigonX = 100;
	public int giroDisparoPerdigon = 1;

	void Start()
	{
		miCanvasPerdigon = GameObject.FindGameObjectWithTag ("juegoPanel").GetComponent<Canvas> ();
	}

	public void dispararPerdigonesAzules()
	{
		GameObject laser = Instantiate (disparoPerdigon, transform.position, transform.rotation) as GameObject;
		laser.transform.SetParent(miCanvasPerdigon.transform);
		laser.transform.position = transform.position;
		// transform.Translate (Vector3.forward * -velocidadLaser);
		laser.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-velocidadPerdigonX,0),ForceMode2D.Impulse);
	}

	public void cambioSignoVerde()
	{
		velocidadPerdigonX = -velocidadPerdigonX;												// cambiamos de signo la velocidad cuando gira el ovni
		giroDisparoPerdigon = -giroDisparoPerdigon;														
		transform.rotation = Quaternion.Euler(new Vector3(0,0,0 * (giroDisparoPerdigon)));		// giramos el sprite del laser
	}
}
