﻿using UnityEngine;
using UnityEngine.UI;
using WebGallery.UIModule.Components.Transitions;

namespace WebGallery.MVP.GalleryItem
{
	public class GalleryItemView : MonoBehaviour
	{
		[field: SerializeField] private ButtonSceneTransition _buttonViewItemTransition;
		[field: SerializeField] private RectTransform _rectTransform; 
		[field: SerializeField] public RawImage ItemImage { get; set; }
		public ButtonSceneTransition ButtonViewItemTransition => _buttonViewItemTransition;
		public RectTransform RectTransform => _rectTransform;

		public void SetSerializedView(uint __name, Texture2D __texture)
		{
			name = __name.ToString();
			ItemImage.texture = __texture;
		}

		public void SetTexture(Texture2D __texture)
		{
			ItemImage.texture = __texture;
			ButtonViewItemTransition.EnableButton();
		}
	}
}
