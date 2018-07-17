using NUnit.Framework;
using System.Collections.Generic;
using UniGLTF;
using UniJSON;


namespace UniGLTFJson
{
    public class GltfSerializerTests
    {
        [Test]
        public void GltfSerializer()
        {
            var gltf = new glTF
            {
                accessors = new List<glTFAccessor>
                {
                    new glTFAccessor
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
                    }
                }
            };

            var jsonOld = gltf.ToJson();

            var s = JsonSchema.FromType(gltf.GetType());
            var jsonNew = s.Serialize(gltf);

            Assert.AreEqual(jsonOld, jsonNew);
        }
    }
}
