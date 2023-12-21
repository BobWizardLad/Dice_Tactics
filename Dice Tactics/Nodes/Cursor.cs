using Godot;
using System;

[GlobalClass]
public partial class Cursor : Node2D
{
	private bool Input_Delay = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!Input_Delay)
		{
			if (Input.IsActionPressed("CursorUp"))
			{
				MoveLocalY(-8);
				MoveLocalX(16);
				ActivateInputDelay();
			}
			else if (Input.IsActionPressed("CursorDown"))
			{
				MoveLocalY(8);
				MoveLocalX(-16);
				ActivateInputDelay();
			}
			if (Input.IsActionPressed("CursorLeft"))
			{
				MoveLocalY(-8);
				MoveLocalX(-16);
				ActivateInputDelay();
			}
			else if (Input.IsActionPressed("CursorRight"))
			{
				MoveLocalY(8);
				MoveLocalX(16);
				ActivateInputDelay();
			}
		}
	}

	public void _InputDelayRefresh()
	{
		Input_Delay = false;
	}
	
	public void ActivateInputDelay()
	{
		Input_Delay = true;
		GetNode<Timer>("InputDelay").Start();
	}
}
