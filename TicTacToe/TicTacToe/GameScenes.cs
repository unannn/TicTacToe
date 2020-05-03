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
        private char[,] board = new char[3,3] {
            { '□','□','□' } ,
            { '□','□','□' } ,
            { '□','□','□' }
        };
                
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

        public void PrintBoard()
        {            
            for(int row = 0;row < board.GetLength(0); row++)
            {
                for(int colomn = 0;colomn < board.GetLength(1); colomn++)
                {
                    Console.Write("{0}   ", board[row, colomn]);
                }
                Console.WriteLine();
            }
        }

        public void ModifyBoard(int inputNumber,string activePlayer)
        {
            inputNumber = inputNumber - 1;            //배열인덱스는 0부터 시작하므로

            if(string.Compare(activePlayer,player1) == 0)
            {
                board[inputNumber / 3,inputNumber % 3] = '○';
            }
            else
            {
                board[inputNumber / 3, inputNumber % 3] = '×';
            }
        }

        public string CheckWinner(string player)
        {           
            for(int location = 0;location < board.GetLength(0); location++)
            {
                if(board[location,0] != '□' && board[0,location] != '□')
                {
                    if (board[location, 0] == board[location, 1] && board[location, 0] == board[location, 2]) { return player; }
                    if (board[0, location] == board[1, location] && board[0, location] == board[2, location]) { return player; }
                }
            }
            if(board[0,0] == board[1,1] && board[0,0] == board[2, 2]) { return player; }

            if(board[0,2] == board[1,1] && board[0,2] == board[2, 0]) { return player; }

            return null;
        }

        public int BoardLength() { return board.Length; }

        public bool IsSameLocation(int inputNumber)              //같은 위치에 두는지를 판별하는 메소드
        {
            inputNumber = inputNumber - 1;
            if (board[inputNumber / 3, inputNumber % 3] == '□') return false;
            else return true;
        }

    }

    class GameScenes
    {
        
        public string PlayGame(string player1, string player2)
        {
            string winner = null;
            int gameTurnNumber = 0;
            int inputNumber = -1;
            string inputNumberInString;

            TicTacToeBoard tictactoeBoard = new TicTacToeBoard(player1, player2);

            while (gameTurnNumber < tictactoeBoard.BoardLength() )
            {
                tictactoeBoard.PrintBoard();      //보드 출력

                if (gameTurnNumber % 2 == 0) Console.Write("Your turn-> ");
                else Console.Write("            ");
                Console.WriteLine(player1);
                if (gameTurnNumber % 2 != 0) Console.Write("Your turn-> ");
                else Console.Write("            ");
                Console.WriteLine(player2);

                Console.Write("1~9 정수입력 : ");
                inputNumberInString = Console.ReadLine();

                if (inputNumberInString.Length == 1)
                {
                    if (string.Compare(inputNumberInString, "1") >= 0 && string.Compare(inputNumberInString, "9") <= 0)
                    {
                        inputNumber = int.Parse(inputNumberInString);
                        if (!tictactoeBoard.IsSameLocation(inputNumber))
                        {
                            if (gameTurnNumber % 2 == 0) tictactoeBoard.ModifyBoard(inputNumber, player1);
                            else tictactoeBoard.ModifyBoard(inputNumber, player2);
                        }
                        else
                        {
                            Console.Clear();
                            continue;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    continue;
                }

                if (gameTurnNumber >= 4)
                {
                    if(gameTurnNumber % 2 == 0) winner = tictactoeBoard.CheckWinner(player1);
                    else winner = tictactoeBoard.CheckWinner(player2);
                }
                Console.Clear();
                if (winner != null) break;
                ++gameTurnNumber;

            }


            return winner;
        }

        public void PlayGame(string player1)
        {

        }

        public void ShowPlayerRanking()
        {

        }

        public void ShowWinner(string winner)
        {
            ConsoleKeyInfo ckey;
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(winner + " WIN!!!!!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            ckey = Console.ReadKey();

            Console.Clear();
        }
        public void ShowDraw()
        {
            ConsoleKeyInfo ckey;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" DRAW!!!!!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            ckey = Console.ReadKey();

            Console.Clear();
        }


        public void AddPlayer()
        {

        }

        protected void EndGame()
        {

        }
    }
}
