﻿using UnityEngine;
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
		}
		
		public void SetTexture(Texture __itemTexture)
		{
			_galleryItemModel.ItemTexture = __itemTexture;
			_galleryItemModel.IsLoaded = true;

			UpdateTexture();
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

		public void UpdateTexture()
		{
			_galleryItemView.ItemImage.texture = _galleryItemModel.ItemTexture;
		}

		public Texture GetTexture()
		{
			return _galleryItemModel.ItemTexture;
		}
		
	}
}