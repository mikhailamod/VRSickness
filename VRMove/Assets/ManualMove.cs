using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMove : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;
    public float speed;
    public Transform camera;
    public float distance = 10f;

    // Update is called once per frame
    void Update()
    {
        float currentDis = Mathf.Abs(camera.transform.position.z - transform.position.y);
        if(currentDis < distance)
        {
            Vector3 newPos = new Vector3(transform.position.x,
                                    transform.position.y,
                                    transform.position.z + distance);
            transform.position = newPos;
        }
        //move up
        if(Input.GetKey(KeyCode.O))
        {
            if(transform.position.y < maxHeight)
            {
                float temp = transform.position.y + speed;
                Vector3 vec = new Vector3(transform.position.x, temp, transform.position.z);
                transform.position = vec;
            }
        }
        if (Input.GetKey(KeyCode.P))
        {
            if (transform.position.y > minHeight)
            {
                float temp = transform.position.y - speed;
                Vector3 vec = new Vector3(transform.position.x, temp, transform.position.z);
                transform.position = vec;
            }
        }
    }
}
