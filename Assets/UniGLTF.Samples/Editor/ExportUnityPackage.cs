#if UNIGLTF_DEVELOP
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;


namespace UniGLTF
{
    public static class ExportUnityPackage
    {
        static IEnumerable<string> EnumerateFiles(string path)
        {
            if (Path.GetFileName(path).StartsWith(".git"))
            {
                yield break;
            }

            if (Directory.Exists(path))
            {
                foreach (var child in Directory.GetFileSystemEntries(path))
                {
                    foreach (var x in EnumerateFiles(child))
                    {
                        yield return x;
                    }
                }
            }
            else
            {
                if (Path.GetExtension(path).ToLower() != ".meta")
                {
                    yield return path.Replace("\\", "/");
                }
            }
        }

        [MenuItem(UniGLTFVersion.UNIGLTF_VERSION + "/Export unitypackage", priority = UniGLTFVersionMenu.MENU_PRIORITY)]
        public static void CreateUnityPackage()
        {
            var path = EditorUtility.SaveFilePanel(
                    "export package",
                    null,
                    string.Format("{0}.unitypackage", UniGLTFVersion.UNIGLTF_VERSION),
                    "unitypackage");

            AssetDatabase.ExportPackage(EnumerateFiles("Assets/UniGLTF").ToArray()
                , path, ExportPackageOptions.Interactive);

            var samplePath = path.Replace(UniGLTFVersion.UNIGLTF_VERSION, "UniGLTF.Samles-"+UniGLTFVersion.VERSION);
            AssetDatabase.ExportPackage(EnumerateFiles("Assets/UniGLTF.Samples").ToArray()
                , samplePath, ExportPackageOptions.Interactive);
        }
    }
}
#endif