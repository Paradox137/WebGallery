using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebGallery.ServiceModule;
using WebGallery.UIModule.Components.Scenes;
using WebGallery.UIModule.Components.Transitions;

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
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				SceneManager.LoadScene((int)WebGalleryScenes.Gallery);
			}
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
