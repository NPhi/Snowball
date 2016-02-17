using UnityEngine;
using System.Collections;

public class PlatformGenrator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	//public GameObject[] thePlatforms;
	public float[] thePlatformsWidths;
	private int platformSelector;



	public ObjectPool[] theObjectPools;

	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold;

	public ObjectPool killBoxPool;
	//private CoinGenerator theKillBoxGenerator;
	public float randomKillBoxThreshold;

	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
		thePlatformsWidths = new float[theObjectPools.Length];

		for(int i =0; i<theObjectPools.Length; i++)
		{
			thePlatformsWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
		//theKillBoxGenerator = FindObjectOfType<CoinGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range(0, theObjectPools.Length);

			transform.position =  new Vector3(transform.position.x + (thePlatformsWidths[platformSelector]/2) + distanceBetween, transform.position.y, transform.position.z);



			GameObject newPlatform;newPlatform = theObjectPools[platformSelector].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation; 
			newPlatform.SetActive(true);
			if(Random.Range(0f, 100f)< randomCoinThreshold){
				theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y+1f, transform.position.z));
			}


			if(Random.Range(0f, 100f)< randomKillBoxThreshold){
				GameObject KillBoxes = killBoxPool.GetPooledObject();

				float Killbox_XPosition = Random.Range(-thePlatformsWidths[platformSelector]/2f, thePlatformsWidths[platformSelector]/2f);

				Vector3 KillboxPosition =  new Vector3(Killbox_XPosition, 1f, 0f);

				KillBoxes.transform.position = transform.position + KillboxPosition;
				KillBoxes.transform.rotation= transform.rotation;
				KillBoxes.SetActive(true);
			}

			//Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
			}

	
	}
}
