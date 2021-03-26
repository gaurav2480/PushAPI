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

/// <summary>
/// Summary description for Queries
/// </summary>
public class Queries
{

    public static SqlConnection GetDBConnection()
    {
        // Get the connection string from the configuration file
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        // Create a new connection object
        SqlConnection connection = new SqlConnection(connectionString);

        // Open the connection, and return it
        connection.Open();
        return connection;
    }
    public static DataSet LoadVenueCountry()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Country_Name  from VenueCountry where Venue_Country_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadVenue()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name  from Venue where Venue_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadVenuebasedOnCountryID(string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name  from venue where Venue_Country_ID =@venuecountry", cs1);
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadSubVenue(string venue1)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue_ID in (select Venue_ID from venue where Venue_Name=@venue)", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue1;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }



    public static DataSet LoadVenuebasedOnCountryName(string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select Venue_Name  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID  where vc.Venue_Country_Name =@venuecountry", cs1);
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static String GetVenueCountryCode(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("  select Venue_Country_ID  from VenueCountry where Venue_Country_Name =@name", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    /*  public static DataSet LoadVenueGroup()
      {
          SqlDataAdapter da;
          DataSet ds = new DataSet();
          using (SqlConnection cs1 = Queries.GetDBConnection())
          {
              SqlCommand SqlCmd = new SqlCommand("select Venue_Group_Name  from Venue_Group where Venue_Group_Status='Active' order by 1", cs1);
              da = new SqlDataAdapter(SqlCmd);
              ds = new DataSet();
              da.Fill(ds);
          }
          return (ds);

      }*/
    public static String GetVenueCode(string name, string country)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_ID from venue where Venue_Name=@name and Venue_Country_ID =@country", cs1);

            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            scd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static String GetVenueCode1(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_ID from venue where Venue_Name=@name ", cs1);

            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            //   scd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static DataSet LoadVenueGroup(string vcode)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand SqlCmd = new SqlCommand("select Venue_Group_Name  from Venue_Group where Venue_Group_Status='Active' order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select  Venue_Group_Name  from Venue_Group where Venue_ID =@vcode and Venue_Group_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@vcode", SqlDbType.VarChar).Value = vcode;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static String GetVenueGroupCode(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_Group_ID from Venue_Group where Venue_Group_Name=@name", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static DataSet LoadMarketingProgram(string vgcode)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand SqlCmd = new SqlCommand("select Marketing_Program_Name  from Marketing_Program where  Marketing_Program_Status='Active' order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Marketing_Program_Name  from Marketing_Program where  Venue_Group_ID=@vgcode", cs1);
            SqlCmd.Parameters.Add("@vgcode", SqlDbType.VarChar).Value = vgcode;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadMarketingProgramOnVenueNVGroup(string venuename, string vgname)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select m.Marketing_Program_Name  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name =@venuename and vg.Venue_Group_Name =@vgname and m.Marketing_Program_Status = 'Active'", cs1);
            SqlCmd.Parameters.Add("@venuename", SqlDbType.VarChar).Value = venuename;
            SqlCmd.Parameters.Add("@vgname", SqlDbType.VarChar).Value = vgname;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }



    public static DataSet LoadAgents()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Agent_Name  from Agent where Agent_Status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadAgents(string mktg)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select a.Agent_Name  from Agent a join Agent_marketing sm on a.Agent_ID = sm.Agent_ID join Marketing_Program mp on mp.Marketing_Program_ID = sm.marketing_program_id where a.Agent_Status = 'Active' and mp.Marketing_Program_Name =@mktg order by 1", cs1);
            SqlCmd.Parameters.Add("@mktg", SqlDbType.VarChar).Value = mktg;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    /* public static DataSet LoadAgentsOnVenue(string venue,string venuegroup)
     {
         SqlDataAdapter da;
         DataSet ds = new DataSet();
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {
             SqlCommand SqlCmd = new SqlCommand(" select a.Agent_Name from Agent_GroupVenue ag join agent a on a.Agent_ID = ag.Agent_id where   a.Agent_Status = 'Active'and ag.venue =@venue and ag.Venue_Group_ID =@venuegroup", cs1);
             SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
             SqlCmd.Parameters.Add("@venuegroup", SqlDbType.VarChar).Value = venuegroup;
             da = new SqlDataAdapter(SqlCmd);
             ds = new DataSet();
             da.Fill(ds);
         }
         return (ds);

     }*/
    public static DataSet LoadAgentsOnVenue(string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select a.Agent_Name from Agent_GroupVenue ag join agent a on a.Agent_ID = ag.Agent_id where   a.Agent_Status = 'Active'and ag.venue =@venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    /*  public static DataSet LoadManagersOnVenue(string venue, string venuegroup)
      {
          SqlDataAdapter da;
          DataSet ds = new DataSet();
          using (SqlConnection cs1 = Queries.GetDBConnection())
          {
              SqlCommand SqlCmd = new SqlCommand("  select distinct Manager_Name from managers where Manager_Status='Active' and  Venue=@venue and 	VenueGroup=@venuegroup", cs1);
              SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
              SqlCmd.Parameters.Add("@venuegroup", SqlDbType.VarChar).Value = venuegroup;
              da = new SqlDataAdapter(SqlCmd);
              ds = new DataSet();
              da.Fill(ds);
          }
          return (ds);

      }*/
    public static DataSet LoadManagersOnVenue(string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("  select distinct Manager_Name from managers where Manager_Status='Active' and  Venue=@venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    /* public static DataSet LoadTOOPCOnVenue(string venue, string venuegroup)
     {
         SqlDataAdapter da;
         DataSet ds = new DataSet();
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {
             SqlCommand SqlCmd = new SqlCommand("  select distinct to_name from OPC_TOs where TO_Status='Active' and  Venue=@venue and 	VenueGroup=@venuegroup", cs1);
             SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
             SqlCmd.Parameters.Add("@venuegroup", SqlDbType.VarChar).Value = venuegroup;
             da = new SqlDataAdapter(SqlCmd);
             ds = new DataSet();
             da.Fill(ds);
         }
         return (ds);

     }*/
    public static DataSet LoadTOOPCOnVenue(string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct to_name from OPC_TOs where TO_Status='Active' and  Venue=@venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadAgentCode()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Agent_Code_Name  from Agent_Code where Agent_Code_Status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadMemberType()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Member_Type_name   from Member_Type where Member_Type_status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCode()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryName()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct country_name   from country order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadStateName(string profile_ID, string country)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select State_Name  from State where State_Status='Active' and State_Name not in (select Profile_Address_State from Profile_Address where Profile_ID='" + profile_ID + "') and State_Country='" + country + "'", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadNationality()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct  nationality_name from nationality order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadGuestStatus()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Guest_Status_name  from Guest_Status where Guest_Status_Status ='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSalesRep()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select sales_rep_name from Sales_Rep  where sales_rep_status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadGiftOption(string office)
    {
        SqlDataAdapter da;
        DataSet dt = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Gift_Option_Name + ' -' + ' ' + item as item from Gift_Option where Gift_Option_Status = 'Active' and office=@office", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            dt = new DataSet();
            da.Fill(dt);
        }
        return (dt);

    }



    public static DataSet LoadSalesReponVenue(string venue, string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select sales_rep_name from Sales_Rep  where sales_rep_status = 'Active'  and venue =@venue and Venue_country_ID =@venuecountry", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static int InsertIDGeneration(string venue, int year)
    {
        int rowsAffected = 0;

        int Profile_Start_Val = 0;
        int Primary_Start_Val = 0;
        int Secondary_Start_Val = 0;
        int SubProfile1_Start_Val = 0;
        int SubProfile2_Start_Val = 0;
        int Address_Start_Val = 0;
        int Phone_Start_Val = 0;
        int Email_Start_Val = 0;
        int Profile_Stay_Start_Val = 0;
        int Tour_Details_Start_Val = 0;
        int Gift_Start_Val = 0;
        int SubProfile3_Start_Val = 0;
        int SubProfile4_Start_Val = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into ID_Generation values(@VenueCode,	@Year,	@Profile_Start_Val,	@Primary_Start_Val,	@Secondary_Start_Val,	@SubProfile1_Start_Val,	@SubProfile2_Start_Val,	@Address_Start_Val,	@Phone_Start_Val,	@Email_Start_Val,	@Profile_Stay_Start_Val,	@Tour_Details_Start_Val,@Gift_Start_Val,@SubProfile3_Start_Val,@SubProfile4_Start_Val)", cs1);
                da.InsertCommand.Parameters.Add("@VenueCode", SqlDbType.VarChar).Value = venue;
                da.InsertCommand.Parameters.Add("@Year", SqlDbType.Int).Value = year;
                da.InsertCommand.Parameters.Add("@Profile_Start_Val", SqlDbType.VarChar).Value = Profile_Start_Val;
                da.InsertCommand.Parameters.Add("@Primary_Start_Val", SqlDbType.VarChar).Value = Primary_Start_Val;
                da.InsertCommand.Parameters.Add("@Secondary_Start_Val", SqlDbType.VarChar).Value = Secondary_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile1_Start_Val", SqlDbType.VarChar).Value = SubProfile1_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile2_Start_Val", SqlDbType.VarChar).Value = SubProfile2_Start_Val;
                da.InsertCommand.Parameters.Add("@Address_Start_Val", SqlDbType.VarChar).Value = Address_Start_Val;
                da.InsertCommand.Parameters.Add("@Phone_Start_Val", SqlDbType.VarChar).Value = Phone_Start_Val;
                da.InsertCommand.Parameters.Add("@Email_Start_Val", SqlDbType.VarChar).Value = Email_Start_Val;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Start_Val", SqlDbType.VarChar).Value = Profile_Stay_Start_Val;
                da.InsertCommand.Parameters.Add("@Tour_Details_Start_Val", SqlDbType.VarChar).Value = Tour_Details_Start_Val;
                da.InsertCommand.Parameters.Add("@Gift_Start_Val", SqlDbType.VarChar).Value = Gift_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile3_Start_Val", SqlDbType.VarChar).Value = SubProfile3_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile4_Start_Val", SqlDbType.VarChar).Value = SubProfile4_Start_Val;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //  MessageBox.Show("Error in ID Generation Query " + ex.Message);

                string msg = "Error in ID Generation Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static String GetProfileID(string startvalue)//(string off)
    {
        string ProfileID = null;
        // string startvalue = "";
        int id = 0;
        int chek = 0;
        int year = DateTime.Now.Year;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year ", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {

                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                ProfileID = startvalue + year + id;



            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                ProfileID = startvalue + year + id;



            }



        }

        return ProfileID;
    }
    public static int UpdateProfileValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdatePrimaryValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Primary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Primary_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Primary_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Primary_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateSecondaryValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Secondary_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Secondary_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateSubprofile1Value(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val SubProfile1_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val SubProfile1_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }
    public static int UpdateSubprofile2Value(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val SubProfile2_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val SubProfile2_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }
    public static int UpdateAddressValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Address_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Address_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }
    public static int UpdatePhoneValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Phone_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Phone_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateEmailValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Stay_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Profile_Stay_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateStayValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Tour_Details_Start_Val Profile_Stay_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Tour_Details_Start_Val Profile_Stay_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }
    public static int UpdateTourValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Tour_Details_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Tour_Details_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateGiftValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Gift_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Gift_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE ID_Generation Query Gift_Start_Val " + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Gift_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static int InsertProfile(string Profile_ID, DateTime Profile_Date_Of_Insertion, string Profile_Created_By, string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple, string Office, string Comments, string Manager, string Photo_identity, string Card_Holder, string Reception, string SubVenue, string regTerms, string VP_ID, string Company_Name, string RegTerms2,string  Secondary_Employment_Status, string Lead_Source ,string Pre_Arrival,string comment2,string Verification,string Promo_Source,string Tele_agent,string subVenueGroup,string leadOffices,string feedbackComment)
    {

        int rowsAffected = 0;
        string Sale_Marketing_Source = "";
         
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile values(@Profile_ID,	@Profile_Date_Of_Insertion,	@Profile_Created_By,@Profile_Venue_Country,	@Profile_Venue,	@Profile_Group_Venue,	@Profile_Marketing_Program,	@Profile_Agent,	@Profile_Agent_Code,	@Profile_Member_Type1,	@Profile_Member_Number1,	@Profile_Member_Type2,	@Profile_Member_Number2,	@Profile_Employment_status,	@Profile_Marital_status,	@Profile_NOY_Living_as_couple,@Office,@Comments,@Manager,@Photo_identity,@Card_Holder,@Reception,@SubVenue,@regTerms,@VP_ID,@Company_Name,@RegTerms2,@Secondary_Employment_Status,@Lead_Source,@Pre_Arrival,@comment2,@Verification,@Promo_Source,@Tele_agent,@subVenueGroup,@leadOffices,@Sale_Marketing_Source,@feedbackComment)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Profile_Date_Of_Insertion", SqlDbType.DateTime).Value = Profile_Date_Of_Insertion;
                da.InsertCommand.Parameters.Add("@Profile_Created_By", SqlDbType.VarChar).Value = Profile_Created_By;
                da.InsertCommand.Parameters.Add("@Profile_Venue_Country", SqlDbType.VarChar).Value = Profile_Venue_Country;
                da.InsertCommand.Parameters.Add("@Profile_Venue", SqlDbType.VarChar).Value = Profile_Venue;
                da.InsertCommand.Parameters.Add("@Profile_Group_Venue", SqlDbType.VarChar).Value = Profile_Group_Venue;
                da.InsertCommand.Parameters.Add("@Profile_Marketing_Program", SqlDbType.VarChar).Value = Profile_Marketing_Program;
                da.InsertCommand.Parameters.Add("@Profile_Agent", SqlDbType.VarChar).Value = Profile_Agent;
                da.InsertCommand.Parameters.Add("@Profile_Agent_Code", SqlDbType.VarChar).Value = Profile_Agent_Code;
                da.InsertCommand.Parameters.Add("@Profile_Member_Type1", SqlDbType.VarChar).Value = Profile_Member_Type1;
                da.InsertCommand.Parameters.Add("@Profile_Member_Number1", SqlDbType.VarChar).Value = Profile_Member_Number1;
                da.InsertCommand.Parameters.Add("@Profile_Member_Type2", SqlDbType.VarChar).Value = Profile_Member_Type2;
                da.InsertCommand.Parameters.Add("@Profile_Member_Number2", SqlDbType.VarChar).Value = Profile_Member_Number2;
                da.InsertCommand.Parameters.Add("@Profile_Employment_status", SqlDbType.VarChar).Value = Profile_Employment_status;
                da.InsertCommand.Parameters.Add("@Profile_Marital_status", SqlDbType.VarChar).Value = Profile_Marital_status;
                da.InsertCommand.Parameters.Add("@Profile_NOY_Living_as_couple", SqlDbType.VarChar).Value = Profile_NOY_Living_as_couple;
                da.InsertCommand.Parameters.Add("@Office", SqlDbType.VarChar).Value = Office;
                da.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;
                da.InsertCommand.Parameters.Add("@Manager", SqlDbType.VarChar).Value = Manager;
                da.InsertCommand.Parameters.Add("@Photo_identity", SqlDbType.VarChar).Value = Photo_identity;
                da.InsertCommand.Parameters.Add("@Card_Holder", SqlDbType.VarChar).Value = Card_Holder;
                da.InsertCommand.Parameters.Add("@Reception", SqlDbType.VarChar).Value = Reception;
                da.InsertCommand.Parameters.Add("@SubVenue", SqlDbType.VarChar).Value = SubVenue;
                da.InsertCommand.Parameters.Add("@regTerms", SqlDbType.VarChar).Value = regTerms;
                da.InsertCommand.Parameters.Add("@VP_ID", SqlDbType.VarChar).Value = VP_ID;
                da.InsertCommand.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = Company_Name;
                da.InsertCommand.Parameters.Add("@RegTerms2", SqlDbType.VarChar).Value = RegTerms2;
                da.InsertCommand.Parameters.Add("@Secondary_Employment_Status", SqlDbType.VarChar).Value = Secondary_Employment_Status;
                da.InsertCommand.Parameters.Add("@Lead_Source", SqlDbType.VarChar).Value = Lead_Source;
	        	da.InsertCommand.Parameters.Add("@Pre_Arrival", SqlDbType.VarChar).Value = Pre_Arrival;             
                da.InsertCommand.Parameters.Add("@comment2", SqlDbType.VarChar).Value = comment2;
		        da.InsertCommand.Parameters.Add("@Verification", SqlDbType.VarChar).Value = Verification;
	          	da.InsertCommand.Parameters.Add("@Promo_Source", SqlDbType.VarChar).Value = Promo_Source;
		        da.InsertCommand.Parameters.Add("@Tele_agent", SqlDbType.VarChar).Value = Tele_agent;
                da.InsertCommand.Parameters.Add("@subVenueGroup", SqlDbType.VarChar).Value = subVenueGroup;
                da.InsertCommand.Parameters.Add("@leadOffices", SqlDbType.VarChar).Value = leadOffices;
                da.InsertCommand.Parameters.Add("@Sale_Marketing_Source", SqlDbType.VarChar).Value = Sale_Marketing_Source;
                da.InsertCommand.Parameters.Add("@feedbackComment", SqlDbType.VarChar).Value = feedbackComment;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Profile Query " + ex.Message);

                string msg = "Error in Insert Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);

    }
    //public static String GetPrimaryProfileID(string off)
    //{
    //    string PProfileID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    /*if (off == "INDIA")
    //    {
    //        startvalue = "HMC";
    //    }
    //    else //if (off == "BALI")
    //    {
    //        startvalue = "IVO";
    //    }*/
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        //  SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Primary_ID ,6,len(Profile_Primary_ID)))from Profile_Primary", cs1);
    //        //    SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp join profile p on p.Profile_ID = pp.Profile_ID where p.Profile_Venue_Country= @off and  pp.Profile_Primary_ID like 'P_HMC%'", cs1);
    //        if (off == "INDIA"||off=="India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp where  pp.Profile_Primary_ID like 'P_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else 
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp where  pp.Profile_Primary_ID like 'P_IVO%'", cs1);
    //           // scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //            }
    //        }


    //    }

    //    return PProfileID;
    //}
    public static String GetPrimaryProfileID(string startvalue)//(string off)
    {
        string PProfileID = null;
        //string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "P";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Primary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                PProfileID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Primary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                PProfileID = initial + startvalue + year + id;



            }


        }

        return PProfileID;
    }
    public static int InsertPrimaryProfile(string Profile_Primary_ID, string Profile_Primary_Title, string Profile_Primary_Fname, string Profile_Primary_Lname, string Profile_Primary_DOB, string Profile_Primary_Nationality, string Profile_Primary_Country, string Profile_ID, string Primary_Age, string Primary_Designation, string Primary_Language,string PrimaryContID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile_Primary values(@Profile_Primary_ID,	@Profile_Primary_Title,	@Profile_Primary_Fname,	@Profile_Primary_Lname,convert(datetime,@Profile_Primary_DOB,105), @Profile_Primary_Nationality,@Profile_Primary_Country,@Profile_ID,@Primary_Age,@Primary_Designation,@Primary_Language,@Primary_ContactID)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_Primary_ID", SqlDbType.VarChar).Value = Profile_Primary_ID;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Title", SqlDbType.VarChar).Value = Profile_Primary_Title;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Fname", SqlDbType.VarChar).Value = Profile_Primary_Fname;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Lname", SqlDbType.VarChar).Value = Profile_Primary_Lname;
                da.InsertCommand.Parameters.Add("@Profile_Primary_DOB", SqlDbType.VarChar).Value = Profile_Primary_DOB;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Nationality", SqlDbType.VarChar).Value = Profile_Primary_Nationality;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Country", SqlDbType.VarChar).Value = Profile_Primary_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Primary_Age", SqlDbType.VarChar).Value = Primary_Age;
                da.InsertCommand.Parameters.Add("@Primary_Designation", SqlDbType.VarChar).Value = Primary_Designation;
                da.InsertCommand.Parameters.Add("@Primary_Language", SqlDbType.VarChar).Value = Primary_Language;
                da.InsertCommand.Parameters.Add("@Primary_ContactID", SqlDbType.VarChar).Value = PrimaryContID;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Primary Profile Query " + ex.Message);

                string msg = "Error in Insert Primary Profile Query" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }



    public static String GetSecondaryProfileID(string startvalue)//(string off)
    {
        string SProfileID = null;
        //string startvalue = "";
        int id = 0;

        int year = DateTime.Now.Year;
        string initial = "S";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /*  if (off == "INDIA" || off == "India")
              {
                  startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SProfileID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SProfileID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SProfileID;
    }
    public static int InsertSecondaryProfile(string Profile_Secondary_ID, string Profile_Secondary_Title, string Profile_Secondary_Fname, string Profile_Secondary_Lname, string Profile_Secondary_DOB, string Profile_Secondary_Nationality, string Profile_Secondary_Country, string Profile_ID, string Secondary_Age, string Secondary_Designation, string Secondary_Language, string SecondaryContID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Profile_Secondary values(@Profile_Secondary_ID, 	@Profile_Secondary_Title,@Profile_Secondary_Fname,@Profile_Secondary_Lname,convert(datetime,@Profile_Secondary_DOB,105), @Profile_Secondary_Nationality,@Profile_Secondary_Country,@Profile_ID,@Secondary_Age,@Secondary_Designation,@Secondary_Language,@Secondary_ContactID)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_Secondary_ID ", SqlDbType.VarChar).Value = Profile_Secondary_ID;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Title ", SqlDbType.VarChar).Value = Profile_Secondary_Title;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Fname ", SqlDbType.VarChar).Value = Profile_Secondary_Fname;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Lname ", SqlDbType.VarChar).Value = Profile_Secondary_Lname;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_DOB ", SqlDbType.VarChar).Value = Profile_Secondary_DOB;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Nationality ", SqlDbType.VarChar).Value = Profile_Secondary_Nationality;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Country ", SqlDbType.VarChar).Value = Profile_Secondary_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Secondary_Age", SqlDbType.VarChar).Value = Secondary_Age;
                da.InsertCommand.Parameters.Add("@Secondary_Designation", SqlDbType.VarChar).Value = Secondary_Designation;
                da.InsertCommand.Parameters.Add("@Secondary_Language", SqlDbType.VarChar).Value = Secondary_Language;
                da.InsertCommand.Parameters.Add("@Secondary_ContactID", SqlDbType.VarChar).Value = SecondaryContID;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Secondary Profile Query " + ex.Message);

                string msg = "Error in Insert Secondary Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static String GetAddressProfileID(string startvalue)//(string off)
    {
        string AProfileID = null;
        //string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "A";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /*  if (off == "INDIA" || off == "India")
              {
                  startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                AProfileID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                AProfileID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return AProfileID;
    }
    public static int InsertProfileAddress(string Profile_Address_ID, string Profile_Address_Line1, string Profile_Address_Line2, string Profile_Address_State, string Profile_Address_city, string Profile_Address_Postcode, DateTime Profile_Address_Created_Date, string Profile_Address_Expiry_Date, string Profile_ID, string acountry)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile_Address values(@Profile_Address_ID ,	@Profile_Address_Line1,	@Profile_Address_Line2 ,@Profile_Address_State,	@Profile_Address_city, 	@Profile_Address_Postcode ,	@Profile_Address_Created_Date, 	@Profile_Address_Expiry_Date ,@Profile_ID,@acountry)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_Address_ID ", SqlDbType.VarChar).Value = Profile_Address_ID;
                da.InsertCommand.Parameters.Add("@Profile_Address_Line1 ", SqlDbType.VarChar).Value = Profile_Address_Line1;
                da.InsertCommand.Parameters.Add("@Profile_Address_Line2 ", SqlDbType.VarChar).Value = Profile_Address_Line2;
                da.InsertCommand.Parameters.Add("@Profile_Address_State ", SqlDbType.VarChar).Value = Profile_Address_State;
                da.InsertCommand.Parameters.Add("@Profile_Address_city ", SqlDbType.VarChar).Value = Profile_Address_city;
                da.InsertCommand.Parameters.Add("@Profile_Address_Postcode ", SqlDbType.VarChar).Value = Profile_Address_Postcode;
                da.InsertCommand.Parameters.Add("@Profile_Address_Created_Date ", SqlDbType.DateTime).Value = Profile_Address_Created_Date;
                da.InsertCommand.Parameters.Add("@Profile_Address_Expiry_Date ", SqlDbType.VarChar).Value = Profile_Address_Expiry_Date;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@acountry ", SqlDbType.VarChar).Value = acountry;
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Profile Address Query " + ex.Message);
                string msg = "Error in Insert Profile Address Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
            rowsAffected = da.InsertCommand.ExecuteNonQuery();
        }
        return (rowsAffected);
    }




    public static String GetSubProfile1ID(string startvalue)//(string off)
    {
        string SubProfile1ID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP1";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile1ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile1ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SubProfile1ID;
    }





    public static int InsertSub_Profile1(string Sub_Profile1_ID, string Sub_Profile1_Title, string Sub_Profile1_Fname, string Sub_Profile1_Lname, string Sub_Profile1_DOB, string Sub_Profile1_Nationality, string Sub_Profile1_Country, string Profile_ID, string Sub_Profile1_Age,string SP1ContID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Sub_Profile1 values(@Sub_Profile1_ID,@Sub_Profile1_Title ,	@Sub_Profile1_Fname ,	@Sub_Profile1_Lname ,	convert(datetime,@Sub_Profile1_DOB,105) ,	@Sub_Profile1_Nationality ,	@Sub_Profile1_Country,	@Profile_ID,@Sub_Profile1_Age,@Sub_Profile1_ContactID)", cs1);
                da.InsertCommand.Parameters.Add("@Sub_Profile1_ID", SqlDbType.VarChar).Value = Sub_Profile1_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Title", SqlDbType.VarChar).Value = Sub_Profile1_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Fname", SqlDbType.VarChar).Value = Sub_Profile1_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Lname", SqlDbType.VarChar).Value = Sub_Profile1_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_DOB", SqlDbType.VarChar).Value = Sub_Profile1_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Nationality", SqlDbType.VarChar).Value = Sub_Profile1_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Country", SqlDbType.VarChar).Value = Sub_Profile1_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Age", SqlDbType.VarChar).Value = Sub_Profile1_Age;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_ContactID", SqlDbType.VarChar).Value = SP1ContID;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile1 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile1 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    //public static String GetSubProfile2ID(string off)
    //{
    //    string SubProfile2ID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile2_ID  ,8,len(Sub_Profile2_ID)))from Sub_Profile2  where Sub_Profile2_ID like 'SP2_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile2_ID  ,8,len(Sub_Profile2_ID)))from Sub_Profile2  where Sub_Profile2_ID like 'SP2_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //            }

    //        }
    //    }

    //    return SubProfile2ID;
    //}

    public static String GetSubProfile2ID(string startvalue)//(string off)
    {
        string SubProfile2ID = null;
        //  string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP2";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile2ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile2ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SubProfile2ID;
    }
    public static int InsertSub_Profile2(string Sub_Profile2_ID, string Sub_Profile2_Title, string Sub_Profile2_Fname, string Sub_Profile2_Lname, string Sub_Profile2_DOB, string Sub_Profile2_Nationality, string Sub_Profile2_Country, string Profile_ID, string Sub_Profile2_Age,string SP2ContID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile2 values(@Sub_Profile2_ID,@Sub_Profile2_Title ,	@Sub_Profile2_Fname ,	@Sub_Profile2_Lname ,	convert(datetime,@Sub_Profile2_DOB,105) ,	@Sub_Profile2_Nationality ,	@Sub_Profile2_Country,	@Profile_ID,@Sub_Profile2_Age,@Sub_Profile2_ContactID)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile2_ID", SqlDbType.VarChar).Value = Sub_Profile2_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Title", SqlDbType.VarChar).Value = Sub_Profile2_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Fname", SqlDbType.VarChar).Value = Sub_Profile2_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Lname", SqlDbType.VarChar).Value = Sub_Profile2_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_DOB", SqlDbType.VarChar).Value = Sub_Profile2_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Nationality", SqlDbType.VarChar).Value = Sub_Profile2_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Country", SqlDbType.VarChar).Value = Sub_Profile2_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Age", SqlDbType.VarChar).Value = Sub_Profile2_Age;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_ContactID", SqlDbType.VarChar).Value = SP2ContID;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile2 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static String GetSubProfile3ID(string startvalue)//(string off)
    {
        string SubProfile3ID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP3";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile3_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile3ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile3_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile3ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SubProfile3ID;
    }


    public static int InsertSub_Profile3(string Sub_Profile3_ID, string Sub_Profile3_Title, string Sub_Profile3_Fname, string Sub_Profile3_Lname, string Sub_Profile3_DOB, string Sub_Profile3_Nationality, string Sub_Profile3_Country, string Profile_ID, string Sub_Profile3_Age,string SP3ContID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile3 values(@Sub_Profile3_ID,@Sub_Profile3_Title ,	@Sub_Profile3_Fname ,	@Sub_Profile3_Lname ,	convert(datetime,@Sub_Profile3_DOB,105) ,	@Sub_Profile3_Nationality ,	@Sub_Profile3_Country,@Sub_Profile3_Age,@Profile_ID,@Sub_Profile3_ContactID)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile3_ID", SqlDbType.VarChar).Value = Sub_Profile3_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Title", SqlDbType.VarChar).Value = Sub_Profile3_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Fname", SqlDbType.VarChar).Value = Sub_Profile3_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Lname", SqlDbType.VarChar).Value = Sub_Profile3_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_DOB", SqlDbType.VarChar).Value = Sub_Profile3_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Nationality", SqlDbType.VarChar).Value = Sub_Profile3_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Country", SqlDbType.VarChar).Value = Sub_Profile3_Country;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Age", SqlDbType.VarChar).Value = Sub_Profile3_Age;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_ContactID", SqlDbType.VarChar).Value = SP3ContID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile3 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static String GetSubProfile4ID(string startvalue)//(string off)
    {
        string SubProfile4ID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP4";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile4_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile4ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile4_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile4ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SubProfile4ID;
    }


    public static int InsertSub_Profile4(string Sub_Profile4_ID, string Sub_Profile4_Title, string Sub_Profile4_Fname, string Sub_Profile4_Lname, string Sub_Profile4_DOB, string Sub_Profile4_Nationality, string Sub_Profile4_Country, string Profile_ID, string Sub_Profile4_Age,string SP4ContID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile4 values(@Sub_Profile4_ID,@Sub_Profile4_Title ,	@Sub_Profile4_Fname ,	@Sub_Profile4_Lname ,	convert(datetime,@Sub_Profile4_DOB,105) ,	@Sub_Profile4_Nationality ,	@Sub_Profile4_Country,@Sub_Profile4_Age,@Profile_ID,@Sub_Profile4_ContactID)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile4_ID", SqlDbType.VarChar).Value = Sub_Profile4_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Title", SqlDbType.VarChar).Value = Sub_Profile4_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Fname", SqlDbType.VarChar).Value = Sub_Profile4_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Lname", SqlDbType.VarChar).Value = Sub_Profile4_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_DOB", SqlDbType.VarChar).Value = Sub_Profile4_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Nationality", SqlDbType.VarChar).Value = Sub_Profile4_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Country", SqlDbType.VarChar).Value = Sub_Profile4_Country;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Age", SqlDbType.VarChar).Value = Sub_Profile4_Age;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_ContactID", SqlDbType.VarChar).Value = SP4ContID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile4 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    //public static String GetPhoneID(string off)
    //{
    //    string PhoneID = null;
    //    string startvalue = "";
    //    int id = 0;

    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Phone_ID,7,len(Phone_ID)))from Phone where Phone_ID like 'PH_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Phone_ID,7,len(Phone_ID)))from Phone where Phone_ID like 'PH_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //            }

    //        }

    //    }

    //    return PhoneID;
    //}

    public static String GetPhoneID(string startvalue)//(string off)
    {
        string PhoneID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "PH";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                PhoneID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                PhoneID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }

        }

        return PhoneID;
    }




    public static int InsertPhone(string Phone_ID, string Profile_ID, string Primary_CC, string Primary_Mobile, string Primary_Alt_CC, string Primary_Alternate, string Secondary_CC, string Secondary_Mobile, string Secondary_Alt_CC, string Secondary_Alternate, string Subprofile1_CC, string Subprofile1_Mobile, string Subprofile1_Alt_CC, string Subprofile1_Alternate, string Subprofile2_CC, string Subprofile2_Mobile, string Subprofile2_Alt_CC, string Subprofile2_Alternate, string Subprofile3_CC, string Subprofile3_Mobile, string Subprofile4_CC, string Subprofile4_Mobile, string Subprofile3_Alt_CC, string Subprofile3_Alternate, string Subprofile4_Alt_CC, string Subprofile4_Alternate, string Primary_office_cc, string Primary_office_num, string Secondary_office_cc, string Secondary_office_num,string Primary_home_cc,string Primary_home_num,string Secondary_home_cc,string Secondary_home_num)
    {
        int rowsAffected = 0;
        SqlDataAdapter da1 = new SqlDataAdapter();


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da1.InsertCommand = new SqlCommand("insert into Phone values(@Phone_ID,@Profile_ID,@Primary_CC,@Primary_Mobile,@Primary_Alt_CC,@Primary_Alternate,@Secondary_CC, @Secondary_Mobile,@Secondary_Alt_CC,@Secondary_Alternate,@Subprofile1_CC,@Subprofile1_Mobile,@Subprofile1_Alt_CC,@Subprofile1_Alternate,@Subprofile2_CC,@Subprofile2_Mobile,@Subprofile2_Alt_CC,@Subprofile2_Alternate,@Subprofile3_CC,@Subprofile3_Mobile,@Subprofile4_CC,@Subprofile4_Mobile,@Subprofile3_Alt_CC,@Subprofile3_Alternate,@Subprofile4_Alt_CC,@Subprofile4_Alternate,@Primary_office_cc,@Primary_office_num,@Secondary_office_cc,@Secondary_office_num,@Primary_home_cc,@Primary_home_num,@Secondary_home_cc,@Secondary_home_num)", cs1);
                da1.InsertCommand.Parameters.Add("@Phone_ID", SqlDbType.VarChar).Value = Phone_ID;
                da1.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da1.InsertCommand.Parameters.Add("@Primary_CC", SqlDbType.VarChar).Value = Primary_CC;
                da1.InsertCommand.Parameters.Add("@Primary_Mobile", SqlDbType.VarChar).Value = Primary_Mobile;
                da1.InsertCommand.Parameters.Add("@Primary_Alt_CC", SqlDbType.VarChar).Value = Primary_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Primary_Alternate", SqlDbType.VarChar).Value = Primary_Alternate;
                da1.InsertCommand.Parameters.Add("@Secondary_CC", SqlDbType.VarChar).Value = Secondary_CC;
                da1.InsertCommand.Parameters.Add("@Secondary_Mobile", SqlDbType.VarChar).Value = Secondary_Mobile;
                da1.InsertCommand.Parameters.Add("@Secondary_Alt_CC", SqlDbType.VarChar).Value = Secondary_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Secondary_Alternate", SqlDbType.VarChar).Value = Secondary_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile1_CC", SqlDbType.VarChar).Value = Subprofile1_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Mobile", SqlDbType.VarChar).Value = Subprofile1_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Alt_CC", SqlDbType.VarChar).Value = Subprofile1_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Alternate", SqlDbType.VarChar).Value = Subprofile1_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile2_CC", SqlDbType.VarChar).Value = Subprofile2_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Mobile", SqlDbType.VarChar).Value = Subprofile2_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Alt_CC", SqlDbType.VarChar).Value = Subprofile2_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Alternate", SqlDbType.VarChar).Value = Subprofile2_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile3_CC", SqlDbType.VarChar).Value = Subprofile3_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Mobile", SqlDbType.VarChar).Value = Subprofile3_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile4_CC", SqlDbType.VarChar).Value = Subprofile4_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Mobile", SqlDbType.VarChar).Value = Subprofile4_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Alt_CC", SqlDbType.VarChar).Value = Subprofile3_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Alternate", SqlDbType.VarChar).Value = Subprofile3_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Alt_CC", SqlDbType.VarChar).Value = Subprofile4_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Alternate", SqlDbType.VarChar).Value = Subprofile4_Alternate;
                da1.InsertCommand.Parameters.Add("@Primary_office_cc", SqlDbType.VarChar).Value = Primary_office_cc;
                da1.InsertCommand.Parameters.Add("@Primary_office_num", SqlDbType.VarChar).Value = Primary_office_num;
                da1.InsertCommand.Parameters.Add("@Secondary_office_cc", SqlDbType.VarChar).Value = Secondary_office_cc;
                da1.InsertCommand.Parameters.Add("@Secondary_office_num", SqlDbType.VarChar).Value = Secondary_office_num;
                da1.InsertCommand.Parameters.Add("@Primary_home_cc", SqlDbType.VarChar).Value = Primary_home_cc;
                da1.InsertCommand.Parameters.Add("@Primary_home_num", SqlDbType.VarChar).Value = Primary_home_num;
                da1.InsertCommand.Parameters.Add("@Secondary_home_cc", SqlDbType.VarChar).Value = Secondary_home_cc;
                da1.InsertCommand.Parameters.Add("@Secondary_home_num", SqlDbType.VarChar).Value = Secondary_home_num;
                rowsAffected = da1.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Phone Query " + ex.Message);
                string msg = "Error in Insert Phone Query   " + " " + ex.Message;

                throw new Exception(msg, ex);
                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }


        return (rowsAffected);
    }
    //public static String GetEmailID(string off)
    //{
    //    string EmailID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Email_ID ,7,len(Email_ID )))from Email where Email_ID like 'EM_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Email_ID ,7,len(Email_ID )))from Email where Email_ID like 'EM_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //            }
    //        }

    //    }

    //    return EmailID;
    //}
    public static String GetEmailID(string startvalue)//(string off)
    {
        string EmailID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "EM";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                EmailID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                EmailID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }


        return EmailID;
    }
    public static int InsertEmail(string Email_ID, string Profile_ID, string Primary_Email, string Secondary_Email, string Subprofile1_Email, string Subprofile2_Email, string Primary_Email2, string Secondary_Email2, string Subprofile1_Email2, string Subprofile2_Email2, string Subprofile3_Email, string Subprofile3_Email2, string Subprofile4_Email, string Subprofile4_Email2)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Email values(@Email_ID,@Profile_ID,@Primary_Email,@Secondary_Email,@Subprofile1_Email,@Subprofile2_Email,@Primary_Email2,@Secondary_Email2,@Subprofile1_Email2,@Subprofile2_Email2,@Subprofile3_Email,@Subprofile3_Email2,@Subprofile4_Email,@Subprofile4_Email2)", cs2);
                da.InsertCommand.Parameters.Add("@Email_ID ", SqlDbType.VarChar).Value = Email_ID;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Primary_Email ", SqlDbType.VarChar).Value = Primary_Email;
                da.InsertCommand.Parameters.Add("@Secondary_Email ", SqlDbType.VarChar).Value = Secondary_Email;
                da.InsertCommand.Parameters.Add("@Subprofile1_Email ", SqlDbType.VarChar).Value = Subprofile1_Email;
                da.InsertCommand.Parameters.Add("@Subprofile2_Email ", SqlDbType.VarChar).Value = Subprofile2_Email;
                da.InsertCommand.Parameters.Add("@Primary_Email2 ", SqlDbType.VarChar).Value = Primary_Email2;
                da.InsertCommand.Parameters.Add("@Secondary_Email2 ", SqlDbType.VarChar).Value = Secondary_Email2;
                da.InsertCommand.Parameters.Add("@Subprofile1_Email2 ", SqlDbType.VarChar).Value = Subprofile1_Email2;
                da.InsertCommand.Parameters.Add("@Subprofile2_Email2 ", SqlDbType.VarChar).Value = Subprofile2_Email2;
                da.InsertCommand.Parameters.Add("@Subprofile3_Email ", SqlDbType.VarChar).Value = Subprofile3_Email;
                da.InsertCommand.Parameters.Add("@Subprofile3_Email2 ", SqlDbType.VarChar).Value = Subprofile3_Email2;
                da.InsertCommand.Parameters.Add("@Subprofile4_Email ", SqlDbType.VarChar).Value = Subprofile4_Email;
                da.InsertCommand.Parameters.Add("@Subprofile4_Email2 ", SqlDbType.VarChar).Value = Subprofile4_Email2;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Email Query " + ex.Message);

                string msg = "Error in Insert Email Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    //public static String GetStayDetailsID(string off)
    //{
    //    string Profile_Stay_ID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Stay_ID ,7,len(Profile_Stay_ID)))from Profile_Stay where Profile_Stay_ID like 'SD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else

    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Stay_ID  ,7,len(Profile_Stay_ID)))from Profile_Stay where Profile_Stay_ID like 'SD_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //            }
    //        }
    //    }

    //    return Profile_Stay_ID;
    //}
    public static String GetStayDetailsID(string startvalue)//(string off)
    {
        string Profile_Stay_ID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SD";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /*  if (off == "INDIA" || off == "India")
              {
                  startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                Profile_Stay_ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                Profile_Stay_ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return Profile_Stay_ID;
    }
    public static int InsertProfileStay(string Profile_Stay_ID, string Profile_Stay_Resort_Name, string Profile_Stay_Resort_Room_Number, string Profile_Stay_Arrival_Date, string Profile_Stay_Departure_Date, string Profile_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile_Stay values(@Profile_Stay_ID ,	@Profile_Stay_Resort_Name ,	@Profile_Stay_Resort_Room_Number ,	@Profile_Stay_Arrival_Date ,	@Profile_Stay_Departure_Date ,	@Profile_ID)", cs2);
                da.InsertCommand.Parameters.Add("@Profile_Stay_ID ", SqlDbType.VarChar).Value = Profile_Stay_ID;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Resort_Name ", SqlDbType.VarChar).Value = Profile_Stay_Resort_Name;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Resort_Room_Number ", SqlDbType.VarChar).Value = Profile_Stay_Resort_Room_Number;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Arrival_Date ", SqlDbType.VarChar).Value = Profile_Stay_Arrival_Date;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Departure_Date ", SqlDbType.VarChar).Value = Profile_Stay_Departure_Date;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Profile Stay Query " + ex.Message);

                string msg = "Error in Insert Profile Stay Query  " + " " + ex.Message;

                throw new Exception(msg, ex);

                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    //public static String GetTourDetailsID(string off)
    //{
    //    string TourID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Tour_Details_ID,7,len(Tour_Details_ID )))from Tour_Details where Tour_Details_ID like 'TD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Tour_Details_ID,7,len(Tour_Details_ID )))from Tour_Details where Tour_Details_ID like 'TD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //            }
    //        }
    //    }

    //    return TourID;
    //}
    public static String GetTourDetailsID(string startvalue)//(string off)
    {
        string TourID = null;
        //  string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "TD";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                TourID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                TourID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }


        return TourID;
    }

     public static int InsertTourDetails(string Tour_Details_ID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, string Tour_Details_Taxi_In_Price, string Tour_Details_Taxi_In_Ref, string Tour_Details_Taxi_Out_Price, string Tour_Details_Taxi_Out_Ref, string Profile_ID, string Tour_Details_Qualified_Status, int Week_number,string Tour_Start_Time,string Tour_End_Time)
    {
        int rowsAffected = 0;
 	int price1 = int.Parse(Tour_Details_Taxi_In_Price, NumberStyles.Number);
        int price2 = int.Parse(Tour_Details_Taxi_Out_Price, NumberStyles.Number);
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Tour_Details values(@Tour_Details_ID,@Tour_Details_Guest_Status,@Tour_Details_Guest_Sales_Rep,@Tour_Details_Tour_Date,@Tour_Details_Sales_Deck_Check_In,	@Tour_Details_Sales_Deck_Check_Out,@Tour_Details_Taxi_In_Price,@Tour_Details_Taxi_In_Ref ,@Tour_Details_Taxi_Out_Price ,@Tour_Details_Taxi_Out_Ref,@Profile_ID,@Tour_Details_Qualified_Status,@Week_number,@Tour_Start_Time,@Tour_End_Time)", cs2);
                da.InsertCommand.Parameters.Add("@Tour_Details_ID ", SqlDbType.VarChar).Value = Tour_Details_ID;
                da.InsertCommand.Parameters.Add("@Tour_Details_Guest_Status ", SqlDbType.VarChar).Value = Tour_Details_Guest_Status;
                da.InsertCommand.Parameters.Add("@Tour_Details_Guest_Sales_Rep ", SqlDbType.VarChar).Value = Tour_Details_Guest_Sales_Rep;
                da.InsertCommand.Parameters.Add("@Tour_Details_Tour_Date ", SqlDbType.VarChar).Value = Tour_Details_Tour_Date;
                da.InsertCommand.Parameters.Add("@Tour_Details_Sales_Deck_Check_In ", SqlDbType.VarChar).Value = Tour_Details_Sales_Deck_Check_In;
                da.InsertCommand.Parameters.Add("@Tour_Details_Sales_Deck_Check_Out ", SqlDbType.VarChar).Value = Tour_Details_Sales_Deck_Check_Out;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_In_Price ", SqlDbType.VarChar).Value = price1;// Tour_Details_Taxi_In_Price;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_In_Ref ", SqlDbType.VarChar).Value = Tour_Details_Taxi_In_Ref;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_Out_Price ", SqlDbType.VarChar).Value =price2;// Tour_Details_Taxi_Out_Price;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_Out_Ref ", SqlDbType.VarChar).Value = Tour_Details_Taxi_Out_Ref;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Tour_Details_Qualified_Status", SqlDbType.VarChar).Value = Tour_Details_Qualified_Status;
                da.InsertCommand.Parameters.Add("@Week_number", SqlDbType.Int).Value = Week_number;
                da.InsertCommand.Parameters.Add("@Tour_Start_Time", SqlDbType.VarChar).Value = Tour_Start_Time;
                da.InsertCommand.Parameters.Add("@Tour_End_Time", SqlDbType.VarChar).Value = Tour_End_Time;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Tour Details Query " + ex.Message);

                string msg = "Error in Insert Tour Details Query" + " " + ex.Message;

                throw new Exception("transction: " + msg, ex);


            }
        }
        return (rowsAffected);
    }

    public static String GetCountryCodeValue(string name, string code)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand scd = new SqlCommand(" select country_id from country where country_name =@name and country_code =@code", cs1);
            SqlCommand scd = new SqlCommand(" select country_code from country where country_name =@name and country_code =@code", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            scd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static void ProfileView(string ID)
    {
        System.Web.HttpContext.Current.Response.Write("<script>window.open('Guest REg form india.rpt?value=" + ID + " ', 'newwindow','location=no,menubar=no,width=800,height=1000,resizable=yes,scrollbars=yes,top=250,left=200')</script>");

    }

    public static DataSet LoadProfileOnCreation(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select *, pp.Profile_Primary_Title, pp.Profile_Primary_Fname, pp.Profile_Primary_Lname, CONVERT (date, pp.Profile_Primary_DOB)dob, pp.Profile_Primary_Nationality, pp.Profile_Primary_Country, pa.Profile_Address_city, pa.Profile_Address_State, ph.Primary_Mobile, em.Primary_Email, s.Profile_Stay_Resort_Name, CONVERT (date,s.Profile_Stay_Arrival_Date)arrivaldate, CONVERT (date,s.Profile_Stay_Departure_Date) DepartureDate, ps.Profile_Secondary_Title, ps.Profile_Secondary_Fname, ps.Profile_Secondary_Lname, ps.Profile_Secondary_Nationality from Profile p left   join Profile_Primary pp on pp.Profile_ID = p.Profile_ID left   join Profile_Secondary ps on ps.Profile_ID = pp.Profile_ID  left outer join Phone ph on ph.Profile_ID = p.Profile_ID left outer join Email em on em.Profile_ID = p.Profile_ID left outer join Profile_Address pa on pa.Profile_ID = p.Profile_ID left outer join Profile_Stay s on s.Profile_ID = p.Profile_ID  left join Tour_Details td on td.Profile_ID=p.Profile_ID where p.Profile_ID =@profileid", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadEntitlement()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Entitlement_Name  from Entitlement where Entitlement_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    //public static DataSet LoadSearchProfile(string profileid,string office)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        //SqlCommand SqlCmd = new SqlCommand("select Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname from Profile_Primary where Profile_ID=@profileid", cs1);
    //        //SqlCommand SqlCmd = new SqlCommand("	 select pp.Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  where pp.Profile_ID=@profileid  and p.office=@office", cs1);
    //        SqlCommand SqlCmd = new SqlCommand("select pp.Profile_ID,pp.Profile_Primary_Title,pp.Profile_Primary_Fname,pp.Profile_Primary_Lname  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  where p.office=@office and(pp.Profile_ID = @profileid or pp.Profile_Primary_Fname like '%"+ profileid + "%')", cs1);
    //        //p.office = 'ivo' and(pp.Profile_ID = '' or pp.Profile_Primary_Fname like '%anket%')
    //        SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
    //        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);

    //    }
    //    return (ds);
    //}
    public static DataSet LoadPayMethod()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select pay_method_name from pay_method", cs1);

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSalesReps(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID=@venuecountry", cs1);//("select * from Sales_Rep where Venue_country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuec)", cs1);
            SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where office=@office and Sales_Rep_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadVenueCountry1(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Country_Name from VenueCountry where Venue_Country_Name not in(select Profile_Venue_Country  from Profile where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


   public static DataSet LoadLeadOffice()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from LeadSourceOffice where status='Active'", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadVenue1(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name  from Venue where Venue_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static int ProfileExists(string profile)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select Profile_ID  from Profile  where Profile_ID =@profile", cs1);
            scd.Parameters.Add("@profile", SqlDbType.VarChar).Value = profile;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }

    public static int UserExists(string uname)
    {
        int user, ch;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqcmd = new SqlCommand("select count(*) from users where username=@uname and userstatus='Active'", cs1);
            sqcmd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            ch = (int)sqcmd.ExecuteScalar();
            if (ch == 1)
            {
                user = 1;
            }
            else
            {
                user = 0;
            }
        }
        return user;
    }
    public static string PswdCheck(string uname)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select password from users where username=@uname", cs1);
            scd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
    public static string GetGroupID(string uname)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select[Group Id] from users where username= @uname", cs1);
            scd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
    public static string GetTitle(string uname)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Title from users where username= @uname", cs1);
            scd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
    public static DataSet LoadUserGroupAccess(string id, string title)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select* from user_group_access where[Group Id]=@id   and title=@title", cs1);
            SqlCmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            SqlCmd.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static String GetCountryCode(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand scd = new SqlCommand(" select country_id from country where country_name =@name and country_code =@code", cs1);
            SqlCommand scd = new SqlCommand(" select country_code from country where country_name =@name", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static string GetOffice(string uname)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select office from users where username= @uname", cs1);
            scd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
    public static int GetAccessValue(string id, string title, string name)
    {
        int val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select PageName  from user_group_access where[Group Id] =@id   and title =@title and Name =@name  and([read] = 1 or[modify] = 1 or[delete] = 1 or[write] = 1 or[report] = 1)", cs1);
            scd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            scd.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            val = (int)scd.ExecuteScalar();

        }
        return val;
    }

    public static DataSet LoadSearchProfileName(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname from Profile_Primary where Profile_ID=@profileid", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    /*public static DataSet LoadSearchProfile(string profileid,string office)
  {
      SqlDataAdapter da;
      DataSet ds = new DataSet();
      using (SqlConnection cs1 = Queries.GetDBConnection())
      {
          //SqlCommand SqlCmd = new SqlCommand("select Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname from Profile_Primary where Profile_ID=@profileid", cs1);
          //SqlCommand SqlCmd = new SqlCommand("  select pp.Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  where pp.Profile_ID=@profileid  and p.office=@office", cs1);
          // SqlCommand SqlCmd = new SqlCommand("select pp.Profile_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  where p.office=@office and(pp.Profile_ID = @profileid or pp.Profile_Primary_Fname like '%"+ profileid + "%')", cs1);
          SqlCommand SqlCmd = new SqlCommand("select pp.Profile_ID,Profile_Primary_Title as Title,Profile_Primary_Fname+' '+Profile_Primary_Lname as Name,e.Primary_Email as Email,q.Primary_Mobile as Mobile,td.Tour_Details_Tour_Date as [Tour Date]  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  join Email e on e.Profile_ID =pp.Profile_ID join Phone q on q.Profile_ID =pp.Profile_ID join Tour_Details td on p.Profile_ID = td.Profile_ID where p.office=@office and(pp.Profile_ID = @profileid or pp.Profile_Primary_Fname like '%" + profileid + "%' or pp.Profile_Primary_Lname like '%" + profileid + "%' or e.Primary_Email like '%" + profileid + "%' or q.Primary_Mobile like '%" + profileid + "%')", cs1);

          //p.office = 'ivo' and(pp.Profile_ID = '' or pp.Profile_Primary_Fname like '%anket%')
          SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
          SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

          da = new SqlDataAdapter(SqlCmd);
          ds = new DataSet();
          da.Fill(ds);

      }
      return (ds);
  }*/

    public static DataSet LoadSearchProfile(string profileid, string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand SqlCmd = new SqlCommand("select Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname from Profile_Primary where Profile_ID=@profileid", cs1);
            //SqlCommand SqlCmd = new SqlCommand("  select pp.Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  where pp.Profile_ID=@profileid  and p.office=@office", cs1);
            // SqlCommand SqlCmd = new SqlCommand("select pp.Profile_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  where p.office=@office and(pp.Profile_ID = @profileid or pp.Profile_Primary_Fname like '%"+ profileid + "%')", cs1);
            SqlCommand SqlCmd = new SqlCommand("select pp.Profile_ID,pp.Profile_Primary_Title as Title,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as Name,e.Primary_Email as Email,q.Primary_Mobile as Mobile, REPLACE(ISNULL(CONVERT(varchar, td.Tour_Details_Tour_Date,105), ''), '01-01-1900', '') as [Tour Date],td.Tour_Details_ID as Tour_Id   from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  join Email e on e.Profile_ID =pp.Profile_ID join Phone q on q.Profile_ID =pp.Profile_ID join Tour_Details td on p.Profile_ID = td.Profile_ID where p.office=@office and(pp.Profile_ID = @profileid or pp.Profile_Primary_Fname like '%" + profileid + "%' or pp.Profile_Primary_Lname like '%" + profileid + "%' or e.Primary_Email like '%" + profileid + "%' or q.Primary_Mobile like '%" + profileid + "%')", cs1);

            //p.office = 'ivo' and(pp.Profile_ID = '' or pp.Profile_Primary_Fname like '%anket%')
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadTOManager(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select TO_Manager_Name  from TO_Manager where office=@office and TO_Manager_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadTOManagerOnVenue(string office, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select TO_Manager_Name  from TO_Manager where office=@office and TO_Manager_Status='Active' and venue=@venue ORDER BY 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadButtonUp(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select ButtonUp_Name  from ButtonUp  where office=@office and ButtonUp_Status='Active' ORDER BY 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadButtonUpOnVenue(string office, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select ButtonUp_Name  from ButtonUp  where office=@office and ButtonUp_Status='Active' and venue=@venue ORDER BY 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadFinanceOffice(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Finance_Currency_Name  from Finance_Office  where office=@office and Status='Active'", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
 public static DataSet LoadProfielDetailsFull(string profile)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select* from Profile p left join Profile_Primary pp on pp.Profile_ID = p.Profile_ID left join Profile_Secondary ps on ps.Profile_ID = p.Profile_ID left join Sub_Profile1 sp1 on sp1.Profile_ID = p.Profile_ID left join Sub_Profile2   sp2 on sp2.Profile_ID = p.Profile_ID left join Sub_Profile3 sp3 on sp3.Profile_ID = p.Profile_ID left join Sub_Profile4   sp4 on sp4.Profile_ID = p.Profile_ID left join Profile_Stay  sp on sp.Profile_ID = p.Profile_ID left join Tour_Details  td on td.Profile_ID = p.Profile_ID left join Phone ph on ph.Profile_ID=p.Profile_ID left join Email em on em.Profile_ID =p.Profile_ID left join Contract_Correspondence_Address cord on cord.Profile_ID=p.Profile_ID left join Profile_Address pa on pa.Profile_ID =p.Profile_ID left join Identity_Proof_Details ipd on ipd.Profile_ID =p.Profile_ID  where p.Profile_ID =@profile  ", cs1);
            SqlCmd.Parameters.Add("@profile", SqlDbType.VarChar).Value = profile;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadProfileVenueCountry(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Country_Name from VenueCountry where Venue_Country_Status='active' and  Venue_Country_Name not in(select Profile_Venue_Country  from Profile where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    //public static DataSet LoadProfileVenue (string ProfileID)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        SqlCommand SqlCmd = new SqlCommand(" select distinct Venue_Name from Venue where Venue_Status='active' and Venue_Name  not in(select Profile_Venue   from Profile where Profile_ID=@ProfileID) ", cs1);
    //        SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}

    public static DataSet LoadProfileVenue(string ProfileID, string country)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //SqlCommand SqlCmd = new SqlCommand(" select distinct Venue_Name from Venue where Venue_Status='active' and Venue_Name  not in(select Profile_Venue   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand("  select distinct Venue_Name from Venue join VenueCountry vc on vc.Venue_Country_ID = venue.Venue_Country_ID where Venue_Status = 'active' and Venue_Name    not in(select Profile_Venue   from Profile where Profile_ID = @ProfileID)and vc.Venue_Country_Name =@country ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    //public static DataSet LoadProfileVenueGroup(string ProfileID)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Group_Name  from Venue_Group  where Venue_Group_Status='active' and Venue_Group_Name  not in(select Profile_Group_Venue    from Profile where Profile_ID=@ProfileID) ", cs1);
    //        SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}

    public static DataSet LoadProfileVenueGroup(string ProfileID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Group_Name  from Venue_Group  where Venue_Group_Status='active' and Venue_Group_Name  not in(select Profile_Group_Venue    from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Group_Name  from Venue_Group vg join venue v on v.Venue_ID = vg.Venue_ID where vg.Venue_Group_Status = 'active' and vg.Venue_Group_Name  not in(select Profile_Group_Venue    from Profile where Profile_ID =@ProfileID) and v.Venue_Name =@venue ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    //public static DataSet LoadProfileMktg(string ProfileID)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        SqlCommand SqlCmd = new SqlCommand(" select distinct Marketing_Program_Name   from Marketing_Program   where Marketing_Program_Status ='active' and Marketing_Program_Name  not in(select Profile_Marketing_Program   from Profile where Profile_ID=@ProfileID) ", cs1);
    //        SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}


    public static DataSet LoadProfileMktg(string ProfileID, string venue, string venuegrp)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand(" select distinct Marketing_Program_Name   from Marketing_Program   where Marketing_Program_Status ='active' and Marketing_Program_Name  not in(select Profile_Marketing_Program   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand("select distinct Marketing_Program_Name   from Marketing_Program join Venue_Group vg on vg.Venue_group_ID = Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID = @ProfileID) and vg.Venue_Group_Name = @venuegrp and v.Venue_Name =@venue ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadProfileAgent(string ProfileID)//,string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct Agent_Name    from Agent    where Agent_Status  ='active' and Agent_Name  not in(select Profile_Agent   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            //   SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
//------////
    public static DataSet LoadProfileAgent1(string ProfileID,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select a.Agent_Name from   agent a   where   a.Agent_Status = 'Active' and Agent_Name not in (select Profile_Agent  from Profile where Profile_ID=@ProfileID) and a.Agent_office =@office order by 1", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    //-/////
    public static DataSet LoadProfileAgentNotColdline(string ProfileID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select Sales_Rep_Name from Sales_Rep where Sales_Rep_Status = 'Active' and venue =@venue and Sales_Rep_Name not in (select Profile_Agent  from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadTOOPCOnVenue11(string profile_ID, string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select distinct to_name from OPC_TOs where TO_Status='Active' and  to_name not in(select Profile_Agent_Code from Profile where Profile_ID =@profile_ID) and office=@office order by 1", cs1);
            SqlCmd.Parameters.Add("@profile_ID", SqlDbType.VarChar).Value = profile_ID;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadTOOPCOnVenue12(string profile_ID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select distinct TO_Manager_Name from TO_Manager where TO_Manager_Status = 'Active' and TO_Manager_Name not in(select Profile_Agent_Code from Profile where Profile_ID =@Profile_ID) and Venue =@venue order by 1", cs1);
            SqlCmd.Parameters.Add("@profile_ID", SqlDbType.VarChar).Value = profile_ID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadProfileMemberType(string profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select distinct Member_Type_Name from Member_Type where Member_Type_Status='Active' and Member_Type_Name not in(select Profile_Member_Type1 from Profile where Profile_ID =@Profile_ID)", cs1);
            SqlCmd.Parameters.Add("@profile_ID", SqlDbType.VarChar).Value = profile_ID;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadProfileType(string profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select distinct Type_Name from Type  where Type_Status='Active' and Type_Name not in(select Profile_Member_Number1 from Profile where Profile_ID =@Profile_ID)", cs1);
            SqlCmd.Parameters.Add("@profile_ID", SqlDbType.VarChar).Value = profile_ID;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }



    public static DataSet LoadProfileManager(string ProfileID, string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select distinct Manager_Name from Managers where Manager_Status = 'Active' and Office =@office and Manager_Name not in(select manager  from Profile where Profile_ID =@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                SqlCommand SqlCmd1 = new SqlCommand(" select distinct Manager_Name from Managers where Manager_Status = 'Active' and Office =@office  ", cs1);
                SqlCmd1.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                SqlCmd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                da = new SqlDataAdapter(SqlCmd1);
                ds = new DataSet();
                da.Fill(ds);

            }

            return (ds);
        }

    }
    public static DataSet LoadProfileEmployment(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("   select Name from EmploymentStatus where status = 'Active' and name not in (select Profile_Employment_status from profile where Profile_ID = @ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }





    public static DataSet LoadProfileAgentCode(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select distinct Agent_Code_Name    from Agent_Code     where Agent_Code_Status  ='active' and Agent_Code_Name  not in(select Profile_Agent_Code   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadProfileTOName(string ProfileID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct TO_Manager_Name from TO_Manager where TO_Manager_Status  ='active' and TO_Manager_Name  not in(select Profile_Agent_Code from Profile where Profile_ID =@ProfileID) and venue =@venue ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryPrimary(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("	 select distinct country_name   from country where country_name not in(select Profile_Primary_Country  from Profile_Primary where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountrySecondary(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct ' ' as  country_name UNION select Country_Name  from country where country_name not in(select Profile_Secondary_Country  from Profile_Secondary where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountrySP1(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct ' ' as  country_name UNION select Country_Name   from country where country_name not in(select Sub_Profile1_Country  from Sub_Profile1 where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountrySP2(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct ' ' as  country_name UNION select Country_Name   from country where country_name not in(select Sub_Profile2_Country  from Sub_Profile2 where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodePrimaryMobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Primary_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodePrimaryAlt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
           //  SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Primary_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSecondaryMobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             // SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Secondary_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSecondaryAlt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Secondary_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountryWithCodeSP1Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //   SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile1_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSP1Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
           
           // SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile1_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSP2Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //   SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile2_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSP2Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile2_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }




    public static int UpdateProfile(string ProfileID, string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple, string manager, string Photo_identity, string Card_Holder, string Comments, string reception, string SubVenue, string regTerms, string vp_ID,string comment2, string subVenueGroup, string LeadOffice)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Profile  SET Profile_Venue_Country= '" + Profile_Venue_Country + "',	Profile_Venue= '" + Profile_Venue + "',	Profile_Group_Venue= '" + Profile_Group_Venue + "',	Profile_Marketing_Program= '" + Profile_Marketing_Program + "',	Profile_Agent= '" + Profile_Agent + "',	Profile_Agent_Code= '" + Profile_Agent_Code + "',	Profile_Member_Type1= '" + Profile_Member_Type1 + "',	Profile_Member_Number1= '" + Profile_Member_Number1 + "',	Profile_Member_Type2= '" + Profile_Member_Type2 + "',	Profile_Member_Number2= '" + Profile_Member_Number2 + "',	Profile_Employment_status= '" + Profile_Employment_status + "',	Profile_Marital_status= '" + Profile_Marital_status + "',	Profile_NOY_Living_as_couple= '" + Profile_NOY_Living_as_couple + "',	manager= '" + manager + "',	Photo_identity= '" + Photo_identity + "',	Card_Holder= '" + Card_Holder + "',Comments='" + Comments + "',Reception='" + reception + "', SubVenue='" + SubVenue + "',RegTerms='" + regTerms + "',comment2='"+comment2+ "',Sub_Venue_Group='" + subVenueGroup + "',leadOffice='" + LeadOffice + "' where Profile_ID ='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }




    public static int UpdateProfilePrimary(string ProfileID, string Profile_Primary_Title, string Profile_Primary_Fname, string Profile_Primary_Lname, string Profile_Primary_DOB, string Profile_Primary_Nationality, string Profile_Primary_Country, string Primary_Age, string Primary_Designation, string Primary_Language)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Primary SET  Profile_Primary_Title='" + Profile_Primary_Title + "',Profile_Primary_Fname='" + Profile_Primary_Fname + "',Profile_Primary_Lname='" + Profile_Primary_Lname + "',Profile_Primary_DOB= convert(datetime,'" + Profile_Primary_DOB + "',105),Profile_Primary_Nationality='" + Profile_Primary_Nationality + "',Profile_Primary_Country='" + Profile_Primary_Country + "',Primary_Age='" + Primary_Age + "',Primary_Designation='" + Primary_Designation + "',Primary_Language='" + Primary_Language + "'where Profile_ID='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Profile_Primary Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Primary Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }




    public static int UpdateProfileSecondary(string ProfileID, string Profile_Secondary_Title, string Profile_Secondary_Fname, string Profile_Secondary_Lname, string Profile_Secondary_DOB, string Profile_Secondary_Nationality, string Profile_Secondary_Country, string Secondary_Age, string Secondary_Designation, string Secondary_Language)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Secondary SET  Profile_Secondary_Title='" + Profile_Secondary_Title + "',Profile_Secondary_Fname='" + Profile_Secondary_Fname + "',Profile_Secondary_Lname='" + Profile_Secondary_Lname + "',Profile_Secondary_DOB= convert(datetime,'" + Profile_Secondary_DOB + "',105),Profile_Secondary_Nationality='" + Profile_Secondary_Nationality + "',Profile_Secondary_Country='" + Profile_Secondary_Country + "',Secondary_Age='" + Secondary_Age + "',Secondary_Designation='" + Secondary_Designation + "',Secondary_Language='" + Secondary_Language + "'where Profile_ID='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Profile_Secondary Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Secondary Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }



    public static int UpdateSubProfile1(string ProfileID, string Sub_Profile1_Title, string Sub_Profile1_Fname, string Sub_Profile1_Lname, string Sub_Profile1_DOB, string Sub_Profile1_Nationality, string Sub_Profile1_Country, string Sub_Profile1_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Sub_Profile1 SET  Sub_Profile1_Title='" + Sub_Profile1_Title + "',Sub_Profile1_Fname='" + Sub_Profile1_Fname + "',Sub_Profile1_Lname='" + Sub_Profile1_Lname + "',Sub_Profile1_DOB= convert(datetime,'" + Sub_Profile1_DOB + "',105),Sub_Profile1_Nationality='" + Sub_Profile1_Nationality + "',Sub_Profile1_Country='" + Sub_Profile1_Country + "',Sub_Profile1_Age='" + Sub_Profile1_Age + "'where Profile_ID='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile1 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile1 Query  " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }



    public static int UpdateSubProfile2(string ProfileID, string Sub_Profile2_Title, string Sub_Profile2_Fname, string Sub_Profile2_Lname, string Sub_Profile2_DOB, string Sub_Profile2_Nationality, string Sub_Profile2_Country, string Sub_Profile2_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Sub_Profile2 SET  Sub_Profile2_Title='" + Sub_Profile2_Title + "',Sub_Profile2_Fname='" + Sub_Profile2_Fname + "',Sub_Profile2_Lname='" + Sub_Profile2_Lname + "', Sub_Profile2_DOB= convert(datetime,'" + Sub_Profile2_DOB + "',105),Sub_Profile2_Nationality='" + Sub_Profile2_Nationality + "',Sub_Profile2_Country='" + Sub_Profile2_Country + "',Sub_Profile2_Age='" + Sub_Profile2_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile2 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateSubProfile3(string ProfileID, string Sub_Profile3_Title, string Sub_Profile3_Fname, string Sub_Profile3_Lname, string Sub_Profile3_DOB, string Sub_Profile3_Nationality, string Sub_Profile3_Country, string Sub_Profile3_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Sub_Profile3 SET  Sub_Profile3_Title='" + Sub_Profile3_Title + "',Sub_Profile3_Fname='" + Sub_Profile3_Fname + "',Sub_Profile3_Lname='" + Sub_Profile3_Lname + "',Sub_Profile3_DOB= convert(datetime,'" + Sub_Profile3_DOB + "',105),Sub_Profile3_Nationality='" + Sub_Profile3_Nationality + "',Sub_Profile3_Country='" + Sub_Profile3_Country + "',Sub_Profile3_Age='" + Sub_Profile3_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile3 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateSubProfile4(string ProfileID, string Sub_Profile4_Title, string Sub_Profile4_Fname, string Sub_Profile4_Lname, string Sub_Profile4_DOB, string Sub_Profile4_Nationality, string Sub_Profile4_Country, string Sub_Profile4_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Sub_Profile4 SET  Sub_Profile4_Title='" + Sub_Profile4_Title + "',Sub_Profile4_Fname='" + Sub_Profile4_Fname + "',Sub_Profile4_Lname='" + Sub_Profile4_Lname + "',Sub_Profile4_DOB= convert(datetime,'" + Sub_Profile4_DOB + "',105),Sub_Profile4_Nationality='" + Sub_Profile4_Nationality + "',Sub_Profile4_Country='" + Sub_Profile4_Country + "',Sub_Profile4_Age='" + Sub_Profile4_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile4 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateProfileAddress(string ProfileID, string Profile_Address_Line1, string Profile_Address_Line2, string Profile_Address_State, string Profile_Address_city, string Profile_Address_Postcode, string acountry)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Address SET  Profile_Address_Line1='" + Profile_Address_Line1 + "',Profile_Address_Line2='" + Profile_Address_Line2 + "',Profile_Address_State='" + Profile_Address_State + "',Profile_Address_city='" + Profile_Address_city + "',Profile_Address_Postcode='" + Profile_Address_Postcode + "',Profile_Address_Country='" + acountry + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile_Address Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Address Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    public static int UpdateProfileAddressCorres(string ProfileID, string Address_Line1, string Address_Line2, string Address_State, string Address_city, string Address_Postcode, string Address_country)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Contract_Correspondence_Address  SET  Address_Line1 ='" + Address_Line1 + "',Address_Line2='" + Address_Line2 + "',Address_State='" + Address_State + "',Address_city='" + Address_city + "',Address_Postcode='" + Address_Postcode + "',Address_Country='" + Address_country + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile_Address Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Address Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }



    /*  public static int UpdatePhone(string ProfileID, string Primary_CC, string Primary_Mobile, string Primary_Alt_CC, string Primary_Alternate, string Secondary_CC, string Secondary_Mobile, string Secondary_Alt_CC, string Secondary_Alternate, string Subprofile1_CC, string Subprofile1_Mobile, string Subprofile1_Alt_CC, string Subprofile1_Alternate, string Subprofile2_CC, string Subprofile2_Mobile, string Subprofile2_Alt_CC, string Subprofile2_Alternate, string Subprofile3_CC, string Subprofile3_Mobile, string Subprofile4_CC, string Subprofile4_Mobile, string Subprofile3_Alt_CC, string Subprofile3_Alternate, string Subprofile4_Alt_CC, string Subprofile4_Alternate)
      {
          int rowsaffected = 0;
          using (SqlConnection cs2 = Queries.GetDBConnection())                       

          {
              try
              {

                  SqlCommand scd = new SqlCommand("update Phone SET Primary_CC= '" + Primary_CC + "',Primary_Mobile='" + Primary_Mobile + "',	Primary_Alt_CC='" + Primary_Alt_CC + "',	Primary_Alternate='" + Primary_Alternate + "',	Secondary_CC='" + Secondary_CC + "',	Secondary_Mobile='" + Secondary_Mobile + "',	Secondary_Alt_CC='" + Secondary_Alt_CC + "',	Secondary_Alternate='" + Secondary_Alternate + "',	Subprofile1_CC='" + Subprofile1_CC + "',	Subprofile1_Mobile='" + Subprofile1_Mobile + "',	Subprofile1_Alt_CC='" + Subprofile1_Alt_CC + "',	Subprofile1_Alternate='" + Subprofile1_Alternate + "',	Subprofile2_CC='" + Subprofile2_CC + "',	Subprofile2_Mobile='" + Subprofile2_Mobile + "',	Subprofile2_Alt_CC='" + Subprofile2_Alt_CC + "',	Subprofile2_Alternate='" + Subprofile2_Alternate + "',	Subprofile3_CC='" + Subprofile3_CC + "',	Subprofile3_Mobile='" + Subprofile3_Mobile + "',	Subprofile3_Alt_CC='" + Subprofile3_Alt_CC + "',	Subprofile3_Alternate='" + Subprofile3_Alternate + "',	Subprofile4_CC='" + Subprofile4_CC + "',	Subprofile4_Mobile='" + Subprofile4_Mobile + "',	Subprofile4_Alt_CC='" + Subprofile4_Alt_CC + "',	Subprofile4_Alternate='" + Subprofile4_Alternate + "'  where Profile_ID ='" + ProfileID + "'", cs2);
                  scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                  rowsaffected = scd.ExecuteNonQuery();
              }
              catch (Exception ex)
              {

                 // MessageBox.Show("Error in UPDATE Phone Query " + ex.Message);
                  string msg = "Error in UPDATE Phone Query" + " " + ex.Message;

                  throw new Exception(msg, ex);

                  // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
              }
          }
          return (rowsaffected);
      }*/
  public static int UpdatePhone(string ProfileID, string Primary_CC, string Primary_Mobile, string Primary_Alt_CC, string Primary_Alternate, string Secondary_CC, string Secondary_Mobile, string Secondary_Alt_CC, string Secondary_Alternate, string Subprofile1_CC, string Subprofile1_Mobile, string Subprofile1_Alt_CC, string Subprofile1_Alternate, string Subprofile2_CC, string Subprofile2_Mobile, string Subprofile2_Alt_CC, string Subprofile2_Alternate, string Subprofile3_CC, string Subprofile3_Mobile, string Subprofile4_CC, string Subprofile4_Mobile, string Subprofile3_Alt_CC, string Subprofile3_Alternate, string Subprofile4_Alt_CC, string Subprofile4_Alternate, string priOfficecc, string priOfficeno, string secOfficecc, string secOfficeno,string primaryHomecc,string primaryHomeno,string secondaryHomecc,string secondaryHomeno)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {
            try
            {

                SqlCommand scd = new SqlCommand("update Phone SET Primary_CC= '" + Primary_CC + "',Primary_Mobile='" + Primary_Mobile + "',	Primary_Alt_CC='" + Primary_Alt_CC + "',	Primary_Alternate='" + Primary_Alternate + "',	Secondary_CC='" + Secondary_CC + "',	Secondary_Mobile='" + Secondary_Mobile + "',	Secondary_Alt_CC='" + Secondary_Alt_CC + "',	Secondary_Alternate='" + Secondary_Alternate + "',	Subprofile1_CC='" + Subprofile1_CC + "',	Subprofile1_Mobile='" + Subprofile1_Mobile + "',	Subprofile1_Alt_CC='" + Subprofile1_Alt_CC + "',	Subprofile1_Alternate='" + Subprofile1_Alternate + "',	Subprofile2_CC='" + Subprofile2_CC + "',	Subprofile2_Mobile='" + Subprofile2_Mobile + "',	Subprofile2_Alt_CC='" + Subprofile2_Alt_CC + "',	Subprofile2_Alternate='" + Subprofile2_Alternate + "',	Subprofile3_CC='" + Subprofile3_CC + "',	Subprofile3_Mobile='" + Subprofile3_Mobile + "',	Subprofile3_Alt_CC='" + Subprofile3_Alt_CC + "',	Subprofile3_Alternate='" + Subprofile3_Alternate + "',	Subprofile4_CC='" + Subprofile4_CC + "',	Subprofile4_Mobile='" + Subprofile4_Mobile + "',	Subprofile4_Alt_CC='" + Subprofile4_Alt_CC + "',	Subprofile4_Alternate='" + Subprofile4_Alternate + "',Primary_office_cc='" + priOfficecc + "',Primary_office_num='" + priOfficeno + "',Secondary_office_cc='" + secOfficecc + "',Secondary_office_num='" + secOfficeno + "',Primary_home_cc='"+primaryHomecc+"',Primary_home_num='"+primaryHomeno+"',Secondary_home_cc='"+secondaryHomecc+"',Secondary_home_num='"+secondaryHomeno+"'  where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Phone Query " + ex.Message);
                string msg = "Error in UPDATE Phone Query" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }




    public static int UpdateEmail(string ProfileID, string Primary_Email, string Secondary_Email, string Subprofile1_Email, string Subprofile2_Email, string Primary_Email2, string Secondary_Email2, string Subprofile1_Email2, string Subprofile2_Email2, string Subprofile3_Email, string Subprofile3_Email2, string Subprofile4_Email, string Subprofile4_Email2)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {
                SqlCommand scd = new SqlCommand("update Email SET Primary_Email= '" + Primary_Email + "',	Secondary_Email= '" + Secondary_Email + "',	Subprofile1_Email= '" + Subprofile1_Email + "',	Subprofile2_Email= '" + Subprofile2_Email + "', Primary_Email2= '" + Primary_Email2 + "',	Secondary_Email2= '" + Secondary_Email2 + "',	Subprofile1_Email2= '" + Subprofile1_Email2 + "',	Subprofile2_Email2= '" + Subprofile2_Email2 + "',	Subprofile3_Email= '" + Subprofile3_Email + "',	Subprofile3_Email2= '" + Subprofile3_Email2 + "',	Subprofile4_Email= '" + Subprofile4_Email + "',	Subprofile4_Email2= '" + Subprofile4_Email2 + "' where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Email Query " + ex.Message);

                string msg = "Error in UPDATE Email Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateProfileStay(string ProfileID, string Profile_Stay_Resort_Name, string Profile_Stay_Resort_Room_Number, string Profile_Stay_Arrival_Date, string Profile_Stay_Departure_Date)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Stay SET  Profile_Stay_Resort_Name= '" + Profile_Stay_Resort_Name + "',Profile_Stay_Resort_Room_Number = '" + Profile_Stay_Resort_Room_Number + "',Profile_Stay_Arrival_Date= convert(datetime,'" + Profile_Stay_Arrival_Date + "',105),Profile_Stay_Departure_Date =convert(datetime, '" + Profile_Stay_Departure_Date + "',105) where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile_Stay Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                string msg = "Error in UPDATE Profile_Stay Query " + " " + ex.Message;

                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateTourDetails(string ProfileID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, string Tour_Details_Taxi_In_Price, string Tour_Details_Taxi_In_Ref, string Tour_Details_Taxi_Out_Price, string Tour_Details_Taxi_Out_Ref, string QualiStatus, int Week_number)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {

                SqlCommand scd = new SqlCommand("update Tour_Details SET  Tour_Details_Guest_Status= '" + Tour_Details_Guest_Status + "',	Tour_Details_Guest_Sales_Rep= '" + Tour_Details_Guest_Sales_Rep + "',	Tour_Details_Tour_Date=convert(datetime, '" + Tour_Details_Tour_Date + "',105),	Tour_Details_Sales_Deck_Check_In= '" + Tour_Details_Sales_Deck_Check_In + "',	Tour_Details_Sales_Deck_Check_Out= '" + Tour_Details_Sales_Deck_Check_Out + "',	Tour_Details_Taxi_In_Price= '" + Tour_Details_Taxi_In_Price + "',	Tour_Details_Taxi_In_Ref= '" + Tour_Details_Taxi_In_Ref + "',	Tour_Details_Taxi_Out_Price= '" + Tour_Details_Taxi_Out_Price + "',	Tour_Details_Taxi_Out_Ref= '" + Tour_Details_Taxi_Out_Ref + "',	Tour_Details_Qualified_Status= '" + QualiStatus + "',	Week_number= '" + Week_number + "'where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in UPDATE Tour_Details Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static SqlDataReader GetUserData(string user)
    {
        SqlDataReader dr;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {
            SqlCommand scd = new SqlCommand("select * from user_group_access ug join users u on u.[Group Id] = ug.[Group Id]where u.username =@user ", cs2);
            scd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            dr = scd.ExecuteReader();

        }
        return dr;
    }
    public static DataSet LoadSalutations(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Salutation from Salutations where status='active' and Office=@office order by 1", cs1);
 	   SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadPrimarySalutation(string ProfileID,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Salutation from Salutations where status='active' and Office=@office  and Salutation not in(select Profile_Primary_Title  from Profile_Primary where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
	 SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSecondarySalutation(string ProfileID,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as Salutation UNION select Salutation from Salutations where status='active' and Office=@office  and Salutation not in(select Profile_Secondary_Title  from Profile_Secondary where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
 SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSub_Profile1Salutation(string ProfileID,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as Salutation UNION select Salutation from Salutations where status='active' and Office=@office  and Salutation not in(select Sub_Profile1_Title  from Sub_Profile1 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
 SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSub_Profile2Salutation(string ProfileID,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as Salutation UNION select Salutation from Salutations where status='active' and Office=@office   and Salutation not in(select Sub_Profile2_Title  from Sub_Profile2 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
 SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadContractType(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ContractType_name  from  ContractType  where ContractType_Status='Active' and office=@office", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadPrimaryNationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Nationality_Name from  Nationality    where Nationality_Name  not in(select Profile_Primary_Nationality  from Profile_Primary where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSecondaryNationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as  Nationality_Name UNION select Nationality_Name from  Nationality    where Nationality_Name not in(select Profile_Secondary_Nationality  from Profile_Secondary where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSub_Profile1Nationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as  Nationality_Name UNION select Nationality_Name from Nationality    where Nationality_Name not in(select Sub_Profile1_Nationality  from Sub_Profile1 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSub_Profile2Nationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as  Nationality_Name UNION select Nationality_Name from  Nationality    where Nationality_Name not in(select Sub_Profile2_Nationality  from Sub_Profile2 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    //public static DataSet LoadAffiliationType(string office)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        SqlCommand SqlCmd = new SqlCommand("select Affiliation_Type_name  from AffiliationType where Affiliation_Type_Status='Active' and office=@office", cs1);
    //        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}
    public static SqlDataReader LoadAffiliationType(string office)//,string curr)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select AffiliationType_ID, Affiliation_Type_name,Affiliation_Type_Amt  from AffiliationType where Affiliation_Type_Status='Active' and office=@office", cs1);// and Affiliation_Type_Currency=@curr", cs1);
        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
        //   SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
        SqlDataReader dr = SqlCmd.ExecuteReader();
        return dr;
    }
    public static DataSet LoadPointsClub(string office, string venueid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct Contract_Club_Name from contract_club where Contract_Club_Status = 'Active' and office =@office and  Venue_ID=@venueid order by 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@venueid", SqlDbType.VarChar).Value = venueid;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadPaymentMethod(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  pay_method_name from pay_method where pay_method_status='Active' and office=@office order by 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadDepositPaymentMethod(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Deposit_pay_method_name from Deposit_Pay_Method where Deposit_pay_method_status='Active' and office=@office order by 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static String GetdeptID(string off)
    {
        string dept = null;
        string startvalue = "D00";
        int id = 0;
        int chek = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {


            SqlCommand scd = new SqlCommand("select count(*) from department", cs1);
            chek = (int)scd.ExecuteScalar();
            if (chek == 0)
            {
                id = 1;
                dept = startvalue + id;
            }
            else
            {
                id = chek + 1;
                dept = startvalue + id;
            }

        }
        return dept;
    }

    public static string GetLastYr(string firstyr, string tenure)
    {
        string last;
        using (SqlConnection cs = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select LastYear  from Occupancy where StartYear=@firstyr and tenure=@tenure and status='active',cs1 ");
            scd.Parameters.Add("@firstyr", SqlDbType.VarChar).Value = firstyr;
            scd.Parameters.Add("@tenure", SqlDbType.VarChar).Value = tenure;
            last = (string)scd.ExecuteScalar();
        }
        return last;
    }
    public static DataSet LoadMembershipEntitlement()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Entitlement_Name from Entitlement where  Entitlement_Status='active' order by 1", cs1);

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    /* public static DataSet LoadPointsContract(string Currency)
     {
         SqlDataAdapter da;
         DataSet ds = new DataSet();
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {
               SqlCommand SqlCmd = new SqlCommand("select * from PointsContract where Currency=@Currency and status='active'", cs1);
         //    SqlCommand SqlCmd = new SqlCommand("select Amount from PointsContract where Currency=@Te  status='active'", cs1);
          SqlCmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
             da = new SqlDataAdapter(SqlCmd);
             ds = new DataSet();
             da.Fill(ds);
         }
         return (ds);
     }*/

    public static SqlDataReader LoadPointsContract(string Currency)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select amount,taxValue from PointsContract where Currency=@Currency and status='active'", cs1);
        SqlCmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
        SqlDataReader dr = SqlCmd.ExecuteReader();
        return dr;
    }

    public static DataSet LoadEmploymentStatus()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Name  from EmploymentStatus  where  Status='Active'", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadMaritalStatus()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select MaritalStatus  from MaritalStatus  where  Status='Active'", cs1);

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadEmploymentStatusNotInProfile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select Name  from EmploymentStatus  where  Status='Active' and Name not in(select Profile_Employment_status from profile where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadMaritalStatusNotInProfile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select MaritalStatus  from MaritalStatus  where  Status='Active' and MaritalStatus not in(select Profile_Marital_status from profile where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadGuestStatusInProfile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Guest_Status_name  from Guest_Status where Guest_Status_Status ='Active'  and Guest_Status_name not in(select Tour_Details_Guest_Status from Tour_Details  where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSalesRepsInProfile(string office, string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where office=@office   and Sales_Rep_Status='Active' and Sales_Rep_Name not in (select Tour_Details_Guest_Sales_Rep from Tour_Details  where profile_id=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSalesRepsInProfile1(string office, string ProfileID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where office=@office and venue=@venue and Sales_Rep_Status='Active' and Sales_Rep_Name not in (select Tour_Details_Guest_Sales_Rep from Tour_Details  where profile_id=@ProfileID) ORDER BY 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static int InsertGiftOption(string Gift_ID, string Gift_ID_Option, string Gift_Voucher_numb, string Gift_Comment, string Profile_ID, string GiftItem, string GiftPrice)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Gift values(@Gift_ID,	@Gift_ID_Option,@Gift_Voucher_numb,	@Gift_Comment,@Profile_ID,@GiftItem,@GiftPrice)", cs1);
                da.InsertCommand.Parameters.Add("@Gift_ID", SqlDbType.VarChar).Value = Gift_ID;
                da.InsertCommand.Parameters.Add("@Gift_ID_Option", SqlDbType.VarChar).Value = Gift_ID_Option;
                da.InsertCommand.Parameters.Add("@Gift_Voucher_numb", SqlDbType.VarChar).Value = Gift_Voucher_numb;
                da.InsertCommand.Parameters.Add("@Gift_Comment", SqlDbType.VarChar).Value = Gift_Comment;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@GiftItem", SqlDbType.VarChar).Value = GiftItem;
                da.InsertCommand.Parameters.Add("@GiftPrice", SqlDbType.VarChar).Value = GiftPrice;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Gift Query " + ex.Message);

                string msg = "Error in Insert Gift Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static String GetProfileGift(string startvalue)//(string off)
    {
        string PProfileID = null;
        //string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "G";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /*  if (off == "INDIA" || off == "India")
              {
                  startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Gift_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                PProfileID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Gift_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Gift_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                PProfileID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Gift_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }



        }

        return PProfileID;
    }
    public static DataSet LoadFinanceMethod(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Finance_Name  from FinanceMethod where office=@office and Finance_Status='Active' ", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    } 
/*public static DataSet LoadFinanceMethod(string office,string currency)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Finance_Name  from FinanceMethod where office=@office and Finance_Status='Active' and currency=@currency ", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office; 
            SqlCmd.Parameters.Add("@currency", SqlDbType.VarChar).Value = currency;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }*/

    public static DataSet LoadSeason()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select season_name from Seasons where season_status='Active' order by 1 ", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static SqlDataReader ContractNoGeneration(string venue, string grpname, string contractname)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct Contract_Club_Name,vg.Venue_group_Code from contract_club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID=vg.Venue_ID  where  v.Venue_Name = '" + venue + "' and vg.Venue_Group_Name = '" + grpname + "' and cc.Contract_Club_Name = '" + contractname + "' and cc.Contract_Club_Status = 'Active'", cs1);
        //  SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@grpname", SqlDbType.VarChar).Value = grpname;
        SqlCmd.Parameters.Add("@contractname", SqlDbType.VarChar).Value = contractname;
        SqlDataReader dr = SqlCmd.ExecuteReader();

        return dr;
    }
    public static SqlDataReader LoadVenueonVCountry(string venuecountry)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select Venue_Name  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID   where vc.Venue_Country_Name = @venuecountry order by 1", cs1);
        SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
        //   SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
    public static SqlDataReader GetIncrementValueofContractClubIndian(string venue, string venuegrp, string club, string nationality)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        //  SqlCommand SqlCmd = new SqlCommand(" select distinct cc.Contract_Code,vg.Venue_group_Code,cc.increment_value from contract_club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where cc.Contract_Club_Status = 'Active' and v.Venue_Name = @venue and vg.Venue_Group_Name = @venuegrp and Contract_Club_Name = @club and    cc.nationality=@nationality", cs1);
        SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name = @venue and cc.Contract_Club_Name = @club and vg.Venue_Group_Name = @venuegrp and cc.Nationality in('Indian' ,'INDIAN','OCI,'PIO')", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
        SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
        SqlCmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;

        SqlDataReader dr = SqlCmd.ExecuteReader();

        return dr;
    }
    public static SqlDataReader GetIncrementValueofContractClubNonIndian(string venue, string venuegrp, string club, string nationality)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        //   SqlCommand SqlCmd = new SqlCommand(" select distinct cc.Contract_Code,vg.Venue_group_Code,cc.increment_value from contract_club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where cc.Contract_Club_Status = 'Active' and v.Venue_Name = @venue and vg.Venue_Group_Name = @venuegrp and Contract_Club_Name = @club and    cc.nationality=@nationality", cs1);
        SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name = @venue and cc.Contract_Club_Name = @club and vg.Venue_Group_Name = @venuegrp and cc.Nationality not in( 'Indian' ,'INDIAN','OCI,'PIO')", cs1);

        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
        SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
        SqlCmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;

        SqlDataReader dr = SqlCmd.ExecuteReader();

        return dr;
    }

    public static int InsertContract_Points_Indian(string ContractPoints_ID, string ProfileID, string ContractNo, string club, string New_points_rights, string Type_membership, string Total_points_rights, string First_year_occupancy, string Tenure, string Last_year_occupancy, string NoPersons, string ContractDetails_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Points_Indian values(@ContractPoints_ID ,	@ProfileID ,	@ContractNo ,	@club,	@New_points_rights,	@Type_membership,	@Total_points_rights,	@First_year_occupancy,	@Tenure,	@Last_year_occupancy,@NoPersons,@ContractDetails_ID )", cs1);
                da.InsertCommand.Parameters.Add("@ContractPoints_ID ", SqlDbType.VarChar).Value = ContractPoints_ID;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                da.InsertCommand.Parameters.Add("@New_points_rights", SqlDbType.VarChar).Value = New_points_rights;
                da.InsertCommand.Parameters.Add("@Type_membership", SqlDbType.VarChar).Value = Type_membership;
                da.InsertCommand.Parameters.Add("@Total_points_rights", SqlDbType.VarChar).Value = Total_points_rights;
                da.InsertCommand.Parameters.Add("@First_year_occupancy", SqlDbType.VarChar).Value = First_year_occupancy;
                da.InsertCommand.Parameters.Add("@Tenure", SqlDbType.VarChar).Value = Tenure;
                da.InsertCommand.Parameters.Add("@Last_year_occupancy ", SqlDbType.VarChar).Value = Last_year_occupancy;
                da.InsertCommand.Parameters.Add("@NoPersons", SqlDbType.VarChar).Value = NoPersons;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Points_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

  public static int InsertFinance_Details_Indian(string Finance_Details_Id, string ProfileID, string ContractNo, string Finance_Method, string Currency, string Affiliate_Type, string Total_Price_Including_Tax, string Initial_Deposit_Percent, string Initial_Deposit_Amount, string Balance_Payable, string Total_Inital_Deposit, string Initial_Deposit_Balance, string Bal_Amount_Payable, string Payment_Method, string No_Installments, string Installment_Amount, string Finance_Type, string Finance_No, string IGSTrate, string Interestrate, string documentationfee, string IGST_Amount, string No_Emi, string Emi_Installment, string financeMonth, string Old_Loan_AgreementNo, string Registry_Collection_Term, string Registry_Collection_Amt, string ContractDetails_ID, string BalanceDeposit_Date, string Old_Loan_Amount,string eurorate, string loanamtINEuro, string monthlyPremiumprotectionplan,string Open_Loan_AgreementNo)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Finance_Details_Indian values(@Finance_Details_Id,@ProfileID,@ContractNo,@Finance_Method,@Currency,	@Affiliate_Type ,	@Total_Price_Including_Tax ,	@Initial_Deposit_Percent  ,	@Initial_Deposit_Amount  ,	@Balance_Payable  ,	@Total_Inital_Deposit  ,	@Initial_Deposit_Balance,	@Bal_Amount_Payable,@Payment_Method,@No_Installments,@Installment_Amount,@Finance_Type,@Finance_No,	@IGSTrate ,	@Interestrate ,	@documentationfee ,	@IGST_Amount,@No_Emi,@Emi_Installment,@financeMonth,@Old_Loan_AgreementNo,@Registry_Collection_Term,@Registry_Collection_Amt,@ContractDetails_ID,convert(datetime,@BalanceDeposit_Date,105),@Old_Loan_Amount,@eurorate,@loanamtINEuro,@monthlyPremiumprotectionplan,@Open_Loan_AgreementNo)", cs1);
                da.InsertCommand.Parameters.Add("@Finance_Details_Id ", SqlDbType.VarChar).Value = Finance_Details_Id;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Finance_Method ", SqlDbType.VarChar).Value = Finance_Method;
                da.InsertCommand.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
                da.InsertCommand.Parameters.Add("@Affiliate_Type", SqlDbType.VarChar).Value = Affiliate_Type;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Percent", SqlDbType.VarChar).Value = Initial_Deposit_Percent;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Amount", SqlDbType.VarChar).Value = Initial_Deposit_Amount;
                da.InsertCommand.Parameters.Add("@Balance_Payable", SqlDbType.VarChar).Value = Balance_Payable;
                da.InsertCommand.Parameters.Add("@Total_Inital_Deposit", SqlDbType.VarChar).Value = Total_Inital_Deposit;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Balance", SqlDbType.VarChar).Value = Initial_Deposit_Balance;
                da.InsertCommand.Parameters.Add("@Bal_Amount_Payable", SqlDbType.VarChar).Value = Bal_Amount_Payable;
                da.InsertCommand.Parameters.Add("@Payment_Method", SqlDbType.VarChar).Value = Payment_Method;
                da.InsertCommand.Parameters.Add("@No_Installments", SqlDbType.VarChar).Value = No_Installments;
                da.InsertCommand.Parameters.Add("@Installment_Amount", SqlDbType.VarChar).Value = Installment_Amount;
                da.InsertCommand.Parameters.Add("@Finance_Type", SqlDbType.VarChar).Value = Finance_Type;
                da.InsertCommand.Parameters.Add("@Finance_No", SqlDbType.VarChar).Value = Finance_No;
                da.InsertCommand.Parameters.Add("@IGSTrate", SqlDbType.VarChar).Value = IGSTrate;
                da.InsertCommand.Parameters.Add("@Interestrate", SqlDbType.VarChar).Value = Interestrate;
                da.InsertCommand.Parameters.Add("@documentationfee", SqlDbType.VarChar).Value = documentationfee;
                da.InsertCommand.Parameters.Add("@IGST_Amount", SqlDbType.VarChar).Value = IGST_Amount;
                da.InsertCommand.Parameters.Add("@No_Emi", SqlDbType.VarChar).Value = No_Emi;
                da.InsertCommand.Parameters.Add("@Emi_Installment", SqlDbType.VarChar).Value = Emi_Installment;
                da.InsertCommand.Parameters.Add("@financeMonth", SqlDbType.VarChar).Value = financeMonth;
                da.InsertCommand.Parameters.Add("@Old_Loan_AgreementNo", SqlDbType.VarChar).Value = Old_Loan_AgreementNo;
                da.InsertCommand.Parameters.Add("@Registry_Collection_Term", SqlDbType.VarChar).Value = Registry_Collection_Term;
                da.InsertCommand.Parameters.Add("@Registry_Collection_Amt", SqlDbType.VarChar).Value = Registry_Collection_Amt;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@BalanceDeposit_Date", SqlDbType.VarChar).Value = BalanceDeposit_Date;
                da.InsertCommand.Parameters.Add("@Old_Loan_Amount", SqlDbType.VarChar).Value = Old_Loan_Amount;
                da.InsertCommand.Parameters.Add("@eurorate", SqlDbType.VarChar).Value = eurorate;
                da.InsertCommand.Parameters.Add("@loanamtINEuro", SqlDbType.VarChar).Value = loanamtINEuro;
                da.InsertCommand.Parameters.Add("@monthlyPremiumprotectionplan", SqlDbType.VarChar).Value = monthlyPremiumprotectionplan;
               da.InsertCommand.Parameters.Add("@Open_Loan_AgreementNo", SqlDbType.VarChar).Value = Open_Loan_AgreementNo;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 

                string msg = "Error in Insert Finance_Details_Indian Query " + " " + ex.Message;
                throw new Exception(msg, ex);
 
            }
        }
        return (rowsAffected);
    }


     public static int InsertContract_PA_Indian(string Contract_PA_Id, string ProfileID, string ContractNo, string New_Points_Price, string Conversion_Fee, string Admin_Fee, string Total_Purchase_Price, string Cgst, string Sgst, string Total_Price_Including_Tax, string Deposit, string Balance, string Balance_Due_Dates, string Remarks, string ContractDetails_ID,string oldVolume,string oldadminfee,string oldTotalTax, string  oldDeposit, string usdoldvolume, string usdoldadminfee,string usdoldtax, string usdolddeposit,string USDConvertedVolume, string USDConvertedAdminfee, string USDConvertedTax, string USDConverteddeposit,string Total_Tax,string USDConvertedTotalVolume,string exchangerate)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_PA_Indian values(@Contract_PA_Id,@ProfileID,@ContractNo ,@New_Points_Price,@Conversion_Fee,	@Admin_Fee ,@Total_Purchase_Price ,	@Cgst ,	@Sgst ,	@Total_Price_Including_Tax ,@Deposit ,	@Balance,	@Balance_Due_Dates,	@Remarks,@ContractDetails_ID,@oldVolume,@oldadminfee, @oldTotalTax,@oldDeposit,@usdoldvolume,@usdoldadminfee,@usdoldtax,@usdolddeposit,@USDConvertedVolume,@USDConvertedAdminfee,@USDConvertedTax,@USDConverteddeposit,@Total_Tax,@USDConvertedTotalVolume,@exchangerate)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_PA_Id ", SqlDbType.VarChar).Value = Contract_PA_Id;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@New_Points_Price ", SqlDbType.VarChar).Value = New_Points_Price;
                da.InsertCommand.Parameters.Add("@Conversion_Fee", SqlDbType.VarChar).Value = Conversion_Fee;
                da.InsertCommand.Parameters.Add("@Admin_Fee", SqlDbType.VarChar).Value = Admin_Fee;
                da.InsertCommand.Parameters.Add("@Total_Purchase_Price", SqlDbType.VarChar).Value = Total_Purchase_Price;
                da.InsertCommand.Parameters.Add("@Cgst", SqlDbType.VarChar).Value = Cgst;
                da.InsertCommand.Parameters.Add("@Sgst", SqlDbType.VarChar).Value = Sgst;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Deposit ", SqlDbType.VarChar).Value = Deposit;
                da.InsertCommand.Parameters.Add("@Balance", SqlDbType.VarChar).Value = Balance;
                da.InsertCommand.Parameters.Add("@Balance_Due_Dates", SqlDbType.VarChar).Value = Balance_Due_Dates;
                da.InsertCommand.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@oldVolume", SqlDbType.VarChar).Value = oldVolume;
                da.InsertCommand.Parameters.Add("@oldadminfee", SqlDbType.VarChar).Value = oldadminfee;
                da.InsertCommand.Parameters.Add("@oldTotalTax", SqlDbType.VarChar).Value = oldTotalTax;
                da.InsertCommand.Parameters.Add("@oldDeposit", SqlDbType.VarChar).Value = oldDeposit;
                da.InsertCommand.Parameters.Add("@usdoldvolume", SqlDbType.VarChar).Value = usdoldvolume;
                da.InsertCommand.Parameters.Add("@usdoldadminfee", SqlDbType.VarChar).Value = usdoldadminfee;
                da.InsertCommand.Parameters.Add("@usdoldtax", SqlDbType.VarChar).Value = usdoldtax;
                da.InsertCommand.Parameters.Add("@usdolddeposit", SqlDbType.VarChar).Value = usdolddeposit;
                da.InsertCommand.Parameters.Add("@USDConvertedVolume", SqlDbType.VarChar).Value = USDConvertedVolume; 
                da.InsertCommand.Parameters.Add("@USDConvertedAdminfee", SqlDbType.VarChar).Value = USDConvertedAdminfee;
                da.InsertCommand.Parameters.Add("@USDConvertedTax", SqlDbType.VarChar).Value = USDConvertedTax;
                da.InsertCommand.Parameters.Add("@USDConverteddeposit", SqlDbType.VarChar).Value = USDConverteddeposit;
                da.InsertCommand.Parameters.Add("@Total_Tax", SqlDbType.VarChar).Value = Total_Tax;
                da.InsertCommand.Parameters.Add("@USDConvertedTotalVolume", SqlDbType.VarChar).Value = USDConvertedTotalVolume;
                da.InsertCommand.Parameters.Add("@exchangerate", SqlDbType.VarChar).Value = exchangerate;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                

                string msg = "Error in Insert Contract_PA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                 
            }
        }
        return (rowsAffected);
    }

    public static string GetInstallmentInvoiceNo(string office)
    {
        string InvoiceNo;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select startval+midval+smidval+ cast (endval as varchar(50)) from Finance_install_ID where office=@office", cs1);
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            InvoiceNo = (string)scd.ExecuteScalar();
        }
        return InvoiceNo;

    }
    public static int UpdateInstallmentInvoiceNo(string office)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand(" update Finance_install_ID set endval = endval + 1 where office =@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE Finance_install_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }


   public static int InsertContract_Installments_Indian(string ProfileID, string ContractNo, string Installment_no, string Installment_Amount, string Installment_Date, string Installment_Invoice_No, string ContractDetails_ID,string Paymentmode)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Installments_Indian values(@ProfileID,	@ContractNo,@Installment_no,@Installment_Amount,convert(datetime,@Installment_Date,105),@Installment_Invoice_No,@ContractDetails_ID,@Paymentmode)", cs1);
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Installment_no", SqlDbType.VarChar).Value = Installment_no;
                da.InsertCommand.Parameters.Add("@Installment_Amount", SqlDbType.VarChar).Value = Installment_Amount;
                da.InsertCommand.Parameters.Add("@Installment_Date", SqlDbType.VarChar).Value = Installment_Date;
                da.InsertCommand.Parameters.Add("@Installment_Invoice_No", SqlDbType.VarChar).Value = Installment_Invoice_No;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@Paymentmode", SqlDbType.VarChar).Value = Paymentmode;
                
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                 
                string msg = "Error in Insert InsertContract_Installments_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

               
            }
        }
        return (rowsAffected);
    }

    public static string GetContract_Points_Indian()
    {
        string Contract_Points_Indian = "";
        string startvalue = "CPI";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractPoints_ID, 4, len(ContractPoints_ID)))from Contract_Points_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Contract_Points_Indian = startvalue + id;
                }
                else
                {
                    id = 1;
                    Contract_Points_Indian = startvalue + id;

                }

            }
        }
        return Contract_Points_Indian;


    }

    public static string GetFinance_Details_Indian()
    {
        string Finance_Details_Id = "";
        string startvalue = "FD_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Finance_Details_Id, 6, len(Finance_Details_Id)))from Finance_Details_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Finance_Details_Id = startvalue + id;
                }
                else
                {
                    id = 1;
                    Finance_Details_Id = startvalue + id;

                }

            }
        }
        return Finance_Details_Id;


    }
    public static string GetContract_PA_Indian()
    {
        string Contract_PA_Id = "";
        string startvalue = "PA_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Contract_PA_Id, 6, len(Contract_PA_Id)))from Contract_PA_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Contract_PA_Id = startvalue + id;
                }
                else
                {
                    id = 1;
                    Contract_PA_Id = startvalue + id;

                }

            }
        }
        return Contract_PA_Id;


    }

    public static int UpdateContractNo(string venue, string club, string nationality)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select cc.increment_value from contract_club  cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name =@venue and Contract_Club_Name = @club and    cc.nationality = @nationality", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from contract_club cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name = @venue  and Contract_Club_Name = @club and    cc.nationality = @nationality", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE contract_club Query " + ex.Message);

                string msg = "Error in UPDATE contract_club Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static int UpdateContractNoInd(string venue, string club)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select cc.increment_value from contract_club  cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name =@venue and Contract_Club_Name = @club and    cc.nationality in('Indian','INDIAN','OCI','PIO')", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                // scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from contract_club cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name = @venue  and Contract_Club_Name = @club and    cc.nationality in( 'Indian','INDIAN','OCI','PIO')", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                //  sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE contract_club Query " + ex.Message);

                string msg = "Error in UPDATE contract_club Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateContractNoNInd(string venue, string club)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select cc.increment_value from contract_club  cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name =@venue and Contract_Club_Name = @club and    cc.nationality  not in( 'Indian','INDIAN','OCI','PIO')", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                //  scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from contract_club cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name = @venue  and Contract_Club_Name = @club and    cc.nationality not in('Indian','INDIAN','OCI','PIO') ", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                // sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE contract_club Query " + ex.Message);

                string msg = "Error in UPDATE contract_club Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateResortNoInd(string venue, string club)//, string nationality)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Increment_Value from Contract_ResortCode_Generation   where    Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue =@venue and Nationality  in('Indian','INDIAN','OCI','PIO')", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                // scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from Contract_ResortCode_Generation cc  where    cc.Contract_Resort_Name=@club and cc.Contract_Resort_Status = 'active' and cc.venue =@venue and cc.Nationality in('Indian','INDIAN','OCI','PIO')", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                //   sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Contract_ResortCode_Generation Query " + ex.Message);

                string msg = "Error in UPDATE Contract_ResortCode_Generation Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateResortNoNonInd(string venue, string club)//, string nationality)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Increment_Value from Contract_ResortCode_Generation   where    Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue =@venue and Nationality not in('Indian','INDIAN','OCI','PIO')", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                // scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from Contract_ResortCode_Generation cc  where    cc.Contract_Resort_Name=@club and cc.Contract_Resort_Status = 'active' and cc.venue =@venue and cc.Nationality not in('Indian','INDIAN','OCI','PIO')", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                //   sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Contract_ResortCode_Generation Query " + ex.Message);

                string msg = "Error in UPDATE Contract_ResortCode_Generation Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static string GetContract_Trade_In_Points_Indian()
    {
        string ContractTradeInPoint_ID = "";
        string startvalue = "CTIP";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractTradeInPoint_ID, 5, len(ContractTradeInPoint_ID)))from Contract_Trade_In_Points_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractTradeInPoint_ID = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractTradeInPoint_ID = startvalue + id;

                }

            }
        }
        return ContractTradeInPoint_ID;


    }

     public static int InsertContract_Trade_In_Points_Indian(string ContractTradeInPoint_ID, string ProfileID, string ContractNo, string Trade_In_Details_club_resort, string Trade_In_Details_No_rights, string Trade_In_Details_ContNo_RCINo, string Trade_In_Details_Points_value, string New_Club, string New_Club_Points_Rights, string New_MemebrshipType, string New_TotalPointsRights, string New_First_year_occupancy, string New_Tenure, string New_Last_year_occupancy, string NoPersons, string ContractDetails_ID,string Actualpoints_value,string OldMemtype)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Trade_In_Points_Indian values(@ContractTradeInPoint_ID,	@ProfileID,	@ContractNo,	@Trade_In_Details_club_resort,	@Trade_In_Details_No_rights,	@Trade_In_Details_ContNo_RCINo,	@Trade_In_Details_Points_value,	@New_Club,	@New_Club_Points_Rights,	@New_MemebrshipType,	@New_TotalPointsRights,	@New_First_year_occupancy,	@New_Tenure,	@New_Last_year_occupancy,@NoPersons,@ContractDetails_ID,@Actualpoints_value,@OldMemtype)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTradeInPoint_ID", SqlDbType.VarChar).Value = ContractTradeInPoint_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_club_resort", SqlDbType.VarChar).Value = Trade_In_Details_club_resort;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_No_rights", SqlDbType.VarChar).Value = Trade_In_Details_No_rights;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_ContNo_RCINo", SqlDbType.VarChar).Value = Trade_In_Details_ContNo_RCINo;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_Points_value", SqlDbType.VarChar).Value = Trade_In_Details_Points_value;
                da.InsertCommand.Parameters.Add("@New_Club", SqlDbType.VarChar).Value = New_Club;
                da.InsertCommand.Parameters.Add("@New_Club_Points_Rights", SqlDbType.VarChar).Value = New_Club_Points_Rights;
                da.InsertCommand.Parameters.Add("@New_MemebrshipType", SqlDbType.VarChar).Value = New_MemebrshipType;
                da.InsertCommand.Parameters.Add("@New_TotalPointsRights", SqlDbType.VarChar).Value = New_TotalPointsRights;
                da.InsertCommand.Parameters.Add("@New_First_year_occupancy", SqlDbType.VarChar).Value = New_First_year_occupancy;
                da.InsertCommand.Parameters.Add("@New_Tenure", SqlDbType.VarChar).Value = New_Tenure;
                da.InsertCommand.Parameters.Add("@New_Last_year_occupancy", SqlDbType.VarChar).Value = New_Last_year_occupancy;
                da.InsertCommand.Parameters.Add("@NoPersons", SqlDbType.VarChar).Value = NoPersons;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("Actualpoints_value", SqlDbType.VarChar).Value = Actualpoints_value;
                da.InsertCommand.Parameters.Add("OldMemtype", SqlDbType.VarChar).Value = OldMemtype;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                string msg = "Error in Insert Contract_Trade_In_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

               
            }
        }
        return (rowsAffected);
    }

    public static string GetContract_Trade_In_Weeks_Indian()
    {
        string ContractTradeInWeeks_ID = "";
        string startvalue = "CTIW";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractTradeInWeeks_ID, 5, len(ContractTradeInWeeks_ID)))from Contract_Trade_In_Weeks_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractTradeInWeeks_ID = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractTradeInWeeks_ID = startvalue + id;

                }

            }
        }
        return ContractTradeInWeeks_ID;


    }

   public static int InsertContract_Trade_In_Weeks_Indian(String ContractTradeInWeeks_ID, String ProfileID, String ContractNo, String Trade_In_Weeks_resort, String Trade_In_Weeks_Apt, string Trade_In_Weeks_Season, String Trade_In_Weeks_NoWks, String Trade_In_Weeks_ContNo_RCINo, String Trade_In_Weeks_Points_value, String NewPointsW_Club, String NewPointsW_Club_Points_Rights, String NewPointsW_MemebrshipType, String NewPointsW_Total_Points_rights, String NewPointsW_First_year_occupancy, String NewPointsW_Tenure, String NewPointsW_Last_year_occupancy, string NoPersons, string ContractDetails_ID,string OldMemtype,string Actualpoints_value)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Trade_In_Weeks_Indian values(@ContractTradeInWeeks_ID,	@ProfileID,	@ContractNo,	@Trade_In_Weeks_resort,	@Trade_In_Weeks_Apt ,@Trade_In_Weeks_Season,	@Trade_In_Weeks_NoWks,	@Trade_In_Weeks_ContNo_RCINo,	@Trade_In_Weeks_Points_value,	@NewPointsW_Club ,	@NewPointsW_Club_Points_Rights ,	@NewPointsW_MemebrshipType ,	@NewPointsW_Total_Points_rights ,	@NewPointsW_First_year_occupancy,	@NewPointsW_Tenure,	@NewPointsW_Last_year_occupancy,@NoPersons,@ContractDetails_ID,@OldMemtype,@Actualpoints_value)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTradeInWeeks_ID ", SqlDbType.VarChar).Value = ContractTradeInWeeks_ID;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_resort", SqlDbType.VarChar).Value = Trade_In_Weeks_resort;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Apt ", SqlDbType.VarChar).Value = Trade_In_Weeks_Apt;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Season", SqlDbType.VarChar).Value = Trade_In_Weeks_Season;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_NoWks ", SqlDbType.VarChar).Value = Trade_In_Weeks_NoWks;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_ContNo_RCINo", SqlDbType.VarChar).Value = Trade_In_Weeks_ContNo_RCINo;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Points_value", SqlDbType.VarChar).Value = Trade_In_Weeks_Points_value;
                da.InsertCommand.Parameters.Add("@NewPointsW_Club ", SqlDbType.VarChar).Value = NewPointsW_Club;
                da.InsertCommand.Parameters.Add("@NewPointsW_Club_Points_Rights ", SqlDbType.VarChar).Value = NewPointsW_Club_Points_Rights;
                da.InsertCommand.Parameters.Add("@NewPointsW_MemebrshipType ", SqlDbType.VarChar).Value = NewPointsW_MemebrshipType;
                da.InsertCommand.Parameters.Add("@NewPointsW_Total_Points_rights ", SqlDbType.VarChar).Value = NewPointsW_Total_Points_rights;
                da.InsertCommand.Parameters.Add("@NewPointsW_First_year_occupancy", SqlDbType.VarChar).Value = NewPointsW_First_year_occupancy;
                da.InsertCommand.Parameters.Add("@NewPointsW_Tenure", SqlDbType.VarChar).Value = NewPointsW_Tenure;
                da.InsertCommand.Parameters.Add("@NewPointsW_Last_year_occupancy", SqlDbType.VarChar).Value = NewPointsW_Last_year_occupancy;
                da.InsertCommand.Parameters.Add("@NoPersons", SqlDbType.VarChar).Value = NoPersons;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("OldMemtype", SqlDbType.VarChar).Value = OldMemtype;
                da.InsertCommand.Parameters.Add("Actualpoints_value", SqlDbType.VarChar).Value = Actualpoints_value;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               

                string msg = "Error in Insert Contract_Trade_In_Weeks_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static SqlDataReader GetFinanceNoIncrementValue(string venue, string finance, string type)
    {

        /*  if (type == "Fractional" || type == "Trade-In-Fractionals")
          {
              SqlConnection cs1 = Queries.GetDBConnection();
              SqlCommand SqlCmd = new SqlCommand(" select financecode+FinanceIncrval+contracttypecode  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType='Fractional'", cs1);
              SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
              SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
              SqlDataReader dr = SqlCmd.ExecuteReader();

              return dr;
          }
          else
          {
              SqlConnection cs1 = Queries.GetDBConnection();
              SqlCommand SqlCmd = new SqlCommand(" select financecode+FinanceIncrval+contracttypecode  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType='Non Fractional'", cs1);
              SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
              SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
              SqlDataReader dr = SqlCmd.ExecuteReader();

              return dr;
          }
          */
        SqlConnection cs1 = Queries.GetDBConnection();
       // SqlCommand SqlCmd = new SqlCommand(" select financecode+FinanceIncrval+contracttypecode  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance", cs1);
        SqlCommand SqlCmd = new SqlCommand(" select financecode+FinanceIncrval   from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance  and FinanceMethod_Status='Active'", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
        SqlDataReader dr = SqlCmd.ExecuteReader();

        return dr;


    }

    public static SqlDataReader GetVgroupOnVenue(string venue)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select Venue_Group_Name  from Venue_Group vg join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name =@venue and Venue_Group_Status = 'Active' order by 1", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
    public static SqlDataReader GetSalesRepOnVenue(string venue, string country)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select sales_rep_name from Sales_Rep  sr    join VenueCountry vc on vc.Venue_Country_ID = sr.Venue_country_ID    where    sales_rep_status = 'Active'   and sr.venue =@venue and vc.Venue_Country_Name = @country order by 1", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
    public static SqlDataReader GetSalesRepOnlyVenue(string venue)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select sales_rep_name from Sales_Rep  sr    join VenueCountry vc on vc.Venue_Country_ID = sr.Venue_country_ID    where    sales_rep_status = 'Active'   and sr.venue =@venue order by 1", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        //  cs1.Close();
        return dr;
    }

   public static int UpdateFinanceNo(string venue, string finance, string contracttype)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                /*if (contracttype == "Fractional" || contracttype == "Trade-In-Fractionals")
                {
                    SqlCommand scd1 = new SqlCommand("select FinanceIncrval  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType='Fractional'", cs1);
                    scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                    scd1.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SqlCommand sqlcmd = new SqlCommand("update cc set cc.FinanceIncrval=@id from FinanceMethod_Venue cc  where  venue=@venue and FinanceMethod_Name=@finance and ContractType='Fractional'", cs1);
                    sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                    sqlcmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                    sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    rows = sqlcmd.ExecuteNonQuery();

                }
                else
                {
                    SqlCommand scd1 = new SqlCommand("select FinanceIncrval  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType!='Fractional'", cs1);
                    scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                    scd1.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SqlCommand sqlcmd = new SqlCommand("update cc set cc.FinanceIncrval=@id from FinanceMethod_Venue cc  where  venue=@venue and FinanceMethod_Name=@finance and ContractType!='Fractional'", cs1);
                    sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                    sqlcmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                    sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    rows = sqlcmd.ExecuteNonQuery();

                }*/

                SqlCommand scd1 = new SqlCommand("select FinanceIncrval  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance  and FinanceMethod_Status='Active' ", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.FinanceIncrval=@id from FinanceMethod_Venue cc  where  venue=@venue and FinanceMethod_Name=@finance  and FinanceMethod_Status='Active'", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE FinanceMethod_Venue Query " + ex.Message);

                string msg = "Error in UPDATE FinanceMethod_Venue Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static DataSet LoadPrintPDFFiles_Indian(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance and isnull(Waiver, '') =@mc and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataTable NewPoints_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PA_Points_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable TradeInPoints_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PA_TradeInPoints_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable TradeInWeeks_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PA_TradeInWeeks_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable Fractional_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

         //   SqlCommand cmd_sp = new SqlCommand("PA_Fractional_India", con);
 		SqlCommand cmd_sp = new SqlCommand("PA_Fractional_TradeIn_India", con); 

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static SqlDataReader LoadAgentsOnVenue1(string venue,string office)//string venue)
    {

        SqlConnection cs1 = Queries.GetDBConnection();
     //   SqlCommand SqlCmd = new SqlCommand("select a.Agent_Name from Agent_GroupVenue ag join agent a on a.Agent_ID = ag.Agent_id where   a.Agent_Status = 'Active'and ag.venue =@venue order by 1", cs1);
        SqlCommand SqlCmd = new SqlCommand("select a.Agent_Name from   agent a   where   a.Agent_Status = 'Active'and a.Agent_office =@office order by 1", cs1);
        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }



    public static SqlDataReader LoadManagersOnVenue1(string venue,string office)//string venue)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
     //   SqlCommand SqlCmd = new SqlCommand("  select distinct Manager_Name from managers where Manager_Status='Active' and  Venue=@venue order by 1", cs1);
        SqlCommand SqlCmd = new SqlCommand(" select distinct Manager_Name from managers where Manager_Status='Active' and  office=@office order by 1", cs1);
        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }

    public static SqlDataReader LoadTOOPCOnVenue1(string venue,string office)//string venue)
    {

        SqlConnection cs1 = Queries.GetDBConnection();
        //SqlCommand SqlCmd = new SqlCommand(" select distinct to_name from OPC_TOs where TO_Status='Active' and  Venue=@venue order by 1", cs1);
        SqlCommand SqlCmd = new SqlCommand(" select distinct to_name from OPC_TOs where TO_Status='Active' and  office=@office order by 1", cs1);
        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
    public static SqlDataReader LoadTOOPCOnVenueNGrp(string venue)
    {

        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct TO_Manager_Name from TO_Manager where TO_Manager_Status = 'Active' and   Venue =@venue order by 1", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
    public static SqlDataReader LoadMarketingProgramOnVenueNVGroup1(string venuename, string vgname)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select m.Marketing_Program_Name  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name =@venuename and vg.Venue_Group_Name =@vgname and m.Marketing_Program_Status = 'Active' order by 1", cs1);
        SqlCmd.Parameters.Add("@venuename", SqlDbType.VarChar).Value = venuename;
        SqlCmd.Parameters.Add("@vgname", SqlDbType.VarChar).Value = vgname;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }

    public static DataSet LoadFractionalResortIndia()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Contract_Resort_Name  from [Contract_Resort] where office='hml' and Contract_Resort_Status='Active'", cs1);
            // SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadFractionalResortNonIndia()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Contract_Resort_Name  from [Contract_Resort] where office!='hml' and Contract_Resort_Status='Active'", cs1);
            // SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static SqlDataReader LoadfractionalResidencetype(string resort)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
       // SqlCommand SqlCmd = new SqlCommand("select crt.Contract_Resi_Type_Name from Contract_Residence_No crn join Contract_Resort cr on cr.Contract_Resort_ID = crn.Contract_Resort_ID join Contract_Residence_Type crt on crt.Contract_Residence_ID = crn.Contract_Residence_ID where cr.Contract_Resort_Name = @resort and crt.Contract_Resi_Type_Status = 'Active'", cs1);
 SqlCommand SqlCmd = new SqlCommand("select crt.Contract_Resi_Type_Name from Contract_Residence_No crn join Contract_Resort cr on cr.Contract_Resort_ID = crn.Contract_Resort_ID join Contract_Residence_Type crt on crt.Contract_Residence_ID = crn.Contract_Residence_ID where cr.Contract_Resort_Name = @resort and crt.Contract_Resi_Type_Status = 'Active' and cr.office='HML'", cs1);
        SqlCmd.Parameters.Add("@resort", SqlDbType.VarChar).Value = resort;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }

    public static SqlDataReader LoadfractionalResidenceNo(string resort)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select crn.Contract_Residence_Name from Contract_Residence_No crn join Contract_Resort cr on cr.Contract_Resort_ID = crn.Contract_Resort_ID where cr.Contract_Resort_Name =@resort and crn.Contract_Residence_Status = 'Active' and cr.office='HML'", cs1);
        SqlCmd.Parameters.Add("@resort", SqlDbType.VarChar).Value = resort;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }
    public static DataSet LoadFractionalInterest()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Fractional_Int_Name FROM  Contract_Fractional_Int  where [Contract_Fractional_Int_Status]='Active'", cs1);

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadMCChart(string club, string year, string curr)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select * from ManagementCharges_Chart_India where club =@club and year =@year and status='Active' and  Currency=@curr", cs1);
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadMCChartfractional(string club, string year, string curr, string wk, string type)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select * from ManagementCharges_Chart_India where club =@club and year =@year and status='Active' and  Currency=@curr and weekno=@wk and Otype =@type", cs1);
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@wk", SqlDbType.VarChar).Value = wk;
            SqlCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static string GetContract_Fractional_PA_Indian()
    {
        string Contract_Fractional_PA_Id = "";
        string startvalue = "PAF_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Contract_Fractional_PA_Id, 7, len(Contract_Fractional_PA_Id)))from Contract_Fractional_PA_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Contract_Fractional_PA_Id = startvalue + id;
                }
                else
                {
                    id = 1;
                    Contract_Fractional_PA_Id = startvalue + id;

                }

            }
        }
        return Contract_Fractional_PA_Id;


    }

    public static int InsertContract_Fractional_PA_Indian(string Contract_Fractional_PA_Id, string ProfileID, string ContractNo, string Admission_fees, string administration_fees, string Cgst, string Sgst, string Total_Purchase_Price, string Total_Price_Including_Tax, string Deposit, string Balance, string Balance_Due_Dates, string Remarks, string TradeIn_value, string Total_value, string ContractDetails_ID,string FoldVolume , string Foldadminfee, string FoldTotalTax, string FoldDeposit, string Fusdoldvolume,string Fusdoldadminfee,string Fusdoldtax,string Fusdolddeposit,string USDConvertedFVolume, string USDConvertedFAdminfee, string USDConvertedFTax, string USDConvertedFdeposit,string Total_Tax,string USDConvertedTotalVolume,string exchangerate)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Fractional_PA_Indian values(@Contract_Fractional_PA_Id,	@ProfileID,	@ContractNo,	@Admission_fees,	@administration_fees ,	@Cgst,	@Sgst,	@Total_Purchase_Price ,	@Total_Price_Including_Tax,@Deposit,@Balance,@Balance_Due_Dates,@Remarks,@TradeIn_value,@Total_value,@ContractDetails_ID,@FoldVolume,	@Foldadminfee,	@FoldTotalTax,	@FoldDeposit,@Fusdoldvolume,@Fusdoldadminfee,@Fusdoldtax,@Fusdolddeposit,@USDConvertedFVolume,@USDConvertedFAdminfee,@USDConvertedFTax,@USDConvertedFdeposit,@Total_Tax,@USDConvertedTotalVolume,@exchangerate)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_Fractional_PA_Id ", SqlDbType.VarChar).Value = Contract_Fractional_PA_Id;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Admission_fees", SqlDbType.VarChar).Value = Admission_fees;
                da.InsertCommand.Parameters.Add("@administration_fees", SqlDbType.VarChar).Value = administration_fees;
                da.InsertCommand.Parameters.Add("@Cgst", SqlDbType.VarChar).Value = Cgst;
                da.InsertCommand.Parameters.Add("@Sgst", SqlDbType.VarChar).Value = Sgst;
                da.InsertCommand.Parameters.Add("@Total_Purchase_Price", SqlDbType.VarChar).Value = Total_Purchase_Price;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Deposit", SqlDbType.VarChar).Value = Deposit;
                da.InsertCommand.Parameters.Add("@Balance", SqlDbType.VarChar).Value = Balance;
                da.InsertCommand.Parameters.Add("@Balance_Due_Dates", SqlDbType.VarChar).Value = Balance_Due_Dates;
                da.InsertCommand.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                da.InsertCommand.Parameters.Add("@TradeIn_value", SqlDbType.VarChar).Value = TradeIn_value;
                da.InsertCommand.Parameters.Add("@Total_value", SqlDbType.VarChar).Value = Total_value;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@FoldVolume", SqlDbType.VarChar).Value = FoldVolume;
                da.InsertCommand.Parameters.Add("@Foldadminfee", SqlDbType.VarChar).Value = Foldadminfee;
                da.InsertCommand.Parameters.Add("@FoldTotalTax", SqlDbType.VarChar).Value = FoldTotalTax;
                da.InsertCommand.Parameters.Add("@FoldDeposit", SqlDbType.VarChar).Value = FoldDeposit;
                da.InsertCommand.Parameters.Add("@Fusdoldvolume", SqlDbType.VarChar).Value = Fusdoldvolume;
                da.InsertCommand.Parameters.Add("@Fusdoldadminfee", SqlDbType.VarChar).Value = Fusdoldadminfee;
                da.InsertCommand.Parameters.Add("@Fusdoldtax", SqlDbType.VarChar).Value = Fusdoldtax;
                da.InsertCommand.Parameters.Add("@Fusdolddeposit", SqlDbType.VarChar).Value = Fusdolddeposit;
                da.InsertCommand.Parameters.Add("@USDConvertedFVolume", SqlDbType.VarChar).Value = USDConvertedFVolume; 
                da.InsertCommand.Parameters.Add("@USDConvertedFAdminfee", SqlDbType.VarChar).Value = USDConvertedFAdminfee;
                da.InsertCommand.Parameters.Add("@USDConvertedFTax", SqlDbType.VarChar).Value = USDConvertedFTax;
                da.InsertCommand.Parameters.Add("@USDConvertedFdeposit", SqlDbType.VarChar).Value = USDConvertedFdeposit;
                da.InsertCommand.Parameters.Add("@Total_Tax", SqlDbType.VarChar).Value = Total_Tax;
                da.InsertCommand.Parameters.Add("@USDConvertedTotalVolume", SqlDbType.VarChar).Value = USDConvertedTotalVolume;
                da.InsertCommand.Parameters.Add("@exchangerate", SqlDbType.VarChar).Value = exchangerate;
                
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
 

                string msg = "Error in Insert Contract_Fractional_PA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

              
            }
        }
        return (rowsAffected);
    }

    public static string GetContract_Fractional_Indian()
    {
        string ContractFractionalIndian_ID = "";
        string startvalue = "F_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractFractionalIndian_ID, 5, len(ContractFractionalIndian_ID)))from Contract_Fractional_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractFractionalIndian_ID = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractFractionalIndian_ID = startvalue + id;

                }

            }
        }
        return ContractFractionalIndian_ID;


    }
    public static int InsertContract_Fractional_Indian(string ContractFractionalIndian_ID, string ProfileID, string ContractNo, string resort, string residence_no, string residence_type, string fractional_interest, string entitlement, string firstyear_Occupancy, string tenure, string lastyear_Occupancy, string leaseback, string Mc_Charges, string ContractDetails_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into  Contract_Fractional_Indian values(@ContractFractionalIndian_ID,@ProfileID,@ContractNo,@resort,@residence_no,	@residence_type,@fractional_interest,	@entitlement,	@firstyear_Occupancy,	@tenure,	@lastyear_Occupancy,	@leaseback,	@Mc_Charges,@ContractDetails_ID)", cs1);
                da.InsertCommand.Parameters.Add("@ContractFractionalIndian_ID", SqlDbType.VarChar).Value = ContractFractionalIndian_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@resort", SqlDbType.VarChar).Value = resort;
                da.InsertCommand.Parameters.Add("@residence_no", SqlDbType.VarChar).Value = residence_no;
                da.InsertCommand.Parameters.Add("@residence_type", SqlDbType.VarChar).Value = residence_type;
                da.InsertCommand.Parameters.Add("@fractional_interest", SqlDbType.VarChar).Value = fractional_interest;
                da.InsertCommand.Parameters.Add("@entitlement", SqlDbType.VarChar).Value = entitlement;
                da.InsertCommand.Parameters.Add("@firstyear_Occupancy", SqlDbType.VarChar).Value = firstyear_Occupancy;
                da.InsertCommand.Parameters.Add("@tenure", SqlDbType.VarChar).Value = tenure;
                da.InsertCommand.Parameters.Add("@lastyear_Occupancy", SqlDbType.VarChar).Value = lastyear_Occupancy;
                da.InsertCommand.Parameters.Add("@leaseback", SqlDbType.VarChar).Value = leaseback;
                da.InsertCommand.Parameters.Add("@Mc_Charges", SqlDbType.VarChar).Value = Mc_Charges;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Contract_Fractional_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static SqlDataReader GetIncrementValueofContractResortIndian(string venue, string club)//, string nationality)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
      
      //  SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when Contract_Resort_Name ='Karma Haathi Mahal' then 'HM' else '' end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality = 'Indian'", cs1);
SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when venue like '%roadshow%' then (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'RSHM' else '' end) else (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'HM'  when Contract_Resort_Name ='Fractional Member' then 'FM'  else '' end) end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality = 'Indian'", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
        // SqlCmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }
    public static SqlDataReader GetIncrementValueofContractResortNonIndian(string venue, string club)//, string nationality)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
       
       // SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when Contract_Resort_Name ='Karma Haathi Mahal' then 'HM' else '' end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality != 'Indian'", cs1);
SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when venue like '%roadshow%' then (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'RSHM' else '' end) else (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'HM'  when Contract_Resort_Name ='Fractional Member' then 'FM'  else '' end) end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality != 'Indian'", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
        //SqlCmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }

    public static string GetFinanceMonth(string contractno)
    {
        string mn;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select financemonth from Finance_Details_Indian where contractNo =@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;
            mn = (string)scd.ExecuteScalar();
        }
        return mn;
    }


    public static int UpdatefinanceStartdate(string contractno)
    {
        int rows = 0;

        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select max(Installment_Date) from Contract_Installments_Indian where ContractNo=@contractno", cs1);
                scd1.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;

                DateTime val = (DateTime)scd1.ExecuteScalar();
                DateTime fdat = Convert.ToDateTime(val);
                int month = fdat.Month;
                int year = fdat.Year;
                if (month == 12)
                {
                    mon = 1;
                    yr = year + 1;
                    string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon); //CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName()
                                                                                                            // DateTime.Now.ToString("MMM", CultureInfo.CurrentCulture);
                                                                                                            //   int mno = DateTime.ParseExact(value, "MMMM", CultureInfo.CurrentCulture).Month;
                    financemonth = month1 + " " + yr;

                }
                else
                {
                    mon = month + 1;
                    string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                    financemonth = month1 + " " + year;
                }


                SqlCommand sqlcmd = new SqlCommand("UPDATE Finance_Details_Indian SET financeMonth=@financemonth where ContractNo=@contractno", cs1);
                sqlcmd.Parameters.Add("@financemonth", SqlDbType.VarChar).Value = financemonth;
                sqlcmd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;

                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_Details_Indian Query " + ex.Message);

                string msg = "Error in UPDATE Finance_Details_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }


        }
        return rows;
    }

    public static string GetContract_Trade_In_Fractional_Indian()
    {
        string ContractTrade_InFractional_ID = "";
        string startvalue = "CTIF";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractTrade_InFractional_ID, 5, len(ContractTrade_InFractional_ID)))from Contract_Trade_In_Fractional_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractTrade_InFractional_ID = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractTrade_InFractional_ID = startvalue + id;

                }

            }
        }
        return ContractTrade_InFractional_ID;


    }

    public static int InsertContract_Trade_In_Fractional_Indian(string ContractTrade_InFractional_ID, string ProfileID, string ContractNo, string Oldcontracttype, string RESORT, string APT_TYPE,  string SEASON, string NO_WEEKS, string NO_POINTS, string POINTS_VALUE, string oldContract_No, string ContractDetails_ID,string OldMemtype)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Trade_In_Fractional_Indian values(@ContractTrade_InFractional_ID ,	@ProfileID ,	@ContractNo ,	@Oldcontracttype ,	@RESORT ,	@APT_TYPE ,		@SEASON, @NO_WEEKS ,	@NO_POINTS,	@POINTS_VALUE ,	@oldContract_No,@ContractDetails_ID,@OldMemtype)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTrade_InFractional_ID  ", SqlDbType.VarChar).Value = ContractTrade_InFractional_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Oldcontracttype", SqlDbType.VarChar).Value = Oldcontracttype;
                da.InsertCommand.Parameters.Add("@RESORT", SqlDbType.VarChar).Value = RESORT;
                da.InsertCommand.Parameters.Add("@APT_TYPE", SqlDbType.VarChar).Value = APT_TYPE;
                da.InsertCommand.Parameters.Add("@NO_WEEKS", SqlDbType.VarChar).Value = NO_WEEKS;
                da.InsertCommand.Parameters.Add("@SEASON", SqlDbType.VarChar).Value = SEASON;
                da.InsertCommand.Parameters.Add("@NO_POINTS", SqlDbType.VarChar).Value = NO_POINTS;
                da.InsertCommand.Parameters.Add("@POINTS_VALUE", SqlDbType.VarChar).Value = POINTS_VALUE;
                da.InsertCommand.Parameters.Add("@oldContract_No", SqlDbType.VarChar).Value = oldContract_No;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("OldMemtype", SqlDbType.VarChar).Value = OldMemtype;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 
                string msg = "Error in Insert Contract_Trade_In_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }



   /* public static int InsertContractLogs_India(string ProfileID, String ContractNo, string UpdatedField, string Username, string Log_Entry)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Contract_Logs_India values(@ProfileID,@ContractNo,@UpdatedField,@Username,@Log_Entry)", cs1);
                da.InsertCommand.Parameters.Add("@ProfileID  ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@UpdatedField", SqlDbType.VarChar).Value = UpdatedField;
                da.InsertCommand.Parameters.Add("@Username ", SqlDbType.VarChar).Value = Username;
                da.InsertCommand.Parameters.Add("@Log_Entry", SqlDbType.VarChar).Value = Log_Entry;
                
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract Logs Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

                string msg = "Error in Insert Contract Logs Query" + " " + ex.Message;

                throw new Exception(msg, ex);

            }
        }
        return (rowsAffected);
    } 
public static int InsertContractLogs_India(string ProfileID, String ContractNo, string UpdatedField, string Username, string Log_Entry,string PageName)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Contract_Logs_India values(@ProfileID,@ContractNo,@UpdatedField,@Username,@Log_Entry,@PageName)", cs1);
                da.InsertCommand.Parameters.Add("@ProfileID  ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@UpdatedField", SqlDbType.VarChar).Value = UpdatedField;
                da.InsertCommand.Parameters.Add("@Username ", SqlDbType.VarChar).Value = Username;
                da.InsertCommand.Parameters.Add("@Log_Entry", SqlDbType.VarChar).Value = Log_Entry;
                da.InsertCommand.Parameters.Add("@PageName", SqlDbType.VarChar).Value = PageName;                
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                

                string msg = "Error in Insert Contract Logs Query" + " " + ex.Message;

                throw new Exception(msg, ex);

            }
        }
        return (rowsAffected);
    }*/
 public static int InsertContractLogs_India(string ProfileID, String ContractNo, string UpdatedField, string Username, string Log_Entry, string PageName,string description,string old_value,string new_value)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Contract_Logs_India values(@ProfileID,@ContractNo,@UpdatedField,@Username,@Log_Entry,@PageName,@description,@old_value,@new_value)", cs1);
                da.InsertCommand.Parameters.Add("@ProfileID  ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@UpdatedField", SqlDbType.VarChar).Value = UpdatedField;
                da.InsertCommand.Parameters.Add("@Username ", SqlDbType.VarChar).Value = Username;
                da.InsertCommand.Parameters.Add("@Log_Entry", SqlDbType.VarChar).Value = Log_Entry;
                da.InsertCommand.Parameters.Add("@PageName", SqlDbType.VarChar).Value = PageName;
                da.InsertCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                da.InsertCommand.Parameters.Add("@old_value", SqlDbType.VarChar).Value = old_value;
                da.InsertCommand.Parameters.Add("@new_value", SqlDbType.VarChar).Value = new_value;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                string msg = "Error in Insert Contract Logs Query" + " " + ex.Message;

                throw new Exception(msg, ex);

            }
        }
        return (rowsAffected);
    }


    public static SqlDataReader LoadCodeOnCountry(string country)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select Country_Code from Country  where country_name =@country union all select Country_Code from Country  where country_name !=@country", cs1);
        SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
    public static SqlDataReader LoadAllCodeOnCountry(string country)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select Country_Code from Country  where country_name =@country union all select Country_Code from Country  where country_name !=@country", cs1);
        SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }


    public static SqlDataReader LoadClubOnContractType(string conttype)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct Club_name from Contract_type_Club where Status='Active' and Contract_Type=@conttype", cs1);
        SqlCmd.Parameters.Add("@conttype", SqlDbType.VarChar).Value = conttype;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }

    public static SqlDataReader LoadPrimaryLang(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("SELECT Primary_Language FROM Profile_Primary WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }
    public static SqlDataReader LoadSecLang(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("SELECT Secondary_Language FROM Profile_Secondary WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }
    public static SqlDataReader LoadPhotoID(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select Photo_identity	from profile WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }
    public static SqlDataReader LoadCardType(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select  Card_Holder from profile  WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }


    //new changes by muriel

    public static DataSet LoadContractProfile(string contractno, string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select pp.ContractNo, prp.Profile_Primary_Title+' '+prp.Profile_Primary_Fname+' '+prp.Profile_Primary_Lname Name, REPLACE(ISNULL(CONVERT(varchar, pp.DealRegistered_Date,105), ''), '01-01-1900', '') as 'Deal Date',pp.contracttype [Contract Type], pp.DealStatus 'Deal Status', pp.Finance_Details 'Method',fd.Total_Price_Including_Tax 'Total price' ,p.profile_venue [Venue],p.profile_group_venue [Group Venue] from ContractDetails_Indian  pp join Profile_Primary prp on prp.Profile_ID = pp.ProfileID join Finance_Details_Indian fd on fd.ContractDetails_ID  = pp.ContractDetails_ID join Profile p on p.Profile_ID = pp.ProfileID  where p.office = @office and(pp.ContractNo like '%" + contractno + "%' or p.Profile_ID like '%" + contractno + "%' or prp.Profile_Primary_Fname like '%" + contractno + "%') order by pp.DealRegistered_Date", cs1);
            SqlCmd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static String GetProfileIDOnContractNo(string contractno)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select ProfileID  from ContractDetails_Indian where ContractNo =@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }

    public static DataSet LoadContractNoDetails(string contractno)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select *  from ContractDetails_Indian where ContractNo =@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadNewPointsDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand scd = new SqlCommand("select * from Contract_Points_Indian cp join Finance_Details_Indian f on f.ContractNo=cp.ContractNo   where  cp.ContractNo=@contractno", cs1);
            SqlCommand scd = new SqlCommand("select * from Contract_Points_Indian cp join Finance_Details_Indian f on f.ContractDetails_ID=cp.ContractDetails_ID   where  cp.ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadTradeinWeeksDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select * from Contract_Trade_In_Weeks_Indian cp join Finance_Details_Indian f on f.ContractNo=cp.ContractNo   where  cp.ContractNo=@contractno", cs1);
            SqlCommand scd = new SqlCommand("select * from Contract_Trade_In_Weeks_Indian cp join Finance_Details_Indian f on f.ContractDetails_ID=cp.ContractDetails_ID   where  cp.ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadTradeinPointsDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand scd = new SqlCommand("select * from Contract_Trade_In_Points_Indian cp join Finance_Details_Indian f on f.ContractNo=cp.ContractNo   where  cp.ContractNo=@contractno", cs1);
            SqlCommand scd = new SqlCommand("select * from Contract_Trade_In_Points_Indian cp join Finance_Details_Indian f on f.ContractDetails_ID=cp.ContractDetails_ID   where  cp.ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static int UpdateProfile(string ProfileID, string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple, string manager, string Photo_identity, string Card_Holder, string Comments)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Profile  SET Profile_Venue_Country= '" + Profile_Venue_Country + "', Profile_Venue= '" + Profile_Venue + "', Profile_Group_Venue= '" + Profile_Group_Venue + "', Profile_Marketing_Program= '" + Profile_Marketing_Program + "', Profile_Agent= '" + Profile_Agent + "', Profile_Agent_Code= '" + Profile_Agent_Code + "', Profile_Member_Type1= '" + Profile_Member_Type1 + "', Profile_Member_Number1= '" + Profile_Member_Number1 + "', Profile_Member_Type2= '" + Profile_Member_Type2 + "', Profile_Member_Number2= '" + Profile_Member_Number2 + "', Profile_Employment_status= '" + Profile_Employment_status + "', Profile_Marital_status= '" + Profile_Marital_status + "', Profile_NOY_Living_as_couple= '" + Profile_NOY_Living_as_couple + "', manager= '" + manager + "', Photo_identity= '" + Photo_identity + "', Card_Holder= '" + Card_Holder + "' , Comments= '" + Comments + "' where Profile_ID ='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


 public static int InsertContractDetails_Indian(string ContractNo, string ProfileID, string Sales_Rep, string TO_Manager, string ButtonUp_Officer, string DealRegistered_Date, string DealStatus, string Contract_CreatedDate, string Contract_UpdatedDate, string ContractType, string MCWaiver, string Finance_Details, string Contract_Remark, string Pan_Card, string Adhar_Card, string MC_Charges, string First_MC_Payable_Date, string MemberFee, string MemberCGST, string MembersGST, string CanxContractNo, string ContractDetails_ID, string Contract_Canx_date, string Loan_BU_officer, string Client_GSTIN, string Company_PanNo, string dealweekno,string deckdetails,string deckremark,string Contract_comment,string Contract_createdUser,string BU_A6,string Updowngrade,
         string Expirydate,string Commence_date,string Contract_group,string Contract_Venue,string Returnhomedate,string Finance_mailingAddress)
    {
        int rowsAffected = 0; 
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
           
            da.InsertCommand = new SqlCommand("insert into ContractDetails_Indian values(@ContractNo,@ProfileID,@Sales_Rep,@TO_Manager,@ButtonUp_Officer,convert(datetime,@DealRegistered_Date,105),@DealStatus,@Contract_CreatedDate,@Contract_UpdatedDate ,@ContractType ,	@MCWaiver,	@Finance_Details ,	@Contract_Remark ,	@Pan_Card ,	@Adhar_Card,@MC_Charges,  @First_MC_Payable_Date,@MemberFee,@MemberCGST,@MembersGST,@CanxContractNo,@ContractDetails_ID,convert(datetime,@Contract_Canx_date,105),@Loan_BU_officer,@Client_GSTIN,@Company_PanNo,@dealweekno,@deckdetails, @deckremark,@Contract_comment,@Contract_createdUser,@BU_A6,@Updowngrade,@Expirydate, @Commence_date, @Contract_group, @Contract_Venue,@Returnhomedate,@Finance_mailingAddress)", cs1);
            da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
            da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da.InsertCommand.Parameters.Add("@Sales_Rep", SqlDbType.VarChar).Value = Sales_Rep;
            da.InsertCommand.Parameters.Add("@TO_Manager", SqlDbType.VarChar).Value = TO_Manager;
            da.InsertCommand.Parameters.Add("@ButtonUp_Officer", SqlDbType.VarChar).Value = ButtonUp_Officer;
            da.InsertCommand.Parameters.Add("@DealRegistered_Date", SqlDbType.VarChar).Value = DealRegistered_Date;
            da.InsertCommand.Parameters.Add("@DealStatus", SqlDbType.VarChar).Value = DealStatus;
            da.InsertCommand.Parameters.Add("@Contract_CreatedDate", SqlDbType.VarChar).Value = Contract_CreatedDate;
            da.InsertCommand.Parameters.Add("@Contract_UpdatedDate", SqlDbType.VarChar).Value = Contract_UpdatedDate;
            da.InsertCommand.Parameters.Add("@ContractType ", SqlDbType.VarChar).Value = ContractType;
            da.InsertCommand.Parameters.Add("@MCWaiver", SqlDbType.VarChar).Value = MCWaiver;
            da.InsertCommand.Parameters.Add("@Finance_Details", SqlDbType.VarChar).Value = Finance_Details;
            da.InsertCommand.Parameters.Add("@Contract_Remark", SqlDbType.VarChar).Value = Contract_Remark;
            da.InsertCommand.Parameters.Add("@Pan_Card", SqlDbType.VarChar).Value = Pan_Card;
            da.InsertCommand.Parameters.Add("@Adhar_Card", SqlDbType.VarChar).Value = Adhar_Card;
            da.InsertCommand.Parameters.Add("@MC_Charges", SqlDbType.VarChar).Value = MC_Charges;
            da.InsertCommand.Parameters.Add("@First_MC_Payable_Date", SqlDbType.VarChar).Value = First_MC_Payable_Date;
            da.InsertCommand.Parameters.Add("@MemberFee", SqlDbType.VarChar).Value = MemberFee;
            da.InsertCommand.Parameters.Add("@MemberCGST", SqlDbType.VarChar).Value = MemberCGST;
            da.InsertCommand.Parameters.Add("@MembersGST", SqlDbType.VarChar).Value = MembersGST;
            da.InsertCommand.Parameters.Add("@CanxContractNo", SqlDbType.VarChar).Value = CanxContractNo;
            da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da.InsertCommand.Parameters.Add("@Contract_Canx_date", SqlDbType.VarChar).Value = Contract_Canx_date;
            da.InsertCommand.Parameters.Add("@Loan_BU_officer", SqlDbType.VarChar).Value = Loan_BU_officer;
            da.InsertCommand.Parameters.Add("@Client_GSTIN", SqlDbType.VarChar).Value = Client_GSTIN;
            da.InsertCommand.Parameters.Add("@Company_PanNo", SqlDbType.VarChar).Value = Company_PanNo;
		    da.InsertCommand.Parameters.Add("@dealweekno", SqlDbType.VarChar).Value = dealweekno;
            da.InsertCommand.Parameters.Add("@deckdetails", SqlDbType.VarChar).Value = deckdetails;
            da.InsertCommand.Parameters.Add("@deckremark", SqlDbType.VarChar).Value = deckremark;
            da.InsertCommand.Parameters.Add("@Contract_comment", SqlDbType.VarChar).Value = Contract_comment;
            da.InsertCommand.Parameters.Add("@Contract_createdUser", SqlDbType.VarChar).Value = Contract_createdUser;
            da.InsertCommand.Parameters.Add("@BU_A6", SqlDbType.VarChar).Value = BU_A6;
            da.InsertCommand.Parameters.Add("@Updowngrade", SqlDbType.VarChar).Value = Updowngrade;
            da.InsertCommand.Parameters.Add("@Expirydate", SqlDbType.VarChar).Value = Expirydate;
            da.InsertCommand.Parameters.Add("@Commence_date", SqlDbType.VarChar).Value = Commence_date;
            da.InsertCommand.Parameters.Add("@Contract_group", SqlDbType.VarChar).Value = Contract_group;
            da.InsertCommand.Parameters.Add("@Contract_Venue", SqlDbType.VarChar).Value = Contract_Venue;
            da.InsertCommand.Parameters.Add("@Returnhomedate", SqlDbType.VarChar).Value = Returnhomedate;
            da.InsertCommand.Parameters.Add("@Finance_mailingAddress", SqlDbType.VarChar).Value = Finance_mailingAddress;
            rowsAffected = da.InsertCommand.ExecuteNonQuery();
        }
        return (rowsAffected);
    }

    // new functions for sub profile 3 //

    public static DataSet LoadSub_Profile3Salutation(string ProfileID,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as Salutation UNION select Salutation from Salutations where status='active' and office=@office and Salutation not in(select Sub_Profile3_Title  from Sub_Profile3 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
 SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSub_Profile3Nationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as  Nationality_Name UNION select Nationality_Name from  Nationality where Nationality_Name not in(select Sub_Profile3_Nationality  from Sub_Profile3 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountrySP3(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct ' ' as  country_name UNION select Country_Name   from country where country_name not in(select Sub_Profile3_Country  from Sub_Profile3 where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountryWithCodeSP3Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //   SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile3_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountryWithCodeSP3Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile3_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    // end//


    // sub profile 4 new functions//
    public static DataSet LoadSub_Profile4Salutation(string ProfileID,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as Salutation UNION select Salutation from Salutations where status='active' and office=@office and Salutation not in(select Sub_Profile4_Title  from Sub_Profile4 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSub_Profile4Nationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ' ' as  Nationality_Name UNION select Nationality_Name from Nationality where Nationality_Name not in(select Sub_Profile4_Nationality  from Sub_Profile4 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountrySP4(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select distinct ' ' as  country_name UNION select Country_Name   from country where country_name not in(select Sub_Profile4_Country  from Sub_Profile4 where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountryWithCodeSP4Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {


            //SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile4_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountryWithCodeSP4Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
           
//            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile4_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataTable FractionalTradeIn_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PA_Fractional_TradeIn_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }





    public static DataSet LoadContractType_Edit(string contractno, string office)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select ContractType_name from ContractType where office = @office and ContractType_name not in(select ContractType from ContractDetails_Indian where contractno=@contractno)", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadCurrency_Edit(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand scd = new SqlCommand("select Finance_Currency_Name from Finance_Currency  where Finance_Currency_Name not in(select Currency from Finance_Details_Indian  where contractno=@contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Finance_Currency_Name from Finance_Currency  where Finance_Currency_Name not in(select Currency from Finance_Details_Indian  where ContractDetails_ID=@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;

            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadFinanceContractDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand(" select *  from Finance_Details_Indian where ContractNo =@contractno", cs1);
            SqlCommand scd = new SqlCommand(" select *  from Finance_Details_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet pointsentitlement(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select Entitlement_Name from Entitlement where Entitlement_Status='Active' and Entitlement_Name not in(select Type_membership from Contract_Points_Indian where contractno=@contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Entitlement_Name from Entitlement where Entitlement_Status='Active' and Entitlement_Name not in(select Type_membership from Contract_Points_Indian where ContractDetails_ID=@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet contractdealstatus(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select Status_Type from DealStatus where status = 'active' and Status_Type not in(select DealStatus  from ContractDetails_Indian where contractno = @contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Status_Type from DealStatus where status = 'active' and Status_Type not in(select DealStatus  from ContractDetails_Indian where ContractDetails_ID = @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet currencyfinancedetails(string ContractDetails_ID, string office)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select Finance_Currency_Name from Finance_Office where status='active' and office=@office and Finance_Currency_Name not in(Select currency from Finance_Details_Indian where ContractNo= @contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Finance_Currency_Name from Finance_Office where status='active' and office=@office and Finance_Currency_Name not in(Select currency from Finance_Details_Indian where ContractDetails_ID= @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet paymethodfinancedetails(string ContractDetails_ID, string office)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select pay_method_name from pay_method where pay_method_status = 'active' and office = @office and pay_method_name not in(Select Payment_Method from Finance_Details_Indian where ContractNo = @contractno)", cs1);
            SqlCommand scd = new SqlCommand("select pay_method_name from pay_method where pay_method_status = 'active' and office = @office and pay_method_name not in(Select Payment_Method from Finance_Details_Indian where ContractDetails_ID = @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet financemethodfinancedetails(string ContractDetails_ID, string office)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand scd = new SqlCommand("select Finance_Name  from FinanceMethod where Finance_Status='active' and office=@Office and Finance_Name not in(select Finance_Type from Finance_Details_Indian where ContractNo= @contractno)", cs1);
            SqlCommand scd = new SqlCommand("select distinct Finance_Name  from FinanceMethod where Finance_Status='active' and office=@Office and Finance_Name not in(select Finance_Type from Finance_Details_Indian where ContractDetails_ID= @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet contractPA(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select * from Contract_PA_Indian  where ContractNo= @contractno", cs1);
            SqlCommand scd = new SqlCommand("select * from Contract_PA_Indian  where ContractDetails_ID= @ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet contractInstallment(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand(" select  Installment_no[Installment_No], Installment_Amount [Installment_Amount],convert(date, Installment_Date) Installment_Date, Installment_Invoice_No [Installment_Invoice_No]  from Contract_Installments_Indian   where ContractNo=@contractno", cs1);
            SqlCommand scd = new SqlCommand(" select  Installment_no[Installment_No], Installment_Amount [Installment_Amount],convert(date, Installment_Date) Installment_Date, Installment_Invoice_No [Installment_Invoice_No]  from Contract_Installments_Indian   where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet tradeinpointsentitlement(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand scd = new SqlCommand("select Entitlement_Name from Entitlement where Entitlement_Status='Active' and Entitlement_Name not in(select New_MemebrshipType from Contract_Trade_In_Points_Indian where contractno=@contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Entitlement_Name from Entitlement where Entitlement_Status='Active' and Entitlement_Name not in(select New_MemebrshipType from Contract_Trade_In_Points_Indian where ContractDetails_ID=@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet tradeinwksentitlement(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select Entitlement_Name from Entitlement where Entitlement_Status='Active' and Entitlement_Name not in(select NewPointsW_MemebrshipType from Contract_Trade_In_Weeks_Indian where contractno=@contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Entitlement_Name from Entitlement where Entitlement_Status='Active' and Entitlement_Name not in(select NewPointsW_MemebrshipType from Contract_Trade_In_Weeks_Indian where ContractDetails_ID=@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet tradeinwksseason(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select Season_Name from Seasons where Season_Status='active' and Season_Name not in(select Trade_In_Weeks_Season from Contract_Trade_In_Weeks_Indian where contractno=@contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Season_Name from Seasons where Season_Status='active' and Season_Name not in(select Trade_In_Weeks_Season from Contract_Trade_In_Weeks_Indian where ContractDetails_ID=@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet loadtradeinfractional(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select *,cfi.RESORT tradeinresort from  Contract_Fractional_Indian ctf left outer join Contract_Trade_In_Fractional_Indian  cfi on cfi.ContractNo = ctf.ContractNo left outer join ContractDetails_Indian ct on ct.ContractNo = cfi.ContractNo  where ctf.ContractNo = @contractno", cs1);
            SqlCommand scd = new SqlCommand("select *,cfi.RESORT tradeinresort from  Contract_Fractional_Indian ctf left outer join Contract_Trade_In_Fractional_Indian  cfi on cfi.ContractDetails_ID = ctf.ContractDetails_ID left   join ContractDetails_Indian ct on ct.ContractDetails_ID = ctf.ContractDetails_ID  left join  Finance_Details_Indian fd on fd.ContractDetails_ID = ct.ContractDetails_ID left join Contract_Fractional_PA_Indian fpa on fpa.contractdetails_id=ctf.contractdetails_id  where ctf.ContractDetails_ID = @ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet loadtradeinfractionalResort(string ContractDetails_ID, string office)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("SELECT Contract_Resort_Name  FROM Contract_Resort  where Contract_Resort_Status ='Active' and office =@office and Contract_Resort_Name not in(select resort from Contract_Fractional_Indian where contractno = @contractno)", cs1);
            SqlCommand scd = new SqlCommand("SELECT Contract_Resort_Name  FROM Contract_Resort  where Contract_Resort_Status ='Active' and office =@office and Contract_Resort_Name not in(select resort from Contract_Fractional_Indian where ContractDetails_ID = @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }


    public static DataSet loadtradeinfractionalResidence(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand(" SELECT [Contract_Residence_Name]  FROM[Contract_Residence_No]  crn join[Contract_Resort] cr on cr.[Contract_Resort_ID] = crn.Contract_Resort_ID where[Contract_Residence_Status] = 'active' and[Contract_Residence_Name] not in (select residence_no from Contract_Fractional_Indian where contractno = @contractno)", cs1);
            SqlCommand scd = new SqlCommand(" SELECT [Contract_Residence_Name]  FROM[Contract_Residence_No]  crn join[Contract_Resort] cr on cr.[Contract_Resort_ID] = crn.Contract_Resort_ID where[Contract_Residence_Status] = 'active' and[Contract_Residence_Name] not in (select residence_no from Contract_Fractional_Indian where ContractDetails_ID = @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet loadtradeinfractionalResidencetype(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("SELECT [Contract_Resi_Type_Name] FROM[Contract_Residence_Type] crt join  contract_Residence_No crn on crn.Contract_Residence_ID = crt.Contract_Residence_ID where[Contract_Resi_Type_Status] = 'active' and  Contract_Resi_Type_Name not in(select residence_type from Contract_Fractional_Indian where contractno = @contractno)", cs1);
            SqlCommand scd = new SqlCommand("SELECT [Contract_Resi_Type_Name] FROM[Contract_Residence_Type] crt join  contract_Residence_No crn on crn.Contract_Residence_ID = crt.Contract_Residence_ID where[Contract_Resi_Type_Status] = 'active' and  Contract_Resi_Type_Name not in(select residence_type from Contract_Fractional_Indian where ContractDetails_ID = @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet loadtradeinfractionalFractionalInt(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("SELECT [Contract_Fractional_Int_Name]FROM[Contract_Fractional_Int] where[Contract_Fractional_Int_Status] = 'active' and Contract_Fractional_Int_Name not in(select fractional_interest from Contract_Fractional_Indian where contractno = @contractno)", cs1);
            SqlCommand scd = new SqlCommand("SELECT [Contract_Fractional_Int_Name]FROM[Contract_Fractional_Int] where[Contract_Fractional_Int_Status] = 'active' and Contract_Fractional_Int_Name not in(select fractional_interest from Contract_Fractional_Indian where ContractDetails_ID = @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet tradeinfractionalentitlement(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand scd = new SqlCommand("select Entitlement_Name from Entitlement where Entitlement_Status='Active' and Entitlement_Name not in(select entitlement from Contract_Fractional_Indian where contractno=@contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Entitlement_Name from Entitlement where Entitlement_Status='Active' and Entitlement_Name not in(select entitlement from Contract_Fractional_Indian where ContractDetails_ID=@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet tradeinfractionalseason(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select Season_Name from Seasons where Season_Status = 'active' and Season_Name not in(select Season from Contract_Trade_In_Fractional_Indian where contractno=@contractno)", cs1);
            SqlCommand scd = new SqlCommand("select Season_Name from Seasons where Season_Status = 'active' and Season_Name not in(select Season from Contract_Trade_In_Fractional_Indian where ContractDetails_ID=@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadfractionalPA(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select* from Contract_Fractional_PA_Indian where ContractNo=@contractno", cs1);
            SqlCommand scd = new SqlCommand("select* from Contract_Fractional_PA_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

  public static int UpdateContractDetails_Indian(string Sales_Rep, string TO_Manager, string ButtonUp_Officer, string DealRegistered_Date, string DealStatus, string MCWaiver, string Finance_Details,  string MC_Charges, string First_MC_Payable_Date, string MemberFee, string MemberCGST, string MembersGST, string CanxContractNo, string Contract_Canx_date, string Loan_BU_officer, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                //SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET Sales_Rep= '" + Sales_Rep + "',	TO_Manager= '" + TO_Manager + "',ButtonUp_Officer = '" + ButtonUp_Officer + "', DealRegistered_Date =convert(datetime, '" + DealRegistered_Date + "',105),DealStatus = '" + DealStatus + "', MCWaiver = '" + MCWaiver + "', Finance_Details = '" + Finance_Details + "', pan_card = '" + pan_card + "', Adhar_Card = '" + Adhar_Card + "', MC_Charges = '" + MC_Charges + "', First_MC_Payable_Date =convert(datetime, '" + First_MC_Payable_Date + "',105), MemberFee = '" + MemberFee + "', MemberCGST = '" + MemberCGST + "', MembersGST = '" + MembersGST + "',contractno='" + contractno + "',CanxContractNo='" + CanxContractNo + "',Contract_Canx_date=convert(datetime,'" + Contract_Canx_date + "',105) ,Loan_BU_officer='" + Loan_BU_officer + "'   where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                //  scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET Sales_Rep= '" + Sales_Rep + "',	TO_Manager= '" + TO_Manager + "',ButtonUp_Officer = '" + ButtonUp_Officer + "', DealRegistered_Date =convert(datetime, '" + DealRegistered_Date + "',105),DealStatus = '" + DealStatus + "', MCWaiver = '" + MCWaiver + "', Finance_Details = '" + Finance_Details + "',  MC_Charges = '" + MC_Charges + "', First_MC_Payable_Date =convert(datetime, '" + First_MC_Payable_Date + "',105), MemberFee = '" + MemberFee + "', MemberCGST = '" + MemberCGST + "', MembersGST = '" + MembersGST + "', CanxContractNo='" + CanxContractNo + "',Contract_Canx_date='"+Contract_Canx_date+"' ,Loan_BU_officer='" + Loan_BU_officer + "'   where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                 scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                string msg = "Error in UPDATE UpdateContractDetails_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);
 
            }

        }
        return rows;
    }
    public static int UpdateFinanceDetails_Indian(string Finance_Method, string Currency, string Affiliate_Type, string Total_Price_Including_Tax, string Initial_Deposit_Percent, string Initial_Deposit_Amount, string Balance_Payable, string Total_Inital_Deposit, string Initial_Deposit_Balance, string Bal_Amount_Payable, string Payment_Method, string No_Installments, string Installment_Amount, string Finance_Type, string Finance_No, string IGSTrate, string Interestrate, string documentationfee, string IGST_Amount, string No_Emi, string Emi_Installment, string financeMonth, string Old_Loan_AgreementNo, string Registry_Collection_Term, string Registry_Collection_Amt, string BalanceDeposit_Date, string Old_Loan_Amount, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Finance_Details_Indian  SET Finance_Method= '" + Finance_Method + "',	Currency= '" + Currency + "',Affiliate_Type = '" + Affiliate_Type + "', Total_Price_Including_Tax = '" + Total_Price_Including_Tax + "',Initial_Deposit_Percent = '" + Initial_Deposit_Percent + "', Initial_Deposit_Amount = '" + Initial_Deposit_Amount + "', Balance_Payable = '" + Balance_Payable + "', Total_Inital_Deposit = '" + Total_Inital_Deposit + "', Initial_Deposit_Balance = '" + Initial_Deposit_Balance + "', Bal_Amount_Payable = '" + Bal_Amount_Payable + "', Payment_Method = '" + Payment_Method + "', No_Installments ='" + No_Installments + "',Installment_Amount='" + Installment_Amount + "',  Finance_Type='" + Finance_Type + "',Finance_No='" + Finance_No + "',IGSTrate='" + IGSTrate + "',Interestrate='" + Interestrate + "',documentationfee='" + documentationfee + "',IGST_Amount='" + IGST_Amount + "',No_Emi='" + No_Emi + "', Emi_Installment='" + Emi_Installment + "', financeMonth='" + financeMonth + "', Old_Loan_AgreementNo='" + Old_Loan_AgreementNo + "' ,    Registry_Collection_Term='" + Registry_Collection_Term + "' ,    Registry_Collection_Amt='" + Registry_Collection_Amt + "' ,  BalanceDeposit_Date=convert(datetime,'" + BalanceDeposit_Date + "',105) ,Old_Loan_Amount='" + Old_Loan_Amount + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

              

                string msg = "Error in UPDATE UpdateFinanceDetails_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateContract_PA_Indian(string New_Points_Price, string Conversion_Fee, string Admin_Fee, string Total_Purchase_Price, string Cgst, string Sgst, string Total_Price_Including_Tax, string Deposit, string Balance, string Balance_Due_Dates, string Remarks,  string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_PA_Indian  SET New_Points_Price = '" + New_Points_Price + "', Conversion_Fee = '" + Conversion_Fee + "',Admin_Fee = '" + Admin_Fee + "',Total_Purchase_Price = '" + Total_Purchase_Price + "', Cgst = '" + Cgst + "',Sgst = '" + Sgst + "',Total_Price_Including_Tax = '" + Total_Price_Including_Tax + "', Deposit = '" + Deposit + "',Balance = '" + Balance + "', Balance_Due_Dates = '" + Balance_Due_Dates + "',Remarks = '" + Remarks + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

              

                string msg = "Error in UPDATE UpdateContract_PA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateContract_Points_Indian(string club, string New_points_rights, string Type_membership, string Total_points_rights, string First_year_occupancy, string Tenure, string Last_year_occupancy, string NoPersons, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Points_Indian  SET   club = '" + club + "', New_points_rights = '" + New_points_rights + "',Type_membership = '" + Type_membership + "',Total_points_rights = '" + Total_points_rights + "',First_year_occupancy = '" + First_year_occupancy + "', Tenure = '" + Tenure + "',Last_year_occupancy = '" + Last_year_occupancy + "',NoPersons='"+ NoPersons+"' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                

                string msg = "Error in UPDATE UpdateContract_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static int UpdateContract_Trade_In_Points_Indian(string Trade_In_Details_club_resort, string Trade_In_Details_No_rights, string Trade_In_Details_ContNo_RCINo, string Trade_In_Details_Points_value, string New_Club, string New_Club_Points_Rights, string New_MemebrshipType, string New_TotalPointsRights, string New_First_year_occupancy, string New_Tenure, string New_Last_year_occupancy, string ContractDetails_ID,string Actualpoints_value,string NoPersons,string OldMemtype)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                //SqlCommand scd = new SqlCommand("update Contract_Trade_In_Points_Indian  SET Trade_In_Details_club_resort = '" + Trade_In_Details_club_resort + "', Trade_In_Details_No_rights = '" + Trade_In_Details_No_rights + "',Trade_In_Details_ContNo_RCINo = '" + Trade_In_Details_ContNo_RCINo + "',Trade_In_Details_Points_value = '" + Trade_In_Details_Points_value + "',New_Club = '" + New_Club + "', New_Club_Points_Rights = '" + New_Club_Points_Rights + "',New_MemebrshipType = '" + New_MemebrshipType + "', New_TotalPointsRights = '" + New_TotalPointsRights + "',New_First_year_occupancy = '" + New_First_year_occupancy + "', New_Tenure = '" + New_Tenure + "',New_Last_year_occupancy = '" + New_Last_year_occupancy + "' where contractno = '" + contractno + "'", cs1);
                SqlCommand scd = new SqlCommand("update Contract_Trade_In_Points_Indian  SET Trade_In_Details_club_resort = '" + Trade_In_Details_club_resort + "', Trade_In_Details_No_rights = '" + Trade_In_Details_No_rights + "',Trade_In_Details_ContNo_RCINo = '" + Trade_In_Details_ContNo_RCINo + "',Trade_In_Details_Points_value = '" + Trade_In_Details_Points_value + "',Actualpoints_value='"+ Actualpoints_value+"', New_Club = '" + New_Club + "', New_Club_Points_Rights = '" + New_Club_Points_Rights + "',New_MemebrshipType = '" + New_MemebrshipType + "', New_TotalPointsRights = '" + New_TotalPointsRights + "',New_First_year_occupancy = '" + New_First_year_occupancy + "', New_Tenure = '" + New_Tenure + "',New_Last_year_occupancy = '" + New_Last_year_occupancy + "', NoPersons='"+ NoPersons+ "',OldMemtype='"+ OldMemtype+"'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               

                string msg = "Error in UPDATE UpdateContract_Trade_In_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
  public static int UpdateContract_Trade_In_Weeks_Indian(string Trade_In_Weeks_resort, string Trade_In_Weeks_Apt, string Trade_In_Weeks_Season, string Trade_In_Weeks_NoWks, string Trade_In_Weeks_ContNo_RCINo, string Trade_In_Weeks_Points_value, string NewPointsW_Club, string NewPointsW_Club_Points_Rights, string NewPointsW_MemebrshipType, string NewPointsW_Total_Points_rights, string NewPointsW_First_year_occupancy, string NewPointsW_Tenure, string NewPointsW_Last_year_occupancy, string NoPersons, string ContractDetails_ID,string OldMemtype)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Trade_In_Weeks_Indian  SET Trade_In_Weeks_resort = '" + Trade_In_Weeks_resort + "', Trade_In_Weeks_Apt = '" + Trade_In_Weeks_Apt + "',Trade_In_Weeks_Season = '" + Trade_In_Weeks_Season + "', Trade_In_Weeks_NoWks = '" + Trade_In_Weeks_NoWks + "', Trade_In_Weeks_ContNo_RCINo = '" + Trade_In_Weeks_ContNo_RCINo + "', Trade_In_Weeks_Points_value = '" + Trade_In_Weeks_Points_value + "',NewPointsW_Club = '" + NewPointsW_Club + "', NewPointsW_Club_Points_Rights = '" + NewPointsW_Club_Points_Rights + "', NewPointsW_MemebrshipType = '" + NewPointsW_MemebrshipType + "', NewPointsW_Total_Points_rights = '" + NewPointsW_Total_Points_rights + "',NewPointsW_First_year_occupancy = '" + NewPointsW_First_year_occupancy + "', NewPointsW_Tenure = '" + NewPointsW_Tenure + "', NewPointsW_Last_year_occupancy = '" + NewPointsW_Last_year_occupancy + "',  NoPersons='"+ NoPersons+ "',OldMemtype='" + OldMemtype + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                //SqlCommand scd = new SqlCommand("update Contract_Trade_In_Weeks_Indian  SET Trade_In_Weeks_resort = '" + Trade_In_Weeks_resort + "', Trade_In_Weeks_Apt = '" + Trade_In_Weeks_Apt + "',Trade_In_Weeks_Season = '" + Trade_In_Weeks_Season + "', Trade_In_Weeks_NoWks = '" + Trade_In_Weeks_NoWks + "', Trade_In_Weeks_ContNo_RCINo = '" + Trade_In_Weeks_ContNo_RCINo + "', Trade_In_Weeks_Points_value = '" + Trade_In_Weeks_Points_value + "',NewPointsW_Club = '" + NewPointsW_Club + "', NewPointsW_Club_Points_Rights = '" + NewPointsW_Club_Points_Rights + "', NewPointsW_MemebrshipType = '" + NewPointsW_MemebrshipType + "', NewPointsW_Total_Points_rights = '" + NewPointsW_Total_Points_rights + "',NewPointsW_First_year_occupancy = '" + NewPointsW_First_year_occupancy + "', NewPointsW_Tenure = '" + NewPointsW_Tenure + "', NewPointsW_Last_year_occupancy = '" + NewPointsW_Last_year_occupancy + "' where contractno = '" + contractno + "'", cs1);

                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               

                string msg = "Error in UPDATE UpdateContract_Trade_In_Weeks_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

    
            }

        }
        return rows;
    }

    public static int UpdateContract_FractionalPA_Indian(string Admission_fees, string administration_fees, string Total_Purchase_Price, string Cgst, string Sgst, string Total_Price_Including_Tax, string Deposit, string Balance, string Balance_Due_Dates, string Remarks, string TradeIn_value, string Total_value, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Fractional_PA_Indian  SET Admission_fees = '" + Admission_fees + "', administration_fees = '" + administration_fees + "',Total_Purchase_Price = '" + Total_Purchase_Price + "', Cgst = '" + Cgst + "',Sgst = '" + Sgst + "',Total_Price_Including_Tax = '" + Total_Price_Including_Tax + "', Deposit = '" + Deposit + "',Balance = '" + Balance + "', Balance_Due_Dates = '" + Balance_Due_Dates + "',Remarks = '" + Remarks + "',  TradeIn_value= '" + TradeIn_value + "',	Total_value= '" + Total_value + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateContract_FractionalPA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

               
            }

        }
        return rows;
    }

    public static int UpdateContract_Fractional_Indian(string resort, string residence_no, string residence_type, string fractional_interest, string entitlement, string firstyear_Occupancy, string tenure, string lastyear_Occupancy, string leaseback, string Mc_Charges, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {


                SqlCommand scd = new SqlCommand("update Contract_Fractional_Indian  SET resort = '" + resort + "', residence_no = '" + residence_no + "',residence_type = '" + residence_type + "',fractional_interest = '" + fractional_interest + "', entitlement = '" + entitlement + "',firstyear_Occupancy = '" + firstyear_Occupancy + "', tenure = '" + tenure + "', lastyear_Occupancy = '" + lastyear_Occupancy + "', leaseback = '" + leaseback + "', Mc_Charges = '" + Mc_Charges + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 

                string msg = "Error in UPDATE UpdateContract_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

               
            }

        }
        return rows;
    }

   public static int UpdateContract_Trade_In_Fractional_Indian(string Oldcontracttype, string RESORT, string APT_TYPE, string SEASON, string NO_WEEKS, string NO_POINTS, string POINTS_VALUE, string oldContract_No, string ContractDetails_ID,string OldMemtype)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {


                SqlCommand scd = new SqlCommand("update Contract_Trade_In_Fractional_Indian  SET Oldcontracttype = '" + Oldcontracttype + "', RESORT = '" + RESORT + "',APT_TYPE = '" + APT_TYPE + "', SEASON = '" + SEASON + "', NO_WEEKS = '" + NO_WEEKS + "', NO_POINTS = '" + NO_POINTS + "', POINTS_VALUE = '" + POINTS_VALUE + "', oldContract_No = '" + oldContract_No + "',OldMemtype='"+ OldMemtype+"'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               

                string msg = "Error in UPDATE Contract_Trade_In_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);
                 
            }

        }
        return rows;
    }
    public static int UpdateFinanceNoFromNFtoF(string venue, string finance, string contracttype)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                if (contracttype == "Fractional" || contracttype == "Trade-In-Fractionals")
                {
                    SqlCommand scd1 = new SqlCommand("select FinanceIncrval  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType='Fractional'", cs1);
                    scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                    scd1.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) - 1;
                    SqlCommand sqlcmd = new SqlCommand("update cc set cc.FinanceIncrval=@id from FinanceMethod_Venue cc  where  venue=@venue and FinanceMethod_Name=@finance and ContractType='Fractional'", cs1);
                    sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                    sqlcmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                    sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    rows = sqlcmd.ExecuteNonQuery();

                }
                else
                {
                    SqlCommand scd11 = new SqlCommand("select FinanceIncrval  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType!='Fractional'", cs1);
                    scd11.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                    scd11.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                    string val = (string)scd11.ExecuteScalar();
                    id = Convert.ToInt32(val) - 1;
                    SqlCommand sqlcmd = new SqlCommand("update cc set cc.FinanceIncrval=@id from FinanceMethod_Venue cc  where  venue=@venue and FinanceMethod_Name=@finance and ContractType!='Fractional'", cs1);
                    sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                    sqlcmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                    sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    rows = sqlcmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE FinanceMethod_Venue Query " + ex.Message);

                string msg = "Error in UPDATE FinanceMethod_Venue Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static DataSet DisplayDealstatus()
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select status_type from DealStatus where status='Active'", cs1);

            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    //public static DataSet   GetfinanceStartdate(string contractno)
    //{


    //    int mon, yr;
    //    string financemonth;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //            SqlCommand scd1 = new SqlCommand("select max(Installment_Date) from Contract_Installments_Indian where ContractNo=@contractno", cs1);
    //            scd1.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;

    //            DateTime val = (DateTime)scd1.ExecuteScalar();
    //            DateTime fdat = Convert.ToDateTime(val);
    //            int month = fdat.Month;
    //            int year = fdat.Year;
    //            if (month == 12)
    //            {
    //                mon = 1;
    //                yr = year + 1;
    //                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mon); //CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName()
    //                                                                                                        // DateTime.Now.ToString("MMM", CultureInfo.CurrentCulture);
    //                                                                                                        //   int mno = DateTime.ParseExact(value, "MMMM", CultureInfo.CurrentCulture).Month;
    //                financemonth = month1 + " " + yr;

    //            }
    //            else
    //            {
    //                mon = month + 1;
    //            string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mon);//  GetAbbreviatedMonthName(mon);
    //                financemonth = month1 + " " + year;
    //            }





    //    }
    //    return financemonth;
    //}

    public static int ContractNoInInstallmentTable(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand(" select contractno from Contract_Installments_Indian where contractno=@contractno", cs1);
            SqlCommand scd = new SqlCommand(" select ContractDetails_ID from Contract_Installments_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

     public static int InsertContract_Installments_Indian_Deleted(string Installment_ID, string ProfileID, string ContractNo, string Installment_no, string Installment_Amount, string Installment_Date, string Installment_Invoice_No, string DeleteDate, string ContractDetails_ID,string Paymentmode)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Installments_Indian_Deleted values(@Installment_ID,@ProfileID,	@ContractNo,@Installment_no,@Installment_Amount,@Installment_Date,@Installment_Invoice_No,@DeleteDate,@ContractDetails_ID,@Paymentmode)", cs1);

                da.InsertCommand.Parameters.Add("@Installment_ID ", SqlDbType.VarChar).Value = Installment_ID;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Installment_no", SqlDbType.VarChar).Value = Installment_no;
                da.InsertCommand.Parameters.Add("@Installment_Amount", SqlDbType.VarChar).Value = Installment_Amount;
                da.InsertCommand.Parameters.Add("@Installment_Date", SqlDbType.VarChar).Value = Installment_Date;
                da.InsertCommand.Parameters.Add("@Installment_Invoice_No", SqlDbType.VarChar).Value = Installment_Invoice_No;
                da.InsertCommand.Parameters.Add("@DeleteDate", SqlDbType.VarChar).Value = DeleteDate;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@Paymentmode", SqlDbType.VarChar).Value = Paymentmode;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
 

                string msg = "Error in Insert InsertContract_Installments_Indian_Deleted Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static DataSet LoadcontractInstallment(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand(" select  *  from Contract_Installments_Indian   where ContractNo=@contractno", cs1);
            SqlCommand scd = new SqlCommand(" select  *  from Contract_Installments_Indian   where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int DeleteContract_Installments_Indian(string recid)
    {
        int rows = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqlcmd = new SqlCommand(" delete from  Contract_Installments_Indian where installment_id=@recid", cs1);
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@recid";
            para.Value = recid;
            sqlcmd.Parameters.Add(para);
            rows = sqlcmd.ExecuteNonQuery();
        }
        return rows;
    }

    public static string GetContractDetails_Indian()
    {
        string ContractDetails_Id = "";
        string startvalue = "CD_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractDetails_ID, 6, len(ContractDetails_ID)))from ContractDetails_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractDetails_Id = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractDetails_Id = startvalue + id;

                }

            }
        }
        return ContractDetails_Id;


    }
    public static string GetContract_Indian_Deposit_ReceiptID()
    {
        string Deposit_Receipt_Id = "";
        string startvalue = "DP_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Deposit_Receipt_Id, 6, len(Deposit_Receipt_Id)))from Contract_Indian_Deposit_Receipt", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Deposit_Receipt_Id = startvalue + id;
                }
                else
                {
                    id = 1;
                    Deposit_Receipt_Id = startvalue + id;

                }

            }
        }
        return Deposit_Receipt_Id;


    }
   public static int InsertContract_Indian_Deposit_Receipt(string Deposit_Receipt_Id, string ContractDetails_ID, string ContractNo, string Receipt_No, string Receipt_Date, string place_supply, string state, string state_code, string Product_Name, string SAC, string Amount, string taxable_value, string cgstrate, string cgstamt, string sgstrate, string sgstamt, string totalamt, string Payment_Mode,string actual_currency,string converted_currency,string Converted_rate,string ExchangedValue_date,string Actual_Amt,string receipttype, string Total_deposit, string USDTotal_deposit, string Previous_DepositAmt,string floodcess)
    {
        int rowsAffected = 0;
       string Receipt_Status ="Active";
        
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Indian_Deposit_Receipt values(@Deposit_Receipt_Id,@ContractDetails_ID ,	 @ContractNo ,	@Receipt_No ,	 @Receipt_Date  ,	@place_supply ,	@state ,	@state_code ,	@Product_Name,	@SAC ,	@Amount,@taxable_value,@cgstrate,@cgstamt,@sgstrate,@sgstamt,@totalamt,@Payment_Mode,@actual_currency,@converted_currency,@Converted_rate,@ExchangedValue_date,@Actual_Amt,@Receipt_Status,@receipttype,@payment_date, @Total_deposit, @USDTotal_deposit, @Previous_DepositAmt,@floodcess)", cs1);
                da.InsertCommand.Parameters.Add("@Deposit_Receipt_Id", SqlDbType.VarChar).Value = Deposit_Receipt_Id;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Receipt_No", SqlDbType.VarChar).Value = Receipt_No;
                da.InsertCommand.Parameters.Add("@Receipt_Date", SqlDbType.VarChar).Value = Receipt_Date;
                da.InsertCommand.Parameters.Add("@place_supply", SqlDbType.VarChar).Value = place_supply;
                da.InsertCommand.Parameters.Add("@state", SqlDbType.VarChar).Value = state;
                da.InsertCommand.Parameters.Add("@state_code", SqlDbType.VarChar).Value = state_code;
                da.InsertCommand.Parameters.Add("@Product_Name", SqlDbType.VarChar).Value = Product_Name;
                da.InsertCommand.Parameters.Add("@SAC", SqlDbType.VarChar).Value = SAC;
                da.InsertCommand.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount;
                da.InsertCommand.Parameters.Add("@taxable_value", SqlDbType.VarChar).Value = taxable_value;
                da.InsertCommand.Parameters.Add("@cgstrate", SqlDbType.VarChar).Value = cgstrate;
                da.InsertCommand.Parameters.Add("@cgstamt", SqlDbType.VarChar).Value = cgstamt;
                da.InsertCommand.Parameters.Add("@sgstrate", SqlDbType.VarChar).Value = sgstrate;
                da.InsertCommand.Parameters.Add("@sgstamt", SqlDbType.VarChar).Value = sgstamt;
                da.InsertCommand.Parameters.Add("@totalamt", SqlDbType.VarChar).Value = totalamt;
                da.InsertCommand.Parameters.Add("@Payment_Mode", SqlDbType.VarChar).Value = Payment_Mode;
                da.InsertCommand.Parameters.Add("@actual_currency", SqlDbType.VarChar).Value = actual_currency;
                da.InsertCommand.Parameters.Add("@converted_currency", SqlDbType.VarChar).Value = converted_currency;
                da.InsertCommand.Parameters.Add("@Converted_rate", SqlDbType.VarChar).Value = Converted_rate;
                da.InsertCommand.Parameters.Add("@ExchangedValue_date", SqlDbType.VarChar).Value = ExchangedValue_date;
                da.InsertCommand.Parameters.Add("@Actual_Amt", SqlDbType.VarChar).Value = Actual_Amt;
		        da.InsertCommand.Parameters.Add("@Receipt_Status", SqlDbType.VarChar).Value = Receipt_Status ;
                da.InsertCommand.Parameters.Add("@receipttype", SqlDbType.VarChar).Value = receipttype;
                da.InsertCommand.Parameters.Add("@payment_date", SqlDbType.VarChar).Value = Receipt_Date;
                da.InsertCommand.Parameters.Add("@Total_deposit", SqlDbType.VarChar).Value = Total_deposit;
                da.InsertCommand.Parameters.Add("@USDTotal_deposit", SqlDbType.VarChar).Value = USDTotal_deposit;
                da.InsertCommand.Parameters.Add("@Previous_DepositAmt", SqlDbType.VarChar).Value = Previous_DepositAmt;
                da.InsertCommand.Parameters.Add("@floodcess", SqlDbType.VarChar).Value = floodcess;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

             

                string msg = "Error in Insert Contract_Indian_Deposit_Receipt" + " " + ex.Message;

                throw new Exception(msg, ex);

                
            }
        }
        return (rowsAffected);
    }

    public static DataSet LoadIndian_ReceiptGeneration(string venue)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select  *  from Indian_ReceiptGeneration   where venue=@venue", cs1);
            scd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int UpdateIndian_ReceiptGeneration(string venue)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd1 = new SqlCommand("select ReceiptGen_Code  from Indian_ReceiptGeneration where venue=@venue  and status='Active'", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.ReceiptGen_Code=@id from Indian_ReceiptGeneration cc  where  venue=@venue  and status='Active'", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE FinanceMethod_Venue Query " + ex.Message);

                string msg = "Error in UPDATE FinanceMethod_Venue Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static DataSet LoadContract_Fractional_IndianDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand scd = new SqlCommand("select * from Contract_Fractional_Indian cp join Finance_Details_Indian f on f.ContractNo=cp.ContractNo   where  cp.ContractNo=@contractno", cs1);
            SqlCommand scd = new SqlCommand("select * from Contract_Fractional_Indian cp join Finance_Details_Indian f on f.ContractDetails_ID=cp.ContractDetails_ID   where  cp.ContractDetails_ID=@ContractDetails_ID", cs1);

            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadContract_Indian_Deposit_Receipt(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from Contract_Indian_Deposit_Receipt where  ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadDeposit_Pay_Method(string ContractDetails_ID, string office)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Deposit_pay_method_name from Deposit_Pay_Method where Deposit_pay_method_status='Active' and office =@office and Deposit_pay_method_name not in(select Payment_Mode from Contract_Indian_Deposit_Receipt where ContractDetails_ID=@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadContractDetails_ID(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select *  from ContractDetails_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadOldContractType(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select ContractType from OldContractTradeInType where status = 'active' and ContractType not in(select Oldcontracttype from Contract_Trade_In_Fractional_Indian  where ContractDetails_ID =@ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static int UpdateReceiptIndian(string ContractNo, string Receipt_Date, string Amount, string taxable_value, string cgstamt, string sgstamt, string totalamt, string Payment_Mode, string ContractDetails_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Indian_Deposit_Receipt SET ContractNo = '" + ContractNo + "',Receipt_Date =convert(datetime, '" + Receipt_Date + "',105), Amount = '" + Amount + "',taxable_value = '" + taxable_value + "',cgstamt = '" + cgstamt + "',sgstamt = '" + sgstamt + "',totalamt = '" + totalamt + "',Payment_Mode = '" + Payment_Mode + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE UpdateReceiptIndian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }
    public static DataTable ReceiptPage(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Receipt", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static int UpdateInstallmentdetails_Indian(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Installments_Indian   set contractno='" + contractno + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateInstallmentdetails_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static String GetContractDetails_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "CD_IN";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select ContractDetails_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContractDetails_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select ContractDetails_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET ContractDetails_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateContractDetails_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static String GetFinance_Details_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "FD_IN";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Finance_Details_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateFinance_Details_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Finance_Details_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Finance_Details_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateFinance_Details_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static String GetContract_Fractional_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "F_IN";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Contract_Fractional_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_Fractional_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_Fractional_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_Fractional_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Fractional_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static String GetContract_Fractional_PA_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "PAF_IN";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Contract_Fractional_PA_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_Fractional_PA_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_Fractional_PA_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_Fractional_PA_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Fractional_PA_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static String GetContract_Indian_Deposit_Receipt_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "DP_IN";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Contract_Indian_Deposit_Receipt_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_Indian_Deposit_Receipt_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_Indian_Deposit_Receipt_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_Indian_Deposit_Receipt_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Indian_Deposit_Receipt_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static String GetContract_Points_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "CPI";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Contract_Points_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_Points_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_Points_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_Points_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Points_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static String GetContract_Trade_In_Points_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "CTIP";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Contract_Trade_In_Points_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_Trade_In_Points_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_Trade_In_Points_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_Trade_In_Points_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Trade_In_Points_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static String GetContract_PA_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "PA_IN";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Contract_PA_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_PA_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_PA_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_PA_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateContract_PA_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static String GetContract_Trade_In_Weeks_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "CTIW";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Contract_Trade_In_Weeks_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_Trade_In_Weeks_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_Trade_In_Weeks_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_Trade_In_Weeks_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                string msg = "Error in UPDATE UpdateContract_Trade_In_Weeks_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


            }

        }
        return rows;
    }
    public static String GetContract_Trade_In_Fractional_Indian_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "CTIF";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd1 = new SqlCommand("select Contract_Trade_In_Fractional_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_Trade_In_Fractional_Indian_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_Trade_In_Fractional_Indian_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_Trade_In_Fractional_Indian_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                string msg = "Error in UPDATE UpdateContract_Trade_In_Fractional_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


            }

        }
        return rows;
    }

    public static DataSet LoadPrintPDFFiles_IndianMC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) 	 and ((isnull(Waiver, '') ='yes') or isnull(waiver,'')<>'')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //  SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_IndianNOMC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) 	 and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static int UpdateProfileCompanyName(string ProfileID, string Company_Name)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Profile  SET Company_Name= '" + Company_Name + "'  where Profile_ID ='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateProfileCompanyName Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }
    public static String GetContractNo_OthernamesID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "CON_IN";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select ContractNo_OthernamesID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContractNo_OthernamesID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select ContractNo_OthernamesID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET ContractNo_OthernamesID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                string msg = "Error in UPDATE UpdateContractDetails_Indian_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);



            }

        }
        return rows;
    }
   public static int InsertContractNo_Othernames(string otherNamesID, string ContractNo, string ContractDetails_ID, string Type, string Name, string Address, string State, string Country, string Postcode, string Status, string Document_name, string Added_Date)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into ContractNo_Othernames values(@otherNamesID ,@ContractNo ,	@ContractDetails_ID,	@Type,	@Name,@Address,@State,@Country, @Postcode,	@Status,	@Document_name, @Added_Date,@Modified_Date,@Acceptance,@Enrollment )", cs1);
                da.InsertCommand.Parameters.Add("@otherNamesID ", SqlDbType.VarChar).Value = otherNamesID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
                da.InsertCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                da.InsertCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
                da.InsertCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = State;
                da.InsertCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;
                da.InsertCommand.Parameters.Add("@Postcode", SqlDbType.VarChar).Value = Postcode;
                da.InsertCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
                da.InsertCommand.Parameters.Add("@Document_name", SqlDbType.VarChar).Value = Document_name;
                da.InsertCommand.Parameters.Add("@Added_Date", SqlDbType.VarChar).Value = Added_Date;
                da.InsertCommand.Parameters.Add("@Modified_Date", SqlDbType.VarChar).Value = "";
                da.InsertCommand.Parameters.Add("@Acceptance", SqlDbType.VarChar).Value = "pending";
                da.InsertCommand.Parameters.Add("@Enrollment", SqlDbType.VarChar).Value = "pending";
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Points_Indian Query " + ex.Message);

                string msg = "Error in Insert InsertContractNo_Othernames Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static DataTable TIP_SOR_India(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("TIP_SOR_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static int CheckIDExistsInOtherNames(string ContractDetails_ID, string Type)
    {

        int id = 0;

        int year = DateTime.Now.Year;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {


            SqlCommand scd = new SqlCommand(" select  ContractDetails_ID   from ContractNo_Othernames  where ContractDetails_ID =@ContractDetails_ID and Type=@Type ", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                id = 1;
            }
            else
            {
                id = 0;
            }


        }

        return id;
    }
    public static int InsertFinance_Breakup(string ContractDetails_ID, string ContractNo, double Principal_Amount, double Yearly_interest, double Monthly_Principal, double Monthly_Interest, double Monthly_Instalment, string Installments, string Months, string fmonth)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            try
            {
                da.InsertCommand = new SqlCommand("insert into Finance_Breakup values(@ContractDetails_ID ,@ContractNo ,	@Principal_Amount,	@Yearly_interest,	@Monthly_Principal,@Monthly_Interest,@Monthly_Instalment,@Installments, @Months,convert(datetime, @fmonth,105))", cs1);
                da.InsertCommand.Parameters.Add("@ContractDetails_ID ", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Principal_Amount", SqlDbType.Float).Value = Principal_Amount;
                da.InsertCommand.Parameters.Add("@Yearly_interest", SqlDbType.Float).Value = Yearly_interest;
                da.InsertCommand.Parameters.Add("@Monthly_Principal", SqlDbType.Float).Value = Monthly_Principal;
                da.InsertCommand.Parameters.Add("@Monthly_Interest", SqlDbType.Float).Value = Monthly_Interest;
                da.InsertCommand.Parameters.Add("@Monthly_Instalment", SqlDbType.Float).Value = Monthly_Instalment;
                da.InsertCommand.Parameters.Add("@Installments", SqlDbType.VarChar).Value = Installments;
                da.InsertCommand.Parameters.Add("@Months", SqlDbType.VarChar).Value = Months;
                da.InsertCommand.Parameters.Add("@fmonth", SqlDbType.VarChar).Value = fmonth;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Points_Indian Query " + ex.Message);

                string msg = "Error in Insert InsertFinance_Breakup Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static int CheckIDExistsInFinance_Breakup(string ContractDetails_ID)
    {

        int id = 0;

        int year = DateTime.Now.Year;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {


            SqlCommand scd = new SqlCommand(" select  ContractDetails_ID   from Finance_Breakup  where ContractDetails_ID =@ContractDetails_ID ", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                id = 1;
            }
            else
            {
                id = 0;
            }


        }

        return id;
    }

    public static string FinanceInstallmentMonthF(string ContractDetails_ID)
    {
        int rows = 0;

        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select max(fmonth) from Finance_Breakup where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            DateTime val = (DateTime)scd1.ExecuteScalar();
            
            DateTime fdat = Convert.ToDateTime(val);
            int dt =15;// fdat.Day;
            int month = fdat.Month;
            int year = fdat.Year;
            if (month == 12)
            {
                mon = 1;
                yr = year + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                financemonth = dt + "/" + mon + "/" + yr;

            }
            else
            {
                mon = month + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                financemonth = dt + "/" + mon + "/" + year;

            }



        }
        return financemonth;
    }
    public static string FinanceInstallmentMonthStartdate(string ContractDetails_ID)
    {
        int rows = 0;

        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select max(fmonth) from Finance_Breakup where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            DateTime val = (DateTime)scd1.ExecuteScalar();
            DateTime fdat = Convert.ToDateTime(val);
            int month = fdat.Month;
            int year = fdat.Year;
            if (month == 12)
            {
                mon = 1;
                yr = year + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                financemonth = month1 + "-" + yr;

            }
            else
            {
                mon = month + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                financemonth = month1 + "-" + year;
            }



        }
        return financemonth;
    }

    public static string FinanceInstallmentMonthStartdateNew(string ContractDetails_ID)
    {


        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select max(Installment_Date) from Contract_Installments_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            DateTime val = (DateTime)scd1.ExecuteScalar();
            DateTime fdat = Convert.ToDateTime(val);
            int month = fdat.Month;
            int year = fdat.Year;
            if (month == 12)
            {
                mon = 1;
                yr = year + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                financemonth = month1 + "-" + yr;

            }
            else
            {
                mon = month + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                financemonth = month1 + "-" + year;
            }



        }
        return financemonth;
    }
    public static string FinanceInstallmentMonthStartdateNewF(string ContractDetails_ID)
    {


        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select max(Installment_Date) from Contract_Installments_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            DateTime val = (DateTime)scd1.ExecuteScalar();
            DateTime fdat = Convert.ToDateTime(val);
            int dt = 15;//fdat.Day;
            int month = fdat.Month;
            int year = fdat.Year;
            if (month == 12)
            {
                mon = 1;
                yr = year + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
               financemonth = dt + "/" + mon + "/" + yr;
            //    financemonth = "1" + "/" + mon + "/" + yr;

            }
            else
            {
                mon = month + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                 financemonth = dt + "/" + mon + "/" + year;
                //financemonth = "1" + "/" + mon + "/" + year;

            }



        }
        return financemonth;
    }
    public static double GetMinPrinicipalAmt(string ContractDetails_ID)
    {
        double amt;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select min(Principal_Amount) from Finance_Breakup  where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            amt = (double)scd1.ExecuteScalar();

        }
        return amt;
    }
    public static double GetMinMonthlyPrincipal(string ContractDetails_ID, int Installments, double Principal_Amount)
    {
        double amt;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select  Monthly_Principal  from Finance_Breakup  where ContractDetails_ID=@ContractDetails_ID and Installments=@Installments and  Principal_Amount=@Principal_Amount", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd1.Parameters.Add("@Installments", SqlDbType.Int).Value = Installments;
            scd1.Parameters.Add("@Principal_Amount", SqlDbType.Float).Value = Principal_Amount;
            amt = (double)scd1.ExecuteScalar();

        }
        return amt;
    }
    public static int GetWkNumber(DateTime dtDate)
    {
        int returnNumber = 0;
        try
        {
            CultureInfo ciGetNumber = CultureInfo.CurrentCulture;
            // returnNumber = ciGetNumber.Calendar.GetWeekOfYear(dtDate, CalendarWeekRule.FirstDay, DayOfWeek.Friday);
            returnNumber = ciGetNumber.Calendar.GetWeekOfYear(dtDate, CalendarWeekRule.FirstFullWeek, DayOfWeek.Saturday);
        }
        catch (System.FormatException fe)
        {
            // MessageBox.Show("Exception occurred in " + fe);

        }
        return returnNumber;

    }
    public static DataTable LoanEMIBreakupFinance(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("LoanEMIBreakup", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }
    }



    public static int ContractNo_OthernamesExistsA(string ContractDetails_ID)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select  ContractDetails_ID from ContractNo_Othernames where ContractDetails_ID=@ContractDetails_ID AND type='Additional Name' and type <>'SOR Name'", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }
    public static int ContractNo_OthernamesExistsS(string ContractDetails_ID)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select  ContractDetails_ID from ContractNo_Othernames where ContractDetails_ID=@ContractDetails_ID AND type='SOR Name' and type <>'Additional Name' ", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }
    public static int ContractNo_OthernamesExistsB(string ContractDetails_ID)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select  ContractDetails_ID from ContractNo_Othernames where ContractDetails_ID=@ContractDetails_ID ", cs1);// AND type = 'SOR Name' and type = 'Additional Name'
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
                
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }
    public static int ContractNo_OthernamesExistsNone(string ContractDetails_ID)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select  ContractDetails_ID from ContractNo_Othernames where ContractDetails_ID=@ContractDetails_ID and (type <>'SOR Name' and type <> 'Additional Name')", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }
    public static DataSet LoadContractNo_Othernames(string ContractDetails_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd = new SqlCommand("select   ContractNo,	Type,	Name,	Address,	State,	Country,	Postcode,OtherNamesID	 from ContractNo_Othernames where ContractDetails_ID=@ContractDetails_ID and status='Active'", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadPrintPDFFiles_Points1(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))  and   ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')  and(printname    not like '%company%')and(printname    not like '%sor%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465') ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    //add printpdf ids of normal pa names of all contracttype
    public static DataSet LoadPrintPDFFiles_Points2(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%company%')  and(printname    not like '%sor%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points3(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) 	and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%void%')  and(printname    not like '%sor%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points4(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')  and(printname    not like '%company%') and(printname    not like '%sor%') and(printname    not like '%addition%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points5(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname  not like '%company%') and(printname    not like '%sor%') and(printname    not like '%addition%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points6(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%void%') and(printname    not like '%sor%') and(printname    not like '%addition%'))  and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points7(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')  and(printname    not like '%company%') )  and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points8(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname  not like '%company%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points9(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%void%'))  and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points10(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname not like '%void%')  and(printname    not like '%company%') and(printname    not like '%addition%'))  and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points11(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%company%')  and(printname    not like '%addition%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points12(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%void%')  and(printname    not like '%addition%'))  and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points1MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223')  and((printname not like '%void%')  and(printname    not like '%company%')and(printname    not like '%sor%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235''PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND283','PDIND285','PDIND294','PDIND296','PDIND305','PDIND307','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465') ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    //add printpdf ids of normal pa names of all contracttype
    public static DataSet LoadPrintPDFFiles_Points2MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223')  and((printname  not like '%company%')  and(printname    not like '%sor%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points3MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223')  and((printname  not like '%void%')  and(printname    not like '%sor%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points4MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname not like '%void%')  and(printname    not like '%company%') and(printname    not like '%sor%') and(printname    not like '%addition%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points5MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%company%') and(printname    not like '%sor%') and(printname    not like '%addition%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points6MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%void%') and(printname    not like '%sor%') and(printname    not like '%addition%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points7MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname not like '%void%')  and(printname    not like '%company%') )and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points8MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))  and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%company%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points9MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%void%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points10MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname not like '%void%')  and(printname    not like '%company%') and(printname    not like '%addition%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points11MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%company%')  and(printname    not like '%addition%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points12MC(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223')   and((printname  not like '%void%')  and(printname    not like '%addition%'))and Printpdf_id not in ('PDIND232','PDIND233','PDIND234','PDIND235','PDIND236','PDIND237','PDIND238','PDIND239','PDIND240','PDIND241','PDIND242','PDIND243','PDIND441','PDIND443','PDIND452','PDIND454','PDIND463','PDIND465')", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataTable Rep_ReportProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Rep_TO_Report", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable AdditionalName_FractionalProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("AdditionalName_Fractional", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
   /* public static DataTable SOR_FractionalProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Fract_SOR_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }*/

 public static DataTable SOR_FractionalProc(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            //SqlCommand cmd_sp = new SqlCommand("Fract_SOR_India", con);

            //cmd_sp.CommandType = CommandType.StoredProcedure;
            //cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlCommand cmd_sp = new SqlCommand("Fractional_SOR_India", con);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable AdditionalName_NewPointsProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("AdditionalName_NewPoints", con);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable AdditionalName_TIPProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("AdditionalName_TradeInPoints", con);
           // SqlCommand cmd_sp = new SqlCommand("AdditionalName_NewPoints", con);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable SOR_TIPProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("TIP_SOR_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
        //    cmd_sp.Parameters.AddWithValue("@contractno", contractno);
	           cmd_sp.Parameters.AddWithValue("@contractid", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable AdditionalName_TIWProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

              SqlCommand cmd_sp = new SqlCommand("AdditionalName_TradeInWeeks", con);
           // SqlCommand cmd_sp = new SqlCommand("AdditionalName_NewPoints", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable SOR_TIWProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("TIW_SOR_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }


    public static DataSet LoadCountryWithCodePrimaryOffice(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Primary_office_cc from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountryWithCodeSecondaryOffice(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Secondary_office_cc from phone where profile_id=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Country_Code  name from Country  where country_name =@ProfileID  union all   select Country_Code name from Country  where country_name! =@ProfileID ", cs1);

            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadPrintPDFFiles_Points1MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223')  and((printname not like '%void%')  and(printname    not like '%company%')and(printname    not like '%sor%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464')) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    //add printpdf ids of normal pa names of all contracttype
    public static DataSet LoadPrintPDFFiles_Points2MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223')  and((printname  not like '%company%')  and(printname    not like '%sor%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204' ,'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points3MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223')  and((printname  not like '%void%')  and(printname    not like '%sor%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points4MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname not like '%void%')  and(printname    not like '%company%') and(printname    not like '%sor%') and(printname    not like '%addition%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points5MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%company%') and(printname    not like '%sor%') and(printname    not like '%addition%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points6MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%void%') and(printname    not like '%sor%') and(printname    not like '%addition%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points7MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname not like '%void%')  and(printname    not like '%company%') and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points8MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))  and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%company%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464')) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points9MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%void%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points10MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname not like '%void%')  and(printname    not like '%company%') and(printname    not like '%addition%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points11MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223') and((printname  not like '%company%')  and(printname    not like '%addition%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216','PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points12MCGOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='yes')  or isnull(waiver,'')='no') and Printpdf_id not in('PDIND08',	'PDIND09',	'PDIND26',	'PDIND27',	'PDIND41',	'PDIND42',	'PDIND59',	'PDIND60',	'PDIND74',	'PDIND75',	'PDIND79',	'PDIND103',	'PDIND104',	'PDIND108',	'PDIND115',	'PDIND116',	'PDIND119',	'PDIND137',	'PDIND138',	'PDIND141',	'PDIND156',	'PDIND157',	'PDIND161',	'PDIND185',	'PDIND186',	'PDIND190',	'PDIND197',	'PDIND198',	'PDIND201',	'PDIND219',	'PDIND220',	'PDIND223')   and((printname  not like '%void%')  and(printname    not like '%addition%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204', 'PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points1GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))  and   ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')  and(printname    not like '%company%')and(printname    not like '%sor%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464') )", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    //add printpdf ids of normal pa names of all contracttype
    public static DataSet LoadPrintPDFFiles_Points2GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%company%')  and(printname    not like '%sor%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points3GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) 	and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%void%')  and(printname    not like '%sor%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND163','PDIND164','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points4GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')  and(printname    not like '%company%') and(printname    not like '%sor%') and(printname    not like '%addition%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points5GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname  not like '%company%') and(printname    not like '%sor%') and(printname    not like '%addition%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points6GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%void%') and(printname    not like '%sor%') and(printname    not like '%addition%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points7GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')  and(printname    not like '%company%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464') )", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points8GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname  not like '%company%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464')) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points9GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%void%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points10GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname not like '%void%')  and(printname    not like '%company%') and(printname    not like '%addition%')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points11GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%company%')  and(printname    not like '%addition%')) and(Printpdf_id not in('PDIND01',	'PDIND02',	'PDIND19',	'PDIND22',	'PDIND34',	'PDIND37',	'PDIND52',	'PDIND55',	'PDIND68',	'PDIND69',	'PDIND90',	'PDIND93',	'PDIND109',	'PDIND112',	'PDIND131',	'PDIND134',	'PDIND150',	'PDIND151',	'PDIND172',	'PDIND175',	'PDIND191',	'PDIND194',	'PDIND213',	'PDIND216')and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Points12GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance  and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = '')) and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no') and((printname  not like '%void%')  and(printname    not like '%addition%') and Printpdf_id not in ('PDIND11','PDIND44','PDIND81','PDIND123','PDIND163','PDIND205','PDIND10','PDIND43','PDIND82','PDIND122','PDIND164','PDIND204','PDIND282','PDIND284','PDIND293','PDIND304','PDIND440','PDIND451','PDIND462','PDIND295','PDIND306','PDIND442','PDIND453','PDIND464'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            //   SqlCmd.Parameters.Add("@mc", SqlDbType.VarChar).Value = mc;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_Fractionals(string ctype, string office, string club, string curr, string finance)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static int ContractIDINSOR_Additional(string ContractDetails_ID)
    {
        int id = 0;

        int year = DateTime.Now.Year;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {


            SqlCommand scd = new SqlCommand(" select  ContractDetails_ID   from ContractNo_Othernames  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                id = 1;
            }
            else
            {
                id = 0;
            }


        }

        return id;
    }
    public static int DeleteContractNo_Othernames(string recid)
    {
        int rows = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqlcmd = new SqlCommand(" delete from  ContractNo_Othernames where otherNamesID=@recid", cs1);
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@recid";
            para.Value = recid;
            sqlcmd.Parameters.Add(para);
            rows = sqlcmd.ExecuteNonQuery();
        }
        return rows;
    }
    public static DataSet LoadGift(string profileID)
    {
        SqlDataAdapter da;
        DataSet dt = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Gift_Voucher_numb,Gift_Comment from gift where Profile_ID='" + profileID + "'", cs1);
            SqlCmd.Parameters.Add("@profileID", SqlDbType.VarChar).Value = profileID;
            da = new SqlDataAdapter(SqlCmd);
            dt = new DataSet();
            da.Fill(dt);
        }
        return (dt);

    }
    public static DataTable loadClientDetails(string profileID)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("clientDetails", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@profileID", profileID);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static int UpdateFinance_Details_IndianInsAmt(string num,string ContractDetails_ID)
    {
        int rowsaffected = 0;
       // string num = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                //SqlCommand scd1 = new SqlCommand("select min(installment_amount) from Contract_Installments_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
                //scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                //num = (string)scd1.ExecuteScalar();

                SqlCommand scd = new SqlCommand("update Finance_Details_Indian set Installment_Amount = '" + num + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;

                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE UpdateFinance_Details_IndianInsAmt Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }
    

    public static String GetMinFinance_Details_IndianInsAmt(string ContractDetails_ID)
    {

        string num = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select min(installment_amount) from Contract_Installments_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            num = (string)scd1.ExecuteScalar();

        }
        return num;
    }
    public static DataTable DGRReportIndia(string date, string office, string venue)
    {
        
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand cmd_sp = new SqlCommand("DGRIndia", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;          
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

         
        }
        

    }
   public static DataSet LoadProfileOnCreationOnLoad(string Profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct pro.Profile_Marketing_Program,pro.Profile_Agent,pro.Profile_Marital_status,pro.Profile_Employment_status,pro.Photo_identity,pro.Card_Holder,pro.Profile_Member_Type1+'/'+pro.Profile_Member_Number1 as memeberNonmember, REPLACE(REPLACE(pro.comments, CHAR(13), ' '), CHAR(10), ' ')+' '+REPLACE(REPLACE(pro.comment2, CHAR(13), ' '), CHAR(10), ' ') as comments,pro.RegTerms,pro.Profile_Agent_Code,pro.Profile_ID, pp.Profile_Primary_Title + '.' + pp.Profile_Primary_Fname + ' ' + pp.Profile_Primary_Lname as primaryFullName, pp.Primary_Designation, pp.Primary_Language, pp.Primary_Age,  REPLACE(ISNULL(CONVERT(varchar,  pp.Profile_Primary_DOB, 105), ''), '01-01-1900', '') Profile_Primary_DOB, ps.Profile_Secondary_Title + '.' + ps.Profile_Secondary_Fname + ' ' + ps.Profile_Secondary_Lname as secondaryFullName, ps.Secondary_Designation, ps.Secondary_Language, ps.Secondary_Age, REPLACE(ISNULL(CONVERT(varchar,  ps.Profile_Secondary_DOB, 105), ''), '01-01-1900', '')  Profile_Secondary_DOB,pros.Profile_Stay_Resort_Name, pros.Profile_Stay_Resort_Room_Number, REPLACE(ISNULL(CONVERT(varchar, pros.Profile_Stay_Arrival_Date, 105), ''), '01-01-1900', '') arrival, REPLACE(ISNULL(CONVERT(varchar, pros.Profile_Stay_Departure_Date, 105), ''), '01-01-1900', '')Departure,tour.Tour_Details_Guest_Sales_Rep, REPLACE(ISNULL(CONVERT(varchar, tour.Tour_Details_Tour_Date, 105), ''), '01-01-1900', '') tourdate from profile pro left join Profile_Primary pp on pro.Profile_ID = pp.Profile_ID left join Profile_Secondary ps on pro.Profile_ID = ps.Profile_ID left join Phone p on pro.Profile_ID = p.Profile_ID left join Profile_Stay pros on pro.Profile_ID = pros.Profile_ID left join Tour_Details tour on pro.Profile_ID = tour.Profile_ID left join Email e on pro.Profile_ID = e.Profile_ID where pro.Profile_ID = @Profile_ID", cs1);
            SqlCmd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet GetSalesRepOnlyVenueViewPage(string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select sales_rep_name from Sales_Rep  sr    join VenueCountry vc on vc.Venue_Country_ID = sr.Venue_country_ID    where    sales_rep_status = 'Active'   and sr.venue =@venue order by 1", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;       
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static int UpdateSalesRepDetails(string ProfileID,   string Tour_Details_Guest_Sales_Rep)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {

                SqlCommand scd = new SqlCommand("update Tour_Details SET  Tour_Details_Guest_Sales_Rep= '" + Tour_Details_Guest_Sales_Rep + "' where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in UPDATE UpdateSalesRepDetails Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }
    public static DataTable loadDGRIndia(string date, string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

           
           
            SqlCommand cmd_sp = new SqlCommand("DGRIndia", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
         
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static int ContractDetails_IDFinance_Breakup(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             SqlCommand scd = new SqlCommand(" select  ContractDetails_ID from Finance_Breakup where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int DeleteContractDetailsIDFinance_Breakup(string ContractDetails_ID)
    {
        int rows = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqlcmd = new SqlCommand(" delete from  Finance_Breakup where ContractDetails_ID=@ContractDetails_ID", cs1);
            sqlcmd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            rows = sqlcmd.ExecuteNonQuery();
        }
        return rows;
    }
	
  public static int UpdatefinanceStartdateIfNoBal(string contractno)
    {
        int rows = 0;

        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select  DealRegistered_Date from ContractDetails_Indian  where contractno=@contractno", cs1);
                scd1.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;

                DateTime val = (DateTime)scd1.ExecuteScalar();
                DateTime fdat = Convert.ToDateTime(val);
                int month = fdat.Month;
                int year = fdat.Year;
                if (month == 12)
                {
                    mon = 1;
                    yr = year + 1;
                    string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon); //CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName()
                                                                                                            // DateTime.Now.ToString("MMM", CultureInfo.CurrentCulture);
                                                                                                            //   int mno = DateTime.ParseExact(value, "MMMM", CultureInfo.CurrentCulture).Month;
                    financemonth = month1 + " " + yr;

                }
                else
                {
                    mon = month + 1;
                    string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                    financemonth = month1 + " " + year;
                }


                SqlCommand sqlcmd = new SqlCommand("UPDATE Finance_Details_Indian SET financeMonth=@financemonth where contractno=@contractno", cs1);
                sqlcmd.Parameters.Add("@financemonth", SqlDbType.VarChar).Value = financemonth;
                sqlcmd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;

                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_Details_Indian Query " + ex.Message);

                string msg = "Error in UPDATE UpdatefinanceStartdateIfNoBal Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }


        }
        return rows;
    }

    public static string FinanceInstallmentMonthStartdateNewFZeroInstallment(string ContractDetails_ID)
    {


        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select  DealRegistered_Date from ContractDetails_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            DateTime val = (DateTime)scd1.ExecuteScalar();
            DateTime fdat = Convert.ToDateTime(val);
            int dt =15;// fdat.Day;
            int month = fdat.Month;
            int year = fdat.Year;
            if (month == 12)
            {
                mon = 1;
                yr = year + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                   financemonth = dt + "/" + mon + "/" + yr;
                

            }
            else
            {
                mon = month + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
               financemonth = dt + "/" + mon + "/" + year;
              

            }



        }
        return financemonth;
    }
    public static string FinanceInstallmentMonthStartdateNewZeroInstallment(string ContractDetails_ID)
    {


        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select  DealRegistered_Date from ContractDetails_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            DateTime val = (DateTime)scd1.ExecuteScalar();
            DateTime fdat = Convert.ToDateTime(val);
            int month = fdat.Month;
            int year = fdat.Year;
            if (month == 12)
            {
                mon = 1;
                yr = year + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                financemonth = month1 + "-" + yr;

            }
            else
            {
                mon = month + 1;
                string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                financemonth = month1 + "-" + year;
            }



        }
        return financemonth;
    }
    public static int UpdateFinanceBreakup_ContractNo(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Finance_Breakup  SET        contractno='" + contractno + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateFinanceBreakup_ContractNo Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

public static int UpdatefinanceStartdateIFZeroInstallment(string contractno)
    {
        int rows = 0;

        int mon, yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select  DealRegistered_Date  from ContractDetails_Indian where ContractNo=@contractno", cs1);
                scd1.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;

                DateTime val = (DateTime)scd1.ExecuteScalar();
                DateTime fdat = Convert.ToDateTime(val);
                int month = fdat.Month;
                int year = fdat.Year;
                if (month == 12)
                {
                    mon = 1;
                    yr = year + 1;
                    string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon); //CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName()
                                                                                                            // DateTime.Now.ToString("MMM", CultureInfo.CurrentCulture);
                                                                                                            //   int mno = DateTime.ParseExact(value, "MMMM", CultureInfo.CurrentCulture).Month;
                    financemonth = month1 + " " + yr;

                }
                else
                {
                    mon = month + 1;
                    string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                    financemonth = month1 + " " + year;
                }


                SqlCommand sqlcmd = new SqlCommand("UPDATE Finance_Details_Indian SET financeMonth=@financemonth where ContractNo=@contractno", cs1);
                sqlcmd.Parameters.Add("@financemonth", SqlDbType.VarChar).Value = financemonth;
                sqlcmd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;

                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_Details_Indian Query " + ex.Message);

                string msg = "Error in UPDATE UpdatefinanceStartdateIFZeroInstallment Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }


        }
        return rows;
    }

 public static int CheckFinanceBreakup_ContractNoExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            
                SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Finance_Breakup where ContractDetails_ID =@ContractDetails_ID", cs1);
                scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                SqlDataReader dr = scd1.ExecuteReader();
                if (dr.Read())
                {
                rows = 1;
                }
                else
                {
                rows = 0;
            }

 

        }
        return rows;
    }


    public static DataSet LoadOldContractTypeAll()
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select ContractType from OldContractTradeInType where status = 'active'", cs1);
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

 public static DataSet LoadContractNoDetailsOnContractDetails_ID(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select *  from ContractDetails_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int UpdateCompnayGSTIN_PAN(string Client_GSTIN, string Company_PanNo,string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET        Client_GSTIN='" + Client_GSTIN + "', Company_PanNo='" + Company_PanNo + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateCompnayGSTIN_PAN Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

 public static int CheckFinanceIndianDetailsExists(string ContractDetails_ID,string Finance_Method,string finance_type)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Finance_Details_Indian where ContractDetails_ID =@ContractDetails_ID and Finance_Method=@Finance_Method and finance_type=@finance_type", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd1.Parameters.Add("@Finance_Method", SqlDbType.VarChar).Value = Finance_Method;
            scd1.Parameters.Add("@finance_type", SqlDbType.VarChar).Value = finance_type;            
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }
    public static SqlDataReader getFinanceNoFromID(string ContractDetails_ID, string Finance_Method, string finance_type)
    {
       
        SqlConnection cs1 = Queries.GetDBConnection();
         
            SqlCommand sqlcmd = new SqlCommand(" select Finance_No from Finance_Details_Indian  where ContractDetails_ID=@ContractDetails_ID and Finance_Method =@Finance_Method and finance_type =@finance_type", cs1);
            sqlcmd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            sqlcmd.Parameters.Add("@Finance_Method", SqlDbType.VarChar).Value = Finance_Method;
            sqlcmd.Parameters.Add("@finance_type", SqlDbType.VarChar).Value = finance_type;
        SqlDataReader dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }
    public static int CheckFinanceIndianDetailsExists1(string ContractDetails_ID)//,  string finance_type)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Finance_Details_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);//   and finance_type=@finance_type
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;    
          //  scd1.Parameters.Add("@finance_type", SqlDbType.VarChar).Value = finance_type;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }
    public static SqlDataReader LoadMCChartTimeshare(string club, string year, string curr)
    {
         
        SqlConnection cs1 = Queries.GetDBConnection();


        SqlCommand SqlCmd = new SqlCommand("select Property_fee,Member_fee,Member_CGST,Member_SGST from ManagementCharges_Chart_India where club =@club and year =@year and status='Active' and  Currency=@curr", cs1);
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);        
        return dr;

    }

    public static SqlDataReader LoadMCChartfractionalOnEdit(string club, string year, string curr, string wk, string type)
    {
        SqlConnection cs1 = Queries.GetDBConnection();

        SqlCommand SqlCmd = new SqlCommand("select Property_fee,Member_fee,Member_CGST,Member_SGST from ManagementCharges_Chart_India where club =@club and year =@year and status='Active' and  Currency=@curr and weekno=@wk and Otype =@type", cs1);
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@wk", SqlDbType.VarChar).Value = wk;
            SqlCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;

    }
    public static DataSet Paymethoddetails(string ContractDetails_ID, string office)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             SqlCommand scd = new SqlCommand("SELECT pay_method_name  FROM pay_method WHERE pay_method_status='Active' and office=@Office and pay_method_name not in(select Payment_Method from Finance_Details_Indian where ContractDetails_ID= @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
}

 public static DataTable CompanyLetterHead(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("CompanyLetterHead", con);          
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataSet LoadContract_Indian_Deposit_ReceiptDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select ContractNo,	Receipt_No,	Receipt_Date,	 Product_Name,	  	taxable_value,	cgstrate,	cgstamt,	sgstrate,	sgstamt,	totalamt,	Payment_Mode,	actual_currency,	converted_currency,	Converted_rate,	ExchangedValue_date,Actual_Amt, Deposit_Receipt_Id,	ContractDetails_ID from Contract_Indian_Deposit_Receipt where  ContractDetails_ID=@ContractDetails_ID", cs1);
            SqlCommand scd = new SqlCommand("select ContractNo,	Receipt_No,	Receipt_Date,	taxable_value,	 totalamt,	Payment_Mode,	actual_currency,	converted_currency,	Converted_rate,	 Actual_Amt,  	ContractDetails_ID from Contract_Indian_Deposit_Receipt where  ContractDetails_ID=@ContractDetails_ID and Receipt_Status='Active'", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }


    public static DataSet LoadContractNo_OthernamesOnID(string otherNamesID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand scd = new SqlCommand("select ContractNo,	Receipt_No,	Receipt_Date,	 Product_Name,	  	taxable_value,	cgstrate,	cgstamt,	sgstrate,	sgstamt,	totalamt,	Payment_Mode,	actual_currency,	converted_currency,	Converted_rate,	ExchangedValue_date,Actual_Amt, Deposit_Receipt_Id,	ContractDetails_ID from Contract_Indian_Deposit_Receipt where  ContractDetails_ID=@ContractDetails_ID", cs1);
            SqlCommand scd = new SqlCommand("select * from ContractNo_Othernames where  otherNamesID=@otherNamesID", cs1);
            scd.Parameters.Add("@otherNamesID", SqlDbType.VarChar).Value = otherNamesID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
 public static int UpdateReceiptTableStatus(string Receipt_No)
    {
        int rows = 0;
       
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            { 
                SqlCommand sqlcmd = new SqlCommand("UPDATE Contract_Indian_Deposit_Receipt SET Receipt_Status='Inactive' where Receipt_No=@Receipt_No", cs1);
                sqlcmd.Parameters.Add("@Receipt_No", SqlDbType.VarChar).Value = Receipt_No;                 
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                string msg = "Error in UPDATE UpdateReceiptTableStatus Query" + " " + ex.Message;
                throw new Exception(msg, ex);
              
            }

        }
        return rows;
    }

    public static int UpdateContractNo_OthernamesStatus(string otherNamesID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractNo_Othernames SET Status='Inactive' where otherNamesID=@otherNamesID", cs1);
                sqlcmd.Parameters.Add("@otherNamesID", SqlDbType.VarChar).Value = otherNamesID;

                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                string msg = "Error in UPDATE UpdateContractNo_OthernamesStatus Query" + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

  public static int admin_Log(string PageName, string details, string user, string Log_Entry)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Admin_Log values(@PageName,@details,@user,@Log_Entry)", cs1);
                da.InsertCommand.Parameters.Add("@PageName  ", SqlDbType.VarChar).Value = PageName;
                da.InsertCommand.Parameters.Add("@details ", SqlDbType.VarChar).Value = details;
                da.InsertCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            
                da.InsertCommand.Parameters.Add("@Log_Entry", SqlDbType.VarChar).Value = Log_Entry;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract Logs Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

                string msg = "Error in Insert Admin Log Query" + " " + ex.Message;

                throw new Exception(msg, ex);

            }
        }
        return (rowsAffected);
    }

public static int UpdateDealdateWeekno(string dealweekno, string ContractDetails_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                 
                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET dealweekno= '" + dealweekno + "'  where ContractDetails_ID ='" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateProfileCompanyName Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }

    public static DataTable loadDGRINDIA1(string date, string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("dgrindia", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@date", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

public static int UpdateContractDetails_IndianComment(string ContractDetails_ID, string Contract_comment)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET Contract_comment= '" + Contract_comment + "'  where ContractDetails_ID ='" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateContractDetails_IndianComment Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }


 public static DataTable DSRINDIA(string date, string country, string venue, string currency)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSRINDIA", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@date", date);
            cmd_sp.Parameters.AddWithValue("@country", country);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            cmd_sp.Parameters.AddWithValue("@currency", currency);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

public static int CheckContractNo_Othernames_ContractNoExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from ContractNo_Othernames where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }
    public static int UpdateContractNo_Othernames_ContractNo(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update ContractNo_Othernames  SET        contractno='" + contractno + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContractNo_Othernames_ContractNo Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
public static int CheckContract_Indian_Deposit_Receipt_ContractNoExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Contract_Indian_Deposit_Receipt where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }
    public static int UpdateContract_Indian_Deposit_Receipt_ContractNo(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Indian_Deposit_Receipt  SET   contractno='" + contractno + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContractNo_Othernames_ContractNo Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
public static int UpdateIndian_ReceiptGenerationFinancialYear(string venue)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd1 = new SqlCommand("select IncrementValue  from FinancialYearReceiptGeneration where venue=@venue  and status='Active'", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

                int val = (int)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.IncrementValue=@id from FinancialYearReceiptGeneration cc  where  venue=@venue  and status='Active'", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE FinanceMethod_Venue Query " + ex.Message);

                string msg = "Error in UPDATE Indian_ReceiptGenerationFinancialYear Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static DataSet LoadFractionalResort()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Contract_Resort_Name  from [Contract_Resort] where office='hml' and Contract_Resort_Status='Active'", cs1);
            // SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
public static DataTable GuestExitReportIndia(string date, string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand cmd_sp = new SqlCommand("GuestExitReport", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;


        }


    }


 public static DataTable dsr_india_1(string DATE, string COUNTRY, string CURR,string VENUE)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_B1", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@CURR", CURR);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static DataTable dsr_india_2(string DATE, string COUNTRY, string CURR, string VENUE)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_B2", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@CURR", CURR);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }


    public static DataTable dsr_india_3(string DATE, string COUNTRY, string CURR, string VENUE)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_BS", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@CURR", CURR);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }




    public static DataTable SeapConsovenueindia(string INPUT, string COUNTRY, string VENUE)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("SeapConsoVenue_India", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", INPUT);
            cmd_sp.Parameters.AddWithValue("@country", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@venue", VENUE);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }


    public static DataTable seapdateindia(string INPUT)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("seapdate_india", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", INPUT);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }
    }



    public static DataTable SeapSingleIndia(string INPUT, string COUNTRY, string VENUE,string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("SeapSingleIndia", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", INPUT);
            cmd_sp.Parameters.AddWithValue("@country", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@venue", VENUE);
            cmd_sp.Parameters.AddWithValue("@gvenue", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static String GetFractionalResortIndian(string venue, string club)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when venue like '%roadshow%' then (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'RSHM' else '' end) else (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'HM' else '' end) end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality = 'Indian'", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }
    public static String GetFractionalResortNonIndian(string venue, string club)//, string nationality)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when venue like '%roadshow%' then (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'RSHM' else '' end) else (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'HM' else '' end) end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality != 'Indian'", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }

    public static String GetTimeshareContractNoIndian_CancelledMember(string venue, string club, string venuegrp)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code+'R' from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality ='INDIAN' or cc.Nationality ='Indian')", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }
    public static String GetTimeshareContractNoNonIndian_CancelledMember(string venue, string club, string venuegrp)//, string nationality)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code + '/' + REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '') + '/' + Increment_Value + vg.Venue_group_Code+'R' from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality !='INDIAN'  or cc.Nationality !='Indian')", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;

            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }
    public static String GetTimeshareContractNoIndian(string venue, string club, string venuegrp)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality ='INDIAN' or cc.Nationality ='Indian')", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }
    public static String GetTimeshareContractNoNonIndian(string venue, string club, string venuegrp)//, string nationality)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code + '/' + REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '') + '/' + Increment_Value + vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality !='INDIAN'  or cc.Nationality !='Indian')", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;

            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }
    public static DataSet LoadFinanceMethodRates(string FinanceMethod_Name, int year)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from FinanceMethodRates where FinanceMethod_Name=@FinanceMethod_Name and  (start_year=@year or end_year=@year)   and  FinanceMethod_Status='Active'  and ContractType='Non Fractional' ", cs1);
            SqlCmd.Parameters.Add("@FinanceMethod_Name", SqlDbType.VarChar).Value = FinanceMethod_Name;
            SqlCmd.Parameters.Add("@year", SqlDbType.Int).Value = year;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadFinanceMethodRatesFractional(string FinanceMethod_Name, int year)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from FinanceMethodRates where FinanceMethod_Name=@FinanceMethod_Name and  (start_year=@year or end_year=@year)   and  FinanceMethod_Status='Active' and ContractType='Fractional'  ", cs1);
            SqlCmd.Parameters.Add("@FinanceMethod_Name", SqlDbType.VarChar).Value = FinanceMethod_Name;
            SqlCmd.Parameters.Add("@year", SqlDbType.Int).Value = year;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static String LoadMC_PaymentDate(int year)
    {
        string mcyr = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  MC_Day+'/'+ MC_Month+'/'+MC_Year firstmcdate from MC_PaymentYear where  mc_year=@year and MC_Status = 'Active'", cs1);
            SqlCmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            mcyr = (string)SqlCmd.ExecuteScalar();
        }
        return mcyr;

    }
   public static String GetFinanceNum(string venue, string finance)
    {

        string financeno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select case when FinanceMethod_Name ='Pashuram Finance' then financecode+FinanceIncrval else financecode + '/' + REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '') + '/' + FinanceIncrval + 'EU' end as no from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance  and FinanceMethod_Status='Active'", cs1); 
          //  SqlCommand SqlCmd = new SqlCommand(" select financecode+FinanceIncrval   from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance  and FinanceMethod_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            financeno = (string)SqlCmd.ExecuteScalar();
        }
        return financeno;


    }
    public static int SecondaryprofileExists(string Profile_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             SqlCommand scd = new SqlCommand("select Profile_ID from Profile_Secondary where Profile_ID =@Profile_ID", cs1);
            scd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

    public static int Sub_Profile1Exists(string Profile_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Profile_ID from Sub_Profile1 where Profile_ID =@Profile_ID", cs1);
            scd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

    public static int Sub_Profile2Exists(string Profile_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Profile_ID from Sub_Profile2 where Profile_ID =@Profile_ID", cs1);
            scd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int Sub_Profile3Exists(string Profile_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Profile_ID from Sub_Profile3 where Profile_ID =@Profile_ID", cs1);
            scd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

    public static int Sub_Profile4Exists(string Profile_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Profile_ID from Sub_Profile4 where Profile_ID =@Profile_ID", cs1);
            scd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int InsertContract_Correspondence_Address(string Address_ID, string Address_Line1, string Address_Line2, string Address_State, string Address_city, string Address_Postcode, string Address_Country, string Profile_ID, string ContractDetails_ID, DateTime Address_Created_Date, string Address_Expiry_Date)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Correspondence_Address values(@Address_ID ,	@Address_Line1,	@Address_Line2 ,@Address_State,	@Address_city, 	@Address_Postcode ,@Address_Country,@Profile_ID,@ContractDetails_ID,@Address_Created_Date,	@Address_Expiry_Date )", cs1);
                da.InsertCommand.Parameters.Add("@Address_ID ", SqlDbType.VarChar).Value = Address_ID;
                da.InsertCommand.Parameters.Add("@Address_Line1 ", SqlDbType.VarChar).Value = Address_Line1;
                da.InsertCommand.Parameters.Add("@Address_Line2 ", SqlDbType.VarChar).Value = Address_Line2;
                da.InsertCommand.Parameters.Add("@Address_State ", SqlDbType.VarChar).Value = Address_State;
                da.InsertCommand.Parameters.Add("@Address_city ", SqlDbType.VarChar).Value = Address_city;
                da.InsertCommand.Parameters.Add("@Address_Postcode ", SqlDbType.VarChar).Value = Address_Postcode;
                da.InsertCommand.Parameters.Add("@Address_Country ", SqlDbType.VarChar).Value = Address_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID ", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@Address_Created_Date ", SqlDbType.DateTime).Value = Address_Created_Date;
                da.InsertCommand.Parameters.Add("@Address_Expiry_Date ", SqlDbType.VarChar).Value = Address_Expiry_Date;
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Profile Address Query " + ex.Message);
                string msg = "Error in Insert Correspondence Address Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
            rowsAffected = da.InsertCommand.ExecuteNonQuery();
        }
        return (rowsAffected);
    }
    public static String GetContract_Correspondence_Address_ID(string office)//(string off)
    {
        string ContractDetails_Indian_ID = "";
        string firstpart = "CAD";

        int id;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            //get last code of profile n increment by 1
            SqlCommand scd1 = new SqlCommand("select Contract_Correspondence_Address_ID  from ContractTableIDGeneration where office=@office", cs1);
            scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            string val = (string)scd1.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            ContractDetails_Indian_ID = firstpart + id;
        }

        return ContractDetails_Indian_ID;
    }
    public static int UpdateContract_Correspondence_Address_ID(string office)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Contract_Correspondence_Address_ID  from ContractTableIDGeneration where office=@office", cs1);
                scd1.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;

                SqlCommand sqlcmd = new SqlCommand("UPDATE ContractTableIDGeneration SET Contract_Correspondence_Address_ID=@id where office=@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Correspondence_Address_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static DataSet LoadProfile_PrimaryLang(string Profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select * from Profile_Primary  where Profile_ID = @Profile_ID  ", cs1);
            SqlCmd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
 

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

 public static int Contract_Correspondence_AddressExists(string Profile_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Profile_ID from Contract_Correspondence_Address where Profile_ID =@Profile_ID", cs1);
            scd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
 public static DataSet LoadExchange_Rate()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from Exchange_Rate where ERates_Status='active' and office='HML' ", cs1);

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataTable Leaseback_FractionalProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("LeaseBackAgreement_India", con);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

  public static string GetOfficeOnVenueCountry(string venueCountry)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_Country_Office from VenueCountry where Venue_Country_Name=@venueCountry", cs1);
            scd.Parameters.Add("@venueCountry", SqlDbType.VarChar).Value = venueCountry;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
 public static SqlDataReader LoadSubVenueGroup(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select  Sub_Venue_Group from profile  WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;

    }

public static DataSet onLoadLeadOffice(string profileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Office from LeadSourceOffice where status='active'  and Office not in(select leadOffice from profile where Profile_ID='"+profileID+"')", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

public static DataSet onLoadSubVenue(string venue , string groupVenue ,string profileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select svi.SVenue_India_Name as SVenue_India_Name  from sub_venue_india svi join Venue_Group vg on vg.Venue_Group_ID = svi.GroupVenue_ID join venue v on v.Venue_ID = vg.Venue_ID where vg.Venue_Group_Name = '" + groupVenue+"' and v.Venue_Name = '"+venue+"' and svi.SVenue_India_Status = 'Active' and  svi.SVenue_India_Name not in(select subvenue from profile where profile_id = '"+profileID+"')", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataTable dsr_india_acc1(string DATE, string COUNTRY, string CURR, string VENUE, string CLUB, string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_B1_Acc", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@CURR", CURR);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);
            cmd_sp.Parameters.AddWithValue("@CLUB", CLUB);
            cmd_sp.Parameters.AddWithValue("@venuegroup", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static DataTable dsr_india_acc2(string DATE, string COUNTRY, string CURR, string VENUE, string CLUB, string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_B2_Acc", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@CURR", CURR);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);
            cmd_sp.Parameters.AddWithValue("@CLUB", CLUB);
            cmd_sp.Parameters.AddWithValue("@venuegroup", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable dsr_india_acc3(string DATE, string COUNTRY, string CURR, string VENUE, string CLUB, string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_BS_Acc", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@CURR", CURR);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);
            cmd_sp.Parameters.AddWithValue("@CLUB", CLUB);
            cmd_sp.Parameters.AddWithValue("@venuegroup", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static DataTable dsr_india_acc4(string DATE, string COUNTRY, string CURR, string VENUE, string CLUB, string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_BS2_Acc", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@CURR", CURR);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);
            cmd_sp.Parameters.AddWithValue("@CLUB", CLUB);
            cmd_sp.Parameters.AddWithValue("@venuegroup", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

  public static DataSet LoadProfileMktg1(string ProfileID, string venue, string venuegrp)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand(" select distinct Marketing_Program_Name   from Marketing_Program   where Marketing_Program_Status ='active' and Marketing_Program_Name  not in(select Profile_Marketing_Program   from Profile where Profile_ID=@ProfileID) ", cs1);
            //SqlCommand SqlCmd = new SqlCommand("select distinct m.Marketing_Program_Name,m.Marketing_Program_abbrv  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name = @venue and vg.Venue_Group_Name = @venuegrp and m.Marketing_Program_Status = 'Active' and m.Marketing_Program_abbrv not in(Select profile_marketing_program from profile where profile_id =@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand("select distinct m.Marketing_Program_Name,m.Marketing_Program_abbrv  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name = @venue and vg.Venue_Group_Name = @venuegrp   and m.Marketing_Program_abbrv not in(Select profile_marketing_program from profile where profile_id =@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadMarktOnCode(string code, string venue, string venueGroup)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand(" select distinct Marketing_Program_Name   from Marketing_Program   where Marketing_Program_Status ='active' and Marketing_Program_Name  not in(select Profile_Marketing_Program   from Profile where Profile_ID=@ProfileID) ", cs1);
            //SqlCommand SqlCmd = new SqlCommand(" select m.Marketing_Program_Name,m.Marketing_Program_abbrv from Marketing_Program m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where Marketing_Program_abbrv = '" + code + "' and Marketing_Program_Status = 'Active' and v.Venue_Name = '" + venue + "' and vg.Venue_Group_Name = '" + venueGroup + "'", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select m.Marketing_Program_Name,m.Marketing_Program_abbrv from Marketing_Program m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where Marketing_Program_abbrv = '" + code + "'   and v.Venue_Name = '" + venue + "' and vg.Venue_Group_Name = '" + venueGroup + "'", cs1);
            SqlCmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

  public static String getMarketingAbbOnMarketingProgram(string venue,string venueGroup,string program)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select m.Marketing_Program_abbrv from Marketing_Program m join Venue_Group vg on vg.Venue_Group_ID=m.Venue_Group_ID join venue v on v.Venue_ID=vg.Venue_ID where Marketing_Program_Name=@program and Marketing_Program_Status='Active' and v.Venue_Name=@venue and vg.Venue_Group_Name=@venueGroup", cs1);
            scd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            scd.Parameters.Add("@venueGroup", SqlDbType.VarChar).Value = venueGroup;
            scd.Parameters.Add("@program", SqlDbType.VarChar).Value = program;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }

 public static int InsertCRM_details(string Profile_ID, string contractdetails_id, string program_source, string Referred_By, string comment1,string created_date, string updated_date, string createdby, string updatedby,string status)
    {
         
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //try
            //{
            da.InsertCommand = new SqlCommand("insert into CRM_details values(@Profile_ID,	@contractdetails_id ,@program_source ,@Referred_By ,@comment1 , @created_date,  @updated_date, @createdby, @updatedby,@status)", cs1);
            da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            da.InsertCommand.Parameters.Add("@contractdetails_id ", SqlDbType.VarChar).Value = contractdetails_id;
            da.InsertCommand.Parameters.Add("@program_source ", SqlDbType.VarChar).Value = program_source;
            da.InsertCommand.Parameters.Add("@Referred_By ", SqlDbType.VarChar).Value = Referred_By;
            da.InsertCommand.Parameters.Add("@comment1 ", SqlDbType.VarChar).Value = comment1;
            da.InsertCommand.Parameters.Add("@created_date", SqlDbType.VarChar).Value = created_date;
            da.InsertCommand.Parameters.Add("@updated_date ", SqlDbType.VarChar).Value = updated_date;
            da.InsertCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby;
            da.InsertCommand.Parameters.Add("@updatedby", SqlDbType.VarChar).Value = updatedby; 
            da.InsertCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            rowsAffected = da.InsertCommand.ExecuteNonQuery();

        }
        return (rowsAffected);
    }

    public static String GetTimeshareContractNoIndian_MemberAmb(string venue, string club, string venuegrp)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code+'OR' from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality ='INDIAN' or cc.Nationality ='Indian')", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }
    public static String GetTimeshareContractNoNonIndian_MemberAmb(string venue, string club, string venuegrp)//, string nationality)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code + '/' + REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '') + '/' + Increment_Value + vg.Venue_group_Code+'OR' from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality !='INDIAN'  or cc.Nationality !='Indian')", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;

            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }
    public static SqlDataReader CheckContractNo(string contractno)
    {
        
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select contractno from contractdetails_indian where contractno =@contractno", cs1);
        SqlCmd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;      
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }
  public static int UpdateContract_PA_IndianUSDConversion(string  USDConvertedVolume,string  USDConvertedAdminfee,string USDConvertedTax, string USDConverteddeposit,  string total_tax, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_PA_Indian  SET USDConvertedVolume = '" + USDConvertedVolume + "', USDConvertedAdminfee = '" + USDConvertedAdminfee + "',USDConvertedTax = '" + USDConvertedTax + "',USDConverteddeposit = '" + USDConverteddeposit + "', total_tax='" + total_tax + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContract_PA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static int UpdateContractDetails_IndianBuUpdown(string bu6, string updowngrade, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                 SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET BU_A6= '" + bu6 + "',	Updowngrade= '" + updowngrade + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContractDetails_IndianBuUpdown Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static int UpdateFinanceMonth_Indian(string financeMonth,    string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Finance_Details_Indian  SET financeMonth='" + financeMonth + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateFinanceDetails_Indian Query " + " " + ex.Message;
                throw new Exception(msg, ex);
 
            }

        }
        return rows;
    }

    public static String GetFractionalContractNo(string venue, string club)//, string nationality)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when venue like '%roadshow%' then (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'RSHM' else '' end) else (case when Contract_Resort_Name ='Karma Haathi Mahal' then 'HM' else '' end) end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }

    public static int UpdateFractionalContractNo(string venue, string club)//, string nationality)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Increment_Value from Contract_ResortCode_Generation   where    Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue =@venue", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
              
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from Contract_ResortCode_Generation cc  where    cc.Contract_Resort_Name=@club and cc.Contract_Resort_Status = 'active' and cc.venue =@venue ", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;      
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

              

                string msg = "Error in UPDATE Contract_ResortCode_Generation Query " + " " + ex.Message;

                throw new Exception(msg, ex);

             
            }

        }
        return rows;
    }

   public static string  LoadIndian_FinReceiptGeneration(string venue)
    {

        string recno;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select IncrementValue from FinancialYearReceiptGeneration   where venue=@venue and status='Active'", cs1);
            scd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            recno = (string)scd.ExecuteScalar();

        }
        return recno;
    }
   public static int InsertContract_Indian_Deposit_Receipt_Deleted(string Deposit_Receipt_Id, string ContractDetails_ID, string ContractNo, string Receipt_No, string Receipt_Date, string place_supply, string state, string state_code, string Product_Name, string SAC, string Amount, string taxable_value, string cgstrate, string cgstamt, string sgstrate, string sgstamt, string totalamt, string Payment_Mode, string actual_currency, string converted_currency, string Converted_rate, string ExchangedValue_date, string Actual_Amt, string receipttype, string Receipt_Status,string payment_date,string Total_deposit,string USDTotal_deposit,string Previous_DepositAmt,string floodcess)
    {
        int rowsAffected = 0;
 

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Indian_Deposit_Receipt_Deleted values(@Deposit_Receipt_Id,@ContractDetails_ID ,	 @ContractNo ,	@Receipt_No ,	 @Receipt_Date  ,	@place_supply ,	@state ,	@state_code ,	@Product_Name,	@SAC ,	@Amount,@taxable_value,@cgstrate,@cgstamt,@sgstrate,@sgstamt,@totalamt,@Payment_Mode,@actual_currency,@converted_currency,@Converted_rate,@ExchangedValue_date,@Actual_Amt,@Receipt_Status,@receipttype,@payment_date,@Total_deposit,@USDTotal_deposit ,@Previous_DepositAmt,@floodcess)", cs1);
                da.InsertCommand.Parameters.Add("@Deposit_Receipt_Id", SqlDbType.VarChar).Value = Deposit_Receipt_Id;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Receipt_No", SqlDbType.VarChar).Value = Receipt_No;
                da.InsertCommand.Parameters.Add("@Receipt_Date", SqlDbType.VarChar).Value = Receipt_Date;
                da.InsertCommand.Parameters.Add("@place_supply", SqlDbType.VarChar).Value = place_supply;
                da.InsertCommand.Parameters.Add("@state", SqlDbType.VarChar).Value = state;
                da.InsertCommand.Parameters.Add("@state_code", SqlDbType.VarChar).Value = state_code;
                da.InsertCommand.Parameters.Add("@Product_Name", SqlDbType.VarChar).Value = Product_Name;
                da.InsertCommand.Parameters.Add("@SAC", SqlDbType.VarChar).Value = SAC;
                da.InsertCommand.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount;
                da.InsertCommand.Parameters.Add("@taxable_value", SqlDbType.VarChar).Value = taxable_value;
                da.InsertCommand.Parameters.Add("@cgstrate", SqlDbType.VarChar).Value = cgstrate;
                da.InsertCommand.Parameters.Add("@cgstamt", SqlDbType.VarChar).Value = cgstamt;
                da.InsertCommand.Parameters.Add("@sgstrate", SqlDbType.VarChar).Value = sgstrate;
                da.InsertCommand.Parameters.Add("@sgstamt", SqlDbType.VarChar).Value = sgstamt;
                da.InsertCommand.Parameters.Add("@totalamt", SqlDbType.VarChar).Value = totalamt;
                da.InsertCommand.Parameters.Add("@Payment_Mode", SqlDbType.VarChar).Value = Payment_Mode;
                da.InsertCommand.Parameters.Add("@actual_currency", SqlDbType.VarChar).Value = actual_currency;
                da.InsertCommand.Parameters.Add("@converted_currency", SqlDbType.VarChar).Value = converted_currency;
                da.InsertCommand.Parameters.Add("@Converted_rate", SqlDbType.VarChar).Value = Converted_rate;
                da.InsertCommand.Parameters.Add("@ExchangedValue_date", SqlDbType.VarChar).Value = ExchangedValue_date;
                da.InsertCommand.Parameters.Add("@Actual_Amt", SqlDbType.VarChar).Value = Actual_Amt;
                da.InsertCommand.Parameters.Add("@Receipt_Status", SqlDbType.VarChar).Value = Receipt_Status;
                da.InsertCommand.Parameters.Add("@receipttype", SqlDbType.VarChar).Value = receipttype;
                da.InsertCommand.Parameters.Add("@payment_date", SqlDbType.VarChar).Value = payment_date;
                da.InsertCommand.Parameters.Add("@Total_deposit", SqlDbType.VarChar).Value = Total_deposit;
                da.InsertCommand.Parameters.Add("@USDTotal_deposit", SqlDbType.VarChar).Value = USDTotal_deposit;
                da.InsertCommand.Parameters.Add("@Previous_DepositAmt", SqlDbType.VarChar).Value = Previous_DepositAmt;
                da.InsertCommand.Parameters.Add("@floodcess", SqlDbType.VarChar).Value = floodcess;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                

                string msg = "Error in Insert Contract_Indian_Deposit_Receipt" + " " + ex.Message;

                throw new Exception(msg, ex);
 
            }
        }
        return (rowsAffected);
    }

    public static DataSet LoadContract_Indian_Deposit_ReceiptOnDeposit_Receipt_Id(string Deposit_Receipt_Id)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from Contract_Indian_Deposit_Receipt where  Deposit_Receipt_Id=@Deposit_Receipt_Id", cs1);
            scd.Parameters.Add("@Deposit_Receipt_Id", SqlDbType.VarChar).Value = Deposit_Receipt_Id;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    
    public static int DeleteContract_Indian_Deposit_ReceiptOnDeposit(string Deposit_Receipt_Id)
    {
        int rows = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqlcmd = new SqlCommand(" delete   from Contract_Indian_Deposit_Receipt where Deposit_Receipt_Id=@Deposit_Receipt_Id", cs1);
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@Deposit_Receipt_Id";
            para.Value = Deposit_Receipt_Id;
            sqlcmd.Parameters.Add(para);
            rows = sqlcmd.ExecuteNonQuery();
        }
        return rows;
    }
    public static int CheckDeposit_Receipt_IdExists(string Deposit_Receipt_Id)
    {

        int exists;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Deposit_Receipt_Id from Contract_Indian_Deposit_Receipt_Deleted where  Deposit_Receipt_Id=@Deposit_Receipt_Id", cs1);
            scd.Parameters.Add("@Deposit_Receipt_Id", SqlDbType.VarChar).Value = Deposit_Receipt_Id;
            SqlDataReader dr = scd.ExecuteReader();
           
            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

    public static DataSet LoadContract_Indian_Deposit_ReceiptActiveOnlyDeposit(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from Contract_Indian_Deposit_Receipt where  ContractDetails_ID=@ContractDetails_ID and Receipt_Status='Active' and receipttype='Deposit'", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
     public static int UpdateReceiptNoIndian(string ContractNo, string Receipt_No,string Payment_Mode,   string ContractDetails_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Indian_Deposit_Receipt SET ContractNo = '" + ContractNo + "',  Receipt_No = '" + Receipt_No + "',Payment_Mode='"+ Payment_Mode+"' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                

                string msg = "Error in UPDATE UpdateReceiptNoIndian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

         
            }
        }
        return (rowsaffected);
    }
   public static int UpdateContract_Fractional_PA_IndianUSDConversion(string USDConvertedFVolume, string USDConvertedFAdminfee, string USDConvertedFTax, string USDConvertedFdeposit, string total_tax, string ContractDetails_ID)
    {
        
          
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Fractional_PA_Indian  SET USDConvertedFVolume = '" + USDConvertedFVolume + "', USDConvertedFAdminfee = '" + USDConvertedFAdminfee + "',USDConvertedFTax = '" + USDConvertedFTax + "',USDConvertedFdeposit = '" + USDConvertedFdeposit + "', total_tax='" + total_tax + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

           

                string msg = "Error in UPDATE UpdateContract_Fractional_PA_IndianUSDConversion Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                
            }

        }
        return rows;
    }

    public static DataTable DealsGoneThroughReport(string date, string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand cmd_sp = new SqlCommand("DealsGoneThrough", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;


        }


    }

    public static SqlDataReader getContractIDOnContractNo(string contractNo)
    {

        SqlConnection cs1 = Queries.GetDBConnection();
         SqlCommand SqlCmd = new SqlCommand("select distinct ContractDetails_ID from ContractDetails_Indian where ContractNo='" + contractNo + "'", cs1);
        SqlCmd.Parameters.Add("@contractNo", SqlDbType.VarChar).Value = contractNo;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }

    public static SqlDataReader getcontractTeamDetailsOnContractID(string contractID) 
    {

        SqlConnection cs1 = Queries.GetDBConnection();
         SqlCommand SqlCmd = new SqlCommand("select distinct Rep_report,To_report,SMS_Update,Approval_comments from contractTeamDetails where contractDetails_ID='" + contractID + "'", cs1);
        SqlCmd.Parameters.Add("@contractID", SqlDbType.VarChar).Value = contractID;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
    
 
 

    public static int InsertContractTeamDetails(string ContractDetails_ID, string Approval_Comments, string Rep_report, string To_report, string SMS_Update, string Created_Date, string CreatedBy, string Updated_Date, string UpdatedBy)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into ContractTeamDetails values(@ContractDetails_ID,@Approval_Comments,@Rep_report, @To_report, @SMS_Update, @Created_Date, @CreatedBy, @Updated_Date,@UpdatedBy)", cs1);
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@Approval_Comments", SqlDbType.VarChar).Value = Approval_Comments;
                da.InsertCommand.Parameters.Add("@Rep_report", SqlDbType.VarChar).Value = Rep_report;
                da.InsertCommand.Parameters.Add("@To_report", SqlDbType.VarChar).Value = To_report;
                da.InsertCommand.Parameters.Add("@SMS_Update", SqlDbType.VarChar).Value = SMS_Update;
                da.InsertCommand.Parameters.Add("@Created_Date", SqlDbType.VarChar).Value = Created_Date;
                da.InsertCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;         
                da.InsertCommand.Parameters.Add("@Updated_Date", SqlDbType.VarChar).Value = Updated_Date;
                da.InsertCommand.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = UpdatedBy;
 

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

              

                string msg = "Error in Insert InsertContractTeamDetails Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static int UpdateContractTeamDetails(string Approval_Comments, string Rep_report, string To_report, string SMS_Update, string Updated_Date, string UpdatedBy,string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                 SqlCommand scd = new SqlCommand("update ContractTeamDetails  SET Approval_Comments = '" + Approval_Comments + "', Rep_report = '" + Rep_report + "',To_report = '" + To_report + "',SMS_Update = '" + SMS_Update + "',Updated_Date='" + Updated_Date + "', UpdatedBy = '" + UpdatedBy + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                
                string msg = "Error in UPDATE UpdateContractTeamDetails Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                
            }

        }
        return rows;
    }

    public static DataSet LoadContractTeamDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from ContractTeamDetails where  ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
  public static int UpdateContractDetails_IndianContract_Remark(string ContractDetails_ID, string Contract_Remark)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET Contract_Remark= '" + Contract_Remark + "'  where ContractDetails_ID ='" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateContractDetails_IndianContract_Remark Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }

    public static DataSet LoadCRM_details(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from CRM_details where  ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    
    public static int UpdateCRM_details(string ContractDetails_ID, string program_source,string Referred_By, string updated_date, string updatedby)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update CRM_details  SET program_source= '" + program_source + "',Referred_By='"+ Referred_By+ "', updated_date='"+ updated_date+ "',updatedby='"+ updatedby+"' where ContractDetails_ID ='" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateCRM_details Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }
 public static int DeleteContractDetails_Indian(string ContractDetails_ID)
    {
        int rows1 = 0;  
       using (SqlConnection cs1 = Queries.GetDBConnection())
         {
           
           SqlCommand sqlcmd1 = new SqlCommand("delete from ContractDetails_Indian  where ContractDetails_ID =@ContractDetails_ID", cs1);
 

          sqlcmd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
          
              rows1 = sqlcmd1.ExecuteNonQuery();  
            
            
        }
        return rows1;
         
    }
    public static int DeleteFinance_Details_Indian(string ContractDetails_ID)
    {
          int rows2 = 0;  
        
        using (SqlConnection cs1 = Queries.GetDBConnection())
         {

            
         SqlCommand sqlcmd2 = new SqlCommand("delete from Finance_Details_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
           

           
            sqlcmd2.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
        rows2 = sqlcmd2.ExecuteNonQuery();  
        }
        
         return rows2; 
        
    }
    public static int DeleteContract_PA_Indian(string ContractDetails_ID)
    {
         int rows3 = 0;  
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            
            SqlCommand sqlcmd3 = new SqlCommand(" delete from Contract_PA_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
        
           sqlcmd3.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
           rows3 = sqlcmd3.ExecuteNonQuery(); 

         }
       
        return rows3;
    }
    public static int DeleteContract_Points_Indian(string ContractDetails_ID)
    {
          int rows4 = 0;  
         using (SqlConnection cs1 = Queries.GetDBConnection())
        {

           
           SqlCommand sqlcmd4 = new SqlCommand(" delete from Contract_Points_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
          
           
            sqlcmd4.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
           rows4 = sqlcmd4.ExecuteNonQuery();  

        }
        return rows4;
    }
    public static int DeleteContract_Trade_In_Points_Indian(string ContractDetails_ID)
    {
          int rows5 = 0;
        
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {


            SqlCommand sqlcmd5 = new SqlCommand(" delete from  Contract_Trade_In_Points_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);



         sqlcmd5.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;

            rows5 = sqlcmd5.ExecuteNonQuery();



       }
        return rows5;
    }
    public static int DeleteContract_Trade_In_Weeks_Indian(string ContractDetails_ID)
    {
        
        int rows6 = 0; 
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {
 
            SqlCommand sqlcmd6 = new SqlCommand("delete from Contract_Trade_In_Weeks_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            

          
          sqlcmd6.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
           
            
          rows6 = sqlcmd6.ExecuteNonQuery();  

       }
       
         return rows6; 
    }
    public static int DeleteContract_Indian_Deposit_Receipt(string ContractDetails_ID)
    {
          int rows7 = 0; 
         using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            
           SqlCommand sqlcmd7 = new SqlCommand(" delete from Contract_Indian_Deposit_Receipt where ContractDetails_ID =@ContractDetails_ID", cs1);
           
       sqlcmd7.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
        rows7 = sqlcmd7.ExecuteNonQuery();  


        }
        return rows7;  
    }
    public static int DeleteContract_Fractional_Indian(string ContractDetails_ID)
    {
       int rows8 = 0; 
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {

         SqlCommand sqlcmd8 = new SqlCommand("delete from Contract_Fractional_Indian  where ContractDetails_ID =@ContractDetails_ID", cs1);

           
         sqlcmd8.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
             
          rows8 = sqlcmd8.ExecuteNonQuery();  


        }
         return rows8 = 0; 
    }
    public static int DeleteContract_Trade_In_Fractional_Indian(string ContractDetails_ID)
    {
          int rows9 = 0;  
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {

             
          SqlCommand sqlcmd9 = new SqlCommand(" delete from  Contract_Trade_In_Fractional_Indian where ContractDetails_ID=@ContractDetails_ID", cs1);
            
         sqlcmd9.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
         rows9 = sqlcmd9.ExecuteNonQuery(); 


        }
        return rows9;
    }
    public static int DeleteContract_Fractional_PA_Indian(string ContractDetails_ID)
    {
         int rows10 = 0;
        
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            
      SqlCommand sqlcmd10 = new SqlCommand(" delete from  Contract_Fractional_PA_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
           
           sqlcmd10.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
          rows10 = sqlcmd10.ExecuteNonQuery();
           

        }
        return rows10;
       
    }
    public static int DeleteContract_Installments_IndianRows(string ContractDetails_ID)
    {
         int rows12 = 0; 
        using (SqlConnection cs1 = Queries.GetDBConnection())
         {

          
            
           SqlCommand sqlcmd12 = new SqlCommand(" delete from  Contract_Installments_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
             

          
          sqlcmd12.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
         rows12 = sqlcmd12.ExecuteNonQuery();  


         }
     return rows12;  
    }
    public static int DeleteContractNo_Othernamestablerows(string ContractDetails_ID)
    {
        int rows13 = 0;  
        using (SqlConnection cs1 = Queries.GetDBConnection())
         {

           
        SqlCommand sqlcmd13 = new SqlCommand("  delete from ContractNo_Othernames where ContractDetails_ID =@ContractDetails_ID", cs1);
           
            sqlcmd13.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
          rows13 = sqlcmd13.ExecuteNonQuery();  


        }
        return rows13;
    }
    public static int DeleteContract_Installments_Indian_Deleted(string ContractDetails_ID)
    {
        int rows14 = 0; 
         using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            
             SqlCommand sqlcmd14 = new SqlCommand(" delete from Contract_Installments_Indian_Deleted where ContractDetails_ID=@ContractDetails_ID", cs1);
            
          sqlcmd14.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            rows14 = sqlcmd14.ExecuteNonQuery(); 


        }
        return rows14;
    }
    public static int DeleteContract_Logs_India(string ContractDetails_ID)
    {
          int rows15 = 0;
         
        //using (SqlConnection cs1 = Queries.GetDBConnection())
        //{
        //    SqlCommand sqlcmd15 = new SqlCommand(" delete from Contract_Logs_India where ContractDetails_ID=@ContractDetails_ID", cs1);           
        //    sqlcmd15.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
        //    rows15 = sqlcmd15.ExecuteNonQuery();
           

        //}
        return rows15;
    }
    public static int DeleteContractTeamDetails(string ContractDetails_ID)
    {
         
        int rows16 = 0;  
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            
            SqlCommand sqlcmd16 = new SqlCommand("delete from ContractTeamDetails where ContractDetails_ID =@ContractDetails_ID", cs1);
            
          sqlcmd16.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
          
          rows16 = sqlcmd16.ExecuteNonQuery();  


       }
        
         return rows16;  
    }
  
  
    public static int DeleteCRM_details(string ContractDetails_ID)
    {
        int rows17 = 0; 
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {
            SqlCommand sqlcmd17 = new SqlCommand(" delete from CRM_details where ContractDetails_ID=@ContractDetails_ID", cs1);         
            sqlcmd17.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;          
          rows17 = sqlcmd17.ExecuteNonQuery(); 


        }
         return rows17; 
    }
    public static int DeleteFinance_Breakup(string ContractDetails_ID)
    {
        int rows18 = 0;
         using (SqlConnection cs1 = Queries.GetDBConnection())
         { 
            SqlCommand sqlcmd18 = new SqlCommand(" delete from Finance_Breakup where ContractDetails_ID =@ContractDetails_ID", cs1);            
           sqlcmd18.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
           rows18 = sqlcmd18.ExecuteNonQuery();


         }
        return rows18;

    }

	 public static int CheckContract_Installments_Indian_ContractNoExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Contract_Installments_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }
  public static DataTable DealsGoneThroughDateRangeReport(string date,string edate, string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand cmd_sp = new SqlCommand("DealsGoneThroughDateRange", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@EDATE", edate);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;


        }


    }


  public static DataTable DealsGoneThroughDateRangeReportOutSideIndia(string date, string edate, string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand cmd_sp = new SqlCommand("DealsGoneThroughDateRangeOutsideIndia", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@EDATE", edate);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;


        }


    }

  public static DataTable inhousegoacon(string date)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("InhouseGoaConso", cs1);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", date);
            //cmd_sp.Parameters.AddWithValue("@gvenue", gvenue);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

  public static DataTable inhousegoaconbyLeadsource(string date)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("InhouseGoaleadsource", cs1);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", date);
            //cmd_sp.Parameters.AddWithValue("@gvenue", gvenue);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

 public static String GetFractionalContractNoAmb(string venue, string club)//, string nationality)
    {
        string contractno = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+'OR' from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            contractno = (string)SqlCmd.ExecuteScalar();
        }

        return contractno;
    }
    
    
   
    public static DataSet LoadSORnAddtionalNames(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             SqlCommand scd = new SqlCommand("select * from ContractNo_Othernames where  ContractDetails_ID=@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int Identity_Proof_DetailsExists(string Profile_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Profile_ID from Identity_Proof_Details where Profile_ID =@Profile_ID", cs1);
            scd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int InsertIdentity_Proof_Details(string Profile_ID, string Primary_ID_Type, string Primary_ID_Num,  string Primary_ID_Type2, string Primary_ID_Num2, string Insert_Date)
    {
        string Secondary_ID_Type = "";
        string Secondary_ID_Num = "";
        string Secondary_ID_Type2 = "";
        string @Secondary_ID_Num2 = "";
        string SP1_ID_Type = "";
        string SP1_ID_Num = "";
        string SP2_ID_Type = "";
        string SP2_ID_Num = "";
        string SP3_ID_Type = "";
        string SP3_ID_Num = "";
        string SP4_ID_Type = "";
        string SP4_ID_Num = "";
     

        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Identity_Proof_Details values(@Profile_ID,@Primary_ID_Type ,	@Primary_ID_Num,@Secondary_ID_Type ,@Secondary_ID_Num, @Primary_ID_Type2, @Primary_ID_Num2, @Secondary_ID_Type2, @Secondary_ID_Num2 , @SP1_ID_Type, @SP1_ID_Num, @SP2_ID_Type, @SP2_ID_Num, @SP3_ID_Type, @SP3_ID_Num, @SP4_ID_Type, @SP4_ID_Num, @Insert_Date)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Primary_ID_Type ", SqlDbType.VarChar).Value = Primary_ID_Type;
                da.InsertCommand.Parameters.Add("@Primary_ID_Num ", SqlDbType.VarChar).Value = Primary_ID_Num;
                da.InsertCommand.Parameters.Add("@Secondary_ID_Type ", SqlDbType.VarChar).Value = Secondary_ID_Type;
                da.InsertCommand.Parameters.Add("@Secondary_ID_Num ", SqlDbType.VarChar).Value = Secondary_ID_Num;
                da.InsertCommand.Parameters.Add("@Primary_ID_Type2 ", SqlDbType.VarChar).Value = Primary_ID_Type2;
                da.InsertCommand.Parameters.Add("@Primary_ID_Num2 ", SqlDbType.VarChar).Value = Primary_ID_Num2;
                da.InsertCommand.Parameters.Add("@Secondary_ID_Type2 ", SqlDbType.VarChar).Value = Secondary_ID_Type2;   
                da.InsertCommand.Parameters.Add("@Secondary_ID_Num2 ", SqlDbType.VarChar).Value = Secondary_ID_Num2;
                da.InsertCommand.Parameters.Add("@SP1_ID_Type", SqlDbType.VarChar).Value = SP1_ID_Type;
                 da.InsertCommand.Parameters.Add("@SP1_ID_Num", SqlDbType.VarChar).Value = SP1_ID_Num;
                 da.InsertCommand.Parameters.Add("@SP2_ID_Type", SqlDbType.VarChar).Value = SP2_ID_Type;
                 da.InsertCommand.Parameters.Add("@SP2_ID_Num", SqlDbType.VarChar).Value = SP2_ID_Num;
                  da.InsertCommand.Parameters.Add("@SP3_ID_Type", SqlDbType.VarChar).Value = SP3_ID_Type;
                  da.InsertCommand.Parameters.Add("@SP3_ID_Num", SqlDbType.VarChar).Value = SP3_ID_Num;
                 da.InsertCommand.Parameters.Add("@SP4_ID_Type", SqlDbType.VarChar).Value = SP4_ID_Type;
                 da.InsertCommand.Parameters.Add("@SP4_ID_Num", SqlDbType.VarChar).Value = SP4_ID_Num;
                 da.InsertCommand.Parameters.Add("@Insert_Date", SqlDbType.VarChar).Value = Insert_Date;
            }
            catch (Exception ex)
            {

                 
                string msg = "Error in Insert Identity_Proof_Details Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
            rowsAffected = da.InsertCommand.ExecuteNonQuery();
        }
        return (rowsAffected);
    }
    public static int UpdateIdentity_Proof_Details(string ProfileID, string Primary_ID_Num, string Primary_ID_Num2)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Identity_Proof_Details  SET  Primary_ID_Num ='" + Primary_ID_Num + "',Primary_ID_Num2='" + Primary_ID_Num2 + "' where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE Identity_Proof_Details Query " + " " + ex.Message;

                throw new Exception(msg, ex);  
            }
        }
        return (rowsaffected);
    }
    public static int UpdateContractDetails_IndianIDProofDetails(string ContractDetails_ID, string Pan_Card, string Client_GSTIN,string Company_PanNo)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET  Pan_Card ='" + Pan_Card + "',Client_GSTIN='" + Client_GSTIN + "',Company_PanNo='"+ Company_PanNo+ "' where ContractDetails_ID='" + ContractDetails_ID + "'", cs2);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE ContractDetails_IndianIdentity_Proof_Details Query " + " " + ex.Message;

                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }
    public static int ContractNoExistsAlongwithcount(string contractno)
    {
        int value = 0 ;
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select contractno from ContractDetails_Indian where contractno =@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                // exists = 1;
                SqlCommand scd2 = new SqlCommand("  select count(*) from ContractDetails_Indian where contractno  =@contractno", cs1);
                scd2.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
                value = (int)scd2.ExecuteScalar();
                if(value==1)
                {
                    exists = 0;
                }
                else
                {
                    exists = 1;
                }
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

    public static int ContractDetailsIDInCRMDetailsExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from CRM_details where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInFinance_Details_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Finance_Details_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDIContractDetailsExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from contractdetails_indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
   public static int InsertDeletedFinance_Details_Indian(string Finance_Details_Id, string ProfileID, string ContractNo, string Finance_Method, string Currency, string Affiliate_Type, string Total_Price_Including_Tax, string Initial_Deposit_Percent, string Initial_Deposit_Amount, string Balance_Payable, string Total_Inital_Deposit, string Initial_Deposit_Balance, string Bal_Amount_Payable, string Payment_Method, string No_Installments, string Installment_Amount, string Finance_Type, string Finance_No, string IGSTrate, string Interestrate, string documentationfee, string IGST_Amount, string No_Emi, string Emi_Installment, string financeMonth, string Old_Loan_AgreementNo, string Registry_Collection_Term, string Registry_Collection_Amt, string ContractDetails_ID, string BalanceDeposit_Date, string Old_Loan_Amount, string eurorate, string loanamtINEuro, string monthlyPremiumprotectionplan,string Open_Loan_AgreementNo)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Finance_Details_Indian values(@Finance_Details_Id,@ProfileID,@ContractNo,@Finance_Method,@Currency,	@Affiliate_Type ,	@Total_Price_Including_Tax ,	@Initial_Deposit_Percent  ,	@Initial_Deposit_Amount  ,	@Balance_Payable  ,	@Total_Inital_Deposit  ,	@Initial_Deposit_Balance,	@Bal_Amount_Payable,@Payment_Method,@No_Installments,@Installment_Amount,@Finance_Type,@Finance_No,	@IGSTrate ,	@Interestrate ,	@documentationfee ,	@IGST_Amount,@No_Emi,@Emi_Installment,@financeMonth,@Old_Loan_AgreementNo,@Registry_Collection_Term,@Registry_Collection_Amt,@ContractDetails_ID,convert(datetime,@BalanceDeposit_Date,105),@Old_Loan_Amount,@eurorate,@loanamtINEuro,@monthlyPremiumprotectionplan,@Open_Loan_AgreementNo)", cs1);
                da.InsertCommand.Parameters.Add("@Finance_Details_Id ", SqlDbType.VarChar).Value = Finance_Details_Id;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Finance_Method ", SqlDbType.VarChar).Value = Finance_Method;
                da.InsertCommand.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
                da.InsertCommand.Parameters.Add("@Affiliate_Type", SqlDbType.VarChar).Value = Affiliate_Type;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Percent", SqlDbType.VarChar).Value = Initial_Deposit_Percent;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Amount", SqlDbType.VarChar).Value = Initial_Deposit_Amount;
                da.InsertCommand.Parameters.Add("@Balance_Payable", SqlDbType.VarChar).Value = Balance_Payable;
                da.InsertCommand.Parameters.Add("@Total_Inital_Deposit", SqlDbType.VarChar).Value = Total_Inital_Deposit;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Balance", SqlDbType.VarChar).Value = Initial_Deposit_Balance;
                da.InsertCommand.Parameters.Add("@Bal_Amount_Payable", SqlDbType.VarChar).Value = Bal_Amount_Payable;
                da.InsertCommand.Parameters.Add("@Payment_Method", SqlDbType.VarChar).Value = Payment_Method;
                da.InsertCommand.Parameters.Add("@No_Installments", SqlDbType.VarChar).Value = No_Installments;
                da.InsertCommand.Parameters.Add("@Installment_Amount", SqlDbType.VarChar).Value = Installment_Amount;
                da.InsertCommand.Parameters.Add("@Finance_Type", SqlDbType.VarChar).Value = Finance_Type;
                da.InsertCommand.Parameters.Add("@Finance_No", SqlDbType.VarChar).Value = Finance_No;
                da.InsertCommand.Parameters.Add("@IGSTrate", SqlDbType.VarChar).Value = IGSTrate;
                da.InsertCommand.Parameters.Add("@Interestrate", SqlDbType.VarChar).Value = Interestrate;
                da.InsertCommand.Parameters.Add("@documentationfee", SqlDbType.VarChar).Value = documentationfee;
                da.InsertCommand.Parameters.Add("@IGST_Amount", SqlDbType.VarChar).Value = IGST_Amount;
                da.InsertCommand.Parameters.Add("@No_Emi", SqlDbType.VarChar).Value = No_Emi;
                da.InsertCommand.Parameters.Add("@Emi_Installment", SqlDbType.VarChar).Value = Emi_Installment;
                da.InsertCommand.Parameters.Add("@financeMonth", SqlDbType.VarChar).Value = financeMonth;
                da.InsertCommand.Parameters.Add("@Old_Loan_AgreementNo", SqlDbType.VarChar).Value = Old_Loan_AgreementNo;
                da.InsertCommand.Parameters.Add("@Registry_Collection_Term", SqlDbType.VarChar).Value = Registry_Collection_Term;
                da.InsertCommand.Parameters.Add("@Registry_Collection_Amt", SqlDbType.VarChar).Value = Registry_Collection_Amt;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@BalanceDeposit_Date", SqlDbType.VarChar).Value = BalanceDeposit_Date;
                da.InsertCommand.Parameters.Add("@Old_Loan_Amount", SqlDbType.VarChar).Value = Old_Loan_Amount;
                da.InsertCommand.Parameters.Add("@eurorate", SqlDbType.VarChar).Value = eurorate;
                da.InsertCommand.Parameters.Add("@loanamtINEuro", SqlDbType.VarChar).Value = loanamtINEuro;
                da.InsertCommand.Parameters.Add("@monthlyPremiumprotectionplan", SqlDbType.VarChar).Value = monthlyPremiumprotectionplan;
                da.InsertCommand.Parameters.Add("@Open_Loan_AgreementNo", SqlDbType.VarChar).Value = Open_Loan_AgreementNo;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in   InsertDeletedFinance_Details_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

          
            }
        }
        return (rowsAffected);
    }
    public static int ContractDetailsIDInContract_PA_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_PA_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
   public static int InsertDeletedContract_PA_Indian(string Contract_PA_Id, string ProfileID, string ContractNo, string New_Points_Price, string Conversion_Fee, string Admin_Fee, string Total_Purchase_Price, string Cgst, string Sgst, string Total_Price_Including_Tax, string Deposit, string Balance, string Balance_Due_Dates, string Remarks, string ContractDetails_ID, string oldVolume, string oldadminfee, string oldTotalTax, string oldDeposit, string usdoldvolume, string usdoldadminfee, string usdoldtax, string usdolddeposit, string USDConvertedVolume, string USDConvertedAdminfee, string USDConvertedTax, string USDConverteddeposit,string total_tax,string USDConvertedTotalVolume, string exchangerate)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Contract_PA_Indian values(@Contract_PA_Id,@ProfileID,@ContractNo ,@New_Points_Price,@Conversion_Fee,	@Admin_Fee ,@Total_Purchase_Price ,	@Cgst ,	@Sgst ,	@Total_Price_Including_Tax ,@Deposit ,	@Balance,	@Balance_Due_Dates,	@Remarks,@ContractDetails_ID,@oldVolume,@oldadminfee, @oldTotalTax,@oldDeposit,@usdoldvolume,@usdoldadminfee,@usdoldtax,@usdolddeposit,@USDConvertedVolume,@USDConvertedAdminfee,@USDConvertedTax,@USDConverteddeposit,@total_tax,@USDConvertedTotalVolume,@exchangerate)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_PA_Id ", SqlDbType.VarChar).Value = Contract_PA_Id;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@New_Points_Price ", SqlDbType.VarChar).Value = New_Points_Price;
                da.InsertCommand.Parameters.Add("@Conversion_Fee", SqlDbType.VarChar).Value = Conversion_Fee;
                da.InsertCommand.Parameters.Add("@Admin_Fee", SqlDbType.VarChar).Value = Admin_Fee;
                da.InsertCommand.Parameters.Add("@Total_Purchase_Price", SqlDbType.VarChar).Value = Total_Purchase_Price;
                da.InsertCommand.Parameters.Add("@Cgst", SqlDbType.VarChar).Value = Cgst;
                da.InsertCommand.Parameters.Add("@Sgst", SqlDbType.VarChar).Value = Sgst;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Deposit ", SqlDbType.VarChar).Value = Deposit;
                da.InsertCommand.Parameters.Add("@Balance", SqlDbType.VarChar).Value = Balance;
                da.InsertCommand.Parameters.Add("@Balance_Due_Dates", SqlDbType.VarChar).Value = Balance_Due_Dates;
                da.InsertCommand.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@oldVolume", SqlDbType.VarChar).Value = oldVolume;
                da.InsertCommand.Parameters.Add("@oldadminfee", SqlDbType.VarChar).Value = oldadminfee;
                da.InsertCommand.Parameters.Add("@oldTotalTax", SqlDbType.VarChar).Value = oldTotalTax;
                da.InsertCommand.Parameters.Add("@oldDeposit", SqlDbType.VarChar).Value = oldDeposit;
                da.InsertCommand.Parameters.Add("@usdoldvolume", SqlDbType.VarChar).Value = usdoldvolume;
                da.InsertCommand.Parameters.Add("@usdoldadminfee", SqlDbType.VarChar).Value = usdoldadminfee;
                da.InsertCommand.Parameters.Add("@usdoldtax", SqlDbType.VarChar).Value = usdoldtax;
                da.InsertCommand.Parameters.Add("@usdolddeposit", SqlDbType.VarChar).Value = usdolddeposit;
                da.InsertCommand.Parameters.Add("@USDConvertedVolume", SqlDbType.VarChar).Value = USDConvertedVolume;
                da.InsertCommand.Parameters.Add("@USDConvertedAdminfee", SqlDbType.VarChar).Value = USDConvertedAdminfee;
                da.InsertCommand.Parameters.Add("@USDConvertedTax", SqlDbType.VarChar).Value = USDConvertedTax;
                da.InsertCommand.Parameters.Add("@USDConverteddeposit", SqlDbType.VarChar).Value = USDConverteddeposit;
                da.InsertCommand.Parameters.Add("@total_tax", SqlDbType.VarChar).Value = total_tax;
                da.InsertCommand.Parameters.Add("@USDConvertedTotalVolume", SqlDbType.VarChar).Value = USDConvertedTotalVolume;
                da.InsertCommand.Parameters.Add("@exchangerate", SqlDbType.VarChar).Value = exchangerate;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                string msg = "Error in  InsertDeletedContract_PA_Indian Query " + " " + ex.Message;
                throw new Exception(msg, ex);


            }
        }
        return (rowsAffected);
    }

    public static int ContractDetailsIDInContract_Points_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_Points_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int InsertDeletedContract_Points_Indian(string ContractPoints_ID, string ProfileID, string ContractNo, string club, string New_points_rights, string Type_membership, string Total_points_rights, string First_year_occupancy, string Tenure, string Last_year_occupancy, string NoPersons, string ContractDetails_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Contract_Points_Indian values(@ContractPoints_ID ,	@ProfileID ,	@ContractNo ,	@club,	@New_points_rights,	@Type_membership,	@Total_points_rights,	@First_year_occupancy,	@Tenure,	@Last_year_occupancy,@NoPersons,@ContractDetails_ID )", cs1);
                da.InsertCommand.Parameters.Add("@ContractPoints_ID ", SqlDbType.VarChar).Value = ContractPoints_ID;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                da.InsertCommand.Parameters.Add("@New_points_rights", SqlDbType.VarChar).Value = New_points_rights;
                da.InsertCommand.Parameters.Add("@Type_membership", SqlDbType.VarChar).Value = Type_membership;
                da.InsertCommand.Parameters.Add("@Total_points_rights", SqlDbType.VarChar).Value = Total_points_rights;
                da.InsertCommand.Parameters.Add("@First_year_occupancy", SqlDbType.VarChar).Value = First_year_occupancy;
                da.InsertCommand.Parameters.Add("@Tenure", SqlDbType.VarChar).Value = Tenure;
                da.InsertCommand.Parameters.Add("@Last_year_occupancy ", SqlDbType.VarChar).Value = Last_year_occupancy;
                da.InsertCommand.Parameters.Add("@NoPersons", SqlDbType.VarChar).Value = NoPersons;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Points_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static int ContractDetailsIDInContract_Trade_In_Points_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_Trade_In_Points_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

     public static int InsertDeletedContract_Trade_In_Points_Indian(string ContractTradeInPoint_ID, string ProfileID, string ContractNo, string Trade_In_Details_club_resort, string Trade_In_Details_No_rights, string Trade_In_Details_ContNo_RCINo, string Trade_In_Details_Points_value, string New_Club, string New_Club_Points_Rights, string New_MemebrshipType, string New_TotalPointsRights, string New_First_year_occupancy, string New_Tenure, string New_Last_year_occupancy, string NoPersons, string ContractDetails_ID, string Actualpoints_value,string OldMemtype)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Contract_Trade_In_Points_Indian values(@ContractTradeInPoint_ID,	@ProfileID,	@ContractNo,	@Trade_In_Details_club_resort,	@Trade_In_Details_No_rights,	@Trade_In_Details_ContNo_RCINo,	@Trade_In_Details_Points_value,	@New_Club,	@New_Club_Points_Rights,	@New_MemebrshipType,	@New_TotalPointsRights,	@New_First_year_occupancy,	@New_Tenure,	@New_Last_year_occupancy,@NoPersons,@ContractDetails_ID,@Actualpoints_value,@OldMemtype)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTradeInPoint_ID", SqlDbType.VarChar).Value = ContractTradeInPoint_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_club_resort", SqlDbType.VarChar).Value = Trade_In_Details_club_resort;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_No_rights", SqlDbType.VarChar).Value = Trade_In_Details_No_rights;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_ContNo_RCINo", SqlDbType.VarChar).Value = Trade_In_Details_ContNo_RCINo;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_Points_value", SqlDbType.VarChar).Value = Trade_In_Details_Points_value;
                da.InsertCommand.Parameters.Add("@New_Club", SqlDbType.VarChar).Value = New_Club;
                da.InsertCommand.Parameters.Add("@New_Club_Points_Rights", SqlDbType.VarChar).Value = New_Club_Points_Rights;
                da.InsertCommand.Parameters.Add("@New_MemebrshipType", SqlDbType.VarChar).Value = New_MemebrshipType;
                da.InsertCommand.Parameters.Add("@New_TotalPointsRights", SqlDbType.VarChar).Value = New_TotalPointsRights;
                da.InsertCommand.Parameters.Add("@New_First_year_occupancy", SqlDbType.VarChar).Value = New_First_year_occupancy;
                da.InsertCommand.Parameters.Add("@New_Tenure", SqlDbType.VarChar).Value = New_Tenure;
                da.InsertCommand.Parameters.Add("@New_Last_year_occupancy", SqlDbType.VarChar).Value = New_Last_year_occupancy;
                da.InsertCommand.Parameters.Add("@NoPersons", SqlDbType.VarChar).Value = NoPersons;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("Actualpoints_value", SqlDbType.VarChar).Value = Actualpoints_value;
                da.InsertCommand.Parameters.Add("OldMemtype", SqlDbType.VarChar).Value = OldMemtype;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in Insert deleteContract_Trade_In_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static int ContractDetailsIDInContract_Trade_In_Weeks_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_Trade_In_Weeks_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

   public static int InsertDeletedContract_Trade_In_Weeks_Indian(String ContractTradeInWeeks_ID, String ProfileID, String ContractNo, String Trade_In_Weeks_resort, String Trade_In_Weeks_Apt, string Trade_In_Weeks_Season, String Trade_In_Weeks_NoWks, String Trade_In_Weeks_ContNo_RCINo, String Trade_In_Weeks_Points_value, String NewPointsW_Club, String NewPointsW_Club_Points_Rights, String NewPointsW_MemebrshipType, String NewPointsW_Total_Points_rights, String NewPointsW_First_year_occupancy, String NewPointsW_Tenure, String NewPointsW_Last_year_occupancy, string NoPersons, string ContractDetails_ID,string OldMemtype,string Actualpoints_value)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Contract_Trade_In_Weeks_Indian values(@ContractTradeInWeeks_ID,	@ProfileID,	@ContractNo,	@Trade_In_Weeks_resort,	@Trade_In_Weeks_Apt ,@Trade_In_Weeks_Season,	@Trade_In_Weeks_NoWks,	@Trade_In_Weeks_ContNo_RCINo,	@Trade_In_Weeks_Points_value,	@NewPointsW_Club ,	@NewPointsW_Club_Points_Rights ,	@NewPointsW_MemebrshipType ,	@NewPointsW_Total_Points_rights ,	@NewPointsW_First_year_occupancy,	@NewPointsW_Tenure,	@NewPointsW_Last_year_occupancy,@NoPersons,@ContractDetails_ID,@OldMemtype,@Actualpoints_value)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTradeInWeeks_ID ", SqlDbType.VarChar).Value = ContractTradeInWeeks_ID;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_resort", SqlDbType.VarChar).Value = Trade_In_Weeks_resort;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Apt ", SqlDbType.VarChar).Value = Trade_In_Weeks_Apt;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Season", SqlDbType.VarChar).Value = Trade_In_Weeks_Season;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_NoWks ", SqlDbType.VarChar).Value = Trade_In_Weeks_NoWks;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_ContNo_RCINo", SqlDbType.VarChar).Value = Trade_In_Weeks_ContNo_RCINo;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Points_value", SqlDbType.VarChar).Value = Trade_In_Weeks_Points_value;
                da.InsertCommand.Parameters.Add("@NewPointsW_Club ", SqlDbType.VarChar).Value = NewPointsW_Club;
                da.InsertCommand.Parameters.Add("@NewPointsW_Club_Points_Rights ", SqlDbType.VarChar).Value = NewPointsW_Club_Points_Rights;
                da.InsertCommand.Parameters.Add("@NewPointsW_MemebrshipType ", SqlDbType.VarChar).Value = NewPointsW_MemebrshipType;
                da.InsertCommand.Parameters.Add("@NewPointsW_Total_Points_rights ", SqlDbType.VarChar).Value = NewPointsW_Total_Points_rights;
                da.InsertCommand.Parameters.Add("@NewPointsW_First_year_occupancy", SqlDbType.VarChar).Value = NewPointsW_First_year_occupancy;
                da.InsertCommand.Parameters.Add("@NewPointsW_Tenure", SqlDbType.VarChar).Value = NewPointsW_Tenure;
                da.InsertCommand.Parameters.Add("@NewPointsW_Last_year_occupancy", SqlDbType.VarChar).Value = NewPointsW_Last_year_occupancy;
                da.InsertCommand.Parameters.Add("@NoPersons", SqlDbType.VarChar).Value = NoPersons;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("OldMemtype", SqlDbType.VarChar).Value = OldMemtype;
                da.InsertCommand.Parameters.Add("Actualpoints_value", SqlDbType.VarChar).Value = Actualpoints_value;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               
                string msg = "Error in Insert Contract_Trade_In_Weeks_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static int ContractDetailsIDInContract_Indian_Deposit_ReceiptExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_Indian_Deposit_Receipt  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int InsertDeletedContract_Indian_Deposit_Receipt(string Deposit_Receipt_Id, string ContractDetails_ID, string ContractNo, string Receipt_No, string Receipt_Date, string place_supply, string state, string state_code, string Product_Name, string SAC, string Amount, string taxable_value, string cgstrate, string cgstamt, string sgstrate, string sgstamt, string totalamt, string Payment_Mode, string actual_currency, string converted_currency, string Converted_rate, string ExchangedValue_date, string Actual_Amt,string Receipt_Status, string receipttype,  string payment_date, string Total_deposit, string USDTotal_deposit, string Previous_DepositAmt,string floodcess)
    {
        int rowsAffected = 0;


        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Contract_Indian_Deposit_Receipt values(@Deposit_Receipt_Id,@ContractDetails_ID ,	 @ContractNo ,	@Receipt_No ,	 @Receipt_Date  ,	@place_supply ,	@state ,	@state_code ,	@Product_Name,	@SAC ,	@Amount,@taxable_value,@cgstrate,@cgstamt,@sgstrate,@sgstamt,@totalamt,@Payment_Mode,@actual_currency,@converted_currency,@Converted_rate,@ExchangedValue_date,@Actual_Amt,@Receipt_Status,@receipttype,@payment_date,@Total_deposit,@USDTotal_deposit ,@Previous_DepositAmt,@floodcess )", cs1);
                da.InsertCommand.Parameters.Add("@Deposit_Receipt_Id", SqlDbType.VarChar).Value = Deposit_Receipt_Id;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Receipt_No", SqlDbType.VarChar).Value = Receipt_No;
                da.InsertCommand.Parameters.Add("@Receipt_Date", SqlDbType.VarChar).Value = Receipt_Date;
                da.InsertCommand.Parameters.Add("@place_supply", SqlDbType.VarChar).Value = place_supply;
                da.InsertCommand.Parameters.Add("@state", SqlDbType.VarChar).Value = state;
                da.InsertCommand.Parameters.Add("@state_code", SqlDbType.VarChar).Value = state_code;
                da.InsertCommand.Parameters.Add("@Product_Name", SqlDbType.VarChar).Value = Product_Name;
                da.InsertCommand.Parameters.Add("@SAC", SqlDbType.VarChar).Value = SAC;
                da.InsertCommand.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount;
                da.InsertCommand.Parameters.Add("@taxable_value", SqlDbType.VarChar).Value = taxable_value;
                da.InsertCommand.Parameters.Add("@cgstrate", SqlDbType.VarChar).Value = cgstrate;
                da.InsertCommand.Parameters.Add("@cgstamt", SqlDbType.VarChar).Value = cgstamt;
                da.InsertCommand.Parameters.Add("@sgstrate", SqlDbType.VarChar).Value = sgstrate;
                da.InsertCommand.Parameters.Add("@sgstamt", SqlDbType.VarChar).Value = sgstamt;
                da.InsertCommand.Parameters.Add("@totalamt", SqlDbType.VarChar).Value = totalamt;
                da.InsertCommand.Parameters.Add("@Payment_Mode", SqlDbType.VarChar).Value = Payment_Mode;
                da.InsertCommand.Parameters.Add("@actual_currency", SqlDbType.VarChar).Value = actual_currency;
                da.InsertCommand.Parameters.Add("@converted_currency", SqlDbType.VarChar).Value = converted_currency;
                da.InsertCommand.Parameters.Add("@Converted_rate", SqlDbType.VarChar).Value = Converted_rate;
                da.InsertCommand.Parameters.Add("@ExchangedValue_date", SqlDbType.VarChar).Value = ExchangedValue_date;
                da.InsertCommand.Parameters.Add("@Actual_Amt", SqlDbType.VarChar).Value = Actual_Amt;
                da.InsertCommand.Parameters.Add("@Receipt_Status", SqlDbType.VarChar).Value = Receipt_Status;
                da.InsertCommand.Parameters.Add("@receipttype", SqlDbType.VarChar).Value = receipttype;
                da.InsertCommand.Parameters.Add("@payment_date", SqlDbType.VarChar).Value = payment_date;
                da.InsertCommand.Parameters.Add("@Total_deposit", SqlDbType.VarChar).Value = Total_deposit;
                da.InsertCommand.Parameters.Add("@USDTotal_deposit", SqlDbType.VarChar).Value = USDTotal_deposit;
                da.InsertCommand.Parameters.Add("@Previous_DepositAmt", SqlDbType.VarChar).Value = Previous_DepositAmt;
                da.InsertCommand.Parameters.Add("@floodcess", SqlDbType.VarChar).Value = floodcess;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

              

                string msg = "Error in Insert Contract_Indian_Deposit_Receipt" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static int ContractDetailsIDInContract_Fractional_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_Fractional_Indian  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static DataSet LoadFractionalIndianDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             SqlCommand scd = new SqlCommand("select *  from  Contract_Fractional_Indian  where ContractDetails_ID = @ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int InsertDeletedContract_Fractional_Indian(string ContractFractionalIndian_ID, string ProfileID, string ContractNo, string resort, string residence_no, string residence_type, string fractional_interest, string entitlement, string firstyear_Occupancy, string tenure, string lastyear_Occupancy, string leaseback, string Mc_Charges, string ContractDetails_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into  Deleted_Contract_Fractional_Indian values(@ContractFractionalIndian_ID,@ProfileID,@ContractNo,@resort,@residence_no,	@residence_type,@fractional_interest,	@entitlement,	@firstyear_Occupancy,	@tenure,	@lastyear_Occupancy,	@leaseback,	@Mc_Charges,@ContractDetails_ID)", cs1);
                da.InsertCommand.Parameters.Add("@ContractFractionalIndian_ID", SqlDbType.VarChar).Value = ContractFractionalIndian_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@resort", SqlDbType.VarChar).Value = resort;
                da.InsertCommand.Parameters.Add("@residence_no", SqlDbType.VarChar).Value = residence_no;
                da.InsertCommand.Parameters.Add("@residence_type", SqlDbType.VarChar).Value = residence_type;
                da.InsertCommand.Parameters.Add("@fractional_interest", SqlDbType.VarChar).Value = fractional_interest;
                da.InsertCommand.Parameters.Add("@entitlement", SqlDbType.VarChar).Value = entitlement;
                da.InsertCommand.Parameters.Add("@firstyear_Occupancy", SqlDbType.VarChar).Value = firstyear_Occupancy;
                da.InsertCommand.Parameters.Add("@tenure", SqlDbType.VarChar).Value = tenure;
                da.InsertCommand.Parameters.Add("@lastyear_Occupancy", SqlDbType.VarChar).Value = lastyear_Occupancy;
                da.InsertCommand.Parameters.Add("@leaseback", SqlDbType.VarChar).Value = leaseback;
                da.InsertCommand.Parameters.Add("@Mc_Charges", SqlDbType.VarChar).Value = Mc_Charges;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                string msg = "Error in Insert Contract_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

            }
        }
        return (rowsAffected);
    }
    public static int ContractDetailsIDInContract_Fractional_PA_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_Fractional_PA_Indian  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
   public static int InsertDeletedContract_Fractional_PA_Indian(string Contract_Fractional_PA_Id, string ProfileID, string ContractNo, string Admission_fees, string administration_fees, string Cgst, string Sgst, string Total_Purchase_Price, string Total_Price_Including_Tax, string Deposit, string Balance, string Balance_Due_Dates, string Remarks, string TradeIn_value, string Total_value, string ContractDetails_ID, string FoldVolume, string Foldadminfee, string FoldTotalTax, string FoldDeposit, string Fusdoldvolume, string Fusdoldadminfee, string Fusdoldtax, string Fusdolddeposit, string USDConvertedFVolume, string USDConvertedFAdminfee, string USDConvertedFTax, string USDConvertedFdeposit,string total_tax, string USDConvertedTotalVolume, string exchangerate)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Contract_Fractional_PA_Indian values(@Contract_Fractional_PA_Id,	@ProfileID,	@ContractNo,	@Admission_fees,	@administration_fees ,	@Cgst,	@Sgst,	@Total_Purchase_Price ,	@Total_Price_Including_Tax,@Deposit,@Balance,@Balance_Due_Dates,@Remarks,@TradeIn_value,@Total_value,@ContractDetails_ID,@FoldVolume,	@Foldadminfee,	@FoldTotalTax,	@FoldDeposit,@Fusdoldvolume,@Fusdoldadminfee,@Fusdoldtax,@Fusdolddeposit,@USDConvertedFVolume,@USDConvertedFAdminfee,@USDConvertedFTax,@USDConvertedFdeposit,@total_tax,@USDConvertedTotalVolume,@exchangerate)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_Fractional_PA_Id ", SqlDbType.VarChar).Value = Contract_Fractional_PA_Id;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Admission_fees", SqlDbType.VarChar).Value = Admission_fees;
                da.InsertCommand.Parameters.Add("@administration_fees", SqlDbType.VarChar).Value = administration_fees;
                da.InsertCommand.Parameters.Add("@Cgst", SqlDbType.VarChar).Value = Cgst;
                da.InsertCommand.Parameters.Add("@Sgst", SqlDbType.VarChar).Value = Sgst;
                da.InsertCommand.Parameters.Add("@Total_Purchase_Price", SqlDbType.VarChar).Value = Total_Purchase_Price;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Deposit", SqlDbType.VarChar).Value = Deposit;
                da.InsertCommand.Parameters.Add("@Balance", SqlDbType.VarChar).Value = Balance;
                da.InsertCommand.Parameters.Add("@Balance_Due_Dates", SqlDbType.VarChar).Value = Balance_Due_Dates;
                da.InsertCommand.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                da.InsertCommand.Parameters.Add("@TradeIn_value", SqlDbType.VarChar).Value = TradeIn_value;
                da.InsertCommand.Parameters.Add("@Total_value", SqlDbType.VarChar).Value = Total_value;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@FoldVolume", SqlDbType.VarChar).Value = FoldVolume;
                da.InsertCommand.Parameters.Add("@Foldadminfee", SqlDbType.VarChar).Value = Foldadminfee;
                da.InsertCommand.Parameters.Add("@FoldTotalTax", SqlDbType.VarChar).Value = FoldTotalTax;
                da.InsertCommand.Parameters.Add("@FoldDeposit", SqlDbType.VarChar).Value = FoldDeposit;
                da.InsertCommand.Parameters.Add("@Fusdoldvolume", SqlDbType.VarChar).Value = Fusdoldvolume;
                da.InsertCommand.Parameters.Add("@Fusdoldadminfee", SqlDbType.VarChar).Value = Fusdoldadminfee;
                da.InsertCommand.Parameters.Add("@Fusdoldtax", SqlDbType.VarChar).Value = Fusdoldtax;
                da.InsertCommand.Parameters.Add("@Fusdolddeposit", SqlDbType.VarChar).Value = Fusdolddeposit;
                da.InsertCommand.Parameters.Add("@USDConvertedFVolume", SqlDbType.VarChar).Value = USDConvertedFVolume;
                da.InsertCommand.Parameters.Add("@USDConvertedFAdminfee", SqlDbType.VarChar).Value = USDConvertedFAdminfee;
                da.InsertCommand.Parameters.Add("@USDConvertedFTax", SqlDbType.VarChar).Value = USDConvertedFTax;
                da.InsertCommand.Parameters.Add("@USDConvertedFdeposit", SqlDbType.VarChar).Value = USDConvertedFdeposit;
                da.InsertCommand.Parameters.Add("@total_tax", SqlDbType.VarChar).Value = total_tax;
                da.InsertCommand.Parameters.Add("@USDConvertedTotalVolume", SqlDbType.VarChar).Value = USDConvertedTotalVolume;
                da.InsertCommand.Parameters.Add("@exchangerate", SqlDbType.VarChar).Value = exchangerate;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                string msg = "Error in Insert Contract_Fractional_PA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static int ContractDetailsIDIContract_Trade_In_Fractional_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_Trade_In_Fractional_Indian  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static DataSet LoadFractionalIndianTradeInDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select *  from  Contract_Trade_In_Fractional_Indian  where ContractDetails_ID = @ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int InsertDeletedContract_Trade_In_Fractional_Indian(string ContractTrade_InFractional_ID, string ProfileID, string ContractNo, string Oldcontracttype, string RESORT, string APT_TYPE, string SEASON, string NO_WEEKS, string NO_POINTS, string POINTS_VALUE, string oldContract_No, string ContractDetails_ID,string OldMemtype)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Contract_Trade_In_Fractional_Indian values(@ContractTrade_InFractional_ID ,	@ProfileID ,	@ContractNo ,	@Oldcontracttype ,	@RESORT ,	@APT_TYPE ,		@SEASON, @NO_WEEKS ,	@NO_POINTS,	@POINTS_VALUE ,	@oldContract_No,@ContractDetails_ID,@OldMemtype)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTrade_InFractional_ID  ", SqlDbType.VarChar).Value = ContractTrade_InFractional_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Oldcontracttype", SqlDbType.VarChar).Value = Oldcontracttype;
                da.InsertCommand.Parameters.Add("@RESORT", SqlDbType.VarChar).Value = RESORT;
                da.InsertCommand.Parameters.Add("@APT_TYPE", SqlDbType.VarChar).Value = APT_TYPE;
                da.InsertCommand.Parameters.Add("@NO_WEEKS", SqlDbType.VarChar).Value = NO_WEEKS;
                da.InsertCommand.Parameters.Add("@SEASON", SqlDbType.VarChar).Value = SEASON;
                da.InsertCommand.Parameters.Add("@NO_POINTS", SqlDbType.VarChar).Value = NO_POINTS;
                da.InsertCommand.Parameters.Add("@POINTS_VALUE", SqlDbType.VarChar).Value = POINTS_VALUE;
                da.InsertCommand.Parameters.Add("@oldContract_No", SqlDbType.VarChar).Value = oldContract_No;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("OldMemtype", SqlDbType.VarChar).Value = OldMemtype;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Trade_In_Fractional_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Trade_In_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static int ContractDetailsIDContractNo_OthernamesExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from ContractNo_Othernames  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
  
  public static int InsertDeletedContractNo_Othernames(string otherNamesID, string ContractNo, string ContractDetails_ID, string Type, string Name, string Address, string State, string Country, string Postcode, string Status, string Document_name, string Added_Date,string Modified_Date,string Acceptance,string Enrollment)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_ContractNo_Othernames values(@otherNamesID ,@ContractNo ,	@ContractDetails_ID,	@Type,	@Name,@Address,@State,@Country, @Postcode,	@Status,	@Document_name, @Added_Date,@Modified_Date,@Acceptance,@Enrollment)", cs1);
                da.InsertCommand.Parameters.Add("@otherNamesID ", SqlDbType.VarChar).Value = otherNamesID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
                da.InsertCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                da.InsertCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
                da.InsertCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = State;
                da.InsertCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;
                da.InsertCommand.Parameters.Add("@Postcode", SqlDbType.VarChar).Value = Postcode;
                da.InsertCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
                da.InsertCommand.Parameters.Add("@Document_name", SqlDbType.VarChar).Value = Document_name;
                da.InsertCommand.Parameters.Add("@Added_Date", SqlDbType.VarChar).Value = Added_Date;
                da.InsertCommand.Parameters.Add("@Modified_Date", SqlDbType.VarChar).Value = Modified_Date;
                da.InsertCommand.Parameters.Add("@Acceptance", SqlDbType.VarChar).Value = Acceptance;
                da.InsertCommand.Parameters.Add("@Enrollment", SqlDbType.VarChar).Value = Enrollment;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {



                string msg = "Error in Insert InsertContractNo_Othernames Query " + " " + ex.Message;

                throw new Exception(msg, ex);


            }
        }
        return (rowsAffected);
    }

    public static int ContractDetailsIDFinancebreakupExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Finance_Breakup where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }
    public static int InsertDeletedContractDetails_Indian(string ContractNo, string ProfileID, string Sales_Rep, string TO_Manager, string ButtonUp_Officer, string DealRegistered_Date, string DealStatus, string Contract_CreatedDate, string Contract_UpdatedDate, string ContractType,
        string MCWaiver, string Finance_Details, string Contract_Remark, string Pan_Card, string Adhar_Card, string MC_Charges, string First_MC_Payable_Date, string MemberFee, string MemberCGST, string MembersGST, string CanxContractNo, string ContractDetails_ID, string Contract_Canx_date, string Loan_BU_officer, string Client_GSTIN, string Company_PanNo, string dealweekno, string deckdetails, string deckremark, string Contract_comment, string Contract_createdUser, string BU_A6, string Updowngrade,
        string Expirydate, string Commence_date, string Contract_group, string Contract_Venue,string Returnhomedate,string Finance_mailingAddress)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //try
            //{
            da.InsertCommand = new SqlCommand("insert into Deleted_ContractDetails_Indian values(@ContractNo,	@ProfileID ,@Sales_Rep ,@TO_Manager ,	@ButtonUp_Officer ,convert(datetime,@DealRegistered_Date,105),	@DealStatus ,	@Contract_CreatedDate ,	 @Contract_UpdatedDate ,	@ContractType ,	@MCWaiver,	@Finance_Details ,	@Contract_Remark ,	@Pan_Card ,	@Adhar_Card,@MC_Charges,  @First_MC_Payable_Date,@MemberFee,@MemberCGST,@MembersGST,@CanxContractNo,@ContractDetails_ID,convert(datetime,@Contract_Canx_date,105),@Loan_BU_officer,@Client_GSTIN,@Company_PanNo,@dealweekno,@deckdetails, @deckremark,@Contract_comment,@Contract_createdUser,@BU_A6,@Updowngrade,@Expirydate, @Commence_date, @Contract_group, @Contract_Venue, @Returnhomedate,@Finance_mailingAddress)", cs1);
            da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
            da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
            da.InsertCommand.Parameters.Add("@Sales_Rep ", SqlDbType.VarChar).Value = Sales_Rep;
            da.InsertCommand.Parameters.Add("@TO_Manager ", SqlDbType.VarChar).Value = TO_Manager;
            da.InsertCommand.Parameters.Add("@ButtonUp_Officer ", SqlDbType.VarChar).Value = ButtonUp_Officer;
            da.InsertCommand.Parameters.Add("@DealRegistered_Date", SqlDbType.VarChar).Value = DealRegistered_Date;
            da.InsertCommand.Parameters.Add("@DealStatus ", SqlDbType.VarChar).Value = DealStatus;
            da.InsertCommand.Parameters.Add("@Contract_CreatedDate", SqlDbType.VarChar).Value = Contract_CreatedDate;
            da.InsertCommand.Parameters.Add("@Contract_UpdatedDate", SqlDbType.VarChar).Value = Contract_UpdatedDate;
            da.InsertCommand.Parameters.Add("@ContractType ", SqlDbType.VarChar).Value = ContractType;
            da.InsertCommand.Parameters.Add("@MCWaiver", SqlDbType.VarChar).Value = MCWaiver;
            da.InsertCommand.Parameters.Add("@Finance_Details", SqlDbType.VarChar).Value = Finance_Details;
            da.InsertCommand.Parameters.Add("@Contract_Remark", SqlDbType.VarChar).Value = Contract_Remark;
            da.InsertCommand.Parameters.Add("@Pan_Card", SqlDbType.VarChar).Value = Pan_Card;
            da.InsertCommand.Parameters.Add("@Adhar_Card", SqlDbType.VarChar).Value = Adhar_Card;
            da.InsertCommand.Parameters.Add("@MC_Charges", SqlDbType.VarChar).Value = MC_Charges;
            da.InsertCommand.Parameters.Add("@First_MC_Payable_Date", SqlDbType.VarChar).Value = First_MC_Payable_Date;
            da.InsertCommand.Parameters.Add("@MemberFee", SqlDbType.VarChar).Value = MemberFee;
            da.InsertCommand.Parameters.Add("@MemberCGST", SqlDbType.VarChar).Value = MemberCGST;
            da.InsertCommand.Parameters.Add("@MembersGST", SqlDbType.VarChar).Value = MembersGST;
            da.InsertCommand.Parameters.Add("@CanxContractNo", SqlDbType.VarChar).Value = CanxContractNo;
            da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da.InsertCommand.Parameters.Add("@Contract_Canx_date", SqlDbType.VarChar).Value = Contract_Canx_date;
            da.InsertCommand.Parameters.Add("@Loan_BU_officer", SqlDbType.VarChar).Value = Loan_BU_officer;
            da.InsertCommand.Parameters.Add("@Client_GSTIN", SqlDbType.VarChar).Value = Client_GSTIN;
            da.InsertCommand.Parameters.Add("@Company_PanNo", SqlDbType.VarChar).Value = Company_PanNo;
            da.InsertCommand.Parameters.Add("@dealweekno", SqlDbType.VarChar).Value = dealweekno;
            da.InsertCommand.Parameters.Add("@deckdetails", SqlDbType.VarChar).Value = deckdetails;
            da.InsertCommand.Parameters.Add("@deckremark", SqlDbType.VarChar).Value = deckremark;
            da.InsertCommand.Parameters.Add("@Contract_comment", SqlDbType.VarChar).Value = Contract_comment;
            da.InsertCommand.Parameters.Add("@Contract_createdUser", SqlDbType.VarChar).Value = Contract_createdUser;
            da.InsertCommand.Parameters.Add("@BU_A6", SqlDbType.VarChar).Value = BU_A6;
            da.InsertCommand.Parameters.Add("@Updowngrade", SqlDbType.VarChar).Value = Updowngrade;
            da.InsertCommand.Parameters.Add("@Expirydate", SqlDbType.VarChar).Value = Expirydate;
            da.InsertCommand.Parameters.Add("@Commence_date", SqlDbType.VarChar).Value = Commence_date;
            da.InsertCommand.Parameters.Add("@Contract_group", SqlDbType.VarChar).Value = Contract_group;
            da.InsertCommand.Parameters.Add("@Contract_Venue", SqlDbType.VarChar).Value = Contract_Venue;
            da.InsertCommand.Parameters.Add("@Returnhomedate", SqlDbType.VarChar).Value = Returnhomedate;
            da.InsertCommand.Parameters.Add("@Finance_mailingAddress", SqlDbType.VarChar).Value = Finance_mailingAddress;
            rowsAffected = da.InsertCommand.ExecuteNonQuery();

        }
        return (rowsAffected);
    }


    public static int ContractDetailsIDCRM_detailsExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from CRM_details where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }



    public static int InsertDeletedCRM_details(string CRM_ID, string Profile_ID, string contractdetails_id, string program_source, string Referred_By, string comment1, string created_date, string updated_date, string createdby, string updatedby, string status)
    {

        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //try
            //{
            da.InsertCommand = new SqlCommand("insert into Deleted_CRM_details values(@CRM_ID, @Profile_ID,	@contractdetails_id ,@program_source ,@Referred_By ,@comment1 , @created_date,  @updated_date, @createdby, @updatedby,@status)", cs1);
            da.InsertCommand.Parameters.Add("@CRM_ID", SqlDbType.VarChar).Value = CRM_ID;
            da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
            da.InsertCommand.Parameters.Add("@contractdetails_id", SqlDbType.VarChar).Value = contractdetails_id;
            da.InsertCommand.Parameters.Add("@program_source", SqlDbType.VarChar).Value = program_source;
            da.InsertCommand.Parameters.Add("@Referred_By", SqlDbType.VarChar).Value = Referred_By;
            da.InsertCommand.Parameters.Add("@comment1", SqlDbType.VarChar).Value = comment1;
            da.InsertCommand.Parameters.Add("@created_date", SqlDbType.VarChar).Value = created_date;
            da.InsertCommand.Parameters.Add("@updated_date ", SqlDbType.VarChar).Value = updated_date;
            da.InsertCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby;
            da.InsertCommand.Parameters.Add("@updatedby", SqlDbType.VarChar).Value = updatedby;
            da.InsertCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            rowsAffected = da.InsertCommand.ExecuteNonQuery();

        }
        return (rowsAffected);
    }
    public static int ContractDetailsIDContractTeamDetailsExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from ContractTeamDetails where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }

    public static int InsertDeletedContractTeamDetails(string TeamDetailsID, string ContractDetails_ID, string Approval_Comments, string Rep_report, string To_report, string SMS_Update, string Created_Date, string CreatedBy, string Updated_Date, string UpdatedBy)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_ContractTeamDetails values(@TeamDetailsID,@ContractDetails_ID,@Approval_Comments,@Rep_report, @To_report, @SMS_Update, @Created_Date, @CreatedBy, @Updated_Date,@UpdatedBy)", cs1);
                da.InsertCommand.Parameters.Add("@TeamDetailsID", SqlDbType.VarChar).Value = TeamDetailsID;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@Approval_Comments", SqlDbType.VarChar).Value = Approval_Comments;
                da.InsertCommand.Parameters.Add("@Rep_report", SqlDbType.VarChar).Value = Rep_report;
                da.InsertCommand.Parameters.Add("@To_report", SqlDbType.VarChar).Value = To_report;
                da.InsertCommand.Parameters.Add("@SMS_Update", SqlDbType.VarChar).Value = SMS_Update;
                da.InsertCommand.Parameters.Add("@Created_Date", SqlDbType.VarChar).Value = Created_Date;
                da.InsertCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                da.InsertCommand.Parameters.Add("@Updated_Date", SqlDbType.VarChar).Value = Updated_Date;
                da.InsertCommand.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = UpdatedBy;


                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {



                string msg = "Error in Insert InsertContractTeamDetails Query " + " " + ex.Message;

                throw new Exception(msg, ex);


            }
        }
        return (rowsAffected);
    }
    public static int ContractDetailsIDContract_Installments_Indian_DeletedExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Contract_Installments_Indian_Deleted where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }
    public static int ContractDetailsIDContract_Installments_IndianExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Contract_Installments_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }

    public static int InsertDeletedContract_Installments_Indian(string Installment_ID,string ProfileID, string ContractNo, string Installment_no, string Installment_Amount, string Installment_Date, string Installment_Invoice_No, string ContractDetails_ID,string Paymentmode)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Deleted_Contract_Installments_Indian values(@Installment_ID,@ProfileID,	@ContractNo,@Installment_no,@Installment_Amount, @Installment_Date,@Installment_Invoice_No,@ContractDetails_ID,@Paymentmode)", cs1);
                da.InsertCommand.Parameters.Add("@Installment_ID ", SqlDbType.VarChar).Value = Installment_ID;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Installment_no", SqlDbType.VarChar).Value = Installment_no;
                da.InsertCommand.Parameters.Add("@Installment_Amount", SqlDbType.VarChar).Value = Installment_Amount;
                da.InsertCommand.Parameters.Add("@Installment_Date", SqlDbType.VarChar).Value = Installment_Date;
                da.InsertCommand.Parameters.Add("@Installment_Invoice_No", SqlDbType.VarChar).Value = Installment_Invoice_No;
                da.InsertCommand.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                da.InsertCommand.Parameters.Add("@Paymentmode", SqlDbType.VarChar).Value = Paymentmode;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                string msg = "Error in  InsertDeletedContract_Installments_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);
               
            }
        }
        return (rowsAffected);
    }

    public static int ContractDetailsIDInContract_Indian_Deposit_Receipt_DeletedExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Contract_Indian_Deposit_Receipt_Deleted  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static DataSet LoadContract_Indian_Deposit_Receipt_Deleted(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select *  from  Contract_Indian_Deposit_Receipt_Deleted  where ContractDetails_ID = @ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    
    public static int DeleteContract_Indian_Deposit_ReceiptDeleted(string ContractDetails_ID)
    {
        int rows7 = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {


            SqlCommand sqlcmd7 = new SqlCommand(" delete from Contract_Indian_Deposit_Receipt_Deleted where ContractDetails_ID =@ContractDetails_ID", cs1);

            sqlcmd7.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            rows7 = sqlcmd7.ExecuteNonQuery();


        }
        return rows7;
    }
    public static int ContractNoExistsBeforeUpdate(string contractno)
    {
        
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select contractno from ContractDetails_Indian where contractno =@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                 exists = 1;
                
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

    public static int UpdateContractDetails_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                 SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                string msg = "Error in UPDATE UpdateContractDetails_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

            }

        }
        return rows;
    }
    public static int UpdateFinanceDetails_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Finance_Details_Indian  SET  contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateFinanceDetails_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateContract_PA_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_PA_Indian  SET  contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

              

                string msg = "Error in UPDATE UpdateContract_PA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                
            }

        }
        return rows;
    }
    public static int UpdateContract_Points_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Points_Indian  SET contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

               
            }

        }
        return rows;
    }

    public static int UpdateContract_Trade_In_Points_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

    
                SqlCommand scd = new SqlCommand("update Contract_Trade_In_Points_Indian  SET contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Trade_In_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateContract_Trade_In_Weeks_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Trade_In_Weeks_Indian  SET  contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);


                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 
                string msg = "Error in UPDATE UpdateContract_Trade_In_Weeks_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                 
            }

        }
        return rows;
    }

    public static int UpdateContract_FractionalPA_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Fractional_PA_Indian  SET contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContract_FractionalPA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static int UpdateContract_Fractional_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {


                SqlCommand scd = new SqlCommand("update Contract_Fractional_Indian  SET contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }

    public static int UpdateContract_Trade_In_Fractional_IndianContractNoOnly(string contractno, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {


                SqlCommand scd = new SqlCommand("update Contract_Trade_In_Fractional_Indian  SET contractno = '" + contractno + "'where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {



                string msg = "Error in UPDATE Contract_Trade_In_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);
            }

        }
        return rows;
    }
public static string GetItemOnGift(string gift)
    {
        string item;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select item from Gift_Option where Gift_Option_Name+' - '+Item='" + gift + "'", cs1);
            scd.Parameters.Add("@gift", SqlDbType.VarChar).Value = gift;
            item = (string)scd.ExecuteScalar();
        }
        return item;

    }


    public static int leadSource(string ProfileID, string leadSource)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Profile  SET Lead_Source='"+leadSource+ "' where Profile_ID ='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

public static DataSet LoadPrintPDFFiles_FractionalNOCompany1(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like '%addition%') and(printname not like '%sor%') and(printname not like'%trade%')and(printname not like'%goa%')and(printname not like'%open%'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;         
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany2(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like '%addition%') and(printname not like '%sor%')and(printname not like'%trade%')and(printname not like'%goa%'))and(printpdf_id not in('PDIND251'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany3(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%addition%') and (printname not like '%sor%') and (printname not like'%open%')and (printname not like'%goa%') ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany4(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%addition%') and (printname not like '%sor%') and (printname not like'%goa%')and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany5(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')    and(printname not like '%sor%') and(printname not like'%trade%')and(printname not like'%goa%')and(printname not like'%open%'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany6(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')    and(printname not like '%sor%')and(printname not like'%trade%')and(printname not like'%goa%'))and(printpdf_id not in('PDIND251'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany7(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')   and (printname not like '%sor%') and (printname not like'%open%')and (printname not like'%goa%') ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany8(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%sor%') and (printname not like'%goa%')and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany9(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')    and(printname not like '%addition%') and(printname not like'%trade%')and(printname not like'%goa%')and(printname not like'%open%'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany10(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')    and(printname not like '%addition%')and(printname not like'%trade%')and(printname not like'%goa%'))and(printpdf_id not in('PDIND251'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany11(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')   and (printname not like '%addition%') and (printname not like'%open%')and (printname not like'%goa%') ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany12(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%addition%') and (printname not like'%goa%')and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany13(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')     and(printname not like'%trade%')and(printname not like'%goa%')and(printname not like'%open%'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany14(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%') and(printname not like'%trade%')and(printname not like'%goa%'))and(printpdf_id not in('PDIND251'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany15(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%') and (printname not like'%open%')and (printname not like'%goa%') ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany16(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%') and (printname not like'%goa%')and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany1GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like '%addition%') and(printname not like '%sor%') and(printname not like'%trade%')and(printname not like'%open%') and (printpdf_id not in('PDIND251')))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany2GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like '%addition%') and(printname not like '%sor%')and(printname not like'%trade%'))and   (printpdf_id not in('PDIND251','PDIND252','PDIND530'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany3GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%addition%') and (printname not like '%sor%') and (printname not like'%open%')and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany4GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%addition%') and (printname not like '%sor%')  and (printpdf_id not in('PDIND251','PDIND252','PDIND530'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadPrintPDFFiles_FractionalNOCompany5GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like '%sor%')  and(printname not like'%trade%')and(printname not like'%open%') and (printpdf_id not in('PDIND251')))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany6GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like '%sor%') and(printname not like'%trade%'))and   (printpdf_id not in('PDIND251','PDIND252','PDIND530'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany7GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%sor%')  and (printname not like'%open%')and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany8GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%sor%')  and (printpdf_id not in('PDIND251','PDIND252','PDIND530'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadPrintPDFFiles_FractionalNOCompany9GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like '%addition%')  and(printname not like'%trade%')and(printname not like'%open%') and (printpdf_id not in('PDIND251')))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany10GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like '%addition%') and(printname not like'%trade%'))and   (printpdf_id not in('PDIND251','PDIND252','PDIND530'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany11GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%addition%')  and (printname not like'%open%')and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany12GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')  and (printname not like '%addition%')  and (printpdf_id not in('PDIND251','PDIND252','PDIND530'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany13GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like'%trade%')and(printname not like'%open%') and (printpdf_id not in('PDIND251')))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany14GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')and(printname   not   like '%company%')  and(printname not like'%trade%'))and   (printpdf_id not in('PDIND251','PDIND252','PDIND530'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany15GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%') and (printname not like'%open%')and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalNOCompany16GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and(printname   not   like '%company%')   and (printpdf_id not in('PDIND251','PDIND252','PDIND530'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadPrintPDFFiles_FractionalCompany1(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office =@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like '%addition%') and(printname not like '%sor%') and(printname not like'%trade%')and(printname not like'%goa%')and(printname not like'%open%'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany2(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like '%addition%') and(printname not like '%sor%')and(printname not like'%trade%')and(printname not like'%goa%'))and(printpdf_id not in('PDIND251'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany3(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like '%addition%') and (printname not like '%sor%') and (printname not like'%open%')and (printname not like'%goa%') ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany4(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like '%addition%') and (printname not like '%sor%') and (printname not like'%goa%') and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany5(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office= @office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')    and(printname not like '%sor%') and(printname not like'%trade%')and(printname not like'%goa%')and(printname not like'%open%'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany6(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')   and(printname not like '%sor%')and(printname not like'%trade%')and(printname not like'%goa%'))and(printpdf_id not in('PDIND251'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany7(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like '%sor%') and (printname not like'%open%')and (printname not like'%goa%') ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany8(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')    and (printname not like '%sor%') and (printname not like'%goa%') and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany9(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office= @office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')    and(printname not like '%addition%') and(printname not like'%trade%')and(printname not like'%goa%')and(printname not like'%open%'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany10(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')   and(printname not like '%addition%')and(printname not like'%trade%')and(printname not like'%goa%'))and(printpdf_id not in('PDIND251'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany11(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like '%addition%') and (printname not like'%open%')and (printname not like'%goa%') ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany12(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')    and (printname not like '%addition%') and (printname not like'%goa%') and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany13(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office= @office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like'%trade%')and(printname not like'%goa%')and(printname not like'%open%'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany14(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like'%trade%')and(printname not like'%goa%'))and(printpdf_id not in('PDIND251'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany15(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like'%open%')and (printname not like'%goa%') ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany16(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and (printname not like'%goa%') and (printpdf_id not in('PDIND251'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany1GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office= @office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like '%addition%') and(printname not like '%sor%') and(printname not like'%trade%')and(printname not like'%open%')and (printpdf_id not in('PDIND251','PDIND252','PDIND526')))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany2GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like '%addition%') and(printname not like '%sor%')and(printname not like'%trade%'))and(printpdf_id not in('PDIND526','PDIND251','PDIND528','PDIND530','PDIND252','PDIND534'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany3GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like '%addition%') and (printname not like '%sor%') and (printname not like'%open%') and (printpdf_id not in('PDIND526','PDIND251')) ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany4GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like '%addition%') and (printname not like '%sor%') and (printname not like'%goa%') and (printpdf_id not in('PDIND526','PDIND251','PDIND528','PDIND530','PDIND252','PDIND534'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadPrintPDFFiles_FractionalCompany5GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office= @office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')   and(printname not like '%sor%') and(printname not like'%trade%')and(printname not like'%open%')and (printpdf_id not in('PDIND251','PDIND252','PDIND526')))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany6GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like '%sor%')and(printname not like'%trade%'))and(printpdf_id not in('PDIND526','PDIND251','PDIND528','PDIND530','PDIND252','PDIND534'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany7GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like '%sor%') and (printname not like'%open%') and (printpdf_id not in('PDIND526','PDIND251')) ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany8GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')    and (printname not like '%sor%') and (printname not like'%goa%') and (printpdf_id not in('PDIND526','PDIND251','PDIND528','PDIND530','PDIND252','PDIND534'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany9GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office=@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')   and(printname not like '%addition%') and(printname not like'%trade%')and(printname not like'%open%')and (printpdf_id not in('PDIND251','PDIND252','PDIND526')))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany10GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like '%addition%')and(printname not like'%trade%'))and(printpdf_id not in('PDIND526','PDIND251','PDIND528','PDIND530','PDIND252','PDIND534'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany11GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like '%addition%') and (printname not like'%open%') and (printpdf_id not in('PDIND526','PDIND251')) ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany12GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')    and (printname not like '%addition%') and (printname not like'%goa%') and (printpdf_id not in('PDIND526','PDIND251','PDIND528','PDIND530','PDIND252','PDIND534'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany13GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype =@ctype and currency = @curr and Printpdf_Office =@office    and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')   and(printname not like'%trade%')and(printname not like'%open%')and (printpdf_id not in('PDIND251','PDIND252','PDIND526')))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany14GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname = @club and contracttype = @ctype and currency = @curr and Printpdf_Office = @office and finance = @finance and((affiliate_type = @affiliate_type) or(isnull(affiliate_type, '') = ''))and((isnull(Waiver, '') = 'no') or isnull(waiver, '') = 'no')and((printname not like '%void%')  and(printname not like'%trade%'))and(printpdf_id not in('PDIND526','PDIND251','PDIND528','PDIND530','PDIND252','PDIND534'))", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany15GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%')   and (printname not like'%open%') and (printpdf_id not in('PDIND526','PDIND251')) ) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadPrintPDFFiles_FractionalCompany16GOA(string ctype, string office, string club, string curr, string finance, string affiliate_type, string mc)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select printname from Indian_PrintPdf where Printpdf_Status='Active' and clubname=@club and contracttype=@ctype and currency=@curr and  Printpdf_Office = @office and finance=@finance and((affiliate_type =@affiliate_type) or(isnull(affiliate_type, '') = ''))and ((isnull(Waiver, '') ='no') or isnull(waiver,'')='no')and((printname not like '%void%') and (printname not like'%goa%') and (printpdf_id not in('PDIND526','PDIND251','PDIND528','PDIND530','PDIND252','PDIND534'))) ", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlCmd.Parameters.Add("@affiliate_type", SqlDbType.VarChar).Value = affiliate_type;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
public static int UpdateContractDepositDetails(string amount,string type,string depositMethod, string taxableamount,string gst,string receiptNum ,string oldcanxamt,string USDTotal_deposit,string receiptID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Indian_Deposit_Receipt set totalamt = '" + amount + "', receipttype = '" + type + "', Payment_Mode = '" + depositMethod + "', taxable_value = '" + taxableamount + "', cgstamt = '" + gst + "', sgstamt = '" + gst + "', Amount = '" + taxableamount + "', Receipt_No = '" + receiptNum + "', Previous_DepositAmt = '" + oldcanxamt + "', Total_deposit = '" + amount + "',USDTotal_deposit='"+ USDTotal_deposit+"' where Deposit_Receipt_Id = '" + receiptID + "'", cs1);
                scd.Parameters.Add("@receiptID", SqlDbType.VarChar).Value = receiptID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateContractDepositDetails Query " + " " + ex.Message;

                throw new Exception(msg, ex);
                
            }

        }
        return rows;
    }
    public static int UpdateContractDepositDetailsAmtTransfer(string amount, string type, string depositMethod, string taxableamount, string gst, string receiptNum, string oldcanxamt,string totaldeposit,string USDTotal_deposit, string receiptID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Indian_Deposit_Receipt set totalamt = '" + amount + "', receipttype = '" + type + "', Payment_Mode = '" + depositMethod + "', taxable_value = '" + taxableamount + "', cgstamt = '" + gst + "', sgstamt = '" + gst + "', Amount = '" + taxableamount + "', Receipt_No = '" + receiptNum + "', Previous_DepositAmt = '" + oldcanxamt + "', Total_deposit = '" + totaldeposit + "',USDTotal_deposit='" + USDTotal_deposit + "' where Deposit_Receipt_Id = '" + receiptID + "'", cs1);
                scd.Parameters.Add("@receiptID", SqlDbType.VarChar).Value = receiptID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateContractDepositDetailsAmtTransfer Query " + " " + ex.Message;

                throw new Exception(msg, ex);

            }

        }
        return rows;
    }
    public static int UpdateContractDepositDetailsUSD(string amount, string type, string depositMethod, string taxableamount, string gst, string receiptNum, string oldcanxamt, string totaldeposit,string Converted_rate,string USDTotal_deposit,string actual_currency,string ExchangedValue_date,string Actual_Amt, string receiptID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Indian_Deposit_Receipt set totalamt = '" + amount + "', receipttype = '" + type + "', Payment_Mode = '" + depositMethod + "', taxable_value = '" + taxableamount + "', cgstamt = '" + gst + "', sgstamt = '" + gst + "', Amount = '" + taxableamount + "', Receipt_No = '" + receiptNum + "', Previous_DepositAmt = '" + oldcanxamt + "', Total_deposit = '" + totaldeposit + "',Converted_rate = '" + Converted_rate + "',USDTotal_deposit='" + USDTotal_deposit + "', actual_currency= '"+actual_currency+"',ExchangedValue_date =   '" + ExchangedValue_date + "', Actual_Amt = '"+Actual_Amt+"' where Deposit_Receipt_Id = '" + receiptID + "'", cs1);
                scd.Parameters.Add("@receiptID", SqlDbType.VarChar).Value = receiptID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateContractDepositDetailsUSD Query " + " " + ex.Message;

                throw new Exception(msg, ex);

            }

        }
        return rows;
    }
 
 public static int UpdateProfileAddressCorresContractdetailsID(string ProfileID, string ContractDetails_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Contract_Correspondence_Address  SET  ContractDetails_ID ='" + ContractDetails_ID + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               

                string msg = "Error in UPDATE UpdateProfileAddressCorresContractdetailsID Query " + " " + ex.Message;

                throw new Exception(msg, ex);

              
            }
        }
        return (rowsaffected);
    }

public static String GetDistinctReceiptMode(string contractdetails_ID)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select distinct Payment_Mode from Contract_Indian_Deposit_Receipt where ContractDetails_ID = @contractdetails_ID", cs1);
            scd.Parameters.Add("@contractdetails_ID", SqlDbType.VarChar).Value = contractdetails_ID;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }

 public static String getMarketingAbbOnMarketingProgram1(string venue, string venueGroup, string program)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select m.Marketing_Program_abbrv from Marketing_Program m join Venue_Group vg on vg.Venue_Group_ID=m.Venue_Group_ID join venue v on v.Venue_ID=vg.Venue_ID where (Marketing_Program_Name=@program or Marketing_Program_abbrv=@program) and Marketing_Program_Status='Active' and v.Venue_Name=@venue and vg.Venue_Group_Name=@venueGroup", cs1);
            scd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            scd.Parameters.Add("@venueGroup", SqlDbType.VarChar).Value = venueGroup;
            scd.Parameters.Add("@program", SqlDbType.VarChar).Value = program;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }

 public static DataSet LoadCrownFinanceMethodRatesFractional(string FinanceMethod_Name, int year,string No_Emi)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from FinanceMethodRates where FinanceMethod_Name=@FinanceMethod_Name and  (start_year=@year or end_year=@year)   and  FinanceMethod_Status='Active' and ContractType='Fractional' and Interest_Month=@No_Emi  ", cs1);
            SqlCmd.Parameters.Add("@FinanceMethod_Name", SqlDbType.VarChar).Value = FinanceMethod_Name;
            SqlCmd.Parameters.Add("@year", SqlDbType.Int).Value = year;
            SqlCmd.Parameters.Add("@No_Emi", SqlDbType.Int).Value = No_Emi;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadCrownFinanceMethodRates(string FinanceMethod_Name, int year, string No_Emi)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from FinanceMethodRates where FinanceMethod_Name=@FinanceMethod_Name and  (start_year=@year or end_year=@year)   and  FinanceMethod_Status='Active' and ContractType='Non Fractional' and Interest_Month=@No_Emi  ", cs1);
            SqlCmd.Parameters.Add("@FinanceMethod_Name", SqlDbType.VarChar).Value = FinanceMethod_Name;
            SqlCmd.Parameters.Add("@year", SqlDbType.Int).Value = year;
            SqlCmd.Parameters.Add("@No_Emi", SqlDbType.Int).Value = No_Emi;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

 public static int UpdateFinanceDetails_IndianFinanceType(string eurorate, string loanamtINEuro, string monthlyPremiumprotectionplan, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Finance_Details_Indian  SET eurorate= '" + eurorate + "',	loanamtINEuro= '" + loanamtINEuro + "',monthlyPremiumprotectionplan = '" + monthlyPremiumprotectionplan + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
              
                string msg = "Error in UPDATE UpdateFinanceDetails_Indian Query " + " " + ex.Message;
                throw new Exception(msg, ex);
 
            }

        }
        return rows;
    }

 public static int UpdateTourDetailsInhouse(string ProfileID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, int Week_number)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {

                SqlCommand scd = new SqlCommand("update Tour_Details SET  Tour_Details_Guest_Status= '" + Tour_Details_Guest_Status + "',	Tour_Details_Guest_Sales_Rep= '" + Tour_Details_Guest_Sales_Rep + "',	Tour_Details_Tour_Date=convert(datetime, '" + Tour_Details_Tour_Date + "',105),	Tour_Details_Sales_Deck_Check_In= '" + Tour_Details_Sales_Deck_Check_In + "',	Tour_Details_Sales_Deck_Check_Out= '" + Tour_Details_Sales_Deck_Check_Out + "',	Week_number= '" + Week_number + "'where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in UPDATE Tour_Details Query " + ex.Message);                
            }
        }
        return (rowsaffected);
    }


 public static int ContractDetailsIDInDeleted_Finance_Details_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Finance_Details_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInDeleted_Contract_PA_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Contract_PA_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInDeleted_Contract_Points_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Contract_Points_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInDeleted_Contract_Trade_In_Points_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Contract_Trade_In_Points_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInDeleted_Contract_Trade_In_Weeks_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Contract_Trade_In_Weeks_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInDeleted_Contract_Indian_Deposit_ReceiptExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Contract_Indian_Deposit_Receipt  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInDeleted_Contract_Fractional_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Contract_Fractional_Indian  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInDeleted_Contract_Trade_In_Fractional_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Contract_Trade_In_Fractional_Indian  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDInDeleted_Contract_Fractional_PA_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_Contract_Fractional_PA_Indian  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDDeleted_ContractNo_OthernamesExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_ContractNo_Othernames  where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }
    public static int ContractDetailsIDDeleted_CRM_detailsExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Deleted_CRM_details where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }

    public static int ContractDetailsIDDeleted_ContractTeamDetailsExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Deleted_ContractTeamDetails where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }

    public static int ContractDetailsIDDeleted_Contract_Installments_IndianExists(string ContractDetails_ID)
    {
        int rows = 0;


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd1 = new SqlCommand("select ContractDetails_ID from Deleted_Contract_Installments_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd1.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd1.ExecuteReader();
            if (dr.Read())
            {
                rows = 1;
            }
            else
            {
                rows = 0;
            }



        }
        return rows;
    }

    public static int ContractDetailsIDDeleted_ContractDetails_IndianExists(string ContractDetails_ID)
    {
        int exists;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select ContractDetails_ID from Deleted_ContractDetails_Indian where ContractDetails_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();

            if (dr.Read() == true)
            {
                exists = 1;
            }
            else
            {
                exists = 0;
            }
        }
        return exists;
    }

public static DataTable DSR_INDIA_CONTS1(string DATE, string COUNTRY, string VENUE, string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_CONTS1", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);
            cmd_sp.Parameters.AddWithValue("@venuegroup", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static DataTable DSR_INDIA_CONTS2(string DATE, string COUNTRY, string VENUE, string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_CONTS2", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);
            cmd_sp.Parameters.AddWithValue("@venuegroup", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
public static DataTable DSR_INDIA_CONT1(string DATE, string COUNTRY,string VENUE,string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_CONT1", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);
            cmd_sp.Parameters.AddWithValue("@venuegroup", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static DataTable DSR_INDIA_CONT2(string DATE, string COUNTRY, string VENUE, string VENUEGROUP)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("DSR_INDIA_CONT2", cs1);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Date", DATE);
            cmd_sp.Parameters.AddWithValue("@COUNTRY", COUNTRY);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);
            cmd_sp.Parameters.AddWithValue("@venuegroup", VENUEGROUP);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

  public static DataTable Offsiterecap(string INPUT, string VENUE)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Offsiterecap", cs1);
	    cmd_sp.CommandTimeout=0; 
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", INPUT);
            cmd_sp.Parameters.AddWithValue("@VENUE", VENUE);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable Offsiterecap_SEAP(string INPUT)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("seapdate", cs1);
cmd_sp.CommandTimeout=0; 
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", INPUT);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

 public static SqlDataReader userOffices(string username)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select office from UserOffice where UserID=@username", cs1);
        SqlCmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }


    public static SqlDataReader getcountryonprofile(string profileID)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select Profile_Venue_Country from profile where Profile_ID=@profileID", cs1);
        SqlCmd.Parameters.Add("@profileID", SqlDbType.VarChar).Value = profileID;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }


    public static SqlDataReader getOfficeOnCountry(string country)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select Venue_Country_Office from VenueCountry where Venue_Country_Name=@country and Venue_Country_Status='Active'", cs1);
        SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
    public static string GetOfficeFromCountry(string profileid)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_Country_Office from VenueCountry where Venue_Country_Name = (select Profile_Venue_Country from Profile where Profile_ID=@profileid)", cs1);
            scd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
 public static DataSet ExportLogsOnProfile(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select LogID, l.profileid, cd.contractno, UpdatedField, Username, Log_Entry,pagename from Contract_Logs_India l left join ContractDetails_Indian cd on cd.ContractDetails_ID=l.ContractDetails_ID where l.profileid =@profileid  union select   log_ID, Profile_ID, Contract_No, Logs, Username, Log_Entry_Date, area from contract_log where profile_id = @profileid ", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
     public static DataSet ExportLogsOnContract(string contract)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select LogID, l.profileid, cd.contractno, UpdatedField, Username, Log_Entry,pagename from Contract_Logs_India l   join ContractDetails_Indian cd on cd.ContractDetails_ID = l.ContractDetails_ID where cd.contractno = @contract    union 	  select   log_ID, Profile_ID, Contract_No, Logs, Username, Log_Entry_Date,area from contract_log where Contract_No = @contract ", cs1);
            SqlCmd.Parameters.Add("@contract", SqlDbType.VarChar).Value = contract;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static int UpdateContractDetails_IndianDealStatus(string DealStatus, string Contract_Canx_date, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                 SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET  DealStatus = '" + DealStatus + "',Contract_Canx_date=convert(datetime,'" + Contract_Canx_date + "',105)    where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                string msg = "Error in UPDATE UpdateContractDetails_IndianDealStatus Query " + " " + ex.Message;

                throw new Exception(msg, ex);

            }

        }
        return rows;
    }
    public static DataSet LoadContractGroup()
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Contract_Group_Name from Contract_Group where Contract_Group_status = 'Active'", cs1);
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadContractGroupOnID(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Contract_Group_Name from Contract_Group where Contract_Group_status = 'Active' and Contract_Group_Name not in(select Contract_group  from ContractDetails_Indian where ContractDetails_ID = @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadContractVenueOnID(string cvenue, string venue,string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select Contract_Venue_Name from Contract_Venue cv join Contract_Group cg on cg.Contract_Group_ID = cv.Contract_Group_ID join venue v on v.venue_id = cv.venue_id     where Contract_Venue_Status = 'Active' and cg.Contract_Group_Name =@cvenue and v.venue_name =@venue and cv.Contract_Venue_Name not in(select Contract_Venue  from ContractDetails_Indian where ContractDetails_ID = @ContractDetails_ID)", cs1);
            scd.Parameters.Add("@cvenue", SqlDbType.VarChar).Value = cvenue;
            scd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int UpdateContractGroupVenue(string Contract_group, string Contract_Venue, string ContractDetails_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET Contract_group= '" + Contract_group + "',Contract_Venue='"+ Contract_Venue+"'  where ContractDetails_ID ='" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                scd.Parameters.Add("@Contract_group", SqlDbType.VarChar).Value = Contract_group;
                scd.Parameters.Add("@Contract_Venue", SqlDbType.VarChar).Value = Contract_Venue;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateContractGroupVenue Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }
    public static int UpdateCommenceExpiryDate(string Expirydate, string Commence_date, string ContractDetails_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET Expirydate= '" + Expirydate + "',Commence_date='" + Commence_date + "'  where ContractDetails_ID ='" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                scd.Parameters.Add("@Commence_date", SqlDbType.VarChar).Value = Commence_date;
                scd.Parameters.Add("@Expirydate", SqlDbType.VarChar).Value = Expirydate;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateCommenceExpiryDate Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }
    public static int UpdateReturnHomeDate(string Returnhomedate, string ContractDetails_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET Returnhomedate= '" + Returnhomedate + "'  where ContractDetails_ID ='" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                scd.Parameters.Add("@Returnhomedate", SqlDbType.VarChar).Value = Returnhomedate;
              
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateReturnHomeDate Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }

   public static DataSet LoadContractDetailsOnID(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from ContractDetails_Indian where ContractDetails_ID= @ContractDetails_ID", cs1);      
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadContractDetailsOnOthersID(string otherNamesID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select cd.ContractDetails_ID, cd.ProfileID  from ContractDetails_Indian cd join ContractNo_Othernames co on co.ContractDetails_ID = cd.ContractDetails_ID where otherNamesID = @otherNamesID", cs1);
            scd.Parameters.Add("@otherNamesID", SqlDbType.VarChar).Value = otherNamesID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

  public static DataSet loadDefaultDate(string username)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select default_Date from defaultDate where Username='"+username+"'", cs1);
            
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

 public static DataSet LoadLoanBUOnVenue(string office, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select ButtonUp_Name  from Loan_Button_Up_Officer  where office=@office and ButtonUp_Status='Active' and venue=@venue ORDER BY 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

 public static DataTable Recapcoldline(string INPUT, string VENUE)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Recapcoldline", cs1);
	    cmd_sp.CommandTimeout=0; 
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", INPUT);
            cmd_sp.Parameters.AddWithValue("@gvenue", VENUE);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

 public static DataTable RoadshowRecap(string INPUT)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("RoadshowRecap", cs1);
            cmd_sp.CommandTimeout = 0;
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", INPUT);
           

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

   public static DataTable RoadshowconsoRecap(string INPUT)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Roadshowconso", cs1);
            cmd_sp.CommandTimeout = 0;
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", INPUT);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

  public static DataTable Monthly_Budget_Goa(string input)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("MonthlyBudgetGoa", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

 public static DataTable Monthly_Budget_Offsite(string input,string venue)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Monthly_offsite", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
   
 public static DataTable Monthly_Budget_OffsiteD(string input, string venue)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Monthlydharam", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

 public static DataTable Yearly_Budget_Goa(string input)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("yearlybudgetgoa", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }


 public static DataTable Monthly_Budget_Roadshow(string input)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Monthlyroad", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
public static DataTable Yearly_Budget_Offsite(string input, string venue)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Yearly_offsite", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

  public static DataTable Yearly_Budget_Roadshow(string input)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Yearlyroad", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static DataTable Yearly_Budget_OffsiteD(string input, string venue)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("Yearlydharam", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

public static DataTable Monthly_Budget_Conso(string input)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("MonthIndiaBudgetConso", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

 public static DataTable Yearly_Budget_Conso(string input)
    {

        using (SqlConnection cs1 = Queries2.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("yearIndiaBudgetConso", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@input", input);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
 public static DataTable LogReport(string profilecontract)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("LogReport", con);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@profilecontract", profilecontract);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

public static int UpdateContract_PA_IndianVolumeUSDExchRate(string USDConvertedTotalVolume,string  exchangerate , string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_PA_Indian  SET USDConvertedTotalVolume = '" + USDConvertedTotalVolume + "', exchangerate = '" + exchangerate + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContract_PA_IndianVolumeUSDExchRate Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateContract_Fractional_PA_IndianVolumeUSDExchRate(string USDConvertedTotalVolume, string exchangerate, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Fractional_PA_Indian  SET USDConvertedTotalVolume = '" + USDConvertedTotalVolume + "', exchangerate = '" + exchangerate + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE UpdateContract_Fractional_PA_IndianVolumeUSDExchRate Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
public static int UpdateContract_Trade_In_Weeks_IndianActualPoints(string Actualpoints_value, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Trade_In_Weeks_Indian  SET Actualpoints_value = '" + Actualpoints_value + "' where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
 
                scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                string msg = "Error in UPDATE UpdateContract_Trade_In_Weeks_IndianActualPoints Query " + " " + ex.Message;

                throw new Exception(msg, ex);


            }

        }
        return rows;
    }

	public static int UpdateContractDepositDetailsFloodCess(string floodcess,  string receiptID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Contract_Indian_Deposit_Receipt set floodcess = '" + floodcess + "'  where Deposit_Receipt_Id = '" + receiptID + "'", cs1);
                scd.Parameters.Add("@receiptID", SqlDbType.VarChar).Value = receiptID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateContractDepositDetailsFloodCess Query " + " " + ex.Message;

                throw new Exception(msg, ex);

            }

        }
        return rows;
    }
 public static int UpdateFinance_Details_IndianOpenLANo(string Open_Loan_AgreementNo, string ContractDetails_ID)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Finance_Details_Indian set Open_Loan_AgreementNo = '" + Open_Loan_AgreementNo + "'  where ContractDetails_ID = '" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@receiptID", SqlDbType.VarChar).Value = ContractDetails_ID;
                rows = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateFinance_Details_IndianOpenLANo Query " + " " + ex.Message;

                throw new Exception(msg, ex);

            }

        }
        return rows;
    }
 public static int CurrencyByCountryExists(string countryid)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select distinct Country_ID from Currency_Country where country_id =@countryid", cs1);
            scd.Parameters.Add("@countryid", SqlDbType.VarChar).Value = countryid;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }
    public static int CurrencyExistsByCountry(string Country_ID,string Currency_Value)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Currency_Value from Currency_Country where Country_ID =@Country_ID and Currency_Value =@Currency_Value", cs1);
            scd.Parameters.Add("@Country_ID", SqlDbType.VarChar).Value = Country_ID;
            scd.Parameters.Add("@Currency_Value", SqlDbType.VarChar).Value = Currency_Value;
            
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }
    public static int DeleteCurrencyCountry(string Country_ID, string Currency_Value)
    {
        int rows = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("delete from Currency_Country where country_id=@Country_ID and currency_value=@Currency_Value", cs1);
            scd.Parameters.Add("@Country_ID", SqlDbType.VarChar).Value = Country_ID;
            scd.Parameters.Add("@Currency_Value", SqlDbType.VarChar).Value = Currency_Value;
            rows = scd.ExecuteNonQuery();
        }
        return rows;
    }


    public static DataSet LoadCurrencyByCountry(string country)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select Currency_Value from Currency_Country cc join VenueCountry vc on vc.Venue_Country_ID = cc.Country_ID where vc.Venue_Country_Name = @country and cc.Currency_Country_Status = 'Active' order by 1", cs1);
            SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet currencyfinancedetailsbycountry(string ContractDetails_ID, string country)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             SqlCommand scd = new SqlCommand("select Currency_Value from Currency_Country cc join VenueCountry vc on vc.Venue_Country_ID = cc.Country_ID where vc.Venue_Country_Name = 'india' and cc.Currency_Country_Status = 'Active'and Currency_Value   not in(Select currency from Finance_Details_Indian where ContractDetails_ID = @ContractDetails_ID)" , cs1); 
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            scd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

  public static DataTable Members(string fromDate, string toDate)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("New_Members_new", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", fromDate);
            cmd_sp.Parameters.AddWithValue("@EDATE", toDate);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
 public static DataSet LoadCancel_Type()
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select CT_Type from cancel_type order by 1", cs1);
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadCancel_reason()
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select  CR_Reasons  from Cancel_reason where CR_Status='Active' order by 1", cs1);
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadStatus_ChangeDetails(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from status_change where Contract_Finance_ID =@ContractDetails_ID ", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int Status_ChangeDetailsExists(string ContractDetails_ID)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select Contract_Finance_ID  from status_change  where Contract_Finance_ID =@ContractDetails_ID", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }
    public static DataSet LoadCancelTypeother(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select CT_Type from cancel_type where ct_type not in(select sc_cancel_type from status_change where Contract_Finance_ID =@ContractDetails_ID) ", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadCancel_reasonother(string ContractDetails_ID)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select  CR_Reasons  from Cancel_reason where CR_Status='Active' and CR_Reasons not in(select SC_Cancel_Reason from status_change where Contract_Finance_ID =@ContractDetails_ID ) order by 1", cs1);
            scd.Parameters.Add("@ContractDetails_ID", SqlDbType.VarChar).Value = ContractDetails_ID;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static int Updatestatus_change(string SC_Cancel_Group_Venue, string SC_Cancel_Reason, string SC_Cancel_Type, string SC_Cancel_Comment, string SC_Update_Date, string Contract_Finance_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update status_change  SET SC_Cancel_Group_Venue= '" + SC_Cancel_Group_Venue + "',	SC_Cancel_Reason= '" + SC_Cancel_Reason + "',	SC_Cancel_Type= '" + SC_Cancel_Type + "',	SC_Cancel_Comment= '" + SC_Cancel_Comment + "',	SC_Update_Date= '" + SC_Update_Date + "' where Contract_Finance_ID ='" + Contract_Finance_ID + "'", cs1);
                scd.Parameters.Add("@Contract_Finance_ID", SqlDbType.VarChar).Value = Contract_Finance_ID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE Updatestatus_change Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }
public static int UpdateFinancemailingAddress(string Finance_mailingAddress, string ContractDetails_ID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update ContractDetails_Indian  SET Finance_mailingAddress = '" + Finance_mailingAddress + "'  where ContractDetails_ID ='" + ContractDetails_ID + "'", cs1);
                scd.Parameters.Add("@ContractDetails_ID ", SqlDbType.VarChar).Value = ContractDetails_ID;
                scd.Parameters.Add("@Finance_mailingAddress ", SqlDbType.VarChar).Value = Finance_mailingAddress;

                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "Error in UPDATE UpdateFinancemailingAddress Query " + " " + ex.Message;
                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }

  public static DataTable OffTheRecap(string fromDate, string toDate)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("OffTheRecap", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", fromDate);
            cmd_sp.Parameters.AddWithValue("@EDATE", toDate);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
 public static DataTable BUProc(string contractno)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("ButtonUp_Report", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractno", contractno);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }


}