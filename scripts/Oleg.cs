using Godot;
using System;

public partial class Oleg : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public int Speed { get; set; } = 400;
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}
		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}
		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}

		Position += velocity * (float)delta;
		// Position = new Vector2(
		// 	x: Mathf.Clamp(Position.X, 0, 1280),
		// 	y: Mathf.Clamp(Position.Y, 0, 720)
		// );

		if (velocity.X == 0 && velocity.Y == 0)
		{
			animatedSprite2D.Animation = "stay";
		}
		else if (velocity.X != 0)
		{
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.FlipH = velocity.X < 0;
		}
		else if (velocity.Y < 0)
		{
			animatedSprite2D.Animation = "stay";
		}
		else if (velocity.Y > 0)
		{
			animatedSprite2D.Animation = "stay";
		}
	}
}
