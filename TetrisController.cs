using System;
using windows.h;
using conio.h;
using ctime;
using cmath;
using iostream;
using TetrisModel.cs;

public class TetrisController
{
    static public System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    private TetrisModel model;

    public TetrisController(TetrisModel* model, int board_width, int board_height)
	{

	}
    private TetrisModel* model = new TetrisModel();
    public start()
    {
        model.start();
        myTimer.Interval = 1500;
        myTimer.Enabled = true;
        timer.Tick += new EventHandler(MyTimerTick);
        myTimer.Start();
        while (true)
        {  //讀取user透過鍵盤對方塊下的指令
           if (_kbhit())
           {
               char control = Console.ReadKey();
               model->moveBlock(control);
           }
       }
    }
    private static void myTimer_Tick(Object myObject, EventArgs myEventArgs)
    {
        model.fall();
    }

    //no need
    //public class Timer
    //{
    //    public	Timer()
    //    {

    //    }
    //    public void start()
    //    {

    //    }
        
    //    public void reset()
    //    {

    //    }
    //};
}
