using System.Collections.Generic;
using UnityEngine;
using WebGallery.GalleryItemModule;

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
					itemView.UpdateSerializedView(counter, GalleryItemPresenters[i].GetTexture());
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
	}
}
