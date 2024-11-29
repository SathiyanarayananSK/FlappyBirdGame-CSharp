using System;
using System.IO.Compression;
using SplashKitSDK;

public class Bird{
    private Bitmap _BirdBitmap;
    public double X { get; set; }
    private double Y { get; set; }
    public bool quit { get; set; }
    private int Width { get { return _BirdBitmap.Width; } }
    private int Height { get { return _BirdBitmap.Height; } }
    const int GAP = 10;
    const int OFFSET = 100;
    private HomePage _home;
    public string filePath;
    private ScoreCard _score; 
    

    public Bird(Window GameWindow, HomePage home, ScoreCard score)
    {
        _BirdBitmap = new Bitmap("Bird", "Bird.png");
        X = ((GameWindow.Width - Width) / (double)2)-OFFSET;
        Y = (GameWindow.Height - Height) / (double)2;
        GameWindow.DrawBitmap(_BirdBitmap, X, Y);
        quit = false;
        _home = home;
        _score = score;
        filePath = "highscore.txt";

    }

    public void Draw(Window GameWindow)
    {
        GameWindow.DrawBitmap(_BirdBitmap, X, Y);  
    }

    public void StayOnWindow(Window limit)
    {
       
        if (Y < GAP)
        {
            Y = GAP;
        }
        else if (Y > (limit.Height -_BirdBitmap.Height - GAP))
        {
            GameOver();
        }


    }

    public void HandleInput()
    {
        SplashKit.ProcessEvents();
        if (SplashKit.KeyDown(KeyCode.SpaceKey))
        {
            Move(0,-5);
        }
        else
        {
            Move(0,5);
        }
        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            GameOver();
        }
        
    }

    public void Move(int x_dis, int y_dis)
    {
        X += x_dis;
        Y += y_dis;
    }

    public bool ColideWith(Wall w)
    {
        if (_BirdBitmap.RectangleCollision(X,Y, w.UpperWall) || _BirdBitmap.RectangleCollision(X,Y, w.LowerWall))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void GameOver()
    {
        _home.playGame = false;
                string content = $"{_score.SendScore()}";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(content); 
                }
                Console.WriteLine("Score added to the text file");
    }

}