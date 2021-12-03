using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{
		[MenuItem("CONTEXT/Material/Reset Values", false, 10)]
		private static void ResetValues(MenuCommand menuCommand)
		{
			var targetMaterial = menuCommand.context as Material;
			Undo.RecordObject(targetMaterial, "ResetValues");
			var s = targetMaterial.shader;
			var dummyMaterial = new Material(s);
			var numProperties = ShaderUtil.GetPropertyCount(s);
			for (var i = 0; i < numProperties; ++i) {
				var name = ShaderUtil.GetPropertyName(s, i);
				var type = ShaderUtil.GetPropertyType(s, i);
				// Debug.Log(name);
				// Debug.Log(type);
				switch(type) {
					case ShaderUtil.ShaderPropertyType.Color:
					targetMaterial.SetColor(name, dummyMaterial.GetColor(name) );
					break;
					case ShaderUtil.ShaderPropertyType.Vector:
					targetMaterial.SetVector(name, dummyMaterial.GetVector(name) );
					break;
					case ShaderUtil.ShaderPropertyType.Float:
					case ShaderUtil.ShaderPropertyType.Range:
					targetMaterial.SetFloat(name, dummyMaterial.GetFloat(name) );
					break;
				}
			}
		}
	}	
}
