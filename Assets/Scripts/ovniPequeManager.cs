using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ovniPequeManager : MonoBehaviour {

	private Transform target;
	public GameObject scriptLaserDisparador;

	private int radioAtaque = 180;					// radio 250 prueba
	private int velocidadOvni = 80;				// velocidad 80 prueba
	private  float rutaVigilanciaXmin;
	private float rutaVigilanciaXmax;
	private float largoRutaOvni = 200.0f;
	private float alturaOvni = 327.0f;
	private bool facingRight;

	private bool atacando;
	private bool canShot;

	public int vidaOvni = 2;
	private int puntosOvni = 600;

	public AudioClip sonidoDisparoOvni;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		transform.position = new Vector3(transform.position.x,alturaOvni,0);	// reseteamos altura de los ovnis
		calcularRuta();														// calculamos las distancias de la ruta
		// Debug.Log(transform.position);
	}

	void calcularRuta()
	{
		// Debug.Log (transform.position);
		rutaVigilanciaXmax = transform.position.x + largoRutaOvni;
		rutaVigilanciaXmin = transform.position.x - largoRutaOvni;
	}
	
	// Update is called once per frame
	void Update () 
	{
		busqueda ();

		if (Vector3.Distance (transform.position, target.position) < radioAtaque) {
			canShot = true;
			// velocidadOvni = 120;
		} else {
			canShot = false;
			// velocidadOvni = 80;
		}

		if (canShot && target.position.x < transform.position.x && facingRight) {
			// Debug.Log ("estas a mi izq");
			vigilandoDerecha ();
		}

		if (canShot && target.position.x >= transform.position.x && !facingRight) {
			// Debug.Log ("estas a mi der");
			vigilandoIzquierda ();
		}

		if (!atacando && canShot) 
		{
			StartCoroutine (atacar ());
		}

		if (vidaOvni <= 0) 
		{
			// estoy muerto
			GameObject.FindGameObjectWithTag("interface").GetComponent<interfaceManager>().sumarPuntos(puntosOvni);
			Destroy(this.gameObject);
		}
	}
		
	IEnumerator atacar()
	{
		atacando = true;
		scriptLaserDisparador.GetComponent<disparoManager> ().dispararLaser();
		GetComponent<AudioSource> ().PlayOneShot (sonidoDisparoOvni);
		yield return new WaitForSeconds (1);
		atacando = false;
	}

	void busqueda()
	{
		// moverse el ovni
		if (!canShot) {
			transform.Translate (-velocidadOvni * Time.deltaTime, 0, 0);
		} 

		if (transform.position.x < rutaVigilanciaXmin && !facingRight) {
			vigilandoDerecha ();
		}

		if (transform.position.x > rutaVigilanciaXmax && facingRight) {
			vigilandoIzquierda ();
		}
	}

	void vigilandoDerecha()
	{
		velocidadOvni = -velocidadOvni;	// cambiamos el sentido de giro
		scriptLaserDisparador.GetComponent<disparoManager> ().cambioSigno();
		Flip(); 
		// Debug.Log ("voy a derecha");
	}

	void vigilandoIzquierda()
	{
		velocidadOvni = -velocidadOvni;	// cambiamos el sentido de giro
		scriptLaserDisparador.GetComponent<disparoManager> ().cambioSigno();
		Flip();
		// Debug.Log ("voy a izquierda");
	}

	void quitarVidaOvni()
	{
		if (vidaOvni > 0) 
		{
			vidaOvni--;
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
			// quito vida al ovni volador
			// Debug.Log ("me muero");
			quitarVidaOvni();
			Destroy(other.gameObject);		// destruimos hacha impactada
		}
	}
}
