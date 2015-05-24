using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chartDemo.Controls
{
    public partial class TestDevice : System.Web.UI.UserControl
    {
        public string DeviceName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DeviceName.ToLower().Equals("vortex"))
            {
                tblg2o2.Visible = true;
                VortexDevice();
            }
            else
            {
                tblg1o2.Visible = true;
                WaterDevice();
            }
        }

        void VortexDevice()
        {
            img_g2o2_1.ImageUrl = @"~\Assets\images\ico_bend.jpg";
            img_g2o2_2.ImageUrl = @"~\Assets\images\ico_Circle.jpg";
            img_g2o2_3.ImageUrl = @"~\Assets\images\ico_infinite.jpg";
            img_g2o2_4.ImageUrl = @"~\Assets\images\ico_tri.jpg";
            img_g2o2_5.ImageUrl = @"~\Assets\images\ico_u.jpg";
            img_g2o2_6.ImageUrl = @"~\Assets\images\ico_vortex.jpg";
            
        }
        
        void WaterDevice()
        {
            img_g2o2_1.ImageUrl = @"~\Assets\images\ico_wave.jpg";
            img_g2o2_2.ImageUrl = @"~\Assets\images\ico_wave1.jpg";
            img_g2o2_3.ImageUrl = @"~\Assets\images\ico_infinite.jpg";
            img_g2o2_4.ImageUrl = @"~\Assets\images\ico_Circle.jpg";
            img_g2o2_5.ImageUrl = @"~\Assets\images\ico_u.jpg";
            img_g2o2_6.ImageUrl = @"~\Assets\images\ico_vortex.jpg";

        }
    }
}