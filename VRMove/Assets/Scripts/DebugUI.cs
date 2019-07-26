using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DebugUI : MonoBehaviour
{

    public TextMeshProUGUI controllerType;
    public TextMeshProUGUI hasStartedText;
    public TextMeshProUGUI infoBox;
    public TextMeshProUGUI trackerText;

    public void UpdateControllerType(string text)
    {
        controllerType.text = "Controller type: " + text;
    }

    public void UpdateHasStartedText(string text)
    {
        hasStartedText.text = "HasStarted: " + text;
    }

    public void UpdateInfoBox(string text)
    {
        infoBox.text = "Info:\n" + text;
    }

    public void UpdateTrackerDevice(int num)
    {
        trackerText.text = "Current Tracker: " + num;
    }
}
