using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceTracking : MonoBehaviour {

	public static float distance;

	// Use this for initialization
	void Start () {
		distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = "Distance : " + distance;
	}
}
