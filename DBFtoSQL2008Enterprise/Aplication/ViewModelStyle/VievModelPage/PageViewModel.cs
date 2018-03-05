using System;
using ViewModelLib.ViewModelPage;
using MaterialDesignThemes.Wpf;
using ViewModelLib.ViewModelPage.ViewModel;

namespace DBFtoSQL2008Enterprise.Aplication.ViewModelStyle.VievModelPage
{
    
/// <summary>
/// Собственно наша модель 
/// </summary>
    class PageViewModel
    {
        /// <summary>
        /// Массив объектов
        /// </summary>
        public DemoItemIntereface[] DemoItemIntereface { get; }
/// <summary>
/// Наша модель страниц можно добавлять
/// </summary>
/// <param name="messageQueue"></param>
        public PageViewModel(ISnackbarMessageQueue messageQueue)
        {
        
            if (messageQueue == null ) throw  new ArgumentException(nameof(messageQueue));
            DemoItemIntereface = new[]
            {
                new DemoItemIntereface("Конвертация DBF to SQL", new Page.ConvertDbFtoSql {DataContext = new Page.ConvertDbFtoSql()},
                    new[]
                    {
                        Link.Pageses<Page.ConvertDbFtoSql>()
                    }),
            };
        }

    }
}
