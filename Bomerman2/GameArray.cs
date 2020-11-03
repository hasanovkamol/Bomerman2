using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomerman2
{
    class GameArray:Object
    {
        Random _random = new Random();
        int a=0, b=0;
        // mani function
        public  GameArray()
        {
            WallGenrationLocation();
            BomermanGenrationLocation();
            BlockGenrationLocation();
            CripGenrationLocation();
            NextStageWayLocation();
            PresentLocation();
            Array[0, 1] = 0;
            Array[1, 0] = 0;
         
        }
 
        /// 1: Wall
        private  void WallGenrationLocation()
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {

                    if (i % 2 != 0 && j % 2 != 0)
                    {
                        Array[i, j] = 1;
                    }
                    else
                    {
                        Array[i, j] = 0;

                    }
                }
            }
            
        }
        /// 2: Crip
     //   Form1 form = new Form1();
        private void CripGenrationLocation()
        {

            for (int i = 0; i <5;)
            {
                a = _random.Next(0, 22);
                b = _random.Next(0, 10);
                if (Array[a,b]==0)
                {
                    Array[a, b] = 2;
                    _cripArray[i, 0] =30*a;
                    _cripArray[i, 1] = 30*b;
                    i++;
                    
                }
            }
        }
        /// 4: Bomerman
        private void BomermanGenrationLocation()
        {
            Array[0, 0] = 4;
            
        }
        /// 3: Block
        private void BlockGenrationLocation()
        {

            for (int i = 0; i <80 ;)
            {
                a = _random.Next(0,22);
                b = _random.Next(0, 10);
                    if (Array[a,b]==0)
                    {
                    Array[a, b] = 3;
                    i++;
                    }
                if (Array[a+1, b] == 0)
                {
                    i++;
                    Array[a+1, b] = 3;
                }
                if (Array[a, b+1] == 0)
                {
                    i++;
                    Array[a, b+1] = 3;
                }
           
          
            }
            
        }
        /// 5: Stage
        private void NextStageWayLocation()
        {
            while (true)
            {
                a = _random.Next(0, 22);
                b = _random.Next(0, 10);
                if (Array[a,b]==3)
                {
                    Array[a, b] = 5;
                    _nextStage[ 0] = a;
                    _nextStage[ 1] = b;
                    break;
                }
            }
        }
        /// 6: Present
        private void PresentLocation()
        {
            while (true)
            {
                a = _random.Next(0, 22);
                b = _random.Next(0, 10);
                if (Array[a, b] == 3)
                {
                    Array[a, b] = 6;
                    _present[ 0] = a;
                    _present[ 1] = b;
                    break;
                }
            }
        }
    }
}
