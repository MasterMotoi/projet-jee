﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using com;
using System.IO;
using System.Threading;
using System.Windows.Controls.Primitives;
using model;

namespace WpfFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void startWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            emptyList.IsOpen = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Multiselect = true;
            ofd.Filter = "Text Document (.txt)|*.txt";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (ofd.ShowDialog() == true)
            {                
                foreach (string filename in ofd.FileNames)
                {
                    filenamesLb.Items.Add(filename);
                }
            }
            
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            //model.File[] files = new model.File[filenamesLb.Items.Count];
            int i = 0;
            controller ctrl = new controller();
            String[] jaggedFiles = new String[filenamesLb.Items.Count];


            foreach (string filename in filenamesLb.Items)
            {
                //model.File fileObj = new model.File();

                string[] justName = filename.Split("\\");
                /*fileObj.name = justName[justName.Count() - 1];

                fileObj.data = System.IO.File.ReadAllText(filename);

                fileObj.fileType = ".txt";*/
                //files[i] = fileObj;

                jaggedFiles[i] = $"{justName[justName.Count() - 1]}|{System.IO.File.ReadAllText(filename)}";

                string[] s = jaggedFiles[i].Split(new char[] { '|' }, 2);

                i++;            
            }

            filenamesLb.Items.Clear();

            if (ctrl.checkFilesAndSend(jaggedFiles) == false)
            {
                emptyList.IsOpen = true;
            }

        }
    }
}
