using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed = 5;
	public float jumpHigh = 5;

	public bool isJumping;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(speed,0));

		if (Input.GetButtonDown("Jump") && !isJumping){
			rb.velocity = new Vector2(speed,jumpHigh);
			isJumping = true;
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
}
