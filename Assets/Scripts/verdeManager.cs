using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class verdeManager : MonoBehaviour {

	private Animator animVerde;
	private Transform targetVerde;
	public GameObject scriptRayoVerde;

	public int radioDisparoVerde;
	public int velocidadVerde;
	private bool facingRight;
	private bool voyDerechas;
	public bool canRayo;
	private bool disparandoRayos;

	public float posicionVerdeX;
	private int largoRutaVerde = 100;
	private float rutaVigilanciaXmaxVerde;
	private float rutaVigilanciaXminVerde;

	public int vidaVerde = 3;
	private int puntosVerde = 100;

	public AudioClip sonidoDisparoVerde;
	public AudioClip sonidoMuerteVerde;
 
	// Use this for initialization
	void Start () 
	{
		animVerde = GetComponent<Animator>();
		targetVerde = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		calcularRutaVerde ();
	}

	void calcularRutaVerde()
	{
		rutaVigilanciaXmaxVerde = transform.position.x + largoRutaVerde;
		rutaVigilanciaXminVerde = transform.position.x - largoRutaVerde;
	}

	// Update is called once per frame
	void Update () 
	{
		verdeMoverse ();
		busqueda ();

		if (Vector3.Distance (transform.position, targetVerde.position) < radioDisparoVerde) {
			canRayo = true;
		} else {
			canRayo = false;
		}

		if (!disparandoRayos && canRayo) {
			StartCoroutine(dispararVerde());
		}

		if (vidaVerde <= 0) 
		{
			// estoy muerto
			GetComponent<AudioSource> ().PlayOneShot (sonidoMuerteVerde);
			GameObject.FindGameObjectWithTag("interface").GetComponent<interfaceManager>().sumarPuntos(puntosVerde);
			Destroy(this.gameObject);
		}

	}

	void busqueda()
	{ 
		if (transform.position.x < rutaVigilanciaXminVerde && !facingRight) {
			vigilandoDerechaVerde ();
		}

		if (transform.position.x > rutaVigilanciaXmaxVerde && facingRight) {
			vigilandoIzquierdaVerde ();
		}
	}

	public void vigilandoDerechaVerde()
	{
		velocidadVerde = -velocidadVerde;	// cambiamos el sentido de giro
		scriptRayoVerde.GetComponent<DisparoRayoVerde> ().cambioSignoVerde();
		Flip(); 
		// Debug.Log ("voy a derecha");
	}

	public void vigilandoIzquierdaVerde()
	{
		velocidadVerde = -velocidadVerde;	// cambiamos el sentido de giro
		scriptRayoVerde.GetComponent<DisparoRayoVerde> ().cambioSignoVerde();
		Flip();
		// Debug.Log ("voy a izquierda");
	}

	IEnumerator dispararVerde()
	{
		disparandoRayos = true;
		scriptRayoVerde.GetComponent<DisparoRayoVerde> ().dispararLaserVerde ();
		GetComponent<AudioSource> ().PlayOneShot (sonidoDisparoVerde);
		yield return new WaitForSeconds (2);
		disparandoRayos = false;
	}

	void verdeMoverse()
	{
		transform.Translate (-velocidadVerde * Time.deltaTime, 0, 0);		// nos movemos
		animVerde.SetBool ("andarVerde", true);								// animamos movernos

	}

	void Flip()
	{
		// metodo para girar el sprite al moverse hacia atras
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void quitarVidaVerde()
	{
		if (vidaVerde > 0) 
		{
			vidaVerde--;
		}
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
			quitarVidaVerde();
			Destroy(other.gameObject);		// destruimos hacha impactada
		}
	}
}
