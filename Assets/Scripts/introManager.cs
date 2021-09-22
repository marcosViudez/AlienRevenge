using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class introManager : MonoBehaviour {

	public GameObject panelHero;
	public GameObject panelMujer;
	public GameObject panelMarciano;
	public GameObject hero;
	public GameObject ovni;
	public GameObject mujer;

	public Text dialogoHero;
	public Text dialogoMujer;
	public Text dialogoMarciano;

	public bool gritar;
	public int hiScore;
	public Text HIscoreTexto;

	public AudioClip sonidoBoton;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(comenzarIntro ());
		hiScore = PlayerPrefs.GetInt ("scorePlayer");
		HIscoreTexto.text = hiScore.ToString ();
	}

	public void resetScore()
	{
		// reseteamos el hiScore
		PlayerPrefs.SetInt ("scorePlayer", 0);
		hiScore = PlayerPrefs.GetInt ("scorePlayer");
		HIscoreTexto.text = hiScore.ToString ();
	}

	IEnumerator comenzarIntro()
	{
		ovni.GetComponent<Animator> ().SetBool ("idleIntro", true);
		mujer.GetComponent<Image> ().enabled = true;
		panelHero.GetComponent<Image> ().enabled = false;
		panelMujer.GetComponent<Image> ().enabled = false;
		panelMarciano.GetComponent<Image> ().enabled = false;
		StartCoroutine (dialogoUno ());
		yield return new WaitForSeconds (800 * Time.deltaTime);
		StartCoroutine (dialogoDos ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gritar) {
			StartCoroutine (gritoHombre ());
		}
	}

	public void irJuego()
	{
		GetComponent<AudioSource> ().PlayOneShot (sonidoBoton);
		SceneManager.LoadScene ("nivel01");
	}

	public void irOpciones()
	{
		GetComponent<AudioSource> ().PlayOneShot (sonidoBoton);
		SceneManager.LoadScene ("Opciones");
	}

	public void irControles()
	{
		GetComponent<AudioSource> ().PlayOneShot (sonidoBoton);
		SceneManager.LoadScene ("Controles");
	}

	public void Salir()
	{
		GetComponent<AudioSource> ().PlayOneShot (sonidoBoton);
		Application.Quit ();	
	}

	IEnumerator dialogoUno()
	{
		yield return new WaitForSeconds (40 * Time.deltaTime);
		hablarHero ("Voy cortar algo mas de leña y vamos a cenar");
		yield return new WaitForSeconds (120 * Time.deltaTime);
		cerrarHero ();

		yield return new WaitForSeconds (40 * Time.deltaTime);
		hablarMujer ("deacuerdo cari......");
		yield return new WaitForSeconds (120 * Time.deltaTime);
		cerrarMujer	();

		yield return new WaitForSeconds (40 * Time.deltaTime);
		hablarMujer ("¿!Que es ese ruido!?");
		yield return new WaitForSeconds (120 * Time.deltaTime);
		cerrarMujer	();

		girarHero ();
		ovni.GetComponent<ovniIntro> ().moverse ();
		yield return new WaitForSeconds (40 * Time.deltaTime);
		girarHero ();
		hablarHero ("......");
		hablarMujer ("......");
		yield return new WaitForSeconds (120 * Time.deltaTime);
		cerrarHero ();
		cerrarMujer	();
	}

	IEnumerator dialogoDos()
	{
		hablarMarciano ("JAJAJAJAJAJA");
		yield return new WaitForSeconds (80 * Time.deltaTime);
		cerrarMarciano ();
		yield return new WaitForSeconds (80 * Time.deltaTime);
		hablarMarciano ("Tu mujer es mia");
		yield return new WaitForSeconds (80 * Time.deltaTime);
		hablarMarciano ("SOLDADOS DESEMBARCAR Y QUEMADLO TODO");
		yield return new WaitForSeconds (120 * Time.deltaTime);
		cerrarMarciano ();
		yield return new WaitForSeconds (120 * Time.deltaTime);
		// Debug.Log ("comenzar");
		StartCoroutine(comenzarIntro ());									// volver empezar bucle intro
	}

	IEnumerator gritoHombre()
	{
		hablarHero ("AHHHHHHHH !!!!!!");
		yield return new WaitForSeconds (120 * Time.deltaTime);
		cerrarHero ();
		gritar = false;
	}

	public void desapareceMujer()
	{
		mujer.GetComponent<Image> ().enabled = false;
	}

	void girarHero()
	{
		hero.GetComponent<scriptIntroHero> ().Flip ();
	}

	void hablarHero(string texto)
	{
		panelHero.GetComponent<Image> ().enabled = true;
		dialogoHero.GetComponent<Text> ().enabled = true;
		dialogoHero.text = texto;
	}

	void hablarMujer(string texto)
	{
		panelMujer.GetComponent<Image> ().enabled = true;
		dialogoMujer.GetComponent<Text> ().enabled = true;
		dialogoMujer.text = texto;
	}

	void hablarMarciano(string texto)
	{
		panelMarciano.GetComponent<Image> ().enabled = true;
		dialogoMarciano.GetComponent<Text> ().enabled = true;
		dialogoMarciano.text = texto;
	}

	void cerrarHero()
	{
		panelHero.GetComponent<Image> ().enabled = false;
		dialogoHero.GetComponent<Text> ().enabled = false;
	}

	void cerrarMujer()
	{
		panelMujer.GetComponent<Image> ().enabled = false;
		dialogoMujer.GetComponent<Text> ().enabled = false;
	}

	void cerrarMarciano()
	{
		panelMarciano.GetComponent<Image> ().enabled = false;
		dialogoMarciano.GetComponent<Text> ().enabled = false;
	}

}
