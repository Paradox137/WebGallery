using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebGallery.UIModule.Scenes;

namespace WebGallery.UIModule.Transition
{
	[Serializable]
	public struct ButtonSceneTransition
	{
		[field: SerializeField] private WebGalleryScenes _sceneReference;
		[field: SerializeField] private Button _button;
		public void EnableButton()
		{
			_button.enabled = true;
		}
		public void DisableButton()
		{
			_button.enabled = false;
		}
		public void SubscribeButton()
		{
			_button.onClick.AddListener(LoadScene);
		}
		
		private void UnSubscribeButton()
		{
			_button.onClick.RemoveListener(LoadScene);
		}
		
		private void LoadScene()
		{
			SceneManager.LoadScene((int)WebGalleryScenes.Gallery);
		}
	}
}
