using System;
using System.IO.Compression;
using SplashKitSDK;
using System.IO;

public class FlappyBird
{
    private Bird _Bird;
    private Window _GameWindow;
    private List<Wall> _Walls;
    private List<Wall> _RemoveWalls;
    public bool Quit { get { return _Bird.quit; } }
    private Bitmap _BgBitmap;
    const int WALLSPACE = 300;
    private ScoreCard _PlayerScore;
    private HomePage _home;
    public string filePath;
    
    
    

    public FlappyBird(Window GameWindow, HomePage home, ScoreCard _ScoreCard)
    {
        _GameWindow = GameWindow;
        _home = home;
        _Walls = new List<Wall>();
        _RemoveWalls = new List<Wall>();
        _PlayerScore = _ScoreCard;
        _Bird = new Bird(_GameWindow, _home, _PlayerScore);
        _Walls.Add(new Wall(_GameWindow, _Bird));
        _BgBitmap = new Bitmap("Bg", "Bg.png");
        filePath = "highscore.txt";        
        
    }

    public void HandleInput()
    {
        _Bird.HandleInput();
        Draw();
        _Bird.StayOnWindow(_GameWindow);
    }

    public void Draw()
    {
        _GameWindow.Clear(Color.White);
        _GameWindow.DrawBitmap(_BgBitmap,0,0);
        _Bird.Draw(_GameWindow);
        
        Update();
        foreach (Wall w in _Walls)
        {
            w.DrawWall(_GameWindow);

        }
        _PlayerScore.Draw(_GameWindow);
        _GameWindow.Refresh(60);

    }

    public void Update()
    {
        
        if (_GameWindow.Width - _Walls.Last().X > WALLSPACE && _GameWindow.Width - _Walls.Last().X < WALLSPACE+5)
            {
                _Walls.Add(NewWall());

            }

        foreach (Wall w in _Walls)
        {
            w.Update();
            if (Convert.ToInt32(w.X) == Convert.ToInt32(_Bird.X))
            {
                _PlayerScore.Score += 1;
            }
        }

        CheckCollisions();

    }

    public Wall NewWall()
    {
        return new Wall(_GameWindow, _Bird);
    }

    public void CheckCollisions()
    {
        foreach (Wall w in _Walls)
        {
            if (_Bird.ColideWith(w))
            {
                _Bird.GameOver();
                
            }
            if (w.X < -10)
            {
                _RemoveWalls.Add(w);
            }
        }

        if (_RemoveWalls.Count > 0)
        {
            foreach (Wall r_w in _RemoveWalls)
            {
                _Walls.Remove(r_w); 
                Console.WriteLine("Wall removed!");
            }
            _RemoveWalls.Clear();
        }
    }

}