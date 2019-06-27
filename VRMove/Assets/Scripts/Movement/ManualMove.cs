using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Debug class used to test stepper without actually using tracked object
/// </summary>
public class ManualMove : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float maxHeight;
    public float minHeight;
    public float speed;
    public Transform camera;
    public float distance = 10f;

    // Update is called once per frame
    void Update()
    {
        //keep cube certain distance in front of camera
        transform.position = (transform.position - camera.transform.position).normalized
                            * distance + camera.transform.position;
        Vector3 fixedX = new Vector3(0, transform.position.y, transform.position.z);
        transform.position = fixedX;
        
        //move up
        if(Input.GetKey(upKey))
        {
            if(transform.position.y < maxHeight)
            {
                float temp = transform.position.y + speed;
                Vector3 vec = new Vector3(transform.position.x, temp, transform.position.z);
                transform.position = vec;
            }
        }
        //move down
        if (Input.GetKey(downKey))
        {
            if (transform.position.y > minHeight)
            {
                float temp = transform.position.y - speed;
                Vector3 vec = new Vector3(transform.position.x, Mathf.Max(temp,minHeight), transform.position.z);
                transform.position = vec;
            }
        }
    }
}
