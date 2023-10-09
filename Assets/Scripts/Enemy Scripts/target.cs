using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class target : MonoBehaviour {

    public GameObject GiantGameSystem;
    GameObject player;
    Vector2 pos;
    public float rotSpeed = 500f;

    float speed;

	void Start () {
		
        GiantGameSystem = GameObject.FindWithTag("GGS");
        speed = GiantGameSystem.GetComponent<EnemyHandler>().enemySpeed;
		player = GameObject.FindWithTag("Player");
	}

    void FixedUpdate() 
    {
		pos = player.transform.position;

		float diffX = Mathf.Abs((pos.x - transform.position.x)/10);
		float diffY = Mathf.Abs((pos.y - transform.position.y)/10);

		//try using diffX and diffY for movement
    	transform.Rotate(new Vector3(0, 0, 1), rotSpeed*Time.fixedDeltaTime);
        float newX = Mathf.MoveTowards(transform.position.x, pos.x, diffX*speed*Time.fixedDeltaTime*(diffX+2f));
        float newY = Mathf.MoveTowards(transform.position.y, pos.y, diffY*speed*Time.fixedDeltaTime*(diffY+2f));
        transform.position = new Vector2(newX, newY);

    }
}