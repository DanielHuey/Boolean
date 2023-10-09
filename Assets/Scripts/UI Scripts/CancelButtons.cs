using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CancelButtons : MonoBehaviour {

	//public GameObject toHide;
	public AudioClip cancelSound;
	public AudioSource fx;
	GameObject eventSystem;
	//Button button;

	//UnityEvent evnt;

	void Start()
	{
		//button = GetComponent<Button> ();
		//toHide = transform.parent.gameObject;
		eventSystem = GameObject.FindGameObjectWithTag ("eventSYS");
		fx = FindObjectOfType<AudioSource>();
	}

		
	public void CancelQuit() 
	{
		eventSystem.GetComponent<Actions> ().Inact ();
		fx.PlayOneShot(cancelSound);
	}
}
