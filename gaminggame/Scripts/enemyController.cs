using Godot;
using System;

public partial class enemyController : CharacterBody2D
{
	
	
	[Export]
	private int maxHp {get; set;} = 100;
	[Export]
	private int moveSpeed {get; set;} = 300;
	[Export]
	private int damage {get; set;} = 10;
	[Export]
	private int moneyDropMin {get; set;} = 2;
	[Export]
	private int moneyDropMax {get; set;} = 4;
	[Export]
	private int defense {get; set;} = 0;
	private int hp;
	private float friction = 0.25f;
	
	
	public override void _Ready()
	{
		hp = maxHp;
		moveSpeed *= (int)(1f/(1f-friction));
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.X *= 1f-friction;
		velocity.Y *= 1f-friction;
		if (!(velocity.X == 0 && velocity.Y == 0))
		{
			RotationLerp(velocity.Angle());
		}	
		
		Velocity = velocity;
		MoveAndSlide();
	}
	
	public void RotationLerp(float newAngle)
	{
		Rotation = Mathf.LerpAngle(Rotation, newAngle, 0.35f);
	}
}
