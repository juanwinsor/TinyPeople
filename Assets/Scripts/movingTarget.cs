using UnityEngine;
using System.Collections;

public class movingTarget : MonoBehaviour {

	private Bounds m_NetBounds;
	private int m_DirectionTimer = 0;
	private int Axis = 0;
	private Vector3 m_TargetPosition;

	// Use this for initialization
	void Start () 
	{
		Mesh aMesh  = transform.parent.GetComponent<MeshFilter>().mesh;
		m_NetBounds = aMesh.bounds;
		gameObject.transform.localPosition = m_NetBounds.center;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_DirectionTimer ++;
		
		if (m_DirectionTimer > 60) 
		{
			m_DirectionTimer = 0;
			Axis = Random.Range (1, 5); 
			//print ("DIRECTION CHANGE");
			print (Axis);
		}

		if (Axis == 1) 
		{
			m_TargetPosition.x++;
			gameObject.transform.localPosition = m_TargetPosition;
		}
		else if (Axis == 2) 
		{
			m_TargetPosition.x--;
			gameObject.transform.localPosition = m_TargetPosition;
		} 
		else if (Axis == 3) 
		{
			m_TargetPosition.y++;
			gameObject.transform.localPosition = m_TargetPosition;
		} 
		else if (Axis == 4) 
		{
			m_TargetPosition.y--;
			gameObject.transform.localPosition = m_TargetPosition;
		}
	}
}
