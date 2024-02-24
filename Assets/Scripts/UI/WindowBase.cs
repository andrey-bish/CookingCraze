using System;
using CookingPrototype.Controllers;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CookingPrototype.UI {
	public class WindowBase : MonoBehaviour {
		[SerializeField] private  Image    _goalBar;
		[SerializeField] protected  TMP_Text    _goalText;
		[SerializeField] private  CanvasGroup    _canvasGroup;
		
		[SerializeField] private float _duration = 0.25f;
		
		bool _isInit = false;

		protected virtual void Init() {
			_isInit = true;
		}

		public void Show (bool isForce = false, Action onComplete = null) {
			if ( !_isInit ) Init();

			SetProgress();
			
			if ( isForce ) _canvasGroup.Show(callback:onComplete);
			else _canvasGroup.Show(_duration, callback:onComplete);
		}

		protected virtual void SetProgress() {
			var gc = GameplayController.Instance;
			_goalText.text      = $"{gc.TotalOrdersServed}/{gc.OrdersTarget}";
			_goalBar.fillAmount = Mathf.Clamp01((float) gc.TotalOrdersServed / gc.OrdersTarget);
		}

		public void Hide(bool isForce = false) {
			if ( isForce ) _canvasGroup.Hide();
			else _canvasGroup.Hide(_duration);
		}
	}
}