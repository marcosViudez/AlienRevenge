using UnityEngine;
using System.Collections;

public class pichosSalientes : MonoBehaviour {

	public int distanciaResorte;
	public Transform pinchosSalientes;
	private GameObject hero;

	// Use this for initialization
	void Start () 
	{
		hero = GameObject.Find ("HERO") as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (pinchosSalientes.position, hero.transform.position) < distanciaResorte) {
			// Debug.Log ("trampa activada");
			pinchosSalientes.gameObject.SetActive (true);
		} else {
			pinchosSalientes.gameObject.SetActive (false);
		}
	}
}
