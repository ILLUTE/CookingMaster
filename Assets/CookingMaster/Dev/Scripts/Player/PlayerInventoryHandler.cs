using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryHandler : MonoBehaviour
{ 
    public List<Ingredients> PickedUpIngredients = new();
    public CreatedDishInfo createdDish = new();

    public Ingredients AddIngredientToBowl()
    {
        if (PickedUpIngredients.Count == 0) return null;
        Ingredients ingredient = PickedUpIngredients[0];
        PickedUpIngredients.RemoveAt(0);
        return ingredient;
    }

    public bool CanPickIngredients()
    {
        return PickedUpIngredients.Count < 2;
    }

    public void AddIngredientsInInventory(Ingredients ingredient)
    {
        if (!CanPickIngredients()) return;
        if (PickedUpIngredients.Contains(ingredient)) return;
        PickedUpIngredients.Add(ingredient);
        GetComponent<PlayerController>().InvokeIngredientPicked(ingredient);
    }

    public void AddChoppedVeggies(string choppedVeggieName)
    {
        if (createdDish.choppedIngredients.Contains(choppedVeggieName)) return;
        createdDish.choppedIngredients.Add(choppedVeggieName);
    }
}
