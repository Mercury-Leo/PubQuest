using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor.Utility.Scripts {
#if UNITY_EDITOR
    internal sealed class ScriptKeywordProcessor : AssetModificationProcessor {
        private static readonly char[] Spliters = { '/', '\\', '.' };
        private static readonly List<string> WordsToDelete = new List<string>() { "Extensions", "Scripts", "Editor" };
        private const string NameSpace = "#NAMESPACE#";

        public static void OnWillCreateAsset(string path) {
            path = path.Replace(".meta", "");
            var index = path.LastIndexOf(".", StringComparison.Ordinal);
            if (index < 0)
                return;

            var file = path.Substring(index);
            if (file != ".cs" && file != ".js")
                return;

            var namespaces = path.Split(Spliters).ToList();
            namespaces = namespaces.GetRange(1, namespaces.Count - 3);
            namespaces = namespaces.Except(WordsToDelete).ToList();

            var namespaceString = "Globals";
            for (var i = 0; i < namespaces.Count; i++) {
                if (i == 0)
                    namespaceString = "";
                namespaceString += namespaces[i];
                if (i < namespaces.Count - 1)
                    namespaceString += ".";
            }

            index = Application.dataPath.LastIndexOf("Assets", StringComparison.Ordinal);
            path = Application.dataPath.Substring(0, index) + path;
            if (!System.IO.File.Exists(path))
                return;

            var fileContent = System.IO.File.ReadAllText(path);
            fileContent = fileContent.Replace(NameSpace, namespaceString);
            System.IO.File.WriteAllText(path, fileContent);
            AssetDatabase.Refresh();
        }
    }
#endif
}