using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Team3Astro
{
    public partial class Frm_Main : Form
    {
        bool selectFlat1 = false, selectFlat2 = false;
        List<AstroJsonList> Astro = new List<AstroJsonList>();

        public Frm_Main()
        {
            InitializeComponent();
        }
        private void txtboxExit()
        {
            if (txtInfo.Enabled == true)
            {
                txtInfo.Enabled = false;
                selectFlat1 = false;
                selectFlat2 = false;
                labselect1.BackColor = Color.LightBlue;
                labselect1.Text = "無";
                labselect2.BackColor = Color.Transparent;
                labselect2.Text = "無";
                txtInfo.Text = "已變更";
            }
        }
        private void FindInfo()
        {
            string labs1, labs2;
            if (labselect1.Text == "無") { labs1 = ""; } else { labs1 = labselect1.Text; }
            if (labselect2.Text == "無") { labs2 = ""; } else { labs2 = labselect2.Text; }
            if (labs1 != "" || labs2 != "")
            {
                IEnumerable<AstroJsonList> AstroResultSt = from e in Astro
                                                         where e.Select1 == labs1 || e.Select2 == labs1
                                                         select e;
                IEnumerable<AstroJsonList> AstroResultNd = from e in AstroResultSt
                                                           where e.Select1 == labs2 || e.Select2 == labs2
                                                         select e;
                if (AstroResultNd.Count() != 0)
                {
                    txtInfo.Text = AstroResultNd.First().information;
                }
                else { txtInfo.Text = ""; }
            }
        }

        private void SaveInfo()
        {
            string labs1, labs2;
            if (labselect1.Text == "無") { labs1 = ""; } else { labs1 = labselect1.Text; }
            if (labselect2.Text == "無") { labs2 = ""; } else { labs2 = labselect2.Text; }
            if (labs1 != "" || labs2 != "")
            {
                IEnumerable<AstroJsonList> AstroResultSt = from e in Astro
                                                           where e.Select1 == labs1 || e.Select2 == labs1
                                                           select e;
                IEnumerable<AstroJsonList> AstroResultNd = from e in AstroResultSt
                                                           where e.Select1 == labs2 || e.Select2 == labs2
                                                           select e;
                if (AstroResultNd.Count() == 0)
                {
                    Astro.Add(new AstroJsonList()
                    {
                        Select1 = labs1,
                        Select2 = labs2,
                        information = txtInfo.Text
                    });
                }
                else
                {
                    AstroJsonList model = Astro.Where(X => X.information == AstroResultNd.First().information).FirstOrDefault();
                    model.information = txtInfo.Text;
                }
                Text = "　*" + setting.filename + "　-　占星星位Json讀寫";
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtboxExit();
            Button thisbtn = sender as Button;
        
            if (selectFlat1 == true && selectFlat2 == true)
            {
                labselect2.Text = "無";
                selectFlat2 = false;
                labselect1.Text = thisbtn.Text;
                selectFlat1 = true;
                labselect1.BackColor = Color.Transparent;
                labselect2.BackColor = Color.LightBlue;
            }

            else if (selectFlat1 == true)
            {
                labselect2.Text = thisbtn.Text;
                selectFlat2 = true;
                labselect1.BackColor = Color.LightBlue;
                labselect2.BackColor = Color.Transparent;
            }
            else
            {
                labselect1.Text = thisbtn.Text;
                selectFlat1 = true;
                labselect1.BackColor = Color.Transparent;
                labselect2.BackColor = Color.LightBlue;
            }
            FindInfo();



        }
        private void ReadList(string FilePath)
        {
            FileStream fs = new FileStream(FilePath, FileMode.Open);
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(Astro.GetType());
            Astro = dcjs.ReadObject(fs) as List<AstroJsonList>;
            fs.Close();
        }


        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            AstroFunction AF = new AstroFunction();
            AF.WriteJson(Astro);
            FileName FN = new FileName();
            FN.ShowDialog();

        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            txtboxExit();


            OpenFileDialog OF = new OpenFileDialog();
            OF.DefaultExt = ".json";
            OF.Filter = "Json|*.json";
            OF.InitialDirectory = Directory.GetCurrentDirectory();
            DialogResult DR = OF.ShowDialog();
            if (DialogResult.OK == DR)
            {
                setting.filename = Path.GetFileNameWithoutExtension(OF.FileName);
                Text = "　" + setting.filename + "　-　占星星位Json讀寫";
                ReadList(OF.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AstroFunction AF = new AstroFunction();

            if (string.IsNullOrEmpty(setting.filename))
            {
                AF.WriteJson(Astro);
                FileName FN = new FileName();
                DialogResult R = FN.ShowDialog();
                if (DialogResult.OK == R) { Text = "　" + setting.filename + "　-　占星星位Json讀寫"; }
            }
            else
            {
                string detailpath = setting.path + setting.filename + ".json";
                AF.WriteJson(Astro);
                File.WriteAllText(detailpath, setting.data);
                Text = "　" + setting.filename + "　-　占星星位Json讀寫";
            }
        }

        private void palinfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtInfo.Enabled = true;
            txtInfo.Focus();

            labselect1.BackColor = Color.LightBlue;
            labselect2.BackColor = Color.Transparent;

        }



        private void FrmClick(object sender, EventArgs e)
        {

            if (txtInfo.Enabled == false)
            {
                selectFlat1 = false;
                selectFlat2 = false;
                labselect1.BackColor = Color.LightBlue;
                labselect1.Text = "無";
                labselect2.BackColor = Color.Transparent;
                labselect2.Text = "無";
            }
            else { txtboxExit(); }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string testshow = "";
            foreach (AstroJsonList X in Astro)
            {          
                testshow += $"Select1：{X.Select1}，Select2：{X.Select2}，Info：{X.information}\n";
            }
            MessageBox.Show(testshow);
        }



        private void txtInfo_EnabledChanged(object sender, EventArgs e)
        {
            if (txtInfo.Enabled == false)
            {
                SaveInfo();
            }
        }

    }
}
