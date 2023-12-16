using Godot;
using System;

namespace Blackjack;

public partial class dealer : HBoxContainer
{
	private void RefreshCards()
	{
		if (GetNode("/root/Game") is not game game) return;
		
		// Clear cards for redrawing
		foreach (var child in GetChildren())
		{
			RemoveChild(child);
		}
		
		AddChild(new card(game.DealerHand[0]));
		AddChild(new card(game.status == GameStatus.InProgress ? null : game.DealerHand[1]));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		RefreshCards();
	}
}
