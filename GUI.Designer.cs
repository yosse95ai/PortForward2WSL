namespace PortForward2WSL
{
    partial class PortForward2WSL
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortForward2WSL));
            this.LanguageSelection = new System.Windows.Forms.ComboBox();
            this.language = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.Label();
            this.PortsBox = new System.Windows.Forms.TextBox();
            this.PortRule = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ForwardedPortsLabel = new System.Windows.Forms.Label();
            this.UrlsLabel = new System.Windows.Forms.Label();
            this.HostArea = new System.Windows.Forms.TextBox();
            this.ForwardedPort = new System.Windows.Forms.TextBox();
            this.WaitLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LanguageSelection
            // 
            this.LanguageSelection.CausesValidation = false;
            this.LanguageSelection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LanguageSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageSelection.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LanguageSelection.FormattingEnabled = true;
            this.LanguageSelection.ImeMode = System.Windows.Forms.ImeMode.On;
            this.LanguageSelection.Items.AddRange(new object[] {
            "English",
            "日本語"});
            this.LanguageSelection.Location = new System.Drawing.Point(387, 11);
            this.LanguageSelection.Name = "LanguageSelection";
            this.LanguageSelection.Size = new System.Drawing.Size(121, 27);
            this.LanguageSelection.TabIndex = 0;
            this.LanguageSelection.SelectedIndexChanged += new System.EventHandler(this.LanguageSelection_SelectedIndexChanged);
            // 
            // language
            // 
            this.language.BackColor = System.Drawing.Color.Transparent;
            this.language.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.language.Location = new System.Drawing.Point(228, 11);
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(153, 27);
            this.language.TabIndex = 1;
            this.language.Text = "Language:";
            this.language.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Port
            // 
            this.Port.BackColor = System.Drawing.Color.Transparent;
            this.Port.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Port.Location = new System.Drawing.Point(12, 58);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(180, 27);
            this.Port.TabIndex = 1;
            this.Port.Text = "Port numbers:";
            this.Port.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PortsBox
            // 
            this.PortsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PortsBox.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PortsBox.Location = new System.Drawing.Point(198, 58);
            this.PortsBox.Name = "PortsBox";
            this.PortsBox.Size = new System.Drawing.Size(310, 26);
            this.PortsBox.TabIndex = 2;
            // 
            // PortRule
            // 
            this.PortRule.BackColor = System.Drawing.Color.Transparent;
            this.PortRule.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PortRule.Location = new System.Drawing.Point(198, 87);
            this.PortRule.Name = "PortRule";
            this.PortRule.Size = new System.Drawing.Size(282, 31);
            this.PortRule.TabIndex = 1;
            this.PortRule.Text = "Separate by comma. (ex. 3000, 3001)";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.SkyBlue;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartButton.Location = new System.Drawing.Point(380, 318);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(128, 32);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Tomato;
            this.StopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StopButton.Location = new System.Drawing.Point(246, 318);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(128, 32);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // ForwardedPortsLabel
            // 
            this.ForwardedPortsLabel.BackColor = System.Drawing.Color.Transparent;
            this.ForwardedPortsLabel.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForwardedPortsLabel.Location = new System.Drawing.Point(12, 127);
            this.ForwardedPortsLabel.Name = "ForwardedPortsLabel";
            this.ForwardedPortsLabel.Size = new System.Drawing.Size(180, 27);
            this.ForwardedPortsLabel.TabIndex = 1;
            this.ForwardedPortsLabel.Text = "Forwarded ports:";
            // 
            // UrlsLabel
            // 
            this.UrlsLabel.BackColor = System.Drawing.Color.Transparent;
            this.UrlsLabel.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UrlsLabel.Location = new System.Drawing.Point(12, 207);
            this.UrlsLabel.Name = "UrlsLabel";
            this.UrlsLabel.Size = new System.Drawing.Size(180, 27);
            this.UrlsLabel.TabIndex = 1;
            this.UrlsLabel.Text = "URLs:";
            // 
            // HostArea
            // 
            this.HostArea.BackColor = System.Drawing.Color.Gainsboro;
            this.HostArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HostArea.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HostArea.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HostArea.Location = new System.Drawing.Point(198, 207);
            this.HostArea.Multiline = true;
            this.HostArea.Name = "HostArea";
            this.HostArea.ReadOnly = true;
            this.HostArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.HostArea.Size = new System.Drawing.Size(307, 88);
            this.HostArea.TabIndex = 5;
            this.HostArea.WordWrap = false;
            // 
            // ForwardedPort
            // 
            this.ForwardedPort.BackColor = System.Drawing.Color.Gainsboro;
            this.ForwardedPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ForwardedPort.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForwardedPort.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ForwardedPort.Location = new System.Drawing.Point(198, 127);
            this.ForwardedPort.Multiline = true;
            this.ForwardedPort.Name = "ForwardedPort";
            this.ForwardedPort.ReadOnly = true;
            this.ForwardedPort.Size = new System.Drawing.Size(307, 59);
            this.ForwardedPort.TabIndex = 5;
            // 
            // WaitLable
            // 
            this.WaitLable.BackColor = System.Drawing.Color.Transparent;
            this.WaitLable.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WaitLable.ForeColor = System.Drawing.Color.ForestGreen;
            this.WaitLable.Location = new System.Drawing.Point(12, 318);
            this.WaitLable.Name = "WaitLable";
            this.WaitLable.Size = new System.Drawing.Size(228, 32);
            this.WaitLable.TabIndex = 1;
            this.WaitLable.Text = "Wait a moment...";
            this.WaitLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortForward2WSL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 366);
            this.Controls.Add(this.ForwardedPort);
            this.Controls.Add(this.HostArea);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.PortsBox);
            this.Controls.Add(this.WaitLable);
            this.Controls.Add(this.UrlsLabel);
            this.Controls.Add(this.PortRule);
            this.Controls.Add(this.ForwardedPortsLabel);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.language);
            this.Controls.Add(this.LanguageSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortForward2WSL";
            this.Text = "PortForward2WSL";
            this.Load += new System.EventHandler(this.PortForward2WSL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox LanguageSelection;
        private System.Windows.Forms.Label language;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.TextBox PortsBox;
        private System.Windows.Forms.Label PortRule;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label ForwardedPortsLabel;
        private System.Windows.Forms.Label UrlsLabel;
        private System.Windows.Forms.TextBox HostArea;
        private System.Windows.Forms.TextBox ForwardedPort;
        private System.Windows.Forms.Label WaitLable;
    }
}

