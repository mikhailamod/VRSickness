using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindings : MonoBehaviour
{
    public static readonly KeyCode RELOAD_SCENE = KeyCode.Space;
    public static readonly KeyCode INCREASE_SCALE = KeyCode.N;
    public static readonly KeyCode DECREASE_SCALE = KeyCode.M;
    public static readonly KeyCode MOVE_FORWARD = KeyCode.W;
    public static readonly KeyCode INCREASE_TRACKED_OBJECT = KeyCode.KeypadPlus;
    public static readonly KeyCode DECREASE_TRACKED_OBJECT = KeyCode.KeypadMinus;
    public static readonly KeyCode START_STEPPER = KeyCode.Z;
    public static readonly KeyCode STEPPER_THRESHOLD_INCREASE = KeyCode.B;
    public static readonly KeyCode STEPPER_THRESHOLD_DECREASE = KeyCode.V;
    public static readonly KeyCode CHANGE_TO_TETHER = KeyCode.T;
    public static readonly KeyCode CHANGE_TO_STEPPER = KeyCode.S;
    public static readonly KeyCode CHANGE_TO_CONTROLLER = KeyCode.C;
}
