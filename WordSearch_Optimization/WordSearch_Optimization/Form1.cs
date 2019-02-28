using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSearch_Optimization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void TestRight(int m, int n)
        {
            // M = Y, N = X 
            //*/
            for (int y = 0, x = 0; x < n;)
            {
                string tmp = "";
                for (int _y = y, _x = x;  _y >= 0 && _x < n  ; _x++, _y-- )
                {
                    tmp += ($"[{_x}, {_y}]");
                }
                textBox1.Text += $"X={x},Y={y}\t{tmp}\r\n";
                if (y < m-1) y++; // Takes Y up to M               
                else x++;       // Then takes X up to N
            }
            textBox1.Text += "===================\r\n";
            for (int y = 0, x = 0; y < m; y++)
            {
                string tmp = "", r_tmp = "";
                for (int _y = y, _x = x; _y >= 0 && _x < n; _x++, _y--)
                {
                    tmp += ($"[{_x}, {_y}]");
                    if (y < m-1) r_tmp += ($"[{m-1-_y}, {m-1-_x}]");
                }
                textBox1.Text += $"X={x} Y={y}\t{tmp}\tX={m-1-y} Y={m-1-x}\t{r_tmp}\r\n";
            }
            //*/

        }

        void TestLeft(int m, int n)
        {
            //*
            for (int y = m - 1, x = 0; !(x == n && y == 0);)
            {
                string tmp = "";
                for (int _y = y, _x = x; _y < m && _x < n; _x++, _y++)
                {
                    tmp += ($"[{_x}, {_y}]");
                }
                textBox1.Text += $"X={x},Y={y}\t{tmp}\r\n";
                if (y > 0) y--; // Takes Y down to 0                
                else x++;       // Then takes X up to N
            }
            textBox1.Text += "===================\r\n";
            for (int y = m - 1, x = 0; y >= 0; y--)
            {
                string tmp = "", r_tmp = "";
                for (int _y = y, _x = x; _y < m && _x < n; _x++, _y++)
                {
                    tmp += ($"[{_x}, {_y}]");
                    if (y > 0) r_tmp += ($"[{_y}, {_x}]");
                }
                textBox1.Text += $"X={x} Y={y}\t{tmp}\tX={y} Y={x}\t{r_tmp}\r\n";
            }
            textBox1.Text += "===================\r\n";
            //*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int m = 3, n = 3;

            Classes.Board board = new Classes.Board(m, n);
            for (int y = 0; y < m; y++)
            {

                for (int x = 0; x < n; x++)
                {
                    board.Matrix[y, x] = Convert.ToChar('A' + ((y * n) + x));
                    textBox1.Text += board.Matrix[y, x];
                }
                textBox1.Text += "\r\n";
            }

            List<string> Horizontal = board.Horizontal();
            textBox1.Text += "Horizontal\r\n";
            foreach (string s in Horizontal) textBox1.Text += $"{s}\r\n";

            List<string> Vertical = board.Vertical(); 
            textBox1.Text += "Vertical\r\n";
            foreach (string s in Vertical) textBox1.Text += $"{s}\r\n";

            List<string> RDiagonal = board.DiagonalRight(); 
            textBox1.Text += "Right Diagonal\r\n";
            foreach (string s in RDiagonal) textBox1.Text += $"{s}\r\n";

            List<string> LDiagonal = board.DiagonalLeft(); 
            textBox1.Text += "Left Diagonal\r\n";
            foreach (string s in LDiagonal) textBox1.Text += $"{s}\r\n";


        }
    }
}
