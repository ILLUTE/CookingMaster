using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderReadyTrigger : MonoBehaviour
{
    public SpawnPoint spawnPoint;

    public CustomerController GetCustomer()
    {
        return spawnPoint.GetCurrentCustomer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
