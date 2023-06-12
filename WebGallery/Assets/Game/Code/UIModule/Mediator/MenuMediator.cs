using UnityEngine;
using WebGallery.UIModule.Transition;

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
			Application.targetFrameRate = 60;
		}
		private void InitTransitionButtons()
		{
			_buttonGalleryTransition.SubscribeButton();
		}
	}
}
