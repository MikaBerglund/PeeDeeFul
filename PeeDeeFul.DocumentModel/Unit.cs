using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Unit : DocumentObject
    {
        public Unit(double points) : this(points, UnitType.Point) { }

        public Unit(double value, UnitType type)
        {
            this.Value = value;
            this.Type = type;
        }

        public double Value { get; private set; }

        public UnitType Type { get; private set; }


        private static CultureInfo NumberCulture = new CultureInfo("en-US");

        public override void WriteDdl(TextWriter writer)
        {
            if (this.Type != UnitType.Point) writer.Write("\"");

            writer.Write(this.Value.ToString(NumberCulture));

            switch(this.Type)
            {
                case UnitType.Centimeter:
                    writer.Write("cm");
                    break;

                case UnitType.Inch:
                    writer.Write("in");
                    break;

                case UnitType.Millimeter:
                    writer.Write("mm");
                    break;

                case UnitType.Pica:
                    writer.Write("pc");
                    break;
            }

            if (this.Type != UnitType.Point) writer.Write("\"");

        }
    }
}
