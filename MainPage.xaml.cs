using DodgeGame.Classes;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace DodgeGame
{
    public sealed partial class MainPage : Page
    {
        
        GameManager gameManager;

        MusicManager music = new MusicManager();

        public MainPage()
        {

            this.InitializeComponent();

            gameManager = new GameManager(MyCanvas, music, timerTextBlock, SaveGameBtn, LoadGameButton);

            gameManager.NewGame();

        }
        //


        private void PauseResumeButton_Click(object sender, RoutedEventArgs e)
        {

            if (gameManager.IsGameRunning)
            {

                music.PauseBgMusic();

                gameManager.IsGameRunning = false;
                gameManager.player._isAlive = false;
                PauseResumeButton.Content = "Resume";

                gameManager.gameTimer.Stop();
                gameManager.timer.Stop();

            }
            else
            {
                music.ResumePlayingBGMusic(); //Unpause the music

                gameManager.IsGameRunning = true;
                gameManager.player._isAlive = true;
                PauseResumeButton.Content = "Pause";

                gameManager.gameTimer.Start();
                gameManager.timer.Start();

            }
        }


        private void RestartGameButton_Click(object sender, RoutedEventArgs e)
        {
            gameManager.NewGame();

        }


        //
    }

}