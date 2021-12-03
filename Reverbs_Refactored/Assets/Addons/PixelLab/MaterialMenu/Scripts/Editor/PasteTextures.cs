using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{

		[MenuItem("CONTEXT/Material/Paste Textures")]
		private static void PasteTextures(MenuCommand menuCommand)
		{
			if (sourceMaterial == null) {
				Debug.LogWarning("sourceMaterial is not copied");
				return;
			}
			var targetMaterial = menuCommand.context as Material;
			Undo.RecordObject(targetMaterial, "PasteTextures");
			var s = sourceMaterial.shader;
			var numProperties = ShaderUtil.GetPropertyCount(s);
			for (var i = 0; i < numProperties; ++i) {
				var name = ShaderUtil.GetPropertyName(s, i);
				var type = ShaderUtil.GetPropertyType(s, i);
				switch(type) {
					
					case ShaderUtil.ShaderPropertyType.TexEnv:
					targetMaterial.SetTexture(name, sourceMaterial.GetTexture(name) );
					targetMaterial.SetTextureOffset(name, sourceMaterial.GetTextureOffset(name));
					targetMaterial.SetTextureScale(name, sourceMaterial.GetTextureScale(name));
					break;
				}
			}
		}
		
		[MenuItem("CONTEXT/Material/Paste Textures", true)]
		private static bool ValidatePasteTextures(MenuCommand menuCommand)
		{
			return sourceMaterial != null;
		}
		
	}	
}
