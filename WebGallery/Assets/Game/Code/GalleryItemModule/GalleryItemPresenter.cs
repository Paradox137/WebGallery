using UnityEngine;
using WebGallery.UIModule.Scenes;
using WebGallery.UIModule.Transition;

namespace WebGallery.GalleryItemModule
{
	public class GalleryItemPresenter
	{
		private GalleryItemView _galleryItemView;
		private GalleyItemModel _galleryItemModel;
		public bool IsLoading { get; set; }

		public void UpdateSerializedPresenter(GalleryItemView __galleryItemView)
		{
			_galleryItemView = __galleryItemView;
			_galleryItemView.ButtonViewItemTransition.SubscribeButton();
		}
		public GalleryItemPresenter(GalleryItemView __galleryItemView, GalleyItemModel __galleryItemModel)
		{
			_galleryItemModel = __galleryItemModel;
			_galleryItemView = __galleryItemView;
			
			_galleryItemView.ButtonViewItemTransition.SubscribeButton();
			_galleryItemView.ButtonViewItemTransition.DisableButton();
		}
		
		public void SetTexture(Texture2D __itemTexture)
		{
			_galleryItemModel.ItemTexture = __itemTexture;
			_galleryItemModel.IsLoaded = true;

			UpdateView();
		}

		public RectTransform GetRectTransform()
		{
			return _galleryItemView.RectTransform;
		}

		public bool IsLoaded()
		{
			return _galleryItemModel.IsLoaded;
		}
		public uint GetID()
		{
			return _galleryItemModel.Id;
		}

		public void UpdateView()
		{
			_galleryItemView.ItemImage.texture = _galleryItemModel.ItemTexture;
			_galleryItemView.ButtonViewItemTransition.EnableButton();
		}

		public Texture2D GetTexture()
		{
			return _galleryItemModel.ItemTexture;
		}
		
	}
}
