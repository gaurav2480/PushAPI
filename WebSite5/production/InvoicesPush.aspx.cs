using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;
public partial class WebSite5_production_InvoicesPush : System.Web.UI.Page
{

    public void ContractInfo()
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query= "select top(1500) *  from MemberData_MC_Invoices where pstatus='Active' and Status='Inactive'  order by ID asc";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string maestroMemberNo = reader.GetString(1);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query3 = "select * from MemberData_MC_Invoices where VpMemberNo!='' and MemberNo = '" + maestroMemberNo.Trim() + "'";
                sqlcon1.Open();
                SqlCommand cmd3 = new SqlCommand(query3, sqlcon1);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.HasRows)
                {

                }
                else
                {
                   
                    WebRequest webReq = (HttpWebRequest)WebRequest.Create("https://karma.viewpointweb.com/v1/member/external/10048/" + maestroMemberNo.Trim() + "");
                    webReq.Headers.Add("api_key", "eb906bc1-77b6-4aa5-bb29-5fb5735e9dc6");
                    WebResponse response = webReq.GetResponse();
                    StreamReader reader1 = new StreamReader(response.GetResponseStream());
                    string Joke_Json = reader1.ReadToEnd();
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    var records = ser.Deserialize<Owner>(Joke_Json);
                    string vpMemberNo = records.AccountID;

                    string query2 = "update MemberData_MC_Invoices set VpMemberNo='" + vpMemberNo + "' where MemberNo = '" + maestroMemberNo.Trim() + "' ;";
                    SqlCommand cmd2 = new SqlCommand(query2, sqlcon);
                    cmd2.ExecuteNonQuery();
                    reader1.Close();
                }
                reader3.Close();
                sqlcon1.Close();
            }
        }
        reader.Close();
        sqlcon.Close();

    }


    public void api()
    {
        string failedContractID = "";
        string failedSourceFileName = "";
        string failedDescription = "";
        string failedDocumentDate = "";
        string failedDocumentFileType = "";
        string failedDocumentSourceType = "";
        string failedDocumentType = "";


        try
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string memberNumber = "";
            string maestroMemberNumber = "";

            SqlDataReader readerload = API.getAllVpMemberNumbers();
            if (readerload.HasRows)
            {
                while (readerload.Read())
                {
                    memberNumber = memberNumber + readerload.GetString(0) + ",";
                    maestroMemberNumber = maestroMemberNumber + readerload.GetString(1) + ",";

                }
                readerload.Close();

                string[] memberNumberArray = memberNumber.Split(',');
                string[] maestroMemberNumberArray = maestroMemberNumber.Split(',');


                for (int j = 0; j < memberNumberArray.Length - 1; j++)
                {
                    string MaestroID = "";
                    string value = "";
                    SqlConnection sqlcon = new SqlConnection(conn);
                    sqlcon.Open();

                    WebRequest webReq = (HttpWebRequest)WebRequest.Create("https://karma.viewpointweb.com/v1/member/" + memberNumberArray[j].Trim() + "/contracts");
                    webReq.Headers.Add("api_key", "eb906bc1-77b6-4aa5-bb29-5fb5735e9dc6");
                    WebResponse response = webReq.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    int updateContractInfoStatus = API.updateContractIndoStatus(memberNumberArray[j]);
                    string Joke_Json = reader.ReadToEnd();
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    var records = ser.Deserialize<List<contract>>(Joke_Json);

                            //var records = JsonConvert.DeserializeObject<List<contract>>(Joke_Json);
                            //contract myjoke = Newtonsoft.Json.JsonConvert.DeserializeObject<contract>(Joke_Json);
                             string contractNo = records[0].ExternalContractID;
                             string memberNo = records[0].AccountID;
                             string contractID = records[0].ContractID.ToString();

                            failedContractID = contractID;
                            string query = "update MemberData_MC_Invoices set contractID='" + contractID + "', pStatus='Inactive' ,contractNo='"+ contractNo + "' where  VpMemberNo='" + memberNo + "' ;";
                            SqlCommand cmd = new SqlCommand(query, sqlcon);
                            cmd.ExecuteNonQuery();
                            sqlcon.Close();
                            reader.Close();

                            string[] files = Directory.GetFiles(@"\\192.168.10.40\D$\new\code\App_Data", "*" + maestroMemberNumberArray[j].Trim() + "*", SearchOption.AllDirectories);

                             foreach (string file in files)
                                    {
                                        Byte[] bytes = File.ReadAllBytes(file);
                                        String filess = Convert.ToBase64String(bytes);

                                      /*  SqlConnection sqlcon2 = new SqlConnection(conn);
                                        sqlcon2.Open();
                                        string query3 = "select * from collection_corres where Maestromem='" + MaestroNumber.Trim() + "' and SourceFileName='" + sourceFileName + "'";
                                        SqlCommand cmd3 = new SqlCommand(query3, sqlcon2);
                                        SqlDataReader reader3 = cmd3.ExecuteReader();
                                        if (reader3.HasRows)
                                        { }
                                        else
                                        {*/
                                          /*  string query4 = "insert into collection_corres values('" + contractID + "','" + sourceFileName + "','" + Description + "','" + DocumentDate + "','" + DocumentFileType + "','" + DocumentSourceType + "','" + DocumentType + "','','" + MaestroNumber.Trim() + "');";
                                            SqlCommand cmd4 = new SqlCommand(query4, sqlcon2);
                                            cmd4.ExecuteNonQuery();*/
                                            WebRequest postwebReq = (HttpWebRequest)WebRequest.Create("https://karma.viewpointweb.com/v1/contract/" + contractID + "/document");

                                            postwebReq.Headers.Add("api_key", "eb906bc1-77b6-4aa5-bb29-5fb5735e9dc6");
                                            postwebReq.Method = "POST";
                                            postwebReq.ContentType = "application/json";
                                         // string postData = "{\"LogType\":\"" + LogType + "\",\"UserLogType\":\"" + UserLogType + "\",\"LogStatus\":\"" + LogStatus + "\",\"LogComment\":\"" + LogComment + "\",\"Subject\":\"" + Description + "\",\"LogSourceID\":\"" + LogSourceID + "\",\"AssignedToUser\":\"" + AssignedToUser + "\",\"UserDate\":\"" + UserDate + "\",\"DueDate\":\"" + DueDate + "\",\"Attachment\":{\"Description\":\"" + Description + "\",\"DocumentType\":\"" + DocumentType + "\",\"DocumentFileType\":\"" + DocumentFileType + "\",\"DocumentSourceType\":\"" + DocumentSourceType + "\",\"DocumentDate\":\"" + DocumentDate + "\",\"SourceFileName\":\"" + sourceFileName + "\",\"Base64Data\":\"" + filess + "\"}}";
                                            string postData = "{\"Description\":\"" +"Maestro_MC_Invoices_Payment_History" + "\",\"DocumentType\":\"" + "94918" + "\",\"DocumentFileType\":\"" + "10040" + "\",\"DocumentSourceType\":\"" + "95260" + "\",\"DocumentDate\":\"" + "2021-02-25" + "\",\"SourceFileName\":\"" + maestroMemberNumberArray[j].Trim() + "_Maestro_MC_Invoices_Payment_History" + ".pdf" + "\",\"Base64Data\":\"" + filess + "\"}";
                                            using (var streamWriter = new StreamWriter(postwebReq.GetRequestStream()))
                                            {
                                                streamWriter.Write(postData);
                                                streamWriter.Flush();
                                                streamWriter.Close();
                                                var httpResponse = (HttpWebResponse)postwebReq.GetResponse();
                                                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                                {
                                                    var result2 = streamReader.ReadToEnd();

                                                    streamReader.Close();
                                SqlConnection sqlcon1 = new SqlConnection(conn);
                                sqlcon1.Open();
                                string query1 = "update MemberData_MC_Invoices set PushStatus='Success' where  contractID='" + contractID + "' ;";
                                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                                cmd1.ExecuteNonQuery();
                                sqlcon1.Close();
                            }
                                                
                                            }

                                        }

                                       // reader3.Close();
                                      //  sqlcon2.Close();
                                    }

                label1.Text = "Upload Successful";
                //  Response.Redirect(Request.RawUrl, false);
                Response.AppendHeader("Refresh", "30;url=InvoicesPush.aspx");
            }
                          //  }

                    //        reader2.Close();
                        //    sqlcon1.Close();
                        
                    
               // }
              
           // }
            else
            {
                label1.Text = "All files are uploaded successfully!!!";
            }

        }
        catch (Exception ex)
        {
            label1.Text = ex.Message;
           /// int failedDetails = API.InsertFailedDetails(failedContractID, failedSourceFileName, failedDescription, failedDocumentDate, failedDocumentFileType, failedDocumentSourceType, failedDocumentType, "", "");
            Response.AppendHeader("Refresh", "30;url=apidemo.aspx");

        }
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {

    //  api();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ContractInfo();
        api();
    }


    public string getAllMembers()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select * from[contractinfo] where status = 'Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string contractNo = reader.GetString(0);
            string memberNo = reader.GetString(1);
            htmlstr += "<option value='" + memberNo + "'>" + contractNo + "</option>";
        }

        reader.Close();
        sqlcon.Close();
        return htmlstr;
    }



    public class contract
    {
        public int ContractID { get; set; }
        public string AccountID { get; set; }
        public string ExternalContractID { get; set; }
        public int Quantity { get; set; }
        public string InventoryType { get; set; }
        public int UnitTypeID { get; set; }
        public object UnitTypeDesc { get; set; }
        public object UnitTypeAbbr { get; set; }
        public int WeekTypeID { get; set; }
        public object WeekTypeDesc { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int StatusID { get; set; }
        public int ResortID { get; set; }
        public string ResortName { get; set; }
        public int ProductID { get; set; }
        public int Term { get; set; }
        public string TradeIn { get; set; }
        public int InventoryClassID { get; set; }
        public int ChargeCenterID { get; set; }
        public DateTime CommenceDate { get; set; }
        public double ExchangeRate { get; set; }
        public int ReportingChargeCenterID { get; set; }
        public int CollectionsResortID { get; set; }
        public int FinanceStatusID { get; set; }
        public int FinanceCompanyID { get; set; }
        public object FinanceNo { get; set; }
        public DateTime ApprovedDate { get; set; }
        public object AccountManager { get; set; }
        
    }


    public class Owner
    {
        public string AccountID { get; set; }
        public int ContactID { get; set; }
        public string Title { get; set; }
        public int TitleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailName { get; set; }
        public string Salutation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressCity { get; set; }
        public string AddrCountry { get; set; }
        public string Postcode { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsOwner { get; set; }
        public bool IsFamily { get; set; }
        public bool Active { get; set; }
        public object CRMData { get; set; }
    }

    public class RootObject
{
    public string AccountID { get; set; }
    public string AccountName { get; set; }
    public string AccountType { get; set; }
    public int AccountTypeID { get; set; }
    public string ServiceCenter { get; set; }
    public int ServiceCenterID { get; set; }
    public string AccountStatus { get; set; }
    public int AccountStatusID { get; set; }
    public int DefaultChargeCenter { get; set; }
    public DateTime JoinedDate { get; set; }
    public string BillingAddressLine1 { get; set; }
    public string BillingAddressLine2 { get; set; }
    public string BillingAddressLine3 { get; set; }
    public string BillingAddressCity { get; set; }
    public string BillingAddrCountry { get; set; }
    public string BillingPostcode { get; set; }
    public string Notes { get; set; }
    public List<Owner> Owners { get; set; }
    public object Contacts { get; set; }
}

    /*  SqlConnection sqlcon3 = new SqlConnection(conn);
        sqlcon3.Open();
        string query5 = "select * from collection_corres where contractid='"+contractID+"';";
        SqlCommand cmd5 = new SqlCommand(query5, sqlcon3);
        SqlDataReader reader5 = cmd5.ExecuteReader();
        while (reader5.Read())
        {
            string postContractID = reader5.GetString(0);
            string postSourceFileName = reader5.GetString(1);
            string postDescription = reader5.GetString(2);
            string postDocumentDate = reader5.GetString(3);
            string postDocumentFileType = reader5.GetString(4);
            string postDocumentSourceType = reader5.GetString(5);
            string postDocumentType = reader5.GetString(6);
            string postBase64Data = reader5.GetString(7);

            WebRequest postwebReq = (HttpWebRequest)WebRequest.Create("");
            postwebReq.Headers.Add("api_key", "db4ba1fd-5d20-4e10-9b1e-b1d34c46d524");
            postwebReq.Method = "POST";
            postwebReq.ContentType = "application/json";
         

            string postData = "{\"Description\":\""+postDescription+ "\",\"DocumentType\":\"" + postDocumentType + "\",\"DocumentFileType\":\"" + postDocumentFileType + "\",\"DocumentSourceType\":\"" + postDocumentSourceType + "\",\"DocumentDate\":\"" + postDocumentDate + "\",\"SourceFileName\":\"" + postSourceFileName + "\",\"Base64Data\":\"" + postBase64Data + "\"}";

            using (var streamWriter = new StreamWriter(postwebReq.GetRequestStream()) )
            {
                streamWriter.Write(postData);
               streamWriter.Flush();
               streamWriter.Close();

                var httpResponse = (HttpWebResponse)postwebReq.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result2 = streamReader.ReadToEnd();
                }

            }



        }
        reader5.Close();
        sqlcon3.Close();*/




    /*  sqlcon.Open();
      string query1 = "select distinct SUBSTRING(Cust_Serv_Member, 1, 4) as Cust_Serv_Member,Cont_Cont_Numb,contractid,Cust_Serv_File_Name 'SourceFileName' ,Cust_Serv_Desc 'Description',convert(varchar,Cust_Serv_Date,105) 'DocumentDate','10038' DocumentFileType,Log_Code_Desc,docsrcname, docsrcid 'DocumentSourceType',case when Cust_Serv_Desc like '%pa %' then '94917' when Cust_Serv_Desc like '%receipt%'  then '94970' else '10130' end as 'DocumentType' from CuMe_Curr_Cust_Serv join cume_Curr_log_code on Log_Code_Code=Cust_Serv_Type join cume_curr_cont on Cont_Mem_Numb=Cust_Serv_Member join CuMe_Curr_Col_Fina on Col_Fina_Cont_Numb=Cont_Cont_Numb join [contractinfo] on [contractno]=Cont_Cont_Numb join [DOC Source type] on docsrcname=Log_Code_Desc where Cust_Serv_Date>=Cont_DSR_Date and Cust_Serv_Date<=Cont_Cls_Date and Cont_Cls_Date>='2019-07-01' and  Cont_Cls_Date<='2019-07-31' and contractid='" + contractID+"';";
      //  string query1 = " select  SUBSTRING(Maestromem, 1, 4) AS Number from contractinfo where VPmem='" + memberNo+"' and contractid='"+ contractID + "';";
      SqlCommand cmd1 = new SqlCommand(query1, sqlcon);
      SqlDataReader reader1 = cmd1.ExecuteReader();
      while (reader1.Read())
      {

           MaestroID = reader1.GetString(0);
           string sourceFileName = reader1.GetString(3);
           string Description = reader1.GetString(4);
           string DocumentDate = reader1.GetString(5);
           string DocumentFileType = reader1.GetString(6);
           string DocumentSourceType = reader1.GetString(9);
           string DocumentType = reader1.GetString(10);





      }*/


    /* string[] files = Directory.GetFiles(@"" + dir + "", "*" + sourceFileName + "*", SearchOption.AllDirectories);
     Response.Write("<b>List of file</b><br>");
     foreach (string file in files)
     {

         Byte[] bytes = File.ReadAllBytes(file);
         String filess = Convert.ToBase64String(bytes);

         SqlConnection sqlcon1 = new SqlConnection(conn);
         sqlcon1.Open();
         string query3 = "select * from collection_corres where contractid='" + contractID + "' and SourceFileName='" + sourceFileName + "'";
         SqlCommand cmd3 = new SqlCommand(query3, sqlcon1);
         SqlDataReader reader3 = cmd3.ExecuteReader();
         if (reader3.HasRows)
         {
         }
         else
         {
             string query2 = "insert into collection_corres values('" + contractID + "','" + sourceFileName + "','" + Description + "','" + DocumentDate + "','" + DocumentFileType + "','" + DocumentSourceType + "','" + DocumentType + "','" + filess + "');";
             SqlCommand cmd2 = new SqlCommand(query2, sqlcon);
             cmd2.ExecuteNonQuery();
         }

         reader3.Close();
         sqlcon1.Close();


     }*/

    protected void Button2_Click(object sender, EventArgs e)
    {
        Environment.Exit(1);
    }
 }