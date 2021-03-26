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
/// Summary description for Queries
/// </summary>
public class API
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
  

    public static DataSet currencyfinancedetailsbycountry(string ContractDetails_ID, string country)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = API.GetDBConnection())
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


    public static SqlDataReader getAllContractNumbers()
    {
        SqlDataReader dr;
        SqlConnection cs1 = API.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct  VPmem,contractno from contractinfo where Status='Active';", cs1);
        //SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }

    public static SqlDataReader getAllVpMemberNumbers()
    {
        SqlDataReader dr;
        SqlConnection cs1 = API.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct top(1500) VpMemberNo,MemberNo,ID from MemberData_MC_Invoices where pStatus='Active' order by ID asc;", cs1);
        //SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }


    public static int InsertFailedDetails(string contractid,string sourfilename,string description,string documentDate,string documentFileType,string documentSourceType,string documentType,string base64data,string errorMessage)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = API.GetDBConnection())
        {
                da.InsertCommand = new SqlCommand("insert into collection_corres_Failed values('"+contractid+"','"+sourfilename+"','"+description+"','"+documentDate+"','"+documentFileType+"','"+documentSourceType+"','"+documentType+"','','')", cs1);
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
        }
        return (rowsAffected);
    }


    public static int updateContractIndoStatus(string memberNo)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = API.GetDBConnection())
        {
            da.InsertCommand = new SqlCommand("update contractinfo set Status='Inactive' where VPmem='"+memberNo+"'", cs1);
            rowsAffected = da.InsertCommand.ExecuteNonQuery();
        }
        return (rowsAffected);
    }

    public static int updateInvoicePushStatus(string memberNo)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = API.GetDBConnection())
        {
            da.InsertCommand = new SqlCommand("update MemberData_MC_Invoices set pStatus='Inactive' where VpMemberNo='" + memberNo + "'", cs1);
            rowsAffected = da.InsertCommand.ExecuteNonQuery();
        }
        return (rowsAffected);
    }


    public static SqlDataReader getAllVpMemberNo()
    {
        SqlDataReader dr;
        SqlConnection cs1 = API.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct VPmem,fileName,contractno from [creditNote_VPMem] where Status='Active';", cs1);
        //SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }




}