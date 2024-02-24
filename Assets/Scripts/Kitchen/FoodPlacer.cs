using UnityEngine;

using System.Collections.Generic;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	public sealed class FoodPlacer : MonoBehaviour {
		public string                  FoodName = string.Empty;
		public bool IsInit = false;
		public List<AbstractFoodPlace> Places   = new List<AbstractFoodPlace>();

		private void Start() {
			if(IsInit) foreach ( var place in Places ) { place.Init(FoodName); } 
		}

		[UsedImplicitly]
		public void TryPlaceFood() {
			foreach ( var place in Places ) {
				if ( place.TryPlaceFood(new Food(FoodName)) ) {
					return;
				}
			}
		}
	}
}
