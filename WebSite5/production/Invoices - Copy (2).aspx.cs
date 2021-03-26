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
        string query0 = "select * from MemberData_MC_Invoices where [Status]='Active'";
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

                string queryupdate = "update MemberData_MC_Invoices set Status='Inactive' where MemberNo='" + memberNo + "'";
                SqlCommand cmd4 = new SqlCommand(queryupdate, sqlcon1);
                cmd4.ExecuteNonQuery();


                string invoiceNumber = "";
                string transCode = "";
                int Year;
                var data = "";
                data = "<body><h4> Name: " + ownerName + " </h4><h4> Member No: " + memberNo + " </h4><h4> Currency: INR Invoice </h4>";

                SqlConnection sqlcon3 = new SqlConnection(conn);
                sqlcon3.Open();
                string query3 = "delete from Invoice_Year insert into Invoice_Year select distinct YEAR(ccf.fina_date) from cume_curr_prim_ownr ccpo join cume_curr_fina  ccf on ccf.Fina_Mem_Numb= ccpo.Prim_Ownr_Mem_Numb  left join cume_curr_fina_paid ccfp on ccf.Fina_Inv_Numb=ccfp.Fina_Paid_Txn_Invoice left join CuMe_Curr_Pment ccp on ccp.Pment_Txn_Numb=ccfp.Fina_Paid_Txn_Payment where ccpo.Prim_Ownr_Black_List='ST001' and ccpo.Prim_Ownr_Serv_Off='HML' and  ccf.Fina_Acc_Type ='AC001' and ccf.Fina_Curr_Code='INR'  and ccpo.Prim_Ownr_Mem_Numb ='" + memberNo + "' and ccf.Fina_Club_Code in('RGCEB','RGC','RGBC','RTIHC','REGAL','RCVC','RYSTER','RCC','AIHC') select * from invoice_Year";
                SqlCommand cmd3 = new SqlCommand(query3, sqlcon3);
                SqlDataReader reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {

                    Year = reader3.GetInt32(1);

                    data += ""
                        + "<h4>Year: " + Year + "</h4>"
                        + "<table style='border: 1px solid Black; border-collapse: collapse;'><thead><tr><th style='border: 1px solid Black; border-collapse: collapse;'>No.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Date.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Invoice No.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Description.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Bill No.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Net Charge.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Tax.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Gross.</th></tr></thead><tbody>";
                    string query1 = "declare @FinalTable as table (Prim_Ownr_Mem_Numb varchar(50),Name varchar(150),Fina_Inv_Numb varchar(150),Fina_Paid_Txn_Payment varchar(150),Fina_Amt float,Fina_Tax_Amount float,Fina_Amt_Paid float,fina_date datetime,fina_info varchar(200),Fina_Paid_Amt float,Fina_Paid_Tax_Amt float,Pment_Acc_Date datetime,Pment_Pay_Type varchar(60),Pment_Info varchar(300),Pment_Status varchar(50),Pment_Authoriz varchar(100),Fina_Club_Code varchar(40),[Invoice_Month] int,[Invoice_Year] int) insert into @FinalTable select distinct ccpo.Prim_Ownr_Mem_Numb,ccpo.Prim_Ownr_Gname+' '+ccpo.Prim_Ownr_Sname as Name,ccf.Fina_Inv_Numb,isnull(ccfp.Fina_Paid_Txn_Payment,'')Fina_Paid_Txn_Payment,ccf.Fina_Amt,ccf.Fina_Tax_Amount,ccf.Fina_Amt_Paid,convert(varchar,ccf.fina_date,106) [Invoice Date], ccf.fina_info [transaction Code],ccfp.Fina_Paid_Amt,ccfp.Fina_Paid_Tax_Amt,convert(varchar,isnull(ccp.Pment_Acc_Date,''),106) [Payment Date],isnull(ccp.Pment_Pay_Type,'') [Payment Mode],isnull(ccp.Pment_Info,'') Pment_Info,isnull(ccp.Pment_Status,''),isnull(ccp.Pment_Authoriz,'')Pment_Authoriz,isnull(ccf.Fina_Club_Code,'')Fina_Club_Code,MONTH(ccf.fina_date),YEAR(ccf.fina_date) from cume_curr_prim_ownr ccpo join cume_curr_fina  ccf on ccf.Fina_Mem_Numb= ccpo.Prim_Ownr_Mem_Numb  left join cume_curr_fina_paid ccfp on ccf.Fina_Inv_Numb=ccfp.Fina_Paid_Txn_Invoice left join CuMe_Curr_Pment ccp on ccp.Pment_Txn_Numb=ccfp.Fina_Paid_Txn_Payment where ccpo.Prim_Ownr_Black_List='ST001' and ccpo.Prim_Ownr_Serv_Off='HML' and  ccf.Fina_Acc_Type ='AC001' and ccf.Fina_Curr_Code='INR' and ccpo.Prim_Ownr_Mem_Numb ='" + memberNo + "' and ccf.Fina_Club_Code in('RGCEB','RGC','RGBC','RTIHC','REGAL','RCVC','RYSTER','RCC','AIHC') order by ccpo.Prim_Ownr_Mem_Numb declare @InvoiceTable as table (memberNO varchar(50),Name varchar(150),InvoiceNo varchar(100),Invoice_Amount float,Invoice_Tax float,Invoice_Total_Amount float,InvoiceDate varchar(50),[Description] varchar(200),fina_date datetime,ClubCode varchar(40),[Invoice_Month] int,[Invoice_Year] int  ) insert into @InvoiceTable SELECT distinct FT.Prim_Ownr_Mem_Numb,FT.Name,FT.Fina_Inv_Numb,FT.Fina_Amt,FT.Fina_Tax_Amount,FT.Fina_Amt_Paid,convert(varchar,FT.fina_date,106) [Invoice Date], FT.fina_info [transaction Code],FT.fina_date,FT.Fina_Club_Code,FT.Invoice_Month,FT.Invoice_Year FROM @FinalTable FT WHERE FT.Pment_Status in('CLRD','') and (FT.Fina_Paid_Txn_Payment like '%p' or FT.Fina_Paid_Txn_Payment not like '%p' ) or  (FT.Fina_Amt < 0  or FT.Fina_Paid_Txn_Payment ='') select * from @InvoiceTable IT where IT.Invoice_Year='" + Year + "' order by IT.Invoice_Year, IT.Invoice_Month";
                    SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.HasRows)
                    {

                    
                    int i = 1;
                    while (reader1.Read())
                    {

                        invoiceNumber = reader1.GetString(2);
                        double amount = reader1.GetDouble(3);
                        double tax = reader1.GetDouble(4);
                        double gross = reader1.GetDouble(5);
                        string invoiceDate = reader1.GetString(6);
                        transCode = reader1.GetString(7);
                        int year = reader1.GetInt32(11);



                        data += ""
                         + "<tr><td style='border: 1px solid Black; border-collapse: collapse;'>" + i + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + invoiceDate + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + invoiceNumber + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + transCode + "</td><td style='border: 1px solid Black; border-collapse: collapse;'></td><td style='border: 1px solid Black; border-collapse: collapse;'>" + amount + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + tax + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + gross + "</td></tr>";
                        i++;
                            

                    }
                       

                    }

                    data += "</tbody></table><br>";
                    data += ""
                         + "<table style='border: 1px solid Black; border-collapse: collapse;'><thead><tr><th style='border: 1px solid Black; border-collapse: collapse;'>No.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Clear Date.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Invoice No.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Receipt No.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Payment Type.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Description.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Bill No.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Net Charge.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Tax.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Gross.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Comments.</th><th style='border: 1px solid Black; border-collapse: collapse;'>Club Code.</th></tr></thead><tbody>";

                    reader1.Close();

                    int j = 1;
                    SqlConnection sqlcon2 = new SqlConnection(conn);
                    sqlcon2.Open();
                    string query2 = "select distinct ccpo.Prim_Ownr_Mem_Numb,ccf.Fina_Inv_Numb,ccfp.Fina_Paid_Txn_Payment,ccf.fina_info [transaction Code],cast(ccfp.Fina_Paid_Amt as float),cast(ccfp.Fina_Paid_Tax_Amt as float),cast(ccfp.Fina_Paid_Amt+ccfp.Fina_Paid_Tax_Amt as float) [Total],convert(varchar,ccp.Pment_Acc_Date,106) [Payment Date],ccp.Pment_Pay_Type [Payment Mode],ccp.Pment_Info,ccp.Pment_Status,ccf.Fina_Club_Code,ccp.Pment_Acc_Date,MONTH(ccp.Pment_Acc_Date),YEAR(ccp.Pment_Acc_Date) from cume_curr_prim_ownr ccpo join cume_curr_fina  ccf on ccf.Fina_Mem_Numb= ccpo.Prim_Ownr_Mem_Numb  left join cume_curr_fina_paid ccfp on ccf.Fina_Inv_Numb=ccfp.Fina_Paid_Txn_Invoice left join CuMe_Curr_Pment ccp on ccp.Pment_Txn_Numb=ccfp.Fina_Paid_Txn_Payment where ccpo.Prim_Ownr_Black_List='ST001' and ccpo.Prim_Ownr_Serv_Off='HML' and  ccf.Fina_Acc_Type ='AC001' and ccf.Fina_Curr_Code='INR' and ccpo.Prim_Ownr_Mem_Numb ='" + memberNo + "' and ccf.Fina_Club_Code in('RGCEB','RGC','RGBC','RTIHC','REGAL','RCVC','RYSTER','RCC','AIHC')  and YEAR(ccp.Pment_Acc_Date)='" + Year + "' and ccfp.Fina_Paid_Txn_Payment like '%P' order by ccpo.Prim_Ownr_Mem_Numb,ccp.Pment_Acc_Date";
                    SqlCommand cmd2 = new SqlCommand(query2, sqlcon2);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {

                        while (reader2.Read())
                        {
                          
                            string paymentNumber = reader2.GetString(2);
                            double paymentAmount = reader2.GetDouble(4);
                            double paymentTax = reader2.GetDouble(5);
                            double paymentGross = reader2.GetDouble(6);
                            string clearDate = reader2.GetString(7);
                            string paymentMode = reader2.GetString(8);
                            string comments = reader2.GetString(9);
                            string paymentStatus = reader2.GetString(10);
                            string clubCode = reader2.GetString(11);


                            data += ""
                           + "<tr><td style='border: 1px solid Black; border-collapse: collapse;'>" + j + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + clearDate + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + invoiceNumber + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + paymentNumber + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + paymentMode + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + transCode + "</td><td style='border: 1px solid Black; border-collapse: collapse;'></td><td style='border: 1px solid Black; border-collapse: collapse;'>" + paymentAmount + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + paymentTax + "</td><td style='border: 1px solid Black; border-collapse: collapse;'>" + paymentGross + "</td><td style='border: 1px solid Black;'>" + comments + "</td><td style='border: 1px solid Black;'>" + clubCode + "</td></tr>";
                            j++;
                            
                        }

                    }

                    data += "</tbody></table><br>";

                    reader2.Close();
                    sqlcon2.Close();

                    
                }
                data += "</body>";
                var htmlContent = String.Format(data, DateTime.Now);
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.GeneratePdf(htmlContent, null, "" + memberNo + ".pdf");
                //   htmlToPdf.GeneratePdfFromFile("D:/new/code/WebSite5/production/test.html", null, "export.pdf");


                sqlcon1.Close();
                reader3.Close();
                sqlcon3.Close();

            }



            reader.Close();
            sqlcon.Close();


        }
           


        }


    }
