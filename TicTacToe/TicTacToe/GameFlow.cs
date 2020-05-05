using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace TicTacToe
{
    class GameFlow : GameScenes
    {      
        public int SelectMenuItem()            //게임 메뉴를 출력하고 사용자의 입력을 받아 반환
        {
            string selectedItemInString;      
            int selectedItem = 0;
            bool rightInput = false;
            string pringWhiteSpace = "                                                ";

            List<string> menuItem = new List<string>()   //메뉴 리스트 생성
            {
                "1. PLAYER VS COMPUTER",
                "2. PLAYER VS PLAYER",
                "3. RANKING",
                "4. END GAME"
            };

            while (!rightInput)       //1~5의 정수 입력 시 까지 반복
            {
                Console.WriteLine("\n\n\n\n");
                Console.Write(pringWhiteSpace);
                Console.WriteLine("      TIC TAC TOE       \n\n");
                
                foreach (string item in menuItem)
                {
                    Console.Write(pringWhiteSpace);
                    Console.WriteLine(item + "\n");
                }

                Console.WriteLine();
                Console.Write(pringWhiteSpace);
                Console.WriteLine("1~5사이의 정수를 입력하세요\n");            
                Console.Write(pringWhiteSpace);
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

        public void SelectPlayer(ref string player1)  //player vs computer 일때 플레이어 선택
        {
            List<string> players = new List<string>();   //메뉴 리스트 생성
            StreamReader playerNameListFile = new StreamReader(new FileStream("./playerNameList.txt", FileMode.Open), Encoding.UTF8); //파일로 부터 플레이어 리스트 오픈
            ConsoleKeyInfo ckey;
            string pringWhiteSpace = "                                                ";

            bool selectPlayer = false;
            int selectPlayerNumber = 0;
            string line;

            string[] playerRecord;

            while ((line = playerNameListFile.ReadLine()) != null)       //한줄식 입력받아 이름 players 리스트에 저장
            {
                playerRecord = line.Split(',');
                players.Add(playerRecord[0]);
            }

            playerNameListFile.Close();

            Console.CursorVisible = false;

            while (!selectPlayer)
            {
                Console.WriteLine("\n\n\n\n");
                Console.Write(pringWhiteSpace);
                Console.WriteLine("      TIC TAC TOE       \n\n");

                for (int item = 0; item < players.Count; item++)
                {
                    Console.Write(pringWhiteSpace);
                    if (item == selectPlayerNumber)
                    {
                        Console.Write("player1-> ");
                    }
                    else
                    {
                        Console.Write("          ");
                    }
                    Console.WriteLine(players[item]);

                    Console.WriteLine();
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
                        player1 = players[selectPlayerNumber];
                         break;

                    default:
                        break;

                }

                Console.Clear();
            }

        }

        public void SelectPlayer(ref string player1, ref string player2)  //player vs player 일 때 플레이어 선택
        {
            List<string> playerNameList = new List<string>();   //플레이어 메뉴 리스트 생성
            StreamReader playerListFile = new StreamReader(new FileStream("./playerNameList.txt", FileMode.Open), Encoding.UTF8);
            ConsoleKeyInfo ckey;
            bool selectPlayer1 = false;
            bool selectPlayer2 = false;
            int selectedPlayer1Number = -1;
            int selectPlayerNumber = 0;
            string pringWhiteSpace = "                                                ";

            string line;
            string[] playerRecord;

            while ((line = playerListFile.ReadLine()) != null)          
            {
                playerRecord = line.Split(',');
                
                playerNameList.Add(playerRecord[0]);
            }
            playerListFile.Close();

            Console.CursorVisible = false;

            while (!selectPlayer1 || !selectPlayer2)                //player1 과 player2 둘다 선택완료되지 않앗으면
            {
                Console.WriteLine("\n\n\n\n");
                Console.Write(pringWhiteSpace);
                Console.WriteLine("      TIC TAC TOE       \n\n");

                for (int item = 0; item < playerNameList.Count; item++)
                {
                    Console.Write(pringWhiteSpace);

                    if (item == selectPlayerNumber)
                    {
                        if (!selectPlayer1) Console.Write("player1-> ");                          
                        else if (selectPlayerNumber != selectedPlayer1Number) Console.Write("player2-> "); 
                    }                  
                    else if(item != selectedPlayer1Number)Console.Write("          ");
                    
                    if (selectPlayer1  && selectedPlayer1Number == item) Console.Write("player1-> ");
                    
                    Console.WriteLine(playerNameList[item]);
                    Console.WriteLine();
                }
                ckey = Console.ReadKey();

                switch (ckey.Key)          //키 입력에 따라 메뉴바 이동, 선택
                {
                    case ConsoleKey.DownArrow:

                        if (selectPlayerNumber >= playerNameList.Count - 1) selectPlayerNumber = 0;   //마지막 인덱스 메뉴에서 위 방향키 입력 시 처음 인덱스 메뉴로 이동
                        else if (selectPlayerNumber == selectedPlayer1Number - 1)  //다음 플레이어가 선택된 경우
                        {                             
                            selectPlayerNumber += 2;

                            if (selectPlayerNumber >= playerNameList.Count) selectPlayerNumber -= playerNameList.Count;
                        }
                        else ++selectPlayerNumber;

                        break;

                    case ConsoleKey.UpArrow:

                        if (selectPlayerNumber <= 0) selectPlayerNumber = playerNameList.Count - 1;   //처음 인덱스 메뉴에서 위 방향키 입력 시 마지막 인덱스 메뉴로 이동
                        else if (selectPlayerNumber == selectedPlayer1Number + 1)
                        {
                            selectPlayerNumber -= 2;
                            if (selectPlayerNumber < 0) selectPlayerNumber += playerNameList.Count;

                        }
                        else --selectPlayerNumber;

                        break;

                    case ConsoleKey.Spacebar:

                        if (selectPlayer1 == false)
                        {
                            selectPlayer1 = true;
                            selectedPlayer1Number = selectPlayerNumber;
                            player1 = playerNameList[selectedPlayer1Number];
                            ++selectPlayerNumber;

                        }
                        else
                        {
                            selectPlayer2 = true;
                            player2 = playerNameList[selectPlayerNumber];
                        }

                        break;

                    default:
                        break;

                }

                Console.Clear();
            }
        }
        public GameResult PlayGame(string player1)      //1P일때 게임
        {
            int gameTurnNumber = 0;
            bool inputSucess = false;
            string winner = null;
            string computer = "Computer";
            GameResult gameResult = new GameResult(player1, computer);
            string pringWhiteSpace = "                                                ";
            
            TicTacToeBoard tictactoeBoard = new TicTacToeBoard(player1);                     //1P 게임 보드 인스턴스 생성

            while (gameTurnNumber < tictactoeBoard.BoardLength())
            {
                Console.WriteLine("\n\n\n\n");
                Console.Write(pringWhiteSpace);
                Console.WriteLine("      TIC TAC TOE       \n");

                tictactoeBoard.PrintBoard();           

                ShowActivePlayer(player1, "Computer", gameTurnNumber);    //누구의 턴인지 보여주는 그래픽 출력

                tictactoeBoard.PrintExampleBoard();       //입력위치번호 예시 출력

                if (gameTurnNumber % 2 == 0)
                {
                    inputSucess = InputLocationNumber(player1, ref tictactoeBoard);   //입력위치 입력
                }
                else
                {
                    inputSucess = InputByComputer(ref tictactoeBoard);                //컴퓨터 입력
                }

                if (!inputSucess) continue;

                if (gameTurnNumber >= 4)      //게임이 5턴 이상 되어야 승패가 갈릴 수있고 gmaTurnNumber 가 0 부터시작 했으므로 5 - 1 = 4부터 조사
                {
                    if (gameTurnNumber % 2 == 0)
                    {
                        winner = tictactoeBoard.CheckWinner(player1);
                    }
                    else winner = tictactoeBoard.CheckWinner(computer);

                    if (winner != null) gameResult.isDraw = false;
                }

                if (gameResult.winner != null && gameResult.isDraw == false)
                {
                    if (gameTurnNumber % 2 == 0)             //player1의 턴이었으면
                    {
                        gameResult.winner = player1;
                    }
                    else                                     //player2의 턴이었으면
                    {
                        gameResult.winner = computer;
                    }
                    gameResult.isDraw = false;
                    Console.Clear();

                    break;     //승자가 생기면 종료
                }


                ++gameTurnNumber;

                Console.Clear();
            }
            Console.WriteLine("\n\n\n\n\n\n");
            tictactoeBoard.PrintBoard();

            Thread.Sleep(1000);

            Console.Clear();

            return gameResult;
        }

        public GameResult PlayGame(string player1, string player2) //2P일 때 게임
        {
            int gameTurnNumber = 0;
            bool inputSucess = false;
            string pringWhiteSpace = "                                                ";
            
            TicTacToeBoard tictactoeBoard = new TicTacToeBoard(player1, player2);
            GameResult gameResult = new GameResult(player1, player2);

            while (gameTurnNumber < tictactoeBoard.BoardLength())
            {
                Console.WriteLine("\n\n\n\n");
                Console.Write(pringWhiteSpace);
                Console.WriteLine("      TIC TAC TOE       \n");

                tictactoeBoard.PrintBoard();      //보드 출력

                ShowActivePlayer(player1, player2, gameTurnNumber);    //누구의 턴인지 보여주는 그래픽 출력

                tictactoeBoard.PrintExampleBoard();       //입력위치번호 예시 출력

                inputSucess = InputLocationNumber(player1, player2, ref tictactoeBoard, gameTurnNumber);   //입력위치 입력

                if (!inputSucess) continue;  //입력성공 조사


                if (gameTurnNumber >= 4)      //게임이 5턴 이상 되어야 승패가 갈릴 수있으므로 4부터 조사
                {
                    if (gameTurnNumber % 2 == 0)  //player의 턴이었으면
                    {
                        gameResult.winner = tictactoeBoard.CheckWinner(player1);                       
                    }
                    else gameResult.winner = tictactoeBoard.CheckWinner(player2); //computer의 턴이었으면

                    if (gameResult.winner != null) gameResult.isDraw = false;
                }

                Console.Clear();

                if (gameResult.winner != null && gameResult.isDraw == false)
                {
                    if(gameTurnNumber % 2 == 0)
                    {
                        gameResult.winner = player1;
                        gameResult.loser = player2;
                    }
                    else
                    {
                        gameResult.winner = player2;
                        gameResult.loser = player1;
                    }
                    gameResult.isDraw = false;

                    break;     //승자가 생기면 종료
                }

                ++gameTurnNumber;
            }

            UpdateRecord(gameResult);

            Console.WriteLine("\n\n\n\n\n\n");
            tictactoeBoard.PrintBoard();

            Thread.Sleep(1000);

            return gameResult;
        }
        
        public void ShowPlayerRanking()        //현재 플레이어의 랭킹을 보여주는 메소드
        {
            StreamReader playerListFileToRead = new StreamReader(new FileStream("./playerNameList.txt", FileMode.Open), Encoding.UTF8);
            ConsoleKeyInfo ckey;

            List<Player> players = new List<Player>();       //플레이어들의 이름과 전적 리스트
            List<Player> playersSortedByRanking;
            string[] playerRecord;
            Player temp = new Player();
            string line;
            int loopNumber = 0;
            string pringWhiteSpace = "                                                ";
            
            while ((line = playerListFileToRead.ReadLine()) != null)
            {
                playerRecord = line.Split(',');
                temp.playerName = playerRecord[0];
                temp.win = int.Parse(playerRecord[1]);
                temp.lose = int.Parse(playerRecord[2]);
                temp.draw = int.Parse(playerRecord[3]);
                players.Add(new Player(temp.playerName, temp.win, temp.lose, temp.draw));
            }

            playersSortedByRanking = players.OrderByDescending(x => x.win).ThenBy(x => x.lose).ToList();   //승수로 내림차순 정렬 후 패수로 오름차순 정렬

            Console.WriteLine("\n\n\n\n");
            Console.Write(pringWhiteSpace);
            Console.WriteLine("      TIC TAC TOE       \n");

            Console.Write(pringWhiteSpace);

            Console.WriteLine("     Players Ranking\n");
            foreach (Player player in playersSortedByRanking)
            {
                Console.Write(pringWhiteSpace);
                if (loopNumber == 0) Console.Write("★");
                else Console.Write("  ");
                Console.WriteLine("{0}위 {1} : {2}승 {3}패 {4}무\n",++loopNumber, player.playerName,player.win,player.lose,player.draw);
            }
            Console.Write(pringWhiteSpace);

            Console.Write("   Press Any Key...\n");
            ckey = Console.ReadKey();
            Console.Clear();
            playerListFileToRead.Close();
        }
    }
}
