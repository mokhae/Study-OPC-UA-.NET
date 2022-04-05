namespace MinimalClient
{
    partial class MinimalClient
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectButton = new System.Windows.Forms.Button();
            this.EndpointCB = new System.Windows.Forms.ComboBox();
            this.txtNodeID = new System.Windows.Forms.TextBox();
            this.ItemTree = new System.Windows.Forms.TreeView();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnAddList = new System.Windows.Forms.Button();
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.btnRemoveList = new System.Windows.Forms.Button();
            this.btnCreateSubs = new System.Windows.Forms.Button();
            this.btnRemoveSubs = new System.Windows.Forms.Button();
            this.txtSubs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(336, 15);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(80, 21);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // EndpointCB
            // 
            this.EndpointCB.FormattingEnabled = true;
            this.EndpointCB.Items.AddRange(new object[] {
            "opc.tcp://localhost:51210/UA/MinimalServer",
            "opc.tcp://localhost:51210/UA/SampleServer",
            "opc.tcp://192.168.10.7"});
            this.EndpointCB.Location = new System.Drawing.Point(11, 15);
            this.EndpointCB.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.EndpointCB.Name = "EndpointCB";
            this.EndpointCB.Size = new System.Drawing.Size(318, 20);
            this.EndpointCB.TabIndex = 3;
            // 
            // txtNodeID
            // 
            this.txtNodeID.Location = new System.Drawing.Point(432, 44);
            this.txtNodeID.Multiline = true;
            this.txtNodeID.Name = "txtNodeID";
            this.txtNodeID.Size = new System.Drawing.Size(458, 41);
            this.txtNodeID.TabIndex = 5;
            // 
            // ItemTree
            // 
            this.ItemTree.Location = new System.Drawing.Point(12, 41);
            this.ItemTree.Name = "ItemTree";
            this.ItemTree.Size = new System.Drawing.Size(403, 470);
            this.ItemTree.TabIndex = 6;
            this.ItemTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ItemTree_AfterSelect);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(433, 141);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(96, 28);
            this.btnRead.TabIndex = 7;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(723, 109);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(167, 21);
            this.txtValue.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Value : ";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(535, 141);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(96, 28);
            this.btnWrite.TabIndex = 10;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnAddList
            // 
            this.btnAddList.Location = new System.Drawing.Point(433, 180);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(156, 28);
            this.btnAddList.TabIndex = 11;
            this.btnAddList.Text = "Add List";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // lstNodes
            // 
            this.lstNodes.FormattingEnabled = true;
            this.lstNodes.ItemHeight = 12;
            this.lstNodes.Location = new System.Drawing.Point(432, 214);
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.Size = new System.Drawing.Size(459, 124);
            this.lstNodes.TabIndex = 12;
            // 
            // btnRemoveList
            // 
            this.btnRemoveList.Location = new System.Drawing.Point(609, 180);
            this.btnRemoveList.Name = "btnRemoveList";
            this.btnRemoveList.Size = new System.Drawing.Size(156, 28);
            this.btnRemoveList.TabIndex = 13;
            this.btnRemoveList.Text = "Remove List";
            this.btnRemoveList.UseVisualStyleBackColor = true;
            this.btnRemoveList.Click += new System.EventHandler(this.btnRemoveList_Click);
            // 
            // btnCreateSubs
            // 
            this.btnCreateSubs.Location = new System.Drawing.Point(432, 346);
            this.btnCreateSubs.Name = "btnCreateSubs";
            this.btnCreateSubs.Size = new System.Drawing.Size(156, 28);
            this.btnCreateSubs.TabIndex = 14;
            this.btnCreateSubs.Text = "Create Subscription";
            this.btnCreateSubs.UseVisualStyleBackColor = true;
            this.btnCreateSubs.Click += new System.EventHandler(this.btnCreateSubs_Click);
            // 
            // btnRemoveSubs
            // 
            this.btnRemoveSubs.Location = new System.Drawing.Point(608, 346);
            this.btnRemoveSubs.Name = "btnRemoveSubs";
            this.btnRemoveSubs.Size = new System.Drawing.Size(156, 28);
            this.btnRemoveSubs.TabIndex = 15;
            this.btnRemoveSubs.Text = "Remove Subscription";
            this.btnRemoveSubs.UseVisualStyleBackColor = true;
            this.btnRemoveSubs.Click += new System.EventHandler(this.btnRemoveSubs_Click);
            // 
            // txtSubs
            // 
            this.txtSubs.Location = new System.Drawing.Point(432, 380);
            this.txtSubs.Multiline = true;
            this.txtSubs.Name = "txtSubs";
            this.txtSubs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubs.Size = new System.Drawing.Size(458, 131);
            this.txtSubs.TabIndex = 16;
            // 
            // MinimalClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 523);
            this.Controls.Add(this.txtSubs);
            this.Controls.Add(this.btnRemoveSubs);
            this.Controls.Add(this.btnCreateSubs);
            this.Controls.Add(this.btnRemoveList);
            this.Controls.Add(this.lstNodes);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.ItemTree);
            this.Controls.Add(this.txtNodeID);
            this.Controls.Add(this.EndpointCB);
            this.Controls.Add(this.ConnectButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MinimalClient";
            this.Text = "MinimalClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MinimalClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ComboBox EndpointCB;
        private System.Windows.Forms.TextBox txtNodeID;
        private System.Windows.Forms.TreeView ItemTree;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.ListBox lstNodes;
        private System.Windows.Forms.Button btnRemoveList;
        private System.Windows.Forms.Button btnCreateSubs;
        private System.Windows.Forms.Button btnRemoveSubs;
        private System.Windows.Forms.TextBox txtSubs;
    }
}

