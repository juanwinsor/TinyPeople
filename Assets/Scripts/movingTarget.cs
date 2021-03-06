﻿using UnityEngine;
using System.Collections;

public class movingTarget : MonoBehaviour {

	private int m_Timer = 0;
	private Bounds m_NetBounds;
	private Vector3 m_TargetPosition;

	// Use this for initialization
	void Start () 
	{
		// Get mesh componenet from BallTarget's parent
		// Store bounds of mesh inside global variable
		Mesh aMesh  = transform.parent.GetComponent<MeshFilter>().mesh;
		m_NetBounds = aMesh.bounds;
		gameObject.transform.localPosition = m_NetBounds.center;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Timer ++;
		
		if (m_Timer > 60) 
		{
			m_Timer = 0;
			m_TargetPosition.x = Random.Range(m_NetBounds.min.x, m_NetBounds.max.x);
			m_TargetPosition.z = Random.Range(m_NetBounds.min.z + 5, m_NetBounds.max.z + 5);
			gameObject.transform.localPosition = m_TargetPosition;
		}
	}
}
