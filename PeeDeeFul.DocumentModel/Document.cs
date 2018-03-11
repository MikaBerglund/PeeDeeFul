﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    /// <summary>
    /// Represents a PDF document.
    /// </summary>
    /// <remarks>
    /// You can customize how doucuments look by inheriting from this class and overriding its methods and properties. You
    /// can also create new document types that introduce their own elements.
    /// </remarks>
    public class Document : ContainerObject
    {
        /// <summary>
        /// Creates a new document.
        /// </summary>
        public Document() : base(null)
        {
        }



        public Section LastSection
        {
            get { return this.Sections.Last(); }
        }

        public IEnumerable<Section> Sections
        {
            get { return this.GetChildren<Section>(); }
        }



        /// <summary>
        /// Adds the given section to the document.
        /// </summary>
        public Document Add(Section section)
        {
            base.Add(section);
            return this;
        }

        /// <summary>
        /// Adds a new section to the document and returns the section.
        /// </summary>
        public Section AddSection()
        {
            return this.Add<Section>();
        }


        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("\\document");
            writer.WriteLine("[");
            writer.WriteLine("]");

            writer.WriteLine("{");
            base.WriteDdl(writer);
            writer.WriteLine("}");

        }
    }
}
