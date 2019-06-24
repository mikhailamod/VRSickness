using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void Move(float delta)
    {
        transform.position += new Vector3(0, 0, delta);
    }
}
