using UnityEngine;
using System.Collections;

public class ballSpawner : MonoBehaviour {

	// SPRAY THOSE WATER CUBES!
	public GameObject m_Ball;
	public Transform m_LaunchPosition;
	
	// COUNT THAT TIME!
	public int m_ShootTimer;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_ShootTimer ++;
		
		if (m_ShootTimer > 3) 
		{
			m_ShootTimer = 0;
			shoot ();
		}
	}
	
	void shoot()
	{
		Instantiate(m_Ball, m_LaunchPosition.position, m_LaunchPosition.rotation);
		//Rigidbody projectileBody = projectile.rigidbody;
		//projectileBody.AddForce (m_HorizontalForce, m_VerticalForce, m_ForwardForce, ForceMode.Impulse);
	}
}
