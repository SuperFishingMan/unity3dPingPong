using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float positionZ = -10;


	public Vector3 speedVector3 = new Vector3();


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public virtual void Update () {
		// MousePosition
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 5;
		// lastPos
		Vector3 lastPos = this.gameObject.transform.position;
		// CameraPosition
		Vector3 positionOnScreen = Camera.main.ScreenToWorldPoint( mousePosition );
		Vector3 pos = this.gameObject.transform.position;
		this.gameObject.transform.position = pos + ( positionOnScreen-pos ) * (0.25f*(1-Time.deltaTime));

		// speed
		speedVector3 = this.gameObject.transform.position-lastPos;

		// Debug.Log( this.lastPosition- this.gameObject.transform.position );
	}
}
