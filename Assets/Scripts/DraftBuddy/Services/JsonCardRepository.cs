using System;
using DraftBuddy.Models;
using System.Collections;
using UnityEngine;
using UnityEngineInternal;

namespace DraftBuddy.Services
{
	public class JsonCardRepository : ICardRepository
	{
		private Hashtable _cardSets;
		private SetConfig _setConfig;

		public JsonCardRepository ()
		{
			_cardSets = new Hashtable ();	
			TextAsset setInfo = Resources.Load<TextAsset> ("Sets/Sets");
			_setConfig = JsonUtility.FromJson<SetConfig>(setInfo.text);
		}

		public Card getCard(String setValue, int setNumber)
		{
			if (!_cardSets.Contains (setValue)) {
				loadSet (setValue);
			}
			return  ((CardSet)_cardSets [setValue]).getCard (setNumber);		
		}

		private void loadSet(String setValue)
		{
			if (!_cardSets.ContainsKey (setValue)) {
				String setFile =  _setConfig.getSetFile (setValue).Replace(".json", "");
				TextAsset setJson = Resources.Load<TextAsset> (setFile);

				CardSet newSet = JsonUtility.FromJson<CardSet> (setJson.text);
				_cardSets.Add (setValue, newSet);
			}
		}
	}

	[Serializable]
	public class SetConfig : ISerializationCallbackReceiver
	{
		public SetConfigEntry[] sets;

		private Hashtable nameToFileMap;

		public void OnAfterDeserialize (){
			nameToFileMap = new Hashtable ();
			foreach (SetConfigEntry entry in sets) {
				nameToFileMap.Add (entry.setName, entry.setFile);
			}
		}

		public void OnBeforeSerialize () {}

		public String getSetFile(String setName)
		{
			if(nameToFileMap.ContainsKey(setName)){
				return (String)nameToFileMap[setName];
			}
			return "";
		}
	}

	[Serializable]
	public class SetConfigEntry
	{
		public String setName;
		public String setFile;
	}
}


