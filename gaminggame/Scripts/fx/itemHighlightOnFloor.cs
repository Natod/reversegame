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
		RotationDegrees += (float)(rotSpeed * delta);
	}
}
