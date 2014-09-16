using UnityEngine;
using System.Collections;
public class Ball : MonoBehaviour {

	// effect prefav
	public GameObject effectFire;
	public GameObject effectDamage;


	// public
	public float ballCurvePower = 2.0f;
	public float ballSpeed = 5.0f;

	public Object[] sounds;

	// Stat
	private int turn = 0;

	// difficulty
	// private

	// speed
	private float ballSpeedX = 2.0f;
	private float ballSpeedY = 5.0f;
	private float ballSpeedZ = -5.0f;

	// 2d virtual force
	public float forceX = 0.0f;
	public float forceY = 0.0f;
	public float forceZ = 0.0f;
	// friction
	private float forceFriction = 0.98f;

	public float secondForceX = 0.0f;
	public float secondForceY = 0.0f;

	private float secondForceFriction = 0.98f;

	public int life = 10;
	public int turnCount = 0;


	// Use this for initialization
	void Start () {
		Physics.gravity = Vector3.zero;

		UpdateGUI();
	}
	
	// Update is called once per frame
	void Update () {

		// append speed
		ballSpeedX += forceX * Time.deltaTime;
		ballSpeedY += forceY * Time.deltaTime;
		// ballSpeedZ += forceZ * Time.deltaTime;

		// apply fliction for force
		forceX -= forceX * Time.deltaTime;
		forceY -= forceY * Time.deltaTime;
		// forceZ *= forceZ * (1-Time.deltaTime);

		forceX += secondForceX * Time.deltaTime;
		forceY += secondForceY * Time.deltaTime;

		// Debug.Log( forceX );
		

		// apply transform
		gameObject.transform.position += new Vector3( this.ballSpeedX*Time.deltaTime, this.ballSpeedY*Time.deltaTime, this.ballSpeedZ*Time.deltaTime );
		// gameObject.transform.position += new Vector3( 0.0f, -0.06f, this.bal );
		// Debug.Log( this.ballSpeedY );
	}

	// Hit call from Player instance

	public void HitFromPlayer( Vector3 speedVector3 ){
		Debug.Log( speedVector3 );
		this.secondForceX = -speedVector3.x*this.ballCurvePower;
		this.secondForceY = -speedVector3.y*this.ballCurvePower;
		// this.forceY += 0;//speedVector3.y * 5;
	}

	private void UpdateGUI(){
		GameObject go = GameObject.Find("UIText");
		TextMesh tm = (TextMesh)go.GetComponent(typeof(TextMesh));
		string ui = "Life:"+life+"\nTurn:"+turnCount;
		tm.text = ui;
	}

	private void TurnAdd(){
		turnCount ++;
		UpdateGUI();
	}
	private void LifeMinus(){
		life --;
		if( life < 0 ){
			Application.LoadLevel(0);
		}else{
			UpdateGUI();
		}
	}

	void OnCollisionEnter( Collision col ){
		string tag = col.gameObject.tag;
		// Confrict of Wall
		if( tag.Equals("WallGround") || tag.Equals("WallRoof") ){
			this.ballSpeedY *= -1;
			
			//Singleton<SoundPlayer>.instance.playSE( wallHitSound );
		}
		else if( tag.Equals("WallLeft") || tag.Equals("WallRight")){
			this.ballSpeedX *= -1;
			//Singleton<SoundPlayer>.instance.playSE( wallHitSound );
		}

		// Confrict Player1,2
		if( tag.Equals( "Player1" )){

			this.ballSpeedZ = this.ballSpeed;
			this.ballSpeed += 0.25f;
			this.ballCurvePower += 1.0f;
			this.Update();

			TurnAdd();

			Instantiate( (GameObject)effectFire, gameObject.transform.position, Quaternion.identity );
		}else if( tag.Equals("Player2")){

			this.ballSpeedZ = -this.ballSpeed;
			this.ballSpeed += 0.25f;
			this.ballCurvePower += 1.0f;
			this.Update();

			TurnAdd();

			Instantiate( (GameObject)effectFire, gameObject.transform.position, Quaternion.identity );
		}

		// Out
		if( tag.Equals("Player1Wall") ){
			Instantiate( (GameObject)effectDamage, gameObject.transform.position, Quaternion.identity );

			transform.localPosition = new Vector3( 0.0f, 0.0f, 0.0f );


			LifeMinus();

		}else if( tag.Equals("Player2Wall") ){

		}

	}
}
