using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject ball = GameObject.Find ("Ball");
		gameObject.transform.position = new Vector3 (ball.transform.position.x, ball.transform.position.y);
	}
}
