using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI playerScoreTxt;
    [SerializeField] private ChoppedUI choppedUI;
    [SerializeField] private CartUI cartUI;

    private void Awake()
    {
        Locator.Instance.ScoreManagerInstance.OnUpdateScore += OnScoreUpdated;
        playerController.OnChoppedPicked += OnChoppedIngredientPicked;
        playerController.OnChoppedFlush += OnChoppedFlush;
        playerController.OnIngredientDropped += OnIngredientDropped;
        playerController.OnIngredientPicked += OnIngredientPicked;
    }

    private void OnIngredientPicked(Ingredients ingredients)
    {
        cartUI.Add(ingredients);
    }

    private void OnIngredientDropped(Ingredients ingredients)
    {
        cartUI.Remove(ingredients);
    }

    private void OnChoppedFlush()
    {
        choppedUI.Flush();
    }

    private void OnChoppedIngredientPicked(Ingredients ingredient)
    {
        choppedUI.Add(ingredient);
    }

    private void OnScoreUpdated(PlayerController controller, int score)
    {
       if(playerController.Id == controller.Id)
        {
            playerScoreTxt.text = $"{score}";
        }
    }
}
