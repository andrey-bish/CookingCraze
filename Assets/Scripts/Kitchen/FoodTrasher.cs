using UnityEngine;

using JetBrains.Annotations;
using UnityEngine.EventSystems;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour , IPointerClickHandler{

		private FoodPlace _place = null;
		
		private int _clickedCount = 0;
		
		private float _clickTime = 0;
		private float _clickDelay = 0.5f;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_clickTime = Time.time;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// Реализация через таймер
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			
			if ( _place.IsFree ) return;
			
			if ( Time.time - _clickTime > _clickDelay && _clickedCount > 0 ) ResetValues();

			_clickedCount++;

			if ( _clickedCount == 1 ) _clickTime =  Time.time;

			if ( _clickedCount > 1 &&  Time.time - _clickTime < _clickDelay ) {
				ResetValues();
				if ( _place.CurFood.CurStatus == Food.FoodStatus.Overcooked ) _place.FreePlace();
			}
			else if ( _clickedCount > 2 ||  Time.time - _clickTime > _clickDelay ) _clickedCount = 0;
		}

		private void ResetValues() {
			_clickedCount = 0;
			_clickTime = 0;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// Реализация через EventSystems
		/// </summary>
		public void OnPointerClick(PointerEventData eventData) {
			if ( _place.IsFree ) return;
			
			if (eventData.clickCount == 2) {
				if ( _place.CurFood.CurStatus == Food.FoodStatus.Overcooked ) _place.FreePlace();
			}
		}
	}
}
