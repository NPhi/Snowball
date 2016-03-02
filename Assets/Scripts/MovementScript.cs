using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float Speed =1;
	private Vector3 direction;
	public float jump;
	private bool doublejump;

	public Transform floorCheck;
	public float floorCheckRadius;
	public LayerMask whatIsFloor;
	private bool onFloor;
	public bool rope;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityOnPlayer;
	private Rigidbody2D rb2d;

	public float SpeedPerFrame
	{
		get { return this.Speed * Time.deltaTime; }
	}
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		gravityOnPlayer = rb2d.gravityScale;
	}

	void FixedUpdate()
	{
		onFloor = Physics2D.OverlapCircle(floorCheck.position, floorCheckRadius, whatIsFloor);
	}

	void Update () {

		this.direction = DetectKeyboardInput();


		Move(this.direction);

		if (onFloor)
		{
			doublejump = false;
		}

		if(Input.GetKeyDown(KeyCode.Space) && onFloor)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump);

		}
		if (Input.GetKeyDown(KeyCode.Space) && !onFloor && !doublejump)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump);
			doublejump = true;
		}
	

	}
	private Vector3 DetectKeyboardInput()
	{
		Vector3 movementDirection = Vector3.zero;

		if  (Input.GetKey(KeyCode.D))
		{
			movementDirection += Vector3.right;
		}

		if (Input.GetKey(KeyCode.A))
		{
			movementDirection += Vector3.left;
		}


		return movementDirection;
	}

	private void Move(Vector3 movementDirection)
	{
		this.gameObject.transform.Translate(movementDirection * this.SpeedPerFrame);
	}
}
