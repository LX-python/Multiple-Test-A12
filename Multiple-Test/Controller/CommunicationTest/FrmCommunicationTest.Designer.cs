namespace Multiple_Test.Controller.CommunicationTest
{
    partial class FrmCommunicationTest
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode(" Chroma 6530/6520/6512");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("AC Sourse", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Chroma 63600");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("DC-Load", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Tektronix ");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("示波器", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Agilent 34401A");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("万用电表", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommunicationTest));
            this.uiTreeView1 = new Sunny.UI.UITreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.SuspendLayout();
            // 
            // uiTreeView1
            // 
            this.uiTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.uiTreeView1.FillColor = System.Drawing.Color.White;
            this.uiTreeView1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTreeView1.Location = new System.Drawing.Point(0, 35);
            this.uiTreeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTreeView1.Name = "uiTreeView1";
            treeNode1.Name = "ACCHROMA6530_6520_6512";
            treeNode1.Text = " Chroma 6530/6520/6512";
            treeNode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode2.Name = "节点0";
            treeNode2.Text = "AC Sourse";
            treeNode3.Name = "Chroma63600";
            treeNode3.Text = "Chroma 63600";
            treeNode4.Name = "节点1";
            treeNode4.Text = "DC-Load";
            treeNode5.Name = "节点0";
            treeNode5.Text = "Tektronix ";
            treeNode6.Name = "节点2";
            treeNode6.Text = "示波器";
            treeNode7.Name = "节点1";
            treeNode7.Text = "Agilent 34401A";
            treeNode8.Name = "节点0";
            treeNode8.Text = "万用电表";
            this.uiTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8});
            this.uiTreeView1.SelectedNode = null;
            this.uiTreeView1.ShowLines = true;
            this.uiTreeView1.Size = new System.Drawing.Size(283, 560);
            this.uiTreeView1.TabIndex = 0;
            this.uiTreeView1.Text = "uiTreeView1";
            this.uiTreeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.uiTreeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            this.imageList1.Images.SetKeyName(1, "plug-1 (1).png");
            this.imageList1.Images.SetKeyName(2, "模拟直流电源.png");
            this.imageList1.Images.SetKeyName(3, "v4_ futuresRiskControl_h.png");
            // 
            // uiPanel1
            // 
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(291, 40);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(792, 538);
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            // 
            // FrmCommunicationTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 595);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.uiTreeView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCommunicationTest";
            this.ShowInTaskbar = false;
            this.Text = "设备通讯测试";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITreeView uiTreeView1;
        public System.Windows.Forms.ImageList imageList1;
        private Sunny.UI.UIPanel uiPanel1;
    }
}