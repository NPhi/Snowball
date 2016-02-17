using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public static float score;					// The player's score.


	//private PlayerController playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.


	void Awake ()
	{

		score = 0;

		// Setting up the reference.
		//playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Start(){
	}


	void Update ()
	{
		// Set the score text.
		GetComponent<Text>().text = "Score: " + score;

		// If the score has changed...


		// Set the previous score to this frame's score.
		//previousScore = score;
	}

}
