// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenDocumentTemplate.cs" company="Allors bvba">
// Copyright 2002-2017 Allors bvba
// This file is licenses under the Lesser General Public Licence v3 (LGPL)
// The LGPL License is included in the file LICENSE.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Document.OpenDocument
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Reflection;

    using Antlr4.StringTemplate;
    using Antlr4.StringTemplate.Misc;

    public class OpenDocumentTemplate
    {
        internal const string ContentFileName = "content.xml";

        internal const string MetaFileName = "META-INF/manifest.xml";

        protected const char DefaultLeftDelimiter = '\u02C2';

        protected const char DefaultRightDelimiter = '\u02C3';

        private const string MainTemplateName = "main";

        private readonly Dictionary<string, byte[]> fileByFileName;

        private readonly TemplateGroup templateGroup;

        private readonly byte[] manifest;

        public OpenDocumentTemplate(byte[] document, string arguments, char leftDelimiter = DefaultLeftDelimiter, char rightDelimiter = DefaultRightDelimiter)
        {
            this.fileByFileName = new Dictionary<string, byte[]>();

            using (var zip = new MemoryStream(document))
            {
                using (var archive = new ZipArchive(zip, ZipArchiveMode.Read))
                {
                    foreach (var entry in archive.Entries)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var zipStream = entry.Open())
                            {
                                zipStream.CopyTo(memoryStream);
                                var file = memoryStream.ToArray();

                                if (entry.FullName.Equals(ContentFileName))
                                {
                                    var errorBuffer = new ErrorBuffer();

                                    var content = new OpenDocumentTemplateContent(file, leftDelimiter, rightDelimiter);
                                    var stringTemplate = content.ToStringTemplate();
                                    var group = MainTemplateName + "(" + arguments + ")" + stringTemplate;
                                    this.templateGroup = new TemplateGroupString(MainTemplateName, group, leftDelimiter, rightDelimiter)
                                                            {
                                                                ErrorManager = new ErrorManager(errorBuffer)
                                                            };

                                    // Force a compilation of the templates to check for errors
                                    this.templateGroup.GetInstanceOf(MainTemplateName);
                                    if (errorBuffer.Errors.Count > 0)
                                    {
                                        throw new TemplateException(errorBuffer.Errors);
                                    }
                                }
                                else if (entry.FullName.Equals(MetaFileName))
                                {
                                    this.manifest = file;
                                }
                                else
                                {
                                    this.fileByFileName.Add(entry.FullName, file);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string InferArguments(Type fromType)
        {
            return string.Join(",", fromType.GetProperties().Select(v => v.Name));
        }

        public byte[] Render(IDictionary<string, object> model, IDictionary<string, byte[]> imageByName = null)
        {
            var clonedFileByFileName = new Dictionary<string, byte[]>(this.fileByFileName);
            var render = new OpenDocumentRendering(model, this.manifest, imageByName, this.templateGroup, clonedFileByFileName);
            return render.Execute();
        }
    }

    public class OpenDocumentTemplate<T> : OpenDocumentTemplate
    {
        private readonly PropertyInfo[] properties;

        public OpenDocumentTemplate(byte[] document, char leftDelimiter = DefaultLeftDelimiter, char rightDelimiter = DefaultRightDelimiter)
            : base(document, OpenDocumentTemplate.InferArguments(typeof(T)), leftDelimiter, rightDelimiter)
        {
            this.properties = typeof(T).GetProperties();
        }


        public byte[] Render(T model, Dictionary<string, byte[]> imageByName = null)
        {
            var dictionary = this.properties.ToDictionary(property => property.Name, property => property.GetValue(model));
            return this.Render(dictionary, imageByName);
        }
    }
}