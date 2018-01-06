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
		current_block.randomShape();
		current_block.set_CurrentX(BOARD_WIDTH / 2); 
		current_block.set_CurrentY(1);

		if (!tryMove(current_block, current_block.get_CurrentX(), current_block.get_CurrentY()))
		{
			current_block.setBlockShape(TetrisBlock::Blocks::No_shape);
			//timer.stop();
			started = false;
			//Gameover.
		}
	}
	bool tryMove(TetrisBlock block, int newX, int newY)							//Check if the block is movable.
	{
		for (size_t i = 0; i < 4; i++)
		{
			int x = newX + block.get_X(i);
			int y = newY + block.get_Y(i);
			if (x < 0 || x>BOARD_WIDTH || y < 0 || y >= BOARD_HEIGHT)
				return false;
			//
		}
		current_block = block;
		current_block.set_CurrentX(newX);
		current_block.set_CurrentY(newY);
		//repaint?
		return true;
	}
	bool fall()							//Block falling.
	{

	}
	void moveBlock(char control)			//Change the block for either move or spin
	{
		switch (control)
		{
		case 'a':				//left
			if (tryMove(current_block, current_block.get_CurrentX() - 1, current_block.get_CurrentY()))
				current_block.set_CurrentX(current_block.get_CurrentX() - 1);
			BottomDetection();
			break;
		case 'd':				//right
			if (tryMove(current_block, current_block.get_CurrentX() + 1, current_block.get_CurrentY()))
				current_block.set_CurrentX(current_block.get_CurrentX() + 1);
			BottomDetection();
			break;
		case 's':				//down+speed
			while (fall());
			break;
		case ' ':				//spin
			if (current_block.getBlockShape() != TetrisBlock::Blocks::No_shape&&current_block.getBlockShape() != TetrisBlock::Blocks::Square_shape)
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
		int coords[4][2];
		int coord_tables[SHAPE_NUM + 1][4][2] = 
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
		for (size_t i = 0; i < 4; i++)
		{
			coord[i][0] = coord_table[(Blocks)shape][i][0];
			coord[i][1] = coord_table[(Blocks)shape][i][1];
		}
		this->block_shape = shape;
	}
	void randomShape()
	{
		srand(time(NULL));

		int random = rand() % SHAPE_NUM + 1;
		Blocks shape = (Blocks)random;

		setBlockShape(shape);
	}
	void set_CurrentX(int x)
	{
		Current_X = x;
	}
	void set_CurrentY(int y)
	{
		Current_Y = y;
	}
	int get_CurrentX()
	{
		return Current_X;
	}
	int get_CurrentY()
	{
		return Current_Y;
	}
	int get_X(int index)
	{
		return coord[index][0];
	}
	int get_Y(int index)
	{
		return coord[index][1];
	}
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
	}
	void rotate()
	{

	}
private:
	Blocks block_shape;
	int coord[4][2];
	int coord_table[SHAPE_NUM + 1][4][2];
	
	int Current_X = 0;
	int Current_Y = 0;

};
