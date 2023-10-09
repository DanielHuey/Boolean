using UnityEngine;
using System.Collections;

public class EnemyHandler : MonoBehaviour 
{
    [Range(3f, 9f)]
    public float enemySpeed = 3f;

    public GameObject basicEnemy;
    public GameObject shootingEnemy;
    public GameObject homingEnemy;
	Camera cam;
	Vector2 cMax,cMin;
	public float bEnDelay=1.5f;//b enemy
	public float sEnDelay=3f;//s enemy
	public float hEnDelay=5f;//h enemy


	void Start ()
	{
		cam = Camera.main;
        SpeedIncrease();
		StartCoroutine (SpeedIncrease ());
		cMax = cam.ViewportToWorldPoint (new Vector2 (1, 1));
		cMin = cam.ViewportToWorldPoint (new Vector2 (0, 0));
		StartCoroutine (spawn1());
		StartCoroutine (spawn2());
		StartCoroutine (spawn3());
	}

	IEnumerator SpeedIncrease()
	{
		while (enemySpeed < 9f)
		{
			yield return new WaitForSeconds(1f);
			enemySpeed += 0.06f;
		}
	}
	IEnumerator spawn1()
	{
		while (true)
		{
			yield return new WaitForSeconds(bEnDelay);
			if(bEnDelay>0.8f)
				bEnDelay-=(enemySpeed/100);
			Instantiate(basicEnemy,new Vector3(Random.Range(cMin.x,cMax.x),cMax.y+2f,0),Quaternion.Euler(0,0,0));
		}
	}
	IEnumerator spawn2()
	{
		yield return new WaitForSeconds(15f);
		while (true)
		{
			yield return new WaitForSeconds(sEnDelay);
			if(sEnDelay>2.5f)
				sEnDelay-=(enemySpeed/50);
			Instantiate(shootingEnemy,new Vector3(Random.Range(cMin.x,cMax.x),cMax.y+2f,0),Quaternion.Euler(0,0,0));
		}
	}
	IEnumerator spawn3()
	{
		yield return new WaitForSeconds(45f);
		while (true)
		{
			yield return new WaitForSeconds(hEnDelay);
			if(hEnDelay>4.5f)
				hEnDelay-=(enemySpeed/30);
			Instantiate(homingEnemy,new Vector3(Random.Range(cMin.x,cMax.x),cMax.y+2f,0),Quaternion.Euler(0,0,0));
		}
	}

}
