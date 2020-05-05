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

        private char[,] board = new char[3, 3] {                 //게임 보드
            { '□','□','□' } ,
            { '□','□','□' } ,
            { '□','□','□' }
        };
        public char[,] Board
        {
            get { return board; }
            set { board = value; }
        }
        public TicTacToeBoard(string player1, string player2)         //2P 일떄 생성자
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public TicTacToeBoard(string player1)               //1P 일떄 생성자
        {
            this.player1 = player1;
            player2 = null;
        }

        public void PrintBoard()              //tictactoe 보드 출력
        {
            string pringWhiteSpace = "                                                   ";

            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write(pringWhiteSpace);

                for (int colomn = 0; colomn < board.GetLength(1); colomn++)
                {
                    Console.Write("   {0}", board[row, colomn]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintExampleBoard()        //플레이어 입력 번호 안내 보드
        {
            string pringWhiteSpace = "                                                   ";

            Console.Write(pringWhiteSpace);
            Console.Write("   입력위치번호    \n\n");

            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write(pringWhiteSpace);

                for (int colomn = 0; colomn < board.GetLength(1); colomn++)
                {
                    Console.Write("    {0}", row * 3 + colomn + 1);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        public void ModifyBoard(int inputNumber, string activePlayer)        //입력에 따라 게임 보드를 수정하는 메소드
        {
            inputNumber = inputNumber - 1;            //배열인덱스는 0부터 시작하므로

            if (string.Compare(activePlayer, player1) == 0)
            {
                board[inputNumber / 3, inputNumber % 3] = '○';
            }
            else
            {
                board[inputNumber / 3, inputNumber % 3] = '×';
            }
        }

        public string CheckWinner(string player)  // 승자가 있는지 체크하는 메소드
        {
            for (int location = 0; location < board.GetLength(0); location++)
            {
                if (board[location, 0] != '□')
                {
                    if (board[location, 0] == board[location, 1] && board[location, 0] == board[location, 2]) { return player; }
                }

                if (board[0, location] != '□')
                {
                    if (board[0, location] == board[1, location] && board[0, location] == board[2, location]) { return player; }
                }            
            }
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) { return player; }

            if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]) { return player; }

            return null;
        }

        public int BoardLength() { return board.Length; }       //보드의 크기를 반환

        public bool IsSameLocation(int inputNumber)              //같은 위치에 두는지를 판별하는 메소드
        {
            inputNumber = inputNumber - 1;
            if (board[inputNumber / 3, inputNumber % 3] == '□') return false;
            else return true;
        }

    }
}
