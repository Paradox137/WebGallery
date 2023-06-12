using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using WebGallery.CollectionModule;
using WebGallery.GalleryItemModule;
using WebGallery.ServiceModule;
using WebGallery.UIModule.Components.Scenes;
using WebGallery.UIModule.Components.Scroll;

namespace WebGallery.UIModule.Mediator
{
	public delegate void OnScrollCallBack(Vector2 pos);
	public class GalleryMediator : MonoBehaviour
	{
		[SerializeField] private ProgressSceneLoader _gallerySceneLoader;
		[SerializeField] private ScrollRectContent _galleryContent;
		
		private OnScrollCallBack _onScrollGalleryCallBack;
		private void Awake()
		{
			InitComponents();
			InitCollections();
			InitServices();
		}
		
		private void Start()
		{
			CheckFirstItemsVisability();
		}

		#region Initialization
		private void InitComponents()
		{
			_gallerySceneLoader.ShowSceneLoader();
			
			_onScrollGalleryCallBack = OnScrollGallery;
			_galleryContent.Init(_onScrollGalleryCallBack);
		}
		private void InitServices()
		{
			ItemsLoader.Init(this);
		}
		private void InitCollections()
		{
			GalleryItemsCollection.InitGalleryCollection(_galleryContent.Content, _galleryContent.GameObject);
		}
		#endregion

		#region GalleryItems
		private void OnScrollGallery(Vector2 __vector2)
		{
			CheckItemsVisabilityOnScroll();
		}
		private async void CheckItemsVisabilityOnScroll()
		{
			foreach (var galleryItem in GalleryItemsCollection.GalleryItemPresenters)
			{
				if (!galleryItem.IsLoading && !galleryItem.IsLoaded() && galleryItem.GetRectTransform().IsVisible(_galleryContent.Viewport))
				{
					galleryItem.IsLoading = true;
					Texture texture = await ItemsLoader.DownloadItem(galleryItem.GetID());
					galleryItem.SetTexture(texture);
				}
			}
		}
		private async void CheckFirstItemsVisability()
		{
			Canvas.ForceUpdateCanvases();
			
			if (GalleryItemsCollection.IsCreated)
			{
				foreach (var galleryItem in GalleryItemsCollection.GalleryItemPresenters)
				{
					if (galleryItem.IsLoaded())
					{
						galleryItem.UpdateTexture();
					}
				}
				_gallerySceneLoader.HideSceneLoader();
				
				return;
			}
			
			List<uint> itemsIDs = new List<uint>(); 
			
			foreach (var galleryItem in GalleryItemsCollection.GalleryItemPresenters)
			{
				if (galleryItem.GetRectTransform().IsVisible(_galleryContent.Viewport))
				{
					Debug.Log(galleryItem.GetID());
					itemsIDs.Add(galleryItem.GetID());
				}
			}
			
			List<Texture> textures = await ItemsLoader.DownloadMultipleItems(itemsIDs.ToArray());

			for (int i = 0; i < textures.Count; i++)
			{
				GalleryItemsCollection.GalleryItemPresenters[i].SetTexture(textures[i]);
			}
			
			_gallerySceneLoader.HideSceneLoader();
			
			GalleryItemsCollection.IsCreated = true;
		}
		public void NotifyLoadProgressUpdate(float __value)
		{
			_gallerySceneLoader.ChangeProgressBarValue(__value);
		}
		#endregion
	}
}
