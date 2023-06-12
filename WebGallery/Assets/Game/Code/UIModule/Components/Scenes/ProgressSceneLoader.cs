using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WebGallery.UIModule.Components.Scenes
{
	[Serializable]
	public struct ProgressSceneLoader
	{
		[field: SerializeField] private Canvas _galleryLoaderCanvas;
		[field: SerializeField] private Image _progressBar;
		[field: SerializeField] private TextMeshProUGUI _progressText;
		
		public void ChangeProgressBarValue(float value)
		{
			_progressBar.fillAmount = value;
			_progressText.text = ((int)(_progressBar.fillAmount * 100f)).ToString() + "%";
		}
		
		public void ShowSceneLoader()
		{
			_galleryLoaderCanvas.enabled = true;
		}

		public void HideSceneLoader()
		{
			_galleryLoaderCanvas.enabled = false;
		}
	}
}
