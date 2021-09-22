using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interfaceManager : MonoBehaviour {

	public Camera miCamara;
	public float regX = 0f;
	public float regY = 0f;
	public float regZ = 0f;

	public Text scoreInterface;
	public int puntosScore;

	// Use this for initialization
	void Start () 
	{
	
	}

	public void sumarPuntos(int cantidadPuntos)
	{
		puntosScore += cantidadPuntos;
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreInterface.text = puntosScore.ToString ();
		// posicion y regulacion de la interface segun la poscion de la camara
		GetComponent<RectTransform> ().position = miCamara.transform.position + new Vector3(regX,regY,regZ);;
	}
}
