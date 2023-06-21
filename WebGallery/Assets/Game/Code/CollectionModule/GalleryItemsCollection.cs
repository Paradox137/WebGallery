using System.Collections.Generic;
using UnityEngine;
using WebGallery.MVP.GalleryItem;
using WebGallery.ServiceModule;
using WebGallery.UIModule.Components.Scroll;

namespace WebGallery.CollectionModule
{
	public static class GalleryItemsCollection
	{
		public static List<GalleryItemPresenter> GalleryItemPresenters { get; private set; }
		
		private const int ItemsNumber = 66;
		public static bool IsCreated { get; set; }
		
		public static void InitGalleryCollection(RectTransform __itemsContent, GameObject __itemGameObject)
		{
			if(!IsCreated)
				CreateCollection(__itemsContent, __itemGameObject);
			else
			{
				uint counter = 0;
				
				for (int i = 0; i < ItemsNumber; i++)
				{
					GalleryItemView itemView = Object.Instantiate(__itemGameObject, __itemsContent).GetComponent<GalleryItemView>();
					counter++;
					itemView.SetSerializedView(counter, GalleryItemPresenters[i].GetTexture());
					GalleryItemPresenters[i].UpdateSerializedPresenter(itemView);
				}
			}
		}
		
		private static void CreateCollection(RectTransform __itemsContent, GameObject __itemGameObject)
		{
			uint counter = 0;
			
			GalleryItemPresenters = new List<GalleryItemPresenter>(ItemsNumber);
			
			for (int i = 0; i < ItemsNumber; i++)
			{
				GalleryItemView itemView = Object.Instantiate(__itemGameObject, __itemsContent).GetComponent<GalleryItemView>();
				counter++;
				
				GalleyItemModel itemModel = new GalleyItemModel();
				itemModel.Id = counter;

				itemView.name = counter.ToString();

				GalleryItemPresenter itemPresenter = new GalleryItemPresenter(itemView, itemModel);
				GalleryItemPresenters.Add(itemPresenter);
			}
		}

		public static void UpdateCollectionView()
		{
			foreach (var galleryItem in GalleryItemsCollection.GalleryItemPresenters)
			{
				if (galleryItem.IsLoaded())
				{
					galleryItem.TryUpdateView();
				}
			}
		}

		public static List<uint> GetVisibleItemsID(ScrollRectContent __galleryContent)
		{
			List<uint> itemsIDs = new List<uint>(); 
			
			foreach (var galleryItem in GalleryItemsCollection.GalleryItemPresenters)
			{
				if (galleryItem.GetRectTransform().IsVisible(__galleryContent.Viewport))
				{
					Debug.Log(galleryItem.GetID());
					itemsIDs.Add(galleryItem.GetID());
				}
			}

			return itemsIDs;
		}
	}
}
