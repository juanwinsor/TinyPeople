using UnityEngine;
using System.Collections;

public class crabController : MonoBehaviour {


	private Animator animator;

	const int maxVelocityAccumulator = 10;
	int velocityAccumulatorLeft = 0;
	int velocityAccumulatorRight = 0;

	float velocity = 0;

	float keyPressTimerPreviousLeft = 0;
	float keyPressTimerCurrentLeft = 0;
	float keyPressTimerPreviousRight = 0;
	float keyPressTimerCurrentRight = 0;
	float keyPressTimerInterval = 0.15f;

	const int constantVelocity = 3;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		//-- left key down
		if( Input.GetKeyDown( KeyCode.A ) )
		{
			//-- check if the key press is a rapid succession
			if( (keyPressTimerCurrentLeft - keyPressTimerPreviousLeft) < keyPressTimerInterval )
			{
				//-- it is a rapid key press so we increment the velocity accumulator
				velocityAccumulatorLeft += 1;
				//-- clamp the velocity accumulator to the max
				Mathf.Min( velocityAccumulatorLeft, maxVelocityAccumulator ); 
			}
		}
		//-- left key up
		if( Input.GetKeyUp( KeyCode.A ) )
		{
			keyPressTimerPreviousLeft = keyPressTimerCurrentLeft;

		}
		keyPressTimerCurrentLeft = Time.time;
		if( (keyPressTimerCurrentLeft - keyPressTimerPreviousLeft) > keyPressTimerInterval )
		{
			if( Input.GetKey( KeyCode.A ) )
			{
				velocityAccumulatorLeft = constantVelocity;
			}
			else
			{
				velocityAccumulatorLeft = 0;
			}
			
		}


		//-- right key down
		if( Input.GetKeyDown( KeyCode.D ) )
		{
			//-- check if the key press is a rapid succession
			if( (keyPressTimerCurrentRight - keyPressTimerPreviousRight) < keyPressTimerInterval )
			{
				//-- it is a rapid key press so we increment the velocity accumulator
				velocityAccumulatorRight += 1;
				//-- clamp the velocity accumulator to the max
				Mathf.Min( velocityAccumulatorRight, maxVelocityAccumulator ); 
			}
		}
		//-- left key up
		if( Input.GetKeyUp( KeyCode.D ) )
		{
			keyPressTimerPreviousRight = keyPressTimerCurrentRight;
			
		}
		keyPressTimerCurrentRight = Time.time;
		if( (keyPressTimerCurrentRight - keyPressTimerPreviousRight) > keyPressTimerInterval )
		{
			if( Input.GetKey( KeyCode.D ) )
			{
				velocityAccumulatorRight = constantVelocity;
			}
			else
			{
				velocityAccumulatorRight = 0;
			}
		}



		//-- calculate the left key velocity
		float leftVelocity = velocityAccumulatorLeft * -0.5f;

		//-- calculate the right key velocity
		float rightVelocity = velocityAccumulatorRight * 0.5f;

		//-- calculate the net velocity the player is inputting
		velocity = leftVelocity + rightVelocity;

		//-- set the velocity for the animation states
		setVelocity( velocity );



		Debug.Log( "velocity: " + velocity );

	}

	void setVelocity( float velocity )
	{
		if( animator )
		{
			animator.SetFloat( "velocity", velocity );
		}
	}
}
