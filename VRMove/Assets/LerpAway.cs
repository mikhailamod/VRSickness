using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAway : MonoBehaviour
{
	[SerializeField]
	private Transform endTransform;
	[SerializeField]
	private Transform startTransform;

	[SerializeField]
	[Range(0f, 1f)]
	private float lerpPct = 0.5f;
	public bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move){
	
	transform.position = Vector3.MoveTowards(startTransform.position, endTransform.position, lerpPct);
	}
    }
}
