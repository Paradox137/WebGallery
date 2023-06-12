using UnityEngine.UI;

namespace WebGallery.ServiceModule
{
	public static class ContentPositionRememberer
	{
		public static float PlayerYPosOnContent { get; set; }

		public static void SetContentPosition(ScrollRect __scrollRect)
		{
			__scrollRect.verticalNormalizedPosition = PlayerYPosOnContent;
		}
	}
}
