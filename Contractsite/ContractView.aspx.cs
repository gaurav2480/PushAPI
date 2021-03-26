using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Sql;
using System.Net;
using System.IO;
using System.Web.UI.WebControls.Adapters;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Globalization;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using System.Collections.Generic;

public partial class Contractsite_ContractView : System.Web.UI.Page
{
    //static string officeo, GenContNumbglob,globContClub="";
    protected void Page_Load(object sender, EventArgs e)
    { 
        //string user =  (string)Session["username"];
        //string office = Queries.GetOffice(user);
       // string resort="", resort1="";
       // Session["officeo"] = "";
        //Session["officeo"] = office;


	string user =  (string)Session["username"];
      //  string office = Queries.GetOffice(user);
        string resort="", resort1="";
       // Session["officeo"] = "";
       // Session["officeo"] = office;





        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        if (!Page.IsPostBack)
        {

            //string contractno = "RGC9/271117/114";//.ToString(Request.QueryString["ContractNo"]);

            string contractno = Convert.ToString(Request.QueryString["ContractNo"]);
            Session["GenContNumbglob"] = "";
          Session["GenContNumbglob"] = contractno;

	 string ProfileID = Queries2.getProfileIDfromNo(contractno);

            // string  office = Queries2.GetOfficeFromCountry(ProfileID);
            string office = Queries2.GetOfficeFromCountry(ProfileID);


            string fracid = Queries2.getcontIDfromNo(contractno);
         
            DataSet ds4 = Queries2.LoadAllContractFractionalDetails(fracid);
            string conttype = ds4.Tables[0].Rows[0]["Contract_Finance_Cont_Type"].ToString(); //ds4.Tables[0].Rows[0][""].ToString();
            Session["globContClub"] = "";
            if (conttype == "Points")
            {
                Session["globContClub"]  = ds4.Tables[0].Rows[0]["CT_Points_Club"].ToString(); 
            }
            else if (conttype == "Trade Into Points")
            {
                Session["globContClub"] = ds4.Tables[0].Rows[0]["TP_New_CLub"].ToString();
            }
            else if (conttype == "Fractional")
            {
                Session["globContClub"] = "";
                resort1= ds4.Tables[0].Rows[0]["Contract_Fractional_Resort"].ToString();
                if (resort1=="FRACTIONAL MEMBER")
                {
                    resort = "FM";
                }
            }
            else if (conttype == "Trade Into Fractional")
            {
                Session["globContClub"] = "";


resort1 = ds4.Tables[0].Rows[0]["TF_Resort"].ToString();
                if (resort1 == "FRACTIONAL MEMBER")
                {
                    resort = "FM";
                }




            }


            string PaymentMethod=ds4.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString();
            string affilice = ds4.Tables[0].Rows[0]["Contract_Finance_Affil_ICE"].ToString();
            string CrownCurr = ds4.Tables[0].Rows[0]["Contract_Finance_Crown_Curr"].ToString();
string financeCurr = ds4.Tables[0].Rows[0]["Contract_Finance_Currency"].ToString();
string coolonoff = ds4.Tables[0].Rows[0]["Contract_Finance_Cool_OnOff"].ToString();

            string PaymentMethod2, affil2;
            if (PaymentMethod == "Crown Finance")
            {
                PaymentMethod2 = "Crown Finance";
            }
            else
            {
                PaymentMethod2 = "NCrown Finance";
            }

            if (affilice == "True")
            {
                affil2 = "ICE";
            }
            else
            {
                affil2 = "NICE";
            }







  if (office == "GER" || office == "GRE" || office == "FRA" || office == "ITA" || office == "IRE")
            {
                if (coolonoff == "1")
                {
                    Session["Pofficeo"] = "GER";
                    Session["Cooloff"] = "1";

                }
                else
                {
                    Session["Pofficeo"] = "GER";
                    Session["Cooloff"] = "";
                }
            }
            else
            {
                Session["Cooloff"] = "";
                Session["Pofficeo"] = office;
            }



            Session["PConttype"] = conttype;//DropDownList40.SelectedItem.Text;
            //Session["Pofficeo"] = office;
            Session["PGlobContClub"] = Session["globContClub"].ToString();
            Session["PPaymentMethod"] = PaymentMethod2;
            Session["PAffil"] = affil2;
            Session["PCrownCurr"] = CrownCurr;
            Session["Presort"] = resort;
Session["PFinaCurrency"] = financeCurr;


            if (financeCurr == "INR")
            {


                if (PaymentMethod == "PARSHURAM FINANCE")
                {
                    Session["PPaymentMethod"] = PaymentMethod2 = "Parshuram";
                }
                else
                {
                   Session["PPaymentMethod"] =  PaymentMethod2 = "NP";
                }

                PrintPdfDropDownList.Items.Clear();
                //string ContType1 = DropDownList40.SelectedItem.Text;
                DataSet ds21 = Queries2.LoadPrintFiles3(conttype, (string)Session["Pofficeo"], (string)Session["globContClub"], PaymentMethod2, affil2, financeCurr, resort);
                PrintPdfDropDownList.DataSource = ds21;
                PrintPdfDropDownList.DataTextField = "Printpdf_name";
                PrintPdfDropDownList.DataValueField = "Printpdf_name";
                PrintPdfDropDownList.AppendDataBoundItems = true;
                PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                PrintPdfDropDownList.DataBind();
            }
            else
            {
               PrintPdfDropDownList.Items.Clear();
                 //string ContType1 = DropDownList40.SelectedItem.Text;
                DataSet ds21 = Queries2.LoadPrintFiles2(conttype, Session["Pofficeo"].ToString(), (string)Session["globContClub"], PaymentMethod2, affil2, CrownCurr, resort, Session["Cooloff"].ToString(), Session["PFinaCurrency"].ToString());
                PrintPdfDropDownList.DataSource = ds21;
                PrintPdfDropDownList.DataTextField = "Printpdf_name";
                PrintPdfDropDownList.DataValueField = "Printpdf_name";
                PrintPdfDropDownList.AppendDataBoundItems = true;
                PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                PrintPdfDropDownList.DataBind();

            }

        }

        }

