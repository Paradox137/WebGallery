﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebGallery.UIModule.Scenes;

namespace WebGallery.UIModule.Transition
{
	public delegate void ButtonItemViewSceneCallBack();
	[Serializable]
	public struct ButtonSceneTransition
	{
		[field: SerializeField] private WebGalleryScenes _sceneReference;
		[field: SerializeField] private Button _button;
		public void EnableButton()
		{
			_button.interactable = true;
		}
		public void DisableButton()
		{
			_button.interactable = false;
		}
		public void SubscribeButton()
		{
			_button.onClick.AddListener(LoadScene);
		}
		
		public void SubscribeButton(ButtonItemViewSceneCallBack __itemViewSceneCallBack)
		{
			_button.onClick.AddListener(__itemViewSceneCallBack.Invoke);
		}
		
		private void UnSubscribeButton()
		{
			_button.onClick.RemoveListener(LoadScene);
		}
		
		private void LoadScene()
		{
			SceneManager.LoadScene((int)_sceneReference);
		}
	}
}
