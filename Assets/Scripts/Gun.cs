using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;	
	public float shotDelay = 2.0f;
	public float timer;
	public float shotAngle = 30f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if(timer > shotDelay){
			timer = 0;
			Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-speed, shotAngle);
		}

	}


}
