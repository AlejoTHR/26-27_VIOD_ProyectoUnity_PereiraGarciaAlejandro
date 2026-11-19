using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraRotationYAxis : MonoBehaviour
{

    // GETS THE CAMERA//

    // GET INPUT SYSTEM
    public InputSystem_Actions _input;


    [Header("------Camera Rotation Y AXIS------")]
    private float MousePosY;
    public float SensibilityY;
    private float AngleMin = -60;
    private float AngleMax = 60;
    public Transform _cameraTrsfm;
    public bool InvertCameraY = false;

    private void Start()
    {
        // ENABLE INPUT SYSTEM
        _input = new InputSystem_Actions();
        _input.Enable();


    }
    private void Update()
    {
        // GET MOUSE POSITION * SENSITIVITY
        // LEVER CONTROL
        if (!InvertCameraY) 
        MousePosY += -Mouse.current.delta.ReadValue().y * SensibilityY;
        // REGULAR CONTROL
        else MousePosY += Mouse.current.delta.ReadValue().y * SensibilityY;
    }

    private void LateUpdate()
    {
        // CLAMPS MOUSE Y VALUES BETWEEN MAX AND MIN
        MousePosY = Mathf.Clamp(MousePosY, AngleMin, AngleMax);

        // ROTATES CAMERA
        _cameraTrsfm.localEulerAngles = new Vector3(MousePosY, _cameraTrsfm.localEulerAngles.y, 0);

    }
}
