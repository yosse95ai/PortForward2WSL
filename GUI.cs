using PortForward2WSL.Properties;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortForward2WSL
{
    public partial class PortForward2WSL : Form
    {
        private int[] currentPorts;
        private string PS1Folder;


        /******************************
         * Windows Form Method
         ******************************/
        public PortForward2WSL()
        {
            InitializeComponent();
            currentPorts = new int[] { };
            PS1Folder = Path.Combine(Environment.CurrentDirectory, "PS1");
        }

        private void PortForward2WSL_Load(object sender, EventArgs e)
        {
            InitializeLanguage();
            InitializePort();
            UpdateGUI();
        }

        /// <summary>
        /// Language change action
        /// </summary>
        private void LanguageSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLanguage = LanguageSelection.SelectedItem.ToString();
            switch (selectedLanguage)
            {
                case "日本語":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
                    break;
                case "English":
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
            }
            language.Text = Resources.language;
            UpdateGUI();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string clickedButton = ((Button)sender).Text;
            string filePath = "";

            if (clickedButton == Resources.start)
            {
                filePath = Path.Combine(PS1Folder, "open_wsl_port.ps1");
            }
            else if (clickedButton == Resources.stop)
            {
                filePath = Path.Combine(PS1Folder, "close_wsl_port.ps1");
            }
            else if (clickedButton == Resources.reflesh)
            {
                InitializePort();
                UpdateGUI();
                return;
            }
            PS1Invoke(filePath);
        }

        /******************************
         * Helper Method
         ******************************/

        /// <summary>
        /// Initialize Language (en-US)
        /// </summary>
        private void InitializeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            language.Text = Resources.language;
            LanguageSelection.SelectedItem = "English";
        }

        /// <summary>
        /// Update GUI Text
        /// </summary>
        private void UpdateGUI()
        {
            Port.Text = Resources.port_label;
            PortRule.Text = Resources.port_rule;
            StartButton.Text = Resources.start;
            StopButton.Text = Resources.stop;
            RefleshButton.Text = Resources.reflesh;
            ForwardedPortsLabel.Text = Resources.forwarded_port;
            ForwardedPort.Text = currentPorts.Length > 0
                                    ? String.Join(",", currentPorts.Select(port => port.ToString()).ToArray())
                                    : Resources.none_port;
        }

        /// <summary>
        /// Load Port numbers from environment variable "PORT" and initialize PortBox Text
        /// </summary>
        private void InitializePort()
        {
            string envPorts = Environment.GetEnvironmentVariable("PORT", EnvironmentVariableTarget.User);
            currentPorts = (envPorts != null)
                            ? envPorts.Split(' ').Select(int.Parse).ToArray()
                            : new int[] { };
        }

        private void PS1Invoke(string PS1FilePath)
        {
            RunspaceInvoke runspaceInvoke = new RunspaceInvoke();
            runspaceInvoke.Invoke(PS1FilePath);
            runspaceInvoke.Dispose();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            PortsBox.Text = currentPorts.Length > 0 ? ForwardedPort.Text : "";
        }
    }
}
