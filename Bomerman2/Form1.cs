using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bomerman2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeInterface();

        }
        GameArray game = new GameArray();
        GameRule rule = new GameRule();
        bool sandiq = false; int sx, sy;
        bool bonbaspit = false; int bx, by;
        private void Form1_Load(object sender, EventArgs e)
        {
               
        }       
       
        private void InitializeInterface()
        {
            label4.Text = "Bonus: " + game.Bonus;
            WallInterface();
            timer2.Start();
            timer1.Start();
           
        }
        private void WallInterface()
        {
            label2.Text = "Player Life " + game.Life;
            Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(b);

            for (int i = 0; i < GameArray.Array.GetLength(0); i++)
            {
                for (int j = 0; j < GameArray.Array.GetLength(1); j++)
                {
                    ///Wall
                    if (GameArray.Array[i, j] == 1)
                    {
                        g.FillRectangle(Brushes.DarkGray, 30 * i, 30 * j, 30, 30);
                    }
                     // Block
                    else if (GameArray.Array[i, j] == 3)
                    {
                     g.DrawImage(new Bitmap("brickwall1.png"), 30 * i, 30 * j, 30, 30);

                    }


                }
            }
            if (sandiq)
            {
               
                g.DrawImage(new Bitmap("Sandiq.png"), sx, sy, 30, 30);
            }
            if (bonbaspit)
            {
                
                g.DrawImage(new Bitmap("bombaSpit.png"), sx, sy, 30, 30);
            }

            BomermanFace.Location = new Point(game._SizeX,game._SizeY);
             for (int i = 0; i < 5; i++)
            {
                g.DrawImage(new Bitmap("bored.png"), GameArray._cripArray[i, 0], GameArray._cripArray[i, 1], 30, 30);
            }
            

            pictureBox1.Image = b;
        }
       

        private void RuleBomerman(Keys key)
        {
            
            try
            {
            
                switch (key)
                {
                    case Keys.A:
                    {
                            game.bomba = true;
                            game._bomba[0] = (game._SizeX-30)/30;
                            game._bomba[1] = (game._SizeY-30)/30;
                            bombaPict.Location = new Point(30*game._bomba[0]+30, 30*game._bomba[1]+30);

                            break;
                    }
                    case Keys.Enter:
                        {
                            timer2.Start();
                            timer1.Start();
                            break;
                        }
                    case Keys.Space:
                    {
                            timer2.Stop();
                            timer1.Stop();
                            break;
                    }

                    case Keys.Left:
                        {
                            if (rule.BomermanLeft(game._SizeX, game._SizeY))
                            {
                                game._SizeX -= game.Bomermanspeed;
                            }
                         
                            break;
                        }

                    case Keys.Right:
                        {
                            if (rule.BomermanRight(game._SizeX, game._SizeY))
                            {

                                game._SizeX += game.Bomermanspeed;
                            }
                        
                            break;
                        }

                    case Keys.Down:
                        {
                            if (rule.BomermanDown(game._SizeX, game._SizeY))
                            {

                                game._SizeY += game.Bomermanspeed;

                            }
                           
                            break;
                        }
                    case Keys.Up:
                        {
                            if (rule.BomermanUp(game._SizeX, game._SizeY))
                            {
                                game._SizeY -= game.Bomermanspeed;

                            }
                            break;
                        }
                }
            }
            catch (Exception e)
            {
               
            }

            BomermanFace.Location = new Point(game._SizeX, game._SizeY);

        }

    
        Random r = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {

            Bomba();
            
            GameTimer();
        }
        private void Bomba()
        {
            game._timerChange++;
            if (game.bomba == true)
            {
                game.bombaTime--;
                label5.Text = "Bomba Time: " + game.bombaTime;
            }
            if (game.bombaTime==0)
            {
                game.bombaTime=25;
                game.bomba = false;
                try
                {
                    for (int i = 1; i <=game._bombaSpit; i++)
                    {
                        GameArray.Array[game._bomba[0] , game._bomba[1]] = 0;
                        bombaPict.Location=new Point(504, 366);
                        Explosion(game._bomba[0]*30, game._bomba[1]*30);
                        label4.Text = "Bonus: " + game.Bonus;

                        if (game._bomba[0]-i>=0)
                        {
                            if (GameArray.Array[game._bomba[0] - i, game._bomba[1]] != 1)
                            {
                                if (GameArray.Array[game._bomba[0] - i, game._bomba[1]] == 5)
                                {
                                    NextStage(30 * (game._bomba[0] - i), 30 * (game._bomba[1]));
                                }
                                if (GameArray.Array[game._bomba[0] - i, game._bomba[1]] == 6)
                                {
                                    BombaSpit(30 * (game._bomba[0] - i), 30 * (game._bomba[1]));
                                }
                                else
                                {
                                GameArray.Array[game._bomba[0] - i, game._bomba[1]] = 0;

                                }
                            }
                        }
                        if (game._bomba[0]+i<23)
                        {
                            if (GameArray.Array[game._bomba[0] + i, game._bomba[1]] != 1)
                            {
                                if (GameArray.Array[game._bomba[0]+i, game._bomba[1] ] == 5)
                                {
                                    NextStage(30 * (game._bomba[0]+i), 30 * (game._bomba[1]));
                                }
                                if (GameArray.Array[game._bomba[0]+i, game._bomba[1]] == 6)
                                {
                                    BombaSpit(30 * (game._bomba[0]+i), 30 * (game._bomba[1]));
                                }
                                else
                                {
                                GameArray.Array[game._bomba[0] + i, game._bomba[1]] = 0;

                                }
                            }
                        }
                        if (game._bomba[1] - i >= 0)
                        {

                            if (GameArray.Array[game._bomba[0], game._bomba[1] - i] != 1)
                            {
                                if (GameArray.Array[game._bomba[0], game._bomba[1] - i] == 5)
                                {
                                    NextStage(30 * (game._bomba[0]), 30 * (game._bomba[1] - i));
                                }
                                if (GameArray.Array[game._bomba[0], game._bomba[1] - i] == 6)
                                {
                                    BombaSpit(30 * (game._bomba[0]), 30 * (game._bomba[1] - i));
                                }
                                else
                                {

                                GameArray.Array[game._bomba[0], game._bomba[1] - i] = 0;
                                }
                            }
                        }
                        if (game._bomba[1] + i < 11)
                        {
                            if (GameArray.Array[game._bomba[0], game._bomba[1]+i] != 1)
                            {
                                if (GameArray.Array[game._bomba[0], game._bomba[1]+i] == 5)
                                {
                                    NextStage(30*(game._bomba[0]),30*(game._bomba[1]+i));
                                }
                                if (GameArray.Array[game._bomba[0], game._bomba[1]+i] == 6)
                                {
                                    BombaSpit(30 * (game._bomba[0]), 30 * (game._bomba[1] + i));
                                }
                                else
                                {
                                GameArray.Array[game._bomba[0], game._bomba[1]+i] = 0;

                                }
                            }
                        }

                    }

                    InitializeInterface();

                }
                catch (Exception ex)
                {
                    
                }
            }
        }
        private void NextStage(int x,int y)
        {
            sandiq = true;
            sx = x;
            sy = y;
        }
        private void BombaSpit(int x, int y)
        {
            bonbaspit = true;
            bx = x;
            by = y;

        }
        private void Explosion(int x, int y)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Math.Abs(GameArray._cripArray[i, 0] - x) <=30 && Math.Abs(GameArray._cripArray[i, 1] - y) <=30)
                {
                    ConstantCripLocation(i);
                   
                }
            }
            if (Math.Abs(game._SizeX - 30 - x) < 30 && Math.Abs(game._SizeY - 30 - y) < 30)
            {
                game.Over = true;

            }
        }
        private void ConstantCripLocation(int i)
        {
            game.Bonus += 100;
          
            switch (i)
            {
                case 0: {  GameArray._cripArray[i, 0] = 540; GameArray._cripArray[i, 1] = 370; break; }
                case 1: {  GameArray._cripArray[i, 0] = 576; GameArray._cripArray[i, 1] = 370; break; }
                case 2: {  GameArray._cripArray[i, 0] = 616; GameArray._cripArray[i, 1] = 370; break; }
                case 3: { GameArray._cripArray[i, 0] = 652; GameArray._cripArray[i, 1] = 370; break; }
                case 4: {  GameArray._cripArray[i, 0] = 688; GameArray._cripArray[i, 1] = 370; break; }
               
                default:
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RuleBomerman(e.KeyCode);

        }


        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
 
        private void GameTimer()
        {
            if (game._timerValue != 0 && game._timerChange == 15)
            {
                label1.Text = "Timer: " + game._timerValue.ToString();
                game._timerValue -= 1;
                game._timerChange = 0;
            }
            if (game._SizeX==game._nextStage[0] && game._SizeY==game._nextStage[1])
            {
                game.Life += 2;
                game.Over = true;
            }
            if (game._SizeX == game._present[0] && game._SizeY == game._present[1])
            {
                game._bombaSpit += 1;
            }
            if(game.Life==0)
            {
                sandiq = false;
                bonbaspit = false;
                game.Life = 3;
                game._timerValue = 150;
                Mani mani = new Mani();
                mani.Show();
                this.Hide();
                MessageBox.Show("Game Over");
            }
            if(game._timerValue==0 || game.Over || rule.BomermenAndCrip(game._SizeX,game._SizeY))
            {
                game.Over = false;
                game._timerValue = 150;
                game.Life--;
                //GameOver stage = new GameOver();
                //stage.Show();
                timer1.Stop();
                timer2.Stop();
                game._SizeX = 30;
                game._SizeY = 30;
                MessageBox.Show("Stage: " + game.Life);
                GameArray array = new GameArray();              
                InitializeInterface();   
                
            }
            


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            RuleBomerman(e.KeyCode);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CripAction();
            WallInterface();
        }
        Random _Random = new Random();
        public void CripAction()
        {
              for (int i = 0; i < 5; i++)
            {
                CripRoute(GameArray._cripArray[i, 0], GameArray._cripArray[i, 1], i);

            }
        }
      
        private void CripRoute(int X, int Y, int CripIndex)
        {
            try
            {
                X += 30;
                Y += 30;
                switch (_Random.Next(4))
                {
                    //left
                    case 1:
                        {
                            if (rule.BomermanLeft(X, Y))
                            {
                                GameArray._cripArray[CripIndex, 0] -= 10;
                            }

                            break;
                        }
                    case 2:
                        {
                            if (rule.BomermanRight(X, Y))
                            {
                                GameArray._cripArray[CripIndex, 0] += 10;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (rule.BomermanDown(X, Y))
                            {
                                GameArray._cripArray[CripIndex, 1] += 10;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (rule.BomermanUp(X, Y))
                            {
                                GameArray._cripArray[CripIndex, 1] -= 10;
                            }
                            break;
                        }
                }
            }
            catch (Exception es)
            {
                
            }
        }

    }
}
