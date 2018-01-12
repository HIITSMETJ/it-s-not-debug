using System;
using System.Windows.Forms;
using Tetris;

public class TetrisController
{
    public Timer myTimer = new Timer();
    private TetrisModel model;
    private TetrisView view;

    public TetrisController()
    {
        //整個程式換view時唯一需要改的地方
        view = new B10432028(this);
        
        model = new TetrisModel(this, view);
        myTimer.Tick += new EventHandler(myTimer_Tick);
        Application.Run(view);
    }

    public void start()
    {
        if (!model.isStarted())
        {
            myTimer.Stop();
            model.start();
            myTimer.Interval = 500;
            myTimer.Enabled = true;
            myTimer.Start();
        }
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
        if (model.isStarted())
        {
            myTimer.Interval = 500;
            model.fall();
        }
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new Form1());
        TetrisController controller = new TetrisController();
        //controller.start();
    }
}
