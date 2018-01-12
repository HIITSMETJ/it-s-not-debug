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
    //public class TetrisView : Form
    //{
    //    public virtual void changeView(TetrisModel model) { }
    //}




    public partial class B10432028 : TetrisView //TetrisView
    {
        Graphics graphics;
        TetrisController controller;
        // Create pen.
        Pen blackPen = new Pen(Color.White, 3);  //畫筆顏色
        Pen redPen = new Pen(Color.Black, 3);    //落下方塊顏色
        SolidBrush brush = new SolidBrush(Color.Gold);  //??

        //for double buffer
        private BufferedGraphicsContext m_CurrentContext;
        private BufferedGraphics m_Graphics;

        public B10432028(TetrisController controller)
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
            graphics.Clear(Color.Black);  //起始背景色
            drawBackGround();
            //drawBlock(170, 20);

        }


        private void strat_Click(object sender, EventArgs e)
        {
            controller.start();
        }

        public void drawBackGround()                //畫框線
        {
            // Create points that define line.
            m_Graphics.Graphics.DrawLine(blackPen, 30, 20, 200, 20);  //上
            m_Graphics.Graphics.DrawLine(blackPen, 200, 20, 200, 394);  //右
            m_Graphics.Graphics.DrawLine(blackPen, 200, 394, 30, 394);  //下
            m_Graphics.Graphics.DrawLine(blackPen, 30, 394, 30, 20);  //左
        }

        private void Form1_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            controller.keyPress(e.KeyCode.ToString());
        }

        public void drawBlock(Pen pen, int i, int j)   //??
        {
            i = i * 17 + 20;
            j = j * 17 + 30;
            m_Graphics.Graphics.FillRectangle(brush, j, i, 17, 17);   //畫方塊
            m_Graphics.Graphics.DrawRectangle(pen, j, i, 17, 17);   //畫方塊
        }

        //public override void changeView(TetrisModel model) 多型覆蓋
        public override void changeView(TetrisModel model)
        {
            m_Graphics.Graphics.Clear(Color.Black);   //背景這也要改
            drawBackGround();
            bool[,] board = model.getBoard();
            TetrisBlock current_block = model.getBlock();
            
            if (model.GameOver())
            {
                LbGO.Visible = true;
                LbGO2.Visible = true;
            }
            else
            {
                LbGO.Visible = false;
                LbGO2.Visible = false;
            }

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // B10432028
        //    // 
        //    this.ClientSize = new System.Drawing.Size(282, 253);
        //    this.Name = "B10432028";
        //    //this.Load += new System.EventHandler(this.B10432028_Load);
        //    this.ResumeLayout(false);

        //}


    }

}

