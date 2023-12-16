using Godot;
using System;

namespace Blackjack.labels;

public partial class player : Label
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var game = GetNode<game>("/root/Game");
		Text = $"Player ({game.PlayerHand.GetCardTotal()})";
	}
}
