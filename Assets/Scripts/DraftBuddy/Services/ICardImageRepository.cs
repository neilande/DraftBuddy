using System;
using DraftBuddy.Models;
using UnityEngine;

namespace DraftBuddy.Services
{
	public interface ICardImageRepository
	{
		Sprite getCardFrontSprite(Card c);

		Sprite getCardBackSprite(Card c);
	}
}



