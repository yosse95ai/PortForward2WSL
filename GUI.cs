using PortForward2WSL.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;

namespace PortForward2WSL
{
    public partial class PortForward2WSL : Form
    {
        private int[] currentPorts;
        private string PS1Folder;
        private readonly string openWslPort = "open_wsl_port.ps1";
        private readonly string closeWslPort = "close_wsl_port.ps1";
        private readonly string envirnmentVariableName = "PORT";

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
            SetLogInfo(Resources.wait);

            if (clickedButton == Resources.start)
            {

                if (PortsBox.Text == "")
                {
                    SetLogError(Resources.empty);
                    return; 
                }
                int[] inputPorts = Regex.Replace(PortsBox.Text, @"[^0-9,]", "").Split(',').Where(p => p != "").Select(int.Parse).ToArray();
                string env = Environment.GetEnvironmentVariable(envirnmentVariableName, EnvironmentVariableTarget.User);
                int[] defaultPorts = env != null
                                         ? env.Split(',').Select(int.Parse).ToArray()
                                         : new int[] { };
                int[] allPorts = new int[inputPorts.Length + defaultPorts.Length];
                Array.Copy(inputPorts, allPorts, inputPorts.Length);
                Array.Copy(defaultPorts, 0, allPorts, inputPorts.Length, defaultPorts.Length);
                Environment.SetEnvironmentVariable(
                                    envirnmentVariableName,
                                    string.Join(",", allPorts.Distinct()),
                                    EnvironmentVariableTarget.User
                                );
                filePath = Path.Combine(PS1Folder, openWslPort);
            }
            else if (clickedButton == Resources.stop)
            {
                if (currentPorts.Length < 1)
                {
                    SetLogInfo("");
                    return;
                }
                filePath = Path.Combine(PS1Folder, closeWslPort);
            }
            PS1InvokeParams(filePath);
            UpdateGUI();
        }

        /******************************
         * Helper Method
         ******************************/

        /// <summary>
        /// Initialize Language (en-US)
        /// </summary>
        private void InitializeLanguage()
        {
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "ja-JP":
                    LanguageSelection.SelectedItem = "日本語";
                    break;
                case "en-US":
                default:
                    LanguageSelection.SelectedItem = "English";
                    break;
            }
            language.Text = Resources.language;
        }

        /// <summary>
        /// Update GUI Text
        /// </summary>
        private void UpdateGUI()
        {
            InitializePort();
            Port.Text = Resources.port_label;
            PortRule.Text = Resources.port_rule;
            StartButton.Text = Resources.start;
            StopButton.Text = Resources.stop;
            ForwardedPortsLabel.Text = Resources.forwarded_port;
            UrlsLabel.Text = Resources.urls;
            ForwardedPort.Text = currentPorts.Length > 0
                                    ? String.Join(",", currentPorts.Select(port => port.ToString()).ToArray())
                                    : Resources.none_port;
            PortsBox.Text = currentPorts.Length > 0
                                    ? String.Join(",", currentPorts.Select(port => port.ToString()).ToArray())
                                    : "";
            SetLogInfo("");
            HostArea.Lines = CreateUrls();
        }

        /// <summary>
        /// Load Port numbers from environment variable "PORT" and initialize PortBox Text
        /// </summary>
        private void InitializePort()
        {
            string envPorts = Environment.GetEnvironmentVariable(envirnmentVariableName, EnvironmentVariableTarget.User);
            currentPorts = (envPorts != null)
                            ? envPorts.Split(',').Select(int.Parse).ToArray()
                            : new int[] { };
        }

        private void PS1InvokeParams(string PS1FilePath)
        {
            PowerShell.Create().AddScript(PS1FilePath).Invoke();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            PortsBox.Text = currentPorts.Length > 0 ? ForwardedPort.Text : "";
        }
        private void ArrayWriteline<T>(T[] arr)
        {
            Console.WriteLine(string.Join(",", arr));
        }

        private string GetIPAddress()
        {
            string ipaddress = "";
            IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in ipentry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipaddress = ip.ToString();
                    break;
                }
            }
            return ipaddress;
        }

        private string[] CreateUrls()
        {
            string[] urls = new string[] { };
            if (currentPorts.Length > 0)
            {
                string host = GetIPAddress();
                urls = currentPorts.Select(p => $"http://{host}:{p}").ToArray();
            }
            return urls;
        }
        private void SetLog(string text,Color color)
        {
            WaitLable.Text = text;
            WaitLable.ForeColor = color;
        }
        private void SetLogInfo(string text)
        {
            SetLog(text, Color.ForestGreen);
        }

        private void SetLogError(string text)
        {
            SetLog(text, Color.Red);
        }
    }
}
