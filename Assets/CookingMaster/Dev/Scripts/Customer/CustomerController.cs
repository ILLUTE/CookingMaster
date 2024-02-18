using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerController : MonoBehaviour
{
    public Dish m_CurrentDishOrder; // current Dish Order

    [SerializeField] private Image m_FillImage;
    private float startTime;


    private bool IsLookingToOrder = false;

    public void SetCustomer(Transform spawn, Dish info)
    {
        startTime = Time.time;
        transform.SetPositionAndRotation(spawn.position, spawn.rotation);
        m_CurrentDishOrder = info;
        IsLookingToOrder = true;
    }

    public void UpdateTime()
    {
        if (!IsLookingToOrder) return;
        m_FillImage.fillAmount = 1 - (Time.time - startTime) / GetMaxDishTime();

        if (Time.time - startTime > GetMaxDishTime())
        {
            Leave();
        }
    }

    private void Leave()
    {
        IsLookingToOrder = false;
        Locator.Instance.CustomerHandlerInstance.RemoveACustomer(this);
    }

    public float GetMaxDishTime() // Get Time For A Customer.
    {
        return m_CurrentDishOrder.m_Ingredients.Count * GlobalConstants.CustomerWaitPerIngredient;
    }

    public void ServeDish(CreatedDishInfo dishInfo, PlayerController playerController)// Serve A Dish
    {
        Debug.Log("Dish was Served");
        Locator.Instance.ScoreManagerInstance.UpdateScore(playerController, IsDishCorrect(dishInfo) ? GlobalConstants.CorrectDish : GlobalConstants.InCorrectDish);
        float timeTaken = Time.time - startTime;
        float ratio = timeTaken / GetMaxDishTime();

        // ratio -> 70%? Provide Powerup
        Leave();
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
