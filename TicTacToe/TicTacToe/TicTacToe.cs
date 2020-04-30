using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class GameTypes
    {
        public const int vsComputer = 1;
        public const int vsPlayer = 2;
        public const int endGame = 5;
    }
    class TicTacToe
    {
        private string player1;
        private string player2;
        private int gameType;

        public TicTacToe()
        {
            player1 = null;
            player2 = null;
            gameType = 0;
        }

        public void GameStart()
        {
            GameFlow gameFlow = new GameFlow();

            gameType = gameFlow.SelectMenuItem();
            

            gameFlow.SelectPlayer(ref player1,ref player2, gameType);
            gameFlow.PlayGame(player1, player2, gameType);

        }
    }
}
