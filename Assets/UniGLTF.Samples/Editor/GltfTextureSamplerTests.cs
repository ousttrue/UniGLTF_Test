using NUnit.Framework;
using UnityEngine;


namespace UniGLTF
{
    public class GltfTextureSamplerTests
    {

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

#if UNITY_2017_1_OR_NEWER
        [Test]
        public void TextureSamplerExportTest_for_Unity_2017_1()
        {
            {
                var texture = Resources.Load<Texture2D>("Samplers/wrap_clamp");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.CLAMP_TO_EDGE, sampler.wrapS);
                Assert.AreEqual(glWrap.CLAMP_TO_EDGE, sampler.wrapT);
            }
            {
                var texture = Resources.Load<Texture2D>("Samplers/wrap_mirror");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.MIRRORED_REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.MIRRORED_REPEAT, sampler.wrapT);
            }
            {
                // ?
                var texture = Resources.Load<Texture2D>("Samplers/wrap_mirroronce");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.MIRRORED_REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.MIRRORED_REPEAT, sampler.wrapT);
            }
            {
                var texture = Resources.Load<Texture2D>("Samplers/wrap_repeat");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapT);
            }
            {
                var texture = Resources.Load<Texture2D>("Samplers/wrap_repeat_clamp");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.CLAMP_TO_EDGE, sampler.wrapT);
            }
        }
#else
        [Test]
        public void TextureSamplerExportTest_for_Unity_5_6()
        {
            {
                var texture = Resources.Load<Texture2D>("Samplers/wrap_clamp");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.CLAMP_TO_EDGE, sampler.wrapS);
                Assert.AreEqual(glWrap.CLAMP_TO_EDGE, sampler.wrapT);
            }
            {
                var texture = Resources.Load<Texture2D>("Samplers/wrap_repeat");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapT);
            }
            /*
            {
                var texture = Resources.Load<Texture2D>("Samplers/wrap_repeat_clamp");
                var sampler = TextureSamplerUtil.Export(texture);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapS);
                Assert.AreEqual(glWrap.REPEAT, sampler.wrapT);
            }
            */
        }
#endif

        [Test]
        public void TextureSamplerImportFilterModeTest()
        {
            Assert.AreEqual(FilterMode.Bilinear, TextureSamplerUtil.ImportFilterMode(glFilter.NONE));
            Assert.AreEqual(FilterMode.Bilinear, TextureSamplerUtil.ImportFilterMode(glFilter.LINEAR));
            Assert.AreEqual(FilterMode.Trilinear, TextureSamplerUtil.ImportFilterMode(glFilter.LINEAR_MIPMAP_LINEAR));
            Assert.AreEqual(FilterMode.Bilinear, TextureSamplerUtil.ImportFilterMode(glFilter.LINEAR_MIPMAP_NEAREST));
            Assert.AreEqual(FilterMode.Point, TextureSamplerUtil.ImportFilterMode(glFilter.NEAREST));
            Assert.AreEqual(FilterMode.Point, TextureSamplerUtil.ImportFilterMode(glFilter.NEAREST_MIPMAP_LINEAR));
            Assert.AreEqual(FilterMode.Point, TextureSamplerUtil.ImportFilterMode(glFilter.NEAREST_MIPMAP_NEAREST));
            Assert.AreEqual(FilterMode.Bilinear, TextureSamplerUtil.ImportFilterMode(glFilter.NONE));
        }

        [Test]
        public void TextureSamplerExportFilterModeTest()
        {
            {
                var texture = Resources.Load<Texture2D>("Samplers/filter_point");
                Assert.AreEqual(glFilter.NEAREST, TextureSamplerUtil.ExportFilterMode(texture));
            }
            {
                var texture = Resources.Load<Texture2D>("Samplers/filter_bilinear");
                Assert.AreEqual(glFilter.LINEAR, TextureSamplerUtil.ExportFilterMode(texture));
            }
            {
                var texture = Resources.Load<Texture2D>("Samplers/filter_trilinear");
                Assert.AreEqual(glFilter.LINEAR_MIPMAP_LINEAR, TextureSamplerUtil.ExportFilterMode(texture));
            }
        }
    }
}
