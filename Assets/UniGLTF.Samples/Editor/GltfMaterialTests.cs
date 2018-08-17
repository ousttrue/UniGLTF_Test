using NUnit.Framework;
using UnityEngine;


namespace UniGLTF
{
    public class GltfMaterialTests
    {
        [Test]
        public void ExportTest()
        {
            {
                var material = Resources.Load<Material>("Materials/pbr_opaque");
                var exporter = new MaterialExporter();
                var exported = exporter.ExportMaterial(material, null);
                Assert.True(exported.extensions == null || exported.extensions.KHR_materials_unlit == null);
                Assert.AreEqual("OPAQUE", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/pbr_transparent");
                var exporter = new MaterialExporter();
                var exported = exporter.ExportMaterial(material, null);
                Assert.True(exported.extensions == null || exported.extensions.KHR_materials_unlit == null);
                Assert.AreEqual("BLEND", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/pbr_cutout");
                var exporter = new MaterialExporter();
                var exported = exporter.ExportMaterial(material, null);
                Assert.True(exported.extensions == null || exported.extensions.KHR_materials_unlit == null);
                Assert.AreEqual("MASK", exported.alphaMode);
            }

            {
                var material = Resources.Load<Material>("Materials/unlit_color");
                var exporter = new MaterialExporter();
                var exported = exporter.ExportMaterial(material, null);
                Assert.NotNull(exported.extensions.KHR_materials_unlit);
                Assert.AreEqual("OPAQUE", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/unlit_texture");
                var exporter = new MaterialExporter();
                var exported = exporter.ExportMaterial(material, null);
                Assert.NotNull(exported.extensions.KHR_materials_unlit);
                Assert.AreEqual("OPAQUE", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/unlit_transparent");
                var exporter = new MaterialExporter();
                var exported = exporter.ExportMaterial(material, null);
                Assert.NotNull(exported.extensions.KHR_materials_unlit);
                Assert.AreEqual("BLEND", exported.alphaMode);
            }
            {
                var material = Resources.Load<Material>("Materials/unlit_cutout");
                var exporter = new MaterialExporter();
                var exported = exporter.ExportMaterial(material, null);
                Assert.NotNull(exported.extensions.KHR_materials_unlit);
                Assert.AreEqual("MASK", exported.alphaMode);
            }
        }
    }
}
