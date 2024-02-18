using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private RectTransform anchoredBox;
    [SerializeField] private TextMeshProUGUI m_OutcomeTxt;
    private void Awake()
    {
        Locator.Instance.ScoreManagerInstance.OnOutcome += OnOutCome;
    }

    private void OnOutCome(MatchOutcome outcome)
    {
        anchoredBox.DOAnchorPosY(0, 0.5f);
        m_OutcomeTxt.text = outcome == MatchOutcome.Tied ? "Tied" : outcome == MatchOutcome.Player1 ? "Player 1 Wins" : "Player 2 Wins";
    }
}
