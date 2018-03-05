using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using WordReportsFull.EventsFull;
using WordReportsFull.Trige.SelectVisibl;
using WordReportsFull.Trige.UregTrig;
using WordReportsFull.ValidationControl;

namespace WordReportsFull.EventsFull
{
   public class SeathControl
    {


        public TextBox Seathinn(ListView listFile)
        {
            ListBoxItem myListBoxItem = (ListBoxItem)listFile.ItemContainerGenerator.ContainerFromItem(listFile.Items.CurrentItem);
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            TextBox myTextBlock = (TextBox)myDataTemplate.FindName("INN", myContentPresenter);
            return myTextBlock;
        }

        public TextBox Seathgod(ListView listFile)
        {
            ListBoxItem myListBoxItem = (ListBoxItem)listFile.ItemContainerGenerator.ContainerFromItem(listFile.Items.CurrentItem);
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            TextBox myTextBlock = (TextBox)myDataTemplate.FindName("GOD", myContentPresenter);
            return myTextBlock;
        }



        private TChildItem FindVisualChild<TChildItem>(DependencyObject obj) where TChildItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                var item = child as TChildItem;
                if (item != null)
                    return item;
                else
                {
                    TChildItem childOfChild = FindVisualChild<TChildItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }


    }
}
