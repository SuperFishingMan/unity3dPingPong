using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.gravity = Vector3.zero;
		Vector3 force = new Vector3(0f,100f,-1000f );
		gameObject.rigidbody.AddForce( force );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
