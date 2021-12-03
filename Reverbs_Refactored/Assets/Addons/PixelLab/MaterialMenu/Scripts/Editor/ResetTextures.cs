using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{

		[MenuItem("CONTEXT/Material/Reset Textures", false, 10)]
		private static void ResetTextures(MenuCommand menuCommand)
		{
			var targetMaterial = menuCommand.context as Material;
			Undo.RecordObject(targetMaterial, "ResetTextures");
			var s = targetMaterial.shader;
			var numProperties = ShaderUtil.GetPropertyCount(s);
			for (var i = 0; i < numProperties; ++i) {
				var name = ShaderUtil.GetPropertyName(s, i);
				var type = ShaderUtil.GetPropertyType(s, i);
				// Debug.Log(name);
				// Debug.Log(type);
				switch(type) {
					// case ShaderUtil.ShaderPropertyType.Color:
					// targetMaterial.SetColor(name, sourceMaterial.GetColor(name) );
					// break;
					// case ShaderUtil.ShaderPropertyType.Vector:
					// targetMaterial.SetVector(name, sourceMaterial.GetVector(name) );
					// break;
					// case ShaderUtil.ShaderPropertyType.Float:
					// case ShaderUtil.ShaderPropertyType.Range:
					// targetMaterial.SetFloat(name, sourceMaterial.GetFloat(name) );
					// break;
					case ShaderUtil.ShaderPropertyType.TexEnv:
					targetMaterial.SetTexture(name, null );
					targetMaterial.SetTextureOffset(name, Vector2.zero);
					targetMaterial.SetTextureScale(name, Vector2.one);
					break;
				}
			}
		}
	}	
}
