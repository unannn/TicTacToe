using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameFlow : GameScenes
    {
        public enum Menu
        {
         PLAYERVSPLAYER,
         PLAYEVSCOMPUTER,
         ADDPLAYER,
         RANKING,
         ENDGAME   
        }
        public int SelectType()
        {
            char selectedTypeInChar;
            int selectedType = 0;
            bool rightInput = false;
            List<string> menuItem = new List<string>()   //메뉴 리스트 생성
            {
                "1. PLAYER VS PLAYER",
                "2. PLAYER VS COMPUTER",
                "3. ADD PLAYER",
                "4. RANKING",
                "5. END GAME"
            };
            while (!rightInput)
            {
                foreach (string item in menuItem)
                {
                    Console.WriteLine(item);
                }
                Console.Write("메뉴 선택 : ");
                selectedTypeInChar = Convert.ToChar(Console.Read());

                if (selectedTypeInChar >= '1' &&  selectedTypeInChar <= '5') {
                    selectedType = selectedTypeInChar - '0';
                    rightInput = true;
                }
                Console.Clear();
            }

            return 0;
        }
        public void SelectPlayer(ref string player1, ref string player2,int gameMode)
        {
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
