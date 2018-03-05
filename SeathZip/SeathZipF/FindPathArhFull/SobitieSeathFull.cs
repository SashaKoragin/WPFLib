using System;
using System.ComponentModel;
using System.IO;
using SevenZip;
using System.Windows.Forms;

namespace SeathZip.SeathZipF.FindPathArhFull
{
   internal class SobitieSeathFull : IDisposable
    {
        public Forms.Pages.SeathFullPath P2;

        public SobitieSeathFull(Forms.Pages.SeathFullPath owner)  //Конструктор для формы xaml
        {
            P2 = owner;
            P2.DataContext = this;
        }

        public BackgroundWorker Worker2 = new BackgroundWorker();

        ~SobitieSeathFull()
        {
            Dispose(false);
        }

        private bool _disposed;
        public FileStream Stream;
        public FileStream Createnamefile;
        public SevenZipExtractor Strf;
        public StreamReader FileStrim;
        internal void ToGo()
        {
            Worker2.WorkerReportsProgress = true;
            Worker2.WorkerSupportsCancellation = true;
            Worker2.DoWork += worker_DoworkConvertFile;
            Worker2.ProgressChanged += worker_progressChange;
            Worker2.RunWorkerCompleted += worker_RunWorkerComplete;
            Worker2.RunWorkerAsync();
            P2.SeathArhFileFull.IsEnabled = false;
        }

        internal void worker_DoworkConvertFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                var zn = (SeathPath.PathStart)P2.Dispatcher.Invoke(() =>P2.TextFull.DataContext);
                if ( !Validate.IsValid.IsSeathZn(P2.TextBoxFull)|| string.IsNullOrWhiteSpace(zn.FullPath))
                {
                   Worker2.CancelAsync();
                }
                else
                {
                            P2.Dispatcher.Invoke(() => P2.StatusFull.Text = @"Собираем архивы в папках!!!");
                            string[] filesarj = Arh.Seath.Seatharj(zn.FullPath);
                            var proc = (100.0f / filesarj.Length);
                    if (Capacity.Capacity.GetOsBit() == "x64")
                    {SevenZipBase.SetLibraryPath(Configuration.Conf.PathDll64);}
                    else
                    {SevenZipBase.SetLibraryPath(Configuration.Conf.PathDll32);}
                    foreach (var filearj in filesarj)
                            {
                                Worker2.ReportProgress((int)(proc * 100.0f));
                                P2.Dispatcher.Invoke(() => P2.StatusFull.Text = @"Осуществляем поиск файла!!!");
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
                                                if (readLine.Contains(P2.Dispatcher.Invoke(() => P2.TextBoxFull.Text)))
                                                {
                                                    Strf.ExtractFiles(Configuration.Conf.OkPath, entry);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            SeathPath.PathSt.FilePath(sender, P2.Dispatcher.Invoke(() => P2.ListFileArhFull));
                            Arh.Seath.Delet();
                            Dispose();
                }
            }
            catch (Exception n)
            {
                MessageBox.Show(n.ToString());
            }
        }

        internal void worker_progressChange(object sender, ProgressChangedEventArgs e)
        {
            P2.ProgressFull.Value += e.ProgressPercentage;
        }

        private void worker_RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            P2.StatusFull.Dispatcher.Invoke(() => P2.StatusFull.Text = @"Закончили!!!");
            P2.SeathArhFileFull.IsEnabled = true;
            P2.ProgressFull.Value = 10000;
            P2.ProgressFull.Value = 0;
            Worker2.CancelAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if(FileStrim !=null)
                    { FileStrim.Dispose(); }
                    if (Stream != null)
                    { Stream.Dispose(); }
                    if (Strf != null)
                    { Strf.Dispose(); }
                    if (Createnamefile != null)
                    { Createnamefile.Dispose(); }
                    if (Worker2 != null)
                    { Worker2.Dispose(); }
                    FileStrim = null;
                    Stream = null;
                    Strf = null;
                    Createnamefile = null;
                }
            }
            _disposed = true;
        }
    }
}
