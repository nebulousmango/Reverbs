using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{
		[MenuItem("CONTEXT/Material/Paste Properties")]
		private static void PasteProperties(MenuCommand menuCommand)
		{
			if (sourceMaterial == null) {
				Debug.LogWarning("sourceMaterial is not copied");
				return;
			}

	    	var targetMaterial = menuCommand.context as Material;
	    	Undo.RecordObject(targetMaterial, "PasteProperties");
	    	targetMaterial.shader = sourceMaterial.shader;
	    	targetMaterial.CopyPropertiesFromMaterial(sourceMaterial);
		}
		
		[MenuItem("CONTEXT/Material/Paste Properties", true)]
		private static bool ValidatePasteProperties(MenuCommand menuCommand)
		{
			return sourceMaterial != null;
		}
		
	}	
}
