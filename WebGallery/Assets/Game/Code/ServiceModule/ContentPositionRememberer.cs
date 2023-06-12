using UnityEngine;
using UnityEngine.UI;

namespace WebGallery.ServiceModule
{
	public static class ContentPositionRememberer
	{
		public static float PlayerYPosOnContent { get; set; }

		public static void Init(ScrollRect __scrollRect)
		{
			if (PlayerYPosOnContent == 0)
				PlayerYPosOnContent = 1;

			SetContentPosition(__scrollRect);
		}
		private static void SetContentPosition(ScrollRect __scrollRect)
		{
			__scrollRect.normalizedPosition = new Vector2(__scrollRect.normalizedPosition.x, PlayerYPosOnContent);
			Debug.Log(PlayerYPosOnContent);
			Debug.Log(__scrollRect.verticalNormalizedPosition);
		}
	}
}
