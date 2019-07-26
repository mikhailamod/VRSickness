using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderUpdater : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void UpdateText(float value)
    {
        text.text = (Mathf.Round(value*100)/100.0) + "";
    }
}
