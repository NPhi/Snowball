using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform thePlatformGenerator;
	private Vector3 platformStartPoint;
	public PlayerController thePlayer;
	private Vector3 playerStartPoint;
	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;
	private ScoreManager distanceManager;

	// Use this for initialization
	void Start () {
		platformStartPoint = thePlatformGenerator.position;
		playerStartPoint = thePlayer.transform.position;


		theScoreManager = FindObjectOfType<ScoreManager>();
		distanceManager = FindObjectOfType<ScoreManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame(){
		StartCoroutine ("RestartGameCo");
	}

	public IEnumerator RestartGameCo(){
		theScoreManager.scoreIncreasing = false;
		distanceManager.distanceIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i<platformList.Length; i++) {
			platformList[i].gameObject.SetActive(false);
		}
		thePlayer.transform.position = playerStartPoint;
		thePlatformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;

		distanceManager.distanceCount = 0;
		distanceManager.distanceIncreasing = true;
	}
}
