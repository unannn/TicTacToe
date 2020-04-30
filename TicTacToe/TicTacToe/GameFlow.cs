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
                "1. PLAYER VS PLAYER",
                "2. PLAYER VS COMPUTER",
                "3. ADD PLAYER",
                "4. RANKING",
                "5. END GAME"
            };

            while (!rightInput)       //1~5의 정수 입력 시 까지 반복
            {
                foreach (string item in menuItem)
                {
                    Console.WriteLine(item);
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

        public void SelectPlayer(ref string player1, ref string player2,int gameType)
        {
            List<string> playerNameList = new List<string>();   //메뉴 리스트 생성
            StreamReader playerNameListFile = new StreamReader("./playerNameList.txt",Encoding.Default);
            string line;
           
            while ((line = playerNameListFile.ReadLine()) != null)
            {
                playerNameList.Add(line);
            }
            
            foreach (string name in playerNameList)
            {
                Console.WriteLine(name);
            }
                        
        }

        public void PlayGame(string player1,string player2,int gameMode)
        {
            switch (gameMode)
            {
                case GameTypes.vsPlayer:
                    PlayerVsPlayer();
                    break;

                case GameTypes.vsComputer:
                    PlayerVsComputer();
                    break;

                default:
                    //생각해보기
                    break;
            }
        }
    }
}
