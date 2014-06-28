using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	// Apply these forces to ball
	[SerializeField] private Vector3 kickForce;
	
	// Use this for initialization
	void Start () 
	{
		// Create Random Vars
		kickForce.x = Random.Range (-100, 100);
		kickForce.y = Random.Range ( 100, 400);
		kickForce.z = Random.Range ( 400, 600);
		print (kickForce);

		//rigidbody.AddForce (0, 0, 150);
		rigidbody.AddForce (kickForce);

		// ball lives for x ammount of time
		Object.Destroy(gameObject, 10);
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
			Debug.Log ("YOU SCORED");
		}
	}

	void OnDisable()
	{
		Debug.Log ("BALL DESTROYED");
	}
}
