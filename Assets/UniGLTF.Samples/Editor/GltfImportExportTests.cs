using NUnit.Framework;
using System.IO;
using System.Text;
using UnityEngine;


namespace UniGLTF
{
    public class GltfImportExportTests
    {
        [Test]
        public void ImportExportTest()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF-Sample-Models/2.0/Box/glTF/Box.gltf");
            var context = new ImporterContext();
            var bytes = File.ReadAllBytes(path);
            var importJson = Encoding.UTF8.GetString(bytes);

            context.ParseJson(importJson, new FileSystemStorage(Path.GetDirectoryName(path)));
            gltfImporter.Load(context);

            var gltf = gltfExporter.Export(context.Root);
            var exportJson = gltf.ToJson();

            var l = UniJSON.JsonParser.Parse(importJson);
            var r = UniJSON.JsonParser.Parse(exportJson);

            foreach (var diff in l.Diff(r))
            {
                Debug.Log(diff);
            }

            //Assert.AreEqual();
        }

#if UNITY_2017_OR_NEWER
#else
        [Test]
        public void TextureSamplerImportTest_for_Unity_5_6()
        {
            Assert.AreEqual(
                new[] { TextureSamplerUtil.TypeWithMode(TextureSamplerUtil.TextureWrapType.All, TextureWrapMode.Repeat) },
                TextureSamplerUtil.GetUnityWrapMode(new glTFTextureSampler
                {
                })
                );

            Assert.AreEqual(
                new[] { TextureSamplerUtil.TypeWithMode(TextureSamplerUtil.TextureWrapType.All, TextureWrapMode.Clamp) },
                TextureSamplerUtil.GetUnityWrapMode(new glTFTextureSampler
                {
                    wrapS = glWrap.CLAMP_TO_EDGE
                })
                );

            Assert.AreEqual(
                new[] { TextureSamplerUtil.TypeWithMode(TextureSamplerUtil.TextureWrapType.All, TextureWrapMode.Repeat) },
                TextureSamplerUtil.GetUnityWrapMode(new glTFTextureSampler
                {
                    wrapS = glWrap.REPEAT
                })
                );
        }
#endif
    }
}
