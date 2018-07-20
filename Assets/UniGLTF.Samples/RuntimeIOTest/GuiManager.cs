using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace UniGLTF
{
    public class GuiManager : MonoBehaviour
    {
        [SerializeField]
        Button m_importButton;

        GameObject m_root;

#if UNITY_EDITOR
        void Start()
        {
            m_importButton.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            var path = UnityEditor.EditorUtility.OpenFilePanel("open gltf", "", "gltf,glb,zip");
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            if (m_root != null)
            {
                GameObject.Destroy(m_root);
            }

            m_root = Load(path);
        }

        GameObject Load(string path)
        {
            var bytes = File.ReadAllBytes(path);

            Debug.LogFormat("[OnClick] {0}", path);
            var context = new ImporterContext();

            var ext = Path.GetExtension(path).ToLower();
            switch(ext)
            {
                case ".gltf":
                    context.ParseJson(Encoding.UTF8.GetString(bytes), new FileSystemStorage(Path.GetDirectoryName(path)));
                    break;

                case ".zip":
                    {
                        var zipArchive=Zip.ZipArchiveStorage.Parse(bytes);
                        var gltf = zipArchive.Entries.FirstOrDefault(x => x.FileName.ToLower().EndsWith(".gltf"));
                        if (gltf == null)
                        {
                            throw new Exception("no gltf in archive");
                        }
                        var jsonBytes = zipArchive.Extract(gltf);
                        var json = Encoding.UTF8.GetString(jsonBytes);
                        context.ParseJson(json, zipArchive);
                    }
                    break;

                case ".glb":
                    context.ParseGlb(bytes);
                    break;

                default:
                    throw new NotImplementedException();
            }

            gltfImporter.Import(context);
            context.Root.name = Path.GetFileNameWithoutExtension(path);
            context.ShowMeshes();

            return context.Root;
        }
#endif
    }
}
