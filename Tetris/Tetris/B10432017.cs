using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{

    public partial class B10432017 : TetrisView //TetrisView
    {

        Graphics graphics;
        TetrisController controller;

        Pen blackPen = new Pen(Color.Black, 3);
        Pen redPen = new Pen(Color.Red, 3);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush blackBrush = new SolidBrush(Color.Blue);
        SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);

        private BufferedGraphicsContext m_CurrentContext;
        private BufferedGraphics m_Graphics;

        public B10432017(TetrisController controller)
        {
            InitializeComponent();

            graphics = this.CreateGraphics();

            graphics.Clear(Color.White);

            m_CurrentContext = BufferedGraphicsManager.Current;
            m_Graphics = m_CurrentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            drawBackGround();
            this.controller = controller;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            drawBackGround();
            //drawBlock(170, 20);

        }


        private void strat(object sender, EventArgs e)
        {
            controller.start();
        }

        public void drawBackGround()
        {

            m_Graphics.Graphics.DrawRectangle(blackPen, 67, 20, 174, 374);

        }

        private void Form1_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            controller.keyPress(e.KeyCode.ToString());
        }

        public void drawBlock(SolidBrush brush, Pen pen, int i, int j)
        {
            i = i * 17 + 20;
            j = j * 17 + 70;
            m_Graphics.Graphics.DrawRectangle(pen, j, i, 15.5f, 15.5f);
            m_Graphics.Graphics.FillRectangle(brush, j, i, 15.5f, 15.5f);
        }

        //public override void changeView(TetrisModel model) 多型覆蓋
        public override void changeView(TetrisModel model)
        {
            m_Graphics.Graphics.Clear(Color.White);
            drawBackGround();
            bool[,] board = model.getBoard();
            TetrisBlock current_block = model.getBlock();

            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j])
                    {
                        drawBlock(blackBrush, blackPen, i, j);
                    }
                }
            }


            int depth = 0;
            bool add = true;
            while (add)
            {
                depth++;
                for (int i = 0; i < 4; i++)
                {
                    //System.Diagnostics.Debug.WriteLine(current_block.get_X(i) + depth);
                    int h = current_block.get_X(i) + depth;
                    if (h < 0) h = 0;
                    if (h > 21) h = 21;
                    if (board[h, current_block.get_CurrentY() + current_block.get_Y(i)])
                    {
                        add = false;
                    }
                }
                if (depth > 21) break;
            }

            for (int i = 0; i < 4; i++)
            {
                while (current_block.get_X(i) + depth > 22) depth--;

            }

            for (int i = 0; i < 4; i++)
            {
                if (!model.GameOver()) drawBlock(whiteBrush, redPen, current_block.get_X(i) + depth - 1, current_block.get_CurrentY() + current_block.get_Y(i));
                if (!model.GameOver()) drawBlock(yellowBrush, redPen, current_block.get_CurrentX() + current_block.get_X(i), current_block.get_CurrentY() + current_block.get_Y(i));
            }
            m_Graphics.Render();
            //m_Graphics.Dispose();
            score.Text = "Score: " + model.getScore().ToString();
        }
    }

}
