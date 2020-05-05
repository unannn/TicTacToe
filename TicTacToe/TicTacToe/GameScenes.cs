using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TicTacToe
{
    class GameScenes
    {
        public bool InputLocationNumber(string player1, string player2,ref TicTacToeBoard tictactoeBoard,int gameTurnNumber)   //2P 일때 플레이어에게 틱택토 보드에 둘 수를 입력받음
        {
            string inputNumberInString = null;
            int inputNumber;      
            string pringWhiteSpace = "                                                   ";

            Console.Write(pringWhiteSpace);
            Console.Write("1~9 정수입력 : ");
            inputNumberInString = Console.ReadLine();

            if (inputNumberInString.Length == 1)             //예외처리
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
                }
            }
            Console.Clear();
            return false;
        }
        public bool InputLocationNumber(string player, ref TicTacToeBoard tictactoeBoard) //1P 일때 플레이어에게 틱택토 보드에 둘 수를 입력받음
        {
            string inputNumberInString = null;
            int inputNumber;
            string pringWhiteSpace = "                                                   ";

            Console.Write(pringWhiteSpace);
            Console.Write("1~9 정수입력 : ");
            inputNumberInString = Console.ReadLine();

            if (inputNumberInString.Length == 1)
            {
                if (string.Compare(inputNumberInString, "1") >= 0 && string.Compare(inputNumberInString, "9") <= 0)
                {
                    inputNumber = int.Parse(inputNumberInString);
                    if (!tictactoeBoard.IsSameLocation(inputNumber))
                    {
                        tictactoeBoard.ModifyBoard(inputNumber, player);

                        return true;
                    }
                }
            }
            Console.Clear();
            return false;
        }

        public bool InputByComputer(ref TicTacToeBoard tictactoeBoard)  //1P 일때 컴퓨터에게 입력받음
        {
            char[,] board = new char[3, 3];
            board = tictactoeBoard.Board;
            
            for (int location = 0; location < board.GetLength(0); location++)  
            {
                if (board[location, 0] != '□')
                {
                    if (board[location, 0] == board[location, 1] && board[location, 0] != board[location, 2] && board[location, 2] == '□') {                        
                        tictactoeBoard.ModifyBoard(location* 3 + 3, "Computer");
                        return true;
                    }
                    else if (board[location, 0] != board[location, 1] && board[location, 0] == board[location, 2] && board[location, 1] == '□') {
                        tictactoeBoard.ModifyBoard(location * 3 + 2, "Computer");
                        return true;
                    }
                }
                else if(board[location, 1] != '□')
                {
                    if (board[location, 0] != board[location, 1] && board[location, 1] == board[location, 2] && board[location, 0] == '□') {
                        tictactoeBoard.ModifyBoard(location * 3 + 1, "Computer");
                        return true;
                    }
                }

                if (board[0, location] != '□')
                {
                    if (board[0, location] == board[1, location] && board[0, location] != board[2, location] && board[2, location] == '□') {
                        tictactoeBoard.ModifyBoard( 7 + location, "Computer");
                        return true;

                    }
                    else if (board[0,location] != board[1,location] && board[0, location] == board[2, location] && board[1, location] == '□') {
                        tictactoeBoard.ModifyBoard( 4 + location, "Computer");
                        return true;
                    }

                }
                else if(board[1, location] != '□')
                {
                    if (board[0, location] != board[1, location] && board[1, location] == board[2, location] && board[0, location] == '□') {
                        tictactoeBoard.ModifyBoard(1 + location, "Computer");
                        return true;
                    }
                }
            }

            if (board[1, 1] == '□')
            {
                tictactoeBoard.ModifyBoard(5, "Computer");
            }
            else if(board[0, 0] == '□') { tictactoeBoard.ModifyBoard(1, "Computer"); }
            else if (board[0, 2] == '□') { tictactoeBoard.ModifyBoard(3, "Computer"); }
            else if (board[2, 0] == '□') { tictactoeBoard.ModifyBoard(7, "Computer"); }
            else if (board[2, 2] == '□') { tictactoeBoard.ModifyBoard(9, "Computer"); }
            else if (board[0, 1] == '□') { tictactoeBoard.ModifyBoard(2, "Computer"); }
            else if (board[1, 2] == '□') { tictactoeBoard.ModifyBoard(6, "Computer"); }
            else if (board[2, 1] == '□') { tictactoeBoard.ModifyBoard(8, "Computer"); }
            else if (board[1, 0] == '□') { tictactoeBoard.ModifyBoard(4, "Computer"); }
                        
            return true;
        }
                
        public void UpdateRecord(GameResult gameResult)   //플레이어의 전적 업데이트
        {

            StreamReader playerListFileToRead = new StreamReader(new FileStream("./playerNameList.txt",FileMode.Open), Encoding.UTF8);
            List<Player> players = new List<Player>();       //플레이어들의 이름과 전적 리스트
            string[] playerRecord;
            Player temp = new Player();
            string line;

            while ((line = playerListFileToRead.ReadLine()) != null)
            {
                playerRecord = line.Split(',');
                temp.playerName = playerRecord[0];
                temp.win = int.Parse(playerRecord[1]);
                temp.lose = int.Parse(playerRecord[2]);
                temp.draw = int.Parse(playerRecord[3]);
                players.Add(new Player(temp.playerName, temp.win, temp.lose, temp.draw));
            }

            playerListFileToRead.Close();

            if(gameResult.isDraw == false)
            {
                foreach(Player player in players)
                {
                    if (player.playerName == gameResult.winner) player.win += 1;
                    else if (player.playerName == gameResult.loser) player.lose += 1;                    
                }
            }
            else
            {
                foreach (Player player in players)
                {
                    if (player.playerName == gameResult.winner) player.draw +=1;
                    else if (player.playerName == gameResult.loser) player.draw += 1;
                }
            }

            //플레이어 전적 수정 후 파일에 다시 씀
            StreamWriter playerListFileToWrite = new StreamWriter(new FileStream("./playerNameList.txt", FileMode.Create),Encoding.UTF8);

            foreach(Player player in players)
            {
                playerListFileToWrite.WriteLine("{0},{1},{2},{3}", player.playerName, player.win, player.lose,player.draw);
            }

            playerListFileToWrite.Close();
        }

        public void ShowActivePlayer(string player1, string player2, int gameTurnNumber) //현재 턴인 플레이어를 보여줌
        {
            string pringWhiteSpace = "                                                   ";
            Console.Write(pringWhiteSpace);
            if (gameTurnNumber % 2 == 0) Console.Write("Your turn-> ");
            else Console.Write("            ");

            Console.WriteLine("○ " + player1);

            Console.Write(pringWhiteSpace);

            if (gameTurnNumber % 2 != 0) Console.Write("Your turn-> ");
            else Console.Write("            ");

            Console.WriteLine("× " + player2 + "\n");
        }

        public void ShowWinner(string winner)         //승자 출력
        {
            string pringWhiteSpace = "                                                   ";

            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n");
            Console.Write(pringWhiteSpace);
            Console.WriteLine(winner + " WIN!!!!!");
            Console.WriteLine("\n\n");

            Console.Write(pringWhiteSpace);
            Console.WriteLine("Press Any Key...");
            Console.ReadKey();

            Console.Clear();
        }

        public void ShowDraw()                //비겼을 때 출력
        {
            string pringWhiteSpace = "                                                   ";

            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n");
            Console.Write(pringWhiteSpace);
            Console.WriteLine(" DRAW!!!!!");
            Console.WriteLine("\n\n");

            Console.Write(pringWhiteSpace);
            Console.WriteLine("Press Any Key...");

            Console.ReadKey();

            Console.Clear();
        }        
    }
}
