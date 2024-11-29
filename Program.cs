using System;
using SplashKitSDK;



namespace FlappyBirdGame
{
    public class Program
    {
        public static void Main()
        {
            
            Window canvas = new Window("Flappy Bird", 1200, 700);
            ScoreCard GameScore = new ScoreCard(canvas);
            FlappyBird game;
            HomePage home;
            
            

            do
            {
                home = new HomePage(canvas, GameScore);
                game = new FlappyBird(canvas, home, GameScore);
                do
                {
                    home.HandleInput();
                
                }while(!home.playGame && !home.QuitGame);

                if(home.QuitGame)
                {
                    break;
                }
                else if(home.playGame)
                {
                    do
                    {
                        game.HandleInput();
                    }while(!canvas.CloseRequested && home.playGame );
                }

            }while(!home.QuitGame && !canvas.CloseRequested);

            
            
        }
    }
}
