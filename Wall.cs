using System.Diagnostics;
using SplashKitSDK;


public class Wall
{
    public double X { get; set; }
    public double UpperWallHeight { get; set; }
    public double LowerWallHeight { get; set; }
    public double WallWidth { get; set; }
    public double Dy { get; set; }
    public double Uy { get; set; }
    public Color MainColor { get; set; }
    private Vector2D Velocity { get; set; }
    const int SPEED = 1;
    const int GAP = 150;
    public Rectangle LowerWall;
    public Rectangle UpperWall;

    public Wall(Window gamewindow, Bird bird)
    {

        MainColor = Color.Brown;
        Random random = new Random();
        int randomGapGusser = random.Next(1, 6);

        switch(randomGapGusser)
        {
            case 1:
            UpperWallHeight = 100;
            break;

            case 2:
            UpperWallHeight = 200;
            break;

            case 3:
            UpperWallHeight = 300;
            break;

            case 4:
            UpperWallHeight = 400;
            break;

            case 5:
            UpperWallHeight = 500;
            break;
        }

        LowerWallHeight = gamewindow.Height- UpperWallHeight - GAP;
        X= gamewindow.Width;
        Uy = 0;
        Dy = gamewindow.Height - LowerWallHeight;
        WallWidth = 50;


        Point2D fromPt = new Point2D()
        {
            X = gamewindow.Width,
            Y = 0,
        };

        Point2D toPt = new Point2D()
        {
            X = -gamewindow.Width,
            Y = 0,
        };

        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));
        Velocity = SplashKit.VectorMultiply(dir, SPEED);
        UpperWall = new Rectangle()
        {
            X = X,
            Y = Uy,
            Width = WallWidth,
            Height = UpperWallHeight 
        };

        LowerWall = new Rectangle()
        {
            X = X,
            Y = Dy,
            Width = WallWidth,
            Height = LowerWallHeight 
        };

        
    }

    public void DrawWall(Window gamewindow)
    {
        gamewindow.FillRectangle(MainColor, X, Uy, WallWidth, UpperWallHeight);
        gamewindow.FillRectangle(MainColor, X, Dy, WallWidth, LowerWallHeight);
        
    }

    public void Update()
    {
        X += Velocity.X;
        UpperWall.X = X;
        LowerWall.X = X;
    }

    public Boolean IsOffScreen(Window gamewindow)
    {
        return false;
    }

    }