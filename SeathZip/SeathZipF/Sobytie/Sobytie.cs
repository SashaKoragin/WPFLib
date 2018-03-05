using SevenZip;
using System.IO;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using SeathZip.SeathZipF.Capacity;

namespace SeathZip.SeathZipF.Sobytie
{
    internal class Sobytie : IDisposable
    {

        public Forms.Pages.SeathArg P2;
        public Sobytie(Forms.Pages.SeathArg owner)  //Конструктор для формы xaml
        {
            P2 = owner;
            P2.DataContext = this;
        }

        ~Sobytie()
        {
            Dispose(false);
        }

        public BackgroundWorker Worker = new BackgroundWorker();
        // public MainWindow win = Application.Current.Dispatcher.Invoke(() => (MainWindow)Application.Current.MainWindow);
        public bool Disposed = false;
        public FileStream Stream;
        public FileStream Createnamefile;
        public SevenZipExtractor Strf;
        public StreamReader FileStrim;
        internal void ToGo()
        {
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += worker_DoworkConvertFile;
            Worker.ProgressChanged += worker_progressChange;
            Worker.RunWorkerCompleted += worker_RunWorkerComplete;
            Worker.RunWorkerAsync();
            P2.SeathArhFile.IsEnabled = false;
        }

        internal void worker_DoworkConvertFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!Validate.IsValid.IsSelectcom1(P2.ComboBox) || !Validate.IsValid.IsSelectcom2(P2.ComboBox1) || !Validate.IsValid.IsSeathZn(P2.TextBox))
                {
                    Worker.CancelAsync();
                }
                else
                {
                    var item = (SeathPath.PathStart)P2.Dispatcher.Invoke(() => P2.ComboBox.SelectedValue);
                    var item1 = (SeathPath.PathStart)P2.Dispatcher.Invoke(() => P2.ComboBox1.SelectedValue);
                    P2.Dispatcher.Invoke(() => P2.Status.Text = @"Собираем архивы в папках!!!");
                    string[] filesarj = Arh.Seath.Seatharj(item.NamePath, item1.PathNow);
                    var proc = (100.0f / filesarj.Length);
                    if (Capacity.Capacity.GetOsBit()== "x64")
                    {SevenZipBase.SetLibraryPath(Configuration.Conf.PathDll64);}
                    else
                    {SevenZipBase.SetLibraryPath(Configuration.Conf.PathDll32);}
                        foreach (var filearj in filesarj)
                        {
                           Worker.ReportProgress((int)(proc * 100.0f));
                           P2.Dispatcher.Invoke(() => P2.Status.Text = @"Осуществляем поиск файла!!!");
                            Stream = File.OpenRead(filearj);
                            Strf = new SevenZipExtractor(Stream);
                                 foreach (var entry in Strf.ArchiveFileNames)
                                 {
                                   Createnamefile = new FileStream(Configuration.Conf.RunTimeDerectory + entry, FileMode.Create);
                                   Strf.ExtractFile(entry, Createnamefile);
                                   Createnamefile.Close();
                                   using (FileStrim = new StreamReader(Createnamefile.Name))
                                        {
                                            while (!FileStrim.EndOfStream)
                                            {
                                             var readLine = FileStrim.ReadLine();
                                             if (readLine != null)
                                             {
                                               if (readLine.Contains(P2.Dispatcher.Invoke(() => P2.TextBox.Text)))
                                                    {
                                                        Strf.ExtractFiles(Configuration.Conf.OkPath, entry);
                                                    }
                                                }
                                            }
                                        }
                                 }
                       }

                }
                SeathPath.PathSt.FilePath(sender, P2.Dispatcher.Invoke(() => P2.ListFileArh));
                Arh.Seath.Delet();
                Dispose();
            }
            catch (Exception n)
            {
                MessageBox.Show(n.ToString());
            }
        }

        internal void worker_progressChange(object sender, ProgressChangedEventArgs e)
        {
           P2.Progress.Value += e.ProgressPercentage;
        }

        private void worker_RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            P2.Status.Dispatcher.Invoke(() => P2.Status.Text= @"Закончили!!!");
            P2.SeathArhFile.IsEnabled = true;
            P2.Progress.Value = 10000;
            P2.Progress.Value = 0;
            Worker.CancelAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {

                if (disposing)
                {
                    if (FileStrim != null)
                    { FileStrim.Dispose(); }
                    if (Stream != null)
                    { Stream.Dispose(); }
                    if (Strf != null)
                    { Strf.Dispose(); }
                    if (Createnamefile != null)
                    { Createnamefile.Dispose(); }
                    if (Worker != null)
                    { Worker.Dispose(); }
                    FileStrim = null;
                    Stream = null;
                    Strf = null;
                    Createnamefile = null;
                }
            }
            Disposed = true;
        }
    }
}
