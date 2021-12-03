using UnityEngine;
using UnityEditor;
using System.Collections;


namespace PixelLab.MaterialMenu.Editor {
	
	[InitializeOnLoad]
	public static class Config  {
		static Config() {
			LoadConfig();
		}
		
		static class PrefPath {
			public const string copiedMaterialDefaultDirectory = "PixelLab.MaterialMenu.copiedMaterialDefaultPath";
		}
		
		private static string copiedMaterialDirectory;
		const string copiedMaterialDefaultDirectory = "Assets/PixelLab/MaterialMenu/Data/";
		
		public static string copiedMaterialPath {
			get {
				var basePath = Config.copiedMaterialDirectory;
				basePath = basePath.Replace("\\", "/");
				if (!basePath.EndsWith("/")) {
					basePath += "/";
				}
				return basePath + "copied.mat";
			}
		}
		
		public static void LoadConfig() {
			copiedMaterialDirectory = EditorPrefs.GetString(PrefPath.copiedMaterialDefaultDirectory, copiedMaterialDefaultDirectory);
		}
		
		
		
		[PreferenceItem("Material Menu")]
		public static void PreferencesGUI()
		{
			const int columnWidth0 = 150;
			const int columnWidth1 = 200;
			EditorGUILayout.Space();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Copied Material Directory",GUILayout.Width(columnWidth0));
			copiedMaterialDirectory = EditorGUILayout.TextField(copiedMaterialDirectory,GUILayout.Width(columnWidth1));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			if (GUILayout.Button("Reset Settings", GUILayout.Width(columnWidth0) )) {
				EditorPrefs.DeleteKey(PrefPath.copiedMaterialDefaultDirectory);
				
				LoadConfig();
			}
			
			if (GUI.changed) {
				EditorPrefs.SetString(PrefPath.copiedMaterialDefaultDirectory, copiedMaterialDirectory);
			}
		}		
	}
	
}