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
	private int defense {get; set;} = 0;
	
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
		if (!(Input.GetVector("in_left", "in_right", "in_up", "in_down").X == 0 && Input.GetVector("in_left", "in_right", "in_up", "in_down").Y == 0))
		{
			velocity = Input.GetVector("in_left", "in_right", "in_up", "in_down") * moveSpeed;
		}
		if (!(velocity.X == 0 && velocity.Y == 0))
		{
			RotationLerp(velocity.Angle());
		}	

		Velocity = velocity;

		// "MoveAndSlide" already takes delta time into account.
		MoveAndSlide();
	}
	
	public void RotationLerp(float newAngle)
	{
		Rotation = Mathf.LerpAngle(Rotation, newAngle, 0.35f);
	}
	
	private void GetHurt(int damageTaken)
	{
		hp -= damageTaken;
		Modulate = new Color(1, 0.65f, 0.65f, 1);
	}
	
}
