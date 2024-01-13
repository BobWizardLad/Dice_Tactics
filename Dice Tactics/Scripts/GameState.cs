using Godot;
using System;

public partial class GameState : Node
{
	// --------------------------------------------- VARIABLES -----------------------------------------

	// Editable grid size properties.
	[Export]
	private int Grid_X = 16;
	[Export]
	private int Grid_Y = 16;

	private Cursor Cursor;

	// Flag for if the cursor is currently being delayed
	private bool Input_Is_Delay;
	// Cursor Tile
	private int Cursor_Pos;
	// # of tiles.
	private int Grid_Size;
	// Grid array to store game state.
    private GridTile[] GameBoard;
	
	// --------------------------------------------- BUILT-INS -----------------------------------------

	public override void _Ready()
	{
		Cursor = GetNode<Cursor>("TileMap/Cursor");

		Grid_Size = Grid_X * Grid_Y;

		Input_Is_Delay = false;

		// Build the virtual grid using config X and Y.
		GameBoard = new GridTile[Grid_Size];
		for (int index = 0; index < Grid_Size; index++)
		{
			GameBoard[index].Is_Cursor = false;
			GameBoard[index].Board_Pos = new Vector2(index % Grid_X, index / Grid_X);
		}

		// Place cursor on first tile.
		GameBoard[0].Is_Cursor = true;
		Cursor_Pos = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!Input_Is_Delay)
		{
			if (Input.IsActionPressed("CursorUp") && Cursor_Pos <= (Grid_X * Grid_Y) - Grid_X - 1)
			{
				Cursor.Cursor_Up();
				GameBoard[Cursor_Pos].Is_Cursor = false;
				Cursor_Pos += Grid_X;
				GameBoard[Cursor_Pos].Is_Cursor = true;
				Activate_Input_Delay();
			}
			else if (Input.IsActionPressed("CursorDown") && Cursor_Pos >= Grid_X)
			{
				Cursor.Cursor_Down();
				GameBoard[Cursor_Pos].Is_Cursor = false;
				Cursor_Pos -= Grid_X;
				GameBoard[Cursor_Pos].Is_Cursor = true;
				Activate_Input_Delay();
			}
			if (Input.IsActionPressed("CursorLeft") && (Cursor_Pos % 16) != 0)
			{
				Cursor.Cursor_Left();
				GameBoard[Cursor_Pos].Is_Cursor = false;
				Cursor_Pos -= 1;
				GameBoard[Cursor_Pos].Is_Cursor = true;
				Activate_Input_Delay();
			}
			else if (Input.IsActionPressed("CursorRight") && (Cursor_Pos % 16) - 15 != 0)
			{
				Cursor.Cursor_Right();
				GameBoard[Cursor_Pos].Is_Cursor = false;
				Cursor_Pos += 1;
				GameBoard[Cursor_Pos].Is_Cursor = true;
				Activate_Input_Delay();
			}
			Cursor_Pos_Refresh(GameBoard[Cursor_Pos].Board_Pos);
		}
	}

	// --------------------------------------------- STRUCTS -----------------------------------------

	// GridItem struct to store grid state.
    struct GridTile
    {
        // Pawn
        // Hazard
        // Type
		public Vector2 Board_Pos;
        public bool Is_Cursor;

        public GridTile()
        {
            Is_Cursor = false;
			Board_Pos = new Vector2(0,0);
        }
		public GridTile(bool cursor, Vector2 board_pos)
		{
			Is_Cursor = cursor;
			Board_Pos = board_pos;
		}
    }

	// --------------------------------------------- METHODS -----------------------------------------

	// Function to handle grid motion
	public bool _On_Cursor_Move(int x, int y)
	{
		// Precalc

		// Error Catch
		if (true)
		{
			return false;
		}

		// Set Index of Cursor


		// Update Graphics

		return false;
	}

	public void _Input_Delay_Refresh()
	{
		Input_Is_Delay = false;
	}
	
	private void Activate_Input_Delay()
	{
		Input_Is_Delay = true;
		GetNode<Timer>("InputDelay").Start();
	}

	private void Cursor_Pos_Refresh(Vector2 pos)
	{
		GetNode<Label>("Coordinates").Text = pos.ToString();
	}
}
