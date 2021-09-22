using UnityEngine;
using System.Collections;

public class DesapareceSuelo : MonoBehaviour {

	private Animator animSueloDissapier;
	private bool destrozar;

	// Use this for initialization
	void Start () 
	{
		animSueloDissapier = GetComponent<Animator>();	// componente de las animaciones
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (destrozar) 
		{
			animSueloDissapier.SetBool ("SueloOff", true);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			destrozar = true;
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			destrozar = true;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			destrozar = true;
		}
	}

	public void destrozarCollider()
	{
		animSueloDissapier.SetBool ("SueloOff", false);
		Destroy (gameObject);
		destrozar = false;
	}
}
