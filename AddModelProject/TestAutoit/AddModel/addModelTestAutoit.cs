
using System;
using System.Drawing.Printing;
using System.IO;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using ViewModelLib.ModelTestAutoit.ShemeXsd;


namespace AddModelProject.TestAutoit.AddModel
{
    public class AddModelTestAutoit
    {
        public void AddXmlFile()
        {
            
        }

        public Sheme AddShemeUse(UserControl[] test)
        {
           var  sheme = new Sheme();
            sheme.Shemefulllist.Add(new Sheme() {Document = AddDocument.DocumentSnuOneForm(ExampleXml.ExampleXaml.SnuOneForm), Shemes = "SnuOneForm", UserContr = test[0] });
            sheme.Shemefulllist.Add(new Sheme() { Document = AddDocument.DocumentSnuOneForm("sdsddsadsadsa"), Shemes = "Новый список" , UserContr = test[1]});
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
