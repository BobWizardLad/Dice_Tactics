using Godot;
using System;

[GlobalClass]
public partial class Cursor : Node2D
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Cursor_Down()
	{
		MoveLocalY(8);
		MoveLocalX(-16);
	}

	public void Cursor_Up()
	{
		MoveLocalY(-8);
		MoveLocalX(16);
	}

	public void Cursor_Left()
	{
		MoveLocalY(-8);
		MoveLocalX(-16);
	}

	public void Cursor_Right()
	{
		MoveLocalY(8);
		MoveLocalX(16);
	}
}