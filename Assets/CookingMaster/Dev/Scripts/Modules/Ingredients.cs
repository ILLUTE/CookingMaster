using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Ingredients")]
public class Ingredients : ScriptableObject
{
    public string IngredientName;
    public float ChoppingTime;
    public Sprite IngredientIcon;
}
