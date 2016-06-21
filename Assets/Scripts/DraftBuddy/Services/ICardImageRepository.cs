using System;
using DraftBuddy.Models;
using UnityEngine;

namespace DraftBuddy.Services
{
	public interface ICardImageRepository
	{
		Sprite getNewCardSprite(Card c);
	}
}



