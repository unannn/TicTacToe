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
    public struct Player
    {
        public string playerName;
        public int win;
        public int lose;        
    }

    class TicTacToe
    {
        private string player1;
        private string player2;
        private string winner;
        private int selectedItem;

        public TicTacToe()
        {
            player1 = null;
            player2 = null;
            winner = null;
            selectedItem = 0;
        }

        public void GameStart()
        {
            GameFlow gameFlow = new GameFlow();

            while(selectedItem != Item.endGame)
            {
                selectedItem = gameFlow.SelectMenuItem();

                switch (selectedItem)
                {
                    case Item.vsComputer:
                        gameFlow.SelectPlayer(ref player1);
                        gameFlow.PlayGame(player1);
                        break;

                    case Item.vsPlayer:
                        gameFlow.SelectPlayer(ref player1, ref player2);
                        winner = gameFlow.PlayGame(player1, player2);

                        if (winner != null) gameFlow.ShowWinner(winner);
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
