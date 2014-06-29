using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
	
	//private Vector3 targetForBall; // used to set direction
	private Vector3 kickForce; // apply force
	
	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "net") 
		{
			//TODO: have a splash screen for winning
		}
	}

	void OnDisable()
	{
		//print("BALL DESTROYED");
	}

	public void Kick()
	{
		// Create Random Vars
		//kickForce.x = Random.Range (-100, 100); // LEFT-RIGHT FORCE
		kickForce  = gameObject.transform.forward * Random.Range ( 500, 700); // FORWARD FORCE
		kickForce.z = Random.Range ( 400, 500); // UP FORCE

		//rigidbody.AddForce (0, 0, 150);
		rigidbody.AddForce (kickForce);
		
		// ball lives for x ammount of time
		Object.Destroy(gameObject, 10);
	}
}
