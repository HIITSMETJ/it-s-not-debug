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
    public partial class b10432016 : TetrisView// Form 
    {
        Graphics graphics;
        TetrisController controller;
        TetrisModel mymodel;
        // Create pen.
        Pen whitePen = new Pen(Color.WhiteSmoke,3);
        Pen blackPen = new Pen(Color.Black, 1);
        SolidBrush brush = new SolidBrush(Color.Aquamarine);
        SolidBrush cadeBluebrush = new SolidBrush(Color.CadetBlue);

        //for double buffer
        private BufferedGraphicsContext m_CurrentContext;
        private BufferedGraphics m_Graphics;

        public b10432016(TetrisController controller)
        {
            InitializeComponent();

            //get畫布
            graphics = this.CreateGraphics();

            //塗白底
            graphics.Clear(Color.White);

            //double buffer
            m_CurrentContext = BufferedGraphicsManager.Current;
            m_Graphics = m_CurrentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            DrawGameField();
            this.controller = controller;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void TetrisView_Load(object sender, EventArgs e)
        {

        }

        private void TetrisView_Shown(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            DrawGameField();
            
        }


        public void DrawGameField()
        {
            m_Graphics.Graphics.DrawLine(whitePen, 10,8, 184, 8);
            m_Graphics.Graphics.DrawLine(whitePen, 10, 8, 10, 384);
            m_Graphics.Graphics.DrawLine(whitePen, 10, 384, 184, 384);
            m_Graphics.Graphics.DrawLine(whitePen, 182, 384, 184, 8);
        }

        public void DrawBlock(SolidBrush brush, int i, int j)
        {
            i = i * 17 + 8;
            j = j * 17 + 12;
            m_Graphics.Graphics.FillRectangle(brush, j, i, 17, 17);
             
        }

        //public override void changeView(TetrisModel model) 多型覆蓋
        public override void  changeView(TetrisModel model)
        {
            mymodel = model;
            gg.Visible = false;
            m_Graphics.Graphics.Clear(Color.White);
            DrawGameField();
            bool[,] board = model.getBoard();
            TetrisBlock current_block = model.getBlock();

            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j])
                    {
                        DrawBlock(cadeBluebrush, i, j);                      
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                DrawBlock(brush, current_block.get_CurrentX() + current_block.get_X(i), current_block.get_CurrentY() + current_block.get_Y(i));
            }
            m_Graphics.Render();
            score.Text =model.getScore().ToString();
            
        }

        private void start_Click(object sender, EventArgs e)
        {
            controller.start();
            
        }

        private void TetrisView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mymodel.isStarted())
                gg.Visible = true;
            controller.keyPress(e.KeyCode.ToString());            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }

}
