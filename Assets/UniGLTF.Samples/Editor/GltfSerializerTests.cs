using NUnit.Framework;
using UniGLTF;
using UniJSON;


namespace UniGLTFJson
{
    public class GltfSerializerTests
    {
        static void Test<T>(T value) where T : IJsonSerializable
        {
            var jsonOld = value.ToJson();

            var s = JsonSchema.FromType(value.GetType());
            var jsonNew = s.Serialize(value);

            Assert.AreEqual(jsonOld, jsonNew);
        }

        [Test]
        public void Accessor()
        {
            Test(new glTFAccessor
            {
                bufferView = 0,
                byteOffset = 0,
                componentType = glComponentType.UNSIGNED_BYTE,
                count = 1,
                name = "accessor",
                normalized = false,
                min = new float[] { 0, 0, 0 },
                max = new float[] { 1, 1, 1 },
                type = "VEC3",
                sparse = new glTFSparse
                {

                }
            });
        }

        [Test]
        public void AccessorSparse()
        {
            Test(new glTFSparse
            {
                count = 1,
                indices = new glTFSparseIndices
                {
                    bufferView = 0,
                    componentType = glComponentType.UNSIGNED_BYTE,
                },
                values = new glTFSparseValues
                {
                    bufferView = 0,
                }
            });
        }

        [Test]
        public void AccessorSparseIndices()
        {
            Test(new glTFSparseIndices
            {
                bufferView = 0,
                componentType = glComponentType.UNSIGNED_BYTE,
            });
        }

        [Test]
        public void AccessorSparseValues()
        {
            Test(new glTFSparseValues
            {
                bufferView = 0,
            });
        }

        [Test]
        public void AnimationChannel()
        {
            Test(new glTFAnimationChannel
            {
                sampler=0,
                target = new glTFAnimationTarget
                {
                    path="",
                }
            });
        }

        [Test]
        public void AnimationChannelTarget()
        {
            Test(new glTFAnimationTarget
            {
                path = "",
            });
        }

        [Test]
        public void AnimationSampler()
        {
            Test(new glTFAnimationSampler
            {
                input = 0,
                interpolation = "",
                output = 0
            });
        }

        [Test]
        public void Animation()
        {
            Test(new glTFAnimation {
                channels=new System.Collections.Generic.List<glTFAnimationChannel> {
                    new glTFAnimationChannel { sampler=0}
                },
                samplers=new System.Collections.Generic.List<glTFAnimationSampler> {
                    new glTFAnimationSampler { input=0, interpolation="", output=0 } },
            });
        }

        [Test]
        public void Asset()
        {
            Test(new glTFAssets { });
        }

        [Test]
        public void Buffer()
        {
            Test(new glTFBuffer(null) { });
        }

        [Test]
        public void BufferView()
        {
            Test(new glTFBufferView { });
        }

        [Test]
        public void Gltf()
        {
            Test(new glTF { });
        }

        [Test]
        public void Image()
        {
            Test(new glTFImage { });
        }

        [Test]
        public void MaterialNormalTextureInfo()
        {
            Test(new glTFMaterialNormalTextureInfo { });
        }

        [Test]
        public void MaterialOcclusionTextureInfo()
        {
            Test(new glTFMaterialOcclusionTextureInfo { });
        }

        [Test]
        public void MaterialPbrMetallicRoughness()
        {
            Test(new glTFPbrMetallicRoughness { });
        }

        [Test]
        public void Material()
        {
            Test(new glTFMaterial { });
        }

        [Test]
        public void MeshPrimitive()
        {
            Test(new glTFPrimitives { });
        }

        [Test]
        public void Mesh()
        {
            Test(new glTFMesh("") { });
        }

        [Test]
        public void Node()
        {
            Test(new glTFNode { });
        }

        [Test]
        public void Sampler()
        {
            Test(new glTFTextureSampler { });
        }

        [Test]
        public void Scene()
        {
            Test(new gltfScene { });
        }

        [Test]
        public void Skin()
        {
            Test(new glTFSkin { });
        }

        [Test]
        public void Texture()
        {
            Test(new glTFTexture { });
        }

        [Test]
        public void TextureInfo()
        {
            Test(new glTFTextureInfo { });
        }
    }
}
