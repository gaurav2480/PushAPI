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
/// <summary>
/// Summary description for production
/// </summary>
public class production
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

       public static SqlDataReader searchProfiles(string profileID,string office)//string venue)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        //   SqlCommand SqlCmd = new SqlCommand("  select distinct Manager_Name from managers where Manager_Status='Active' and  Venue=@venue order by 1", cs1);
        SqlCommand SqlCmd = new SqlCommand("select top(100) pp.Profile_ID,pp.Profile_Primary_Title as Title,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as Name,e.Primary_Email as Email,q.Primary_Mobile as Mobile, REPLACE(ISNULL(CONVERT(varchar, td.Tour_Details_Tour_Date,105), ''), '01-01-1900', '') as [Tour Date],td.Tour_Details_ID as Tour_Id ,cast(dbo.udf_GetNumeric(pp.Profile_ID) as int) as sort  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  join Email e on e.Profile_ID =pp.Profile_ID join Phone q on q.Profile_ID =pp.Profile_ID join Tour_Details td on p.Profile_ID = td.Profile_ID where p.office in (" + office.TrimEnd(',') + ") and (pp.Profile_ID = '" + profileID + "' or pp.Profile_Primary_Fname like '" + profileID + "%' or pp.Profile_Primary_Lname like '" + profileID + "%' or q.Primary_Mobile like '" + profileID + "%' or e.Primary_Email like '" + profileID + "%') order by sort asc;", cs1);
        SqlCmd.Parameters.Add("@profileID", SqlDbType.VarChar).Value = profileID;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }

	 public static String GetVenueCode(string Venue_Name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("  select Venue_ID from venue where Venue_Name=@Venue_Name and Venue_Status='Active'", cs1);
            scd.Parameters.Add("@Venue_Name", SqlDbType.VarChar).Value = Venue_Name;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static String GetContractgroupCode(string Contract_Group_Name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("    select Contract_Group_ID   from contract_group  where Contract_Group_Name=@Contract_Group_Name and Contract_Group_Status='Active'", cs1);
            scd.Parameters.Add("@Contract_Group_Name", SqlDbType.VarChar).Value = Contract_Group_Name;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static int Insertcontractvenue(string  Contract_Venue_ID,string Contract_Group_ID, string Contract_Venue_Name,  string Contract_Venue_Creation, string Contract_Venue_Updated, string Venue_ID,string vpID)
    {
        int   rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        string Contract_Venue_Status = "Active";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into contract_venue values(@Contract_Venue_ID,	@Contract_Group_ID,	@Contract_Venue_Name,	@Contract_Venue_Status,	@Contract_Venue_Creation,	@Contract_Venue_Updated,	@Venue_ID,@vpID)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_Venue_ID", SqlDbType.VarChar).Value =Contract_Venue_ID;
                da.InsertCommand.Parameters.Add("@Contract_Group_ID", SqlDbType.VarChar).Value =Contract_Group_ID;
                da.InsertCommand.Parameters.Add("@Contract_Venue_Name", SqlDbType.VarChar).Value =Contract_Venue_Name;
                da.InsertCommand.Parameters.Add("@Contract_Venue_Status", SqlDbType.VarChar).Value =Contract_Venue_Status;
                da.InsertCommand.Parameters.Add("@Contract_Venue_Creation", SqlDbType.VarChar).Value =Contract_Venue_Creation;
                da.InsertCommand.Parameters.Add("@Contract_Venue_Updated", SqlDbType.VarChar).Value =Contract_Venue_Updated;
                da.InsertCommand.Parameters.Add("@Venue_ID", SqlDbType.VarChar).Value =Venue_ID;
                da.InsertCommand.Parameters.Add("@vpID", SqlDbType.VarChar).Value = vpID;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //  MessageBox.Show("Error in ID Generation Query " + ex.Message);

                string msg = "Error in ID Insertcontractvenue Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static String GetVenueName(string Venue_ID)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("  select Venue_Name  from venue where Venue_ID=@Venue_ID and Venue_Status='Active'", cs1);
            scd.Parameters.Add("@Venue_ID", SqlDbType.VarChar).Value = Venue_ID;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static String GetRegion(string country)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("  select region  from VenueCountry where Venue_Country_Name=@country and Venue_Country_Status='Active'", cs1);
            scd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

            val = (string)scd.ExecuteScalar();
        }
        return val;
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
    public static int InsertcontractvenueVP(string CVenue_ID, string CVenue_Region, string CVenue_Country, string CVenue_Venue2, string CVenue_VenueCountryID, string CVenue_VenueID, string CVenue_GroupVenueID, string CVenue_Venue,  string CVenue_Insertdate, string CVenue_expirydate,int CVenue_Reverse,string vpID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        string CVenue_Status = "Active";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Venue_VP values(@CVenue_ID,	@CVenue_Region,	@CVenue_Country,	@CVenue_Venue2,	@CVenue_VenueCountryID,	@CVenue_VenueID,	@CVenue_GroupVenueID,	@CVenue_Venue,	@CVenue_Status,	@CVenue_Insertdate,	@CVenue_expirydate,@CVenue_Reverse,@vpID)", cs1);
                da.InsertCommand.Parameters.Add("@CVenue_ID", SqlDbType.VarChar).Value = CVenue_ID;
                da.InsertCommand.Parameters.Add("@CVenue_Region", SqlDbType.VarChar).Value = CVenue_Region;
                da.InsertCommand.Parameters.Add("@CVenue_Country", SqlDbType.VarChar).Value = CVenue_Country;
                da.InsertCommand.Parameters.Add("@CVenue_Venue2", SqlDbType.VarChar).Value = CVenue_Venue2;
                da.InsertCommand.Parameters.Add("@CVenue_VenueCountryID", SqlDbType.VarChar).Value = CVenue_VenueCountryID;
                da.InsertCommand.Parameters.Add("@CVenue_VenueID", SqlDbType.VarChar).Value = CVenue_VenueID;
                da.InsertCommand.Parameters.Add("@CVenue_GroupVenueID", SqlDbType.VarChar).Value = CVenue_GroupVenueID;
                da.InsertCommand.Parameters.Add("@CVenue_Venue", SqlDbType.VarChar).Value = CVenue_Venue;
                da.InsertCommand.Parameters.Add("@CVenue_Status", SqlDbType.VarChar).Value = CVenue_Status;
                da.InsertCommand.Parameters.Add("@CVenue_Insertdate", SqlDbType.VarChar).Value = CVenue_Insertdate;
                da.InsertCommand.Parameters.Add("@CVenue_expirydate", SqlDbType.VarChar).Value = CVenue_expirydate;
	         	da.InsertCommand.Parameters.Add("@CVenue_Reverse", SqlDbType.Int).Value = CVenue_Reverse;
                da.InsertCommand.Parameters.Add("@vpID", SqlDbType.Int).Value = vpID;


                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

          

                string msg = "Error in ID InsertcontractvenueVP Query " + " " + ex.Message;

                throw new Exception(msg, ex);


             
            }
        }
        return (rowsAffected);
    }
     
    public static DataTable ExportLogsOnProfile(string profileid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("ExportLogs_Profile", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@profileid", profileid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable ExportLogsOnContract(string contract)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("ExportLogs_Profile", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contract", contract);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable ExportLogsOnProfileWithDates(string profileid,string sdate , string edate)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("ExportLogsWithDate_Profile", con);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@profileid", profileid);
            cmd_sp.Parameters.AddWithValue("@sdate", sdate);
            cmd_sp.Parameters.AddWithValue("@edate", edate);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable ExportLogsOnContractWithDates(string contract, string sdate, string edate)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("ExportLogsWithDate_Contract", con);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contract", contract);
            cmd_sp.Parameters.AddWithValue("@sdate", sdate);
            cmd_sp.Parameters.AddWithValue("@edate", edate);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataSet LoadContractGroup(string Contract_Group_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select* from contract_group where Contract_Group_ID=@Contract_Group_ID", cs1);
            SqlCmd.Parameters.Add("@Contract_Group_ID", SqlDbType.VarChar).Value = Contract_Group_ID; 
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static String GetContractgroupName(string Contract_Group_ID)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("    select Contract_Group_Name   from contract_group  where Contract_Group_ID=@Contract_Group_ID and Contract_Group_Status='Active'", cs1);
            scd.Parameters.Add("@Contract_Group_ID", SqlDbType.VarChar).Value = Contract_Group_ID;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static String GetGroupVenueCode(string Venue_Name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("  select Venue_ID from venue where Venue_Name=@Venue_Name and Venue_Status='Active'", cs1);
            scd.Parameters.Add("@Venue_Name", SqlDbType.VarChar).Value = Venue_Name;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static String GetVenueName2(string Venue_ID)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("  select Venue2_Name  from venue2 where Venue2_ID=@Venue_ID and Venue2_Status='Active'", cs1);
            scd.Parameters.Add("@Venue_ID", SqlDbType.VarChar).Value = Venue_ID;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
 public static DataTable LogsPage(string  LogID)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PCLog", con);
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@LogID", LogID);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataSet LoadProfileLog(string LogID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("  select profileid 'Profile ID', descriptiontitle 'Description', Old_value [Old Value], New_value [New Value], Username [User], PageName [Page] , Log_Entry [Date] from Contract_Logs_India where LogID = @LogID", cs1);
            SqlCmd.Parameters.Add("@LogID", SqlDbType.VarChar).Value = LogID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

}