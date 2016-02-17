using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float speedMultiplyer;
	private float speedStore;

	public float speedIncreaseMilestone;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;
	private float speedIncreaseMilestoneStore;



	public float jumpforce;
	public float jumpTime;
	private float jumpTimeCounter;

	private Rigidbody2D RB2D;

	public bool grounded;
	public LayerMask ground;
	public Transform groundCheck;
	public float groundCheckRadius;

	//private Collider2D playerCollider;
	private Animator snowBallAnimations;
	public GameManager theGameManager;

	// Use this for initialization
	void Start () {
		RB2D = GetComponent<Rigidbody2D> ();

		//playerCollider = GetComponent<Collider2D> ();

		snowBallAnimations = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		speedStore = speed;

		speedMilestoneCountStore = speedMilestoneCount;

		speedIncreaseMilestoneStore = speedIncreaseMilestone;

	
	}
	
	// Update is called once per frame
	void Update () {

		//grounded = Physics2D.IsTouchingLayers (playerCollider, ground);

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, ground);

		if (transform.position.x > speedMilestoneCount) {

			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplyer;
			speed = speed*speedMultiplyer;
		}

		RB2D.velocity = new Vector2 (speed, RB2D.velocity.y);

		if (Input.GetButtonDown("Jump")) {
			if(grounded){
				RB2D.velocity = new Vector2(RB2D.velocity.x, jumpforce);
			}
		}
		if (Input.GetButton ("Jump")) {
			if(jumpTimeCounter > 0 )
			{
				RB2D.velocity = new Vector2(RB2D.velocity.x, jumpforce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetButtonUp ("Jump")) {
			jumpTimeCounter =0;
		}
		if (grounded) {
			jumpTimeCounter=jumpTime;
		}
		snowBallAnimations.SetFloat ("Speed", RB2D.velocity.x);
		snowBallAnimations.SetBool ("Grounded", grounded);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Killbox") {
			theGameManager.RestartGame();
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}
	}
}
