using UnityEngine;
using System.Collections;

public class BgScroll : MonoBehaviour {
	public float bgspeed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 offset = new Vector2(Time.time * bgspeed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;

	
	}
}
