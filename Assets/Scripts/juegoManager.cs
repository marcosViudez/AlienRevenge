using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class juegoManager : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			SceneManager.LoadScene ("intro");
		}
	}

	public void gameOver()
	{

	}

	public void finishLevel()
	{

	}


}
