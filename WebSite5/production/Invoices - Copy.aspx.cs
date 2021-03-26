using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite5_production_Invoices : System.Web.UI.Page
{




    protected void Page_Load(object sender, EventArgs e)
    {
        //      HtmlLoadOptions htmloptions = new HtmlLoadOptions();

        //   Document doc = new Document("D:/new/code/WebSite5/production/test.html", htmloptions);

        //  doc.Save("HTML-to-PDF.pdf");

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query0 = "select * from MemberData_MC_Invoices where [status]='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query0, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string memberNo = reader.GetString(1);
                string ownerName = reader.GetString(2);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                sqlcon1.Open();

                string query1 = "select distinct Prim_Ownr_Mem_Numb,Prim_Ownr_Gname+' '+Prim_Ownr_Sname,Fina_Inv_Numb,Fina_Paid_Txn_Payment,convert(varchar,fina_date,106) [Invoice Date], fina_info [transaction Code],cast(Fina_Paid_Amt as float) [Amount], cast(Fina_Paid_Tax_Amt as float) [Tax],cast(Fina_Paid_Tax_Amt+Fina_Paid_Amt as float) [Gross],convert(varchar,Pment_Acc_Date,106) [Payment Date],Pment_Pay_Type [Payment Mode],Pment_Info,isnull(Fina_Cont_Numb,'') as Fina_Cont_Numb,ROW_NUMBER() OVER(ORDER BY fina_date ASC) AS Row#,fina_date from cume_curr_prim_ownr join cume_curr_fina   on Fina_Mem_Numb= Prim_Ownr_Mem_Numb join cume_curr_fina_paid on Fina_Inv_Numb=Fina_Paid_Txn_Invoice join CuMe_Curr_Pment on Pment_Txn_Numb=Fina_Paid_Txn_Payment where Prim_Ownr_Black_List='ST001' and Prim_Ownr_Serv_Off='HML' and  Fina_Acc_Type ='AC001' and Fina_Curr_Code='INR'  and  Pment_Status <> 'DECLIN' and  Pment_Authoriz NOT LIKE '%declin%' and Prim_Ownr_Mem_Numb ='" + memberNo+"' order by Prim_Ownr_Mem_Numb,fina_date";
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                var data = "<body><h4> Name: " + ownerName + " </h4><h4> Member No: " + memberNo + " </h4><h4> Currency: INR Invoice </h4>";
                int i = 1;
                while (reader1.Read())
                {
                    
                    string invoiceNumber = reader1.GetString(2);
                    string receiptNumber= reader1.GetString(3);
                    string invoiceDate = reader1.GetString(4);
                    string transCode = reader1.GetString(5);
                    double amount = reader1.GetDouble(6);
                    double tax = reader1.GetDouble(7);
                    double gross = reader1.GetDouble(8);
                    string clearDate = reader1.GetString(9);
                    string paymentMode = reader1.GetString(10);
                    string comments = reader1.GetString(11);
                    string contractNo = reader1.GetString(12);
                  


                    data += ""
                       + "<table style='border: 2px solid Black; border-collapse: collapse;'><thead><tr><th style='border: 2px solid Black; border-collapse: collapse;'>No.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Date.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Invoice No.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Description.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Bill No.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Net Charge.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Tax.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Gross.</th></tr></thead>"
                       + "<tbody><tr><td style='border: 2px solid Black; border-collapse: collapse;'>"+i+"</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + invoiceDate + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + invoiceNumber + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + transCode + "</td><td style='border: 2px solid Black; border-collapse: collapse;'></td><td style='border: 2px solid Black; border-collapse: collapse;'>" + amount + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + tax + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + gross + "</td></tr></tbody></table><br>"
                       + "<table style='border: 2px solid Black; border-collapse: collapse;'><thead><tr><th style='border: 2px solid Black; border-collapse: collapse;'>No.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Clear Date.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Invoice No.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Receipt No.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Payment Type.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Description.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Bill No.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Net Charge.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Tax.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Gross.</th><th style='border: 2px solid Black; border-collapse: collapse;'>Comments.</th></tr></thead>"
                    + "<tbody><tr><td style='border: 2px solid Black; border-collapse: collapse;'>" + i + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + clearDate + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + invoiceNumber + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + receiptNumber + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + paymentMode + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + transCode + "</td><td style='border: 2px solid Black; border-collapse: collapse;'></td><td style='border: 2px solid Black; border-collapse: collapse;'>" + amount + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + tax + "</td><td style='border: 2px solid Black; border-collapse: collapse;'>" + gross + "</td><td style='border: 2px solid Black;'>" + comments + "</td></tr></tbody></table><br>";
                    i++;

                }
               
                reader1.Close();
                sqlcon1.Close();

                data += "</body>";
                var htmlContent = String.Format(data, DateTime.Now);
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.GeneratePdf(htmlContent, null, ""+memberNo+".pdf");
             //   htmlToPdf.GeneratePdfFromFile("D:/new/code/WebSite5/production/test.html", null, "export.pdf");

            }
           


        }
        reader.Close();
        sqlcon.Close();




      

    }
}