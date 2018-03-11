using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class PageSetup : DocumentObject
    {
        public PageSetup() : this(null) { }

        public PageSetup(DocumentObject parent) : base(parent)
        {
            this.Orientation = Orientation.Landscape;
            this.PageFormat = PageFormat.A4;

            this.TopMargin = new Unit(2.5, UnitType.Centimeter);
            this.LeftMargin = this.TopMargin;
            this.RightMargin = this.TopMargin;
            this.BottomMargin = new Unit(2, UnitType.Centimeter);

            this.HeaderDistance = new Unit(1.25, UnitType.Centimeter);
            this.FooterDistance = new Unit(1.25, UnitType.Centimeter);

            this.StartingNumber = 1;
        }


        public Unit TopMargin
        {
            get { return this.GetProperty<Unit>(nameof(TopMargin)); }
            set { this.SetProperty(nameof(TopMargin), value); }
        }

        public Unit RightMargin
        {
            get { return this.GetProperty<Unit>(nameof(RightMargin)); }
            set { this.SetProperty(nameof(RightMargin), value); }
        }

        public Unit BottomMargin
        {
            get { return this.GetProperty<Unit>(nameof(BottomMargin)); }
            set { this.SetProperty(nameof(BottomMargin), value); }
        }

        public Unit LeftMargin
        {
            get { return this.GetProperty<Unit>(nameof(LeftMargin)); }
            set { this.SetProperty(nameof(LeftMargin), value); }
        }

        public bool MirrorMargins
        {
            get { return this.GetProperty<bool>(nameof(MirrorMargins)); }
            set { this.SetProperty(nameof(MirrorMargins), value); }
        }



        public bool DifferentFirstPageHeaderFooter
        {
            get { return this.GetProperty<bool>(nameof(DifferentFirstPageHeaderFooter)); }
            set { this.SetProperty(nameof(DifferentFirstPageHeaderFooter), value); }
        }

        public Unit FooterDistance
        {
            get { return this.GetProperty<Unit>(nameof(FooterDistance)); }
            set { this.SetProperty(nameof(FooterDistance), value); }
        }

        public Unit HeaderDistance
        {
            get { return this.GetProperty<Unit>(nameof(HeaderDistance)); }
            set { this.SetProperty(nameof(HeaderDistance), value); }
        }



        public bool HorizontalPageBreak
        {
            get { return this.GetProperty<bool>(nameof(HorizontalPageBreak)); }
            set { this.SetProperty(nameof(HorizontalPageBreak), value); }
        }

        public bool OddAndEvenPagesHeaderFooter
        {
            get { return this.GetProperty<bool>(nameof(OddAndEvenPagesHeaderFooter)); }
            set { this.SetProperty(nameof(OddAndEvenPagesHeaderFooter), value); }
        }

        public Orientation Orientation
        {
            get { return this.GetProperty<Orientation>(nameof(Orientation)); }
            set { this.SetProperty(nameof(Orientation), value); }
        }

        public PageFormat PageFormat
        {
            get { return this.GetProperty<PageFormat>(nameof(PageFormat)); }
            set { this.SetProperty(nameof(PageFormat), value); }
        }


        public Unit PageHeight
        {
            get { return this.GetProperty<Unit>(nameof(PageHeight)); }
            set { this.SetProperty(nameof(PageHeight), value); }
        }


        public Unit PageWidth
        {
            get { return this.GetProperty<Unit>(nameof(PageWidth)); }
            set { this.SetProperty(nameof(PageWidth), value); }
        }




        public int StartingNumber
        {
            get { return this.GetProperty<int>(nameof(StartingNumber)); }
            set { this.SetProperty(nameof(StartingNumber), value); }
        }


        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("PageSetup");
            writer.WriteLine("{");

            this.WriteUnit(nameof(TopMargin), this.TopMargin, writer);
            this.WriteUnit(nameof(RightMargin), this.RightMargin, writer);
            this.WriteUnit(nameof(BottomMargin), this.BottomMargin, writer);
            this.WriteUnit(nameof(LeftMargin), this.LeftMargin, writer);

            writer.WriteLine($"DifferentFirstPageHeaderFooter = {this.DifferentFirstPageHeaderFooter}");
            this.WriteUnit(nameof(HeaderDistance), this.HeaderDistance, writer);
            this.WriteUnit(nameof(FooterDistance), this.FooterDistance, writer);

            writer.WriteLine($"HorizontalPageBreak = {this.HorizontalPageBreak}");
            writer.WriteLine($"OddAndEvenPagesHeaderFooter = {this.OddAndEvenPagesHeaderFooter}");
            writer.WriteLine($"Orientation = {this.Orientation}");
            writer.WriteLine($"PageFormat = {this.PageFormat}");

            this.WriteUnit(nameof(PageHeight), this.PageHeight, writer);
            this.WriteUnit(nameof(PageWidth), this.PageWidth, writer);

            writer.WriteLine($"StartingNumber = {this.StartingNumber}");

            writer.WriteLine("}");
        }

        


        private void WriteUnit(string name, Unit value, TextWriter writer)
        {
            if(null != value)
            {
                writer.Write(name);
                writer.Write(" = ");
                value.WriteDdl(writer);
                writer.WriteLine();
            }
        }
    }
}
