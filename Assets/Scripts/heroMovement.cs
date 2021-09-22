using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heroMovement : MonoBehaviour {

	public float jumpForce;
	public float speedWalk;
	public float speedUpStairs;
	public float turnPlayer;
	public int numeroVidas;
	public Text numeroVidasText;

	private RaycastHit hit;
	public GameObject colliderSuelo;

	private Vector3 moveHor;
	private Vector3 moveVer;

	private Rigidbody2D hero;
	private Animator animHero;

	public GameObject panelHero;
	public Text dialogoHero;

	private bool facingRight;
	private bool isJumping;

	private int pocimaLevel = 2;

	public GameObject[] vidaHero = new GameObject[9];
	public int vidaRestante;

	public GameObject escalera;
	public GameObject interfaceScript;
	public int scorePlayer;

	public bool escaleraActivada;
	public bool tengoTarjeta;
	public bool tengoLlave;

	public AudioClip sonidoLlaves;
	// Use this for initialization
	void Start () 
	{
		scorePlayer = 0;
		speedWalk = 150;
		numeroVidas = 2;
		panelHero.GetComponent<Image> ().enabled = false;
		dialogoHero.GetComponent<Text> ().enabled = false;
		hero = GetComponent<Rigidbody2D> ();	// componente de nuestro player
		animHero = GetComponent<Animator>();	// componente de las animaciones
		moveHor.x = 0;
		vidaRestante = 8;						// lo que tengo de vida inicial
		vidaInicial ();
	}

	public void vidaInicial()
	{
		for (int i = 0; i < 9; i++) 
		{
			vidaHero [i].GetComponent<Image> ().enabled = true;	// pongo a true la barra de vida
		}
	}

	IEnumerator hablarHero(string texto)
	{
		panelHero.GetComponent<Image> ().enabled = true;
		dialogoHero.GetComponent<Text> ().enabled = true;
		dialogoHero.text = texto;
		yield return new WaitForSeconds (3);
		cerrarHero ();
	}

	void cerrarHero()
	{
		panelHero.GetComponent<Image> ().enabled = false;
		dialogoHero.GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// saltando
		if (Input.GetKeyDown(KeyCode.Space) && colliderSuelo.GetComponent<sueloColisionScript>().estoyEnSuelo == true && !isJumping && !escaleraManager.subiendoEscalera)
		{
			hero.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			isJumping = true;
		}

		// mover hacia arriba y abajo 
		if (escaleraManager.subiendoEscalera)
		{
			transform.position += moveVer * speedUpStairs;
			animHero.SetBool("subirEscalera", true);
			hero.gravityScale = 0;
		}
		else
		{
			hero.gravityScale = 30;
			animHero.SetBool("subirEscalera", false);
		}

		numeroVidasText.text = numeroVidas.ToString ();
		// crear un raycast para el salto
		/*
		if (colliderSuelo.GetComponent<sueloColisionScript> ().estoyEnSuelo == true) 
		{
			Debug.Log ("estoy en suelo");
		}else{
			Debug.Log("estoy saltando");
		}*/

		scorePlayer = interfaceScript.GetComponent<interfaceManager> ().puntosScore;
		// Debug.Log (transform.position.y);
		// Debug.Log (sueloManager.grounded); // acceder a una variable static de otro script
		/*if (vidaRestante == -1) 
		{
			// Debug.Log("estoy muerto!!!!");
			PlayerPrefs.SetInt("scorePlayer",scorePlayer);
			SceneManager.LoadScene("GameOver");
		}*/

		// movimiento horizontal del player
		moveHor = new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);
		moveVer = new Vector3 (0, Input.GetAxis ("Vertical"), 0);

		// animacion de caminar del personaje player
		if (!escaleraManager.subiendoEscalera && moveHor.x != 0) {
				transform.Translate (moveHor * speedWalk * Time.deltaTime);
				animHero.SetBool ("andando", true);
			} else {
				animHero.SetBool ("andando", false);
			}

		if (colliderSuelo.GetComponent<sueloColisionScript> ().estoyEnSuelo == false) {
			animHero.SetBool ("saltando", true);
		} 

		if(colliderSuelo.GetComponent<sueloColisionScript> ().estoyEnSuelo == true && !Input.GetKeyDown(KeyCode.Space))
		{
			animHero.SetBool ("saltando", false);
			isJumping = false;
		
		}
			
		// vamos a girar el sprite del player segun nos movamos en la horizontal
		turnPlayer = Input.GetAxis ("Horizontal");

		if (turnPlayer < 0 && !facingRight) {
			Flip ();
		}

		if (turnPlayer > 0 && facingRight) {
			Flip ();
		}
	}

	public void EndGame()
	{
		if (vidaRestante == -1) 
		{
			// Debug.Log("estoy muerto!!!!");
			PlayerPrefs.SetInt("scorePlayer",scorePlayer);
			SceneManager.LoadScene("GameOver");
		}
	}

	public void quitarVida()
	{
		if (vidaRestante >= 0)
		{
			vidaHero [vidaRestante].GetComponent<Image> ().enabled = false;
			vidaRestante--;
		}
	}

	public void sumarVida(int numeroVida)
	{
		// recuperamos vida al coger pocimas
		for (int i = 0; i < numeroVida; i++) 
		{
			if (vidaRestante < 8) 
			{
				vidaRestante++;
				vidaHero [vidaRestante].GetComponent<Image> ().enabled = true;
			}
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

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "fondoLava") 
		{
			// quito vida al monstruo verde
			// Debug.Log ("te quito vida");
			quitarVida();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "llaveEscalera") 
		{
			// Debug.Log ("tengo llave");
			tengoLlave = true;
			GetComponent<AudioSource> ().PlayOneShot (sonidoLlaves);
			StartCoroutine (hablarHero ("Aqui esta la llave que buscaba"));
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "tarjeta") 
		{
			// Debug.Log ("tengo tarjeta");
			tengoTarjeta = true;
			GetComponent<AudioSource> ().PlayOneShot (sonidoLlaves);
			StartCoroutine (hablarHero ("JAJAJA, ya tengo la tarjeta del ascensor"));
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "ascensorFin") 
		{
			// Debug.Log ("tengo tarjeta");
			// Debug.Log(" fin de juego");
			PlayerPrefs.SetInt("scorePlayer",scorePlayer);
			SceneManager.LoadScene("Continuara");
		}

		if (other.gameObject.tag == "palanca") 
		{
			if (tengoLlave) 
			{
				// activamos la escalera oculta y borramos llave del inventario
				escalera.GetComponent<Image> ().enabled = true;
				GameObject.FindGameObjectWithTag ("palanca").GetComponent<palancaManager> ().activarPalanca ();	
				GetComponent<AudioSource> ().PlayOneShot (sonidoLlaves);
				StartCoroutine (hablarHero ("ohhh!, una escalera"));
				escaleraActivada = true;
				tengoLlave = false;
			}else if (!tengoLlave && !escaleraActivada) 
			{
				StartCoroutine (hablarHero ("Necesitare una llave para mover la palanca"));
			}
		}

		if (other.gameObject.tag == "tarjetero") 
		{
			if (tengoTarjeta) 
			{
				// activamos el suelo oculto y borramos llave del inventario
				tengoTarjeta = false;
				GameObject.FindGameObjectWithTag ("sueloOculto").GetComponent<BoxCollider2D> ().isTrigger = false;
				StartCoroutine (hablarHero ("ummmm! tendre que hacer un salto de FE"));
			}
		}

		if (other.gameObject.tag == "pinchosSalientes") 
		{
			// quito vida al player
			// Debug.Log ("te quito vida");
			quitarVida();
		}

		if (other.gameObject.tag == "pinchosLava") 
		{
			// quito vida al player
			// Debug.Log ("te quito vida");
			quitarVida();
		}

		if (other.gameObject.tag == "laser") 
		{
			// quito vida al player
			// Debug.Log ("te quito vida");
			quitarVida();
		}

		if (other.gameObject.tag == "rayoVerde") 
		{
			// quito vida al monstruo verde
			// Debug.Log ("te quito vida");
			quitarVida();
		}

		if (other.gameObject.tag == "perdigon") 
		{
			// quito vida al monstruo verde
			// Debug.Log ("te quito vida");
			quitarVida();
		}

		if (other.gameObject.tag == "hachasItem") 
		{
			// quito vida al monstruo verde
			// Debug.Log ("cojo hacha");
			GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WeaponsHero> ().sumarHachasItems();
			GetComponent<AudioSource> ().PlayOneShot (sonidoLlaves);
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "pocima" && vidaRestante < 8) 
		{
			// quito vida al monstruo verde
			// Debug.Log ("sumo vida");
			sumarVida(pocimaLevel);
			GetComponent<AudioSource> ().PlayOneShot (sonidoLlaves);
			Destroy (other.gameObject);
		}

	}
}

