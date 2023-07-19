using Godot;
using System;

public partial class itemHighlightPrompt : Node2D
{
	[Export]
	private float alphaFalloff {get; set;} = 1f;
	private Sprite2D spritesNode;
	Color tempColor;
	//private float aVal = 0;
	
	public override void _Ready()
	{
		spritesNode = (Sprite2D)GetNode("XboxOneB");
		Visible = false;
	}


	public override void _Process(double delta)
	{
		//aVal = (float)(1/ DistanceTo( new Vector2((float)player.Transform.X.X, (float)player.Transform.Y.Y) ));
		
		
		
	}
	
	/*
	private void OpacityFadeTo(float newOpacity)
	{
		tempColor = new Color(1, 1, 1, Mathf.Lerp(spritesNode.Modulate.A, newOpacity, 0.25f));
		spritesNode.Modulate = tempColor;
	}
	*/
	
	private void _on_body_entered(Node2D body)
	{
		if (body.Name == "Player")
		{
			Visible = true;
		}
	}
	
	private void _on_body_exited(Node2D body)
	{
		if (body.Name == "Player")
		{
			Visible = false;
		}
	}
	
}






