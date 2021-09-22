using UnityEngine;
using System.Collections;

public class ovniIntro : MonoBehaviour {

	private Animator animOvni;
	public GameObject canvas;

	// Use this for initialization
	void Start () 
	{
		animOvni = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void cogerMujer()
	{
		canvas.GetComponent<introManager> ().desapareceMujer ();
	}

	public void moverse()
	{
		animOvni.SetBool ("idleIntro", false);
		animOvni.SetBool ("moverse", true);
	}

	public void ovniPararse()
	{
		animOvni.SetBool ("moverse", false);
		animOvni.SetBool ("Tractor", true);
		canvas.GetComponent<introManager> ().gritar = true;
	}
}
