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
    public partial class b10432008 : TetrisView
    {
        Graphics graphics;
        TetrisController controller;
        // Create pen.
        Pen blackPen = new Pen(Color.Black, 3);
        Pen redPen = new Pen(Color.Red, 3);
        SolidBrush brush = new SolidBrush(Color.Yellow);

        //for double buffer
        private BufferedGraphicsContext m_CurrentContext;
        private BufferedGraphics m_Graphics;

        public b10432008(TetrisController controller)
        {
            InitializeComponent();

            //get畫布
            graphics = this.CreateGraphics();

            //塗白底
            graphics.Clear(Color.White);

            //double buffer
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


        private void strat_Click(object sender, EventArgs e)
        {
            controller.start();
        }

        public void drawBackGround()
        {
            // Create points that define line.
            m_Graphics.Graphics.DrawLine(blackPen, 170, 20, 340, 20);
            m_Graphics.Graphics.DrawLine(blackPen, 340, 20, 340, 394);
            m_Graphics.Graphics.DrawLine(blackPen, 340, 394, 170, 394);
            m_Graphics.Graphics.DrawLine(blackPen, 170, 394, 170, 20);
        }

        private void Form1_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            controller.keyPress(e.KeyCode.ToString());
        }

        public void drawBlock(Pen pen, int i, int j)
        {
            i = i * 17 + 20;
            j = j * 17 + 170;
            m_Graphics.Graphics.DrawEllipse(pen, j, i, 17, 17);
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
                        drawBlock(blackPen, i, j);
                    }
                }
            }

            for (int i = 0; i < 4; i++) 
            {
                drawBlock(redPen, current_block.get_CurrentX() + current_block.get_X(i), current_block.get_CurrentY() + current_block.get_Y(i));

            }
            m_Graphics.Render();
            //m_Graphics.Dispose();
            Score.Text = "Score: " + model.getScore().ToString();
        }
    }

}
