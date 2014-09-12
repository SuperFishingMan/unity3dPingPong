using UnityEngine;
using System.Collections;

public class BackgroundControl : MonoBehaviour {

	private float rotatePerMinutes = 0.5f;
	private float totalDeltaTime;

	// Use this for initialization
	void Start () {
		totalDeltaTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		totalDeltaTime += Time.deltaTime;
		while( totalDeltaTime>rotatePerMinutes ){
			gameObject.transform.eulerAngles += new Vector3(0.0f,0.0f,rotatePerMinutes);
			this.totalDeltaTime -= rotatePerMinutes;
		}
	}
}
