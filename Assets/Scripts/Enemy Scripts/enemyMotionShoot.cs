using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMotionShoot : MonoBehaviour
{
	public GameObject enemyBullet;
	public GameObject shootPoint;

	[Range(0.8f,1.2f)]
	public float speedMultiplier = 0.8f;

	float speed;
	public bool canShoot = false;
	Camera cam;
	Vector2 shootLine;

    void Start(){
		cam = Camera.main;
		shootLine = cam.ViewportToWorldPoint (new Vector2 (0,0.75f)); //this is from a quarter of the screen
    }

	void Update(){
		speed = speedMultiplier * GameObject.FindWithTag("GGS").GetComponent<EnemyHandler>().enemySpeed;
	}

	void FixedUpdate(){
		transform.position -= new Vector3(0,(Time.fixedDeltaTime*speed),0);
		if(canShoot && (transform.position.y <= shootLine.y))
		{
			canShoot = false;
			Instantiate(enemyBullet,shootPoint.transform.position,Quaternion.Euler(0,0,0));
		}
	}
}
