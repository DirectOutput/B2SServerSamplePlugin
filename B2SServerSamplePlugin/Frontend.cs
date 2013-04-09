using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace B2SServerSamplePluginCSharp
{
    /// <summary>
    /// Frontend for the B2S.Server Smaple Plugin.
    /// </summary>
    public partial class Frontend : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Frontend"/> form class.
        /// </summary>
        public Frontend()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Frontend form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Frontend_Load(object sender, EventArgs e)
        {
            //Get the version of the assembly
            Version V = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //Calculate the BuildDate based in the build and revsion number of the project.
            DateTime BuildDate = new DateTime(2000, 1, 1).AddDays(V.Build).AddSeconds(V.Revision * 2);
            //Format and set the version string.
            VersionLabel.Text=string.Format("Version {0} as of {1}", V.ToString(), BuildDate.ToString("yyyy.MM.dd hh:mm"));
        }

        /// <summary>
        /// Handles the Click event of the CloseButton control.<br/>
        /// Closes the frontend of the plugin.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DocuLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://directoutput.github.io/B2SServerSamplePlugin/");
        }

        private void VersionLabel_Click(object sender, EventArgs e)
        {

        }

     

  
    }
}
