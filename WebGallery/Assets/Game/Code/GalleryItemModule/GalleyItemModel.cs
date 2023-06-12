using System;
using UnityEngine;

namespace WebGallery.GalleryItemModule
{
	[Serializable]
	public struct GalleyItemModel
	{
		[field: SerializeField] public uint Id { get; set; }
		[field: SerializeField] public bool IsLoaded { get; set;}
		[field: SerializeField] public Texture ItemTexture { get; set;}
	}
}
