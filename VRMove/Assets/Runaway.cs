using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runaway : MonoBehaviour
{

public GameObject playerObject;
public GameObject horseObstacle;
private bool beingHandled = false;
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
		
		animationControl.SetAnimation("isRunning");
		if( /*some case  */ !beingHandled )
    {
        StartCoroutine( HandleIt() );
    }
		

	}
    

IEnumerator HandleIt()
{
    beingHandled = true;
    // process pre-yield
    yield return new WaitForSeconds( 0.1f );
    // process post-yield
LerpAway lerpAway = horseObstacle.GetComponent<LerpAway>();
		lerpAway.move = true;
    beingHandled = false;
}
}
}