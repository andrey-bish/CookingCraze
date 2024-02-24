using UnityEngine;

namespace CookingPrototype.UI {
	public class SceneUI : MonoBehaviour {
		[SerializeField] private LoseWindow _loseWindow;
		[SerializeField] private WinWindow _winWindow;
		[SerializeField] private StartWindow _startWindow;

		public LoseWindow LoseWindow => _loseWindow;
		public WinWindow WinWindow => _winWindow;
		public StartWindow StartWindow => _startWindow;
	}
}