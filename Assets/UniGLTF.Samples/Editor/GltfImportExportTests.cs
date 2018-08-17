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

#if UNITY_2017_1_OR_NEWER
        [Test]
        public void TextureSamplerImportTest_for_Unity_2017_1()
        {
            Assert.AreEqual(
                new[] { TextureSamplerUtil.TypeWithMode(TextureSamplerUtil.TextureWrapType.All, TextureWrapMode.Repeat) },
                TextureSamplerUtil.GetUnityWrapMode(new glTFTextureSampler
                {
                })
                );

            Assert.AreEqual(
                new[] {
                    TextureSamplerUtil.TypeWithMode(TextureSamplerUtil.TextureWrapType.U, TextureWrapMode.Repeat),
                    TextureSamplerUtil.TypeWithMode(TextureSamplerUtil.TextureWrapType.V, TextureWrapMode.Clamp),
                },
                TextureSamplerUtil.GetUnityWrapMode(new glTFTextureSampler
                {
                    wrapS = glWrap.REPEAT,
                    wrapT = glWrap.CLAMP_TO_EDGE,
                })
                );

            Assert.AreEqual(FilterMode.Bilinear, TextureSamplerUtil.ImportFilterMode(glFilter.NONE));
            Assert.AreEqual(FilterMode.Bilinear, TextureSamplerUtil.ImportFilterMode(glFilter.LINEAR));
            Assert.AreEqual(FilterMode.Trilinear, TextureSamplerUtil.ImportFilterMode(glFilter.LINEAR_MIPMAP_LINEAR));
            Assert.AreEqual(FilterMode.Bilinear, TextureSamplerUtil.ImportFilterMode(glFilter.LINEAR_MIPMAP_NEAREST));
            Assert.AreEqual(FilterMode.Point, TextureSamplerUtil.ImportFilterMode(glFilter.NEAREST));
            Assert.AreEqual(FilterMode.Point, TextureSamplerUtil.ImportFilterMode(glFilter.NEAREST_MIPMAP_LINEAR));
            Assert.AreEqual(FilterMode.Point, TextureSamplerUtil.ImportFilterMode(glFilter.NEAREST_MIPMAP_NEAREST));
            Assert.AreEqual(FilterMode.Bilinear, TextureSamplerUtil.ImportFilterMode(glFilter.NONE));
        }
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

        [Test]
        public void TextureSamplerExportFilterTest()
        {
            {
                var texture = Resources.Load<Texture2D>("Sampler/filter_point");
                Assert.AreEqual(glFilter.NEAREST, TextureSamplerUtil.ExportFilter(texture));
            }
            {
                var texture = Resources.Load<Texture2D>("Sampler/filter_bilinear");
                Assert.AreEqual(glFilter.LINEAR, TextureSamplerUtil.ExportFilter(texture));
            }
            {
                var texture = Resources.Load<Texture2D>("Sampler/filter_trilinear");
                Assert.AreEqual(glFilter.LINEAR_MIPMAP_LINEAR, TextureSamplerUtil.ExportFilter(texture));
            }
        }

#if UNITY_2017_1_OR_NEWER
        [Test]
        public void TextureSamplerExportTest_for_Unity_2017_1()
        {
            {
                var texture = Resources.Load<Texture2D>("Sampler/wrap_clamp");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.CLAMP_TO_EDGE, sampler.wrapS);
                Assert.AreEqual(glWrap.CLAMP_TO_EDGE, sampler.wrapT);
            }
            {
                var texture = Resources.Load<Texture2D>("Sampler/wrap_mirror");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.MIRRORED_REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.MIRRORED_REPEAT, sampler.wrapT);
            }
            {
                // ?
                var texture = Resources.Load<Texture2D>("Sampler/wrap_mirroronce");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.MIRRORED_REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.MIRRORED_REPEAT, sampler.wrapT);
            }
            {
                var texture = Resources.Load<Texture2D>("Sampler/wrap_repeat");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapT);
            }
            {
                var texture = Resources.Load<Texture2D>("Sampler/wrap_repeat_clamp");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.CLAMP_TO_EDGE, sampler.wrapT);
            }
        }
#else
        [Test]
        public void TextureSamplerExportTest_for_Unity_5_6()
        {
            Assert.Fail();
        }
#endif
    }
}
