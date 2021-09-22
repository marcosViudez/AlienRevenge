using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class panelHablarManager : MonoBehaviour {

	public float regXX;
	public float regYY;
	public float regZZ;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		transform.position = GameObject.FindGameObjectWithTag ("Player").GetComponent<RectTransform> ().position + new Vector3 (regXX, regYY, regZZ);
	}
}
