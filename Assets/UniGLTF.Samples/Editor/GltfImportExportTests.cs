﻿using NUnit.Framework;
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

            Assert.AreEqual(UniJSON.JsonParser.Parse(importJson), UniJSON.JsonParser.Parse(exportJson));
        }
    }
}
