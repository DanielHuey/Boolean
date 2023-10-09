using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject frontShootingPoint;
    public GameObject[] sideShootingPoints = new GameObject[2];
    public GameObject bulletPrefab;
    public GameObject superBulletPrefab;
	public GameObject shotFxPrefab;
	public bool primaryShot = false;
    public bool chargedShot = false;
	AudioSource fx;
	public AudioClip shotSound;

	[Range(0.05f,1f)]
	public float shotDelay = 0.05f;

	float shotVerifier;

	void Start()
	{
		fx = FindObjectOfType<AudioSource>();
	}
    
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
        	primaryShot = true;
       } else if(Input.GetKeyUp(KeyCode.Space)){
        	primaryShot = false;
       }
       if(Input.GetButtonDown("Fire3"))
       {
        	chargedShot = true;
       } else if(Input.GetButtonUp("Fire3")){
			chargedShot = false;
       }
    }
	void FixedUpdate()
	{
		shotVerifier += Time.fixedDeltaTime;

		if(primaryShot && shotVerifier >= shotDelay){
			shotVerifier = 0f;
			fx.PlayOneShot(shotSound);
			Instantiate(bulletPrefab,sideShootingPoints[0].transform.position,Quaternion.Euler(0,0,0));
			Instantiate(bulletPrefab,sideShootingPoints[1].transform.position,Quaternion.Euler(0,0,0));
			Instantiate(shotFxPrefab,sideShootingPoints[0].transform.position,Quaternion.Euler(0,0,90),sideShootingPoints[0].transform);
			Instantiate(shotFxPrefab,sideShootingPoints[1].transform.position,Quaternion.Euler(0,0,90),sideShootingPoints[1].transform);
		}
	}
}
