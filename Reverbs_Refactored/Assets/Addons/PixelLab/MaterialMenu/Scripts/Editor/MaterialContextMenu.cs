using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{
		static Material sourceMaterialRead;
		static Material sourceMaterial {
			get {
				if (sourceMaterialRead == null) {
					sourceMaterialRead = AssetDatabase.LoadAssetAtPath<Material>(Config.copiedMaterialPath);
				}
				return sourceMaterialRead;
				
			}
			
			set {
				sourceMaterialRead = value;
				if (sourceMaterialRead != null) {
					ClearCopiedProperties(null);
					AssetDatabase.CreateAsset(sourceMaterialRead, Config.copiedMaterialPath);
				}
			}
		}
	}	
}
