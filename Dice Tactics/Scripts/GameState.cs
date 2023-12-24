using Godot;
using System;

public partial class GameState : Node
{
	// Editable grid size properties.
	[Export]
	private int Grid_X = 16;
	[Export]
	private int Grid_Y = 16;
	// # of tiles.
	private int Grid_Size;
	// Grid array to store game state.
    private GridTile[] GameBoard;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Grid_Size = Grid_X * Grid_Y;

		// Build the virtual grid using config X and Y.
		GameBoard = new GridTile[Grid_Size];
		for (int index = 0; index < Grid_Size; index++)
		{
			GameBoard[index].Cursor = false;
			GameBoard[index].Board_Pos = 
		}

		// Place cursor on first tile.
		GameBoard[0].Cursor = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// GridItem struct to store grid state.
    struct GridTile
    {
        // Pawn
        // Hazard
        // Type
		public Vector2 Board_Pos;
        public bool Cursor;

        public GridTile()
        {
            Cursor = false;
			Board_Pos = new Vector2(0,0);
        }
		public GridTile(bool cursor, Vector2 board_pos)
		{
			Cursor = cursor;
			Board_Pos = board_pos;
		}
    }

}
