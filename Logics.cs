using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeLadderGame
{
    class Logics
    {

        /// <summary>
        /// Roll Dice method
        /// <param name="pictureBox"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static int RollDice(ref int n)
        {

            int num = 0;
            Random r = new Random();
            num = r.Next(1, 7);

            n = num;


            return num;
        }


        public static void MovePlayer(ref int x, ref int y, ref int p, int dice, ref int[] position
            , PictureBox px, Label l, ref bool isLeftToRight)
        {

            if (dice + p > 101)
            {
                l.Text = "Can't move!";
                l.ForeColor = Color.Red;
                return;
            }
            for (int i = 0; i < dice; i++)
            {
                InitializeLeftOrRight(ref isLeftToRight, ref p);

                Move(ref p, ref x, ref isLeftToRight);

                //switching player to up
                SwitchToUp(ref p, ref x, ref y);

                //initialize important positions
                if (i == dice - 1)
                {
                    //ladder area
                    InitializeLadderArea(ref p, ref x, ref y);
                    //snake area
                    InitializeSnakeArea(ref p, ref x, ref y);

                }


                l.Text = p.ToString();
                px.Location = new Point(x, y);
                p++;
                position[p] = 1;
            }
        }
        //********************************************************************************************

        static void InitializeLeftOrRight(ref bool isLeftToRight, ref int p)
        {
            if ((p > 10 && p < 21) || (p > 30 && p < 41) || (p > 50 && p < 61) ||
                (p > 70 && p < 81) || (p > 90 && p < 101))
            {
                isLeftToRight = false;
            }
            else if ((p > 20 && p < 31) || (p > 40 && p < 51) || (p > 60 && p < 71) || (p > 80 && p < 91))
            {
                isLeftToRight = true;
            }
        }

        static void SwitchToUp(ref int p, ref int x, ref int y)
        {
            switch (p)
            {
                case 11:
                    {
                        x = 656;
                        y = 434;
                        break;
                    }
                case 21:
                    {
                        x = 11;
                        y = 379;
                        break;
                    }
                case 31:
                    {
                        x = 660;
                        y = 324;
                        break;
                    }
                case 41:
                    {
                        x = 11;
                        y = 276;
                        break;
                    }
                case 51:
                    {
                        x = 657;
                        y = 220;
                        break;
                    }
                case 61:
                    {
                        x = 11;
                        y = 165;
                        break;
                    }
                case 71:
                    {
                        x = 661;
                        y = 109;
                        break;
                    }
                case 81:
                    {
                        x = 11;
                        y = 54;
                        break;
                    }
                case 91:
                    {
                        x = 660;
                        y = 0;
                        break;
                    }
            }
        }
        static void InitializeSnakeArea(ref int p, ref int x, ref int y)
        {

            switch (p)
            {
                case 43:
                    {
                        x = 229;
                        y = 434;
                        p = 17;
                        break;
                    }
                case 50:
                    {
                        x = 293;
                        y = 485;
                        p = 5;
                        break;
                    }
                case 56:
                    {
                        x = 514;
                        y = 485;
                        p = 8;
                        break;
                    }
                case 87:
                    {
                        x = 586;
                        y = 266;
                        p = 49;
                        break;
                    }
                case 84:
                    {
                        x = 162;
                        y = 217;
                        p = 58;
                        break;
                    }
                case 98:
                    {
                        x = 3;
                        y = 327;
                        p = 40;
                        break;
                    }

                case 73:
                    {
                        x = 372;
                        y = 434;
                        p = 15;
                        break;
                    }


            }

        }
        static void InitializeLadderArea(ref int p, ref int x, ref int y)
        {
            switch (p)
            {
                case 2:
                    {
                        x = 148;
                        y = 381;
                        p = 23;
                        break;
                    }
                case 6:
                    {
                        x = 295;
                        y = 275;
                        p = 45;
                        break;
                    }
                case 20:
                    {
                        x = 83;
                        y = 219;
                        p = 59;
                        break;
                    }
                case 52:
                    {
                        x = 587;
                        y = 109;
                        p = 72;
                        break;
                    }
                case 57:
                    {
                        x = 294;
                        y = 3;
                        p = 96;
                        break;
                    }
                case 71:
                    {
                        x = 585;
                        y = 3;
                        p = 92;
                        break;
                    }
            }
        }

        static void Move(ref int p, ref int x, ref bool isLeftToRight)
        {
            if (!(p == 11 || (p == 21) || (p == 31) || (p == 41) || (p == 51) || (p == 61) ||
                    (p == 71) || (p == 81) || (p == 91)))
            {
                if (isLeftToRight == false)
                {
                    x -= 72;
                }

                else if (isLeftToRight == true)
                {
                   x += 72;
                }
            }
        }
    }
}


