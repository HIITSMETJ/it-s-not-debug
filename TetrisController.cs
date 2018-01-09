using System;
using System.Windows.Forms;
using Tetris;

public class TetrisController
{
    public Timer myTimer = new Timer();
    private TetrisModel model;
    private Form1 view;

    public TetrisController()
    {
        view = new Form1(this);
        model = new TetrisModel(this, view);
        Application.Run(view);
    }

    public void start()
    {
        model.start();
        myTimer.Interval = 1500;
        myTimer.Enabled = true;
        myTimer.Tick += new EventHandler(myTimer_Tick);
        myTimer.Start();
        //while (!model.GameOver())
        //{  //讀取user透過鍵盤對方塊下的指令
        //    if (Console.KeyAvailable)
        //    {
        //        char control = Console.ReadKey().KeyChar;
        //        model.moveBlock(control);
        //    }
        //    //view.ChangeView();
        //}
        //myTimer.Stop();
    }

    public void keyPress(string inputKey)
    {
        if (model.isStarted())
        {
            char control = inputKey[0];
            model.moveBlock(control);
        }
    }

    private void myTimer_Tick(Object myObject, EventArgs myEventArgs)
    {
        myTimer.Interval = 1500;
        model.fall();
    }
}
