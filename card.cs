#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Cards;
using Godot;

namespace Blackjack
{
	namespace Cards
	{
		public enum Suit
		{
			Hearts,
			Diamonds,
			Clubs,
			Spades
		}
		
		public enum Value
		{
			Ace,
			Two,
			Three,
			Four,
			Five,
			Six,
			Seven,
			Eight,
			Nine,
			Ten,
			Jack,
			Queen,
			King
		}
		
		public class PlayingCard
		{
			public readonly Suit Suit;
			public readonly Value Value;
			
			public PlayingCard(Suit suit, Value value)
			{
				Suit = suit;
				Value = value;
			}

			public string GetImageFileName()
			{
				var value = Value switch
				{
					Value.Ace => "ace",
					Value.Two => "two",
					Value.Three => "three",
					Value.Four => "four",
					Value.Five => "five",
					Value.Six => "six",
					Value.Seven => "seven",
					Value.Eight => "eight",
					Value.Nine => "nine",
					Value.Ten => "ten",
					Value.Jack => "jack",
					Value.Queen => "queen",
					Value.King => "king",
					_ => throw new ArgumentOutOfRangeException()
				};

				var suit = Suit switch
				{
					Suit.Hearts => "hearts",
					Suit.Diamonds => "diamonds",
					Suit.Clubs => "clubs",
					Suit.Spades => "spades",
					_ => throw new ArgumentOutOfRangeException()
				};

				return $"{value}_of_{suit}.png";
			}
			
			public static IEnumerable<Suit> GetCardColors()
			{
				return Enum.GetValues(typeof(Suit)).Cast<Suit>();
			}
			
			public static IEnumerable<Value> GetCardValues()
			{
				return Enum.GetValues(typeof(Value)).Cast<Value>();
			}
		}

		public class Hand : List<PlayingCard>
		{
			public int GetCardTotal()
			{
				var result = 0;

				var aces = new List<PlayingCard>();
				
				foreach (var card in this)
				{
					switch (card.Value)
					{
						case Value.Ace:
							aces.Add(card);
							break;
						case Value.Two:
							result += 2;
							break;
						case Value.Three:
							result += 3;
							break;
						case Value.Four:
							result += 4;
							break;
						case Value.Five:
							result += 5;
							break;
						case Value.Six:
							result += 6;
							break;
						case Value.Seven:
							result += 7;
							break;
						case Value.Eight:
							result += 8;
							break;
						case Value.Nine:
							result += 9;
							break;
						case Value.Ten:
						case Value.Jack:
						case Value.Queen:
						case Value.King:
							result += 10;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}

				foreach (var card in aces)
				{
					if (result + 10 <= 21)
					{
						result += 10;
					}
					else
					{
						result += 1;
					}
				}
				
				return result;
			}
		}

		public class Deck : Hand
		{
			public Deck()
			{
				foreach (var cardColor in PlayingCard.GetCardColors())
				{
					foreach (var cardValue in PlayingCard.GetCardValues())
					{
						Add(new PlayingCard(cardColor, cardValue));
					}
				}
			}
		}
	}

	public partial class card : TextureRect
	{
		public PlayingCard? Card;
		
		public card(PlayingCard? card)
		{
			SetCard(card);
			ExpandMode = ExpandModeEnum.IgnoreSize;
			StretchMode = StretchModeEnum.KeepAspectCentered;
			CustomMinimumSize = new Vector2(100, 100);
		}

		public void SetCard(PlayingCard? card)
		{
			Card = card;
			
			if (card != null)
			{
				Texture = (Texture2D)GD.Load($"res://cards/{card.GetImageFileName()}");	
			}
			else
			{
				Texture = (Texture2D)GD.Load("res://cards/back.png");
			}
		}
	}
}
