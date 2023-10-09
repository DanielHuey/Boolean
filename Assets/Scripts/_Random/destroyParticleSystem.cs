using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticleSystem : MonoBehaviour
{
	float time = 0f;
    void Update()
    {
		time+=Time.deltaTime;
		if(time>=0.4f)
			Destroy(gameObject);
    }
}
