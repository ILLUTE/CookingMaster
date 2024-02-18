using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartUI : MonoBehaviour
{
    [SerializeField] private List<Image> IngredientIcon = new();
    private Dictionary<Ingredients, Image> cartItems = new();

    public void Add(Ingredients ingredient)
    {
        if (cartItems.ContainsKey(ingredient)) return;
        Image image = GetDisabledImage();
        image.gameObject.SetActive(true);
        image.sprite = ingredient.IngredientIcon;
        cartItems.Add(ingredient, image);
    }

    public void Remove(Ingredients ingredient)
    {
        if (!cartItems.ContainsKey(ingredient)) return;
        Image image = cartItems[ingredient];
        image.gameObject.SetActive(false);
        cartItems.Remove(ingredient);
    }

    public Image GetDisabledImage()
    {
        Image temp = null;
        for (int i = 0; i < IngredientIcon.Count; i++)
        {
            if (!IngredientIcon[i].gameObject.activeSelf)
            {
                temp = IngredientIcon[i];
                break;
            }
        }

        return temp;
    }
}
