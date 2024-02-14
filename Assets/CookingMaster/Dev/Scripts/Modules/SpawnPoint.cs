using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float GizmoSize = 0.3f;
    [SerializeField] private MenuCardUI menuCardUI;
    private CustomerController m_CurrentCustomer;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, Vector3.one * GizmoSize);
    }

    public void SetCustomer(CustomerController controller, Dish dish)
    {
        m_CurrentCustomer = controller;
        menuCardUI.Set(dish);
    }

    public void RemoveCustomer()
    {
        m_CurrentCustomer = null;
        menuCardUI.ResetUI();
    }

    public CustomerController GetCurrentCustomer()
    {
        return m_CurrentCustomer;
    }
}
