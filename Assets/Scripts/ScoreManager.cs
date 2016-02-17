using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecound;
	public bool scoreIncreasing;
	public bool distanceIncreasing;



	public Text distanceText;
	public float distanceCount;
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey("Highscore")) {
			highScoreCount = PlayerPrefs.GetFloat("Highscore");
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) {
			scoreCount += pointsPerSecound * Time.deltaTime;
		}
		
		if (distanceIncreasing) {
			distanceCount += pointsPerSecound * Time.deltaTime;
		}

	



		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat("Highscore", highScoreCount);
		}

		scoreText.text = "Score: " + Mathf.Round(scoreCount) ;
		distanceText.text = "Distance: " + Mathf.Round(distanceCount) + "m" ;
		highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
	
	}

	public void AddScore(int pointsTooAdd){
		scoreCount += pointsTooAdd;
	}
}
