using UnityEngine;
using System.Collections;
using DraftBuddy.Models;
namespace DraftBuddy.UI
{
	public class PackController : MonoBehaviour {

		[SerializeField]
		private Vector2 cameraBufferPct;
		[SerializeField]
		private int cardsPerRow = 8;
		[SerializeField]
		private int rows = 2;

		private Vector3 lowerLeft;
		private Vector3 topRight;

		// Use this for initialization
		void Start () {
			ArrayList cardList = new ArrayList ();
			cardList.Add (1);
			cardList.Add (3);
			cardList.Add (4);
			cardList.Add (5);
			Pack tempPack = new Pack ("SOI", cardList);
			setPack (tempPack);

			lowerLeft = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0));
			topRight = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void setPack(Pack pack)
		{
			float worldSpaceWidth = topRight.x - lowerLeft.x;
			float worldSpaceHeight = topRight.y - lowerLeft.y;
			Vector2 spaceAvailable = new Vector2 (worldSpaceWidth - worldSpaceWidth * cameraBufferPct.x * 2, worldSpaceHeight - worldSpaceHeight * cameraBufferPct.y * 2);

			//TODO:  figure out transform scaling
			//float scaleX = 
			//float scaleY
			GameObject cardPrefab = (GameObject) Instantiate(Resources.Load("Prefabs/CardRenderer"));
			CardController cardController = cardPrefab.GetComponent<CardController> ();



			for(int i = 0; i < pack.setNumbers.Count; i++) {
				int r = (i + 1) / cardsPerRow;
				int c = i % cardsPerRow;

				//create prefab
				GameObject card = (GameObject) Instantiate(cardPrefab);
				card.transform.parent = gameObject.transform;

				//gameObject.AddComponent (card);

				//CardController newCard = new CardController ();
				//newCard.setCard(pack.setValue, pack.setNumbers[i]);

				//set position of cardController

			}
		}


	}
}
