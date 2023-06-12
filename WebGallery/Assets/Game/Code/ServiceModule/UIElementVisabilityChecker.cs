using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace WebGallery.ServiceModule
{
	public static class UIElementVisabilityChecker
	{
		private static int CountCornersVisibleFrom(this RectTransform rectTransform, RectTransform mask)
		{
			if (rectTransform.IsDestroyed() || mask.IsDestroyed())
				return 0;
			Rect screenBounds = new Rect(mask.anchoredPosition.x, mask.anchoredPosition.y, mask.rect.width, mask.rect.height);

			Vector3[] maskCorners = new Vector3[4];
			rectTransform.GetWorldCorners(maskCorners);

			return maskCorners.Count(t => screenBounds.Contains(t));
		}

		public static bool IsVisible(this RectTransform rectTransform, RectTransform mask)
		{
			return CountCornersVisibleFrom(rectTransform, mask) > 0;
		}
	}
}
