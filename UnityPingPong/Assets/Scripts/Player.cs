using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float positionZ = -10;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// MousePosition
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 5;
		// CameraPosition
		Vector3 positionOnScreen = Camera.main.ScreenToWorldPoint( mousePosition );

		print ( positionOnScreen );

		gameObject.transform.position = positionOnScreen;
	}
}
