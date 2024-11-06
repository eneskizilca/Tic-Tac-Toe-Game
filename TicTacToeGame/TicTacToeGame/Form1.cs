using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class Form1 : Form
    {
        bool turn = true; // true ise X, false ise O
        int turnCount = 0; // sira sayaci 
        bool there_is_a_winner = false; // kazanan var mi degiskeni
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (String.IsNullOrWhiteSpace(btn.Text)) // buton text'i bos degilse if'e gir
            {
                if (turn) // sira X'in ise kirmizi renkte X yaz
                {
                    btn.ForeColor = Color.Red;
                    btn.Text = "X";
                }
                else // sira O'nun ise lacivert renkte O yaz
                {
                    btn.ForeColor = Color.DarkBlue;
                    btn.Text = "O";
                }

                turn = !turn; //sirayi degistir
                turnCount++;
                checkWinner(); // kazanan var mı kontrolu yap
            }

        }

        private void checkWinner()
        {
            // ilk 3 sorgu yatay kontrol
            if (A1.Text == A2.Text && A2.Text == A3.Text && !(A1.Text == ""))
            {
                there_is_a_winner = true;
                A1.BackColor = Color.LightGreen; // 3'lu serinin zeminini yesil yap
                A2.BackColor = Color.LightGreen;
                A3.BackColor = Color.LightGreen;
            }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && !(B1.Text == ""))
            {
                there_is_a_winner = true;
                B1.BackColor = Color.LightGreen;
                B2.BackColor = Color.LightGreen;
                B3.BackColor = Color.LightGreen;
            }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && !(C1.Text == ""))
            {
                there_is_a_winner = true;
                C1.BackColor = Color.LightGreen;
                C2.BackColor = Color.LightGreen;
                C3.BackColor = Color.LightGreen;
            }
            //alttan itibaren 3 sorgu dikey kontrol
            else if (A1.Text == B1.Text && B1.Text == C1.Text && !(A1.Text == ""))
            {
                there_is_a_winner = true;
                A1.BackColor = Color.LightGreen;
                B1.BackColor = Color.LightGreen;
                C1.BackColor = Color.LightGreen;
            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && !(A2.Text == ""))
            {
                there_is_a_winner = true;
                A2.BackColor = Color.LightGreen;
                B2.BackColor = Color.LightGreen;
                C2.BackColor = Color.LightGreen;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && !(A3.Text == ""))
            {
                there_is_a_winner = true;
                A3.BackColor = Color.LightGreen;
                B3.BackColor = Color.LightGreen;
                C3.BackColor = Color.LightGreen;
            }
            // son 2 sorgu çapraz kontrol
            else if (A1.Text == B2.Text && B2.Text == C3.Text && !(A1.Text == ""))
            {
                there_is_a_winner = true;
                A1.BackColor = Color.LightGreen;
                B2.BackColor = Color.LightGreen;
                C3.BackColor = Color.LightGreen;
            }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && !(A3.Text == ""))
            {
                there_is_a_winner = true;
                A3.BackColor = Color.LightGreen;
                B2.BackColor = Color.LightGreen;
                C1.BackColor = Color.LightGreen;
            }

            if (there_is_a_winner) // kazanan varse
            {
                String winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show("Kazanan: " + winner);
                restartToolStripMenuItem.PerformClick(); // oyunu restartla
            }
            else
            {
                if (turnCount == 9) // tum kutular dolu ve kazanan yoksa berabere kal
                {
                    MessageBox.Show("Berabere!");
                    restartToolStripMenuItem.PerformClick();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // oyunu kapat
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // oyunu default ayarlara getir
            turn = true;
            turnCount = 0;
            there_is_a_winner = false;
            foreach (Control control in Controls)
            {
                try
                {
                    Button button = (Button)control;
                    button.BackColor = Color.White;
                    button.Text = "";
                }
                catch { }
            }
        }
    }
}
