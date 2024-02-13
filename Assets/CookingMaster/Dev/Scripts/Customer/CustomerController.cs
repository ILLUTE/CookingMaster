using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerController : MonoBehaviour
{
    public Dish m_CurrentDishOrder;

    [SerializeField] private Image m_FillImage;
    private float startTime;

    public void SetCustomer(Transform spawn, Dish info)
    {
        startTime = Time.time;
        transform.SetPositionAndRotation(spawn.position, spawn.rotation);
        m_CurrentDishOrder = info;
    }

    public void UpdateTime()
    {
        m_FillImage.fillAmount = 1 - (Time.time - startTime) / GetMaxDishTime();
        if (Time.time - startTime < GetMaxDishTime())
        {
            // Wait...
        }
        else
        {
            Debug.LogError("I am Out");
            // Leave
        }
    }

    public float GetMaxDishTime()
    {
        return m_CurrentDishOrder.m_Ingredients.Count * 2;
    }

    public void ServeDish(CreatedDishInfo dishInfo)
    {
        if(IsDishCorrect(dishInfo))
        {
            // good
        }
        else
        {
            // Blehhhh
        }
    }

    private bool IsDishCorrect(CreatedDishInfo dishMade)
    {
        List<string> actualDish = new(m_CurrentDishOrder.GetIngredientsOrder());
        List<string> createdDish = new(dishMade.choppedIngredients);
        int totalIngredients = actualDish.Count;

        if (createdDish.Count != totalIngredients) return false;

        for (int i = 0; i < actualDish.Count; i++)
        {
            if (!createdDish[i].Equals(actualDish[i]))
            {
                return false;
            }
        }

        return true;
    }
}