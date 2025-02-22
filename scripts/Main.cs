using Godot;
using System;
using System.Threading;

public partial class Main : Node
{
	// Called when the node enters the scene tree for the first time.
	Oleg Player;
	public override void _Ready()
	{
		Player = GetNode<Oleg>("Oleg");
		var _startPosition = GetNode<Marker2D>("StartPosition");

		Player.Position = _startPosition.Position;

		//GetNode<CanvasLayer>("HUD").Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
