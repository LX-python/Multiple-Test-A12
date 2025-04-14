using Multiple_Test.Controller.CommunicationTest;
using Multiple_Test.Models.Grid;
using Multiple_Test.Service.DataGridViewService;
using OfficeOpenXml;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Multiple_Test.Controller.Derating
{
    public partial class frmDeratintMain : UIForm
    {
        private readonly DataGridView_Service dataGrid;

        private string path = "C:\\Users\\Administrator\\Desktop\\DQEScript.xlsx";
        public frmDeratintMain()
        {
            InitializeComponent();
            dataGrid = new DataGridView_Service(this.dataGridView1);
            this.Load += FrmMain_Load;
            this.dataGridView1.DoubleClick += dataGrid.DataGridView1_DoubleClick;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
           // dataGridView1.RowTemplate.Height = 2000;
        }



        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 设置 ExcelPackage.LicenseContext 属性以避免 LicenseException
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            initGrid();
           //openScript();


        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            initGrid();

        }
        private void initGrid()
        {
            // 启用双缓冲
            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
                dataGridView1, new object[] { true });
            var data = new List<entitygridInit>
            {
                // new entitygridInit { TestItem = "", Id = 1, Result = "PASS" },
            };

            dataGridView1.DataSource = data;
            // 设置列自动填充
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText == "Id" || column.HeaderText == "Result")
                {
                    column.Width = 100;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            dataGridView1.Refresh();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var frm = new FrmCommunicationTest();
            frm.ShowDialog(this);
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            openScript();
        }

        private void openScript()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "选择要导入的Excel文件";

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    FileInfo fileInfo = new FileInfo(filePath);

                    using (ExcelPackage package = new ExcelPackage(fileInfo))
                    {
                        //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming you want to read the first worksheet

                        int rowCount = worksheet.Dimension.Rows;

                        // Get column indices
                        int testItemColumnIndex = GetColumnIndex(worksheet, "TestItem");
                        int describeColumnIndex = GetColumnIndex(worksheet, "Describe");

                        // Print column headers
                        Console.WriteLine("TestItem\tDescribe");
                        var data = new List<entitygridInit>
                        {
                            // new entitygridInit { TestItem = "", Id = 1, Result = "PASS" },
                        };


                        // Print data
                        for (int row = 2; row <= rowCount; row++) // Assuming the first row contains headers
                        {
                            string testItem = worksheet.Cells[row, testItemColumnIndex]?.Value?.ToString() ?? "";
                            string describe = worksheet.Cells[row, describeColumnIndex]?.Value?.ToString() ?? "";
                            var item = new entitygridInit();
                            item.Id = row - 1;
                            item.TestItem = testItem;
                            item.Describe = describe;
                            data.Add(item);
                            Console.WriteLine($"{testItem}\t{describe}");
                        }
                        dataGridView1.DataSource = data;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Handle the exception as needed (log, display a message, etc.)
            }

        }
        // Helper method: Get column index by column name
        static int GetColumnIndex(ExcelWorksheet worksheet, string columnName)
        {
            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
            {
                if (worksheet.Cells[1, col].Text.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return col;
                }
            }
            throw new InvalidOperationException($"Column '{columnName}' not found.");
        }

        private void addTestItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // UIStyles.Style(panel.FillColor, Color.White);
            Style = UIStyle.Red;
        }
    }
}
