using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientPicker : MonoBehaviour
{
    public Ingredients ingredientAvailable;
    [SerializeField] private Image m_IngredientIco;
    private void OnEnable()
    {
        m_IngredientIco.sprite = ingredientAvailable.IngredientIcon;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
