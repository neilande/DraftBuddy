using System;
using System.Collections;
using UnityEngine;
using DraftBuddy.Models;

//TODO:  want to use sprite textures instead of giant sprites
namespace DraftBuddy.Services
{
	public class LocalCardImageRepository : ICardImageRepository
	{
		public Hashtable loadedImages;

		public LocalCardImageRepository ()
		{			
			loadedImages = new Hashtable ();
		}

		public Sprite getNewCardSprite(Card c)
		{
			Texture2D texture = getCardTexture (c);
			Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 1.00f);
			return newSprite;
		}

		private Texture2D getCardTexture(Card c){
			if (loadedImages [c] == null) {
				
				//byte[] fileData = FileStyleUriP


			}
			return (Texture2D)loadedImages [c];
		}


	}
}

