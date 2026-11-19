using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    // GLOBAL CHARACTER STATS
    [Header("------Movement------")]
    [SerializeField] float WalkingSpeed;
    [SerializeField] float SprintSpeed;
    [SerializeField] float JumpForce;
    [SerializeField] int JumpCount;
    [SerializeField] int JumpCountMax;

    // Getters
    protected float getWalkingSpeed(){
        return WalkingSpeed;
    }
    protected float getSprintSpeed(){
        return SprintSpeed;
    }
    protected float getJumpForce(){
        return WalkingSpeed;
    }
    protected int getJumpCount(){
        return JumpCount;
    }
    protected int getJumpCountMax(){
        return JumpCountMax;
    }

    // Setters
    protected float setWalkingSpeed(){
        return WalkingSpeed;
    }
    protected float setSprintSpeed(){
        return SprintSpeed;
    }
    protected float setJumpForce(){
        return WalkingSpeed;
    }
    protected int setJumpCount(){
        return JumpCount;
    }
    protected int setJumpCountMax(){
        return JumpCountMax;
    }

    // CHARACTER MOVEMENT
     public virtual Vector3 Movement(){ return Vector3.zero; }
    // CHARACTER JUMP
     public virtual void Jump(){}
}
