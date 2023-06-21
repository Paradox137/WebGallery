using System;
using UnityEngine;
using WebGallery.UIModule.Components.Transitions;

namespace WebGallery.UIModule.Mediator
{
	public class MenuMediator : MonoBehaviour
	{
		[SerializeField] private ButtonSceneTransition _buttonGalleryTransition;
		
		private void Awake()
		{
			InitTransitionButtons();
			InitApplicationsSettings();
		}
		private void InitApplicationsSettings()
		{
			Screen.orientation = ScreenOrientation.Portrait;
			Application.targetFrameRate = 60;
		}
		private void InitTransitionButtons()
		{
			_buttonGalleryTransition.SubscribeButton();
		}

		private void OnDestroy()
		{
			_buttonGalleryTransition.UnSubscribeButton();
		}
	}
}
