using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameScenes
    {   
        
        public string PlayGame(string player1, string player2)
        {
            string winner = null;
            int gameTurnNumber = 0;
            bool inputSucess = false;

            TicTacToeBoard tictactoeBoard = new TicTacToeBoard(player1, player2);

            while (gameTurnNumber < tictactoeBoard.BoardLength())
            {

                tictactoeBoard.PrintBoard();      //보드 출력

                ShowActivePlayer(player1, player2, gameTurnNumber);    //누구의 턴인지 보여주는 그래픽 출력

                tictactoeBoard.PrintExampleBoard();       //입력위치번호 예시 출력


                inputSucess = InputLocationNumber(player1,  player2, ref tictactoeBoard,  gameTurnNumber);

                if (!inputSucess) continue;
                

                if (gameTurnNumber >= 4)
                {
                    if (gameTurnNumber % 2 == 0) winner = tictactoeBoard.CheckWinner(player1);
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

        private bool InputLocationNumber(string player1, string player2,ref TicTacToeBoard tictactoeBoard,int gameTurnNumber)
        {
            string inputNumberInString = null;
            int inputNumber;            

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

                        return true;
                    }
                    else
                    {                        
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.Clear();
            }
            return false;
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

        private void ShowActivePlayer(string player1, string player2, int gameTurnNumber)
        {
            if (gameTurnNumber % 2 == 0) Console.Write("Your turn-> ");
            else Console.Write("            ");

            Console.WriteLine(player1);

            if (gameTurnNumber % 2 != 0) Console.Write("Your turn-> ");
            else Console.Write("            ");

            Console.WriteLine(player2 + "\n");
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
