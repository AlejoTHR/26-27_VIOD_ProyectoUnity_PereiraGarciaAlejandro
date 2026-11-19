using System;
using UnityEngine;

public class GroundedDetection : MonoBehaviour
{

    [Header("------Detectiom------")]
    public Vector3 GroundDetectionDistanceOffset;
    public float GroundDetectionRadius;
    public float GroundDetectionDistance;
    public bool Grounded = false;
    public LayerMask Detect;

    public bool IsGrounded()
    {
        // GROUND DETECTION
        RaycastHit hit;
        Physics.SphereCast(transform.position + GroundDetectionDistanceOffset, GroundDetectionRadius, Vector3.down, out hit, GroundDetectionDistance, Detect);

        // SEND SPHERECAST FOR DETECTION
        if (Physics.SphereCast(transform.position + GroundDetectionDistanceOffset, GroundDetectionRadius, Vector3.down, out hit, GroundDetectionDistance, Detect))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        return Grounded;
    }

    private void Update()
    {
        Debug.Log(IsGrounded());
    }


    private void OnDrawGizmos()
    {   
        //PLAYER JUMP SPHERECAST
        Gizmos.DrawWireSphere(transform.position + GroundDetectionDistanceOffset + Vector3.down * GroundDetectionDistance, GroundDetectionRadius);

    }

}
