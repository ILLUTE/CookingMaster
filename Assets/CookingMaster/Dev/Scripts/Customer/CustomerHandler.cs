using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerHandler : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> customerSpawns = new();
    private List<CustomerController> m_CurrentCustomer = new();
    public float CustomerRefillTime = 5.0f;

    private float lastCheckTime;

    private Dictionary<CustomerController, SpawnPoint> m_CustomerSpawnPoints = new();
    private void Update()
    {
        CreateCustomer();
        UpdateExistingCustomers();
    }

    private void CreateCustomer()
    {
        if (Time.time < lastCheckTime + CustomerRefillTime) return;

        if (IsPlaceAvailableAtRestaurant(out SpawnPoint playerPoint))
        {
            lastCheckTime = Time.time;
            CustomerController customer = Instantiate(Locator.Instance.ResourceManagerInstance.customer);
            Dish randomDish = GetARandomDish();
            if (randomDish == null)
            {
                Debug.LogError("Customer is being setup with No Dish");
            }
            playerPoint.SetCustomer(customer, randomDish);
            customer.SetCustomer(playerPoint.transform, randomDish);
            m_CustomerSpawnPoints.Add(customer, playerPoint);
            m_CurrentCustomer.Add(customer);
        }
    }

    public void RemoveACustomer(CustomerController customer)
    {
        m_CurrentCustomer.Remove(customer);
        m_CustomerSpawnPoints[customer].RemoveCustomer();
        m_CustomerSpawnPoints.Remove(customer);
        Destroy(customer.gameObject);
    }

    private bool IsPlaceAvailableAtRestaurant(out SpawnPoint point)
    {
        foreach (SpawnPoint spawn in customerSpawns)
        {
            if (spawn.GetCurrentCustomer() == null)
            {
                point = spawn;
                return true;
            }
        }
        point = null;
        return false;
    }

    private Dish GetARandomDish()
    {
        List<Dish> AllDishes = new(Locator.Instance.ResourceManagerInstance.m_Dishes);
        if (AllDishes.Count == 0)
        {
            Debug.Log("No Dishes in Resource Manager");
            return null;
        }
        int x = UnityEngine.Random.Range(0, AllDishes.Count);

        return AllDishes[x];
    }

    private void UpdateExistingCustomers()
    {
        for (int i = 0; i < m_CurrentCustomer.Count; i++)
        {
            if (m_CurrentCustomer[i] == null) continue;

            m_CurrentCustomer[i].UpdateTime();
        }
    }
}
