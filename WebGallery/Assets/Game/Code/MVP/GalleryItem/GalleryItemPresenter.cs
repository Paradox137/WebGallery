using UnityEngine;
using WebGallery.ServiceModule;
using WebGallery.UIModule.Components.Transitions;

namespace WebGallery.MVP.GalleryItem
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

		~GalleryItemPresenter()
		{
			_galleryItemView.ButtonViewItemTransition.UnSubscribeButton();
		}
		
		private void HandleButton()
		{
			if(!_galleryItemModel.IsLoaded)
				_galleryItemView.ButtonViewItemTransition.DisableButton();
			
			viewSceneCallBack = SetTextureToViewService;
			_galleryItemView.ButtonViewItemTransition.SubscribeButton(viewSceneCallBack);
			_galleryItemView.ButtonViewItemTransition.SubscribeButton();
		}
		
		private void SetTextureToViewService() =>ItemViewService.Texture = GetTexture();
		public RectTransform GetRectTransform() => _galleryItemView.RectTransform;
		public bool IsLoaded() => _galleryItemModel.IsLoaded;
		public uint GetID() => _galleryItemModel.Id;
		public Texture2D GetTexture() =>  _galleryItemModel.ItemTexture;
		
		public void TryUpdateView()
		{
			if (_galleryItemView != null)
				_galleryItemView.SetTexture(_galleryItemModel.ItemTexture);
		}

		public void SetTexture(Texture2D __itemTexture)
		{
			_galleryItemModel.ItemTexture = __itemTexture;
			_galleryItemModel.IsLoaded = true;

			TryUpdateView();
		}
		
	}
}
