using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ltap.Models
{
    public class AutoGeneratekey
    {

        public string Generatekey(string id)
        {
            string strkey = "";
          
            string numPart="", strPart="", strPhanSo="";
            //tach phan so 

            numPart = Regex.Match(id, @"\d+").Value;            
            //them cac so o de tach phan so 
            int phanso = (Convert.ToInt32(numPart) + 1);
            for (int i = 0; i < numPart.Length-1; i++)
            {
                strPhanSo += "0";
            }
            strPhanSo += phanso;
            //tach phan chu
            strkey = strPart + strPhanSo;            
            return strkey;
        }
    }
}