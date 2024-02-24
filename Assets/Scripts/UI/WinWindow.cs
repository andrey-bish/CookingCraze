using UnityEngine.UI;
using CookingPrototype.Controllers;

namespace CookingPrototype.UI {
	public sealed class WinWindow : WindowBase {
		public Button   OkButton    = null;
		public Button   CloseButton = null;

		protected override void Init() {
			var gc = GameplayController.Instance;

			OkButton   .onClick.AddListener(gc.CloseGame);
			CloseButton.onClick.AddListener(gc.CloseGame);
			base.Init();
		}
	}
}
