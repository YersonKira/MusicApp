using Music.WindowsStore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Music.WindowsStore.View
{
    public sealed partial class LessonsPage : Page
    {
        public LessonsPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            progress.IsActive = true;
            var result = await InformationProvider.GetMethods();
            MethodsCollection.Source = new ObservableCollection<Method>(result.ToList());
            ZoomOutGridView.ItemsSource = MethodsCollection.View.CollectionGroups;
            progress.IsActive = false;
            base.OnNavigatedTo(e);
        }

        private void LessonSelected(object sender, SelectionChangedEventArgs e)
        {
            Lesson selectedLesson = (Lesson)LessonsList.SelectedItem;
            this.Frame.Navigate(typeof(LessonDetailPage), selectedLesson.File_Name);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }
    }
}
