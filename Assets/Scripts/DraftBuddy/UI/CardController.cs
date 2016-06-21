using UnityEngine;
using System.Collections;
using DraftBuddy.Services;
using DraftBuddy.Models;

namespace DraftBuddy.UI{
	
	public class CardController : MonoBehaviour {

		public ICardRepository cardRepository;

		// Use this for initialization
		void Start () {
			//TODO:  DI & remove everything below
			string set = "SOI";
			int setNumber = 5;
			cardRepository = new JsonCardRepository();
			Card c = cardRepository.getCard (set, setNumber);

		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}

}
