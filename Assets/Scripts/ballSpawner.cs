using UnityEngine;
using System.Collections;

public class ballSpawner : MonoBehaviour {
	
	// GIVE LOCATION TO BALL
	public GameObject m_Ball;
	public GameObject m_Target;
	private Bounds    m_FieldBounds;
	public Vector3  m_LaunchPosition;
	
	// TIME BETWEEN SHOTS
	public int m_ShootTimer = 0;
	
	// Use this for initialization
	void Start () 
	{
		// Get mesh componenet from BallSpawnObj's parent
		// Store bounds of mesh inside global variable
		Mesh aMesh  = transform.parent.GetComponent<MeshFilter>().mesh;
		m_FieldBounds = aMesh.bounds;
		gameObject.transform.localPosition = m_FieldBounds.center;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_ShootTimer ++;
		
		if (m_ShootTimer > 30) 
		{
			m_ShootTimer = 0;
			m_LaunchPosition.x = Random.Range(m_FieldBounds.min.x, m_FieldBounds.max.x);
			m_LaunchPosition.z = Random.Range(m_FieldBounds.min.z, m_FieldBounds.max.z);
			gameObject.transform.localPosition = m_LaunchPosition;
			shoot ();
		}
	}
	
	void shoot()
	{
		GameObject aBall = (GameObject)Instantiate (m_Ball);//, m_LaunchPosition.position, m_LaunchPosition.rotation);
		ball ballComponent = aBall.GetComponent<ball> ();
		ballComponent.SetTarget (m_Target.transform.position);
	}
}
