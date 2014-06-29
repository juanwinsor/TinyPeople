using UnityEngine;
using System.Collections;

public class ballSpawner : MonoBehaviour {
	
	// GIVE LOCATION TO BALL
	public int m_ShootTimer = 0;
	private Bounds    m_FieldBounds;
	public Vector3    m_LaunchPosition;
	
	public GameObject m_Ball;
	public GameObject m_Target;
	// TIME BETWEEN SHOTS

	
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
			m_LaunchPosition.x = Random.Range(m_FieldBounds.min.x, m_FieldBounds.max.x); // left right
			m_LaunchPosition.y = 1;
			m_LaunchPosition.z = Random.Range(m_FieldBounds.min.z, m_FieldBounds.max.z); // forward backward

			//gameObject.transform.localPosition = m_LaunchPosition;
			shoot (m_LaunchPosition);
		}
	}
	
	void shoot( Vector3 aLaunchPos)
	{
		gameObject.transform.position = aLaunchPos;
		gameObject.transform.LookAt (m_Target.transform.position);
		GameObject aBall = (GameObject)Instantiate (m_Ball, aLaunchPos, gameObject.transform.rotation);

		// get a ball instance, call it's kick func
		ball ballComponent = aBall.GetComponent<ball> ();
		ballComponent.Kick ();
	}
}
