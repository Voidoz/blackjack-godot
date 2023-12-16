using Godot;
using System;
using Blackjack.Cards;

namespace Blackjack.labels;

public partial class dealer : Label
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var game = GetNode<game>("/root/Game");

		if (game.status != GameStatus.InProgress)
		{
			Text = $"Dealer ({game.DealerHand.GetCardTotal()})";
		}
		else
		{
			var hand = new Hand { game.DealerHand[0] };

			Text = $"Dealer ({hand.GetCardTotal()})";
		}
	}
}
