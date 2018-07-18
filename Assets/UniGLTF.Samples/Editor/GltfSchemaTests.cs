using NUnit.Framework;
using System.IO;
using UniGLTF;
using UniJSON;
using UnityEngine;


namespace UniGLTFJson
{
    public class GltfSchemaTests
    {
        static IFileSystemAccessor m_schemaDir;
        static IFileSystemAccessor SchemaDir
        {
            get
            {
                if (m_schemaDir == null)
                {
                    var path = Path.GetFullPath(Application.dataPath + "/../glTF/specification/2.0/schema");
                    m_schemaDir = new FileSystemAccessor(path);
                }
                return m_schemaDir;
            }
        }

        [Test]
        public void Accessor()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("accessor.schema.json"));
            var fromClass = JsonSchema.FromType<glTFAccessor>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void AccessorSparseIndices()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("accessor.sparse.indices.schema.json"));
            var fromClass = JsonSchema.FromType<glTFSparseIndices>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void AccessorSparse()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("accessor.sparse.schema.json"));
            var fromClass = JsonSchema.FromType<glTFSparse>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void AccessorSparseValues()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("accessor.sparse.values.schema.json"));
            var fromClass = JsonSchema.FromType<glTFSparseValues>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void AnimationChannel()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("animation.channel.schema.json"));
            var fromClass = JsonSchema.FromType<glTFAnimationChannel>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void AnimationChannelTarget()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("animation.channel.target.schema.json"));
            var fromClass = JsonSchema.FromType<glTFAnimationTarget>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void AnimationSampler()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("animation.sampler.schema.json"));
            var fromClass = JsonSchema.FromType<glTFAnimationSampler>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Animation()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("animation.schema.json"));
            var fromClass = JsonSchema.FromType<glTFAnimation>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Asset()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("asset.schema.json"));
            var fromClass = JsonSchema.FromType<glTFAssets>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Buffer()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("buffer.schema.json"));
            var fromClass = JsonSchema.FromType<glTFBuffer>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void BufferView()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("bufferView.schema.json"));
            var fromClass = JsonSchema.FromType<glTFBufferView>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Camera()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("camera.schema.json"));
            var fromClass = JsonSchema.FromType<glTFCamera>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void CameraOrthographic()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("camera.orthographic.schema.json"));
            var fromClass = JsonSchema.FromType<glTFOrthographic>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void CameraPerspective()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("camera.perspective.schema.json"));
            var fromClass = JsonSchema.FromType<glTFPerspective>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Gltf()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("glTF.schema.json"));
            var fromClass = JsonSchema.FromType<glTF>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Image()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("image.schema.json"));
            var fromClass = JsonSchema.FromType<glTFImage>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void MaterialNormalTextureInfo()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("material.normalTextureInfo.schema.json"));
            var fromClass = JsonSchema.FromType<glTFMaterialNormalTextureInfo>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void MaterialOcclusionTextureInfo()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("material.occlusionTextureInfo.schema.json"));
            var fromClass = JsonSchema.FromType<glTFMaterialOcclusionTextureInfo>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void MaterialPbrMetallicRoughness()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("material.pbrMetallicRoughness.schema.json"));
            var fromClass = JsonSchema.FromType<glTFPbrMetallicRoughness>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Material()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("material.schema.json"));
            var fromClass = JsonSchema.FromType<glTFMaterial>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void MeshPrimitive()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("mesh.primitive.schema.json"));
            var fromClass = JsonSchema.FromType<glTFPrimitives>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Mesh()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("mesh.schema.json"));
            var fromClass = JsonSchema.FromType<glTFMesh>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Node()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("node.schema.json"));
            var fromClass = JsonSchema.FromType<glTFNode>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Sampler()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("sampler.schema.json"));
            var fromClass = JsonSchema.FromType<glTFTextureSampler>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Scene()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("scene.schema.json"));
            var fromClass = JsonSchema.FromType<gltfScene>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Skin()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("skin.schema.json"));
            var fromClass = JsonSchema.FromType<glTFSkin>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void Texture()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("texture.schema.json"));
            var fromClass = JsonSchema.FromType<glTFTexture>();
            Assert.AreEqual(fromSchema, fromClass);
        }

        [Test]
        public void TextureInfo()
        {
            var fromSchema = JsonSchema.ParseFromPath(SchemaDir.Get("textureInfo.schema.json"));
            var fromClass = JsonSchema.FromType<glTFTextureInfo>();
            Assert.AreEqual(fromSchema, fromClass);
        }
    }
}
