using UnityEngine;
using UnityEngine.UI;
using WebGallery.ServiceModule;
using WebGallery.UIModule.Transition;

namespace WebGallery.GalleryItemModule
{
	public class GalleryItemView : MonoBehaviour
	{
		[field: SerializeField] private ButtonSceneTransition _buttonViewItemTransition;
		[field: SerializeField] private RectTransform _rectTransform; 
		[field: SerializeField] public RawImage ItemImage { get; set; }
		public ButtonSceneTransition ButtonViewItemTransition => _buttonViewItemTransition;
		public RectTransform RectTransform => _rectTransform;

		public void UpdateSerializedView(uint __name, Texture __texture)
		{
			this.name = __name.ToString();
			ItemImage.texture = __texture;
		}
	}
}
