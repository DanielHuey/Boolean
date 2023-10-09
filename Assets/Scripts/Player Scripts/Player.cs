using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Camera cam;
	public Vector2 playerPosition;
	public ConstantForce2D constantForce;
	float directionX = 0f;
	float directionY = 0f;
	public static float speed = 1f;

	// Use this for initialization
	void Start ()
	{
		cam = Camera.main;
	}
	void Update()
	{
		directionX = Input.GetAxisRaw("Horizontal");
		directionY = Input.GetAxisRaw("Vertical");
	}

	void FixedUpdate ()
	{
		if(speed<2f){
			speed+=(Time.fixedDeltaTime/100);
		}
		// LookAtPointer();
		playerPosition = transform.position;
		Vector2 min = cam.ViewportToWorldPoint (new Vector2 (0,0));
		Vector2 max = cam.ViewportToWorldPoint (new Vector2 (1,0.6f));
		playerPosition.x += speed*directionX*0.2f;
		playerPosition.y += speed*directionY*0.2f;
		// constantForce.relativeForce = new Vector2(directionX,directionY);

		playerPosition.x = Mathf.Clamp (playerPosition.x, min.x + .25f, max.x - .25f);
		playerPosition.y = Mathf.Clamp (playerPosition.y, min.y + .25f, max.y - .25f);

		transform.position = playerPosition;

	}

	// void LookAtPointer()
	// {
	// 	Vector3 posn = Input.mousePosition;
	// 	posn = cam.ScreenToWorldPoint(posn);

	// 	Vector2 dxn = new Vector2(
	// 		posn.x - transform.position.x,
	// 		posn.y - transform.position.y
	// 	);

	// 	transform.up = dxn;
	// }
}
