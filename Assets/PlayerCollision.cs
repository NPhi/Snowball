using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
	public GameObject explosionPrefab = null;
	private Rigidbody2D myRb;
	
	public bool onLadder;
	public float Speed;
	public float Velocity;
	public float Store;
	
	void Start()
	{
		myRb = GetComponent<Rigidbody2D>();
		Store = myRb.gravityScale;
	}
	
	void Update()
	{
		if (onLadder)
		{
			myRb.gravityScale = 0f;
			Velocity = Speed * Input.GetAxisRaw("Vertical");
			myRb.velocity = new Vector2(myRb.velocity.x, Speed);
			
		}
		else
		{
			myRb.gravityScale = Store;
			
		}
	}
	
	private Vector2 DetectKeyboardInput()
	{
		// Set our direction vector to zero.
		// Here we use Vector2.zero, which is equivalent to (0, 0).
		Vector2 movementDirection = Vector2.zero;
		
		
		
		// Return the resulting movement direction, based on the keyboard input.
		return movementDirection;
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Wall"
		    || other.tag == "Obstacle")
		{
			DestroyMe();
		}
		
		if (other.tag == "Barrier")
		{
			Destroy(other.gameObject);
			DestroyMe();
		}
		
		/*if (other.tag == "Coin")
		{
			PlayerData.Instance.Score++;
			Destroy(other.gameObject);
		}*/
	}
	
	private void DestroyMe()
	{
		Destroy(this.gameObject);
		GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
		explosionObject.transform.position = this.transform.position;
	}
}