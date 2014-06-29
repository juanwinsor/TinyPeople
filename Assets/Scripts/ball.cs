using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
	
	private Vector3 targetForBall; // used to set direction
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
			//Application.LoadLevel ("WaterJumperOver");
			//print ("YOU SCORED");
		}
	}

	void OnDisable()
	{
		//print("BALL DESTROYED");
	}

	public void SetTarget(Vector3 theTarget)
	{
		// Point Ball at Target
		gameObject.transform.LookAt (theTarget, Vector3.up);

		// Create Random Vars
		//kickForce.x = Random.Range (-100, 100); // LEFT-RIGHT FORCE
		kickForce.y = Random.Range ( 300, 400); // FORWARD FORCE
		//kickForce.z = Random.Range ( 100, 200); // UP FORCE

		//rigidbody.AddForce (0, 0, 150);
		rigidbody.AddForce (kickForce);
		
		// ball lives for x ammount of time
		Object.Destroy(gameObject, 10);
	}
}
