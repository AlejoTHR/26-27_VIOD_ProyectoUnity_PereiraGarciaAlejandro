using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    // GET INPUT SYSTEM
    public InputSystem_Actions _input;

    // DICE SIZES
    public enum DiceSize
    {
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
    }

    [Header("------Ammunition------")]
    public float Ammo;
    public DiceSize CurrentDice;

    [Header("------Shooting Detection------")]
    public Transform origin;
    public Transform _camera;
    public float ShootRange;
    public float ShootRayRadius;
    public LayerMask Damagable;
    public bool ShootDetection;

    private void Start()
    {       
        // ENABLE INPUT SYSTEM
        _input = new InputSystem_Actions();
        _input.Enable();

        CurrentDice = DiceSize.D20;
    }

    public void Shoot()
    {
        if (_input.Player.Shoot.WasPerformedThisFrame() && Ammo > 0)
        {
            // RAY CAST
            RaycastHit hit;
            ShootDetection = Physics.SphereCast(origin.transform.position, ShootRayRadius, _camera.forward, out hit);
            if (ShootDetection)
            {
                Debug.Log(hit.collider.name);
            }

            // AMMO
            Ammo--;
        }
    }

    public void Reload()
    {
        // REALOD INPIT
        if (_input.Player.Reload.WasPerformedThisFrame()){
            
            // RANDOM AMMOUNT OF BULLETS
            Ammo = (int)Random.Range(1f, (float)CurrentDice);

        }
    }


}
