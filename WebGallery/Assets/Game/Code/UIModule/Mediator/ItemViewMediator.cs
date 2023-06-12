using System;
using UnityEngine;
using UnityEngine.UI;
using WebGallery.ServiceModule;
using WebGallery.UIModule.Transition;

namespace WebGallery.UIModule.Mediator
{
	public class ItemViewMediator : MonoBehaviour
	{
		[SerializeField] private ButtonSceneTransition _buttonGalleryTransition;
		[SerializeField] private RawImage _image;
		private void Awake()
		{
			InitApplicationsSettings();
			InitTransitionButtons();
		}
		private void Start()
		{
			ItemViewService.ChangeView(_image);
		}
		private void InitApplicationsSettings()
		{
			Screen.orientation = ScreenOrientation.AutoRotation;
		}
		private void InitTransitionButtons()
		{
			_buttonGalleryTransition.SubscribeButton();
		}
	}
}
