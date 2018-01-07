using System;
using windows.h;
using conio.h;
using ctime;
using cmath;
using iostream;
using TetrisModel.cs;

public class TetrisController
{
    static public Windows.Forms.Timer myTimer = new Windows.Forms.Timer();
    private TetrisModel model;
    private TetrisView view;

    public TetrisController(TetrisModel* model, int board_width, int board_height)
    {

    }
  
    public start()
    {
        model.start();
        myTimer.Interval = 1500;
        myTimer.Enabled = true;
        timer.Tick += new EventHandler(MyTimerTick);
        myTimer.Start();
        while (!model.GameOver())
        {  //讀取user透過鍵盤對方塊下的指令
           if (_kbhit())
           {
               char control = Console.ReadKey();
               model->moveBlock(control);
	    }
	    view.ChangeView();
        }
	 myTimer.Stop();
    }
    private static void myTimer_Tick(Object myObject, EventArgs myEventArgs)
    {
        model.fall();
    }
}
