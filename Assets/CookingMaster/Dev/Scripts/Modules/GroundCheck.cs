using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private float m_GroundCheckRadius;
    [SerializeField] private LayerMask m_NonGround;
    private Collider[] colliders = new Collider[14];

    public bool IsGrounded()
    {
        int length = Physics.OverlapSphereNonAlloc(m_GroundCheck.position, m_GroundCheckRadius, colliders, ~m_NonGround);
        return length > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_GroundCheck.position, m_GroundCheckRadius);
    }
}
