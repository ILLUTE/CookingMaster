using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class FileWriter
{
    public static void SaveFile(Leaderboard leaderboard)
    {
        Leaderboard lb = leaderboard;
       
        string json = JsonConvert.SerializeObject(lb);

        string directoryPath = Path.Combine(Application.persistentDataPath, "File", "Leaderboard");
        string filePath = Path.Combine(directoryPath, "leaderboard.json");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        File.WriteAllText(filePath, json);
    }

    public static Leaderboard GetFile()
    {
        string directoryPath = Path.Combine(Application.persistentDataPath, "File", "Leaderboard");
        string filePath = Path.Combine(directoryPath, "leaderboard.json");

        if (!File.Exists(filePath)) return null;
        string json = File.ReadAllText(filePath);
        Leaderboard lb = JsonConvert.DeserializeObject<Leaderboard>(json);
        return lb;
    }
}

public class Leaderboard
{
    public List<int> leaderboard = new();

    public void AddScore(int score)
    {
        if (leaderboard.Count < 10)
        {
            leaderboard.Add(score);
        }
        else
        {
            leaderboard.Sort();
            if (score > leaderboard[0])
            {
                leaderboard.RemoveAt(0);
            }
            leaderboard.Add(score);
            leaderboard.Sort();
        }
    }
}
