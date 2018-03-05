using System;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Windows.Input;


namespace ViewModelLib.ViewModelPage
{
    [DataContract]
    public class Link
    {
        /// <summary>
        /// Основной конструктор куда входят параметры
        /// </summary>
        /// <param name="url"></param>
        /// <param name="label"></param>
        public Link(string url, string label)
        {
            Label = label;
            Url = url;
            Open = new AnotherCommandImplementation(Execute);
        }
        [DataMember]
        public string Label { get; }
        [DataMember]
        public string Url { get; }
        [DataMember]
        public ICommand Open { get; }
        [STAThread]
        public static Link Pageses<TDemoPage>()
        {
            string label ="";
            string nameSpace="";
            var ext = typeof(UserControl).IsAssignableFrom(typeof(TDemoPage))
                ? "xaml"
                : "cs";
            return new Link(
                $"{(string.IsNullOrWhiteSpace(nameSpace) ? "" : ("/" + nameSpace + "/"))}{typeof(TDemoPage).Name}.{ext}",
                label ?? typeof(TDemoPage).Name);
        }
        private void Execute(object o)
        {
            System.Diagnostics.Process.Start(Url);
        }
    }
}