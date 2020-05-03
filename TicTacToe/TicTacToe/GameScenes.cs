using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeBoard
    {   
        private string player1;
        private string player2;

        public TicTacToeBoard(string player1, string player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public TicTacToeBoard(string player1)
        {
            this.player1 = player1;
            player2 = null;
        }

        private char[] board = new char[9] {
            '□','□','□' ,
            '□','□','□' ,
            '□','□','□' 
        };

        public void PrintBoard()
        {            
            for(int row = 0;row < board.Length; row++)
            {
                Console.Write("{0}  ", board[row]);

                if (row % 3 == 2) Console.WriteLine();
            }
        }

        public void ModifyBoard(int inputNumber,string activePlayer)
        {
            if(string.Compare(activePlayer,player1) == 0)
            {
                board[inputNumber] = '○';
            }
            else
            {
                board[inputNumber] = '×';
            }

        }
    }

    class GameScenes
    {
        
        public string PlayGame(string player1, string player2)
        {
            string winner = null;
            int inputNumber = -1;
            int gameTurnNumber = 0;

            TicTacToeBoard tictactoeBoard = new TicTacToeBoard(player1, player2);

            while (gameTurnNumber < 9)
            {
                tictactoeBoard.PrintBoard();

                Console.Write(player1, "1~9 정수입력 : ");
                inputNumber = int.Parse(Console.ReadLine());
                if (gameTurnNumber % 2 == 0) tictactoeBoard.ModifyBoard(inputNumber, player1);
                else tictactoeBoard.ModifyBoard(inputNumber, player2);
                ++gameTurnNumber;

                Console.Clear();
            }

            tictactoeBoard.PrintBoard();
            //2인 틱택토
            Console.WriteLine(player1+player2);

            return winner;
        }

        public void PlayGame(string player1)
        {

        }

        public void ShowPlayerRanking()
        {

        }

        public void AddPlayer()
        {

        }

        protected void EndGame()
        {

        }
    }
}
