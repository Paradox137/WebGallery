using UnityEngine;

namespace WebGallery.ServiceModule
{
	public class DeviceOrientationService : MonoBehaviour
	{
		private const float ORIENTATION_CHECK_INTERVAL = 0.5f;

		private float nextOrientationCheckTime;

		private static ScreenOrientation m_currentOrientation;
		public static ScreenOrientation CurrentOrientation
		{ 
			get { return m_currentOrientation; }
			private set { if (m_currentOrientation != value) { m_currentOrientation = value; Screen.orientation = value; } } 
		}
		public static bool AutoRotateScreen = true;
		void Awake()
		{
			m_currentOrientation = Screen.orientation;
			nextOrientationCheckTime = Time.realtimeSinceStartup + 1f;
		}

		void Update()
		{
			if (!AutoRotateScreen)
				return;

			if (Time.realtimeSinceStartup >= nextOrientationCheckTime)
			{
				DeviceOrientation orientation = Input.deviceOrientation;
				if (orientation == DeviceOrientation.Portrait || orientation == DeviceOrientation.PortraitUpsideDown ||
					orientation == DeviceOrientation.LandscapeLeft || orientation == DeviceOrientation.LandscapeRight)
				{
					if (orientation == DeviceOrientation.LandscapeLeft)
					{
						if (Screen.autorotateToLandscapeLeft)
							DeviceOrientationService.CurrentOrientation = ScreenOrientation.LandscapeLeft;
					}
					else if (orientation == DeviceOrientation.LandscapeRight)
					{
						if (Screen.autorotateToLandscapeRight)
							DeviceOrientationService.CurrentOrientation = ScreenOrientation.LandscapeRight;
					}
					else if (orientation == DeviceOrientation.PortraitUpsideDown)
					{
						if (Screen.autorotateToPortraitUpsideDown)
							DeviceOrientationService.CurrentOrientation = ScreenOrientation.PortraitUpsideDown;
					}
					else
					{
						if (Screen.autorotateToPortrait)
							DeviceOrientationService.CurrentOrientation = ScreenOrientation.Portrait;
					}
				}

				nextOrientationCheckTime = Time.realtimeSinceStartup + ORIENTATION_CHECK_INTERVAL;
			}
		}
	}
}
