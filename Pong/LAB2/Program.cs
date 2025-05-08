//************************************************
//Naresh Koirala, LAB-2
//************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GDIDrawer;
using System.Drawing;
using System.Media;
using System.Configuration;
using System.IO;

/*   WHAT IS SPECIAL???
 *   
 *   -INTRO MUSIC
 *   -OUTRO MUSIC
 *   -BOUNCE MUSIC
 *   -PONG STARTS AT RANDOM POINT
 *   -WALL COLOR CHANGES WHEN IT BOUNCE OF THAT WALL
 *   -PONG CHANGE COLOR WHEN PONG BOUNCES OF THE PADDLE
 *   -SCORE COUNT CHANGE COLOR EVERYTIME THE NUMBER CHANGES
 *   -THERE IS A CIRCLE POINT IN THE WINDOW WHEN U HIT THAT U GET -1.
 *   -THE CIRCLE ADD 1 TO THE PREVIOUS ONE IN ROUND 6,9 10 AND 13.        
 *      -POINT CHANGES AT EVERY DIFFERENT ROUND
 *      -STARTS AT DIFFERENT POINT AT THE WINDOW
 *   -THERE IS A SQURE U CAN HIT AFTER ROUND 5, IF U HIT IT U GET +3
 *   -THERE IS THE HIGHSCORE LOG WHICH GET SAVE EVEN IF U CLOSE THE APP AND START BACK IN THE HIGHSCORE DOESN'T GO TO 0        
 *   -STAYS SAME FROM THE PREVIOUS TIME U PLAYED-BEAUTIFUL START AND END SCREEN (NOT UGLY...DEFINITLY) 
 *   -YOU HAVE LIFES (3)
 */

