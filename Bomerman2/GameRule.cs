using System;

namespace Bomerman2
{
    class GameRule:GameArray
    {

        public GameRule()
        {

        }
        
        public bool BomermanRule(int x, int y)
        {
            if (GameArray.Array[(x - 30) / 30 + 1, (y - 30) / 30 + 1] == 1)
            {
                return false;
            }
            return true;
        }    
        public bool BomermanLeft(int x,int y)
        {

            if (x > 30 && Array[x / 30, (y - 3) / 30] != 1 && Array[x / 30, (y - 30) / 30] != 1 && LeftBlock(x,y) )
            {
       
                return true;
                
            }
            return false;
        }
        private bool LeftBlock(int x,int y)
        {
            if (Array[(x-30)/30,(y-30)/30]!=3)
            {
                return true;
            }
            return false;
        }
        public bool BomermanRight(int x,int y)
        {
            if (x < 690 && Array[x / 30, (y - 3) / 30] != 1 && Array[x / 30, (y - 30) / 30] != 1 && RightBlock(x,y) )
            {

                return true;
              
            }
            return false;
        }
        private bool RightBlock(int x,int y)
        {
            if (Array[(x)/30,(y-30)/30]!=3)
            {
                return true;
            }
            return false;
        }
        public bool BomermanDown(int x,int y)
        {
            if (y < 330 && Array[(x - 3) / 30, y / 30] != 1 && Array[(x - 30) / 30, y / 30] != 1 && DownBlock(x,y))
            {

                return true;
                
            }
            return false;
        }
        private bool DownBlock(int x, int y)
        {
            if (Array[(x-30)/30,(y)/30]!=3)
            {
                return true;
            }
            return false;
        }
        public bool BomermanUp(int x,int y)
        {
            if (y > 30 && Array[(x - 3) / 30, y / 30] != 1 && Array[(x - 30) / 30, y / 30] != 1 && UpBlock(x,y))
            {

                    return true;
                
            }
            return false;
        }
        private bool UpBlock(int x,int y)
        {
            if (Array[(x-30)/30,(y-30)/30]!=3)
            {
                return true;
            }
            return false;
        }

       public bool BomermenAndCrip(int x,int y)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Math.Abs(_cripArray[i,0]-x)<30 && Math.Abs(_cripArray[i,1]-y)<30)
                {
                    bombaTime = 0;
                    return true;
                }
            }
            return false;
        }

    
    }
}
