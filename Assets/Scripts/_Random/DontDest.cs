using UnityEngine;
using System.Collections;

public class DontDest : MonoBehaviour {

	void Update () {
        DontDestroyOnLoad(gameObject);
	}
}
