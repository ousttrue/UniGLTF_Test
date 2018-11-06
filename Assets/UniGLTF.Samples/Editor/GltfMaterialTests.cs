using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace UniGLTF
{
    public class GltfMaterialTests
    {
        static IEnumerable<Texture> GetTextures(Material material)
        {
            var props = ShaderUtil.GetPropertyCount(material.shader);
            for (int i = 0; i < props; ++i)
            {
                if (ShaderUtil.GetPropertyType(material.shader, i) == ShaderUtil.ShaderPropertyType.TexEnv)
                {
                    var texture = material.GetTexture(ShaderUtil.GetPropertyName(material.shader, i));
                    if (texture != null)
                    {
                        yield return texture;
                    }
                }
            }
        }

        [Test]
        public void ExportTest()
        {
            {
                var material = Resources.Load<Material>("Materials/pbr_opaque");
                var exporter = new MaterialExporter();
                var textures = GetTextures(material).ToList();
                var exportedTextures = new List<Texture>(textures);
                var exported = exporter.ExportMaterial(material, textures, exportedTextures);
                Assert.True(exported.extensions == null || exported.extensions.KHR_materials_unlit == null);
                Assert.AreEqual("OPAQUE", exported.alphaMode);
            }

            {
                var material = Resources.Load<Material>("Materials/pbr_transparent");
                var exporter = new MaterialExporter();
                var textures = GetTextures(material).ToList();
                var exportedTextures = new List<Texture>(textures);
                var exported = exporter.ExportMaterial(material, textures, exportedTextures);
                Assert.True(exported.extensions == null || exported.extensions.KHR_materials_unlit == null);
                Assert.AreEqual("BLEND", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/pbr_cutout");
                var exporter = new MaterialExporter();
                var textures = GetTextures(material).ToList();
                var exportedTextures = new List<Texture>(textures);
                var exported = exporter.ExportMaterial(material, textures, exportedTextures);
                Assert.True(exported.extensions == null || exported.extensions.KHR_materials_unlit == null);
                Assert.AreEqual("MASK", exported.alphaMode);
            }

            {
                var material = Resources.Load<Material>("Materials/unlit_color");
                var exporter = new MaterialExporter();
                var textures = GetTextures(material).ToList();
                var exportedTextures = new List<Texture>(textures);
                var exported = exporter.ExportMaterial(material, textures, exportedTextures);
                Assert.NotNull(exported.extensions.KHR_materials_unlit);
                Assert.AreEqual("OPAQUE", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/unlit_texture");
                var exporter = new MaterialExporter();
                var textures = GetTextures(material).ToList();
                var exportedTextures = new List<Texture>(textures);
                var exported = exporter.ExportMaterial(material, textures, exportedTextures);
                Assert.NotNull(exported.extensions.KHR_materials_unlit);
                Assert.AreEqual("OPAQUE", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/unlit_transparent");
                var exporter = new MaterialExporter();
                var textures = GetTextures(material).ToList();
                var exportedTextures = new List<Texture>(textures);
                var exported = exporter.ExportMaterial(material, textures, exportedTextures);
                Assert.NotNull(exported.extensions.KHR_materials_unlit);
                Assert.AreEqual("BLEND", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/unlit_cutout");
                var exporter = new MaterialExporter();
                var textures = GetTextures(material).ToList();
                var exportedTextures = new List<Texture>(textures);
                var exported = exporter.ExportMaterial(material, textures, exportedTextures);
                Assert.NotNull(exported.extensions.KHR_materials_unlit);
                Assert.AreEqual("MASK", exported.alphaMode);
            }

            {
                // multimaterial

            }
        }
    }
}
