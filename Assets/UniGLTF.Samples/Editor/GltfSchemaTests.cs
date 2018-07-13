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
    }
}
