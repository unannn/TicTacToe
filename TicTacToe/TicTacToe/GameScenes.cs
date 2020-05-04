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
        public bool InputLocationNumber(string player1, string player2,ref TicTacToeBoard tictactoeBoard,int gameTurnNumber)
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
                }
            }
            Console.Clear();
            return false;
        }

        public void ShowWinner(string winner)
        {
            ConsoleKeyInfo ckey;
            
            Console.WriteLine("\n\n");
            Console.WriteLine(winner + " WIN!!!!!");
            Console.WriteLine("\n\n");

            ckey = Console.ReadKey();

            Console.Clear();
        }
        public void UpdateRecord(GameResult gameResult)
        {

            StreamReader playerListFileToRead = new StreamReader(new FileStream("./playerNameList.txt",FileMode.Open));
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


            StreamWriter playerListFileToWrite = new StreamWriter(new FileStream("./playerNameList.txt", FileMode.Create),Encoding.UTF8);

            foreach(Player player in players)
            {
                playerListFileToWrite.WriteLine("{0},{1},{2},{3}", player.playerName, player.win, player.lose,player.draw);
            }

            playerListFileToWrite.Close();
        }
        public void ShowActivePlayer(string player1, string player2, int gameTurnNumber)
        {
            if (gameTurnNumber % 2 == 0) Console.Write("Your turn-> ");
            else Console.Write("            ");

            Console.WriteLine(player1 + "○");

            if (gameTurnNumber % 2 != 0) Console.Write("Your turn-> ");
            else Console.Write("            ");

            Console.WriteLine(player2 + "×\n");
        }

        public void ShowDraw()
        {
            ConsoleKeyInfo ckey;

            Console.WriteLine("\n\n");
            Console.WriteLine(" DRAW!!!!!");
            Console.WriteLine("\n\n");

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
