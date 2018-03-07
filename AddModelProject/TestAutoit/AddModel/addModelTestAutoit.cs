
using System;
using System.Drawing.Printing;
using System.IO;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using AddModelProject.TestAutoit.AddModel.UserControl;
using ViewModelLib.ModelTestAutoit.ShemeXsd;


namespace AddModelProject.TestAutoit.AddModel
{
    public class AddModelTestAutoit
    {
        public Sheme AddShemeUse()
        {
           var  sheme = new Sheme();
            sheme.Shemefulllist.Add(new Sheme() {Document = AddDocument.DocumentSnuOneForm(ExampleXml.ExampleXaml.SnuOneForm), Shemes = "SnuOneForm"});
           // sheme.Shemefulllist.Add(new Sheme() { Document = AddDocument.DocumentSnuOneForm("sdsddsadsadsa"), Shemes = "Новый список" });
            return sheme;
        }
    }
    public class AddDocument
    {
        internal static FlowDocument DocumentSnuOneForm(string example)
        {
            var document = new FlowDocument();
            document.Blocks.Add(new Paragraph(new Run("Образец на выходе!!!")) {TextIndent = 48, FontSize = 20, Foreground = Brushes.Red } );
            document.Blocks.Add(new Paragraph(new Run(example) {FontSize = 12}));
            return document;
        }
    }
}
