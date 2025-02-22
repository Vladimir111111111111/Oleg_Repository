using Godot;
using System;
using System.Net.Http;

public partial class Tree : Area2D
{
	bool storytold = false;
	bool TreeStoryEventEnabler = true;
	string[] messages = new string[3]
	{
		"-",
		"Вы подобрали яблоко",
		"Вы пидор"
	};
	int message_index;
	// Called when the node enters the scene tree for the first time.
	private CanvasLayer hud;
	private Label MessageText;
	public override void _Ready()
	{
		hud = GetNode<Hud>("/root/Main/HUD");
		MessageText = GetNode<Label>("/root/Main/HUD/ColorRect/MessageLabel");

		hud.Hide();
	}
	public void OnAreaEntered(Area2D body)
	{
		GD.Print("Collided");
		hud.Show();

		MessageText.Text = messages[message_index];

		TreeStoryEventEnabler = true;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (storytold == false && TreeStoryEventEnabler && Input.IsActionJustPressed("next_message"))
		{
			message_index++;
			if (message_index >= messages.Length)
            {
                hud.Hide();
				storytold = true;
            }
            else
            {
                // Показываем следующее сообщение
                MessageText.Text = messages[message_index];
            }
		}
	}
}
