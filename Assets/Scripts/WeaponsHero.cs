using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponsHero : MonoBehaviour {

	public Canvas miCanvas;
	public GameObject hero;
	public GameObject Knife;
	public Text textoHachas;

	private int numeroHachas;
	public float turnVelocity;
	public float turnLaunch;
	public float velocityKnife;
	private bool cogiendoHacha;
	private float tiempoRecarga = 0.3f;

	void Start()
	{
		turnLaunch = 1f;
	}

	// Update is called once per frame
	void Update () 
	{
		turnVelocity = hero.GetComponent<heroMovement> ().turnPlayer;

		if (turnVelocity > 0) {
			turnLaunch = 1;
		}

		if (turnVelocity < 0) {
			turnLaunch = -1;
		}

		StartCoroutine (dispararHacha ());

		textoHachas.text = numeroHachas.ToString ();
		
	}

	public void sumarHachasItems()
	{
		numeroHachas += 10;
	}

	IEnumerator dispararHacha()
	{
		if (numeroHachas > 0 && !cogiendoHacha && Input.GetMouseButtonDown(0) && !escaleraManager.subiendoEscalera) 
		{
			numeroHachas--;
			// Debug.Log ("pum pum");
			cogiendoHacha = true;
			// instanciamos el arma a disparar
			GameObject lanzaCuchillo = Instantiate (Knife, transform.position,transform.rotation) as GameObject;
			// creamos el cuchillo como hijo del canvas
			lanzaCuchillo.transform.SetParent(miCanvas.transform);
			lanzaCuchillo.transform.position = transform.position;
			// agregamos una fuerza al cuchillo para que se mueva en el eje x
			lanzaCuchillo.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (velocityKnife,0) * turnLaunch,ForceMode2D.Impulse);
			// giramos el arma instanciada segun miremos a derecha o izquierda
			Vector3 theScale = lanzaCuchillo.transform.localScale;
			theScale.x *= turnLaunch;
			lanzaCuchillo.transform.localScale = theScale;
			yield return new WaitForSeconds (tiempoRecarga);
			cogiendoHacha = false;
		}
	}

}
