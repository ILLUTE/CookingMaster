using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float GizmoSize = 0.3f;
    private CustomerController m_CurrentCustomer;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, Vector3.one * GizmoSize);
    }

    public void SetCustomer(CustomerController controller)
    {
        m_CurrentCustomer = controller;
    }

    public CustomerController GetCurrentCustomer()
    {
        return m_CurrentCustomer;
    }
}
