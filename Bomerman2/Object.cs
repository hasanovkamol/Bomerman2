using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomerman2
{
    class Object
    {
        public int Life = 3;
        public bool Over=false;
        public bool Paused = false;
        public static int[,] Array = new int[23, 11];
        public static  int[,] _cripArray = new int[5, 2];
        public int[] _nextStage = new int[2];
        public int[] _present = new int[2];
        public int Bonus = 0;
        public int Bomermanspeed = 5;
        public int bombaTime = 25;
        public bool bomba = false;
        public int _bombaSpit = 1;
        public int[] _bomba = new int[2];
        public int _timerValue = 150;
        public int _timerChange = 0;
        public int _SizeX = 30;
        public int _SizeY = 30;
    }
}
