using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed = 5;
	public float maxSpeed = 15;
	public float jumpForce = 300f;	
	public bool isJumping = false;
	private Vector2 initPosition;
	public float dist = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		initPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {

		DistanceTracking.distance = Vector2.Distance(initPosition, transform.position);


		//stop adding more speed when jumping
		if(isJumping){
			rb.AddForce(new Vector2(speed,0));

		}else if(rb.velocity.magnitude > 0) {
			BecomeBigger();
		}

		//advoid jumping more than once
		if (Input.GetButtonDown("Jump") && !isJumping){
			rb.AddForce(new Vector2(0f,jumpForce));
			isJumping = true;
		}else if (rb.velocity.magnitude > maxSpeed){ // stop speeding up at a certain point
			rb.velocity = rb.velocity.normalized*maxSpeed;
		}else if(Input.GetKey(KeyCode.A)){
			rb.velocity = rb.velocity.normalized*(maxSpeed-10);
			rb.AddForce(new Vector2(speed,1f)); // after reduce the magnitude, this code will make the magnitude goes up again
		}
			
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			isJumping = false;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			isJumping = true;
		}
	}

	void BecomeBigger(){
		transform.localScale += new Vector3(0.001f,0.001f,0);
	}
}
