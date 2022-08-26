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

namespace Team3Astro
{
    public partial class FileName : Form
    {
        public FileName()
        {
            InitializeComponent();
        }

        string detailPath, FNdata;

        private void Save()
        {
            FNdata = setting.data;
            File.WriteAllText(detailPath, FNdata);
            setting.filename = txtFileName.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            detailPath = setting.path + txtFileName.Text + ".json";
            if (File.Exists(detailPath))
            {
                DialogResult Coverresult = MessageBox.Show($"檔案{txtFileName.Text}已存在，是否要覆蓋", "檔案已存在", MessageBoxButtons.YesNo);
                if (Coverresult == DialogResult.Yes)
                {
                    Save();
                }
                else
                {
                    txtFileName.Text = "";
                }
            }
            else               //檔案不存在，直接儲存
            { Save(); }
        }
    }
}
