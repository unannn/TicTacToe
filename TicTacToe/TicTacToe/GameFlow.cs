using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TicTacToe
{
    class GameFlow : GameScenes
    {      
        public int SelectMenuItem()
        {
            string selectedItemInString;      
            int selectedItem = 0;
            bool rightInput = false;

            List<string> menuItem = new List<string>()   //메뉴 리스트 생성
            {
                "1. PLAYER VS COMPUTER",
                "2. PLAYER VS PLAYER",
                "3. ADD PLAYER",
                "4. RANKING",
                "5. END GAME"
            };

            Console.WriteLine("\n    TIC TAC TOE     \n");
            while (!rightInput)       //1~5의 정수 입력 시 까지 반복
            {
                foreach (string item in menuItem)
                {
                    Console.WriteLine(item + "\n");
                }

                Console.WriteLine("\n1~5사이의 정수를 입력하세요\n");

                Console.Write("메뉴 선택 : ");
                selectedItemInString = Console.ReadLine();

                if(selectedItemInString.Length == 1)     //문자열의 길이가 1인지 판별 (한자리수 정수를 입력받으려 하므로)
                {
                    if (string.Compare(selectedItemInString, "1") >= 0 && string.Compare(selectedItemInString, "5") <= 0)        //입력받은 문자열의 크기가 "1" 보다크고 "5"보다 작으면 입력
                    {
                        selectedItem = int.Parse(selectedItemInString);
                        rightInput = true;
                    }
                }
                
                Console.Clear();
            }

            return selectedItem;  //입력받은 정수 반환
        }

        public void SelectPlayer(ref string player1)  //player vs computer
        {
            //List<string> playerNameList = new List<string>();   //메뉴 리스트 생성
            StreamReader playerNameListFile = new StreamReader("./playerNameList.txt", Encoding.Default);
            ConsoleKeyInfo ckey;
            bool selectPlayer = false;
            int selectPlayerNumber = 0;
            string line;
            List<Player> players = new List<Player>();       //플레이어들의 이름과 전적 리스트
            Player temp;
            while ((line = playerNameListFile.ReadLine()) != null)
            {
                string[] playerInfo = line.Split(',');
                temp.playerName = playerInfo[0];
                temp.win = int.Parse(playerInfo[1]);
                temp.lose = int.Parse(playerInfo[2]);
                players.Add(temp);
            }
            //foreach (Player p in players)
            //{
            //    Console.WriteLine(p.playerName + " {0}승 {1}패", p.win, p.lose);
            //}

            //while ((line = playerNameListFile.ReadLine()) != null)
            //{
            //    playerNameList.Add(line);
            //}

            Console.CursorVisible = false;

            while (!selectPlayer)
            {
                for(int item = 0; item < players.Count; item++)
                {
                    if (item == selectPlayerNumber)
                    {
                        Console.Write("player1-> ");
                    }
                    else
                    {
                        Console.Write("          ");
                    }
                    Console.WriteLine(players[item].playerName);
                    Console.ResetColor();

                }
                ckey = Console.ReadKey();

                switch (ckey.Key)          //키 입력에 따라 메뉴바 이동, 선택
                {
                    case ConsoleKey.DownArrow:
                        if (selectPlayerNumber >= players.Count - 1) selectPlayerNumber = 0;   //마지막 인덱스 메뉴에서 위 방향키 입력 시 처음 인덱스 메뉴로 이동
                        else selectPlayerNumber++;
                        break;

                    case ConsoleKey.UpArrow:
                        if (selectPlayerNumber <= 0) selectPlayerNumber = players.Count - 1;   //처음 인덱스 메뉴에서 위 방향키 입력 시 마지막 인덱스 메뉴로 이동
                        else selectPlayerNumber--;
                        break;

                    case ConsoleKey.Spacebar:
                        selectPlayer = true;
                        player1 = players[selectPlayerNumber].playerName;
                         break;

                    default:
                        break;

                }

                Console.Clear();
            }

        }

        public void SelectPlayer(ref string player1, ref string player2)  //player vs player
        {
            //List<string> playerNameList = new List<string>();   //메뉴 리스트 생성
            StreamReader playerNameListFile = new StreamReader("./playerNameList.txt", Encoding.Default);
            ConsoleKeyInfo ckey;
            bool selectPlayer1 = false;
            bool selectPlayer2 = false;
            int selectedPlayer1Number = -1;
            int selectPlayerNumber = 0;
            string line;

            List<Player> players = new List<Player>();       //플레이어들의 이름과 전적 리스트
            Player temp;
            while ((line = playerNameListFile.ReadLine()) != null)
            {
                string[] playerInfo = line.Split(',');
                temp.playerName = playerInfo[0];
                temp.win = int.Parse(playerInfo[1]);
                temp.lose = int.Parse(playerInfo[2]);
                players.Add(temp);
            }

            //while ((line = playerNameListFile.ReadLine()) != null)
            //{
            //    playerNameList.Add(line);
            //}

            Console.CursorVisible = false;

            while (!selectPlayer1 || !selectPlayer2)
            {
                for (int item = 0; item < players.Count; item++)
                {
                    if (item == selectPlayerNumber)
                    {
                        if (!selectPlayer1) Console.Write("player1-> ");
                        else if (selectPlayerNumber != selectedPlayer1Number) Console.Write("player2-> ");
                    }                  
                    else if(item != selectedPlayer1Number)Console.Write("          ");
                    
                    if (selectPlayer1  && selectedPlayer1Number == item) Console.Write("player1-> ");


                    Console.WriteLine(players[item].playerName);
                    Console.ResetColor();

                }
                ckey = Console.ReadKey();

                switch (ckey.Key)          //키 입력에 따라 메뉴바 이동, 선택
                {
                    case ConsoleKey.DownArrow:

                        if (selectPlayerNumber >= players.Count - 1) selectPlayerNumber = 0;   //마지막 인덱스 메뉴에서 위 방향키 입력 시 처음 인덱스 메뉴로 이동
                        else if (selectPlayerNumber == selectedPlayer1Number - 1)
                        {                             
                            selectPlayerNumber += 2;

                            if (selectPlayerNumber >= players.Count) selectPlayerNumber -= players.Count;
                        }
                        else ++selectPlayerNumber;

                        break;

                    case ConsoleKey.UpArrow:

                        if (selectPlayerNumber <= 0) selectPlayerNumber = players.Count - 1;   //처음 인덱스 메뉴에서 위 방향키 입력 시 마지막 인덱스 메뉴로 이동
                        else if (selectPlayerNumber == selectedPlayer1Number + 1)
                        {
                            selectPlayerNumber -= 2;
                            if (selectPlayerNumber < 0) selectPlayerNumber += players.Count;

                        }
                        else --selectPlayerNumber;

                        break;

                    case ConsoleKey.Spacebar:

                        if (selectPlayer1 == false)
                        {
                            selectPlayer1 = true;
                            selectedPlayer1Number = selectPlayerNumber;
                            player1 = players[selectedPlayer1Number].playerName;
                            ++selectPlayerNumber;

                        }
                        else
                        {
                            selectPlayer2 = true;
                            player2 = players[selectPlayerNumber].playerName;
                        }


                        break;

                    default:
                        break;

                }

                Console.Clear();
            }

        }       
    }
}
