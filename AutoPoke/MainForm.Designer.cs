namespace Luaan.AutoPoke
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ddlProcesses = new System.Windows.Forms.ComboBox();
            this.btnReloadProcesses = new System.Windows.Forms.Button();
            this.tbxSearchValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.bwMemoryScan = new System.ComponentModel.BackgroundWorker();
            this.pbScanProgress = new System.Windows.Forms.ProgressBar();
            this.lvFound = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMaintainValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSearchText = new System.Windows.Forms.Label();
            this.tbxSetValue = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnRemoveFromList = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.cbxMaintainValue = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lvSearches = new System.Windows.Forms.ListView();
            this.chSearchTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSearchValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSearchType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSearchLocations = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbNewSearch = new System.Windows.Forms.GroupBox();
            this.btnAddSearch = new System.Windows.Forms.Button();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.ddlSearchType = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.btnSearchRemove = new System.Windows.Forms.Button();
            this.cbxPresumeAlignment = new System.Windows.Forms.CheckBox();
            this.tbxDelta = new System.Windows.Forms.TextBox();
            this.lblDelta = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipError = new System.Windows.Forms.ToolTip(this.components);
            this.gbNewSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlProcesses
            // 
            this.ddlProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProcesses.FormattingEnabled = true;
            this.ddlProcesses.Location = new System.Drawing.Point(12, 12);
            this.ddlProcesses.Name = "ddlProcesses";
            this.ddlProcesses.Size = new System.Drawing.Size(674, 21);
            this.ddlProcesses.TabIndex = 0;
            // 
            // btnReloadProcesses
            // 
            this.btnReloadProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadProcesses.Location = new System.Drawing.Point(692, 11);
            this.btnReloadProcesses.Name = "btnReloadProcesses";
            this.btnReloadProcesses.Size = new System.Drawing.Size(48, 23);
            this.btnReloadProcesses.TabIndex = 1;
            this.btnReloadProcesses.Text = "load";
            this.btnReloadProcesses.UseVisualStyleBackColor = true;
            this.btnReloadProcesses.Click += new System.EventHandler(this.btnReloadProcesses_Click);
            // 
            // tbxSearchValue
            // 
            this.tbxSearchValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxSearchValue.Location = new System.Drawing.Point(12, 344);
            this.tbxSearchValue.Name = "tbxSearchValue";
            this.tbxSearchValue.Size = new System.Drawing.Size(100, 20);
            this.tbxSearchValue.TabIndex = 1;
            this.toolTip.SetToolTip(this.tbxSearchValue, "Represents the value being searched.");
            this.tbxSearchValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxSearchValue_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(181, 342);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddToList.Location = new System.Drawing.Point(266, 302);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(43, 23);
            this.btnAddToList.TabIndex = 5;
            this.btnAddToList.Text = "-->";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // bwMemoryScan
            // 
            this.bwMemoryScan.WorkerReportsProgress = true;
            // 
            // pbScanProgress
            // 
            this.pbScanProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbScanProgress.Location = new System.Drawing.Point(12, 427);
            this.pbScanProgress.Name = "pbScanProgress";
            this.pbScanProgress.Size = new System.Drawing.Size(728, 23);
            this.pbScanProgress.TabIndex = 6;
            // 
            // lvFound
            // 
            this.lvFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFound.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chValue,
            this.chAddress,
            this.chMaintainValue,
            this.chTypeName});
            this.lvFound.FullRowSelect = true;
            this.lvFound.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFound.HideSelection = false;
            this.lvFound.Location = new System.Drawing.Point(315, 39);
            this.lvFound.MultiSelect = false;
            this.lvFound.Name = "lvFound";
            this.lvFound.Size = new System.Drawing.Size(425, 354);
            this.lvFound.TabIndex = 7;
            this.lvFound.UseCompatibleStateImageBehavior = false;
            this.lvFound.View = System.Windows.Forms.View.Details;
            this.lvFound.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvFound_ItemSelectionChanged);
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 104;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            // 
            // chAddress
            // 
            this.chAddress.Text = "Address";
            // 
            // chMaintainValue
            // 
            this.chMaintainValue.Text = "Maintain";
            // 
            // chTypeName
            // 
            this.chTypeName.Text = "Type";
            // 
            // lblSearchText
            // 
            this.lblSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearchText.AutoSize = true;
            this.lblSearchText.Location = new System.Drawing.Point(12, 328);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(73, 13);
            this.lblSearchText.TabIndex = 8;
            this.lblSearchText.Text = "Search value:";
            // 
            // tbxSetValue
            // 
            this.tbxSetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSetValue.Location = new System.Drawing.Point(559, 401);
            this.tbxSetValue.Name = "tbxSetValue";
            this.tbxSetValue.Size = new System.Drawing.Size(100, 20);
            this.tbxSetValue.TabIndex = 9;
            this.tbxSetValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxSetValue_KeyUp);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Enabled = false;
            this.btnSet.Location = new System.Drawing.Point(665, 399);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 10;
            this.btnSet.Text = "set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnRemoveFromList
            // 
            this.btnRemoveFromList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveFromList.Enabled = false;
            this.btnRemoveFromList.Location = new System.Drawing.Point(315, 399);
            this.btnRemoveFromList.Name = "btnRemoveFromList";
            this.btnRemoveFromList.Size = new System.Drawing.Size(54, 23);
            this.btnRemoveFromList.TabIndex = 11;
            this.btnRemoveFromList.Text = "remove";
            this.btnRemoveFromList.UseVisualStyleBackColor = true;
            this.btnRemoveFromList.Click += new System.EventHandler(this.btnRemoveFromList_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 404);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(41, 13);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.Text = "Ready.";
            // 
            // cbxMaintainValue
            // 
            this.cbxMaintainValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMaintainValue.AutoSize = true;
            this.cbxMaintainValue.Location = new System.Drawing.Point(487, 403);
            this.cbxMaintainValue.Name = "cbxMaintainValue";
            this.cbxMaintainValue.Size = new System.Drawing.Size(66, 17);
            this.cbxMaintainValue.TabIndex = 15;
            this.cbxMaintainValue.Text = "Maintain";
            this.toolTip.SetToolTip(this.cbxMaintainValue, "If checked, the application will periodically reset the selected data item to the" +
        " specified value.");
            this.cbxMaintainValue.UseVisualStyleBackColor = true;
            this.cbxMaintainValue.CheckedChanged += new System.EventHandler(this.cbxMaintainValue_CheckedChanged);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(266, 342);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(43, 23);
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lvSearches
            // 
            this.lvSearches.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvSearches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvSearches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSearchTitle,
            this.chSearchValue,
            this.chSearchType,
            this.chSearchLocations});
            this.lvSearches.FullRowSelect = true;
            this.lvSearches.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSearches.HideSelection = false;
            this.lvSearches.Location = new System.Drawing.Point(12, 107);
            this.lvSearches.MultiSelect = false;
            this.lvSearches.Name = "lvSearches";
            this.lvSearches.Size = new System.Drawing.Size(297, 189);
            this.lvSearches.TabIndex = 18;
            this.lvSearches.UseCompatibleStateImageBehavior = false;
            this.lvSearches.View = System.Windows.Forms.View.Details;
            // 
            // chSearchTitle
            // 
            this.chSearchTitle.Text = "Title";
            // 
            // chSearchValue
            // 
            this.chSearchValue.Text = "Value";
            // 
            // chSearchType
            // 
            this.chSearchType.Text = "Type";
            // 
            // chSearchLocations
            // 
            this.chSearchLocations.Text = "Found";
            this.chSearchLocations.Width = 45;
            // 
            // gbNewSearch
            // 
            this.gbNewSearch.Controls.Add(this.btnAddSearch);
            this.gbNewSearch.Controls.Add(this.lblSearchType);
            this.gbNewSearch.Controls.Add(this.ddlSearchType);
            this.gbNewSearch.Controls.Add(this.lblTitle);
            this.gbNewSearch.Controls.Add(this.tbxTitle);
            this.gbNewSearch.Location = new System.Drawing.Point(12, 39);
            this.gbNewSearch.Name = "gbNewSearch";
            this.gbNewSearch.Size = new System.Drawing.Size(297, 62);
            this.gbNewSearch.TabIndex = 0;
            this.gbNewSearch.TabStop = false;
            this.gbNewSearch.Text = "New search";
            // 
            // btnAddSearch
            // 
            this.btnAddSearch.Location = new System.Drawing.Point(238, 30);
            this.btnAddSearch.Name = "btnAddSearch";
            this.btnAddSearch.Size = new System.Drawing.Size(50, 23);
            this.btnAddSearch.TabIndex = 19;
            this.btnAddSearch.Text = "add";
            this.btnAddSearch.UseVisualStyleBackColor = true;
            this.btnAddSearch.Click += new System.EventHandler(this.btnAddSearch_Click);
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Location = new System.Drawing.Point(129, 16);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(34, 13);
            this.lblSearchType.TabIndex = 18;
            this.lblSearchType.Text = "Type:";
            // 
            // ddlSearchType
            // 
            this.ddlSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchType.FormattingEnabled = true;
            this.ddlSearchType.Items.AddRange(new object[] {
            "Int32",
            "Int16",
            "ΔSingle",
            "ΔDouble",
            "ΔInt32",
            "Int32*"});
            this.ddlSearchType.Location = new System.Drawing.Point(132, 31);
            this.ddlSearchType.Name = "ddlSearchType";
            this.ddlSearchType.Size = new System.Drawing.Size(100, 21);
            this.ddlSearchType.TabIndex = 17;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(6, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Title:";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(9, 32);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(108, 20);
            this.tbxTitle.TabIndex = 0;
            this.tbxTitle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxTitle_KeyUp);
            // 
            // btnSearchRemove
            // 
            this.btnSearchRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearchRemove.Location = new System.Drawing.Point(12, 302);
            this.btnSearchRemove.Name = "btnSearchRemove";
            this.btnSearchRemove.Size = new System.Drawing.Size(63, 23);
            this.btnSearchRemove.TabIndex = 20;
            this.btnSearchRemove.Text = "remove";
            this.btnSearchRemove.UseVisualStyleBackColor = true;
            this.btnSearchRemove.Click += new System.EventHandler(this.btnSearchRemove_Click);
            // 
            // cbxPresumeAlignment
            // 
            this.cbxPresumeAlignment.AutoSize = true;
            this.cbxPresumeAlignment.Checked = true;
            this.cbxPresumeAlignment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPresumeAlignment.Location = new System.Drawing.Point(12, 373);
            this.cbxPresumeAlignment.Name = "cbxPresumeAlignment";
            this.cbxPresumeAlignment.Size = new System.Drawing.Size(115, 17);
            this.cbxPresumeAlignment.TabIndex = 21;
            this.cbxPresumeAlignment.Text = "Presume alignment";
            this.toolTip.SetToolTip(this.cbxPresumeAlignment, resources.GetString("cbxPresumeAlignment.ToolTip"));
            this.cbxPresumeAlignment.UseVisualStyleBackColor = true;
            // 
            // tbxDelta
            // 
            this.tbxDelta.Location = new System.Drawing.Point(118, 344);
            this.tbxDelta.Name = "tbxDelta";
            this.tbxDelta.Size = new System.Drawing.Size(57, 20);
            this.tbxDelta.TabIndex = 2;
            this.tbxDelta.Text = "1";
            this.toolTip.SetToolTip(this.tbxDelta, resources.GetString("tbxDelta.ToolTip"));
            this.tbxDelta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxSearchValue_KeyUp);
            // 
            // lblDelta
            // 
            this.lblDelta.AutoSize = true;
            this.lblDelta.Location = new System.Drawing.Point(115, 328);
            this.lblDelta.Name = "lblDelta";
            this.lblDelta.Size = new System.Drawing.Size(35, 13);
            this.lblDelta.TabIndex = 22;
            this.lblDelta.Text = "Delta:";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 0;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 20;
            // 
            // toolTipError
            // 
            this.toolTipError.AutomaticDelay = 100;
            this.toolTipError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.toolTipError.ForeColor = System.Drawing.Color.Black;
            this.toolTipError.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.toolTipError.ToolTipTitle = "Error";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 462);
            this.Controls.Add(this.lblDelta);
            this.Controls.Add(this.tbxDelta);
            this.Controls.Add(this.cbxPresumeAlignment);
            this.Controls.Add(this.btnSearchRemove);
            this.Controls.Add(this.gbNewSearch);
            this.Controls.Add(this.lvSearches);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.cbxMaintainValue);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnRemoveFromList);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.tbxSetValue);
            this.Controls.Add(this.lblSearchText);
            this.Controls.Add(this.lvFound);
            this.Controls.Add(this.pbScanProgress);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearchValue);
            this.Controls.Add(this.btnReloadProcesses);
            this.Controls.Add(this.ddlProcesses);
            this.Name = "MainForm";
            this.Text = "AutoPoke";
            this.gbNewSearch.ResumeLayout(false);
            this.gbNewSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox ddlProcesses;
		private System.Windows.Forms.Button btnReloadProcesses;
		private System.Windows.Forms.TextBox tbxSearchValue;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnAddToList;
		private System.ComponentModel.BackgroundWorker bwMemoryScan;
		private System.Windows.Forms.ProgressBar pbScanProgress;
		private System.Windows.Forms.ListView lvFound;
		private System.Windows.Forms.Label lblSearchText;
		private System.Windows.Forms.TextBox tbxSetValue;
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.ColumnHeader chTitle;
		private System.Windows.Forms.ColumnHeader chValue;
		private System.Windows.Forms.Button btnRemoveFromList;
		private System.Windows.Forms.ColumnHeader chAddress;
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.ColumnHeader chMaintainValue;
		private System.Windows.Forms.CheckBox cbxMaintainValue;
		private System.Windows.Forms.ColumnHeader chTypeName;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.ListView lvSearches;
		private System.Windows.Forms.ColumnHeader chSearchTitle;
		private System.Windows.Forms.ColumnHeader chSearchValue;
		private System.Windows.Forms.ColumnHeader chSearchLocations;
		private System.Windows.Forms.ColumnHeader chSearchType;
		private System.Windows.Forms.GroupBox gbNewSearch;
		private System.Windows.Forms.Label lblSearchType;
		private System.Windows.Forms.ComboBox ddlSearchType;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.TextBox tbxTitle;
		private System.Windows.Forms.Button btnSearchRemove;
		private System.Windows.Forms.Button btnAddSearch;
		private System.Windows.Forms.CheckBox cbxPresumeAlignment;
		private System.Windows.Forms.TextBox tbxDelta;
		private System.Windows.Forms.Label lblDelta;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolTip toolTipError;
	}
}

