using System;
using windows.h;
using conio.h;
using ctime;
using cmath;
using iostream;
enum constant { BOARD_WIDTH=10, BOARD_HEIGHT=22, SHAPE_NUM=7 };


public class TetrisModel
{
    private bool[,] board=new bool[constant.BOARD_HEIGHT, constant.BOARD_WIDTH] {0};
	public TetrisModel()
	{


	}
    public void GameAction()                       //Check line after block finished falling.
    {
        if (toBottom)
        {
            toBottom = false;
            createBlock();
            eliminateRow();
        }
                   
    }
    public void start()                            //Start the game.
    {
        //if (isPaused)
        //    return;
        started = true;
        toBottom = false;
        LinesRemoved = 0;
        Score = 0;
        clearBoard();
        createBlock();
        timer.start();
    }
    /*   No need 
    public void pause()                            //Pause or continue the game.
    {
        if (!isStarted)
            return;

        paused = !paused;

        if (isPaused)
        {
            timer.pause();
            //	tetrisBoard.setStatusText("paused");
        }
        else
        {
            timer.start();
            //	tetrisBoard.setStatusText(String.valueOf(numLinesRemoved));
        }
        //tetrisBoard.repaint();
    }
    */
    public bool isStarted()                        //Check if started.
    {
        return started;
    }
    /* No need
    bool isPaused()                     //Check if paused.
    {
        return paused;
    }
    */
    public void createBlock()                      //Create the block
    {
        current_block.randomShape();
        //current_block.set_CurrentX(BOARD_WIDTH / 2); 
        //current_block.set_CurrentY(BOARD_HEIGHT - 1);

    }
    public bool tryMove()                          //Check if the block is movable.
    {

    }
    public bool fall()                            //Block falling per time unit
    {

    }
    public void moveBlock(char control)            //Change the block for either move or spin
    {
        switch (control)
        {
            case 'a':               //left
                                    //
                BottomDetection();
                break;
            case 'd':               //right
                                    //
                BottomDetection();
                break;
            case 's':               //down+speed
                while (fall()) ;
                break;
            case ' ':               //spin
                                    //
                BottomDetection();
                break;
        }
    }
    /*	a		:left
        s		:down+speed
        d		:right
        space	:spin
    */
    /*	while(true)
        {
        if(_kbhit())
        {
        char control = _getch();
        //moveBlock(control);
        }
        }
    */
    public bool BottomDetection()                  //Check if block touches bottom.
    {

    }
    public bool GameOver()                         //Check if game is over or not.
    {

    }
    public void eliminateRow()                     //Delete while line completed
    {
        bool[] isAbleDelete = new bool[constant.BOARD_HEIGHT];
        for (int i = 0; i < constant.BOARD_HEIGHT; i++)
        {
            isAbleDelete[i] = 1;
        }
       
        //記錄哪些列是滿的
        for (int i = constant.BOARD_HEIGHT - 1; i >= 0; i--)
        {
            for (int j = constant.BOARD_WIDTH - 1; j >= 0; j--)
            {
                if (board[i][j] == 0)
                {
                    isAbleDelete[i] = 0;
                }
            }
        }
        //將滿的那幾列全刪
        for (int i = constant.BOARD_HEIGHT - 1; i >= 0; i--)
        {
            for (int j = constant.BOARD_WIDTH - 1; j >= 0; j--)
            {
                if (isAbleDelete[i])
                {
                    board[i][j] = 0;
                }
            }
        }
        //算每列要下落幾列，這邊lines[]的意義有點複雜，配合下個for loop看比較好懂
        int[] lines = new int[constant.BOARD_HEIGHT + 1] { 0 };
        int count = 0;
        for (int i = constant.BOARD_HEIGHT - 1; i >= 0; i--)
        {
            if (isAbleDelete[i])
            {
                count += 1;
            }
            lines[i + 1] = count;
        }
        //被清空的列要被上面取代
        for (int i = constant.BOARD_HEIGHT - 1; i >= 0; i--)
        {
            for (int j = constant.BOARD_WIDTH - 1; j >= 0; j--)
            {
                if (i - 1 < 0)
                    board[i][j] = 0;
                else
                    board[i][j] = board[i - lines[i]][j];
            }
        }
    }
    private Timer timer;
    private TetrisBlock current_block;
    private void clearBoard()
    {
        Array.Clear(board, 0, constant.BOARD_HEIGHT * constant.BOARD_WIDTH - 1);
    }
    private bool toBottom = false;
    private bool started = false;
    private bool paused = false;
    private bool isGameOver = false;
    private int LinesRemoved = 0;
    private int Score = 0;

    //int[][] coords;
    //int[][][] coordsTable;

};

class Timer
{
    public:
	Timer()
    {

    }
    void start()
    {

    }
    void pause()
    {

    }
    void reset()
    {

    }

    private:

};