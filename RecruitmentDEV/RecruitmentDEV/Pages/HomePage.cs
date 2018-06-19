using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentDEV.Data;

namespace RecruitmentDEV.Pages
{
    public class HomePage
    {
        MapJsonAPI mapAPI = new MapJsonAPI();
        DataModel data = mapAPI.GetData("");
    }
}
