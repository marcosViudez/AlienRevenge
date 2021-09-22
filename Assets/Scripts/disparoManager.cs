using UnityEngine;
using System.Collections;

public class disparoManager : MonoBehaviour {

	public GameObject disparoLaser;
	private Canvas miCanvas;
	public int velocidadLaserX = 100;
	public int velocidadLaserY = 100;
	public int giroDisparo = 1;

	void Start()
	{
		miCanvas = GameObject.FindGameObjectWithTag ("juegoPanel").GetComponent<Canvas> ();
	}

	public void dispararLaser()
	{
		GameObject laser = Instantiate (disparoLaser, transform.position, transform.rotation) as GameObject;
		laser.transform.SetParent(miCanvas.transform);
		laser.transform.position = transform.position;
		// transform.Translate (Vector3.forward * -velocidadLaser);
		laser.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-velocidadLaserX,-velocidadLaserY),ForceMode2D.Impulse);
	}

	public void cambioSigno()
	{
		velocidadLaserX = -velocidadLaserX;												// cambiamos de signo la velocidad cuando gira el ovni
		giroDisparo = -giroDisparo;														
		transform.rotation = Quaternion.Euler(new Vector3(0,0,-45 * (giroDisparo)));		// giramos el sprite del laser
	}
}
