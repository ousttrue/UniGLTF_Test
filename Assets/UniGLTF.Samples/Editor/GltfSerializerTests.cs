using NUnit.Framework;
using UniGLTF;
using UniJSON;


namespace UniGLTFJson
{
    public class GltfSerializerTests
    {
        [Test]
        public void GltfSerializerTestsSimplePasses()
        {
            var gltf = new glTFAccessor
            {
                
            };

            var jsonOld = gltf.ToJson();
            var parsedOld = JsonParser.Parse(jsonOld);

            var s = JsonSchema.FromType<glTFAccessor>();
            var jsonNew = s.Serialize(gltf);
            var parsedNew = JsonParser.Parse(jsonNew);

            Assert.AreEqual(parsedOld, parsedNew);
        }
    }
}
