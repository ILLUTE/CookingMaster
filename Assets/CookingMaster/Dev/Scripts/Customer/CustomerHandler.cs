using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerHandler : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> customerSpawns = new();
    private List<CustomerController> m_CurrentCustomer = new();
    public float CustomerRefillTime = 5.0f;

    private float lastCheckTime;
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
            playerPoint.SetCustomer(customer);
            customer.SetCustomer(playerPoint.transform, randomDish);
            m_CurrentCustomer.Add(customer);
        }
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
        foreach(CustomerController controller in m_CurrentCustomer)
        {
            if (controller == null) continue;

            controller.UpdateTime();
        }
    }
}
