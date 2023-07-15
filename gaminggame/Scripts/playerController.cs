using Godot;
using System;

public partial class playerController : CharacterBody2D
{
	[Export]
	private int hp {get; set;} = 100;
	[Export]
	private int maxHp {get; set;} = 100;
	[Export]
	private int moveSpeed {get; set;} = 500;
	[Export]
	private int damage {get; set;} = 10;
	[Export]
	private int money {get; set;} = 0;
	
	[Export]
	private float friction {get; set;} = 0.4f;
	
	
	public override void _Ready()
	{
		moveSpeed *= (int)(1f/(1f-friction));
	}
	
	public override void _PhysicsProcess(double delta)
	{
		
		var velocity = Velocity;
		velocity.X *= 1f-friction;
		velocity.Y *= 1f-friction;

		if (Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_right"))
		{
			velocity.X = -moveSpeed;
		}
		else if (Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_left"))
		{
			velocity.X = moveSpeed;
		}
		else
		{
			// velocity.X = 0;
		}
		
		if (Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_down"))
		{
			velocity.Y = -moveSpeed;
		}
		else if (Input.IsActionPressed("ui_down") && !Input.IsActionPressed("ui_up"))
		{
			velocity.Y = moveSpeed;
		}
		else
		{
			// velocity.Y = 0;
		}
		

		Velocity = velocity;

		// "MoveAndSlide" already takes delta time into account.
		MoveAndSlide();
	}
}