namespace LAB2
{
    class Program
    {
        static void Main(string[] args)
        {
            restart://REPEATATION AFTER THE END SCREEN

            //reading the txt-----------------------------------------------------------------------------
            string[] text = System.IO.File.ReadAllLines(@"log.txt");//reading the txt at string[] text
            int highscroce = 0;//varable to store highscroe
            foreach(string text1 in text)//for each line in text
            {
                if (int.Parse(text1) > highscroce)//if any values is higher
                    highscroce = int.Parse(text1);//restore the value
            }
            //--------------------------------------------------------------------------------------------

            //main----------------------------------------------------------------------------------------
            Random rng = new Random();//new random varable
            int x = rng.Next(20, 100);//to store x value
            int y = rng.Next(20, 100);//to store y value
            int xv = 1;//varable for x velocity
            int yv = 1;//varable for y velocity
            int diameter = 2;//diameter value
            int bounce = 0;//bounce counting 
            int redo = 0;//redo varable
            int speed = 20;//speed for the thread
            //--------------------------------------------------------------------------------------------

            //sound-------------------------------------------------------------------------------------------------------
            //SoundPlayer walls = new SoundPlayer("SPRTField_Balloon against wall 2 (ID 1826)_BSB.wav");//creating walls varable and storeing the tune
            //SoundPlayer intro = new SoundPlayer("BEAT SESSION DRUM LOOP 12_110BPM_Dmaj.wav");//creating intro varable and storeing the tune
            //SoundPlayer outro = new SoundPlayer("03 Acoustic Guitar - Lost Without You Outro - 65 BPM - Gm.wav");//creating outro varable and storeing the tune
            //intro.Load(); outro.Load(); walls.Load();//loading outro, intro and walls music
            //------------------------------------------------------------------------------------------------------------

            //color change -----------------------------------------------------------------------------------------------
            bool ychange = false, xchange = false, Ychange = false, Xchange = false;//bools for changing the colour
            Color wall = Color.CadetBlue;//creating color varable
            Color wall1 = Color.CadetBlue;//creating color varable
            Color wall2 = Color.CadetBlue;//creating color varable
            Color ball = Color.Green;//creating color varable
            Color number = Color.Gray;//creating color varable
            //------------------------------------------------------------------------------------------------------------

            //power up------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            int randX = rng.Next(10, 150), ranX = rng.Next(10, 150), RanX = rng.Next(10, 150), RanX1 = rng.Next(10, 150), RanX2 = rng.Next(10, 150);//creating and storing random value  x value
            int randY = rng.Next(10, 115), ranY = rng.Next(10, 115), RanY = rng.Next(10, 115), RanY1 = rng.Next(10, 115), RanY2 = rng.Next(10, 115);//creating and storing random value  y value
            int powerDia = 4;//diameter of power up
            int add = 1, adds = 1, addss = 1, addss1 = 1, addss2 = 1;//adds varable to count the loop
            bool more = false, mores = false, More = false, More1 = false, More2 = false;//bools for changing color
            int squareX = rng.Next(10, 150), squareY = rng.Next(10, 115);//square x and y value random
            int Add = 1, addo = 0, rep = 0;//for the square varable
            bool power = false;//bool for the square power up
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //gdi window---------------------------------------------------------------------
            CDrawer pong = new CDrawer(800, 600, false)//creating the window
            {
                ContinuousUpdate = false,//continuous update false
                Scale = 5//scaling to 5
            };
            //-------------------------------------------------------------------------------

            //first window---------------------------------------------------------------------------------------------
            //intro.PlayLooping();//playing the song in loop unless it is stopped
            pong.AddText("Vintage Pong", 60, 5, 1, 150, 70, Color.BlueViolet);//title of the window
            pong.AddText("Made By:- Naresh Koirala, LAB-2.", 10, 5, 89, 60, 30, Color.Silver);//title window
            pong.AddText("Click to start...", 30, Color.HotPink);//user messgae
            pong.AddText("\n\n\n-AVOID THE CIRCLE", 20, Color.Gray);//user msg
            pong.AddText("\n\n\n\n\n\n-3 LIVES MAKE IT COUNT ;p\n(has to be dead centered)", 20, Color.Gray);//user msg
            pong.AddLine(0, 0, 160, 0, Color.Green, 140);//border
            pong.AddLine(160, 0, 160, 120, Color.Orange, 140);//border
            pong.AddLine(0, 0, 0, 120, Color.Yellow, 140);//border
            pong.AddLine(0, 120, 160, 120, Color.Blue, 140);//border
            pong.Render();//rendering pong
            //----------------------------------------------------------------------------------------------------------

        repeat://repeating from go to

            pong.GetLastMouseLeftClickScaled(out Point start);//getting the value when left clicked

            if (start.X != -1)//if the click is readed
            {
                //intro.Stop();//stopping the intro song

                do//loop to pong
                {
                first://repeating from goto first

                    //lives------------------------------------------------------------------------------------------------------------
                    pong.AddText("LIFES:",13,130,1,20,6,Color.Red);//text for user
                    if (redo == 0)//condition if redo is 0
                    {
                        pong.AddCenteredRectangle(157, 4, 2, 2, Color.Red);//create lives
                        pong.AddCenteredRectangle(152, 4, 2, 2, Color.Red);//create lives
                        pong.AddCenteredRectangle(147, 4, 2, 2, Color.Red);//create lives
                        pong.Render();//pong rendering
                    }
                    if (redo == 1)//condition if redo is 1
                    {
                        pong.AddCenteredRectangle(157, 4, 2, 2, Color.Red);//create lives
                        pong.AddCenteredRectangle(152, 4, 2, 2, Color.Red);//create lives
                        pong.Render();//pong rendering
                    }
                    if (redo == 2)//condition if redo is 2
                    {
                        pong.AddCenteredRectangle(157, 4, 2, 2, Color.Red);//create lives
                        pong.Render();//pong rendering
                    }
                    if (redo == 3)//condition if redo is 3
                    {
                        pong.AddText("0", 15, 140, 1, 20, 6, Color.Red);//create lives
                        pong.AddText("LAST LIFE....\nMAKE IT COUNT;)...", 20, 5, 1, 150, 70, Color.Red);//adding text for the user
                    }
                    //------------------------------------------------------------------------------------------------------------------------

                    //border---------------------------------------------------------------------------------------
                    pong.AddRectangle(160, 2, 2, 120, wall, 12);//adding the border for the main game window
                    pong.AddRectangle(0, -3, 160, 3, wall2, 12);//adding the border for the main game window
                    pong.AddLine(0, 120, 160, 120, wall1, 12);//adding the border for the main game window
                    //---------------------------------------------------------------------------------------------

                    //paddle---------------------------------------------------------------------------------------
                    pong.GetLastMousePositionScaled(out Point mos);//mouse position for the paddle
                    int Pong = mos.Y;//pong== y value
                    Pong = ((Pong > 7) ? Pong : 7);//resistive condition
                    Pong = ((Pong < 113) ? Pong : 113);//resistive condition
                    pong.AddLine(5 / 3, Pong - 5, 5 / 3, Pong + 5, Color.Red, 5);//drawing paddle
                    //---------------------------------------------------------------------------------------------

                    //pong-----------------------------------------------------------------------------------------
                    pong.AddRectangle((int)x, (int)y, diameter, diameter, ball);//drawing the pong ball
                    //---------------------------------------------------------------------------------------------

                    //thread
                    System.Threading.Thread.Sleep(speed);
                    pong.Clear();

                    //velocity-----------------------------------
                    x += xv;//changing the x value
                    y += yv;//changing the y value
                    //-------------------------------------------

                    //middle count
                    pong.AddText($"{bounce}", 52, number);

                    //power up ------------------------------------------------------------------------------------------------------------------
                    //HONESTLY SORRY MAYA I COULDN'T BE BORTHERED TO COMMENT ON POWER UPS BUT I GET IT
                    pong.AddCenteredEllipse(randX, randY, powerDia, powerDia, Color.Honeydew);
                    pong.Render();
                    if (bounce == add + 1)
                        more = true;
                    if (more == true)
                    {
                        randX = rng.Next(10, 150);
                        randY = rng.Next(10, 115);
                        pong.AddCenteredEllipse(randX, randY, powerDia, powerDia, Color.FromArgb(rng.Next()));
                        more = false;
                        add = bounce;
                    }
                    if (x == randX || x + 2 == randX || x - 2 == randX || x + 1 == randX || x - 1 == randX)
                    {
                        if (y == randY || y + 2 == randY || y - 2 == randY || x + 1 == randY || x - 1 == randY)
                        {
                            bounce--;
                            randX = rng.Next(10, 150);
                            randY = rng.Next(10, 115);
                            pong.Render();

                        }
                    }//power up
                    if (bounce > 4)
                    {
                        pong.AddCenteredEllipse(ranX, ranY, powerDia, powerDia, Color.Maroon);
                        pong.Render();
                        if (bounce == adds + 1)
                            mores = true;
                        if (mores == true)
                        {
                            ranX = rng.Next(10, 150);
                            ranY = rng.Next(10, 115);
                            pong.AddCenteredEllipse(ranX, ranY, powerDia, powerDia, Color.FromArgb(rng.Next()));
                            mores = false;
                            adds = bounce + 1;

                        }
                        if (x == ranX || x + 2 == ranX || x - 2 == ranX || x + 1 == ranX || x - 1 == ranX)
                        {
                            if (y == ranY || y + 2 == ranY || y - 2 == ranY || x + 1 == ranY || x - 1 == ranY)
                            {
                                bounce--;
                                ranX = rng.Next(10, 150);
                                ranY = rng.Next(10, 115);
                                pong.Render();
                            }
                        }
                    }//power up
                    if (bounce > 6)
                    {
                        pong.AddCenteredEllipse(RanX, RanY, powerDia, powerDia, Color.Magenta);
                        pong.Render();
                        if (bounce == addss + 1)
                            More = true;
                        if (More == true)
                        {
                            RanX = rng.Next(10, 150);
                            RanY = rng.Next(10, 115);
                            pong.AddCenteredEllipse(RanX, RanY, powerDia, powerDia, Color.FromArgb(rng.Next()));
                            More = false;
                            addss = bounce + 1;

                        }
                        if (x + 2 == RanX || x - 2 == RanX || x == RanX || x + 1 == RanX || x - 1 == RanX)
                        {
                            if (y == RanY || y + 2 == RanY || y - 2 == RanY || x + 1 == RanY || x - 1 == RanY)
                            {
                                bounce--;
                                RanX = rng.Next(10, 150);
                                RanY = rng.Next(10, 115);
                                pong.Render();
                            }
                        }
                    }//power up
                    if (bounce > 8)
                    {
                        pong.AddCenteredEllipse(RanX1, RanY1, powerDia, powerDia, Color.Salmon);
                        pong.Render();
                        if (bounce == addss1 + 1)
                            More1 = true;
                        if (More1 == true)
                        {
                            RanX1 = rng.Next(10, 150);
                            RanY1 = rng.Next(10, 115);
                            pong.AddCenteredEllipse(RanX1, RanY1, powerDia, powerDia, Color.FromArgb(rng.Next()));
                            More1 = false;
                            addss1 = bounce + 1;

                        }
                        if (x + 2 == RanX1 || x - 2 == RanX1 || x == RanX1 || x + 1 == RanX1 || x - 1 == RanX1)
                        {
                            if (y == RanY1 || y + 2 == RanY1 || y - 2 == RanY1 || x + 1 == RanY1 || x - 1 == RanY1)
                            {
                                bounce--;
                                RanX1 = rng.Next(10, 150);
                                RanY1 = rng.Next(10, 115);
                                pong.Render();
                            }
                        }
                    }//power up
                    if (bounce > 10)
                    {
                        pong.AddCenteredEllipse(RanX2, RanY2, powerDia, powerDia, Color.Peru);
                        pong.Render();
                        if (bounce == addss2 + 1)
                            More2 = true;
                        if (More2 == true)
                        {
                            RanX2 = rng.Next(10, 150);
                            RanY2 = rng.Next(10, 115);
                            pong.AddCenteredEllipse(RanX2, RanY2, powerDia, powerDia, Color.FromArgb(rng.Next()));
                            More2 = false;
                            addss2 = bounce + 1;

                        }
                        if (x + 2 == RanX2 || x - 2 == RanX2 || x == RanX2 || x + 1 == RanX2 || x - 1 == RanX2)
                        {
                            if (y == RanY2 || y + 2 == RanY2 || y - 2 == RanY2 || x + 1 == RanY2 || x - 1 == RanY2)
                            {
                                bounce--;
                                RanX2 = rng.Next(10, 150);
                                RanY2 = rng.Next(10, 115);
                                pong.Render();
                            }
                        }
                    }//square power up
                    if (bounce >= 5)
                    {
                        pong.AddCenteredRectangle(squareX, squareY, powerDia, powerDia, Color.Gold);
                        pong.Render();

                        if (bounce == Add + 1)
                            power = true;
                        if (power == true)
                        {
                            squareX = rng.Next(10, 150);
                            squareY = rng.Next(10, 115);
                            pong.AddCenteredEllipse(squareX, squareY, powerDia, powerDia, Color.FromArgb(rng.Next()));
                            power = false;
                            Add = bounce + 1;

                        }
                        if (x + 2 == squareX || x - 2 == squareX || x == squareX || x + 1 == squareX || x - 1 == squareX)
                        {
                            if (y == squareY || y + 2 == squareY || y - 2 == squareY || x + 1 == squareY || x - 1 == squareY)
                            {
                                do
                                {
                                    if (rep == 0)
                                    {
                                        pong.Clear();
                                        pong.AddText("+3... POINTS", 40, Color.Green);
                                        pong.AddText("\n\nCONGRATULATION", 30, Color.Green);
                                        pong.AddLine(0, 0, 160, 0, Color.ForestGreen, 180);
                                        pong.AddLine(160, 0, 160, 120, Color.Goldenrod, 180);
                                        pong.AddLine(0, 120, 160, 120, Color.Yellow, 180);
                                        pong.AddLine(0, 0, 0, 120, Color.CadetBlue, 180);
                                        System.Threading.Thread.Sleep(20);
                                        pong.Render();
                                        squareX = rng.Next(10, 150);
                                        squareY = rng.Next(10, 115);
                                        addo++;
                                        if (addo == 60)
                                        {
                                            bounce = bounce + 3;
                                            rep = 1;
                                        }
                                    }
                                    else
                                    {
                                        rep = 0;
                                        addo = 0;
                                        goto first;
                                    }

                                } while (true);
                            }
                        }

                    }
                    //------------------------------------------------------------------------------------------------------- END OF POWER UPS

                    //bounce top and bottom-------------------------------------
                    if (y == 118 || y == 2)
                    {
                        if (y == 118)
                            Ychange = true;

                        yv *= -1;
                        //walls.Play();
                        if (y == 2)
                            ychange = true;

                        pong.Render();
                    }//---------------------------------------------------------
                    //bounce right wall-----------------------------------------
                    if (x == 158)
                    {
                        //walls.Play();
                        xchange = true;
                        xv = -1;
                        pong.Render();
                    }//---------------------------------------------------------
                    //paddle bounce------------------------------------------------------------------------------------------------------------
                    if (x == 5 / 2)
                    {
                        if (y < Pong + 7 && y > Pong - 7)
                        {
                            number = Color.FromArgb(rng.Next(1, 256), rng.Next(1, 256), rng.Next(1, 256));
                            //walls.Play();
                            Xchange = true;
                            bounce++;
                            xv *= -1;
                        }
                        pong.Render();
                    }//-------------------------------------------------------------------------------------------------------------------------

                    //color changing------------------------------------------------------------------------------------------------------------
                    if (ychange == true || Ychange == true || xchange == true)
                    {
                        //speed change
                        if (bounce > 2)
                        {
                            if (speed > 5 && speed < 21)
                            {
                                speed = 20 - (bounce - 2);
                            }
                            else
                                speed = 4;
                            if (bounce > 13)
                                speed = 2;
                            if (bounce > 20)
                                speed = 1/2;
                        }
                        goto changing;
                    }
                    //--------------------------------------------------------------------------------------------------------------------------

                changing:

                    do//CHANGING THE COLOR---------------------------------------------------------------------------------------------------------------
                    {

                        if (ychange == true)//wall color change 
                        {
                            wall2 = Color.FromArgb(rng.Next(1, 256), rng.Next(1, 256), rng.Next(1, 256));
                            ychange = false;
                            pong.Render();
                        }
                        if (Ychange == true)//wall color change 
                        {
                            wall1 = Color.FromArgb(rng.Next(1, 256), rng.Next(1, 256), rng.Next(1, 256));
                            Ychange = false;
                            pong.Render();
                        }
                        if (xchange == true)//wall color change 
                        {
                            wall = Color.FromArgb(rng.Next(1, 256), rng.Next(1, 256), rng.Next(1, 256));
                            xchange = false;
                            pong.Render();
                        }
                        if (Xchange == true)//ball color change 
                        {
                            ball = Color.FromArgb(rng.Next(1, 256), rng.Next(1, 256), rng.Next(1, 256));
                            Xchange = false;
                            pong.Render();
                        }
                        if (xchange != true && ychange != true && Ychange != true && Xchange != true)//condition to exit color change loop
                            goto colorchange;//go to color change

                        pong.Render();//rendering
                    } while (true);
                    //-------------------------------------------------------------------------------------------------------------------------------------

                colorchange://re for goto color change

                    //lives----------------------------------------------------------------------------------
                    if (x < 2 && redo < 3)//condition for lives
                    {
                        redo++;//adding redo
                        x = rng.Next(20, 100) * 1;//new x point
                        y = rng.Next(20, 100) * 1;//new y point
                        xv *= -1;//direction change
                        yv *= -1;//direction change
                        goto repeat;//go to repeat
                    }
                    //---------------------------------------------------------------------------------------

                    //loss-----------------------------------------------------------------------------------------------------
                    if (x < 2 && redo == 3)//if loss condition
                    {
                        if (bounce > highscroce)//if bounce is more then the last highschool
                        {
                            highscroce = bounce;//storing the highscore
                            logger.Writelog($"{highscroce}");//storing the highscore in txt
                        }

                        pong.Clear();//clearing the screen
                        //outro.PlayLooping();//outro song starts
                        pong.AddLine(0, 0, 160, 0, Color.ForestGreen, 150);//border
                        pong.AddLine(160, 0, 160, 120, Color.Goldenrod, 150);//border
                        pong.AddLine(0, 120, 160, 120, Color.Yellow, 150);//border
                        pong.AddLine(0, 0, 0, 120, Color.CadetBlue, 150);//border

                        pong.AddText($"Final score: {bounce}", 52, Color.Red);//displaying the score
                        pong.AddText($"\n\n\nHighscore: {highscroce}", 30, Color.Gray);//displaying the highscore

                        pong.AddRectangle(100, 95, 19, 10, Color.Black, 2, Color.Green);//displaying the play again button
                        pong.AddText("Play again.", 13, 40, 40, 140, 120, Color.Green);//displaying the play again button

                        pong.AddRectangle(130, 95, 19, 10, Color.Black, 2, Color.White); //displaying the quit button
                        pong.AddText("Quit", 13, 70, 40, 140, 120, Color.White); //displaying the quit button

                        if (x <= 0 && redo == 3)//condition to go to click
                        {
                            goto click;//going to click
                        }
                    }
                    //--------------------------------------------------------------------------------------------------------
                }
                while (true);//----------------------------------------------------------------------------------------------------------------------------------
            }

            else//repeating if the click to start is -1
            {
                goto repeat;//GOTO REPEAT
            }

            click://GO TO REF

            do//CKICK LOOP FOR THE END SCREEN------------------------------------------------------------
            {
                pong.GetLastMouseLeftClickScaled(out Point again);//GET THE LEFT CLICK VALUE IN END SCREEN

                if (again.X >= 130 && again.X <= 144)// X CONDITION FOR THE END SCREEN (QUIT)
                {
                    if (again.Y >= 94 && again.Y <= 100)// Y CONDITION FOR THE END SCREEN (QUIT)
                    {
                        //outro.Stop();//OUTRO STOPPING
                        pong.Close();//GDI DRAWER CLOSER
                        System.Environment.Exit(0);//SYSTEM CLOSING
                    }
                }
                else if (again.X >= 75 && again.X <= 116)//X CONDITION FOR THE END SCREEN (PLAY AGAIN)
                {
                    if (again.Y >= 94 && again.Y <= 100)//Y CONDITION FOR THE END SCREEN (PLAY AGAIN)
                    {
                        //outro.Stop();//STOPING THE OUTRO 
                        pong.Close();//CLOSING THE GDI DRAWER
                        goto restart;//GOING BACK TO RESTART
                    }
                }

                else//ELSE TO BREAK THE LOOP
                    break;//BREAKING THE LOOP

            } while (true);//--------------------------------------------------------------------------

            goto click;//GO BACK TO CLICK

        }

        //STORING THE HIGHSCORE--------------------------------------------------------------------------------------------
        private static class logger//CREATING NEW CLASS
        {
            internal static void Writelog(string v)//SUB-VARABLE FOR LOGGER 
            {
                string logPath = ConfigurationManager.AppSettings["logPath"];//READING THE LOGPATH.TXT

                using (StreamWriter writer = new StreamWriter(logPath, true))//USING TO STORE THE VALUE
                {
                    writer.WriteLine(v);//WRITING IN THE TXT
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
    }    
}

/*for (int top = 0; top < 160; top++)
                    {
                        pong.SetBBScaledPixel(top, 0, wall);
                    }
                    for (int side = 0; side < 120; side++)
                    {
                        pong.SetBBScaledPixel(159, side, wall);
                    }
                    for (int bottom = 0; bottom < 160; bottom++)
                    {
                        pong.SetBBScaledPixel(bottom, 119, wall);
                    } */