using System;
using windows.h;
using conio.h;
using ctime;
using cmath;
using iostream;
using TetrisModel.cs;

public class TetrisController
{
	public TetrisController(TetrisModel* model, int board_width, int board_height)
	{

	}
    private TetrisModel* model = new TetrisModel();
    public start()
    {
       while(true)
        {  //讀取user透過鍵盤對方塊下的指令
           if (_kbhit())
           {
               char control = Console.ReadKey();
               model->moveBlock(control);
           }
       }
    }
    public class Timer
    {
        public	Timer()
        {

        }
        public void start()
        {

        }
        
        public void reset()
        {

        }
    };
}
