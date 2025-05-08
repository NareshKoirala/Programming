//*************************************************************
//Program: Lab04
//Description: Lab04
//Date: DEC. 13/2023
//Author: Naresh Koirala
//Course: CMPE1666
//Class: CNT-A01
//**************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace NKoirala_LAB04
{
    public struct SMD5File//struct
    {
        public string sPath;
        public string sMD5;
        public override string ToString()
        {
            return $"{sMD5} : {sPath}";
        }
    }

    public partial class Form1 : Form
    {
        private MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();//to convert to hash
        private List<SMD5File> filesWithHashes = new List<SMD5File>();//save the has to struct

        public Form1()
        {
            InitializeComponent();
        }

        //***********************************************************************************
        //Method: private new void DragEnter(object sender, DragEventArgs e)
        //Purpose: to enter the draged file
        //*******************************************************************************
        private new void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        //***********************************************************************************
        //Method: private void UI_labelDropDown_DragDrop(object sender, DragEventArgs e)
        //Purpose: to get the droped file
        //*******************************************************************************
        private void UI_labelDropDown_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedItems = (string[])e.Data.GetData(DataFormats.FileDrop);

            List<string> folderPaths = new List<string>();

            foreach (string item in droppedItems)
            {
                if (System.IO.File.GetAttributes(item).HasFlag(FileAttributes.Directory))
                {
                    folderPaths.Add(item);

                    DirectoryInfo di = new DirectoryInfo(item); 
                    List<FileInfo> subs = di.EnumerateFiles("*.*", SearchOption.AllDirectories).ToList();


                    foreach (FileInfo file in subs)
                    {
                        if (!file.Attributes.HasFlag(FileAttributes.Directory))
                        {
                            string hash = GenerateFileHash(file.FullName);
                            filesWithHashes.Add(new SMD5File { sPath = file.FullName, sMD5 = hash });
                        }
                    }
                }
            }
            addingToListBox();
        }

        //***********************************************************************************
        //Method: private string GenerateFileHash(string filePath)
        //Purpose: get the string of hash
        //*******************************************************************************
        private string GenerateFileHash(string filePath)
        {
            using (FileStream stream = System.IO.File.OpenRead(filePath))
            {
                byte[] hashBytes = crypto.ComputeHash(stream);
                return FormatBytesToString(hashBytes);
            }
        }
        //***********************************************************************************
        //Method: private string FormatBytesToString(byte[] bytes)
        //Purpose: to format the hash
        //*******************************************************************************
        private string FormatBytesToString(byte[] bytes)
        {
            string result = "";

            foreach (byte b in bytes)
            {
                result += b.ToString("X2") + "-";
            }


            if (!string.IsNullOrEmpty(result))
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }
        //***********************************************************************************
        //Method: private void addingToListBox()
        //Purpose: to add to the list box
        //*******************************************************************************
        private void addingToListBox()
        {
            UI_ListBox.Items.Clear();

            filesWithHashes = filesWithHashes.OrderBy(f => f.sMD5).ToList();

            foreach (var file in filesWithHashes)
            {
                UI_ListBox.Items.Add(file);
            }
        }

        //***********************************************************************************
        //Method: private void UI_buttonDup_Click(object sender, EventArgs e)
        //Purpose: to find the duplicate
        //*******************************************************************************
        private void UI_buttonDup_Click(object sender, EventArgs e)
        {
            UI_ListBox.Items.Clear();

            HashSet<string> hashSet = new HashSet<string>();
            HashSet<string> duplicates = new HashSet<string>();

            foreach (var file in filesWithHashes)
            {
                if (!hashSet.Add(file.sMD5))
                {
                    duplicates.Add(file.sMD5);
                }
            }

            foreach (var file in filesWithHashes)
            {
                if (duplicates.Contains(file.sMD5))
                {
                    UI_ListBox.Items.Add(file);
                }
            }

            if (UI_ListBox.Items.Count == 0)
            {
                UI_ListBox.Items.Add("no duplicates found");
            }

        }

        //***********************************************************************************
        //Method:  private void UI_buttonRest_Click(object sender, EventArgs e)
        //Purpose: to save it to a file
        //*******************************************************************************
        private void UI_buttonRest_Click(object sender, EventArgs e)
        {

            if (UI_ListBox.SelectedItem is SMD5File selectedFile)
            {
                StringBuilder comparisonResults = new StringBuilder();

                foreach (var file in filesWithHashes)
                {
                    if (file.sMD5 == selectedFile.sMD5 && file.sPath != selectedFile.sPath)
                    {
                        if (AreFilesIdentical(selectedFile.sPath, file.sPath))
                        {
                            comparisonResults.AppendLine($"Files {selectedFile.sPath} and {file.sPath} are identical.");
                        }
                        else
                        {
                            comparisonResults.AppendLine($"Files {selectedFile.sPath} and {file.sPath} differ.");
                        }
                    }
                }

                string filePath = "FileCompResults.txt";

                System.IO.File.WriteAllText(filePath, comparisonResults.ToString());

                System.Diagnostics.Process.Start("notepad.exe", filePath);
            }
            else
            {
                MessageBox.Show("Please select a file from the list to resolve duplicates.");
            }

        }

        //***********************************************************************************
        //Method:   private bool AreFilesIdentical(string filePath1, string filePath2)
        //Purpose: to compare to files
        //*******************************************************************************
        private bool AreFilesIdentical(string filePath1, string filePath2)
        {
            byte[] file1 = System.IO.File.ReadAllBytes(filePath1);
            byte[] file2 = System.IO.File.ReadAllBytes(filePath2);

            return file1.SequenceEqual(file2);
        }
    }
}
