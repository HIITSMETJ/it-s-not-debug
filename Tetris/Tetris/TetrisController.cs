using System;
using System.Windows.Forms;
using Tetris;

public class TetrisController
{
    public Timer myTimer = new Timer();
    private TetrisModel model;
    private b10432016 view;

    public TetrisController()
    {
        view = new b10432016(this);
        model = new TetrisModel(this, view);
        myTimer.Tick += new EventHandler(myTimer_Tick);
        Application.Run(view);
    }

    public void start()
    {
        myTimer.Stop();
        model.start();
        myTimer.Interval = 500;
        myTimer.Enabled = true;
        myTimer.Start();
        
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
        myTimer.Interval = 500;
        model.fall();
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new TetrisView());
        TetrisController controller = new TetrisController();
        //controller.start();
    }
}
