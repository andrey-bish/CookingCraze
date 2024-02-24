using UnityEngine;
using UnityEngine.UI;

using CookingPrototype.Controllers;
using Extensions;
using TMPro;

namespace CookingPrototype.UI {
	public sealed class TopUI : MonoBehaviour {
		public Image    OrdersBar          = null;
		public CanvasGroup CanvasGroup     = null;
		public TMP_Text OrdersCountText    = null;
		public TMP_Text CustomersCountText = null;

		[SerializeField] private float _duration = 0.25f;

		void Start() {
			GameplayController .Instance.TotalOrdersServedChanged       += OnOrdersChanged;
			CustomersController.Instance.TotalCustomersGeneratedChanged += OnCustomersChanged;
			OnOrdersChanged();
			OnCustomersChanged();
		}

		void OnDestroy() {
			if ( GameplayController.Instance ) {
				GameplayController.Instance.TotalOrdersServedChanged -= OnOrdersChanged;
			}

			if ( CustomersController.Instance ) {
				CustomersController.Instance.TotalCustomersGeneratedChanged -= OnCustomersChanged;
			}
		}

		public void Show(bool isForce = false) {
			if ( isForce ) CanvasGroup.Show();
			else CanvasGroup.Show(_duration);
		}

		public void Hide(bool isForce = false) {
			if ( isForce ) CanvasGroup.Hide();
			else CanvasGroup.Hide(_duration);
		}

		void OnCustomersChanged() {
			var cc = CustomersController.Instance;
			CustomersCountText.text = (cc.CustomersTargetNumber - cc.TotalCustomersGenerated).ToString();
		}

		void OnOrdersChanged() {
			var gc = GameplayController.Instance;
			OrdersCountText.text = $"{gc.TotalOrdersServed}/{gc.OrdersTarget}";
			OrdersBar.fillAmount = (float) gc.TotalOrdersServed / gc.OrdersTarget;
		}
	}
}
