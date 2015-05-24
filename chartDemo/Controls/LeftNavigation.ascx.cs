using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chartDemo.DataSource;
using Telerik.Web.UI;

namespace chartDemo.Controls
{
    public partial class LeftNavigation : System.Web.UI.UserControl
    {
        public string MenuText
        {
            get { return (rtvNavigation.SelectedNode != null) ? rtvNavigation.SelectedNode.Text : string.Empty; }
            set { }
        }
        public int Level
        {
            get { return (rtvNavigation.SelectedNode != null) ? rtvNavigation.SelectedNode.Level : 0; }
            set { }
        }

        public bool isSelectedIndexChange { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PMMSConnection conn = new PMMSConnection();
                List<PlantHierarchy> hierarchy = conn.PlantHierarchies.ToList();

                rtvNavigation.DataSource = hierarchy;
                rtvNavigation.DataFieldID = "ItemID";
                rtvNavigation.DataTextField = "ItemName";
                rtvNavigation.DataValueField = "ItemID";
                rtvNavigation.DataFieldParentID = "ParentID";
                rtvNavigation.DataBind();
    
            }

            RadTreeNode node = rtvNavigation.Nodes.FindNodeByText("ALMAQYAS");
            node.Expanded = true;

            RadTreeNode node2 = node.Nodes.FindNodeByText("FUNCTIONAL_HIERARCY");
            node2.Expanded = true;
        }

        protected void rtvNavigation_NodeClick(object sender, RadTreeNodeEventArgs e)
        {

            isSelectedIndexChange = true;
           // MenuText = e.Node.Text;
           // Level = e.Node.Level;
        }
    }
}