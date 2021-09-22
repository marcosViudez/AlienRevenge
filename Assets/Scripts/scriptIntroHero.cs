using UnityEngine;
using System.Collections;


public class scriptIntroHero : MonoBehaviour {

	private bool facingRight;

	// Use this for initialization
	void Start () 
	{
		Flip ();	// nos giramos hacia la mujer
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
		
	public void Flip()
	{
		// metodo para girar el sprite al moverse hacia atras
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
