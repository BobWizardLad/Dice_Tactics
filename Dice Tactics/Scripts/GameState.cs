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
	// Called when the node enters the scene tree for the first time.
	
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
			if (Input.IsActionPressed("CursorUp"))
			{
				Cursor.Cursor_Up();
				ActivateInputDelay();
			}
			else if (Input.IsActionPressed("CursorDown"))
			{
				Cursor.Cursor_Down();
				ActivateInputDelay();
			}
			if (Input.IsActionPressed("CursorLeft"))
			{
				Cursor.Cursor_Left();
				ActivateInputDelay();
			}
			else if (Input.IsActionPressed("CursorRight"))
			{
				Cursor.Cursor_Right();
				ActivateInputDelay();
			}
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
	public void _On_Cursor_Move(int x, int y)
	{
		// Precalc

		// Error Catch
		if (!(Cursor_Pos + (y * Grid_X) + x >= Grid_Size))
		{
			return;
		}

		// Y Motion

		// X Motion

		// Update Graphics
	}

	public void _InputDelayRefresh()
	{
		Input_Is_Delay = false;
	}
	
	public void ActivateInputDelay()
	{
		Input_Is_Delay = true;
		GetNode<Timer>("InputDelay").Start();
	}
}
