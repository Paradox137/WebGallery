using System;
using UnityEngine;
using UnityEngine.UI;
using WebGallery.CollectionModule;
using WebGallery.ServiceModule;
using WebGallery.UIModule.Mediator;

namespace WebGallery.UIModule.Components.Scroll
{
	[Serializable]
	public struct ScrollRectContent
	{
		[field: SerializeField] public RectTransform Content { get; private set; }
		[field: SerializeField] public RectTransform Viewport { get; private set; }
		[field: SerializeField] public GameObject GameObject { get; private set; }
		[field: SerializeField] public ScrollRect ScrollRect { get; private set; }

		public void Init(OnScrollCallBack __scrollCallBack)
		{
			SubscribeScrollRect(__scrollCallBack);
		}
		
		public void SubscribeScrollRect(OnScrollCallBack __scrollCallBack)
		{
			ScrollRect.onValueChanged.AddListener(__scrollCallBack.Invoke);
		}

		public void UnSubscribeScrollRect()
		{
			ScrollRect.onValueChanged.RemoveAllListeners();
		}
		
		public async void CheckItemsVisabilityOnScroll()
		{
			foreach (var galleryItem in GalleryItemsCollection.GalleryItemPresenters)
			{
				if (!galleryItem.IsLoading && !galleryItem.IsLoaded() && galleryItem.GetRectTransform().IsVisible(Viewport))
				{
					galleryItem.IsLoading = true;
					Texture2D texture = await ItemsLoader.DownloadItem(galleryItem.GetID());
					galleryItem.SetTexture(texture);
				}
			}
		}
	}
}
