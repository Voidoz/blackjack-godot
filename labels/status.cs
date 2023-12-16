using Godot;
using System;

namespace Blackjack.labels;

public partial class status : Label
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var game = GetNode<game>("/root/Game");

		switch (game.status)
		{
			case GameStatus.InProgress:
				Visible = false;
				break;
			case GameStatus.DealerWon:
				Visible = true;
				Text = "Dealer Won!";
				break;
			case GameStatus.PlayerWon:
				Visible = true;
				Text = "Player Won!";
				break;
			case GameStatus.Draw:
				Visible = true;
				Text = "Draw!";
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}
