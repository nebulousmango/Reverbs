using UnityEngine;
using UnityEditor;

namespace PixelLab.MaterialMenu.Editor {
	public static partial class MaterialMenu
	{
		[MenuItem("CONTEXT/Material/Copy Properties")]
		private static void CopyProperties(MenuCommand menuCommand)
		{
		    sourceMaterial = Object.Instantiate(menuCommand.context as Material);

		}
	}	
}
