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
    public void GameAction()                                                            //Check line after block finished falling.
    {
        if (toBottom)
        {
            toBottom = false;
            createBlock();
            eliminateRow();
        }
                   
    }
    public void start()                                                                 //Start the game.
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
    public void pause()                                                                 //Pause or continue the game.
    {
        if (!started)
            return;

        paused = !paused;

        if (paused)
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
    public bool isStarted()                                                             //Check if started.
    {
        return started;
    }
    /* No need
    bool isPaused()                                                                     //Check if paused.
    {
        return paused;
    }
    */
    public void createBlock()                                                           //Create the block
    {
        current_block.randomShape();
        current_block.set_CurrentX(BOARD_WIDTH / 2);
        current_block.set_CurrentY(1);

        if (!tryMove(current_block, current_block.get_CurrentX(), current_block.get_CurrentY()))
        {
            current_block.setBlockShape(TetrisBlock::Blocks.No_shape);
            //timer.stop();
            started = false;
            //Gameover.
        }

    }
    public bool tryMove(TetrisBlock block, int newX, int newY)                          //Check if the block is movable.
    {
        for (size_t i = 0; i < 4; i++)
        {
            int x = newX + block.get_X(i);
            int y = newY + block.get_Y(i);
            if (board[x][y]) return false;                                              //cant put curBlock on exist blocks
            if (x < 0 || x > BOARD_WIDTH || y < 0 || y >= BOARD_HEIGHT)                 //block out of board
                return false;
            //
        }
        current_block = block;
        current_block.set_CurrentX(newX);
        current_block.set_CurrentY(newY);
        //repaint?
        return true;
    }
    public bool fall()                                                                  //Block falling per time unit
    {
        if (!tryMove(current_block, current_block.get_CurrentX(), current_block.get_CurrentY() + 1))
        {
            for (size_t i = 0; i < 4; i++)
            {
                int x = newX + block.get_X(i);
                int y = newY + block.get_Y(i);
                if (y == constant.BOARD_HEIGHT - 1) toBottom = true;
            }
            GameAction();
        }
    }
    public void moveBlock(char control)                                                 //Change the block for either move or spin
    {
        switch (control)
        {
            case 'a':               //left
                if (tryMove(current_block, current_block.get_CurrentX() - 1, current_block.get_CurrentY()))
                    current_block.set_CurrentX(current_block.get_CurrentX() - 1);
                BottomDetection();
                break;
            case 'd':               //right
                if (tryMove(current_block, current_block.get_CurrentX() + 1, current_block.get_CurrentY()))
                    current_block.set_CurrentX(current_block.get_CurrentX() + 1);
                BottomDetection();
                break;
            case 's':               //down+speed
                while (fall()) ;
                break;
            case ' ':               //spin
                if (current_block.getBlockShape() != TetrisBlock::Blocks.No_shape && current_block.getBlockShape() != TetrisBlock::Blocks.Square_shape)
                {
                    TetrisBlock rotate_test = current_block;
                    rotate_test.rotate();
                    if (tryMove(rotate_test, rotate_test.get_CurrentX(), rotate_test.get_CurrentY()))
                        current_block.rotate();
                }
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
    public bool BottomDetection()                                                       //Check if block touches bottom.
    {

    }
    public bool GameOver()                                                              //Check if game is over or not.
    {

    }
    public void eliminateRow()                                                          //Delete while line completed
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

        Score += count * 10;                                        //delete line score

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
    public int getScore()                                                               //Return score for the display.
    {
        return Score;
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
    public Timer()
    {
        reset();
    }
    public void start()
    {

    }
    //no need
    /*
    public pause()
    {

    }
    */
    public void reset()
    {
        timer = 0;
    }

    float timer;
    bool timerLock;
};
class TetrisBlock
{
    //Enumerate the shapes.
    public enum Blocks { No_shape, Line_shape, Square_shape, N_shape, MirrorN_shape, L_shape, MirrorL_shape, T_shape };

    public TetrisBlock()
    {
        int[,] coords = new int[4, 2];
        int[,,] coord_tables = new int[SHAPE_NUM + 1, 4, 2]
        {
            { ( 0, 0),( 0, 0),( 0, 0),( 0, 0) },        //  No_shape
            { ( 0, 0),( 0, 1),( 0, 2),( 0, 3) },        //  Line_shape
            { (-1,-1),( 0,-1),(-1, 0),( 0, 0) },        //  Square_shape
            { (-1,-1),(-1, 0),( 0, 0),( 0, 1) },        //  N-shape
            { ( 0,-1),( 0, 0),(-1, 0),(-1, 1) },        //  MirrorN_shape
            { (-1,-1),( 0,-1),( 0, 0),( 0, 1) },        //  L_shape
            { ( 0,-1),(-1,-1),(-1, 0),(-1, 1) },        //  MirrorL_shape          
            { (-1,-1),(-1, 0),( 0, 0),(-1, 1) }         //  T-shape          
        };

        setBlockShape((Blocks)No_shape);
    }

    public Blocks getBlockShape()                                                       //Get private block shape.
    {
        return block_shape;
    }
    void setBlockShape(Blocks shape)                                                    //Set the block shape by the shape table.
    {
        for (size_t i = 0; i < 4; i++)
        {
            coord[i][0] = coord_table[(Blocks)shape][i][0];
            coord[i][1] = coord_table[(Blocks)shape][i][1];
        }
        this->block_shape = shape;
    }
    void randomShape()                                                                  //Random th shape.
    {
        srand(time(NULL));      //Need to change position.

        int random = rand() % SHAPE_NUM + 1;
        Blocks shape = (Blocks)random;

        setBlockShape(shape);
    }
    void set_CurrentX(int x)                                                            //Set CurrentX by x.
    {
        Current_X = x;
    }
    void set_CurrentY(int y)                                                            //Set CurrentY by y.
    {
        Current_Y = y;
    }
    int get_CurrentX()                                                                  //Get private CurrentX.
    {
        return Current_X;
    }
    int get_CurrentY()                                                                  //Get private CurrentY.
    {
        return Current_Y;
    }
    void set_X(int index, int x)                                                        //Set block coord x.
    {
        coord[index][0] = x;
    }
    void set_Y(int index, int y)                                                        //Set block coord y.
    {
        coord[index][1] = y;
    }
    int get_X(int index)                                                                //Get private block coord x.
    {
        return coord[index][0];
    }
    int get_Y(int index)                                                                //Get private block coord y.
    {
        return coord[index][1];
    }
    /* Not yet used.
    int min_X()
    {
        int minX = coord[0][0];
        for (size_t i = 0; i < 4; i++)
            minX = min(minX, coord[i][0]);
        return minX;
    }
    int min_Y()
    {
        int minY = coord[0][1];
        for (size_t i = 0; i < 4; i++)
            minY = min(minY, coord[i][1]);
        return minY;
    }*/
    void rotate()                                                                       //Rotate block.
    {
        for (size_t i = 0; i < 4; i++)
        {
            int tmp = get_X(i);
            set_X(i, get_Y(i));
            set_Y(i, -tmp);
        }
    }
   
	private Blocks block_shape;
    private int[,] coord = new int[4, 2];                                                       //Block shape coord.
    private int[,,] coord_table = new int[SHAPE_NUM + 1, 4, 2];                                 //All block shape coord table.

    private int Current_X = 0;                                                                  //Current_X means the x-position of the block on the board.
    private int Current_Y = 0;                                                                  //Current_Y means the y-position of the block on the board.

};