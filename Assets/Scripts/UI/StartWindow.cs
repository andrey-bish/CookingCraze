using CookingPrototype.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace CookingPrototype.UI {
	public class StartWindow : WindowBase {
		[SerializeField] private Button _playButton;
		
		protected override void Init() {
			var gc = GameplayController.Instance;
			_playButton.onClick.AddListener(gc.StartGame);
			base.Init();
		}

		protected override void SetProgress() {
			var gc = GameplayController.Instance;
			_goalText.text      = $"{0}/{gc.OrdersTarget}";
		}
	}
}