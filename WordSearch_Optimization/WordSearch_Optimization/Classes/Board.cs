using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch_Optimization.Classes
{
    class Board
    {
        /// <summary>
        /// This class represents the board over which a word-search puzzle exists.
        /// </summary>        
        public char[,] Matrix;
        int m, n;

        public Board(int M, int N)
        {
            /// <param name="M">Represents the Y dimension of the board</param>
            /// <param name="N">Represents the X dimension of the board</param>
            m = M;
            n = N;
            Matrix = new char[M, N];             
        }

        public List<string> Horizontal()
        {
            ///<summary>
            /// Returns a list of M size of all the horizontal lines of size N in the matrix 
            ///</summary>            
            List<string> output = new List<string>();
            for(int y = 0; y < m; y++)
            {
                string tmp = ""; 
                for(int x = 0; x < n; x++)
                {
                    tmp += Matrix[y, x]; 
                }
                output.Add(tmp);
            }

            return output; 
        }

        public List<string> Vertical()
        {
            ///<summary>
            /// Returns a list of N size of all the vertical lines of size M in the matrix 
            ///</summary>            
            List<string> output = new List<string>();
            for (int x = 0; x < n; x++)
            {
                string tmp = "";
                for (int y = 0; y < m; y++)
                {
                    tmp += Matrix[y, x];
                }
                output.Add(tmp);
            }
            return output;
        }

        public List<string> DiagonalLeft()
        {
            /// <summary>
            /// Returns a list of M+N-1 size of all the diagonal lines to the left.
            /// But it only takes an M+1 time as it grabs oposite poles in a single iteration
            /// /// by determining a polar oposite as M[x,y] as M[y,x]
            /// </summary>
            List<string> output = new List<string>();
            if (m == n)
            {
                for (int y = m - 1, x = 0; y >=0 ; y--)
                {
                    string tmp = "";
                    string flipTmp = "";
                    for (int _y = y, _x = x; _y < m && _x < n; _x++, _y++)
                    {
                        tmp += Matrix[_y, _x];
                        if(y>0) flipTmp += Matrix[_x, _y]; // Prevents duplication of [0,0]
                    }
                    output.Add(tmp);
                    if (y > 0) output.Add(flipTmp);
                }

            }
            else
            {
                for (int y = m - 1, x = 0; !(x == n && y == 0);)
                {
                    string tmp = "";
                    for (int _y = y, _x = x; _y < m && _x < n; _x++, _y++)
                    {
                        tmp += Matrix[_y, _x];
                    }
                    output.Add(tmp);
                    if (y > 0) y--; // Takes Y down to 0                
                    else x++;       // Then takes X up to N
                }
            }
            return output;
        }

        public List<string> DiagonalRight()
        {
            /// <summary>
            /// Returns a list of M+N-1 size of all the diagonal lines to the right.
            /// Where M=N it only takes an M+1 time as it grabs oposite poles in a single iteration
            /// by determining a polar oposite as M[x,y] as M[m-y,m-x]
            /// </summary>
            List<string> output = new List<string>();
            if (m == n)
            {
                for (int y = 0, x = 0; y < m; y++)
                {
                    string tmp = "";
                    string flipTmp = "";
                    for (int _y = y, _x = x; _y >= 0 && _x < n; _x++, _y--)
                    {
                        tmp += Matrix[_y, _x];
                        if (y < m-1) flipTmp += Matrix[m-1-_x, m-1-_y]; // Prevents duplication of [0,0]
                    }
                    output.Add(tmp);
                    if (y < m-1) output.Add(flipTmp);
                }
            }
            else
            {
                for (int y = 0, x = 0; x < n;)
                {
                    string tmp = "";
                    for (int _y = y, _x = x; _y >= 0 && _x < n; _x++, _y--)
                    {
                        tmp += Matrix[_y, _x];
                    }
                    output.Add(tmp);
                    if (y < m - 1) y++; // Takes Y up to  M-1               
                    else x++;           // Then takes X up to N
                }
            }
            return output;
        }

    }
}
