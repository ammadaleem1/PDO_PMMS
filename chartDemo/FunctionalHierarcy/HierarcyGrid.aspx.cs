using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chartDemo.Controls;
using chartDemo.DataSource;
using chartDemo.XHQService;
using System.Data;

namespace chartDemo.FunctionalHierarcy
{
    public partial class HierarcyGrid : PageBase
    {
        protected void btn_Click(object sender, EventArgs e)
        {
            gvFunHierarcy.ExportSettings.IgnorePaging = true;
            gvFunHierarcy.ExportSettings.ExportOnlyData = true;
            gvFunHierarcy.ExportSettings.OpenInNewWindow = true;
            gvFunHierarcy.MasterTableView.ExportToExcel();
        }
        XhqServiceWrapper.ServiceWrapper service;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            service = new XhqServiceWrapper.ServiceWrapper();
            gvFunHierarcy.DataSource = GetHierarcyList();
            gvFunHierarcy.DataBind();
        }

        DataTable GetHierarcyList()
        {
            LeftNavigation control = (LeftNavigation)this.Master.FindControl("ucNavigation");
            int level = control.Level;
            string menuName = control.MenuText;
            DataTable dt = new DataTable();
            dt = service.GetInstrumentsList(level,menuName);
            return dt;
            
            //switch (level)
            //{
            //    case 2:
            //        return SourceConnection.InstrumentFunctionalHierarchies.Where(x => x.MainClass.ToLower().Equals(menuName.ToLower())).ToList();
            //    case 3:
            //        return SourceConnection.InstrumentFunctionalHierarchies.Where(x => x.SubClass1.ToLower().Equals(menuName.ToLower())).ToList();
            //    case 4:
            //        return SourceConnection.InstrumentFunctionalHierarchies.Where(x => x.SubClass2.ToLower().Equals(menuName.ToLower())).ToList();
            //    default:
            //        return SourceConnection.InstrumentFunctionalHierarchies.ToList();
            //}
        }
    }
}