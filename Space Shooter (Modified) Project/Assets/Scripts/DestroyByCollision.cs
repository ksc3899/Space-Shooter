using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByCollision : MonoBehaviour 
{
	public GameObject playerExplosion;
	public GameObject asteroidExplosion;

	Canvas canvas;
	Animator anim;
	GameObject gameController;
	GameRestart gameRestart;

	void Awake()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gameRestart = gameController.GetComponent<GameRestart> ();

		canvas = (Canvas)FindObjectOfType (typeof(Canvas));

		anim = canvas.GetComponent<Animator> ();
	}
		
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			return;
		}

		if (other.gameObject.tag == "Player") 
		{
			Instantiate (playerExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
			anim.SetTrigger ("GameOver");
			gameRestart.Update ();
		}

		if (other.gameObject.tag == "Enemy")
		{
			Instantiate (asteroidExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
		}

		if (other.gameObject.tag == "Bolt")
		{
			ScoreManager.score += 10;
		}

		Instantiate (asteroidExplosion, gameObject.transform.position, gameObject.transform.rotation);
		Destroy (gameObject);
		Destroy (other.gameObject);	
	}
}