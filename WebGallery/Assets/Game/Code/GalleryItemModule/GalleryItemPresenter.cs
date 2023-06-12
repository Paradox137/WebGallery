using UnityEngine;
using WebGallery.ServiceModule;
using WebGallery.UIModule.Scenes;
using WebGallery.UIModule.Transition;

namespace WebGallery.GalleryItemModule
{
	public class GalleryItemPresenter
	{
		private GalleryItemView _galleryItemView;
		private GalleyItemModel _galleryItemModel;
		private ButtonItemViewSceneCallBack viewSceneCallBack;
		public bool IsLoading { get; set; }

		public void UpdateSerializedPresenter(GalleryItemView __galleryItemView)
		{
			_galleryItemView = __galleryItemView;

			HandleButton();
		}
		public GalleryItemPresenter(GalleryItemView __galleryItemView, GalleyItemModel __galleryItemModel)
		{
			_galleryItemModel = __galleryItemModel;
			_galleryItemView = __galleryItemView;

			HandleButton();
		}

		private void HandleButton()
		{
			if(!_galleryItemModel.IsLoaded)
				_galleryItemView.ButtonViewItemTransition.DisableButton();
			
			viewSceneCallBack = SetTextureToViewService;
			_galleryItemView.ButtonViewItemTransition.SubscribeButton(viewSceneCallBack);
			_galleryItemView.ButtonViewItemTransition.SubscribeButton();
		}
		
		private void SetTextureToViewService()
		{
			ItemViewService.Texture = GetTexture();
		}
		public void SetTexture(Texture2D __itemTexture)
		{
			_galleryItemModel.ItemTexture = __itemTexture;
			_galleryItemModel.IsLoaded = true;

			TryUpdateView();
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

		public void TryUpdateView()
		{
			if (_galleryItemView != null)
			{
				_galleryItemView.ItemImage.texture = _galleryItemModel.ItemTexture;
				_galleryItemView.ButtonViewItemTransition.EnableButton();
			}
		}

		public Texture2D GetTexture()
		{
			return _galleryItemModel.ItemTexture;
		}
		
	}
}
