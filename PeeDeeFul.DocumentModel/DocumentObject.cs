using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    /// <summary>
    /// The base class for all objects on a PDF document.
    /// </summary>
    public abstract class DocumentObject
    {
        /// <summary>
        /// Creates a new instance of the document object.
        /// </summary>
        protected DocumentObject()
        {

        }

        /// <summary>
        /// Creates a new instance of the document object.
        /// </summary>
        /// <param name="parent">The parent object of the created object.</param>
        protected DocumentObject(DocumentObject parent)
        {
            this.Parent = parent;
        }

        protected DocumentObject(Document document) : this(document, document) { }

        /// <summary>
        /// Creates a new instance of the document object.
        /// </summary>
        /// <param name="parent">The parent object of the created object.</param>
        /// <param name="document">The document that the created document object is attached to.</param>
        protected DocumentObject(DocumentObject parent, Document document)
        {
            this.Document = document;
            this.Parent = parent;
        }


        private List<DocumentObject> ChildList = new List<DocumentObject>();
        /// <summary>
        /// Returns the child object to the current object.
        /// </summary>
        public IEnumerable<DocumentObject> Children
        {
            get { return this.ChildList.AsQueryable(); }
        }

        /// <summary>
        /// Returns the document the current object is attached to.
        /// </summary>
        public Document Document { get; internal set; }

        /// <summary>
        /// Returns the parent object for the current object.
        /// </summary>
        public DocumentObject Parent { get; internal set; }


        private static CultureInfo NumberCulture = new CultureInfo("en-US");
        /// <summary>
        /// Returns the format provider that is used to format numbers with.
        /// </summary>
        protected IFormatProvider NumberFormatProvider
        {
            get { return NumberCulture; }
        }


        /// <summary>
        /// Returns the parent object as the given type, or <c>null</c>.
        /// </summary>
        /// <typeparam name="TParent">The type of the parent object.</typeparam>
        public TParent GetParent<TParent>() where TParent : DocumentObject
        {
            return this.Parent as TParent;
        }

        /// <summary>
        /// Writes the MDDDL (MigraDoc Document Description Language) that represents the current object to the given writer.
        /// </summary>
        /// <param name="writer">The writer to write the DDL to.</param>
        public virtual void WriteDdl(TextWriter writer)
        {

        }

        /// <summary>
        /// Serializes the object and all its child objects to their MDDDL representation.
        /// </summary>
        public override string ToString()
        {
            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                this.WriteDdl(writer);
            }
            return builder.ToString();
        }



        /// <summary>
        /// Adds the given object as a child object.
        /// </summary>
        /// <param name="child"></param>
        protected void Add(DocumentObject child)
        {
            if (null == child) throw new ArgumentNullException(nameof(child));
            child.Parent = this;
            child.Document = this.GetDocument(this);
            this.ChildList.Add(child);
        }

        /// <summary>
        /// Creates a new object of the given type and adds it as a child to the current object.
        /// </summary>
        /// <typeparam name="TChild">The type of child to add.</typeparam>
        protected TChild Add<TChild>() where TChild : DocumentObject
        {
            var child = Activator.CreateInstance<TChild>();
            this.Add(child);
            return child;
        }

        /// <summary>
        /// Returns the first child object of the given type.
        /// </summary>
        protected TChild GetChild<TChild>() where TChild : DocumentObject
        {
            return this.GetChildren<TChild>().FirstOrDefault();
        }

        /// <summary>
        /// Returns the first child that matches the given predicate.
        /// </summary>
        protected TChild GetChild<TChild>(Func<TChild, bool> predicate) where TChild : DocumentObject
        {
            return this.GetChildren<TChild>(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Returns all child object of the given type.
        /// </summary>
        /// <typeparam name="TChild">The type of child objects to return.</typeparam>
        protected IEnumerable<TChild> GetChildren<TChild>() where TChild : DocumentObject
        {
            return from x in this.Children where x is TChild select (TChild)x;
        }

        /// <summary>
        /// Returns the child objects of the given type filtered by the given predicate.
        /// </summary>
        /// <typeparam name="TChild">The type of child objects to return.</typeparam>
        /// <param name="predicate">The predicate to filter the child object by.</param>
        protected IEnumerable<TChild> GetChildren<TChild>(Func<TChild, bool> predicate) where TChild : DocumentObject
        {
            return from x in this.GetChildren<TChild>().Where(predicate) select x;
        }

        private Dictionary<string, object> Properties = new Dictionary<string, object>();
        protected TProperty GetProperty<TProperty>(string name)
        {
            if(this.Properties.ContainsKey(name) && this.Properties[name] is TProperty)
            {
                return (TProperty)this.Properties[name];
            }
            return default(TProperty);
        }

        protected void SetProperty(string name, object value)
        {
            if(value is DocumentObject)
            {
                var doc = value as DocumentObject;
                doc.Parent = this;
                doc.Document = this.Document;
            }

            this.Properties[name] = value;
        }

        /// <summary>
        /// Writes the name and value of a string property to the given writer.
        /// </summary>
        /// <param name="name">The name of the property to write.</param>
        /// <param name="value">The value of the property to write. The property is not written if the value is null or empty.</param>
        /// <param name="writer">The writer to write to.</param>
        protected void WriteStringProperty(string name, string value, TextWriter writer)
        {
            if(!string.IsNullOrEmpty(value))
            {
                writer.Write(name);
                writer.Write(" = ");
                writer.Write("\"");
                writer.Write(value.Replace(@"""", @"\"""));
                writer.Write("\"");
                writer.WriteLine();
            }
        }


        private Document GetDocument(DocumentObject obj)
        {
            if(obj is Document)
            {
                return (Document)obj;
            }
            return obj.Document;
        }

    }
}
