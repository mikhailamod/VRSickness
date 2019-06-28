using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runaway : MonoBehaviour
{

public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	float dist = Vector3.Distance(playerObject.transform.position, transform.position);
	//Debug.Log(dist);
        if (dist<5){
		Debug.Log("Time to run");
		AnimationControl animationControl = GetComponent<AnimationControl>();
		animationControl.SetAnimation("isWalking");
	}
    }
}
