using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebGallery.CollectionModule;
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

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				SceneManager.LoadScene((int)WebGalleryScenes.Menu);
			}
		}
		private void Awake()
		{
			InitApplicationsSettings();
		}
		
		private void Start()
		{
			InitComponents();
			InitCollections();
			Canvas.ForceUpdateCanvases();
			InitServices();
			CheckFirstItemsVisability();
		}

		#region Initialization
		private void InitApplicationsSettings()
		{
			Screen.orientation = ScreenOrientation.Portrait;
		}
		private void InitComponents()
		{
			_gallerySceneLoader.ShowSceneLoader();
			
			_onScrollGalleryCallBack = OnScrollGallery;
			_galleryContent.Init(_onScrollGalleryCallBack);
		}
		private void InitServices()
		{
			ItemsLoader.Init(this);
			ContentPositionRememberer.Init(_galleryContent.ScrollRect);
		}
		private void InitCollections()
		{
			GalleryItemsCollection.InitGalleryCollection(_galleryContent.Content, _galleryContent.GameObject);
		}
		#endregion

		#region GalleryItems
		private void OnScrollGallery(Vector2 __vector2)
		{
			ContentPositionRememberer.PlayerYPosOnContent = __vector2.y;
			
			_galleryContent.CheckItemsVisabilityOnScroll();
		}
		private async void CheckFirstItemsVisability()
		{
			if (GalleryItemsCollection.IsCreated)
			{
				GalleryItemsCollection.UpdateCollectionView();
				_gallerySceneLoader.HideSceneLoader();
				return;
			}

			List<uint> itemsIDs = GalleryItemsCollection.GetVisibleItemsID(_galleryContent);
			
			List<Texture2D> textures = await ItemsLoader.DownloadMultipleItems(itemsIDs.ToArray());

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

		private void OnDestroy()
		{
			_galleryContent.UnSubscribeScrollRect();
		}
	}
}
