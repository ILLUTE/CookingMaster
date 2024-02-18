using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoppedUI : MonoBehaviour
{
    public List<Image> choppedUI;
    private Dictionary<Ingredients, Image> choppingIcon = new();

    public void Add(Ingredients ingredient)
    {
        if (choppingIcon.ContainsKey(ingredient)) return;
        Image image = GetDisabledImage();
        image.gameObject.SetActive(true);
        image.sprite = ingredient.IngredientIcon;
        choppingIcon.Add(ingredient, image);
    }

    public void Flush()
    {
        choppingIcon.Clear();
        foreach(Image i in choppedUI)
        {
            i.gameObject.SetActive(false);
        }
    }

    public Image GetDisabledImage()
    {
        Image temp = null;
        for (int i = 0; i < choppedUI.Count; i++)
        {
            if (!choppedUI[i].gameObject.activeSelf)
            {
                temp = choppedUI[i];
                break;
            }
        }

        return temp;
    }
}
