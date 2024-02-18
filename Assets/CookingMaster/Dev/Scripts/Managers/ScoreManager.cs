using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Dictionary<int, int> Scores = new();

    public event Action<PlayerController, int> OnUpdateScore;
    public event Action<MatchOutcome> OnOutcome;
    private void Awake()
    {
        Locator.Instance.GameManagerInstance.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        Leaderboard lb = FileWriter.GetFile();
        lb ??= new();
        lb.AddScore(Scores[0]);
        lb.AddScore(Scores[1]);

        MatchOutcome matchOutcome;
        if (Scores[0] == Scores[1])
        {
            matchOutcome = MatchOutcome.Tied;
        }
        else if (Scores[0] > Scores[1])
        {
            matchOutcome = MatchOutcome.Player1;
        }
        else
        {
            matchOutcome = MatchOutcome.Player2;
        }
        FileWriter.SaveFile(lb);
        OnOutcome?.Invoke(matchOutcome);
    }

    public void ConnectPlayer(PlayerController player)
    {
        if (Scores.ContainsKey(player.Id)) return;
        Scores.Add(player.Id, 0);
    }

    public void UpdateScore(PlayerController player, int toUpdate)
    {
        if (!Scores.ContainsKey(player.Id)) return;
        Scores[player.Id] += toUpdate;
        OnUpdateScore?.Invoke(player, Scores[player.Id]);
    }
}

public enum MatchOutcome
{
    Tied,
    Player1,
    Player2
}
