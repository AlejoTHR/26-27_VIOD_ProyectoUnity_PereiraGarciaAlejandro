using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerCharacterClass : CharacterClass
{

    // GET INPUT SYSTEM
    public InputSystem_Actions _input;

    // COMPONENTS
    Rigidbody _rb;
    CapsuleCollider _cpslClldr;

    [Header("-----PLAYER MOVEMENT------")]
    public float BackWalkSpeed = 0.5f;
    public float SideWalkSpeed = 0.75f;
    public float DashForce;


    private void Start()
    {
        // ENABLE INPUT SYSTEM
        _input = new InputSystem_Actions();
        _input.Enable();

        _rb = GetComponent<Rigidbody>();
        _cpslClldr = GetComponent<CapsuleCollider>();


    }

    public void Dash(){
        // READ PLAYER INPUT
        Vector2 DashDir = _input.Player.Move.ReadValue<Vector2>();
        // SET TO LOCAL INSTEAD OF WORLD
        DashDir = transform.TransformDirection(DashDir);


        if (_input.Player.Dash.WasPressedThisFrame()){
            Debug.Log("DASH");

            if (DashDir.y > 0 && DashDir.x == 0 || DashDir.y == 1){ // INPUT IS FORWARD
                _rb.AddForce(transform.forward * DashForce, ForceMode.VelocityChange);

            }else if (DashDir.x > 0 && DashDir.y < 1){ // INPUT IS RIGHT
                _rb.AddForce(transform.forward * DashForce, ForceMode.VelocityChange);

            }else if (DashDir.x > 0 && DashDir.y < 1){ // INPUT IS LEFYT
                _rb.AddForce(transform.forward * DashForce, ForceMode.VelocityChange);
                _rb.linearVelocity = Vector3.zero;
            }
        }

    }

    public override Vector3 Movement(){
        // READ PLAYER INPUT AND APLY SPEED
        Vector3 inputDir = _input.Player.Move.ReadValue<Vector2>() * getWalkingSpeed();
        
        // READ "z" AS "y"
        inputDir.z = inputDir.y;
        // "y" = 0
        inputDir.y = 0;

        //SIDEWARDS | SPEED EQUALS TO 75%
        if (inputDir.x != 0) inputDir *= SideWalkSpeed;
        // BACKWARDS | SPEED EQUALS TO 50%
        if (inputDir.z < 0) inputDir *= BackWalkSpeed;
       
        // SET TO LOCAL INSTEAD OF WORLD
        inputDir = transform.TransformDirection(inputDir);

        return inputDir * Time.deltaTime;
    }

    public override void Jump(){
        Debug.Log("JUMP");
        if(_input.Player.Jump.WasPressedThisFrame())
        _rb.AddForce(Vector3.up * DashForce, ForceMode.VelocityChange);


    }

    private void Update(){
        Dash();

    }

    private void FixedUpdate(){
        transform.position += Movement();

    }

}
