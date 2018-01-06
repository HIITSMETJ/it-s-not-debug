#include <windows.h>
#include <conio.h>
#include <ctime>
#include <cmath>
#include <iostream>
#define BOARD_WIDTH 10
#define BOARD_HEIGHT 22
#define SHAPE_NUM 7

using namespace std;

class TetrisModel
{
public:
	TetrisModel()
	{

	}
	
	void GameAction()						//Check line after block finished falling.
	{
		if (toBottom)
		{
			toBottom = false;
			createBlock();
		}
		else
			eliminateRow();
	}
	void start()							//Start the game.
	{
		if (isPaused)
			return;
		started = true;
		toBottom = false;
		LinesRemoved = 0;
		Score = 0;
		clearBoard();
		createBlock();
		timer.start();
	}
	void pause()							//Pause or continue the game.
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
	bool isStarted()						//Check if started.
	{
		return started;
	}
	bool isPaused()						//Check if paused.
	{
		return paused;
	}
	void createBlock()						//Create the block
	{

	}
	bool tryMove()							//Check if the block is movable.
	{

	}
	bool fall()							//Block falling.
	{

	}
	void moveBlock(char control)			//Change the block for either move or spin
	{
		switch (control)
		{
		case 'a':				//left
								//
			BottomDetection();
			break;
		case 'd':				//right
								//
			BottomDetection();
			break;
		case 's':				//down+speed
			while (fall());
			break;
		case ' ':				//spin
								//
			BottomDetection();
			break;
		}
	}
/*	a		:left
	s		:down+speed
	d		:right
	space	:spin
	p		:pause/continue
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

	bool BottomDetection()					//Check if block touches bottom.
	{

	}
	bool GameOver()							//Check if game is over or not.
	{

	}
	void eliminateRow()						//Delete while line completed
	{
		int full_Line = 0;

	}


private:
	Timer timer;
	TetrisBlock current_block;

	void clearBoard()
	{
		//Clear the board.
	}

	bool toBottom = false;
	bool started = false;
	bool paused = false;
	bool isGameOver = false;


	int LinesRemoved = 0;
	int Score = 0;

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

class TetrisBoard
{
public:
	TetrisBoard()
	{

	}
private:
	int Board[BOARD_WIDTH][BOARD_HEIGHT];
};

class TetrisBlock
{
public:

	enum Blocks { No_shape, Line_shape, Square_shape, N_shape, MirrorN_shape, L_shape, MirrorL_shape, T_shape };
	TetrisBlock()
	{
		int coord[4][2];
		int coord_table[SHAPE_NUM + 1][4][2] = 
		{ 
			{ (0,0),(0,0),(0,0),(0,0) },
			{ (1,0),(0,0),(0,1),(0,2) },
			{ (0,0),(1,0),(1,1),(1,2) },
			{ (0,0),(0,1),(1,1),(1,2) },
			{ (1,0),(1,1),(0,1),(0,2) },
			{ (0,0),(1,0),(0,1),(1,1) },
			{ (0,0),(0,1),(1,1),(0,2) },
			{ (0,0),(0,1),(0,2),(0,3) }
		};
		setBlockShape((Blocks)No_shape);
	}
	Blocks getBlockShape()
	{
		return block_shape;
	}
	void setBlockShape(Blocks shape)
	{
		//set block coord.

		this->block_shape = shape;
	}
	void randomShape()
	{
		srand(time(NULL));

		int random = rand() % SHAPE_NUM + 1;
		Blocks shape = (Blocks)random;

		setBlockShape(shape);
	}
	void set_CurrentX(int index, int x)
	{

	}
	void set_CurrentY(int index, int y)
	{

	}

private:
	Blocks block_shape;
	
	int Current_X = 0;
	int Current_Y = 0;

};
