using UnityEngine;
using System.Collections;

public class Cpu : Player {

	private GameObject ball;
	private float startZ = 0;

	private int status = 0;

	// Use this for initialization
	void Start () {
		Debug.Log( this );
		ball = GameObject.Find("Ball");
		startZ = gameObject.transform.position.z;
	}
	
	public override void Update(){
		// base.Update ();
		// Debug.Log (GameObject.Find ("Ball"));
		// gameObject.transform.position = new Vector3( 

		gameObject.transform.position = new Vector3( ball.transform.position.x, ball.transform.position.y, startZ );


		// switch status

	}


}
