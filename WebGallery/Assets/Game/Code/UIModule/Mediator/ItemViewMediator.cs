using UnityEngine;
using UnityEngine.UI;
using WebGallery.UIModule.Transition;

namespace WebGallery.UIModule.Mediator
{
	public class ItemViewMediator : MonoBehaviour
	{
		[SerializeField] private ButtonSceneTransition _buttonGalleryTransition;
		[SerializeField] private Image Image;
		private void Awake()
		{
			InitApplicationsSettings();
			InitTransitionButtons();
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
