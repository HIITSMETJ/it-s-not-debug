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

    public partial class B10432028 : TetrisView //TetrisView
    {
        int iTime = 0;
        public Timer sTimer = new Timer();
        Graphics graphics;
        TetrisController controller;
        // Create pen.
        Pen whitePen = new Pen(Color.White, 3);  //畫筆顏色_白 for 已落下的方塊
        Pen bleakPen = new Pen(Color.Black, 3);   //畫筆顏色_黑 for 落下中的方塊
        SolidBrush brush = new SolidBrush(Color.Gold);  //筆刷顏色_金 for 方塊內塗色

        //避免破圖 double buffer
        private BufferedGraphicsContext m_CurrentContext;
        private BufferedGraphics m_Graphics;

        public B10432028(TetrisController controller)
        {
            sTimer.Tick += new EventHandler(sTimer_Tick);
            InitializeComponent();

            //建立畫布
            graphics = this.CreateGraphics();

            //畫布塗白底
            graphics.Clear(Color.White);

            //double buffer
            m_CurrentContext = BufferedGraphicsManager.Current;
            m_Graphics = m_CurrentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            drawBackGround();
            this.controller = controller;
        }
        //for double buffer
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
        }


        private void strat_Click(object sender, EventArgs e)
        {
            controller.start();

            //sTimer.Stop();
            LbTime.Text = iTime.ToString();
            sTimer.Interval = 1000;
            sTimer.Enabled = true;
            sTimer.Start();
        }
        private void sTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            iTime++;
            LbTime.Text = iTime.ToString();
        }


        public void drawBackGround()                //畫框線(game space)
        {
            m_Graphics.Graphics.DrawLine(whitePen, 30, 20, 200, 20);  //上
            m_Graphics.Graphics.DrawLine(whitePen, 200, 20, 200, 394);  //右
            m_Graphics.Graphics.DrawLine(whitePen, 200, 394, 30, 394);  //下
            m_Graphics.Graphics.DrawLine(whitePen, 30, 394, 30, 20);  //左
        }

        private void Form1_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            controller.keyPress(e.KeyCode.ToString());
        }

        //畫方塊
        public void drawBlock(Pen pen, int i, int j)
        {
            i = i * 17 + 20;
            j = j * 17 + 30;
            m_Graphics.Graphics.FillRectangle(brush, j, i, 17, 17);   //畫實心方塊
            m_Graphics.Graphics.DrawRectangle(pen, j, i, 17, 17);   //畫方塊框線
        }

        //public override void changeView(TetrisModel model) 多型覆蓋
        public override void changeView(TetrisModel model)
        {
            m_Graphics.Graphics.Clear(Color.Black);
            drawBackGround();
            bool[,] board = model.getBoard();
            TetrisBlock current_block = model.getBlock();


            //取得 GameOver 狀態，並決定是否顯示文字
            if (model.GameOver())
            {
                LbGO.Visible = true;
                LbGO2.Visible = true;
                iTime = 0;
                sTimer.Enabled = false;
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
                        drawBlock(whitePen, i, j);
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                drawBlock(bleakPen, current_block.get_CurrentX() + current_block.get_X(i), current_block.get_CurrentY() + current_block.get_Y(i));

            }
            m_Graphics.Render();
            Score.Text = "Score: " + model.getScore().ToString();
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