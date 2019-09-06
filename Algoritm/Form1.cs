using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Automation;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using ZXing;
using ZXing.Common;
using System.Windows.Media.Imaging;
namespace Algoritm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// test
        /// </summary>
      //  private int[] bases = { 1,2,3 };
    //   private int[] spliters = { 4 };
     //   private int[] bases = { 1, 2, 3 };
      //  private int[] spliters = { 2,10 };
        /// <summary>
        /// Исходные данные
        /// </summary>
           private int[] bases = {3,6,7,9,13,18,20};
           private int[] spliters = { 1,4,9,15,20,23,24 };

        /// <summary>
        /// Решение 2
        /// </summary>
        private List<List<int>> result1 = new List<List<int>>();
        private List<int> newList = new List<int>();

        /// <summary>
        /// Решение 1 и Решение 3
        /// </summary>
        private List<int[]> result  = new List<int[]>();

        private int[] mass = null;

        private void button1_Click(object sender, EventArgs e)
        { 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int base_index = 0;
            int splitter_index = 0;

            while (base_index<bases.Length)
            {
                while (base_index<bases.Length && (splitter_index>=spliters.Length||bases[base_index]<=spliters[splitter_index]))
                {
                    newList.Add(bases[base_index]);
                    base_index++;
                }
                if (newList.Count > 0)
                {
                    result1.Add(newList);
                    newList = new List<int>();
                }
                splitter_index++;
            }
            var u = result1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var s = new Sample();
            s.Print();
            ISample i = s;
            i.Print();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {

           ZXing.BarcodeWriter writer = new BarcodeWriter();
           writer.Format = BarcodeFormat.CODE_128;

            writer.Options.PureBarcode = true;
            writer.Options.Margin = 0;
            writer.Options.Height = 75;
            writer.Options.Width = 200;
            
            var bmp = writer.Write("1");  //.Save("C:\\Users\\7751_svc_admin\\Desktop\\ff.bmp");
            bmp.Save("C:\\Users\\7751_svc_admin\\Desktop\\Асанова Алла Владимировна.bmp");
            CreateDocum("C:\\Users\\7751_svc_admin\\Desktop\\Асанова Алла Владимировна.docx", "C:\\Users\\7751_svc_admin\\Desktop\\Асанова Алла Владимировна.bmp");
        }

        private void button8_Click(object sender, EventArgs e)
        {

            FileStream stream = new FileStream("C:\\Users\\7751_svc_admin\\Desktop\\image.tif", FileMode.Open);
            var path = Tiff2Pngs(stream);
            foreach (var p in path)
            {
                using (Bitmap bitmap = new Bitmap(p))
                {
                    BarcodeReader reader = new BarcodeReader { AutoRotate = true, Options = new DecodingOptions() { TryHarder = true } };
                    Result result = reader.Decode(bitmap);
                    if (result != null)
                    {
                        MessageBox.Show(result.Text);
                    }
                    else
                    {
                        MessageBox.Show("Ищем");
                    }
                }
            }
        }

        public static string[] Tiff2Pngs(FileStream tiffImagePath)
        {
            // PNG image location array
            string[] pngPaths = null;

            // Get an FileStream for reading the TIFF image
            using (tiffImagePath)
            {
                // get a TiffBitmapDecoder
                TiffBitmapDecoder tifDecoder = new TiffBitmapDecoder(tiffImagePath
                    , BitmapCreateOptions.PreservePixelFormat
                    , BitmapCacheOption.Default);

                // Initialize PNG image location array
                pngPaths = new string[tifDecoder.Frames.Count];


                // Save each page in the TIFF image
                for (int i = 0; i < tifDecoder.Frames.Count; i++)
                {
                    // Get a PngBitmapEncoder
                    PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
                    pngEncoder.Frames.Add(tifDecoder.Frames[i]);

                    // Construct a PNG image location
                    string pngPath = "C:\\Users\\7751_svc_admin\\Desktop\\" + i.ToString() + ".png";

                    pngPaths[i] = pngPath;

                    // Save the PNG image
                    using (FileStream pngFs = new FileStream(pngPath, FileMode.Create))
                    {
                        pngEncoder.Save(pngFs);
                    }
                }
            }
            return pngPaths;
        }


        public void CreateDocum(string fullpath, string file)
        {

            using (WordprocessingDocument package = WordprocessingDocument.Create(fullpath, WordprocessingDocumentType.Document))
            {
                CreateWord(package, file);
                package.MainDocumentPart.Document.Save();
                package.Close();
            }
        }



        public void CreateWord(WordprocessingDocument package, string file)
        {
            MainDocumentPart mainDocumentPart = package.AddMainDocumentPart();
            Document document = new Document();
            ImagePart image = mainDocumentPart.AddImagePart(ImagePartType.Jpeg);
            using (FileStream stream = new FileStream(file,FileMode.Open))
            {
                image.FeedData(stream);
            }
            document.Append(AddImageToBody(mainDocumentPart.GetIdOfPart(image)));
            mainDocumentPart.Document = document;
        }
        public static string[] Tiff2Pngs(string tiffImagePath)
        {
            // PNG image location array
            string[] pngPaths = null;

            // Get an FileStream for reading the TIFF image
            using (FileStream tifFs = new FileStream(
                tiffImagePath, FileMode.Open, FileAccess.Read))
            {
                // get a TiffBitmapDecoder
                TiffBitmapDecoder tifDecoder = new TiffBitmapDecoder(tifFs
                    , BitmapCreateOptions.PreservePixelFormat
                    , BitmapCacheOption.Default);

                // Initialize PNG image location array
                pngPaths = new string[tifDecoder.Frames.Count];


                // Save each page in the TIFF image
                for (int i = 0; i < tifDecoder.Frames.Count; i++)
                {
                    // Get a PngBitmapEncoder
                    PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
                    pngEncoder.Frames.Add(tifDecoder.Frames[i]);

                    // Construct a PNG image location
                    string pngPath = string.Format("{0}_{1}{2}",
                        tiffImagePath.Substring(0
                            , tiffImagePath.LastIndexOf("."))
                        , i.ToString()
                        , ".png");

                    pngPaths[i] = pngPath;

                    // Save the PNG image
                    using (FileStream pngFs = new FileStream(
                        pngPath, FileMode.Create, FileAccess.Write))
                    {
                        pngEncoder.Save(pngFs);
                    }
                }
            }

            return pngPaths;
        }
        private Paragraph  AddImageToBody( string relationshipId)
        {

            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 1500000L, Cy = 500000L },
                         
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Barcode"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "Barcode"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 1500000L, Cy = 500000L }
                                            ),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            // Append the reference to body, the element should be in a Run.
           return new Paragraph(new Run(element));
        }

        private void button9_Click(object sender, EventArgs e)
        {
          //  var process = Process.S  //.GetProcessesByName("CommonComponents.UnifiedClient.exe");
            AutomationElement targetApp = AutomationElement.FromHandle() //FromHandle(process[0].MainWindowHandle);


        }
    }
    }



    public interface ISample
    {
        void Print(string val = "1");
    }
    public class Sample : ISample
    {
        public void Print(string val = "2")
        {
            System.Console.Write(val);
        }

        public void S()
        {   
        }
    }