using NUnit.Framework;
using System.IO;
using UniJSON;
using UnityEngine;


namespace UniGLTF
{
    public class GltfSchemaTests
    {

        [Test]
        public void Accessor()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/accessor.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            Assert.AreEqual("Accessor", fromSchema.Title);
            Assert.AreEqual("object", fromSchema.Type);
            Assert.AreEqual("integer", fromSchema.Properties["bufferView"].Type);
            Assert.AreEqual("integer", fromSchema.Properties["byteOffset"].Type);

            var fromClass = JsonSchema.Create<glTFAccessor>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void AccessorSparseIndices()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/accessor.sparse.indices.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFSparseIndices>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void AccessorSparse()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/accessor.sparse.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFSparse>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void AccessorSparseValues()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/accessor.sparse.values.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFSparseValues>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void AnimationChannel()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/animation.channel.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFAnimationChannel>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void AnimationChannelTarget()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/animation.channel.target.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFAnimationTarget>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void AnimationSampler()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/animation.sampler.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFAnimationSampler>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void Animation()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/animation.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFAnimation>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void Asset()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/asset.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFAssets>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void Buffer()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/buffer.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFBuffer>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void BufferView()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/bufferView.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFBufferView>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void Gltf()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/glTF.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTF>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void Image()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/image.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFImage>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void MaterialNormalTextureInfo()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/material.normalTextureInfo.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFMaterialNormalTextureInfo>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void MaterialOcclusionTextureInfo()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/material.occlusionTextureInfo.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFMaterialOcclusionTextureInfo>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void MaterialPbrMetallicRoughness()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/material.pbrMetallicRoughness.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFPbrMetallicRoughness>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

        [Test]
        public void Material()
        {
            var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema/material.schema.json");
            var fromSchema = JsonSchema.ParseFromPath(path);
            var fromClass = JsonSchema.Create<glTFMaterial>();
            Assert.True(fromSchema.MatchProperties(fromClass));
        }

    }
}
