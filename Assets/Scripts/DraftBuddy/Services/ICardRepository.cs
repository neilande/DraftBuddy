using System;
using DraftBuddy.Models;

namespace DraftBuddy.Services
{
	public interface ICardRepository
	{
		Card getCard(String setValue, int setNumber);	
	}
}


