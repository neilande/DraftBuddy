using System;
using System.Collections;
using UnityEngine;
using DraftBuddy.Models;
using System.IO;


//TODO:  want to use sprite textures instead of giant sprites
namespace DraftBuddy.Services
{
	public class LocalCardImageRepository : ICardImageRepository
	{
		public Hashtable loadedTextures;

		public LocalCardImageRepository ()
		{			
			loadedTextures = new Hashtable ();
		}

		public Sprite getCardFrontSprite(Card c)
		{
			return Resources.Load<Sprite> (c.FrontImagePath);
		}

		public Sprite getCardBackSprite(Card c)
		{
			return Resources.Load<Sprite> (c.BackImagePath);
		}

		private Texture2D getCardTexture(String imagePath){
			if (loadedTextures [imagePath] == null) {
				String filePath = Application.dataPath + "/" + imagePath;
				if (!File.Exists (filePath)) {
					return null;
				}
				byte[] fileData = File.ReadAllBytes (filePath);
				Texture2D tex = new Texture2D (2, 2);
				tex.LoadImage (fileData);
				loadedTextures.Add (imagePath, tex);
			}
			return (Texture2D)loadedTextures [imagePath];
		}


	}
}

