using Godot;
using System;

namespace Blackjack.buttons;

public partial class stand : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (GetNode("/root/Game") is not game game) return;

		Pressed += game.Stand;
	}
}
