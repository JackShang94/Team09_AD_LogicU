using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team09LogicU.Pages
{
    public partial class SC_O_TrendAnalysisReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string data = "["+
         "['Element', 'Density', { role: 'style' }],"+
         "['Copper', 8.94, '#b87333'], "+
         "['Silver', 10.49, 'silver'], "+
         "['Platinum', 21.45, 'color: #e5e4e2' ]"+ 
      "]";
            chartData.InnerHtml = "<script>var chart1Data =" + data + ";</script>";


           


        }

    }
}