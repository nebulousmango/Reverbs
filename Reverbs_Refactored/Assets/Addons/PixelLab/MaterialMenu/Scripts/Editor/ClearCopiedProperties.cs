using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{
		[MenuItem("CONTEXT/Material/Clear Copied Properties", false, 15)]
		private static void ClearCopiedProperties(MenuCommand menuCommand)
		{
			try {
				AssetDatabase.DeleteAsset(Config.copiedMaterialPath);
			}catch(System.Exception ) {
				
			}
		}
		
		[MenuItem("CONTEXT/Material/Clear Copied Properties", true, 15)]
		private static bool TestClearCopiedProperties(MenuCommand menuCommand)
		{
			try {
				var asset = AssetDatabase.LoadAssetAtPath<Material>(Config.copiedMaterialPath);
				return asset != null;
			}catch(System.Exception ) {
				
			}
			return false;
		}
		
	}	
}
