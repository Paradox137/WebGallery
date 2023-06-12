using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using WebGallery.UIModule.Mediator;

namespace WebGallery.ServiceModule
{
	public static class ItemsLoader
	{
		private const string URL = "http://data.ikppbb.com/test-task-unity-data/pics/";
		
		private static float _progress;
		private static GalleryMediator _galleryMediator;
		
		public static void Init(GalleryMediator __galleryMediator)
		{
			_galleryMediator = __galleryMediator;
		}
		
		public static async UniTask<Texture> DownloadItem(uint id)
		{
			string path = URL + id + ".jpg";
				
			UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);

			await request.SendWebRequest();
			
			return request.result == UnityWebRequest.Result.Success
				? DownloadHandlerTexture.GetContent(request) : null;
		}
		
		public static async UniTask<List<Texture>> DownloadMultipleItems(uint[] ids)
		{
			string[] paths = new string[ids.Length];
			
			for (int i = 0; i < paths.Length; i++)
			{
				paths[i] = URL + ids[i] + ".jpg";
			}
			
			UnityWebRequest[] requests = new UnityWebRequest[ids.Length];
			
			for (int i = 0; i < ids.Length; i++)
				requests[i] = UnityWebRequestTexture.GetTexture(paths[i]);
					
			_progress = 0;
			
			for (int i = 0; i < requests.Length; i++)
			{
				await requests[i].SendWebRequest().
					ToUniTask(Progress.Create<float>((x
						=> CalculateProgress(x,i, requests.Length))));;
			}
			
			List<Texture> textures = new List<Texture>();
			
			foreach (UnityWebRequest request in requests)
			{
				if(request.result == UnityWebRequest.Result.Success)
					textures.Add(DownloadHandlerTexture.GetContent(request));
			}
			
			return textures;
		}

		private static void CalculateProgress(float __value, int __counter, int __length)
		{
			_progress = (__value + __counter) / __length;
					
			_galleryMediator.NotifyLoadProgressUpdate(_progress);
		}
	}
}
