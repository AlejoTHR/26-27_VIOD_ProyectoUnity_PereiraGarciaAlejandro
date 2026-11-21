using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    // GLOBAL CHARACTER STATS
    [Header("------Movement------")]
    [SerializeField] public float WalkingSpeed;
    [SerializeField] public float SprintSpeed;
    [SerializeField] public float JumpForce;
    [SerializeField] public int JumpCount;
    [SerializeField] public int JumpCountMax;


    // CHARACTER MOVEMENT
     public virtual Vector3 Movement(){ return Vector3.zero; }
    // CHARACTER JUMP
     public virtual void Jump(){}
}
