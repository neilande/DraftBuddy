using UnityEngine;
using System.Collections;
using DraftBuddy.Services;
using DraftBuddy.Models;

namespace DraftBuddy.UI{
	
	public class CardController : MonoBehaviour {

		public ICardRepository cardRepository;
		public ICardImageRepository cardImageRepository;

		private Card card;
		private Sprite frontSprite;
		private Sprite backSprite;

		// Use this for initialization
		void Start () {
			//TODO:  DI & remove everything below
			cardRepository = new JsonCardRepository();
			cardImageRepository = new LocalCardImageRepository ();

//			card = cardRepository.getCard (set, setNumber);
//			frontSprite = cardImageRepository.getCardFrontSprite (card);
//
//			SpriteRenderer frontRenderer = gameObject.GetComponent<SpriteRenderer> ();
//			if(frontSprite != null) {
//				frontRenderer.sprite = frontSprite;
//			}
//
//			frontSprite = frontRenderer.sprite;

			Bounds temp = getWorldBounds ();
			int a = 1;

		}

		public Bounds getWorldBounds()
		{
			Bounds localBounds = gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
			Bounds worldBounds = new Bounds (gameObject.transform.TransformPoint (localBounds.center), gameObject.transform.TransformPoint (localBounds.size) ); 
			return worldBounds;
		}


		public void setCard(string set, int setNumber)
		{
			card = cardRepository.getCard (set, setNumber);
			frontSprite = cardImageRepository.getCardFrontSprite (card);

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
