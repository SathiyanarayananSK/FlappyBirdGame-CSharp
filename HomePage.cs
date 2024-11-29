using System;
using System.IO.Compression;
using SplashKitSDK;

public class HomePage{

    private Bitmap _BgBitmap;
    private Bitmap _BirdBitmap;
    private Window _GameWindow;
    public bool playGame;
    public bool QuitGame;
    public ScoreCard _PlayerScore;
    public int _highscore;
    public int _CurrentScore;

    public HomePage(Window GameWindow, ScoreCard _ScoreCard)
    {
        _BgBitmap = new Bitmap("Bg", "Bg.png");
        _BirdBitmap = new Bitmap("Bird", "Bird.png");
        _GameWindow = GameWindow;
        _PlayerScore = _ScoreCard;
        _highscore = _PlayerScore.GetHighScore();
        _CurrentScore = _PlayerScore.SendScore();
        _PlayerScore.Score = 0;
        playGame = false;
        QuitGame = false;
    }

    public void HandleInput()
    {
        SplashKit.ProcessEvents();
        if (SplashKit.KeyTyped(KeyCode.ReturnKey))
        {
            playGame = true;
        }
        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            QuitGame = true;
        }
        Draw();
    }
    public void Draw()
    {
        _GameWindow.Clear(Color.White);
        _GameWindow.DrawBitmap(_BgBitmap,0,0);
        _GameWindow.FillRectangle(Color.Green, 30, 20, 200, 50);
        _GameWindow.DrawText($"Your Score: {_CurrentScore}",Color.Black, 70, 40);
        _GameWindow.FillRectangle(Color.Green, 980, 20, 200, 50);
        _GameWindow.DrawText($"High Score: {_highscore}",Color.Black, 1020, 40);
        _GameWindow.DrawText($"Flappy Bird",Color.Black, 558, 155);
        _GameWindow.FillCircle(Color.Green, 600, 250, 65);
        _GameWindow.DrawBitmap(_BirdBitmap,570,220);
        _GameWindow.FillRectangle(Color.Green, 460, 350, 300, 50);
        _GameWindow.DrawText($"Start",Color.Black, 580, 370);
        _GameWindow.DrawText($"(Press Enter key to start the game!)",Color.Black, 470, 410);
        _GameWindow.FillRectangle(Color.Green, 460, 450, 300, 50);
        _GameWindow.DrawText($"Quit",Color.Black, 590, 470);
        _GameWindow.DrawText($"(Press Escape key to Quit the game!)",Color.Black, 470, 520);
        _GameWindow.DrawText($"(Note: After starting the game, Pressing the Space key will make the bird fly!)",Color.Black, 290, 650);
        _GameWindow.Refresh(60);
    }
}