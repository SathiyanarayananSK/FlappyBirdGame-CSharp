using System;
using System.IO.Compression;
using SplashKitSDK;
using System.Linq;
using System.Collections.Generic;

public class ScoreCard{
    private double X { get; set; }
    private double Y { get; set; }
    public int Score { get; set; }
    public string filePath;

    public ScoreCard(Window GameWindow)
    {
        X = GameWindow.Width - 100;
        Y = 30;
        Score = 0;
        filePath = "highscore.txt";
    }

    public void Draw(Window GameWindow)
    {
        GameWindow.DrawText($"Score: {Score.ToString()}",Color.Black, X, Y);
    }

    public int SendScore()
    {
        return Score;
    }

    public int GetHighScore()
    {
        
        List<int> scores = new List<int>();

        if (File.Exists(filePath))
        {
            List<string> linesList = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    linesList.Add(line);
                }
            }

            foreach (string fileLine in linesList)
            {
                scores.Add(int.Parse(fileLine));
            }

            int maxScore = scores.Max();
            return maxScore;
        }
        else
        {
            Console.WriteLine("File not found.");
            return 0;
        }
    }

}

