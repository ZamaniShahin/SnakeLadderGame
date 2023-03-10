using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeLadderGame
{


    public partial class Main : Form
    {


        SqlConnection con = new SqlConnection();
        private string connectionString = @"Data Source=.;Initial Catalog=MyPC;Integrated Security=true";
        public Main()
        {

            InitializeComponent();
        }
        bool isBeaver = false, isBird = false, isWalrus = false, isLadybug = false;
        int xBeaver = 0, xBird = 0, xWalrus = 0, xLadybug = 0;//location
        int yBeaver = 467, yBird = 467, yWalrus = 467, yLadybug = 467;//location
        int diceValue;

        int[] position = new int[102];
        int pBeaver = 1, pBird = 1, pWalrus = 1, pLadybug = 1;

        bool isLeftToRight = true;
        int num;
        int flag = 0;

        private void lblNextRound_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pLadybug == 101 || pBeaver == 101 || pBird == 101 || pWalrus == 101)
            {


                isBeaver = false;
                isBird = false;
                isWalrus = false;
                isLadybug = false;

                xBeaver = 0;
                xBird = 0;
                xWalrus = 0;
                xLadybug = 0;

                yBeaver = 467;
                yBird = 467;
                yWalrus = 467;
                yLadybug = 467;

                isLeftToRight = true;

                pBeaver = 1;
                pBird = 1;
                pWalrus = 1;
                pLadybug = 1;

                flag = 1;
                btnRoll.BackColor = Color.Red;

                picboxPlayer1.Visible = true;
                picboxPlayer2.Visible = true;
                picboxPlayer3.Visible = true;
                picboxPlayer4.Visible = true;

                picboxBeaver.Visible = false;
                picboxBird.Visible = false;
                picboxWalrus.Visible = false;
                picboxLadybug.Visible = false;

                btnRoll.Enabled = true;

                picboxDice.Image = Image.FromFile("roll.jpg");
            }

            else
            {
                MessageBox.Show("Please Finish The Game");
            }
        }



        private void lblExit_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult quit = MessageBox.Show("Are you sure?", "Waining!", MessageBoxButtons.YesNo);
            if (quit == DialogResult.Yes)
                Application.Exit();
        }

        private void lblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isBeaver = false;
            isBird = false;
            isWalrus = false;
            isLadybug = false;

            xBeaver = 0;
            xBird = 0;
            xWalrus = 0;
            xLadybug = 0;

            yBeaver = 467;
            yBird = 467;
            yWalrus = 467;
            yLadybug = 467;

            isLeftToRight = true;

            pBeaver = 1;
            pBird = 1;
            pWalrus = 1;
            pLadybug = 1;

            flag = 1;
            btnRoll.BackColor = Color.Red;

            picboxPlayer1.Visible = true;
            picboxPlayer2.Visible = true;
            picboxPlayer3.Visible = true;
            picboxPlayer4.Visible = true;

            picboxBeaver.Visible = false;
            picboxBird.Visible = false;
            picboxWalrus.Visible = false;
            picboxLadybug.Visible = false;

            picboxDice.Image = Image.FromFile("roll.jpg");

            labelRed.Text = "0";
            labelBlue.Text = "0";
            labelOrange.Text = "0";
            labelBrown.Text = "0";

            btnRoll.Enabled = true;


            UpdateScores(labelRed.Text, 1);
            UpdateScores(labelBlue.Text, 2);
            UpdateScores(labelOrange.Text, 3);
            UpdateScores(labelBrown.Text, 4);

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dtRed = DisplayScores(1);
            labelRed.Text = dtRed.Rows[0][2].ToString();

            DataTable dtBlue = DisplayScores(2);
            labelBlue.Text = dtBlue.Rows[0][2].ToString();

            DataTable dtOrange = DisplayScores(3);
            labelOrange.Text = dtOrange.Rows[0][2].ToString();

            DataTable dtBrown = DisplayScores(4);
            labelBrown.Text = dtBrown.Rows[0][2].ToString();



            picboxGifDice.Hide();

            labelDice.Visible = false;
            labelDiceResult.Visible = false;
            labelPResults.Visible = true;
            labelX.Visible = false;
            labelY.Visible = false;
            labelXResult.Visible = false;
            lableYResult.Visible = false;
            labelP.Visible = false;
            labelPResults.Visible = false;



            //Hiding player before getting 6
            picboxBeaver.Visible = false;
            picboxBird.Visible = false;
            picboxWalrus.Visible = false;
            picboxLadybug.Visible = false;

            //Showing picture of dice
            picboxDice.Image = Image.FromFile("roll.jpg");

            picboxDice.SizeMode = PictureBoxSizeMode.StretchImage;


        }


        private void timerDice_Thick(object sender, EventArgs e)//****************RedTimer**************//
        {
            picboxDice.Image = Image.FromFile(num + ".jpg");

            btnRoll.Enabled = true;
            timerDice.Stop();

            switch (flag)
            {
                //Ladybug
                case 1:
                    {

                        // DisplayScores(labelRed, 1);

                        //move player
                        if (isLadybug == true)
                        {
                            Logics.MovePlayer(ref xLadybug, ref yLadybug, ref pLadybug, diceValue
                                , ref position, picboxLadybug, labelPResults, ref isLeftToRight);
                        }

                        //win message
                        FinishGame("Ladybug", ref labelRed);
                        UpdateScores(labelRed.Text, 1);


                        //encounter of players
                        if (pLadybug == pBeaver)
                        {
                            isBeaver = false;
                            pBeaver = 1;
                            picboxBeaver.Visible = false;
                            picboxPlayer4.Visible = true;
                            xBeaver = 11;
                            yBeaver = 485;
                        }
                        else if (pLadybug == pBird)
                        {
                            isBird = false;
                            pBird = 1;
                            picboxBird.Visible = false;
                            picboxPlayer2.Visible = true;
                            xBird = 11;
                            yBird = 485;
                        }
                        else if (pLadybug == pWalrus)
                        {
                            isWalrus = false;
                            pWalrus = 1;
                            picboxWalrus.Visible = false;
                            picboxPlayer3.Visible = true;
                            xWalrus = 11;
                            yWalrus = 485;
                        }

                        // switch players
                        if (diceValue != 6)
                        {

                            btnRoll.BackColor = Color.Blue;
                            flag = 2;

                        }

                        break;

                    }

                //bird
                case 2:
                    {

                        //DisplayScores(labelBlue, 2);

                        //move player
                        if (isBird == true)
                        {
                            Logics.MovePlayer(ref xBird, ref yBird, ref pBird, diceValue, ref position,
                                picboxBird, labelPResults, ref isLeftToRight);
                        }

                        //win message
                        FinishGame("Bird", ref labelBlue);
                        UpdateScores(labelBlue.Text.ToString(), 2);

                        //encounter of players
                        if (pBird == pBeaver)
                        {
                            isBeaver = false;
                            pBeaver = 1;
                            picboxBeaver.Visible = false;
                            picboxPlayer4.Visible = true;
                            xBeaver = 11;
                            yBeaver = 485;
                        }
                        else if (pBird == pLadybug)
                        {
                            isLadybug = false;
                            pLadybug = 1;
                            picboxLadybug.Visible = false;
                            picboxPlayer1.Visible = true;
                            xLadybug = 11;
                            yLadybug = 485;
                        }
                        else if (pBird == pWalrus)
                        {
                            isWalrus = false;
                            pWalrus = 1;
                            picboxWalrus.Visible = false;
                            picboxPlayer3.Visible = true;
                            xWalrus = 11;
                            yWalrus = 485;
                        }

                        // switch players
                        if (diceValue != 6)
                        {

                            btnRoll.BackColor = Color.Orange;
                            flag = 3;


                        }

                        break;
                    }
                //walrus
                case 3:
                    {

                        // DisplayScores(labelOrange, 3);
                        //move player
                        if (isWalrus == true)
                        {
                            Logics.MovePlayer(ref xWalrus, ref yWalrus, ref pWalrus, diceValue
                                , ref position, picboxWalrus, labelPResults, ref isLeftToRight);
                        }

                        //win message
                        FinishGame("Bird", ref labelOrange);
                        UpdateScores(labelOrange.Text.ToString(), 3);


                        //encounter of players
                        if (pWalrus == pBeaver)
                        {
                            isBeaver = false;
                            pBeaver = 1;
                            picboxBeaver.Visible = false;
                            picboxPlayer4.Visible = true;
                            xBeaver = 11;
                            yBeaver = 485;
                        }
                        else if (pWalrus == pLadybug)
                        {
                            isLadybug = false;
                            pLadybug = 1;
                            picboxLadybug.Visible = false;
                            picboxPlayer1.Visible = true;
                            xLadybug = 11;
                            yLadybug = 485;
                        }
                        else if (pWalrus == pBird)
                        {
                            isBird = false;
                            pWalrus = 1;
                            picboxWalrus.Visible = false;
                            picboxPlayer2.Visible = true;
                            xBird = 11;
                            yBird = 485;
                        }

                        // switch players
                        if (diceValue != 6)
                        {
                            btnRoll.BackColor = Color.Brown;
                            flag = 4;
                        }

                        break;
                    }


                //Beaver
                case 4:
                    {

                        // DisplayScores(labelBrown, 4);
                        //move player
                        if (isBeaver == true)
                        {
                            Logics.MovePlayer(ref xBeaver, ref yBeaver, ref pBeaver, diceValue
                                , ref position, picboxBeaver, labelPResults, ref isLeftToRight);
                        }

                        //win message
                        FinishGame("Bird", ref labelBrown);
                        UpdateScores(labelBrown.Text.ToString(), 4);


                        //encounter of players
                        if (pBeaver == pBird)
                        {
                            isBird = false;
                            pBird = 1;
                            picboxBird.Visible = false;
                            picboxPlayer2.Visible = true;
                            xBird = 11;
                            yBird = 485;
                        }
                        else if (pBeaver == pLadybug)
                        {
                            isLadybug = false;
                            pLadybug = 1;
                            picboxLadybug.Visible = false;
                            picboxPlayer1.Visible = true;
                            xLadybug = 11;
                            yLadybug = 485;
                        }
                        else if (pBeaver == pWalrus)
                        {
                            isWalrus = false;
                            pWalrus = 1;
                            picboxWalrus.Visible = false;
                            picboxPlayer3.Visible = true;
                            xWalrus = 11;
                            yWalrus = 485;
                        }
                        // switch players
                        if (diceValue != 6)
                        {
                            btnRoll.BackColor = Color.Red;
                            flag = 1;
                        }

                        break;
                    }
            }
        }

        private void btnDice_Click(object sender, EventArgs e)//*******************Red*******************//
        {


            if (flag == 0)
                flag = 1;

            switch (flag)
            {

                case 1:
                    {


                        timerDice.Start();
                        btnRoll.Enabled = false;
                        picboxDice.Image = Image.FromFile("DiceGif.gif");

                        diceValue = Logics.RollDice(ref num);

                        //Starting Blue Player 
                        if (labelDiceResult.Text == "6" && isLadybug == false)
                        {
                            picboxLadybug.Visible = true;
                            picboxPlayer1.Visible = false;
                            isLadybug = true;

                            picboxLadybug.Location = new Point(xBird, yBird);

                            labelPResults.Text = pLadybug.ToString();
                            pLadybug++;
                            position[pLadybug] = 1;
                        }
                        //showing result in lable
                        labelDiceResult.Text = diceValue.ToString();


                        break;
                    }

                //bird
                case 2:
                    {


                        timerDice.Start();
                        btnRoll.Enabled = false;
                        picboxDice.Image = Image.FromFile("DiceGif.gif");

                        diceValue = Logics.RollDice(ref num);

                        //Starting Blue Player 
                        if (labelDiceResult.Text == "6" && isBird == false)
                        {
                            picboxBird.Visible = true;
                            picboxPlayer2.Visible = false;
                            isBird = true;

                            picboxBird.Location = new Point(xBird, yBird);

                            labelPResults.Text = pBird.ToString();
                            pBird++;
                            position[pBird] = 1;
                        }
                        //showing result in lable
                        labelDiceResult.Text = diceValue.ToString();


                        break;
                    }
                //walrus
                case 3:
                    {


                        timerDice.Start();
                        btnRoll.Enabled = false;
                        picboxDice.Image = Image.FromFile("DiceGif.gif");

                        diceValue = Logics.RollDice(ref num);

                        //Starting Blue Player 
                        if (labelDiceResult.Text == "6" && isWalrus == false)
                        {
                            picboxWalrus.Visible = true;
                            picboxPlayer3.Visible = false;
                            isWalrus = true;

                            picboxWalrus.Location = new Point(xWalrus, yWalrus);

                            labelPResults.Text = pWalrus.ToString();
                            pWalrus++;
                            position[pWalrus] = 1;
                        }
                        //showing result in lable
                        labelDiceResult.Text = diceValue.ToString();


                        break;
                    }
                //beaver
                case 4:
                    {
                        timerDice.Start();
                        btnRoll.Enabled = false;
                        picboxDice.Image = Image.FromFile("DiceGif.gif");

                        diceValue = Logics.RollDice(ref num);

                        //Starting Blue Player 
                        if (labelDiceResult.Text == "6" && isBeaver == false)
                        {
                            picboxBeaver.Visible = true;
                            picboxPlayer4.Visible = false;
                            isBeaver = true;

                            picboxBeaver.Location = new Point(xBeaver, yBeaver);

                            labelPResults.Text = pBeaver.ToString();
                            pBeaver++;
                            position[pBeaver] = 1;
                        }
                        //showing result in lable
                        labelDiceResult.Text = diceValue.ToString();


                        break;
                    }
            }

        }


        void FinishGame(string str, ref Label label)
        {
            int num;
            string tmp;
            if (pBeaver == 101 || pBird == 101 || pWalrus == 101 || pLadybug == 101)
            {
                MessageBox.Show(Owner, str + " wins", "Congratulations!", MessageBoxButtons.OK);
                btnRoll.Enabled = false;
                tmp = label.Text;
                num = Convert.ToInt32(tmp);
                num++;
                label.Text = num.ToString();

            }
        }


        void UpdateScores(string score, int ID)
        {
            int num;

            num = Convert.ToInt32(score);
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Update SnakeAndLadder Set PlayerScore=@PlayerScore Where PlayerID=@PlayerID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("PlayerID", ID);
            cmd.Parameters.AddWithValue("PlayerScore", num);
            connection.Open();
            cmd.ExecuteNonQuery();

            connection.Close();



        }


        DataTable DisplayScores(int ID)
        {
            string query = "Select * From SnakeAndLadder where PlayerID=" + ID;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }


    }


}








