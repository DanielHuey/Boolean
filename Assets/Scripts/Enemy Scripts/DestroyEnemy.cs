using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour
{
	Camera cam;
	Vector2 destroyLine;
	public GameObject deathFx;//Death Effect

	void Start()
	{
		cam = Camera.main;
		destroyLine = cam.ViewportToWorldPoint (new Vector2 (0,-0.25f));
		//destroyLine = cam.ViewportToWorldPoint (new Vector2 (0,0)) - new Vector2 (0,-0.25f); //quarter screen below screen
	}

	void Update()
	{
		if(transform.position.y<=destroyLine.y)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag=="Bullet")
		{
			//add a point to player from here

			//then destroy The Enemy
			Ds();
		}else if(col.gameObject.tag=="Player"){
			Ds();//no Point for Player
		}
	}
	void Ds(){
		Instantiate(deathFx,transform.position,Quaternion.Euler(0,0,0));
		Destroy(gameObject);
	}
}

