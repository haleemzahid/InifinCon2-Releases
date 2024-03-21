using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace InfiniCon.App.Behaviors
{
    public static class ListBoxScrollBehavior
    {
        public static readonly DependencyProperty ScrollToBottomProperty =
            DependencyProperty.RegisterAttached(
                "ScrollToBottom",
                typeof(bool),
                typeof(ListBoxScrollBehavior),
                new PropertyMetadata(false, OnScrollToBottomChanged));

        public static bool GetScrollToBottom(DependencyObject obj)
        {
            return (bool)obj.GetValue(ScrollToBottomProperty);
        }

        public static void SetScrollToBottom(DependencyObject obj, bool value)
        {
            obj.SetValue(ScrollToBottomProperty, value);
        }

        private static void OnScrollToBottomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ListBox listBox)
            {
                var scrollViewer = GetScrollViewer(listBox);
                if (scrollViewer != null)
                {
                    scrollViewer.ScrollToEnd();
                }
            }
        }

        public static ScrollViewer GetScrollViewer(DependencyObject element)
        {
            if (element is ScrollViewer viewer)
            {
                return viewer;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                var result = GetScrollViewer(child);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

    }

}
