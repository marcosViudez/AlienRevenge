using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class marcianoManager : MonoBehaviour {

	private Animator animMarciano;
	private Transform target;
	public GameObject scriptPerdigon;

	private int radioAlertaMarciano = 400;
	private int radioDisparoMarciano = 250;

	public bool facingRight;
	public bool estoyAlerta;
	public bool estoyDisparando;
	public bool disparandoPerdigones;
	private float velocidadPerdigon = 1f;

	public int vidaMarciano = 3;
	public int puntosMarciano = 1000;
	public int numeroPerdigones = 4;

	public AudioClip sonidoDisparo;

	// Use this for initialization
	void Start () 
	{
		animMarciano = GetComponent<Animator>();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		estadoAlerta ();
		estadoDisparando ();
		StartCoroutine(cargandoPerdigones ());

		if (target.position.x > transform.position.x && !facingRight) {
			Flip ();
			scriptPerdigon.GetComponent<disparoPerdigonManager> ().cambioSignoVerde ();
		} 

		if (target.position.x < transform.position.x && facingRight){
			Flip ();
			scriptPerdigon.GetComponent<disparoPerdigonManager> ().cambioSignoVerde ();
		}

		if (vidaMarciano <= 0) 
		{
			// estoy muerto
			GameObject.FindGameObjectWithTag("interface").GetComponent<interfaceManager>().sumarPuntos(puntosMarciano);
			Destroy(this.gameObject);
		}
	}

	IEnumerator cargandoPerdigones()
	{
		if (numeroPerdigones <= 0)
		{
			yield return new WaitForSeconds (1);
			numeroPerdigones = 6;
		}
	}

	void estadoDisparando()
	{
		// el marciano empieza a disparar
		if (Vector3.Distance (transform.position, target.position) < radioDisparoMarciano) {
			estoyDisparando = true;
		} else {
			estoyDisparando = false;
		}

		if (estoyDisparando && !disparandoPerdigones && numeroPerdigones > 0) {
			GetComponent<AudioSource> ().PlayOneShot (sonidoDisparo);
			StartCoroutine(dispararPerdigon());
		}
	}

	IEnumerator dispararPerdigon()
	{
		disparandoPerdigones = true;
		scriptPerdigon.GetComponent<disparoPerdigonManager> ().dispararPerdigonesAzules ();
		numeroPerdigones--;
		yield return new WaitForSeconds (velocidadPerdigon);
		disparandoPerdigones = false;
	}

	void estadoAlerta()
	{
		// el marciano esta alerta y saca el arma
		if (Vector3.Distance (transform.position, target.position) < radioAlertaMarciano) {
			estoyAlerta = true;
		} else {
			estoyAlerta = false;
		}

		if (estoyAlerta) {
			animMarciano.SetBool ("AlertaMarciano", true);
		} else {
			animMarciano.SetBool ("AlertaMarciano", false);
		}
	}

	void quitarVidaMarciano()
	{
		if (vidaMarciano > 0) 
		{
			vidaMarciano--;
		}
	}

	void Flip()
	{
		// metodo para girar el sprite al moverse hacia atras
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			// quito vida al player
			// Debug.Log ("te quito vida");
		}

		if (other.gameObject.tag == "hacha") 
		{
			// quito vida al monstruo verde
			// Debug.Log ("me muero");
			quitarVidaMarciano();
			Destroy(other.gameObject);		// destruimos hacha impactada
		}
	}
}
