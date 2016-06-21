using System;
using UnityEngine;

namespace DraftBuddy.Models
{
	[Serializable]
	public class Card : ISerializationCallbackReceiver
	{
		[SerializeField]
		private int setNumber;

		private String setValue;

		private Boolean isDfc;

		[SerializeField]
		private String frontImagePath;

		[SerializeField]
		private String backImagePath;

//		public Card (int setNumber, String setValue, String frontImagePath){
//			_setNumber = setNumber;
//			_setValue = setValue;
//			_isDfc = false;
//			_frontImagePath = frontImagePath;
//		}
//
//		public Card(int setNumber, String setValue, String frontImagePath, String backImagePath){
//			_setNumber = setNumber;
//			_setValue = setValue;
//			if (backImagePath != null) {
//				_isDfc = true;
//			} else {
//				_isDfc = false;
//			}
//			_frontImagePath = frontImagePath;
//			_backImagePath = backImagePath;
//		}
		public void OnBeforeSerialize(){}

		public void OnAfterDeserialize()
		{
			if (backImagePath != null) {
				isDfc = true;
			} else {
				isDfc = false;
			}
		}

		public void setParent(CardSet parent)
		{
			setValue = parent.SetName;
		}

		public int SetNumber{
			get{ return setNumber; }
		}

		public String SetValue{
			get{ return setValue; }
		}

		public Boolean IsDfc{
			get{ return isDfc; }
		}

		public String FrontImagePath {
			get{ return frontImagePath; }
		}

		public String BackImagePath{
			get{ return backImagePath; }
		}
	}
}

