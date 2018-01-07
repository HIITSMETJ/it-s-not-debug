using System;
using System.Windows.Forms;

public class TetrisController
{
    public Timer myTimer = new Timer();
    private TetrisModel model;
    private Form view;

    public TetrisController(TetrisModel model, int board_width, int board_height)
    {
        model = new TetrisModel(this);
    }

    public void start()
    {
        model.start();
        myTimer.Interval = 1500;
        myTimer.Enabled = true;
        myTimer.Tick += new EventHandler(myTimer_Tick);
        myTimer.Start();
        while (!model.GameOver())
        {  //讀取user透過鍵盤對方塊下的指令
            if (Console.KeyAvailable)
            {
                char control = Console.ReadKey().KeyChar;
                model.moveBlock(control);
            }
            //view.ChangeView();
        }
        myTimer.Stop();
    }
    private void myTimer_Tick(Object myObject, EventArgs myEventArgs)
    {
        myTimer.Interval = 1500;
        model.fall();
    }
}
