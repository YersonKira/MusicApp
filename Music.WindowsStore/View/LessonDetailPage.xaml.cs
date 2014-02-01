using Music.WindowsStore.Model;
using System;
using System.Collections.Generic;
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
    public sealed partial class LessonDetailPage : Page
    {
        public LessonDetailPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var lessonfilename = e.Parameter as string;
            var lesson = await InformationProvider.GetLesson(lessonfilename);
            next.IsEnabled = !string.IsNullOrEmpty(lesson.NextLessonFile);
            previous.IsEnabled = !string.IsNullOrEmpty(lesson.PreviousLessonFile);
            this.DataContext = lesson;
            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LessonsPage));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        private void PreviousLesson(object sender, RoutedEventArgs e)
        {
            Lesson currentlesson = this.DataContext as Lesson;
            this.Frame.Navigate(typeof(LessonDetailPage),currentlesson.PreviousLessonFile);
        }

        private void NextLesson(object sender, RoutedEventArgs e)
        {
            Lesson currentlesson = this.DataContext as Lesson;
            this.Frame.Navigate(typeof(LessonDetailPage), currentlesson.NextLessonFile);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
