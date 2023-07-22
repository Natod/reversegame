using Godot;
using System;

public partial class itemHighlightOnFloor : Node2D
{
	[Export]
	private float rotSpeed {get; set;} = 40f;
	
	public override void _Ready()
	{
	}


	public override void _Process(double delta)
	{
		if (rotSpeed < 0)
		{
			RotationDegrees += (float)(Mathf.Abs(rotSpeed) * delta);
		}
		else
		{
			RotationDegrees += (float)(rotSpeed * delta);
		}
	}
}
