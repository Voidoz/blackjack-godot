using Godot;
using System;

namespace Blackjack.buttons;

public partial class restart : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (GetNode("/root/Game") is not game game) return;

		Pressed += game.RestartGame;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GetNode("/root/Game") is not game game) return;

		Visible = game.status != GameStatus.InProgress;
	}
}
