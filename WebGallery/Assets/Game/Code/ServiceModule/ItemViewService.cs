using UnityEngine;
using UnityEngine.UI;

namespace WebGallery.ServiceModule
{
	public static class ItemViewService
	{
		public static Texture2D Texture { get; set; }

		public static void ChangeView(RawImage __rawImage)
		{
			__rawImage.texture = Texture;
		}
	}
}