    protected void Button5_Click(object sender, EventArgs e)
    {
        var printr = PrintPdfTextBox2.Text; //PrintPdfDropDownList.SelectedItem.Text;

        //string msg = Server.MapPath("~/reports/" + printr + ".rpt");
        //MessageBox.Show("Error while creating profile " + ex.Message);
        //string msg = "Details updated for Profile :" + " " + profile;
        // Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

        DataTable datatable = Queries2.loadreport((string)Session["GenContNumbglob"] , printr, (string)Session["Pofficeo"] );

        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report


        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
        crystalReport.SetDataSource(datatable);

        System.IO.FileStream fs = null;
        long FileSize = 0;
        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
        //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        oDest.DiskFileName = ExportFileName;
        crystalReport.ExportOptions.DestinationOptions = oDest;
        crystalReport.Export();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Type", "application/pdf");
        string fn = printr + ".pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

        fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
        FileSize = fs.Length;
        byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
        fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
        fs.Close();
        Response.BinaryWrite(bBuffer);
        Response.Flush();
	crystalReport.Close();
        crystalReport.Dispose();
        // Response.Close();
    }



    public class PrintPdfType
    {
        public string PrintPdfTypeID { get; set; }
        public string PrintPdfTypeName { get; set; }
        // public string P1Conttype { get; set; }
    }


    [WebMethod]
    public static string PrintPdfTypeDropDownList(string Lang)
    {
        //string conttype2 = globalclass.contracttype;

 string coolonoff = "";
        string P1Conttype = HttpContext.Current.Session["PConttype"].ToString();
        string P1officeo = "";// HttpContext.Current.Session["Pofficeo"].ToString();
        string P1GlobContClub = HttpContext.Current.Session["PGlobContClub"].ToString();
        string P1PaymentMethod = HttpContext.Current.Session["PPaymentMethod"].ToString();
        string P1Affil = HttpContext.Current.Session["PAffil"].ToString();
        string P1CrownCurr = HttpContext.Current.Session["PCrownCurr"].ToString();
        string P1resort = HttpContext.Current.Session["Presort"].ToString();
string P1Finacurrency = HttpContext.Current.Session["PFinaCurrency"].ToString();
        string cooloff = HttpContext.Current.Session["Cooloff"].ToString();
        /* Session["Pofficeo"] = officeo;
         Session["PGlobContClub"] = GlobContClub;
         Session["PPaymentMethod"] = PaymentMethod2;
         Session["PAffil"] = affil2;
         Session["PCrownCurr"] = CrownCurr;*/



if (HttpContext.Current.Session["Pofficeo"].ToString() == "GER" || HttpContext.Current.Session["Pofficeo"].ToString() == "GRE" || HttpContext.Current.Session["Pofficeo"].ToString() == "FRA" || HttpContext.Current.Session["Pofficeo"].ToString() == "ITA" || HttpContext.Current.Session["Pofficeo"].ToString() == "IRE")
        {
            if (cooloff == "1")
            {
                P1officeo = "GER";
                coolonoff = "1";

            }
            else
            {
                P1officeo = "GER";
                coolonoff = "";
            }
        }
        else
        {
            coolonoff = "";
            P1officeo = HttpContext.Current.Session["Pofficeo"].ToString();
        }






        DataTable dt = new DataTable();
        List<PrintPdfType> listRes = new List<PrintPdfType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            if (P1Finacurrency != "INR")
            {
                using (SqlCommand cmd = new SqlCommand("select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr= '" + P1CrownCurr + "' and  Printpdf_Lang='" + Lang + "'  and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='' and Printpdf_Fina_Curr= '" + P1Finacurrency + "' and  Printpdf_Lang='" + Lang + "'  and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "'", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            /*objRes.Add(new resort
                            {
                                //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                                ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                            });*/

                            PrintPdfType objst2 = new PrintPdfType();

                            //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                            objst2.PrintPdfTypeName = Convert.ToString(dt.Rows[i]["Printpdf_name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id  and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='' and Printpdf_Fina='' and Printpdf_Fina_Curr='INR' and Printpdf_FracMem='" + P1resort + "' and  Printpdf_Lang='" + Lang + "' union select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id  and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='INR' and Printpdf_FracMem='" + P1resort + "' and  Printpdf_Lang='" + Lang + "' ", con))
                //using (SqlCommand cmd = new SqlCommand("select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' union select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr= '" + P1CrownCurr + "' and  Printpdf_Lang='" + Lang + "'  and  Printpdf_FracMem='" + P1resort + "'", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            /*objRes.Add(new resort
                            {
                                //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                                ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                            });*/

                            PrintPdfType objst2 = new PrintPdfType();

                            //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                            objst2.PrintPdfTypeName = Convert.ToString(dt.Rows[i]["Printpdf_name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }



            }
        }
    }



}