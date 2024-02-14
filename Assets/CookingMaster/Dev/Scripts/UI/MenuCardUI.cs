using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_HeaderTxt;
    [SerializeField] private List<Image> m_IngredientIcons = new();

    public void Set(Dish dish)
    {
        m_HeaderTxt.text = dish.DishName;
        for (int i = 0; i < m_IngredientIcons.Count; i++)
        {
            if (i < dish.m_Ingredients.Count)
            {
                m_IngredientIcons[i].sprite = dish.m_Ingredients[i].IngredientIcon;
                m_IngredientIcons[i].gameObject.SetActive(true);
            }
            else
            {
                m_IngredientIcons[i].gameObject.SetActive(false);
            }
        }
    }

    public void ResetUI()
    {
        m_HeaderTxt.text = string.Empty;
        SetIcons(false);
    }

    private void SetIcons(bool enable)
    {
        foreach(Image i in m_IngredientIcons)
        {
            i.gameObject.SetActive(enable);
        }
    }
}
