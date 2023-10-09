using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
	public GameObject player;
	Vector3 playerPosition;
	Vector3 direction;
	float sevenSeconds = 0f;

    void Start()
    {
		player = GameObject.FindWithTag("Player");
		playerPosition = player.transform.position;
		direction = playerPosition-transform.position;
		transform.up = direction;
    }

    void FixedUpdate()
    {
		transform.position += transform.up*Time.fixedDeltaTime*10f;
		sevenSeconds+=Time.fixedDeltaTime;
		if(sevenSeconds>=7.0f)
			Destroy(gameObject);

    }
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject == player)
			Destroy(gameObject);
	}
}
