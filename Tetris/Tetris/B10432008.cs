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
    public partial class B10432008 : TetrisView //Form
    {
        Graphics graphics;
        TetrisController controller;
        //TetrisModel model;
        // Create pen.
        Pen blackPen = new Pen(Color.Black, 3);
        Pen redPen = new Pen(Color.Red, 3);                 //  Line_shape
        Pen orangePen = new Pen(Color.Orange, 3);           //  Square_shape
        Pen yellowPen = new Pen(Color.YellowGreen, 3);      //  N-shape
        Pen greenPen = new Pen(Color.Green, 3);             //  MirrorN_shape
        Pen bluePen = new Pen(Color.Blue, 3);               //  L_shape
        Pen indigoPen = new Pen(Color.Indigo, 3);           //  MirrorL_shape 
        Pen purplePen = new Pen(Color.Purple, 3);           //  T-shape       

        SolidBrush redBrush = new SolidBrush(Color.LightPink);                 //  Line_shape
        SolidBrush orangeBrush = new SolidBrush(Color.Yellow);           //  Square_shape
        SolidBrush yellowBrush = new SolidBrush(Color.Lime);      //  N-shape
        SolidBrush greenBrush = new SolidBrush(Color.LightGreen);             //  MirrorN_shape
        SolidBrush blueBrush = new SolidBrush(Color.LightBlue);               //  L_shape
        SolidBrush indigoBrush = new SolidBrush(Color.LightSkyBlue);           //  MirrorL_shape
        SolidBrush purpleBrush = new SolidBrush(Color.Plum);           //  T-shape      
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        //for double buffer
        private BufferedGraphicsContext m_CurrentContext;
        private BufferedGraphics m_Graphics;

        private const int blockSize = 17;
        private const int frame_x = 200;
        private const int frame_y = 20;
        private const int frame_width = (int)constant.BOARD_WIDTH * blockSize;
        private const int frame_height = (int)constant.BOARD_HEIGHT * blockSize;

        public B10432008(TetrisController controller)
        {
            InitializeComponent();

            //get畫布
            graphics = this.CreateGraphics();

            //塗白底
            graphics.Clear(Color.WhiteSmoke);

            //double buffer
            m_CurrentContext = BufferedGraphicsManager.Current;
            m_Graphics = m_CurrentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            drawBackGround();
            this.controller = controller;
            //this.model = model;
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
            m_Graphics.Graphics.Clear(Color.WhiteSmoke);
            drawBackGround();
            m_Graphics.Render();
        }

        private void strat_Click(object sender, EventArgs e)
        {
            Game.Visible = false;
            Over.Visible = false;
            controller.start();
        }

        public void drawBackGround()
        {
            // Create points that define line.
            m_Graphics.Graphics.DrawLine(blackPen, frame_x - 2, frame_y - 2, frame_x + frame_width + 2, frame_y - 2);
            m_Graphics.Graphics.DrawLine(blackPen, frame_x + frame_width + 2, frame_y - 2, frame_x + frame_width + 2, frame_y + frame_height + 2);
            m_Graphics.Graphics.DrawLine(blackPen, frame_x + frame_width + 2, frame_y + frame_height + 2, frame_x - 2, frame_y + frame_height + 2);
            m_Graphics.Graphics.DrawLine(blackPen, frame_x - 2, frame_y + frame_height + 2, frame_x - 2, frame_y - 2);
        }

        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {

            controller.keyPress(e.KeyCode.ToString());
        }

        public void drawBlock(Pen pen, int i, int j)
        {
            i = i * blockSize + frame_y;
            j = j * blockSize + frame_x;
            m_Graphics.Graphics.DrawEllipse(pen, j, i, blockSize, blockSize);
        }

        public Pen choosePenColor(int shape)
        {
            if (shape == 1) return redPen;
            else if (shape == 2) return orangePen;
            else if (shape == 3) return yellowPen;
            else if (shape == 4) return greenPen;
            else if (shape == 5) return bluePen;
            else if (shape == 6) return indigoPen;
            else if (shape == 7) return purplePen;
            else return blackPen;
        }

        public void drawPredictBlock(SolidBrush brush, int i, int j)
        {
            i = i * blockSize + frame_y;
            j = j * blockSize + frame_x;
            m_Graphics.Graphics.FillEllipse(brush, j, i, blockSize, blockSize);
        }

        public SolidBrush chooseBrushColor(int shape)
        {
            if (shape == 1) return redBrush;
            else if (shape == 2) return orangeBrush;
            else if (shape == 3) return yellowBrush;
            else if (shape == 4) return greenBrush;
            else if (shape == 5) return blueBrush;
            else if (shape == 6) return indigoBrush;
            else if (shape == 7) return purpleBrush;
            else return blackBrush;
        }

        public void GameOver()
        {
            Game.Visible = true;
            Over.Visible = true;

        }

        public override void changeView(TetrisModel model)
        //public void changeView(TetrisModel model)
        {
            if (!model.GameOver())
            {
                m_Graphics.Graphics.Clear(Color.WhiteSmoke);
                drawBackGround();
                bool[,] board = model.getBoard();
                TetrisBlock current_block = model.getBlock();

                //draw bottom blocks
                for (int i = 0; i < (int)constant.BOARD_HEIGHT; i++)
                {
                    for (int j = 0; j < (int)constant.BOARD_WIDTH; j++)
                    {
                        if (board[i, j])
                        {
                            drawBlock(blackPen, i, j);
                        }
                    }
                }


                int shape = (int)current_block.getBlockShape();

                //draw predict blocks
                //find distance from falling block to exist blocks
                SolidBrush blockBrush = chooseBrushColor(shape);
                int fallingHeight = -1;
                bool findHeight = false;
                while (!findHeight)
                {
                    fallingHeight++;
                    for (int i = 0; i < 4; i++)
                    {
                        if (current_block.get_CurrentX() + current_block.get_X(i) + fallingHeight < (int)constant.BOARD_HEIGHT)
                        {
                            if (board[current_block.get_CurrentX() + current_block.get_X(i) + fallingHeight, current_block.get_CurrentY() + current_block.get_Y(i)])
                            {
                                findHeight = true;
                                if (fallingHeight != 0) fallingHeight--;
                                break;
                            }
                        }
                        else
                        {
                            findHeight = true;
                            if (fallingHeight != 0) fallingHeight--;
                            break;
                        }
                    }
                }
                //draw
                for (int i = 0; i < 4; i++)
                {
                    drawPredictBlock(blockBrush, current_block.get_CurrentX() + current_block.get_X(i) + fallingHeight, current_block.get_CurrentY() + current_block.get_Y(i));
                }

                //draw falling blocks
                Pen blockPen = choosePenColor(shape);
                for (int i = 0; i < 4; i++)
                {
                    drawBlock(blockPen, current_block.get_CurrentX() + current_block.get_X(i), current_block.get_CurrentY() + current_block.get_Y(i));
                }
                m_Graphics.Render();
                //m_Graphics.Dispose();
                Score.Text = model.getScore().ToString();
            }
            else
            {
                GameOver();
            }
        }
    }

}
