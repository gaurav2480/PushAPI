﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using ASPSnippets.GoogleAPI;

public partial class Contractsite_googlesign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Button1_Click(Button1, null);

       // GoogleConnect.ClientId = "606504304030-n75chncdgcj30pkjrtmu6dnscdljb5ol.apps.googleusercontent.com";
        //GoogleConnect.ClientSecret = "4ZCzhAAYyWWYCYoY67IWTPKn";
        //GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];

        // GoogleConnect.Authorize("profile", "email");

       
        if (!string.IsNullOrEmpty(Request.QueryString["code"]))
        {
            string code = Request.QueryString["code"];
            string json = GoogleConnect.Fetch("me", code);
            Class1.GoogleProfile profile = new JavaScriptSerializer().Deserialize<Class1.GoogleProfile>(json);
            string uemail = TextBox1.Text = profile.Emails.Find(email => email.Type == "ACCOUNT").Value;// profile.DisplayName; //profile.Id;
                                                                                                        //lblName.Text = profile.DisplayName;
            string groupid = "";
            string title = "",uname="";                                                                                         //lblEmail.Text = profile.Emails.Find(email => email.Type == "account").Value;
                                                                                                                       //lblGender.Text = profile.Gender;
                                                                                                                       //lblType.Text = profile.ObjectType;
                                                                                                                       //ProfileImage.ImageUrl = profile.Image.Url;
                                                                                                                       //pnlProfile.Visible = true;
                                                                                                                       //btnLogin.Enabled = false;

            int user = Queries2.UserExists(uemail);
            if (user == 1)
            {
                uname = Queries2.getusername(uemail);
                groupid = Queries.GetGroupID(uname);
                title = Queries.GetTitle(uname);
                
                Session["GroupId"] = groupid;
                Session["username"] = uname;
                Session["title"] = title;
               // string office = Queries.GetOffice(uemail);
                //Session["office"] = office;

                //Response.Redirect("index.aspx");
                Response.Redirect("~/WebSite5/production/Dashboard.aspx");

            }
             else   //if (test=="anket.hoble@karmagroup.com")
            {
                Response.Redirect("~/WebSite5/production/login.aspx");

            }

        }
        if (Request.QueryString["error"] == "access_denied")
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
        }
        Button1_Click(Button1, null);

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GoogleConnect.Authorize("profile", "email");
        // GoogleConnect.Clear(Request.QueryString["code"]);
    }
}