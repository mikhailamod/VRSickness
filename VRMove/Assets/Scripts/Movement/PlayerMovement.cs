using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string walkType = "walk";
    public void Move(float delta)
    {
        transform.position += new Vector3(0, 0, delta);

        if(!SoundManager.Instance.IsPlaying(walkType))
        {
            SoundManager.Instance.PlaySound(walkType);
        }
    }

    public void SetWalkType(string walkType)
    {
        this.walkType = walkType;
    }
}
