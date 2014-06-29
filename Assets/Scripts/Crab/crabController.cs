using UnityEngine;
using System.Collections;

public class crabController : MonoBehaviour {

	public LayerMask raycastExclusionMask;

	GameObject parentObject;

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

	public bool jumped = false;
	bool isFalling = false;
	public bool isOnGround = true;


	float airVelocityX = 0;


	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();

		parentObject = transform.parent.gameObject;
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
		float leftVelocity = velocityAccumulatorLeft * -1.0f;
		//-- calculate the right key velocity
		float rightVelocity = velocityAccumulatorRight * 1.0f;

		//-- calculate the net velocity the player is inputting
		velocity = leftVelocity + rightVelocity;

		//-- set the velocity for the animation states
		setVelocity( velocity );


		//-- update the velocity only if ont he ground
		if( isOnGround )
		{
			Vector3 oldVelocity = parentObject.rigidbody.velocity;
			oldVelocity.x = velocity;
			parentObject.rigidbody.velocity = oldVelocity;
		}		 
		Debug.Log( "velocity: " + velocity );


		//-- check if jump button was pressed
		if( Input.GetKeyDown( KeyCode.Space ) && isOnGround )
		{


			if( Input.GetKey( KeyCode.D ) )
			{
				if( animator )
				{
					animator.SetTrigger( "rightPressed" );
				}
			}
			else if( Input.GetKey( KeyCode.A ) )
			{
				if( animator )
				{
					animator.SetTrigger( "leftPressed" );
				}
			}

			//-- if the up key is pressed then flag it
			if( Input.GetKey( KeyCode.W ) )
			{
				if( animator )
				{
					animator.SetTrigger( "upPressed" );
				}
			}

			//airVelocityX = velocity;
			isOnGround = false;
			jumped = true;
			parentObject.rigidbody.AddForce( 0, 500.0f, 0, ForceMode.Force );
			setJump();
		}						


		/*
		//-- check if the player is falling by check if he has jumped and the velocity is downward
		if( jumped && transform.parent.rigidbody.velocity.y < 0 )
		{
			isFalling = true;
		}
		*/

		/*
		if( animator )
		{
			animator.Update( Time.deltaTime );
		}
		*/
	}

	void setVelocity( float velocity )
	{
		if( animator )
		{
			animator.SetFloat( "velocity", velocity );
		}
	}

	void setJump()
	{
		if( animator )
		{
			animator.SetTrigger( "jump" );
		}
	}

	public void setJumpFinished()
	{
		if( isOnGround == false )
		{
			isOnGround = true;
			jumped = false;
			isFalling = false;
			
			if( animator )
			{
				animator.SetTrigger( "jumpFinished" );
			}
		}
	}
}
