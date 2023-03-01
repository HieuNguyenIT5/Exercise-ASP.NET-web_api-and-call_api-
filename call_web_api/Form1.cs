using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace call_web_api
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hienthi();
        }
        private void Hienthi()
        {
            string url = "http://localhost:81/hieukhac/api/qlnv/danhsach";
            HttpWebRequest req = HttpWebRequest.CreateHttp(url) ;
            WebResponse res = req.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(nv[]));
            object data = js.ReadObject(res.GetResponseStream());
            nv[] danhsach = (nv[])data;
            dgvDanhsach.DataSource = danhsach;
            dgvDanhsach.Columns[0].Width = 100;
            dgvDanhsach.Columns[1].Width = 300;
            dgvDanhsach.Columns[2].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:81/hieukhac/api/qlnv/themnv";
            var client = new WebClient();
            var sv = new NameValueCollection();
            sv["MaNV"] = textBox1.Text;
            sv["TenNV"] = textBox2.Text;
            sv["HSLuong"] = textBox3.Text;
            var res = client.UploadValues(url, sv);
            string msg = Encoding.UTF8.GetString(res);
            MessageBox.Show("Ket qua la: " + msg);
            Hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = String.Format("?manv={0}", textBox1.Text);
            string url = "http://localhost:81/hieukhac/api/qlnv/xoanv"+str;
            WebRequest req = WebRequest.CreateHttp(url);
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if(res.ContentLength == 4)
            {
                MessageBox.Show("Xoa thanh cong!");
            }
            else
            {
                MessageBox.Show("Xoa that bai!");
            }
            Hienthi();
        }
    }
}
