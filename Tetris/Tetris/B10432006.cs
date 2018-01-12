using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Project
{
    //public class TetrisView : Form
    //{
    //    public virtual void changeView(TetrisModel model) { }
    //}
    public class TetrisView : Form
    {
        public virtual void changeView(TetrisModel model) { }
    }

    public partial class B10432006 : TetrisView
    {
        Graphics graphics;
        TetrisController controller;
        // Create pen.
        Pen board_Pen = new Pen(Color.DarkBlue, 3);
        Pen current_Pen = new Pen(Color.BlanchedAlmond, 3);
        Pen preview_Pen = new Pen(Color.LightSteelBlue, 3);
        SolidBrush board_brush = new SolidBrush(Color.DarkBlue);
        SolidBrush current_brush = new SolidBrush(Color.BlanchedAlmond);
        SolidBrush preview_brush = new SolidBrush(Color.LightSteelBlue);
        //for double buffer
        private BufferedGraphicsContext m_CurrentContext;
        private BufferedGraphics m_Graphics;

        TetrisModel mymodel;

        public B10432006(TetrisController controller)
        {
            InitializeComponent();

            //get畫布
            graphics = this.CreateGraphics();

            //塗白底
            graphics.Clear(Color.SkyBlue);

            //double buffer
            m_CurrentContext = BufferedGraphicsManager.Current;
            m_Graphics = m_CurrentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            drawBackGround();
            this.controller = controller;

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            controller.start();
        }

        private void scoreBox_TextChanged(object sender, EventArgs e)
        {

        }


        public void drawBackGround()
        {
            // Create points that define line.
            m_Graphics.Graphics.DrawLine(board_Pen, 100, 70, 270, 70);
            m_Graphics.Graphics.DrawLine(board_Pen, 270, 70, 270, 464);
            m_Graphics.Graphics.DrawLine(board_Pen, 270, 464, 100, 464);
            m_Graphics.Graphics.DrawLine(board_Pen, 100, 464, 100, 70);
        }

        private void B10432006_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            controller.keyPress(e.KeyCode.ToString());
        }

        public void drawBlock(Pen pen, SolidBrush brush, int i, int j)
        {
            i = i * 17 + 90;
            j = j * 17 + 100;
            m_Graphics.Graphics.FillRectangle(brush, new Rectangle(j, i, 17, 17));
        }

        //public override void changeView(TetrisModel model) 多型覆蓋
        public override void changeView(TetrisModel model)
        {
            m_Graphics.Graphics.Clear(Color.SkyBlue);
            drawBackGround();
            mymodel = model;
            bool[,] board = model.getBoard();
            TetrisBlock current_block = model.getBlock();

            if (current_block.getBlockShape() != TetrisBlock.Blocks.No_shape)
            {
                for (int i = 0; i < 22; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j])
                        {
                            drawBlock(board_Pen, board_brush, i, j);
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    drawBlock(current_Pen, current_brush, current_block.get_CurrentX() + current_block.get_X(i), current_block.get_CurrentY() + current_block.get_Y(i));
                   
                }

                m_Graphics.Render();
                //m_Graphics.Dispose();
                scoreBox.Text = model.getScore().ToString();
                   
            }

            if (mymodel.GameOver())
            {
                Gameover gameover_form = new Gameover();
                gameover_form.Show(this);
            }
        }
    }
}
