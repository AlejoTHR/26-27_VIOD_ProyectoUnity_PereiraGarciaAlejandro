using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundedDetection : MonoBehaviour
{

    [Header("------Detectiom------")]
    public bool Grounded = false;

    public Vector3 GroundDetectionDistanceOffset;
    public float GroundDetectionRadius;
    public float GroundDetectionDistance;
    public LayerMask Detect;

    public bool IsGrounded()
    {
        bool DetectsGround;
        // GROUND DETECTION
        RaycastHit hit;
        Physics.SphereCast(transform.position + GroundDetectionDistanceOffset, GroundDetectionRadius, Vector3.down, out hit, GroundDetectionDistance, Detect);

        // SEND SPHERECAST FOR DETECTION
        if (Physics.SphereCast(transform.position + GroundDetectionDistanceOffset, GroundDetectionRadius, Vector3.down, out hit, GroundDetectionDistance, Detect)){

            DetectsGround = true;
        }
        else{

            DetectsGround = false;
        }

        return DetectsGround;
    }
    private void LateUpdate()
    {
        Grounded = IsGrounded();
    }


    private void OnDrawGizmos()
    {   
        //PLAYER JUMP SPHERECAST
        Gizmos.DrawWireSphere(transform.position + GroundDetectionDistanceOffset + Vector3.down * GroundDetectionDistance, GroundDetectionRadius);

    }

}
