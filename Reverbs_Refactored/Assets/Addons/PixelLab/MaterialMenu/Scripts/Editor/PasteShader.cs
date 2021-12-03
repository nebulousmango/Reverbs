using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{

		[MenuItem("CONTEXT/Material/Paste Shader")]
		private static void PasteShader(MenuCommand menuCommand)
		{
			if (sourceMaterial == null) {
				Debug.LogWarning("sourceMaterial is not copied");
				return;
			}
			var targetMaterial = menuCommand.context as Material;
			Undo.RecordObject(targetMaterial, "PasteShader");
			targetMaterial.shader = sourceMaterial.shader;

		}
		
		[MenuItem("CONTEXT/Material/Paste Shader", true)]
		private static bool ValidatePasteShader(MenuCommand menuCommand)
		{
			return sourceMaterial != null;
		}
		
	}	
}
