using UnityEngine;
using System.Collections;

public class flipWeapon : MonoBehaviour {

	private bool facingRight;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x > 0 && facingRight) 
		{
			flip ();
		}

		if (transform.position.x < 0 && !facingRight) 
		{
			flip ();
		}

	}

	void flip()
	{
		// metodo para girar el sprite al moverse hacia atras
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
