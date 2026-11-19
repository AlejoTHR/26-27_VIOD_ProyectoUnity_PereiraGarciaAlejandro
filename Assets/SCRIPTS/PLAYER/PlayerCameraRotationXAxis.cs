using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraRotationXAxis : MonoBehaviour
{
    // GOES ON PLAYER //


    // GET INPUT SYSTEM
    public InputSystem_Actions _input;

    [Header("------Camera Rotation X AXIS------")]
    private float MousePosX;
    public float SensibilityX;
    public bool InvertCameraX = false;

    void Start()
    {
        // ENABLE INPUT SYSTEM
        _input = new InputSystem_Actions();
        _input.Enable();

        // MOUSE IS CENTERED AND ERASED FROM THE SCREEN
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // GET MOUSE POSITION
        // LEVER CONTROL
        if (!InvertCameraX)        
        MousePosX = Mouse.current.delta.ReadValue().x* SensibilityX;
        // REGULAR CONTROL
        else MousePosX = -Mouse.current.delta.ReadValue().x* SensibilityX;

    }
    private void LateUpdate()
    {
        // CAMERA ROTATION RELATIVE TO "MousePosX" AND Y AXIS ROTATION
        transform.Rotate(new Vector3(0, MousePosX, 0));
    }

}

