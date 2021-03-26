using System;
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
using Microsoft.Reporting.WebForms;
public partial class WebSite5_production_Inhouse : System.Web.UI.Page
{

    public string getdata()
    {
        string user = (string)Session["username"];
        //string user = "anket";
        string htmlstr = "";
        string office1 = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlDataReader reader2 = Queries.userOffices(user);
        while (reader2.Read())
        {
            string offices = reader2.GetString(0);
            office1 += "'" + offices + "'" + ",";

        }
reader2.Close();

        string query = "select distinct parentnode,ReportOrder from user_group_access ug join UserOffice uo on ug.Username=uo.UserID where username ='" + user + "' and uo.Office in(" + office1.TrimEnd(',') + ") order by ReportOrder asc";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            if (name == "")
            {

            }
            else
            {
                if (name == "Reports" || name == "REPORTS")
                {
                    htmlstr += "<li><a href='reportSlider.aspx'><i class='fa fa-home'></i>" + name + " <span class='fa fa-chevron - down'></span> </a><ul class='nav child_menu'>";
                    htmlstr += "</ul></li>";
                    name = "";
                }
                if (name == "")
                {

                }
                else
                {
                    htmlstr += "<li><a><i class='fa fa-home'></i>" + name + " <span class='fa fa-chevron - down'></span> </a><ul class='nav child_menu'>";
                    SqlConnection sqlcon1 = new SqlConnection(conn);
                    sqlcon1.Open();
                    string query1 = "select distinct name,PageName,AccessName,Page_Order from user_group_access ug join UserOffice uo on ug.Username=uo.UserID where ug.ParentNode='" + name + "' and username ='" + user + "' and uo.Office in(" + office1.TrimEnd(',') + ") order By name asc";
                    SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);


                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        string pagename = reader1.GetString(0);
                        string pageurl = reader1.GetString(1);
                        string AccessName = reader1.GetString(2);

                        htmlstr += "<li><a href=" + pageurl + "?name=" + AccessName + ">" + pagename + " </a></li>";
                        Session["pagename"] = pagename;
                        //  string office = Queries.GetOffice(user);
                        //  Session["office"] = office;
                        Session["username"] = user;
                    }

                    htmlstr += "</ul></li>";



                    reader1.Close();
                    sqlcon1.Close();

                }

            }
        }

        reader.Close();
        sqlcon.Close();
        return htmlstr;

    }

	public string getreportdetailsAllReports()
	{

		int i = 0;
		string user = (string)Session["username"];
		string htmlstr = "";
		string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
		string query = "select distinct 'All Reports';";
		SqlConnection sqlcon = new SqlConnection(conn);
		sqlcon.Open();
		SqlCommand cmd = new SqlCommand(query, sqlcon);
		SqlDataReader reader = cmd.ExecuteReader();

		while (reader.Read())
		{
			string name = reader.GetString(0);
			if (name == "")
			{

			}
			else
			{

				string nameCapital = name.ToUpper();

				htmlstr += "<li data-toggle='collapse' data-target='#productss" + i + "' class='collapsed'><a href='#'><i class='fa fa-gift fa-lg'></i>" + nameCapital + "<span class='arrow'></span></a></li><ul class='collapse' id='productss" + i + "'>";
				htmlstr += "<input type='Text' style='color:black;' id='searchReports' class='form-control' placeholder='Search for reports'/>";
				SqlConnection sqlcon1 = new SqlConnection(conn);
				sqlcon1.Open();
				string query1 = "select distinct name, pagename, accessname from user_group_access ug where  username ='" + user + "' and PageType='Reports' order By name asc";

				SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);

				SqlDataReader reader1 = cmd1.ExecuteReader();
				while (reader1.Read())
				{
					string pagename = reader1.GetString(0);
					string pageurl = reader1.GetString(1);
					string AccessName = reader1.GetString(2);
					htmlstr += "<li style='background-color:#535a62;'>  <a href=" + pageurl + "?name=" + AccessName + "><span class='glyphicon glyphicon-menu-right'></span> " + pagename + " </a></li>";
					Session["pagename"] = pagename;
					//string office = Queries.GetOffice(user);
					//Session["office"] = office;
					Session["username"] = user;
				}

				htmlstr += "</ul>";
				i++;


				reader1.Close();
				sqlcon1.Close();
			}
		}

		reader.Close();
		sqlcon.Close();
		return htmlstr;

	}

	public string getreportdetailsAllReportsByCountry()
    {

        int i = 0;
        string user = (string)Session["username"];
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct 'Reports By Country';";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            if (name == "")
            {

            }
            else
            {

                htmlstr += "<li data-toggle='collapse' data-target='#productsss" + i + "' class='collapsed'><a href='#'><i class='fa fa-gift fa-lg'></i>" + name + "<span class='arrow'></span></a></li><ul class='collapse' id='productsss" + i + "'>";
                htmlstr += "<input type='Text' style='color:black;' id='searchReports1' class='form-control' placeholder='Search By Country'/>";
                SqlConnection sqlcon1 = new SqlConnection(conn);
                sqlcon1.Open();
                string query1 = "select * from user_group_access ug where  username ='" + user + "' and PageType='Reports' order By name asc";

                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    string pagename = reader1.GetString(1);
                    string pageurl = reader1.GetString(3);
                    string AccessName = reader1.GetString(6);
                    string office = reader1.GetString(4);

                    htmlstr += "<li style='background-color:#535a62;'>  <a href=" + pageurl + "?name=" + AccessName + "><span class='glyphicon glyphicon-menu-right'></span> " + pagename + " </a></li>";
                    Session["pagename"] = pagename;
                    //string office = Queries.GetOffice(user);
                    //Session["office"] = office;
                    Session["username"] = user;
                }

                htmlstr += "</ul>";
                i++;


                reader1.Close();
                sqlcon1.Close();
            }
        }

        reader.Close();
        sqlcon.Close();
        return htmlstr;

    }

    public string getreportdetails()
  	{

  		int i = 0;
  		string user = (string)Session["username"];
  		string htmlstr = "";
  		string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
  		string query = "select * from (select distinct(groups) from user_group_access where groups in ('Accounts','IT','Sales','Others') and username =  '" + user + "') as a order by case when groups = 'Accounts' then '1' when groups = 'Sales' then '2' when groups = 'IT' then '3' when groups = 'Others' then '4' else Groups end asc";
  		SqlConnection sqlcon = new SqlConnection(conn);
  		sqlcon.Open();
  		SqlCommand cmd = new SqlCommand(query, sqlcon);
  		SqlDataReader reader = cmd.ExecuteReader();

  		while (reader.Read())
  		{
  			string name = reader.GetString(0);
  			if (name == "")
  			{

  			}
  			else
  			{

  				string nameCapital = name.ToUpper();

  				htmlstr += "<li data-toggle='collapse' data-target='#products" + i + "' class='collapsed'><a href='#'><i class='fa fa-gift fa-lg'></i>" + nameCapital + "<span class='arrow'></span></a></li><ul class='collapse' id='products" + i + "'>";
  				SqlConnection sqlcon1 = new SqlConnection(conn);
  				sqlcon1.Open();
  				string query1 = "select * from user_group_access ug where ug.Groups='" + name + "' and username ='" + user + "' order By name asc";

  				SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);

  				SqlDataReader reader1 = cmd1.ExecuteReader();
  				while (reader1.Read())
  				{
  					string pagename = reader1.GetString(1);
  					string pageurl = reader1.GetString(3);
  					string AccessName = reader1.GetString(6);
  					string office = reader1.GetString(4);
  					htmlstr += "<li style='background-color:#535a62;'>  <a href=" + pageurl + "?name=" + AccessName + "><span class='glyphicon glyphicon-menu-right'></span> " + pagename + " </a></li>";
  					Session["pagename"] = pagename;
  					//string office = Queries.GetOffice(user);
  					//Session["office"] = office;
  					Session["username"] = user;
  				}

  				htmlstr += "</ul>";
  				i++;


  				reader1.Close();
  				sqlcon1.Close();
  			}
  		}

  		reader.Close();
  		sqlcon.Close();
  		return htmlstr;

  	}

    protected void Page_Load(object sender, EventArgs e)
    {

         string user = (string)Session["username"];
        //string user = "anket";
        // office = (string)Session["office"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
        //Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
if (!Page.IsPostBack)
        {
        DataSet ds = Queries.loadDefaultDate(user);
            if (ds.Tables[0].Rows[0]["default_Date"].ToString() == "Y")
            {

                TextBox4.Text = DateTime.Today.AddDays(-1).ToString("dd-MM-yyyy");

            }
            else
            {

                TextBox4.Text = DateTime.Today.ToString("dd-MM-yyyy");
            }
        }
    }






    protected void Button1_Click(object sender, EventArgs e)
    {

        string country = Request.Form["country"];
        string venue = "";string venueGroup = "";


        string group = Request.Form["group"];
        if (group == "" || group == null)
        {
            group = "NON COOL OFF";
        }
        else
        {
            group = Request.Form["group"];
        }


        //if (country=="India" || country == "INDIA")
        //{
        //    venue = Request.Form["venueInd"];
        //    venueGroup = TextBox2.Text;
        //}
        //else
        //{
        //    venue = TextBox1.Text;
        //    venueGroup = Request.Form["venueGroup"];
        //}

            venue = Request.Form["venueInd"];
            venueGroup = TextBox2.Text;

        // show_report(country, venue, venueGroup);

        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele('" + TextBox4.Text + "','" + country + "','"+venue+"','"+venueGroup+ "','" + group + "')", true);
    }



	public string getcountries()
	{
		string query = "";
		string reportOffice = Convert.ToString(Request.QueryString["office"]);
		string user = (string)Session["username"];
		string htmlstr = "";
		if (reportOffice == null || reportOffice == "")
		{
			query = "select vc.Venue_Country_Office, vc.Venue_Country_Name from useroffice uf inner join venuecountry vc on vc.Venue_Country_Office = uf.Office where uf.UserID = '" + user + "'";
			/*htmlstr += "<option disabled selected value>--Select an Option--</option>";*/
			htmlstr += "<option value='" + 0 + "' selected disabled>--Select an Option--</option>";

		}
		else if (reportOffice == "EUROPE")
		{
			query = "select vc.Venue_Country_Office, vc.Venue_Country_Name from useroffice uf inner join venuecountry vc on vc.Venue_Country_Office = uf.Office where uf.UserID = '" + user + "' and region = 'Europe & Caribbean'";
			/*htmlstr += "<option disabled selected value>--Select an Option--</option>";*/

		}
		else if (reportOffice == "SEAP")
		{
			query = "select vc.Venue_Country_Office, vc.Venue_Country_Name from useroffice uf inner join venuecountry vc on vc.Venue_Country_Office = uf.Office where uf.UserID = '" + user + "' and region = 'South East Asia Pacific'";
		}
		else if (reportOffice == "HML")
		{
			query = "select vc.Venue_Country_Office, vc.Venue_Country_Name from useroffice uf inner join venuecountry vc on vc.Venue_Country_Office = uf.Office where uf.UserID = '" + user + "' and region = 'India & Middle East'";
		}
		else if (reportOffice == "IVO" || reportOffice == "VTM" || reportOffice == "THL" || reportOffice == "HML")
		{
			query = "select vc.Venue_Country_Office, vc.Venue_Country_Name from useroffice uf inner join venuecountry vc on vc.Venue_Country_Office = uf.Office where uf.UserID = '" + user + "' and Venue_Country_Office = '" + reportOffice + "'";

		}

		string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

		SqlConnection sqlcon = new SqlConnection(conn);
		sqlcon.Open();
		SqlCommand cmd = new SqlCommand(query, sqlcon);
		SqlDataReader reader = cmd.ExecuteReader();
		while (reader.Read())
		{
			string office = reader.GetString(0);
			string name = reader.GetString(1);
			htmlstr += "<option value='" + name + "'>" + name + "</option>";

		}

		string query2;

		if (reportOffice != null && reportOffice != "" && reportOffice != "EUROPE" && reportOffice != "SEAP" && reportOffice != "HML")
		{

			query2 = "select vc.Venue_Country_Office, vc.Venue_Country_Name from useroffice uf inner join venuecountry vc on vc.Venue_Country_Office = uf.Office where uf.UserID = '" + user + "' and Venue_Country_Office <> '" + reportOffice + "'";

			string conn2 = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

			SqlConnection sqlcon2 = new SqlConnection(conn2);
			sqlcon2.Open();
			SqlCommand cmd2 = new SqlCommand(query2, sqlcon);
			SqlDataReader reader2 = cmd2.ExecuteReader();
			while (reader2.Read())
			{
				string office = reader2.GetString(0);
				string name = reader2.GetString(1);
				htmlstr += "<option value='" + name + "'>" + name + "</option>";

			}
		}


		sqlcon.Close();
		return htmlstr;

	}


	public string getregion()
	{
		string query = "";
		string reportRegion = Convert.ToString(Request.QueryString["region"]);

		string user = HttpContext.Current.Session["username"].ToString();

		string htmlstr = "";
		if (reportRegion == null || reportRegion == "")
		{
			query = "select * from ((select distinct (region ) from (select case vc.Venue_Country_Name when 'INDONESIA' then 'SEAP' when 'THAILAND' then 'SEAP' when 'VIETNAM' then 'SEAP' end as region from VenueCountry vc inner join UserOffice uo on vc.Venue_Country_Office = uo.Office where uo.UserID = '" + user + "' and region = 'South East Asia Pacific') as region) union (select distinct (country) from (select vc.Venue_Country_Office, case vc.Venue_Country_Name when 'Greece' then 'EUROPE' when 'Ireland' then 'EUROPE' when 'Italy' then 'EUROPE' when 'Germany' then 'EUROPE' when 'France' then 'EUROPE' when 'Indonesia' then 'SEAP' when 'Thailand' then 'SEAP' when 'Vietnam' then 'SEAP' when 'India' then 'INDIA' end as Country from VenueCountry vc inner join UserOffice uo on vc.Venue_Country_Office = uo.Office where uo.UserID = '" + user + "') as country)) as region order by case when region = 'INDONESIA' then '1' when region = 'VIETNAM' then '2' when region = 'THAILAND' then '3' when region = 'SEAP' then '4' when region = 'INDIA' then '5' when region = 'EUROPE' then '6' else region end asc";

		}
		else
		{
			query = "select * from ((select distinct (region ) from (select case vc.Venue_Country_Name when 'INDONESIA' then 'SEAP' when 'THAILAND' then 'SEAP' when 'VIETNAM' then 'SEAP' end as region from VenueCountry vc inner join UserOffice uo on vc.Venue_Country_Office = uo.Office where uo.UserID = '" + user + "' and region = 'South East Asia Pacific') as region) union (select distinct (country) from (select vc.Venue_Country_Office, case vc.Venue_Country_Name when 'Greece' then 'EUROPE' when 'Ireland' then 'EUROPE' when 'Italy' then 'EUROPE' when 'Germany' then 'EUROPE' when 'France' then 'EUROPE' when 'Indonesia' then 'SEAP' when 'Thailand' then 'SEAP' when 'Vietnam' then 'SEAP' when 'India' then 'INDIA' end as Country from VenueCountry vc inner join UserOffice uo on vc.Venue_Country_Office = uo.Office where uo.UserID = '" + user + "') as country)) as country where region = '" + reportRegion + "' order by case when region = 'INDONESIA' then '1' when region = 'VIETNAM' then '2' when region = 'THAILAND' then '3' when region = 'SEAP' then '4' when region = 'INDIA' then '5' when region = 'EUROPE' then '6' else region end asc";

		}

		string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

		SqlConnection sqlcon = new SqlConnection(conn);
		sqlcon.Open();
		SqlCommand cmd = new SqlCommand(query, sqlcon);
		SqlDataReader reader = cmd.ExecuteReader();
		while (reader.Read())
		{

			string name = reader.GetString(0);
			htmlstr += "<option value='" + name + "'>" + name + "</option>";

		}

		string query2;

		if (reportRegion != null && reportRegion != "")
		{

			query2 = "select * from ((select distinct (region ) from (select case vc.Venue_Country_Name when 'INDONESIA' then 'SEAP' when 'THAILAND' then 'SEAP' when 'VIETNAM' then 'SEAP' end as region from VenueCountry vc inner join UserOffice uo on vc.Venue_Country_Office = uo.Office where uo.UserID = '" + user + "' and region = 'South East Asia Pacific') as region) union (select distinct (country) from (select vc.Venue_Country_Office, case vc.Venue_Country_Name when 'Greece' then 'EUROPE' when 'Ireland' then 'EUROPE' when 'Italy' then 'EUROPE' when 'Germany' then 'EUROPE' when 'France' then 'EUROPE' when 'Indonesia' then 'SEAP' when 'Thailand' then 'SEAP' when 'Vietnam' then 'SEAP' when 'India' then 'INDIA' end as Country from VenueCountry vc inner join UserOffice uo on vc.Venue_Country_Office = uo.Office where uo.UserID = '" + user + "') as country)) as country where region <> '" + reportRegion + "' order by case when region = 'INDONESIA' then '1' when region = 'VIETNAM' then '2' when region = 'THAILAND' then '3' when region = 'SEAP' then '4' when region = 'INDIA' then '5' when region = 'EUROPE' then '6' else region end asc";
			string conn2 = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

			SqlConnection sqlcon2 = new SqlConnection(conn2);
			sqlcon2.Open();
			SqlCommand cmd2 = new SqlCommand(query2, sqlcon);
			SqlDataReader reader2 = cmd2.ExecuteReader();
			while (reader2.Read())
			{

				string name = reader2.GetString(0);
				htmlstr += "<option value='" + name + "'>" + name + "</option>";

			}
		}


		sqlcon.Close();
		return htmlstr;

	}


	public class VenueType
    {
        public string VenueTypeID { get; set; }
        public string VenueTypeName { get; set; }

    }


    

    [WebMethod]
    public static string getVenueGroup(string venue,string country)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Venue2_Name from venue2 where Venue_ID in (select v.Venue_ID from venue v join VenueCountry vc on v.Venue_Country_ID=vc.Venue_Country_ID where Venue_Name = '"+venue+"' and vc.Venue_Country_Name='" + country + "' and v.Venue_Status='Active') and venue2_status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var Venue_Group_Name = reader.GetString(0);

                JSON += "[\"" + Venue_Group_Name + "\"],";

            }
        }
        else
        {
            JSON += "[\"" + "" + "\"],";
        }

        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string getSubVenue(string venue)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct sv.Svenue_Name from venue v join venue2 v2 on v.Venue_ID=v2.Venue_ID join Sub_Venue sv on v2.Venue2_ID=sv.Venue2_ID where v.Venue_Name='"+venue+"' and sv.SVenue_Status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var Svenue_Name = reader.GetString(0);

                JSON += "[\"" + Svenue_Name + "\"],";

            }
        }
        else
        {
            JSON += "[\"" + "" + "\"],";
        }

        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string getAdminRights()
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string JSON = "{\n \"names\":[";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        string query = "select name,PageName from user_group_access  where Username='" + user + "' and PageType='Admin' Order by name asc";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string name = reader.GetString(0);
                string PageName = reader.GetString(1);

                JSON += "[\"" + name + "\" , \"" + PageName + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";


        }
        else
        {

            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        reader.Close();
        sqlcon.Close();



        return JSON;



    }

    [WebMethod]
    public static string searchProfile(string profileID)
    {
        string useroffice = "";
        string user = HttpContext.Current.Session["username"].ToString();
        SqlDataReader reader8 = Queries.userOffices(user);
        while (reader8.Read())
        {
            string useroffices = reader8.GetString(0);
            useroffice += "'" + useroffices + "'" + ",";

        }
reader8.Close();
        string JSON = "{\n \"names\":[";

        if (profileID == "" || profileID == null)
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {

            SqlDataReader reader = production.searchProfiles(profileID, useroffice);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string profile = reader.GetString(0);
                    string title = reader.GetString(1);
                    string name = reader.GetString(2);
                    string email = reader.GetString(3);
                    string mobile = reader.GetString(4);
                    string tourdate = reader.GetString(5);

                    string profile1 = profile.Trim();
                    string title1 = title.Trim();
                    string name1 = name.Trim();
                    string email1 = email.Trim();
                    string mobile1 = mobile.Trim();
                    string tourdate1 = tourdate.Trim();

                    JSON += "[\"" + profile1 + "\" , \"" + title1 + "\",\"" + name1 + "\" , \"" + email1 + "\", \"" + mobile1 + "\", \"" + tourdate1 + "\"],";


                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";


            }
            else
            {

                JSON += "[\"" + "" + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }

            reader.Close();


        }

        return JSON;



    }



    [WebMethod]
    public static string getlink(string profileID)
    {
        //string office = HttpContext.Current.Session["office"].ToString();
        string JSON = "{\n \"names\":[";


            string val = "EditProfile1.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";




        return JSON;



    }

    [WebMethod]
    public static string getVenue(string country)
    {
        string Venue_Country_ID;

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Name = '" + country + "' and Venue_Country_Status='Active';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                Venue_Country_ID = reader.GetString(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select Venue_Name,Venue_ID from venue where Venue_Country_ID='" + Venue_Country_ID + "' and Venue_Status='Active' and Venue_Name not in ('JIMBARAN SALES DECK','KOH SAMUI','VIETNAM SALES DECK');";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    var venueName = reader1.GetString(0);

                    JSON += "[\"" + venueName + "\"],";

                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";

                reader1.Close();
                sqlcon1.Close();
            }
        }
        else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }


        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string searchReports(string val)
    {

        string user = HttpContext.Current.Session["username"].ToString();
        string JSON = "{\n \"names\":[";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        string query = "select Name,PageName,ParentNode,AccessName,office from user_group_access where Username='" + user + "' and Name like '%" + val + "%' and PageType='Reports'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string name = reader.GetString(0);
                string pageName = reader.GetString(1);
                string parentNode = reader.GetString(2);
                string accessNode = reader.GetString(3);
                string office = reader.GetString(4);

                JSON += "[\"" + name + "\",\"" + pageName + "\",\"" + parentNode + "\",\"" + accessNode + "\",\"" + office + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";


        }
        else
        {

            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        reader.Close();
        sqlcon.Close();



        return JSON;



    }


    [WebMethod]
    public static string searchReports1(string val)
    {

        string user = HttpContext.Current.Session["username"].ToString();
        string JSON = "{\n \"names\":[";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        string query = "select Name,PageName,ParentNode,AccessName,office from user_group_access ug join VenueCountry vc on ug.office=vc.Venue_Country_Office where Username='" + user + "' and vc.Venue_Country_Name like '%" + val + "%' and PageType='Reports'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string name = reader.GetString(0);
                string pageName = reader.GetString(1);
                string parentNode = reader.GetString(2);
                string accessNode = reader.GetString(3);
                string office = reader.GetString(4);

                JSON += "[\"" + name + "\",\"" + pageName + "\",\"" + parentNode + "\",\"" + accessNode + "\",\"" + office + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";


        }
        else
        {

            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        reader.Close();
        sqlcon.Close();



        return JSON;



    }
}
