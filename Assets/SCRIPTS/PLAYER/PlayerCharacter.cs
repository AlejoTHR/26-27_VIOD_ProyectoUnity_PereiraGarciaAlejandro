using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerCharacter : CharacterClass
{

    // GET INPUT SYSTEM
    public InputSystem_Actions _input;

    // COMPONENTS
    Rigidbody _rb;
    CapsuleCollider _cpslClldr;
    GroundedDetection _GroundDetetction;
    PlayerShootController _ShootScript;

    [Header("-----PLAYER MOVEMENT------")]
    public float BackWalkSpeed = 0.5f;
    public float SideWalkSpeed = 0.75f;

    private void Start()
    {
        // ENABLE INPUT SYSTEM
        _input = new InputSystem_Actions();
        _input.Enable();

        // GET COMPONENTES
        _rb = GetComponent<Rigidbody>();
        _cpslClldr = GetComponent<CapsuleCollider>();

        _GroundDetetction = GetComponent<GroundedDetection>();
        _ShootScript = GetComponent<PlayerShootController>();

    }
    public override Vector3 Movement(){

        // READ PLAYER INPUT AND APLY SPEED
        Vector3 inputDir = _input.Player.Move.ReadValue<Vector2>() * WalkingSpeed;
        
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

    public override void Jump()
    {
        // JUMP INPUT
        if (_input.Player.Jump.WasPressedThisFrame() && JumpCount < JumpCountMax)
        {
            // VERTICAL FORCE
            _rb.AddForce(Vector3.up * JumpForce);
                        
            // JUMP COUNT
            JumpCount++;
        }
    }

    private void Update(){
        
        Jump();
        //SHOOTING
        _ShootScript.Shoot();
        _ShootScript.Reload();


    }
    private void FixedUpdate(){
        transform.position += Movement();
        // REVISAR EN CLASE
        if (_GroundDetetction.Grounded) JumpCount = 0;
    }

}
