using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Extensions {
	public static class MyExtension {
		public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
			where TKey : IComparable<TKey>
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (keySelector == null)
				throw new ArgumentNullException(nameof(keySelector));

			using (var enumerator = source.GetEnumerator())
			{
				if (!enumerator.MoveNext())
					throw new InvalidOperationException("Sequence contains no elements");

				var minElement = enumerator.Current;
				var minValue = keySelector(minElement);

				while (enumerator.MoveNext())
				{
					var element = enumerator.Current;
					var value = keySelector(element);

					if (value.CompareTo(minValue) < 0)
					{
						minElement = element;
						minValue = value;
					}
				}

				return minElement;
			}
		}
		
		/// <param name="canvasGroup"></param>
		/// <param name="duration">Duration of fading in, cannot be negative</param>
		/// <param name="delay">Delay before canvas group show, cannot be negative</param>
		/// <param name="callback"></param>
		public static void Show(this CanvasGroup canvasGroup, float duration = 0, float delay = 0,
			Action callback = null)
		{
			if (duration < 0) throw new ArgumentException("Value cannot be negative", nameof(duration));

			if (delay < 0) throw new ArgumentException("Value cannot be negative", nameof(delay));

			canvasGroup.DOKill();
			if (duration == 0 && delay == 0) canvasGroup.alpha = 1;
			canvasGroup.DOFade(1, duration).SetDelay(delay).SetLink(canvasGroup.gameObject).OnComplete(() =>
			{
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				callback?.Invoke();
			});
		}

		/// <param name="canvasGroup"></param>
		/// <param name="duration">Duration of fading out, cannot be negative</param>
		/// <param name="delay">Delay before canvas group hide, cannot be negative</param>
		/// <param name="callback"></param>
		public static void Hide(this CanvasGroup canvasGroup, float duration = 0, float delay = 0,
			Action callback = null)
		{
			if (duration < 0) throw new ArgumentException("Value cannot be negative", nameof(duration));

			if (delay < 0) throw new ArgumentException("Value cannot be negative", nameof(delay));

			canvasGroup.DOKill();
			if (duration == 0 && delay == 0) canvasGroup.alpha = 0;
			canvasGroup.DOFade(0, duration).SetDelay(delay).SetLink(canvasGroup.gameObject).OnStart(() =>
			{
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
			}).OnComplete(() =>
			{
				callback?.Invoke();
			});
		}
	}
}