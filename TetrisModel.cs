using System;
enum constant { BOARD_WIDTH = 10, BOARD_HEIGHT = 22, SHAPE_NUM = 7 };


public class TetrisModel
{
    private bool[,] board = new bool[(int)constant.BOARD_WIDTH, (int)constant.BOARD_HEIGHT];
    private bool toBottom = false;
    private bool started = false;
    private bool isGameOver = false;
    private int Score = 0;
    private TetrisBlock current_block;
    private TetrisController controller;


    public TetrisModel(TetrisController controller)
    {
        this.controller = controller;
    }



    public void getBoard(bool[,] viewBoard)
    {
        viewBoard = board;
        return;
    }

    public void GameAction()      							//Check line after block finished falling.                                                      
    {
        addBlockToBoard(current_block, current_block.get_CurrentX(), current_block.get_CurrentY());
        createBlock();
        eliminateRow();
    }
    public void start()                                                                 //Start the game.
    {
        started = true;
        Score = 0;
        clearBoard();
        createBlock();
    }

    public bool isStarted()                                                             //Check if started.
    {
        return started;
    }

    public void createBlock()                                                           //Create the block
    {
        current_block.randomShape();
        current_block.set_CurrentX((int)constant.BOARD_WIDTH / 2);
        current_block.set_CurrentY(1);

        if (!tryMove(current_block, current_block.get_CurrentX(), current_block.get_CurrentY()))
        {
            current_block.setBlockShape(TetrisBlock.Blocks.No_shape);
            started = false;
            isGameOver = true;
        }

    }

    public bool tryMove(TetrisBlock block, int newX, int newY)                          //Check if the block is movable, and then move
    {
        for (int i = 0; i < 4; i++)
        {
            int x = newX + block.get_X(i);
            int y = newY + block.get_Y(i);
            if (board[x, y]) return false;                                              //cannot put curBlock on exist blocks
            if (x < 0 || x > (int)constant.BOARD_WIDTH || y < 0 || y >= (int)constant.BOARD_HEIGHT)                 //block out of board
                return false;
        }
        current_block = block;
        current_block.set_CurrentX(newX);
        current_block.set_CurrentY(newY);
        return true;
    }

    public void fall()                                                                  //Block falling per time unit
    {
        if (!tryMove(current_block, current_block.get_CurrentX(), current_block.get_CurrentY() + 1))
        {
            GameAction();
        }
    }

    public void moveBlock(char control)                                                 //Change the block for either move or spin
    {
        switch (control)
        {
            case 'a':               //left
                if (tryMove(current_block, current_block.get_CurrentX() - 1, current_block.get_CurrentY()))
                    break;
                goto case 'd';
            case 'd':               //right
                if (tryMove(current_block, current_block.get_CurrentX() + 1, current_block.get_CurrentY()))
                    break;
                goto case 's';
            case 's':               //down+speed
                controller.myTimer.Interval = 200;
                break;
            case ' ':               //spin
                if (current_block.getBlockShape() != TetrisBlock.Blocks.No_shape && current_block.getBlockShape() != TetrisBlock.Blocks.Square_shape)
                {
                    TetrisBlock rotate_test = current_block;
                    rotate_test.rotate();
                    if (tryMove(rotate_test, rotate_test.get_CurrentX(), rotate_test.get_CurrentY()))
                        current_block.rotate();
                }
                break;
        }
    }

    public bool GameOver()                                                              //Check if game is over or not.
    {
        return isGameOver;
    }

    public void eliminateRow()                                                          //Delete while line completed
    {
        bool[] isAbleDelete = new bool[(int)constant.BOARD_HEIGHT];
        for (int i = 0; i < (int)constant.BOARD_HEIGHT; i++)
        {
            isAbleDelete[i] = true;
        }

        //記錄哪些列是滿的
        for (int i = (int)constant.BOARD_HEIGHT - 1; i >= 0; i--)
        {
            for (int j = (int)constant.BOARD_WIDTH - 1; j >= 0; j--)
            {
                if (board[i, j] == false)
                {
                    isAbleDelete[i] = false;
                }
            }
        }
        //將滿的那幾列全刪
        for (int i = (int)constant.BOARD_HEIGHT - 1; i >= 0; i--)
        {
            for (int j = (int)constant.BOARD_WIDTH - 1; j >= 0; j--)
            {
                if (isAbleDelete[i])
                {
                    board[i, j] = false;
                }
            }
        }
        //算每列要下落幾列，這邊lines[]的意義有點複雜，配合下個for loop看比較好懂
        int[] lines = new int[(int)constant.BOARD_HEIGHT + 1];
        int count = 0;
        for (int i = (int)constant.BOARD_HEIGHT - 1; i >= 0; i--)
        {
            if (isAbleDelete[i])
            {
                count += 1;
            }
            lines[i + 1] = count;
        }

        Score += count * 10;                                        //delete line -> add score

        //被清空的列要被上面取代
        for (int i = (int)constant.BOARD_HEIGHT - 1; i >= 0; i--)
        {
            for (int j = (int)constant.BOARD_WIDTH - 1; j >= 0; j--)
            {
                if (i - 1 < 0)
                    board[i, j] = false;
                else
                    board[i, j] = board[i - lines[i], j];
            }
        }
    }

