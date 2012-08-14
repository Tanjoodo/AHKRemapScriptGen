using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoHotKeyRemapScriptGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Win32.SaveFileDialog SaveFileDialog = new Microsoft.Win32.SaveFileDialog();
        
        public MainWindow()
        {            
            InitializeComponent();
           
           SaveFileDialog.DefaultExt = ".ahk";
           SaveFileDialog.Filter = "AutoHotKey Script| *.ahk";

            
           
        }

        private void KeyRemap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddEntry();
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddEntry();
        }   

         private void DeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            DeleteEntry();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteEntry();
        }
        
        private void AddEntry()
        {
            KeyToBeRemapped.Focus();
            listBox1.Items.Add(KeyToBeRemapped.Text + "::" + KeyRemap.Text);
            KeyToBeRemapped.Text = "";
            KeyRemap.Text = "";
        }

        private void DeleteEntry()
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Nullable<bool> result = SaveFileDialog.ShowDialog();
            
            if (result == true)
            {
                StreamWriter sw = new StreamWriter(SaveFileDialog.FileName);                
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    sw.WriteLine(listBox1.Items[i]);
                }                
                sw.Close();
            }

        }
        
    }
}
