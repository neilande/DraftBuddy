using UnityEngine;
using System.Collections;
using DraftBuddy.Models;
namespace DraftBuddy.UI
{
	public class PackController : MonoBehaviour {

		[SerializeField]
		private Vector2 cameraBufferPct;

		[SerializeField]
		private Vector2 minCardDistancePct;

		[SerializeField]
		private int cardsPerRow = 5;
		[SerializeField]
		private int rows = 3;

		private Vector3 lowerLeft;
		private Vector3 topRight;

		private ArrayList cardObjects;

		// Use this for initialization
		void Start () {
			ArrayList cardList = new ArrayList ();
			cardList.Add (1);
			cardList.Add (3);
			cardList.Add (4);
			cardList.Add (5);
			cardList.Add (1);
			cardList.Add (2);
			cardList.Add (3);
			cardList.Add (4);
			cardList.Add (1);

			lowerLeft = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0));
			topRight = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
			//lowerLeft.y = (lowerLeft.y + topRight.y) / 2;

			cardObjects = new ArrayList ();
			Pack tempPack = new Pack ("SOI", cardList);
			setPack (tempPack);
			positionAndScaleCards();

		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void positionAndScaleCards()
		{
			if (cardObjects.Count == 0) {
				return;
			}
			GameObject firstCard = (GameObject)cardObjects [0];
			float worldSpaceWidth = topRight.x - lowerLeft.x;
			float worldSpaceHeight = topRight.y - lowerLeft.y;
			Vector2 spaceAvailable = new Vector2 (worldSpaceWidth - worldSpaceWidth * cameraBufferPct.x * 2, worldSpaceHeight - worldSpaceHeight * cameraBufferPct.y * 2);

			CardController cardController = firstCard.GetComponent<CardController> ();

			Bounds cardBounds = cardController.getWorldBounds ();
			float scaleX = ((spaceAvailable.x / (float)cardsPerRow) - worldSpaceWidth * minCardDistancePct.x) / Mathf.Abs(cardBounds.max.x - cardBounds.min.x);
			float scaleY = ((spaceAvailable.y / (float)rows) - worldSpaceHeight * minCardDistancePct.y) / Mathf.Abs(cardBounds.max.y - cardBounds.min.y);
			float cardScale = Mathf.Min (scaleX, scaleY);
			Vector2 cardDimensions = new Vector2 (Mathf.Abs (cardBounds.max.x - cardBounds.min.x), Mathf.Abs (cardBounds.max.y - cardBounds.min.y)) * cardScale;
			Vector3 transformScale = firstCard.transform.localScale * cardScale;

			for (int i = 0; i < cardObjects.Count; i++)
			{
				int r = (i) / cardsPerRow;
				int c = i % cardsPerRow;
				GameObject card = (GameObject) cardObjects [i];
				card.transform.localScale = transformScale;
				card.transform.localPosition = new Vector3 (lowerLeft.x + worldSpaceWidth * cameraBufferPct.x + cardDimensions.x / 2.0f + c * spaceAvailable.x / cardsPerRow,
					topRight.y - (worldSpaceHeight * cameraBufferPct.y + cardDimensions.y / 2.0f + r * spaceAvailable.y / rows));	
			}
		}

		public void setPack(Pack pack)
		{
			GameObject cardPrefab = (GameObject) Instantiate(Resources.Load("Prefabs/CardRenderer"));
			for(int i = 0; i < pack.setNumbers.Count; i++) {
				//create prefab
				GameObject card = (GameObject) Instantiate(cardPrefab);
				card.transform.parent = gameObject.transform;
				card.name = "Card " + i;

				//set card
				CardController cardController = card.GetComponent<CardController>();
				cardController.setCard (pack.setValue, (int)pack.setNumbers[i]);
				cardObjects.Add (card);
			}

			Destroy (cardPrefab);
		}
	}
}
