using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[Range(10f,30f)]
	public float speed;

	Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	void Update()
	{
		Vector2 max = cam.ViewportToWorldPoint (new Vector2 (1,1));
		if(transform.position.y>(max.y+5f))
		{
			Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{
		Vector2 pos = transform.position;
		pos.y += speed * Time.fixedDeltaTime;
		transform.position = pos;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag=="enemy")
		{
			Destroy(gameObject);
		}
	}
}
