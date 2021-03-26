using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite5_production_SMSAPI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }





    protected void Button1_Click(object sender, EventArgs e)
    {
       try
        {
            string contractNumber = contractNo.Text;
            string name = customerName.Text;
            string messages = message.Text;
            string number = phone.Text;

            WebRequest putwebReq = (HttpWebRequest)WebRequest.Create("http://api.msg91.com/api/v5/flows/5f69a18cd88dc038805b6795");
            putwebReq.Headers.Add("authkey", "342399A11luumXbcD5f6998b4P1");
            // postwebReq.Headers.Add("Content-Type", "application/json");
            putwebReq.Method = "PUT";
            putwebReq.ContentType = "application/json";
            string putData = "{ \"sender_id\" : \""+"KARMAS"+"\",\"flow_name\" : \""+"DEMO"+"\",\"receiver\" : \""+"##mobiles##"+"\",\"message\" : \""+ messages+ "\"}";
            using (var streamWriter = new StreamWriter(putwebReq.GetRequestStream()))
            {
                streamWriter.Write(putData);
                streamWriter.Flush();
                streamWriter.Close();
                var httpResponse = (HttpWebResponse)putwebReq.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result2 = streamReader.ReadToEnd();

                    streamReader.Close();
                }


            }
            
            WebRequest postwebReq = (HttpWebRequest)WebRequest.Create("https://api.msg91.com/api/v5/flow/");
            postwebReq.Headers.Add("authkey", "342399A11luumXbcD5f6998b4P1");
           // postwebReq.Headers.Add("Content-Type", "application/json");
            postwebReq.Method = "POST";
            postwebReq.ContentType = "application/json";
            string postData = "{\"flow_id\":\"" + "5f69a18cd88dc038805b6795" + "\",\"sender\":\"" + "KARMAS" + "\",\"recipients\":[{\"mobiles\":\"" + number + "\",\"VAR1\":\"" + "##mobiles##" + "\",\"VAR2\":\"" + "VALUE 2" + "\"}]}";
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
                }


            }
            Label1.Text = "Uploaded";
        }
        catch(Exception ex)
        {
            Label1.Text = "Failed";
        }
   
    }
}