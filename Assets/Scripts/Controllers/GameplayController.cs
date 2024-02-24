using System;

using UnityEngine;

using CookingPrototype.Kitchen;
using CookingPrototype.UI;

using JetBrains.Annotations;

namespace CookingPrototype.Controllers {
	public sealed class GameplayController : MonoBehaviour {
		public static GameplayController Instance { get; private set; }

		[SerializeField] private GameObject _tapBlock;
		[SerializeField] private SceneUI _sceneUI;
		[SerializeField] private TopUI _topUI;

		private int _ordersTarget = 0;

		public int OrdersTarget {
			get => _ordersTarget;
			set {
				_ordersTarget = value;
				TotalOrdersServedChanged?.Invoke();
			}
		}

		public int        TotalOrdersServed { get; private set; } = 0;

		public event Action TotalOrdersServedChanged;

		void Awake() {
			if ( Instance != null ) {
				Debug.LogError("Another instance of GameplayController already exists");
			}
			Instance = this;
		}

		private void Start() {
			StartLevel();
		}

		void OnDestroy() {
			if ( Instance == this ) {
				Instance = null;
			}
		}

		private void StartLevel() {
			_sceneUI.WinWindow.Hide(true);
			_sceneUI.LoseWindow.Hide(true);
			CustomersController.Instance.Init();
			_topUI.Hide(true);
			_sceneUI.StartWindow.Show(true);
			Time.timeScale = 0f;
		}

		void Init() {
			StartLevel();
			TotalOrdersServed = 0;
			Time.timeScale = 1f;
			TotalOrdersServedChanged?.Invoke();
		}

		public void CheckGameFinish() {
			if ( CustomersController.Instance.IsComplete ) {
				EndGame(TotalOrdersServed >= OrdersTarget);
			}
		}

		void EndGame(bool win) {
			_tapBlock.SetActive(true);
			if ( win ) {
				_sceneUI.WinWindow.Show(onComplete: () => Time.timeScale = 0f);
			} else {
				_sceneUI.LoseWindow.Show(onComplete: () => Time.timeScale = 0f);
			}
		}

		void HideWindows() {
			_tapBlock.SetActive(false);
			_sceneUI.WinWindow.Hide(true);
			_sceneUI.LoseWindow.Hide(true);
		}

		[UsedImplicitly]
		public bool TryServeOrder(Order order) {
			if ( !CustomersController.Instance.ServeOrder(order) ) {
				return false;
			}

			TotalOrdersServed++;
			TotalOrdersServedChanged?.Invoke();
			CheckGameFinish();
			return true;
		}

		public void StartGame() {
			_topUI.Show();
			_sceneUI.StartWindow.Hide();
			Time.timeScale = 1f;
		}

		public void Restart() {
			HideWindows();
			Init();

			foreach ( var place in FindObjectsOfType<AbstractFoodPlace>() ) {
				place.FreePlace();
			}
		}

		public void CloseGame() {
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}
