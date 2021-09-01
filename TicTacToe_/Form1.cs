using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_
{
    public partial class TicTacToe : Form
    {
        //true = X; False = O
        bool turn = true; 
        string winner = "";
        int turn_count = 0;

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By John. My second application on Microsoft .Net with support from Chris Merritt's channel.", "TicTacToe About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearButtons();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
                if (winner == "O")
                    b.Text = "O";
            }
                
            else
            {
                b.Text = "O";
                if (turn_count >= 1 && winner == "O")
                    b.Text = "X";
            }               

            turn_count++;
            turn = !turn;
            b.Enabled = false;

            checkWinner();
        }
        
        private void checkWinner()
        {
            bool isWinner = false;

            // Horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                isWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                isWinner = true;
            
            // Vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                isWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                isWinner = true;

            // Diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                isWinner = true;

            if (isWinner)
            {
                if (winner != "O")
                    if (turn)
                        winner = "O";
                    else
                        winner = "X";
                else
                    if (turn)
                        winner = "X";
                    else
                        winner = "O";

                MessageBox.Show($"{winner} ganhou!");
                clearButtons();
            }
            else
            {
                if (turn_count == 9)
                {
                    MessageBox.Show("Velha!");
                    clearButtons();
                }
                    
            }
        }

        private void clearButtons()
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }

        private void buttonEnter(object sender, EventArgs e)
        {

        }

        private void buttonLeave(object sender, EventArgs e)
        {

        }
    }
}
