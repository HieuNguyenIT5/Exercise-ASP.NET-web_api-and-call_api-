using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class QlnvController : ApiController
    {
        QLNV db = new QLNV();
        [HttpGet]
        [Route("api/qlnv/danhsach")]
        public List<NV> Danhsach()
        {
           return db.NV.ToList();
        }

        [HttpPost]
        public bool ThemNV([FromBody] NV nv)
        {
            try
            {
                db.NV.Add(nv);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("Loi cho nay " + e.Message);
                return false;
            }
        }
        [HttpDelete]
        public bool XoaNV(string manv)
        {
            NV nv = db.NV.SingleOrDefault(p=>p.MaNV == manv);
            if(nv != null)
            {
            db.NV.Remove(nv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