    public int getScore()                                                               //Return score for the display.
    {
        return Score;
    }

    public void addBlockToBoard(TetrisBlock block, int newX, int newY)
    {
        for (int i = 0; i < 4; i++)
        {
            int x = newX + block.get_X(i);
            int y = newY + block.get_Y(i);
            board[x, y] = true;
        }
    }

    private void clearBoard()
    {
        Array.Clear(board, 0, (int)constant.BOARD_HEIGHT * (int)constant.BOARD_WIDTH - 1);
    }
};


public class TetrisBlock
{
    //Enumerate the shapes.
    public enum Blocks { No_shape, Line_shape, Square_shape, N_shape, MirrorN_shape, L_shape, MirrorL_shape, T_shape };

    public TetrisBlock()
    {
        int[,] coords = new int[4, 2];
        int[,,] coord_tables = new int[(int)constant.SHAPE_NUM + 1, 4, 2]
        {
            { { 0, 0},{ 0, 0},{ 0, 0},{ 0, 0} },        //  No_shape
            { { 0, 0},{ 0, 1},{ 0, 2},{ 0, 3} },        //  Line_shape
            { {-1,-1},{ 0,-1},{-1, 0},{ 0, 0} },        //  Square_shape
            { {-1,-1},{-1, 0},{ 0, 0},{ 0, 1} },        //  N-shape
            { { 0,-1},{ 0, 0},{-1, 0},{-1, 1} },        //  MirrorN_shape
            { {-1,-1},{ 0,-1},{ 0, 0},{ 0, 1} },        //  L_shape
            { { 0,-1},{-1,-1},{-1, 0},{-1, 1} },        //  MirrorL_shape          
            { {-1,-1},{-1, 0},{ 0, 0},{-1, 1} }         //  T-shape          
        };

        setBlockShape((Blocks)Blocks.No_shape);
    }

    public Blocks getBlockShape()                                                       //Get private block shape.
    {
        return block_shape;
    }
    public void setBlockShape(Blocks shape)                                                    //Set the block shape by the shape table.
    {
        for (int i = 0; i < 4; i++)
        {
            coord[i, 0] = coord_table[(int)shape, i, 0];
            coord[i, 1] = coord_table[(int)shape, i, 1];
        }
        this.block_shape = shape;
    }
    public void randomShape()                                                                  //Random th shape.
    {
        //srand(time(NULL));      //Need to change position.

        Random random_R = new Random();
        int random = random_R.Next(1, (int)constant.SHAPE_NUM + 1);
        Blocks shape = (Blocks)random;

        setBlockShape(shape);
    }
    public void set_CurrentX(int x)                                                            //Set CurrentX by x.
    {
        Current_X = x;
    }
    public void set_CurrentY(int y)                                                            //Set CurrentY by y.
    {
        Current_Y = y;
    }
    public int get_CurrentX()                                                                  //Get private CurrentX.
    {
        return Current_X;
    }
    public int get_CurrentY()                                                                  //Get private CurrentY.
    {
        return Current_Y;
    }
    public void set_X(int index, int x)                                                        //Set block coord x.
    {
        coord[index, 0] = x;
    }
    public void set_Y(int index, int y)                                                        //Set block coord y.
    {
        coord[index, 1] = y;
    }
    public int get_X(int index)                                                                //Get private block coord x.
    {
        return coord[index, 0];
    }
    public int get_Y(int index)                                                                //Get private block coord y.
    {
        return coord[index, 1];
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
    public void rotate()                                                                       //Rotate block.
    {
        for (int i = 0; i < 4; i++)
        {
            int tmp = get_X(i);
            set_X(i, get_Y(i));
            set_Y(i, -tmp);
        }
    }

    private Blocks block_shape;
    private int[,] coord = new int[4, 2];                                                       //Block shape coord.
    private int[,,] coord_table = new int[(int)constant.SHAPE_NUM + 1, 4, 2];                                 //All block shape coord table.

    private int Current_X = 0;                                                                  //Current_X means the x-position of the block on the board.
    private int Current_Y = 0;                                                                  //Current_Y means the y-position of the block on the board.

};
