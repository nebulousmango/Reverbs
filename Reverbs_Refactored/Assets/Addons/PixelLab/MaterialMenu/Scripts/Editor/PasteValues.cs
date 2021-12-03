using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{
		[MenuItem("CONTEXT/Material/Paste Values")]
		private static void PasteValues(MenuCommand menuCommand)
		{
			if (sourceMaterial == null) {
				Debug.LogWarning("sourceMaterial is not copied");
				return;
			}
			
			var targetMaterial = menuCommand.context as Material;
			Undo.RecordObject(targetMaterial, "PasteValues");
			var s = sourceMaterial.shader;
			var numProperties = ShaderUtil.GetPropertyCount(s);
			for (var i = 0; i < numProperties; ++i) {
				var name = ShaderUtil.GetPropertyName(s, i);
				var type = ShaderUtil.GetPropertyType(s, i);
				switch(type) {
					case ShaderUtil.ShaderPropertyType.Color:
					targetMaterial.SetColor(name, sourceMaterial.GetColor(name) );
					break;
					case ShaderUtil.ShaderPropertyType.Vector:
					targetMaterial.SetVector(name, sourceMaterial.GetVector(name) );
					break;
					case ShaderUtil.ShaderPropertyType.Float:
					case ShaderUtil.ShaderPropertyType.Range:
					targetMaterial.SetFloat(name, sourceMaterial.GetFloat(name) );
					break;
				}
			}
		}
		
		[MenuItem("CONTEXT/Material/Paste Values", true)]
		private static bool ValidatePasteValues(MenuCommand menuCommand)
		{
			return sourceMaterial != null;
		}
		

	}	
}
