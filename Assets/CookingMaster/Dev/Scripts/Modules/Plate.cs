using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    [SerializeField] private Image m_CurrentlyOnPlateIngredient;
    private Ingredients currentlyOnPlate = null;

    public void AddIngredient(Ingredients ingredient)
    {
        if (currentlyOnPlate != null) return;

        currentlyOnPlate = ingredient;
        m_CurrentlyOnPlateIngredient.sprite = currentlyOnPlate.IngredientIcon;
        m_CurrentlyOnPlateIngredient.enabled = true;
    }

    public Ingredients GetCurrentIngredient()
    {
        Ingredients temp = currentlyOnPlate;
        currentlyOnPlate = null;
        m_CurrentlyOnPlateIngredient.enabled = false;
        return temp;
    }
}
