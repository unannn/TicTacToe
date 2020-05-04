using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class Item
    {
        public const int vsComputer = 1;
        public const int vsPlayer = 2;
        public const int addPlayer = 3;
        public const int ranking = 4;
        public const int endGame= 5;

    }
    public class Player
    {
        public string playerName;
        public int win;
        public int lose;
        public int draw;

        public Player()
        {
            playerName = null;
            win = - 1;
            lose = -1;
            draw = -1;
        }
        public Player(string name, int win, int lose, int draw)
        {
            this.playerName = name;
            this.win = win;
            this.lose = lose;
            this.draw = draw;
        }
    }
    public class GameResult
    {
        public string winner;
        public string loser;
        public bool isDraw;

        public GameResult(string player1,string player2)
        {
            winner = player1;
            loser = player2;
            isDraw = true;
        }
    }

    class TicTacToe
    {
        private string player1;
        private string player2;
        private int selectedItem;
                
        public TicTacToe()
        {
            player1 = null;
            player2 = null;
            selectedItem = 0;
            
        }

        public void GameStart()
        {
            GameFlow gameFlow = new GameFlow();
            GameResult gameResult;

            while(selectedItem != Item.endGame)
            {
                selectedItem = gameFlow.SelectMenuItem();

                switch (selectedItem)
                {
                    case Item.vsComputer:
                        gameFlow.SelectPlayer(ref player1);
                        gameResult = gameFlow.PlayGame(player1);

                        if (gameResult.winner != null) gameFlow.ShowWinner(gameResult.winner);
                        else gameFlow.ShowDraw();

                        break;

                    case Item.vsPlayer:
                        gameFlow.SelectPlayer(ref player1, ref player2);
                        gameResult = gameFlow.PlayGame(player1, player2);

                        if (gameResult.winner != null) gameFlow.ShowWinner(gameResult.winner);
                        else gameFlow.ShowDraw();
                        
                        break;

                    case Item.addPlayer:
                        gameFlow.AddPlayer();
                        break;

                    case Item.ranking:
                        gameFlow.ShowPlayerRanking();
                        break;

                    case Item.endGame:
                        break;

                    default:
                        break;
                }
            }


            //gameFlow.PlayGame(player1, player2, selectedItem);

        }
    }
}
