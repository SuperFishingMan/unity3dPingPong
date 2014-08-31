using UnityEngine;
using System.Collections;
public class Ball : MonoBehaviour {

	// speed
	private float ballSpeedX = 2.0f;
	private float ballSpeedY = 5.0f;
	private float ballSpeedZ = -9.0f;

	// 2d virtual force
	private float forceX = 0.0f;
	private float forceY = 0.0f;
	private float forceZ = 0.0f;
	// friction
	private float forceFriction = 0.98f;


	// Use this for initialization
	void Start () {
		Physics.gravity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		// append speed
		ballSpeedX += forceX * Time.deltaTime;
		ballSpeedY += forceY * Time.deltaTime;
		// ballSpeedZ += forceZ * Time.deltaTime;

		// apply fliction for force
		forceX *= forceX * (1-Time.deltaTime);
		forceY *= forceY * (1-Time.deltaTime);
		// forceZ *= forceZ * (1-Time.deltaTime);
		

		// apply transform
		gameObject.transform.position += new Vector3( this.ballSpeedX*Time.deltaTime, this.ballSpeedY*Time.deltaTime, this.ballSpeedZ*Time.deltaTime );
		// gameObject.transform.position += new Vector3( 0.0f, -0.06f, this.bal );
		// Debug.Log( this.ballSpeedY );
	}

	void OnCollisionEnter( Collision col ){
		string tag = col.gameObject.tag;
		// Confrict of Wall
		if( tag.Equals("WallGround") || tag.Equals("WallRoof") ){ this.ballSpeedY *= -1; }
		else if( tag.Equals("WallLeft") || tag.Equals("WallRight")){ this.ballSpeedX *= -1; }

		// Confrict Player1,2
		if( col.gameObject.tag.Equals( "Player1" ) || col.gameObject.tag.Equals("Player2")){


			this.ballSpeedZ *= -1;
			this.Update();
		}
	}
}
