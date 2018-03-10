using System;
using System.Collections.Generic;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    /// <summary>
    /// A document object that contains other document objects. A container object is different from
    /// a composite object in the way that the container object can itself have visual appearance,
    /// like a frame or table cell.
    /// </summary>
    public abstract class ContainerObject : CompositeObject
    {
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="parent">The parent object of the container object.</param>
        protected ContainerObject(DocumentObject parent) : base(parent) { }

    }
}
