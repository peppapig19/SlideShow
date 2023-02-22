using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SlideShow
{
    class Pic
    {
        public string Filename { get; }
        public BitmapImage Image { get; }

        public Pic(string path)
        {
            Filename = Path.GetFileName(path);
            Image = new BitmapImage(new Uri(path, UriKind.Absolute));
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            names_listBox.ItemsSource = pics;
            slideshow_listBox.ItemsSource = pics;
        }

        ObservableCollection<Pic> pics = new ObservableCollection<Pic>();

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images|*.png;*.jpg;*.jpeg";

            if (dialog.ShowDialog() == true)
            {
                Pic pic = new Pic(dialog.FileName);
                pics.Add(pic);
            }
        }

        private void slideshow_listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pic pic = (Pic)slideshow_listBox.SelectedItem;
            big_image.Source = pic.Image;
            names_listBox.SelectedItem = pic;
        }

        private void names_listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pic pic = (Pic)names_listBox.SelectedItem;
            big_image.Source = pic.Image;
            slideshow_listBox.SelectedItem = pic;
        }
    }
}