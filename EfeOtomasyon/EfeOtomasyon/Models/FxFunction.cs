using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfeOtomasyon.Models
{
    public class FxFunction
    {
        public string ImageUpload(HttpPostedFileBase resim, out bool islemSonucu)
        {
            if (resim.ContentType.Contains("image"))
            {
                if (resim.ContentLength < 10000000)
                {
                    string resimAdi = Guid.NewGuid().ToString().Replace('-', '_').ToLower();
                    string path = string.Format("~/Content/uploads/{0}.{1}", resimAdi, resim.ContentType.Split('/')[1]);
                    resim.SaveAs(HttpContext.Current.Server.MapPath(path));
                    islemSonucu = true;
                    return path;
                }
                else
                {
                    islemSonucu = false;
                    return "Resim boyutu izin verilenden daha büyük!";
                }
            }
            else
            {
                islemSonucu = false;
                return "Yüklediğiniz dosya bir resim değil";
            }
        }
    }
}
