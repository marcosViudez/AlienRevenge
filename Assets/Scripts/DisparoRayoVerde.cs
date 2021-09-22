using UnityEngine;
using System.Collections;

public class DisparoRayoVerde : MonoBehaviour {

	public GameObject disparoLaserVerde;
	private Canvas miCanvasVerde;
	public int velocidadLaserVerdeX = 100;
	public int giroDisparoVerde = 1;

	void Start()
	{
		miCanvasVerde = GameObject.FindGameObjectWithTag ("juegoPanel").GetComponent<Canvas> ();
	}

	public void dispararLaserVerde()
	{
		GameObject laser = Instantiate (disparoLaserVerde, transform.position, transform.rotation) as GameObject;
		laser.transform.SetParent(miCanvasVerde.transform);
		laser.transform.position = transform.position;
		// transform.Translate (Vector3.forward * -velocidadLaser);
		laser.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-velocidadLaserVerdeX,0),ForceMode2D.Impulse);
	}

	public void cambioSignoVerde()
	{
		velocidadLaserVerdeX = -velocidadLaserVerdeX;												// cambiamos de signo la velocidad cuando gira el ovni
		giroDisparoVerde = -giroDisparoVerde;														
		transform.rotation = Quaternion.Euler(new Vector3(0,0,0 * (giroDisparoVerde)));		// giramos el sprite del laser
	}
}
