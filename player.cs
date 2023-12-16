using Godot;
using System;

namespace Blackjack;

public partial class player : HBoxContainer
{
	private void RefreshCards()
	{
		if (GetNode("/root/Game") is not game game) return;

		// Clear children to be replaced
		foreach (var child in GetChildren())
		{
			RemoveChild(child);
		}

		foreach (var card in game.PlayerHand)
		{
			AddChild(new card(card));
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		RefreshCards();
	}
}
