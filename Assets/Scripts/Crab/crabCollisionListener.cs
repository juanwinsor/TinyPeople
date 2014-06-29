using UnityEngine;
using System.Collections;

public class crabCollisionListener : MonoBehaviour {

	crabController controller;

	public GameObject crabObject;

	// Use this for initialization
	void Start () {
		controller = crabObject.GetComponent<crabController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision collision )
	{ 
		if( collision.collider.gameObject.tag == "Ground" )
		{
			controller.setJumpFinished();
		}
	}

	/*
	void OnCollisionExit( Collision collision )
	{
		if( collision.collider.gameObject.tag == "Ground" )
		{
			controller.isOnGround = false;
		}
	}
	*/
}
