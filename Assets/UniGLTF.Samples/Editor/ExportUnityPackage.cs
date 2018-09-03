#if UNIGLTF_DEVELOP
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UniGLTF
{
    public static class ExportUnityPackage
    {
        static IEnumerable<string> EnumerateFiles(string path, Func<string, bool> exclude)
        {
            path = path.Replace("\\", "/");

            if (exclude != null && exclude(path))
            {
                yield break;
            }

            if (Path.GetFileName(path).StartsWith(".git"))
            {
                yield break;
            }

            if (Directory.Exists(path))
            {
                foreach (var child in Directory.GetFileSystemEntries(path))
                {
                    foreach (var x in EnumerateFiles(child, exclude))
                    {
                        yield return x;
                    }
                }
            }
            else
            {
                if (Path.GetExtension(path).ToLower() == ".meta")
                {
                    yield break;
                }

                yield return path;
            }
        }

        static bool Filter(string path)
        {
            if (path.EndsWith("UniJSON/Profiling"))
            {
                return true;
            }
            return false;
        }

        [MenuItem(UniGLTFVersion.UNIGLTF_VERSION + "/Export unitypackage", priority = UniGLTFVersionMenu.MENU_PRIORITY)]
        public static void CreateUnityPackage()
        {
            var path = EditorUtility.SaveFilePanel(
                    "export package",
                    null,
                    string.Format("{0}.unitypackage", UniGLTFVersion.UNIGLTF_VERSION),
                    "unitypackage");

            {
                var files = EnumerateFiles("Assets/UniGLTF", Filter).ToArray();
                Debug.LogFormat("exported:\n{0}", string.Join("", files.Select((x, i) => string.Format("[{0:##0}]{1}\n", i, x)).ToArray()));
                AssetDatabase.ExportPackage(files
                    , path, ExportPackageOptions.Interactive);
            }

            {
                var samplePath = path.Replace(UniGLTFVersion.UNIGLTF_VERSION, "UniGLTF.Samples-" + UniGLTFVersion.VERSION);
                AssetDatabase.ExportPackage(EnumerateFiles("Assets/UniGLTF.Samples", null).ToArray()
                    , samplePath, ExportPackageOptions.Interactive);
            }
        }
    }
}
#endif
