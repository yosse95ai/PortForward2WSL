using PortForward2WSL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortForward2WSL
{
    public partial class PortForward2WSL : Form
    {
        private int[] currentPorts;

        public PortForward2WSL()
        {
            InitializeComponent();
            currentPorts = new int[] { };
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
            RestartButton.Text = Resources.restart;
            portsBox.Text = String.Join(",", currentPorts.Select(port => port.ToString()).ToArray());
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

        private void StartButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Environment.CurrentDirectory);
        }
    }
}
