using UnityEngine;
using System.Collections;
using DraftBuddy.Services;
using DraftBuddy.Models;

namespace DraftBuddy.UI{
	
	public class CardController : MonoBehaviour {

		public ICardRepository cardRepository;
		public ICardImageRepository cardImageRepository;

		private Card card;

		// Use this for initialization
		void Start () {
			//TODO:  DI & remove everything below
			string set = "SOI";
			int setNumber = 2;
			cardRepository = new JsonCardRepository();
			cardImageRepository = new LocalCardImageRepository ();

			card = cardRepository.getCard (set, setNumber);
			Sprite frontSprite = cardImageRepository.getCardFrontSprite (card);

			SpriteRenderer frontRenderer = gameObject.GetComponent<SpriteRenderer> ();
			if(frontSprite != null) {
				frontRenderer.sprite = frontSprite;
			}

			frontSprite = frontRenderer.sprite;

		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}

}
