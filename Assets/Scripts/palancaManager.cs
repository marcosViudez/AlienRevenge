using UnityEngine;
using System.Collections;

public class palancaManager : MonoBehaviour {

	private Animator animPalanca;

	// Use this for initialization
	void Start () 
	{
		animPalanca = GetComponent<Animator> ();
	}

	public void activarPalanca ()
	{
		animPalanca.SetBool ("palancaMover", true);
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
