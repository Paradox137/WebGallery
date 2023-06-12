using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace WebGallery.ServiceModule
{
	public static class UIElementVisabilityChecker
	{
		private static int CountCornersVisibleFrom(this RectTransform __rectTransform, RectTransform __mask)
		{
			if (__rectTransform.IsDestroyed() || __mask.IsDestroyed())
				return 0;
			Rect screenBounds = new Rect(__mask.anchoredPosition.x, __mask.anchoredPosition.y, __mask.rect.width, __mask.rect.height);

			Vector3[] maskCorners = new Vector3[4];
			__rectTransform.GetWorldCorners(maskCorners);

			return maskCorners.Count(t => screenBounds.Contains(t));
		}

		public static bool IsVisible(this RectTransform __rectTransform, RectTransform __mask)
		{
			return CountCornersVisibleFrom(__rectTransform, __mask) > 0;
		}
	}
}
