using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "net") 
		{
			//TODO: have a splash screen for winning
			//Application.LoadLevel ("WaterJumperOver");
			Debug.Log ("GOAL");
		}
	}
}
