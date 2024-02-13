using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Dish")]
public class Dish : ScriptableObject
{
    public string DishName;
    public List<Ingredients> m_Ingredients;

    public List<string> GetIngredientsOrder()
    {
        List<string> IngredientsSequence = new();
        foreach(Ingredients i in m_Ingredients)
        {
            IngredientsSequence.Add(i.IngredientName);
        }

        return IngredientsSequence;
    }
}
