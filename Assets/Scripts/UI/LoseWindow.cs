using UnityEngine.UI;
using  CookingPrototype.Controllers;

namespace CookingPrototype.UI {
	public sealed class LoseWindow : WindowBase {
		
		public Button   ReplayButton = null;
		public Button   ExitButton   = null;
		public Button   CloseButton  = null;


		protected override void Init() {
			var gc = GameplayController.Instance;

			ReplayButton.onClick.AddListener(gc.Restart);
			ExitButton  .onClick.AddListener(gc.CloseGame);
			CloseButton .onClick.AddListener(gc.CloseGame);
			base.Init();
		}
	}
}
