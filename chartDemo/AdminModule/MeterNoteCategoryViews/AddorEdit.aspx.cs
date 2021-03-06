﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chartDemo.DataSource;
using chartDemo.Helpers;
using System.Data;
using chartDemo.DataSource;

namespace chartDemo.AdminModule.MeterNoteCategoryViews
{
    public partial class AddorEdit : PageBase
    {
        bool Update { get; set; }
        int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initialize();
            }
            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"].ToString()))
                Update = true;
            else
                Update = false;
        }

        void Initialize()
        {
            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"].ToString()))
            {
                Update = true;
                Id = StringHelper.TryParse(StringHelper.Decrypt(Request.QueryString["Id"].ToString()));
                DataSource.MeterNoteCategory cat = SourceConnection.MeterNoteCategories.Where(x => x.Id.Equals(Id)).FirstOrDefault();
                FillDataForUpdate(cat);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Id = (Update) ? StringHelper.TryParse(StringHelper.Decrypt(Request.QueryString["Id"].ToString())) : 0 ;
            DataSource.MeterNoteCategory data = (!Update) ? new DataSource.MeterNoteCategory() : SourceConnection.MeterNoteCategories.Where(x => x.Id.Equals(Id)).First();
            data.Description = txtDescription.Text;
            data.Category = txtCategory.Text;

            if (!Update)
            {
                SourceConnection.MeterNoteCategories.AddObject(data);
            }
            
            SourceConnection.SaveChanges();
            Response.Redirect("DataView.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataView.aspx");
        }


        void FillDataForUpdate(DataSource.MeterNoteCategory data)
        {
            txtCategory.Text = data.Category;
            txtDescription.Text = data.Description;
        }

    }
}