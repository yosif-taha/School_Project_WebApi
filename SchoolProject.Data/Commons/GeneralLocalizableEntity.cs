using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        public string Localized(string txtEn, string txtAr)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return txtAr;
            return txtEn;
        }
    }
}
