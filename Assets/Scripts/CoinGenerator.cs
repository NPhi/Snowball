﻿using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

	public ObjectPool coinPool;
	public ObjectPool KillBox;

	public float distanceBetweenKillBoxs;

	public float distanceBetweenCoin;

	public void SpawnCoins(Vector3 startPosition){
	
		GameObject coin1 = coinPool.GetPooledObject ();
		coin1.transform.position = startPosition;
		coin1.SetActive (true);

		GameObject coin2 = coinPool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoin, startPosition.y, startPosition.z);
		coin2.SetActive (true);

		GameObject coin3 = coinPool.GetPooledObject ();
		coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoin, startPosition.y, startPosition.z);
		coin3.SetActive (true);
	}


	public void SpawnKillBoxes(Vector3 startPosition){
		
		GameObject KillBox1 = coinPool.GetPooledObject ();
		KillBox1.transform.position = startPosition;
		KillBox1.SetActive (true);
		
		GameObject KillBox2 = coinPool.GetPooledObject ();
		KillBox2.transform.position = new Vector3(startPosition.x - distanceBetweenCoin, startPosition.y, startPosition.z);
		KillBox2.SetActive (true);

	}

}
