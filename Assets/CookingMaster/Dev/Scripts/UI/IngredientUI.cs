using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientUI : MonoBehaviour
{
    public Image m_ImageIco;

    public void SetImage(Sprite sprite)
    {
        m_ImageIco.sprite = sprite;
    }
}
