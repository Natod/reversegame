using Godot;
using System;

public partial class playerController : CharacterBody2D
{
	[Export]
	private int hp {get; set;} = 100;
	[Export]
	private int maxHp {get; set;} = 100;
	[Export]
	private int moveSpeed {get; set;} = 300;
	[Export]
	private int damage {get; set;} = 10;
	[Export]
	private int money {get; set;} = 0;
	
	[Export]
	private float friction {get; set;} = 0.4f;
	
	//Vector2 velocity = Input.GetVector("in_left", "in_right", "in_up", "in_down");
	
	public override void _Ready()
	{
		moveSpeed *= (int)(1f/(1f-friction));
	}
	
	
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.X *= 1f-friction;
		velocity.Y *= 1f-friction;

		if (Input.IsActionPressed("in_left") && !Input.IsActionPressed("in_right"))
		{
			velocity.X = -moveSpeed;
			RotationLerp(Mathf.Pi, delta);
		}
		else if (Input.IsActionPressed("in_right") && !Input.IsActionPressed("in_left"))
		{
			velocity.X = moveSpeed;
			RotationLerp(0, delta);
		}
		
		if (Input.IsActionPressed("in_up") && !Input.IsActionPressed("in_down"))
		{
			velocity.Y = -moveSpeed;
			RotationLerp(Mathf.Pi*3/2, delta);
		}
		else if (Input.IsActionPressed("in_down") && !Input.IsActionPressed("in_up"))
		{
			velocity.Y = moveSpeed;
			RotationLerp(Mathf.Pi/2, delta);
		}
		

		Velocity = velocity;

		// "MoveAndSlide" already takes delta time into account.
		MoveAndSlide();
	}
	
	public void RotationLerp(float newAngle, double delta)
	{
		Rotation = Mathf.LerpAngle(Rotation, newAngle, 0.35f);
	}
}
