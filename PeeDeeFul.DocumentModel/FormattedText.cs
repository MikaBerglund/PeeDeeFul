using System;
using System.Collections.Generic;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class FormattedText : ContainerObject
    {
        public FormattedText() : this(null) { }

        public FormattedText(DocumentObject parent) : base(parent) { }


        public bool Bold
        {
            get { return this.GetProperty<bool>(nameof(Bold)); }
            set { this.SetProperty(nameof(Bold), value); }
        }

        public Color Color
        {
            get { return this.GetProperty<Color>(nameof(Color)); }
            set { this.SetProperty(nameof(Color), value); }
        }

    }
}
