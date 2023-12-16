using System;
using System.Collections.Generic;
using Blackjack.Cards;
using Godot;

namespace Blackjack;

public enum GameStatus
{
	InProgress,
	DealerWon,
	PlayerWon,
	Draw
}

public partial class game : Node2D
{
	public GameStatus status;
	public Deck Deck;
	public Hand DealerHand;
	public Hand PlayerHand;
	
	public game()
	{
		RestartGame();
	}

	public void RestartGame()
	{
		status = GameStatus.InProgress;
		Deck = new Deck();
		DealerHand = new Hand();
		PlayerHand = new Hand();
		
		var random = new Random();
		for (var i = 0; i < 2; i++)
		{
			var dealerCardIndex = random.Next(Deck.Count);
			var dealerCard = Deck[dealerCardIndex];
			Deck.Remove(dealerCard);
			DealerHand.Add(dealerCard);

			var playerCardIndex = random.Next(Deck.Count);
			var playerCard = Deck[playerCardIndex];
			Deck.Remove(playerCard);
			PlayerHand.Add(playerCard);
		}
	}

	private void UpdateStatus(bool stand)
	{
		var dealerTotal = DealerHand.GetCardTotal();
		var playerTotal = PlayerHand.GetCardTotal();

		if (!stand && playerTotal < 21)
		{
			return;
		}
		
		if (dealerTotal == playerTotal)
		{
			status = GameStatus.Draw;
		}
		else if (dealerTotal > playerTotal || playerTotal > 21)
		{
			status = GameStatus.DealerWon;
		}
		else
		{
			status = GameStatus.PlayerWon;
		}
	}

	public void Hit()
	{
		if (status != GameStatus.InProgress) return;
		
		var random = new Random();
		
		var playerCardIndex = random.Next(Deck.Count);
		var playerCard = Deck[playerCardIndex];
		Deck.Remove(playerCard);
		PlayerHand.Add(playerCard);
		
		UpdateStatus(false);
	}

	public void Stand()
	{
		if (status == GameStatus.InProgress)
		{
			UpdateStatus(true);
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
