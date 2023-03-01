using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace call_web_api
{
    public class nv
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public int HSLuong { get; set; }

        public nv()
        {

        }

        public nv(string maNV, string tenNv, int hSLuong)
        {
            MaNV = maNV;
            TenNV = tenNv;
            HSLuong = hSLuong;
        }
    }
}
