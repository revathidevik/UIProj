using EventHubTest;
using EventHubTest.Models;
using Microsoft.Extensions.Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttachmentsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            openFileDialog1.Filter = "Select Valid Document(*.pdf)|*.pdf";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        label1.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog2.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog2.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            openFileDialog2.Filter = "Select Valid Document(*.json)| *.json";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog2.FilterIndex = 1;
            try
            {
                if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog2.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog2.FileName);
                        label3.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string pdffilename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                string metadatafilename = System.IO.Path.GetFileName(openFileDialog2.FileName);
                if (pdffilename == null || metadatafilename==null)
                {
                    MessageBox.Show("Please select both pdf & Metadata files.");
                }
                else
                {
                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    System.IO.File.Copy(openFileDialog1.FileName, path + "\\Documents\\" + pdffilename);
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string filePath = System.IO.Path.Combine(path, "Documents", pdffilename);

                  
                    string BlobStorageConnection = ConfigurationManager.AppSettings["BlobStorageConnection"];
                   // await BlobStorage.SavePdf(BlobStorageConnection, filePath);

                    string EventHubConnectionString = ConfigurationManager.AppSettings["EventHubConnectionString"];
                    System.IO.File.Copy(openFileDialog2.FileName, path + "\\Documents\\" + metadatafilename);
                    string filePathMeta = System.IO.Path.Combine(path, "Documents", metadatafilename);
                    AttachmentMetaData eventHubMessage = JsonHelpers.CreateFromJsonFile<AttachmentMetaData>(filePathMeta);
                    await EventHubsHelper.PushMessageToEventHubsAsync(eventHubMessage, EventHubConnectionString);
                    MessageBox.Show("Document uploaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
