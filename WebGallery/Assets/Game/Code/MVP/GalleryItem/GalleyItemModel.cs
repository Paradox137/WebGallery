using System;
using UnityEngine;

namespace WebGallery.MVP.GalleryItem
{
	[Serializable]
	public struct GalleyItemModel
	{
		[field: SerializeField] public uint Id { get; set; }
		[field: SerializeField] public bool IsLoaded { get; set;}
		[field: SerializeField] public Texture2D ItemTexture { get; set;}
	}
}
