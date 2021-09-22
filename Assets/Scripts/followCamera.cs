using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class followCamera : MonoBehaviour {

	public Transform targetPos;
	public float regX = 0f;
	public float regY = 264f;
	public float regZ = -1f;

	// movimiento de la camara siguiendo al player
	void Update () 
	{

		transform.position = new Vector3(targetPos.position.x,targetPos.position.y,0) + new Vector3(regX,regY,regZ);

	}
}