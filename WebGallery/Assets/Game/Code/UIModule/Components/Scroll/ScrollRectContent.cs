using System;
using UnityEngine;
using UnityEngine.UI;
using WebGallery.UIModule.Mediator;

namespace WebGallery.UIModule.Components.Scroll
{
	[Serializable]
	public struct ScrollRectContent
	{
		[field: SerializeField] public RectTransform Content { get; private set; }
		[field: SerializeField] public RectTransform Viewport { get; private set; }
		[field: SerializeField] public GameObject GameObject { get; private set; }
		[field: SerializeField] public ScrollRect ScrollRect { get; private set; }

		public void Init(OnScrollCallBack __scrollCallBack)
		{
			SubscribeScrollRect(__scrollCallBack);
		}
		
		public void SubscribeScrollRect(OnScrollCallBack __scrollCallBack)
		{
			ScrollRect.onValueChanged.AddListener(__scrollCallBack.Invoke);
		}

		private void UnSubscribeScrollRect()
		{
			
		}
	}
}
