using System.IO;
using UnityEditor;

namespace Editor.Utility.Scripts {
#if UNITY_EDITOR
    /// <summary>
    /// Adds options to generator default folders
    /// </summary>
    internal static class FolderGenerator {
        #region Private members

        private const string DefaultFolder = "Assets";
        private const string MenuItemPath = "Assets/Create/Folders/";

        #region Default

        private const string ScriptsFolder = "Scripts";
        private const string PrefabsFolder = "Prefabs";
        private const string InterfacesFolder = "Interfaces";
        private const string ScriptableFolder = "Scriptable objects";

        #endregion

        #endregion

        [MenuItem(MenuItemPath + ScriptsFolder + PrefabsFolder, priority = 11)]
        public static void CreateDefaultFolders() {
            var path = FindClickedAssetPath();

            AssetDatabase.CreateFolder(path, ScriptsFolder);
            AssetDatabase.CreateFolder(path, PrefabsFolder);
        }

        [MenuItem(MenuItemPath + ScriptsFolder + InterfacesFolder, priority = 11)]
        public static void CreateInterfacesFolders() {
            var path = FindClickedAssetPath();

            AssetDatabase.CreateFolder(path, ScriptsFolder);
            AssetDatabase.CreateFolder(path, InterfacesFolder);
        }

        [MenuItem(MenuItemPath + ScriptableFolder, priority = 11)]
        public static void CreateScriptableFolders() {
            AssetDatabase.CreateFolder(FindClickedAssetPath(), ScriptableFolder);
        }

        [MenuItem(MenuItemPath + ScriptsFolder + ScriptableFolder, priority = 11)]
        public static void CreateScriptableScriptsFolders() {
            var path = FindClickedAssetPath();

            AssetDatabase.CreateFolder(path, ScriptsFolder);
            AssetDatabase.CreateFolder(path, ScriptableFolder);
        }


        #region Utility

        /// <summary>
        /// Finds the point where the mouse clicked in the assets folder
        /// </summary>
        /// <returns></returns>
        private static string FindClickedAssetPath() {
            var path = AssetDatabase.GetAssetPath(Selection.activeObject);

            if (path.Equals(string.Empty))
                path = DefaultFolder;

            if (!Path.GetExtension(path).Equals(string.Empty))
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), string.Empty);

            return path;
        }

        #endregion
    }
#endif
}