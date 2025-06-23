using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
namespace Accounting_System
{

    using AForge.Video;
    using AForge.Video.DirectShow;

    public partial class Camera : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Employee addCustomerForm;
        public Camera()
        {
            InitializeComponent();
            this.Load += Camera_Load;
            this.FormClosed += Camera_FormClosed;

        }

        public Camera(Employee addCustomerForm)
        {
            InitializeComponent();
            this.FormClosed += Camera_FormClosed;
            this.Load += Camera_Load;
        }
        private void Camera_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                cmbCamera.Items.Clear();
                foreach (FilterInfo device in videoDevices)
                {
                    cmbCamera.Items.Add(device.Name);
                }
                cmbCamera.SelectedIndex = 0;
                StartCamera();
            }
            else
            {
                MessageBox.Show("No camera found.");
                this.Close();
            }
            picFeed.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void StartCamera()
        {
            videoSource = new VideoCaptureDevice(videoDevices[cmbCamera.SelectedIndex].MonikerString);

            // Set the desired resolution (e.g., 640x480)
            videoSource.VideoResolution = videoSource.VideoCapabilities
                                            .FirstOrDefault(cap => cap.FrameSize.Width == 640 && cap.FrameSize.Height == 480);

            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            picFeed.Image = frame;
        }

        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAndDisposeCamera();
        }

        private void StopAndDisposeCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource.NewFrame -= video_NewFrame;
                videoSource.Stop();
                videoSource = null;

            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (picFeed.Image != null)
            {
                picPreview.Image = (Bitmap)picFeed.Image.Clone();
                btnSave.Enabled = true;
            }
            picFeed.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void Camera_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
          

        }

        private void picPreview_Click(object sender, EventArgs e)
        {

        }
    }

}
