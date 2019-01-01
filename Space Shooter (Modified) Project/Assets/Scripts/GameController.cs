using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public GameObject asteroid;
	public Vector3 spawnValues;
	public float startTime = 5f;
	public float enemyRate = 1f;

	void Start()
	{
		InvokeRepeating ("SpawnAsteroids", startTime, enemyRate);
	}

	void SpawnAsteroids()
	{
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (asteroid, spawnPosition, spawnRotation);
	}
}
