using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team09LogicU.Pages
{
    public partial class SS_TrendAnalysisReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            string data = "[" +
         "['Element', 'Density']," +
         "['Copper', 8.94], " +
         "['Silver', 10.49], " +
         "['Platinum', 21.45]" +
      "]";

            chartData.InnerHtml = "<script>var chart1Data =" + data + ";</script>";





        
    }
    }
}