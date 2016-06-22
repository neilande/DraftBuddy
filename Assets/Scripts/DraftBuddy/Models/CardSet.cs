using System;
using UnityEngine;
using System.Collections;

namespace DraftBuddy.Models
{
	[Serializable]
	public class CardSet : ISerializationCallbackReceiver
	{
		[SerializeField]
		private Card[] cardList;
		[SerializeField]
		private String setName;
		[SerializeField]
		private String imageRoot;

		private Hashtable cardMapping;


		public Card getCard(int setNumber)
		{
			return (Card)cardMapping[setNumber];
		}

		public void OnBeforeSerialize(){}

		public void OnAfterDeserialize()
		{
			cardMapping = new Hashtable ();
			foreach (Card c in cardList) {
				c.setParent (this);
				cardMapping.Add (c.SetNumber, c);
			}
		}

		public String SetName{
			get{ return setName; }
		}

		public String ImageRoot {
			get{ return imageRoot; }
		}



	}
}

