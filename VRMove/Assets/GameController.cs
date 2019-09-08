using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This Singleton class controls the state of the environment and initial values.
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    float controllerSpeed = 1.75f;

    int deviceNumber = 3;

    float stepperForce = 40f;
    float stepperThreshold = 0;
    float stepperDragAmount = 0.05f;
    float stepperMaxSpeed = 2f;
    public MovementState state;


    public float StepperThreshold { get => stepperThreshold; set => stepperThreshold = value; }
    public float StepperForce { get => stepperForce; set => stepperForce = value; }
    public float StepperDragAmount { get => stepperDragAmount; set => stepperDragAmount = value; }
    public float StepperMaxSpeed { get => stepperMaxSpeed; set => stepperMaxSpeed = value; }
    public float ControllerSpeed { get => controllerSpeed; set => controllerSpeed = value; }
    public int DeviceNumber { get => deviceNumber; set => deviceNumber = value; }

    public void UpdateDevice(float value)
    {
        deviceNumber = (int)value;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
