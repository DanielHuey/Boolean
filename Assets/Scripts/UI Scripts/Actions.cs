using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour {
    GameObject EventsManager;
	public GameObject[] menusToHideWhenFaderIsInactive;
	
	void Start () {
        EventsManager = GameObject.Find("EventSystem");
	}
    public void Act() 
    {
        EventsManager.GetComponent<UIScript>().FaderActive();
    }
    public void Inact()
    {
        EventsManager.GetComponent<UIScript>().FaderInactive();
		for(int i=0;i<menusToHideWhenFaderIsInactive.Length;i++)
		{
			menusToHideWhenFaderIsInactive[i].SetActive (false);	
		}
    }
}
