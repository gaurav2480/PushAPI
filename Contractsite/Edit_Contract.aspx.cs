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

public partial class Contractsite_Edit_Contract : System.Web.UI.Page
{

    static string  user;
    static string ProfileIDo,fracido;
    static string contFinance;
    static string purchaseservice;
    private string Values;
    static string venuecountryG, venueG, markG;//, GlobContClub="";
    static int i;


    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager, oreception, osubvenue;
    static string oProfile_Primary_ID, oProfile_Primary_Title, oProfile_Primary_Fname, oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID;
    static string oProfile_Secondary_ID, oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB, oProfile_Secondary_Nationality, oProfile_Secondary_Country;
    static string oSub_Profile1_ID, oSub_Profile1_Title, oSub_Profile1_Fname, oSub_Profile1_Lname, oSub_Profile1_DOB, oSub_Profile1_Nationality, oSub_Profile1_Country;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country;
    static string oSub_Profile3_ID, oSub_Profile3_Title, oSub_Profile3_Fname, oSub_Profile3_Lname, oSub_Profile3_DOB, oSub_Profile3_Nationality, oSub_Profile3_Country;
    static string oSub_Profile4_ID, oSub_Profile4_Title, oSub_Profile4_Fname, oSub_Profile4_Lname, oSub_Profile4_DOB, oSub_Profile4_Nationality, oSub_Profile4_Country;
    static string oProfile_Address_ID, oProfile_Address_Line1, oProfile_Address_Line2, oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city, oProfile_Address_Postcode, oProfile_Address_Created_Date, oProfile_Address_Expiry_Date;
    //static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate, oSubprofile3_CC, oSubprofile3_Mobile, oSubprofile3_Alt_CC, oSubprofile3_Alternate, oSubprofile4_CC, oSubprofile4_Mobile, oSubprofile4_Alt_CC, oSubprofile4_Alternate, ohomec, oofficec, ohomenum, oofficenum;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email, oPrimary_Email2, oSecondary_Email2, oSubprofile1_Email2, oSubprofile2_Email2, oSubprofile3_Email, oSubprofile3_Email2, oSubprofile4_Email, oSubprofile4_Email2;
    static string oProfile_Stay_ID, oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID, oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep, oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In, oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price, oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;

    static string oBalance_Pay_Method, oDealDrawer, oCGroupvenueDropDownList, oCReasonDropDownList, oCancelDateTextBox;

   // static string ogiftoptionDropDownList="", ogiftoptionDropDownList2 = "", ogiftoptionDropDownList3 = "", ogiftoptionDropDownList4 = "", ogiftoptionDropDownList5 = "", ogiftoptionDropDownList6 = "", ogiftoptionDropDownList7 = "";
  //  static string ovouchernoTextBox, ovouchernoTextBox2, ovouchernoTextBox3, ovouchernoTextBox4, ovouchernoTextBox5, ovouchernoTextBox6, ovouchernoTextBox7;
  //  static string ogiftprice1, ogiftprice2, ogiftprice3, ogiftprice4, ogiftprice5, ogiftprice6, ogiftprice7;


 //   static string text11,desc,text12,amot1,text13,date,text14,curr, GenContNumbglob, DealRegDate, regTerms, regTerms2,scweekno;

    static string primaryidtype, secondaryidtype, sp1idtype, sp2idtype, sp3idtype, sp4idtype;
    static string primaryidnum, secondaryidnum, sp1idnum, sp2idnum, sp3idnum, sp4idnum, regTerms, regTerms2;
    string sp4fname, sp4lname, sp4dob, tsp4dob, sp4nationality, sp4country;
    string sp3fname, sp3lname, sp3dob, tsp3dob, sp3nationality, sp3country;
    int cweekno,cweekno2, weeknoflag;


    


    protected void Page_Load(object sender, EventArgs e)
    {
        //string user1 = (string)Session["username"];
        //if (user1 == null)
        //{
        //    Response.Redirect("~/WebSite5/production/login.aspx");
        //}

       

        TextBox1.Text = DateTime.Today.ToString("yyyy/MM/dd");

        string user1 = (string)Session["username"];
      // string user1 = "anket";
        // TextBox tb = new TextBox();
         user = user1;

        string contractno = Convert.ToString(Request.QueryString["ContractNo"]);
       //   string contractno = "KRR1/190119/4280KJ";
        //user = "Administrator";
        // officeo = "ivo";

        TextContractNumb.Text = contractno;

       // string office = "THL";//Queries.GetOffice(user);
        //string office = Queries.GetOffice(user);




        string fracid= Queries2.getcontIDfromNo(contractno);

        string dealRegisteredDate= Queries2.getDealRegisteredDate(contractno);

        DealRegisteredDate.Text = dealRegisteredDate;

        string ProfileID = Queries2.getProfileIDfromNo(contractno);
        Session["ProfileID"] = ProfileID;
        string office = Queries2.GetOfficeFromCountry(ProfileID);
        Session["office2"] = office;
       // string office = "IVO";

        Session["fracido"] = "";

        Session["fracido"] = fracid;

        if (office == "IVO")
        {
            TextBoxDummyTax.Text = "0.10";
            TextBoxDummyRate.Text = "2.1";
            TextBoxDummyOffice.Text = "IVO";
        }
        else if (office == "THL")
        {

            DataSet ds4t = Queries2.LoadProfileOnCreation(ProfileID);
        string THLvenue= ds4t.Tables[0].Rows[0]["Profile_Venue"].ToString();
        string THLGroupVenue = ds4t.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();

            if((THLvenue == "Inhouse" && THLGroupVenue== "Karma Apsara") || (THLvenue == "Koh Samui"))
            {
                TextBoxDummyTax.Text = "0";
                TextBoxDummyRate.Text = "1";
                TextBoxDummyOffice.Text = "VTM";
            }
            else
            {
                TextBoxDummyTax.Text = "0.07";
                TextBoxDummyRate.Text = "2.07";
                TextBoxDummyOffice.Text = "THL";

            }
            
        }
        else if (office == "VTM")
        {
            TextBoxDummyTax.Text = "0";
            TextBoxDummyRate.Text = "1";
            TextBoxDummyOffice.Text = "VTM";
        }
        else if (office == "GER" || office == "GRE" || office == "FRA" || office == "ITA" || office == "IRE")
        {
            TextBoxDummyTax.Text = "0";
            TextBoxDummyRate.Text = "1";
            TextBoxDummyOffice.Text = office;
        }

        if (!Page.IsPostBack)
        {



            Session["oAppartmentTypeTPDropDownList"] = ""; Session["oAppartTypeDropDownListTF"] = ""; Session["oContractClubTPDropDownList1"] = ""; Session["oEntitleDropDownListTF1"] = "";
            Session["oEntitleDropDownListTF2"] = ""; Session["oEntitleDropDownListTF3"] = ""; Session["oEntitlementDropDownList1"] = ""; Session["oEntitleTPDropDownList"] = "";
            Session["oFracIntDropDownListTF"] = ""; Session["oNoOccuDropDownListTF"] = ""; Session["oNumbOccuTPDropDownList"] = ""; Session["oOldClubDropDownListTF"] = "";
            Session["oPeriodDropDownListTF"] = ""; Session["oPeriodTPDropDownList"] = ""; Session["oResidenceNoDropDownListTF"] = ""; Session["oResiTypeDropDownListTF"] = "";
            Session["oResortDropDownListTF1"] = ""; Session["oResortDropDownListTF3"] = ""; Session["oResortTPDropDownList"] = ""; Session["oSeasonDropDownListTF"] = "";
            Session["oSeasonTPDropDownList"] = ""; Session["oTextBoxSGST"] = ""; Session["oTextBoxSGST"] = ""; Session["oTextBoxSGST"] = ""; Session["oTextOldAgreeNoTF2"] = "";
            Session["oTextOldNoOfPointsTF"] = ""; Session["oTextOldNoPointsTP"] = ""; Session["oTP_Old_No_Points"] = ""; Session["oAmountCreditCurrTextBoxPFC"] = "";
            Session["oAmountCreditCurrTextBoxPFC"] = ""; Session["oAmountCreditCurrTextBoxPFC"] = ""; Session["oAmountCreditCurrTextBoxPFC"] = ""; Session["oAmountCreditTextBoxPFC"] = "";
            Session["oAmountCreditTextBoxPFC"] = ""; Session["oAmountCreditTextBoxPFC"] = ""; Session["oAmountCreditTextBoxPFC"] = ""; Session["oContract_finance_OddEven50"] = "";
            Session["oContract_finance_OddEven50"] = ""; Session["oContractClubTPDropDownList2"] = ""; Session["oContractVenueVPDropDownList"] = "";
            Session["oContractVenueVPDropDownList"] = ""; Session["oEntitlementTFracDropDownList"] = ""; Session["oEntitlementTPoinDropDownList"] = "";
            Session["oFracIntDropDownListTF1"] = ""; Session["oMonthRepayTextBoxPFC"] = ""; Session["oMonthRepayTextBoxPFC"] = ""; Session["oMonthRepayTextBoxPFC"] = "";
            Session["oMonthRepayTextBoxPFC"] = ""; Session["oNoMonthsTextBoxPFC"] = ""; Session["oNoMonthsTextBoxPFC"] = ""; Session["oNoMonthsTextBoxPFC"] = "";
            Session["oNoMonthsTextBoxPFC"] = ""; Session["oPS_Balloon_Pay"] = ""; Session["oPS_Balloon_Pay"] = ""; Session["oPS_Balloon_Pay"] = ""; Session["oPS_Deposit_Date"] = "";
            Session["oPS_Deposit_Date"] = ""; Session["oPS_Deposit_Date"] = ""; Session["oPS_Ini_Bal_Install"] = ""; Session["oPS_PA_FInstall_Date"] = ""; Session["oPS_PA_FInstall_Date"] = "";
            Session["oQualTextBoxPFC"] = ""; Session["oQualTextBoxPFC"] = ""; Session["oQualTextBoxPFC"] = ""; Session["oQualTextBoxPFC"] = ""; Session["oRateInterestTextBoxPFC"] = "";
            Session["oRateInterestTextBoxPFC"] = ""; Session["oRateInterestTextBoxPFC"] = ""; Session["oRateInterestTextBoxPFC"] = ""; Session["oResidenceTypeDropDownListF"] = "";
            Session["oResiTypeDropDownListTF1"] = ""; Session["oTextAdminFeesP"] = ""; Session["oTextAdminFeesP"] = ""; Session["oTextAdminFeesP"] = ""; Session["oTextAdminFeesP"] = "";
            Session["oTextAdminServiceP"] = ""; Session["oTextAdminServiceP"] = ""; Session["oTextAdmissFeesP"] = ""; Session["oTextAdmissFeesP"] = ""; Session["oTextAdmissFeesP"] = "";
            Session["oTextAdmissFeesP"] = ""; Session["oTextAppliFeesP"] = ""; Session["oTextAppliFeesP"] = ""; Session["oTextBalanceDDatesSAP"] = ""; Session["oTextBalanceDDatesSAP"] = "";
            Session["oTextBalanceDDatesSAP2"] = ""; Session["oTextBalanceDDatesSAP2"] = ""; Session["oTextBalanceDueSAP"] = ""; Session["oTextBalanceDueSAP"] = "";
            Session["oTextBalDepo"] = ""; Session["oTextBalDepo"] = ""; Session["oTextBalDepo"] = ""; Session["oTextBalDepo"] = ""; Session["oTextBoxDDcocuFees"] = "";
            Session["oTextBoxDEMIAmt"] = ""; Session["oTextBoxDFinaMonth"] = ""; Session["oTextBoxDIGSTAmt"] = ""; Session["oTextBoxDIGSTRate"] = ""; Session["oTextBoxDIntRate"] = "";
            Session["oTextBoxDNoEMI"] = ""; Session["oTextBoxDummyleaseoff"] = ""; Session["oTextBoxDummyleaseoff"] = ""; Session["oTextCountryTaxP"] = ""; Session["oTextCountryTaxP"] = "";
            Session["oTextCountryTaxP"] = ""; Session["oTextCountryTaxP"] = ""; Session["oTextDepoPPA"] = ""; Session["oTextDepoPPA"] = ""; Session["oTextDepoPPA"] = "";
            Session["oTextDurationTF"] = ""; Session["oTextDurationTP"] = ""; Session["oTextFDuration"] = ""; Session["oTextFOccuL"] = ""; Session["oTextFYOccTP"] = "";
            Session["oTextFYOccuTF"] = ""; Session["oTextGrandTotalP"] = ""; Session["oTextGrandTotalP"] = ""; Session["oTextGrandTotalP"] = ""; Session["oTextGrandTotalP"] = "";
            Session["oTextIniInstAmtP"] = ""; Session["oTextIniInstAmtP"] = ""; Session["oTextIniInstAmtP"] = ""; Session["oTextIniInstAmtP"] = ""; Session["oTextIniInstP"] = "";
            Session["oTextIniInstP"] = ""; Session["oTextInitDepo"] = ""; Session["oTextInitDepo"] = ""; Session["oTextInitDepo"] = ""; Session["oTextInitDepo"] = "";
            Session["oTextLYOccTP"] = ""; Session["oTextLYOccuTF"] = ""; Session["oTextMemFeesp"] = ""; Session["oTextMemFeesp"] = ""; Session["oTextPBalaceDPA"] = "";
            Session["oTextPBalaceDPA"] = ""; Session["oTextPBalaceDPA"] = ""; Session["oTextPBalaceDPA"] = ""; Session["oTextPBalaceDPATOPD"] = ""; Session["oTextPBalaceDPATOPD"] = "";
            Session["oTextPBalaceDPATOPD"] = ""; Session["oTextPBalaceDPATOPD"] = ""; Session["oTextPBalanceDDates"] = ""; Session["oTextPBalanceDDates"] = "";
            Session["oTextPBalanceDDates"] = ""; Session["oTextPBalanceDDates"] = ""; Session["oTextPBalanceDDates2"] = ""; Session["oTextPBalanceDDates2"] = "";
            Session["oTextPBalanceDDates2"] = ""; Session["oTextPBalanceDDates2"] = ""; Session["oTextPDepositSA"] = ""; Session["oTextPDepositSA"] = ""; Session["oTextPDura"] = "";
            Session["oTextPFOccu"] = ""; Session["oTextPLOccu"] = ""; Session["oTextPnumb"] = ""; Session["oTextPPAAmountInstall"] = ""; Session["oTextPPAAmountInstall"] = "";
            Session["oTextPPAFInstall"] = ""; Session["oTextPPAFInstall"] = ""; Session["oTextPPAFInstall"] = ""; Session["oTextPPAFInstall"] = ""; Session["oTextPPANoInstall"] = "";
            Session["oTextPPANoInstall"] = ""; Session["oTextPPANoInstall"] = ""; Session["oTextPPANoInstall"] = ""; Session["oTextPpurchasePrice"] = ""; Session["oTextPpurchasePrice"] = "";
            Session["oTextPpurchasePrice"] = ""; Session["oTextPpurchasePrice"] = ""; Session["oTextPrimaryCCard2"] = ""; Session["oTextPrimaryCCard2"] = "";
            Session["oTextPrimaryCCard2"] = ""; Session["oTextPrimaryCCard2"] = ""; Session["oTextPropFeesp"] = ""; Session["oTextPropFeesp"] = ""; Session["oTextRemarkP"] = "";
            Session["oTextRemarkP"] = ""; Session["oTextRemarkP"] = ""; Session["oTextRemarkP"] = ""; Session["oTextRemarkP2"] = ""; Session["oTextRemarkP2"] = "";
            Session["oTextRemarkP2"] = ""; Session["oTextRemarkP2"] = ""; Session["oTextTotalBalance"] = ""; Session["oTextTotalBalance"] = ""; Session["oTextTotalBalance"] = "";
            Session["oTextTotalBalance"] = ""; Session["oTextTotalPointsTP"] = ""; Session["oTextTotalServicePriceP"] = ""; Session["oTextTotalServicePriceP"] = "";
            Session["oTotalPurTextBoxPFC"] = ""; Session["oTotalPurTextBoxPFC"] = ""; Session["cweekno"] = ""; Session["DealRegDate"] = ""; Session["oTextCardHNameP"] = "";
            Session["oTextCardNumbP"] = ""; Session["oTextExpMonthP"] = ""; Session["oTextPrimaryCCard"] = ""; Session["oTextPrimaryCCard2"] = ""; Session["oTextSecurityP"] = "";
            Session["scweekno"] = ""; Session["oTextOldAgreeNoTF1"] = ""; Session["oTextNoPoints"] = ""; Session["oTextOldAgreeNoTP2"] = ""; Session["ODeposit"] = "";
            Session["oEntitlementPoinDropDownList"] = ""; Session["oTextBoxCGST"] = ""; Session["Contract_Finance_Cool_End_Dateo"] = ""; Session["oCardPrimaryDropDownList"] = "";
            Session["ButtonUpDropDownListo"] = ""; Session["Contract_Finance_Admin_Feeso"] = ""; Session["Contract_Finance_Cool_OnOffo"] = ""; Session["lastinstalldate"] = "";
            Session["oCGroupvenueDropDownList"] = ""; Session["oContract_finance_OddEven50"] = ""; Session["oContractVenueVPDropDownList"] = ""; Session["oCReasonDropDownList"] = "";
            Session["oCrownFinanceCurrDropDownList"] = ""; Session["ODeposit"] = ""; Session["oFractionalIDropDownListF"] = ""; Session["oPS_PA_FInstall_Date"] = "";
            Session["oTextBoxCGST"] = ""; Session["oTextBoxCGST"] = ""; Session["oTextDepoPPA"] = ""; Session["oTextOldAgreeNoTF3"] = ""; Session["oTextPPAAmountInstall"] = "";
            Session["oTotalPurTextBoxPFC"] = ""; Session["ousepayprotect"] = ""; Session["Contract_Finance_Affil_ICEo"] = ""; Session["Contract_Finance_Cool_Start_Dateo"] = "";
            Session["Contract_Finance_MC_Feeso"] = ""; Session["Contract_Finance_Purchase_Priceo"] = ""; Session["contsalesrepDropDownListo"] = ""; Session["DealDrawerDropDownListo"] = "";
            Session["exrate"] = ""; Session["oBalance_Pay_Method"] = ""; Session["obalancepaymethod"] = ""; Session["oCancelDateTextBox"] = ""; Session["oCGroupvenueDropDownList"] = "";
            Session["oContract_finance_OddEven50"] = ""; Session["oContractNoFractTextBox"] = ""; Session["oContractVenueVPDropDownList"] = ""; Session["oCReasonDropDownList"] = "";
            Session["oDealDrawer"] = ""; Session["ODeposit"] = ""; Session["ODeposit"] = ""; Session["oDPMFractDropDownList"] = ""; Session["oFractionalIDropDownListF"] = "";
            Session["oPayMethodDropDownList"] = ""; Session["oPS_Balloon_Pay"] = ""; Session["oPS_PA_FInstall_Date"] = ""; Session["oResidenceNoDropDownListF"] = ""; Session["oResidenceNoDropDownListTF1"] = "";
            Session["oResortDropDownListF"] = ""; Session["oTextBoxDPrincipalAmt"] = ""; Session["oTextFOccuF"] = ""; Session["oTextIniInstP"] = ""; Session["oTextIniInstP"] = "";
            Session["oTextIssuingP"] = ""; Session["oTextNewPointsTP"] = ""; Session["oTextOldAgreeNoTP1"] = ""; Session["oTextPayMethodDetails"] = ""; Session["oTextPnumb"] = "";
            Session["oTextPPAAmountInstall"] = ""; Session["oTotalPurTextBoxPFC"] = ""; Session["oYearOfIntDropDownList"] = ""; Session["TOManagerDropDownListo"] = "";
            Session["oEntitlementFracDropDownList"] = ""; Session["oPS_TP_Comment"] = ""; Session["oPS_Deposit_Comment"] = "";
            Session["oPS_Deposit_USD"] = "";
            Session["oPS_Country_Tax_USD"] = "";
            Session["oContract_Finance_Purchase_Price_USD"] = "";
            Session["oContract_Finance_Admin_Fees_USD"] = ""; Session["oSC_Withdraw_Date"] = "";







            Session["DealRegDate"] = "";
            Session["regTerms"] = "";
            Session["ProfileIDo"] = "";
            Session["regTerms2"] = "";
            Session["scweekno"] = "";
            Session["cweekno"] = "";

            DataSet ds4 = Queries2.LoadProfileOnCreation(ProfileID);
            DataSet dsT = Queries2.LoadTaxiprice(ProfileID);

            ProfileIDTextBox.Text = ds4.Tables[0].Rows[0]["Profile_ID"].ToString();
            Session["ProfileIDo"] = ProfileIDTextBox.Text;
            TextBox1.Text = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Date_Of_Insertion"]);

            CreatedByTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Created_By"].ToString();

            DataSet recep = Queries2.LoadRecept();

            ReceptionistDropDownList.DataSource = recep;
            ReceptionistDropDownList.DataTextField = "name";
            ReceptionistDropDownList.DataValueField = "Recep_ID";
            ReceptionistDropDownList.AppendDataBoundItems = true;
            ReceptionistDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Reception"].ToString(), ""));
            ReceptionistDropDownList.DataBind();

            Session["ReceptionistDropDownList"] = ds4.Tables[0].Rows[0]["Reception"].ToString();


            primarytitleDropDownList.DataSource = ds4;
            primarytitleDropDownList.DataTextField = "Profile_Primary_Title";
            primarytitleDropDownList.DataValueField = "Profile_Primary_Title";
            primarytitleDropDownList.DataBind();
            pfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();

            //primarynationalityDropDownList.DataSource = ds4;
            //primarynationalityDropDownList.DataTextField = "Profile_Primary_Nationality";
            //primarynationalityDropDownList.DataValueField = "Profile_Primary_Nationality";
            //primarynationalityDropDownList.DataBind();

            DataSet primanat = Queries2.LoadNationalityWithoutPrevValPrimary(ProfileID);
            primarynationalityDropDownList.DataSource = primanat;
            primarynationalityDropDownList.DataTextField = "nationality_name";
            primarynationalityDropDownList.DataValueField = "nationality_name";
            primarynationalityDropDownList.AppendDataBoundItems = true;
            primarynationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
            primarynationalityDropDownList.DataBind();


            //PrimaryCountryDropDownList.Items.Clear();
            DataSet ds28 = Queries2.LoadCountryName();

            PrimaryCountryDropDownList.DataSource = ds28;
            PrimaryCountryDropDownList.DataTextField = "country_name";
            PrimaryCountryDropDownList.DataValueField = "country_name";
            PrimaryCountryDropDownList.AppendDataBoundItems = true;
            PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            PrimaryCountryDropDownList.DataBind();


            string primcount = ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();

            string vencountry = Queries2.GetVenueCountryCode(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString());

            Session["venueCountry"] = "";
            Session["venueCountry"] = ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();


            //VenueCountryDropDownList.Items.Clear();
            DataSet ds8 = Queries2.LoadVenueCountry1(ProfileID,office);

            VenueCountryDropDownList.DataSource = ds8;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            //VenueDropDownList.Items.Clear();
            DataSet ds24 = Queries2.LoadVenue(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ds4.Tables[0].Rows[0]["Profile_Venue"].ToString());
            VenueDropDownList.DataSource = ds24;
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            //string venuecode = Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, vencountry);
            //VenueDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Venue"].ToString());



            GroupVenueDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString());
            MarketingPrgmDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());
            AgentsDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString());
            //AgentCodeDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString());


            string VenueDropDownListval = ds4.Tables[0].Rows[0]["Profile_Venue"].ToString();

            string GroupVenueDropDownListval = ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();

		 if (GroupVenueDropDownListval == "Coldline" || GroupVenueDropDownListval == "COLDLINE")
            {
                sourcecodetext.Text = ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();

            }
            else
            {
                AgentCodeDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString());
            }
            //string subvenue1 = ds4.Tables[0].Rows[0]["SubVenue"].ToString();

            //DataSet loadven = Queries2.LoadSubVenue(VenueDropDownListval, subvenue1);
            ////VenueDropDownList.DataSource = ds24; 
            //VenueDropDownList2.DataSource = loadven;
            //VenueDropDownList2.DataTextField = "SVenue_Name";
            //VenueDropDownList2.DataValueField = "SVenue_Name";
            //VenueDropDownList2.AppendDataBoundItems = true;
            ////VenueCountryDropDownList.Items.Insert(0,"", ""));
            //VenueDropDownList2.Items.Insert(0, new ListItem(subvenue1, ""));
            //VenueDropDownList2.DataBind();

            VenueDropDownList2.Items.Add(ds4.Tables[0].Rows[0]["SubVenue"].ToString());
            string subvenue1 = ds4.Tables[0].Rows[0]["SubVenue"].ToString();
            //GroupVenueDropDownList.Items.Clear();
            //DataSet ds25 = Queries.LoadVenueGroup(venuecode);
            //GroupVenueDropDownList.DataSource = ds25;
            //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            //GroupVenueDropDownList.AppendDataBoundItems = true;
            //GroupVenueDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            //GroupVenueDropDownList.DataBind();

            //string Groupvenuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);

            //MarketingPrgmDropDownList.Items.Clear();
            //DataSet ds26 = Queries.LoadMarketingProgram(Groupvenuecode);
            //MarketingPrgmDropDownList.DataSource = ds26;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            //string MarketingPCode = Queries2.getMarketingProgram(MarketingPrgmDropDownList.SelectedItem.Text, Groupvenuecode);
            //MarketingPrgmDropDownList.Items.Clear();
            //MarketingPrgmDropDownList.DataSource = ds26;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            //AgentsDropDownList.Items.Clear();
            //DataSet ds27 = Queries2.LoadAgentsIVO(MarketingPrgmDropDownList.SelectedItem.Text);
            //AgentsDropDownList.DataSource = ds27;
            //AgentsDropDownList.DataTextField = "Agent_Name";
            //AgentsDropDownList.DataValueField = "Agent_Name";
            //AgentsDropDownList.AppendDataBoundItems = true;
            //AgentsDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
            //AgentsDropDownList.DataBind();

            /*DataSet ds27 = Queries.LoadAgentsIVO(MarketingProgramDropDownList.SelectedItem.Text);
            AgentNameDropDownList.DataSource = ds27;
            AgentNameDropDownList.DataTextField = "Agent_Name";
            AgentNameDropDownList.DataValueField = "Agent_Name";
            AgentNameDropDownList.AppendDataBoundItems = true;
            AgentNameDropDownList.Items.Insert(0, new ListItem("", ""));
            AgentNameDropDownList.DataBind();*/

            Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();

            Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();





           // contsalesrepDropDownList.Items.Clear();
         

            /* secondarytitleDropDownList.DataSource = ds4;
             secondarytitleDropDownList.DataTextField = "Profile_Secondary_Title";
             secondarytitleDropDownList.DataValueField = "Profile_Secondary_Title";
             secondarytitleDropDownList.DataBind();

             Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
             Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();

             pfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
             plnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();



             sfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
             slnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();

             secondarynationalityDropDownList.DataSource = ds4;
             secondarynationalityDropDownList.DataTextField = "Profile_Secondary_Nationality";
             secondarynationalityDropDownList.DataValueField = "Profile_Secondary_Nationality";
             secondarynationalityDropDownList.DataBind();

            // SecCountryDropDownList.DataSource = ds4;
            // SecCountryDropDownList.DataTextField = "Profile_Primary_Country";
            // SecCountryDropDownList.DataValueField = "Profile_Primary_Country";
           //  SecCountryDropDownList.DataBind();

             pmobileTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Mobile"].ToString();
             pemailTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Email"].ToString();
             employmentstatusDropDownList.DataSource = ds4;
             employmentstatusDropDownList.DataTextField = "Profile_Employment_status";
             employmentstatusDropDownList.DataValueField = "Profile_Employment_status";
             employmentstatusDropDownList.DataBind();

             MaritalStatusDropDownList.DataSource = ds4;
             MaritalStatusDropDownList.DataTextField = "Profile_Marital_status";
             MaritalStatusDropDownList.DataValueField = "Profile_Marital_status";
             MaritalStatusDropDownList.DataBind();

             datepicker1.Text = ds4.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString();

             hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();*/

            //string datear = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd"); ; 
            // datepicker5.Text = DateTime.datear.ToString();
            // datepicker5.Text
            //Response.Write(datear);
            //DateTime dae = DateTime.ParseExact(datear, "yyyy/MM/dd", null);
            //datepicker5.Text = datear;

            //AgentCodeDropDownList.Items.Clear();
            //DataSet ds29 = Queries.LoadProfileAgentCode(ProfileID);
            //AgentCodeDropDownList.DataSource = ds29;
            //AgentCodeDropDownList.DataTextField = "Agent_Code_Name";
            //AgentCodeDropDownList.DataValueField = "Agent_Code_Name";
            //AgentCodeDropDownList.AppendDataBoundItems = true;
            //AgentCodeDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //AgentCodeDropDownList.DataBind();

            MemType1DropDownList.Items.Clear();
            DataSet ds30 = Queries.LoadMemberType();
            MemType1DropDownList.DataSource = ds30;
            MemType1DropDownList.DataTextField = "Member_Type_name";
            MemType1DropDownList.DataValueField = "Member_Type_name";
            MemType1DropDownList.AppendDataBoundItems = true;
            MemType1DropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
            MemType1DropDownList.DataBind();

            MemType2DropDownList.Items.Clear();
            DataSet ds31 = Queries.LoadMemberType();
            MemType2DropDownList.DataSource = ds31;
            MemType2DropDownList.DataTextField = "Member_Type_name";
            MemType2DropDownList.DataValueField = "Member_Type_name";
            MemType2DropDownList.AppendDataBoundItems = true;
            MemType2DropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Member_Type2"].ToString(), ""));
            MemType2DropDownList.DataBind();

            Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
            //   MemType2DropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
            Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();

            //employmentstatusDropDownList.Items.Clear();
            //employmentstatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Employment_status"].ToString());
            //employmentstatusDropDownList.Items.Add("Employee");
            //employmentstatusDropDownList.Items.Add("Worker");
            //employmentstatusDropDownList.Items.Add("Self Employed");
            //employmentstatusDropDownList.Items.Add("Director");
            //employmentstatusDropDownList.Items.Add("Office Holder");
            //employmentstatusDropDownList.Items.Add("Unemployed");

            DataSet dsemploy = Queries.LoadEmploymentStatus();
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();


            DataSet Secondemploy = Queries.LoadEmploymentStatus();
            SecondemploymentstatusDropDownList.DataSource = Secondemploy;
            SecondemploymentstatusDropDownList.DataTextField = "Name";
            SecondemploymentstatusDropDownList.DataValueField = "Name";
            SecondemploymentstatusDropDownList.AppendDataBoundItems = true;
            SecondemploymentstatusDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_Employment_Status"].ToString(), ""));
            SecondemploymentstatusDropDownList.DataBind();


            //MaritalStatusDropDownList.Items.Clear();
            //MaritalStatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Marital_status"].ToString());
            //MaritalStatusDropDownList.Items.Add("Single");
            //MaritalStatusDropDownList.Items.Add("Married");
            //MaritalStatusDropDownList.Items.Add("Divorced");
            //MaritalStatusDropDownList.Items.Add("Just Friend");
            //MaritalStatusDropDownList.Items.Add("Female Couple");
            //MaritalStatusDropDownList.Items.Add("Male Couple");
            //MaritalStatusDropDownList.Items.Add("Living Together as couple");

            DataSet dsmart = Queries.LoadMaritalStatus();
            MaritalStatusDropDownList.DataSource = dsmart;
            MaritalStatusDropDownList.DataTextField = "MaritalStatus";
            MaritalStatusDropDownList.DataValueField = "MaritalStatus";
            MaritalStatusDropDownList.AppendDataBoundItems = true;
            MaritalStatusDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            MaritalStatusDropDownList.DataBind();

            livingyrsTextBox.Text = ds4.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

            //primarytitleDropDownList.Items.Clear();
            //primarytitleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            //primarytitleDropDownList.Items.Add("Mr");
            //primarytitleDropDownList.Items.Add("Ms");
            //primarytitleDropDownList.Items.Add("Mrs");
            //primarytitleDropDownList.Items.Add("Adv");
            //primarytitleDropDownList.Items.Add("Dr");


            DataSet dsptitle = Queries2.LoadSalutations(office);
            primarytitleDropDownList.DataSource = dsptitle;
            primarytitleDropDownList.DataTextField = "Salutation";
            primarytitleDropDownList.DataValueField = "Salutation";
            primarytitleDropDownList.AppendDataBoundItems = true;
            primarytitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            primarytitleDropDownList.DataBind();

            //DataSet ds32 = Queries.LoadCountryPrimary(ProfileID);
            //PrimaryCountryDropDownList.DataSource = ds32;
            //PrimaryCountryDropDownList.DataTextField = "country_name";
            //PrimaryCountryDropDownList.DataValueField = "country_name";
            //PrimaryCountryDropDownList.AppendDataBoundItems = true;
            //PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            //PrimaryCountryDropDownList.DataBind();


            DataSet ds33 = Queries2.LoadCountryWithCodePrimaryMobile("");
            primarymobileDropDownList.DataSource = ds33;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();

             Session["oPrimary_CC"] = "";
            Session["oPrimary_CC"] = ds4.Tables[0].Rows[0]["Primary_CC"].ToString();

            string ll = ds4.Tables[0].Rows[0]["Primary_CC"].ToString();
            Session["oPrimary_CC"] = ll;



            DataSet ds34 = Queries2.LoadCountryWithCodePrimaryAlt("");
            primaryalternateDropDownList.DataSource = ds34;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();

            Session["oPrimary_Alt_CC"] = ds4.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();

            DataSet dsHomeC = Queries2.LoadCountryWithCodePrimaryAlt("");
            HomeCodeDropDownList.DataSource = dsHomeC;
            HomeCodeDropDownList.DataTextField = "name";
            HomeCodeDropDownList.DataValueField = "name";
            HomeCodeDropDownList.AppendDataBoundItems = true;
            HomeCodeDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_office_cc"].ToString(), ""));
            HomeCodeDropDownList.DataBind();

            
             Session["ohomec"] = ds4.Tables[0].Rows[0]["Secondary_office_cc"].ToString();


            DataSet dsOfficeC = Queries2.LoadCountryWithCodePrimaryAlt("");
            OfficeCodeDropDownList.DataSource = dsOfficeC;
            OfficeCodeDropDownList.DataTextField = "name";
            OfficeCodeDropDownList.DataValueField = "name";
            OfficeCodeDropDownList.AppendDataBoundItems = true;
            OfficeCodeDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_office_cc"].ToString(), ""));
            OfficeCodeDropDownList.DataBind();

            Session["oofficec"] = ds4.Tables[0].Rows[0]["Primary_office_cc"].ToString();


            pmobileTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            palternateTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            pemailTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Email"].ToString();
            pemailTextBox2.Text = ds4.Tables[0].Rows[0]["Primary_Email2"].ToString();

            HomeNumTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_office_num"].ToString();
            OfficeNumTextBox.Text = ds4.Tables[0].Rows[0]["Primary_office_num"].ToString();

            //secondary profile

            DataSet dsstitle = Queries2.LoadSalutations(office);
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();



            sfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();


            string datep1 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Primary_DOB"]);

            if (datep1 == "" || datep1 == "01-01-1900")
            {
                datepicker1.Text = "";
            }
            else
            {
                datepicker1.Text = datep1;
            }



            string datep2 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Secondary_DOB"]);

            if (datep2 == "" || datep2 == "01-01-1900")
            {
                datepicker2.Text = "";
            }
            else
            {
                datepicker2.Text = datep2;
            }

            DataSet seconnat = Queries2.LoadNationalityWithoutPrevValSecondary(ProfileID);
            secondarynationalityDropDownList.DataSource = seconnat;
            secondarynationalityDropDownList.DataTextField = "nationality_name";
            secondarynationalityDropDownList.DataValueField = "nationality_name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString(), ""));
            secondarynationalityDropDownList.DataBind();
            //secondarynationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString());


            DataSet ds35 = Queries.LoadCountrySecondary("");
            SecondaryCountryDropDownList.DataSource = ds35;
            SecondaryCountryDropDownList.DataTextField = "country_name";
            SecondaryCountryDropDownList.DataValueField = "country_name";
            SecondaryCountryDropDownList.AppendDataBoundItems = true;
            SecondaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString(), ""));
            SecondaryCountryDropDownList.DataBind();
            DataSet ds36 = Queries2.LoadCountryWithCodeSecondaryMobile("");
            secondarymobileDropDownList.DataSource = ds36;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();


            Session["oSecondary_CC"] = ds4.Tables[0].Rows[0]["Secondary_CC"].ToString();


            DataSet ds37 = Queries2.LoadCountryWithCodeSecondaryAlt("");
            secondaryalternateDropDownList.DataSource = ds37;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();

             Session["oSecondary_Alt_CC"] = ds4.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();


            smobileTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            salternateTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            semailTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Email"].ToString();
            semailTextBox2.Text = ds4.Tables[0].Rows[0]["Secondary_Email2"].ToString();
            //subprofile 1
            //subprofile1titleDropDownList.Items.Clear();
            //subprofile1titleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            //subprofile1titleDropDownList.Items.Add("Mr");
            //subprofile1titleDropDownList.Items.Add("Ms");
            //subprofile1titleDropDownList.Items.Add("Mrs");
            //subprofile1titleDropDownList.Items.Add("Adv");
            //subprofile1titleDropDownList.Items.Add("Dr");

            DataSet dssp1title = Queries2.LoadSalutations(office);
            subprofile1titleDropDownList.DataSource = dssp1title;
            subprofile1titleDropDownList.DataTextField = "Salutation";
            subprofile1titleDropDownList.DataValueField = "Salutation";
            subprofile1titleDropDownList.AppendDataBoundItems = true;
            subprofile1titleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            subprofile1titleDropDownList.DataBind();


            //  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            sp1fnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            //datepicker3.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString();

            string datep3 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"]);
            if (datep3 == " " || datep3 == "01-01-1900")
            {
                datepicker3.Text = "";
            }
            else
            {
                datepicker3.Text = datep3;
            }

            DataSet sp1nat = Queries2.LoadNationalityWithoutPrevValSP1(ProfileID);
            subprofile1nationalityDropDownList.DataSource = sp1nat;
            subprofile1nationalityDropDownList.DataTextField = "nationality_name";
            subprofile1nationalityDropDownList.DataValueField = "nationality_name";
            subprofile1nationalityDropDownList.AppendDataBoundItems = true;
            subprofile1nationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
            subprofile1nationalityDropDownList.DataBind();
            //subprofile1nationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString());

            //DataSet ds38 = Queries.LoadCountrySP1(ProfileID);
            //SubProfile1CountryDropDownList.DataSource = ds38;
            //SubProfile1CountryDropDownList.DataTextField = "country_name";
            //SubProfile1CountryDropDownList.DataValueField = "country_name";
            //SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            //SubProfile1CountryDropDownList.DataBind();


            //DataSet ds38 = Queries2.LoadCountryPrevVal(ProfileID, "SP1");
            //SubProfile1CountryDropDownList.DataSource = ds38;
            //SubProfile1CountryDropDownList.DataTextField = "country_name";
            //SubProfile1CountryDropDownList.DataValueField = "country_name";
            //SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            //SubProfile1CountryDropDownList.DataBind();

            SubProfile1CountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString());


            DataSet ds39 = Queries2.LoadCountryWithCodeSP1Mobile("");
            subprofile1mobileDropDownList.DataSource = ds39;
            subprofile1mobileDropDownList.DataTextField = "name";
            subprofile1mobileDropDownList.DataValueField = "name";
            subprofile1mobileDropDownList.AppendDataBoundItems = true;
            subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            subprofile1mobileDropDownList.DataBind();


           Session["oSubprofile1_CC"] = ds4.Tables[0].Rows[0]["Subprofile1_CC"].ToString();

            DataSet ds40 = Queries2.LoadCountryWithCodeSP1Alt("");
            subprofile1alternateDropDownList.DataSource = ds40;
            subprofile1alternateDropDownList.DataTextField = "name";
            subprofile1alternateDropDownList.DataValueField = "name";
            subprofile1alternateDropDownList.AppendDataBoundItems = true;
            subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            subprofile1alternateDropDownList.DataBind();

             Session["oSubprofile1_Alt_CC"] = ds4.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();

            sp1mobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            sp1alternateTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            sp1emailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            sp1emailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();

            //subprofile2
            //subprofile2titleDropDownList.Items.Clear();
            //subprofile2titleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");

            DataSet dssp2title = Queries2.LoadSalutations(office);
            subprofile2titleDropDownList.DataSource = dssp2title;
            subprofile2titleDropDownList.DataTextField = "Salutation";
            subprofile2titleDropDownList.DataValueField = "Salutation";
            subprofile2titleDropDownList.AppendDataBoundItems = true;
            subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            subprofile2titleDropDownList.DataBind();

            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            sp2fnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            // datepicker4.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString();

            string datep4 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"]);
            if (datep4 == " " || datep4 == "01-01-1900")
            {
                datepicker4.Text = "";
            }
            else
            {
                datepicker4.Text = datep4;
            }

            DataSet sp2nat = Queries2.LoadNationalityWithoutPrevValSP2(ProfileID);
            subprofile2nationalityDropDownList.DataSource = sp2nat;
            subprofile2nationalityDropDownList.DataTextField = "nationality_name";
            subprofile2nationalityDropDownList.DataValueField = "nationality_name";
            subprofile2nationalityDropDownList.AppendDataBoundItems = true;
            subprofile2nationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
            subprofile2nationalityDropDownList.DataBind();
            //subprofile2nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

            //subprofile2nationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

            //DataSet ds41 = Queries.LoadCountrySP2(ProfileID);
            //SubProfile2CountryDropDownList.DataSource = ds41;
            //SubProfile2CountryDropDownList.DataTextField = "country_name";
            //SubProfile2CountryDropDownList.DataValueField = "country_name";
            //SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            //SubProfile2CountryDropDownList.DataBind();

            //DataSet ds41 = Queries2.LoadCountryPrevVal(ProfileID, "SP2");
            //SubProfile2CountryDropDownList.DataSource = ds41;
            //SubProfile2CountryDropDownList.DataTextField = "country_name";
            //SubProfile2CountryDropDownList.DataValueField = "country_name";
            //SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            //SubProfile2CountryDropDownList.DataBind();

            SubProfile2CountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString());



            DataSet ds42 = Queries2.LoadCountryWithCodeSP2Mobile("");
            subprofile2mobileDropDownList.DataSource = ds42;
            subprofile2mobileDropDownList.DataTextField = "name";
            subprofile2mobileDropDownList.DataValueField = "name";
            subprofile2mobileDropDownList.AppendDataBoundItems = true;
            subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            subprofile2mobileDropDownList.DataBind();

              Session["oSubprofile2_CC"] = ds4.Tables[0].Rows[0]["Subprofile2_CC"].ToString();


            DataSet ds43 = Queries2.LoadCountryWithCodeSP2Alt("");
            subprofile2alternateDropDownList.DataSource = ds43;
            subprofile2alternateDropDownList.DataTextField = "name";
            subprofile2alternateDropDownList.DataValueField = "name";
            subprofile2alternateDropDownList.AppendDataBoundItems = true;
            subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            subprofile2alternateDropDownList.DataBind();


           Session["oSubprofile2_Alt_CC"] = ds4.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();

            sp2mobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            sp2alternateTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            sp2emailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            sp2emailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();

            address1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            address2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            stateTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            cityTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            pincodeTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();


            DataSet ds64 = Queries2.LoadCountryName();
            AddCountryDropDownList.DataSource = ds64;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            AddCountryDropDownList.DataBind();




            //sub profile 3

            DataSet dssp3title = Queries2.LoadSalutations(office);
            SubP3TitleDropDownList.DataSource = dssp3title;
            SubP3TitleDropDownList.DataTextField = "Salutation";
            SubP3TitleDropDownList.DataValueField = "Salutation";
            SubP3TitleDropDownList.AppendDataBoundItems = true;
            SubP3TitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString(), ""));
            SubP3TitleDropDownList.DataBind();

            //DataSet dssp2title = Queries.LoadSalutations();
            //subprofile2titleDropDownList.DataSource = dssp2title;
            //subprofile2titleDropDownList.DataTextField = "Salutation";
            //subprofile2titleDropDownList.DataValueField = "Salutation";
            //subprofile2titleDropDownList.AppendDataBoundItems = true;
            //subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            //subprofile2titleDropDownList.DataBind();

            //subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");
            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            SubP3FnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            if (SubP3FnameTextBox.Text != "")
            {
                SubP3LnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
                //sp2dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

                string datesp3 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Sub_Profile3_DOB"]);
                if (datesp3 == " " || datesp3 == "01-01-1900")

                {
                    SubP3DOB.Text = "";
                }
                else
                {
                    SubP3DOB.Text = datesp3;
                }




                SubP3MobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
                SubP3AMobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
                SubP3EmailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
                SubP3EmailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();
            }

            DataSet sp3nat = Queries2.LoadNationalityWithoutPrevValSP3(ProfileID);
            SubP3NationalityDropDownList.DataSource = sp3nat;
            SubP3NationalityDropDownList.DataTextField = "nationality_name";
            SubP3NationalityDropDownList.DataValueField = "nationality_name";
            SubP3NationalityDropDownList.AppendDataBoundItems = true;
            SubP3NationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
            SubP3NationalityDropDownList.DataBind();

            //DataSet dsp311 = Queries.LoadCountrySP2(ProfileID);
            //SubP3CountryDropDownList.DataSource = dsp311;
            //SubP3CountryDropDownList.DataTextField = "country_name";
            //SubP3CountryDropDownList.DataValueField = "country_name";
            //SubP3CountryDropDownList.AppendDataBoundItems = true;
            //SubP3CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            //SubP3CountryDropDownList.DataBind();


            //DataSet dsp311 = Queries2.LoadCountryPrevVal(ProfileID, "SP3");
            //SubP3CountryDropDownList.DataSource = dsp311;
            //SubP3CountryDropDownList.DataTextField = "country_name";
            //SubP3CountryDropDownList.DataValueField = "country_name";
            //SubP3CountryDropDownList.AppendDataBoundItems = true;
            //SubP3CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            //SubP3CountryDropDownList.DataBind();

            SubP3CountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString());



            DataSet dssp3 = Queries2.LoadCountryWithCodeSP3Mobile("");
            SubP3CCDropDownList.DataSource = dssp3;
            SubP3CCDropDownList.DataTextField = "name";
            SubP3CCDropDownList.DataValueField = "name";
            SubP3CCDropDownList.AppendDataBoundItems = true;
            SubP3CCDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
            SubP3CCDropDownList.DataBind();

             Session["oSubprofile3_CC"] = ds4.Tables[0].Rows[0]["Subprofile3_CC"].ToString();


            DataSet dsspalt3 = Queries2.LoadCountryWithCodeSP3Alt("");
            SubP3CCDropDownList2.DataSource = dsspalt3;
            SubP3CCDropDownList2.DataTextField = "name";
            SubP3CCDropDownList2.DataValueField = "name";
            SubP3CCDropDownList2.AppendDataBoundItems = true;
            SubP3CCDropDownList2.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
            SubP3CCDropDownList2.DataBind();

             Session["oSubprofile3_Alt_CC"] = ds4.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();

            //sub profile 4

            DataSet dssp4title = Queries2.LoadSalutations(office);
            SubP4TitleDropDownList.DataSource = dssp4title;
            SubP4TitleDropDownList.DataTextField = "Salutation";
            SubP4TitleDropDownList.DataValueField = "Salutation";
            SubP4TitleDropDownList.AppendDataBoundItems = true;
            SubP4TitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString(), ""));
            SubP4TitleDropDownList.DataBind();



            //string tvenue = ds4.Tables[0].Rows[0]["Profile_Venue"].ToString();
            string tvenue = ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
	OfficeSourceTextBox.Text = ds4.Tables[0].Rows[0]["Promo_Source"].ToString();
            
            if (tvenue == "Flybuy")
            {
                /*DataSet OfficeSou = Queries2.LoadOfficeSource();

                OfficeSourceDropDownList.DataSource = OfficeSou;
                OfficeSourceDropDownList.DataTextField = "Office_Source_Name";
                OfficeSourceDropDownList.DataValueField = "Office_Source_Name";
                OfficeSourceDropDownList.AppendDataBoundItems = true;
                OfficeSourceDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                OfficeSourceDropDownList.DataBind();*/



                DataSet Flyage = Queries3.LoadFlybuyAgent(Session["venueCountry"].ToString());

                FAgentDropDownList.DataSource = Flyage;
                FAgentDropDownList.DataTextField = "FAgent_Name";
                FAgentDropDownList.DataValueField = "FAgent_Name";
                FAgentDropDownList.AppendDataBoundItems = true;
                FAgentDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Tele_Agent"].ToString(), ""));
                FAgentDropDownList.DataBind();



                DataSet LeaSou = Queries2.LoadLeadSource();

                DropDownListFly.DataSource = LeaSou;
                DropDownListFly.DataTextField = "Lead_Source_Name";
                DropDownListFly.DataValueField = "Lead_Source_Name";
                DropDownListFly.AppendDataBoundItems = true;
                DropDownListFly.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Lead_Source"].ToString(), ""));
                DropDownListFly.DataBind();


                DataSet PreArr = Queries3.LoadPreArrival(Session["venueCountry"].ToString());

                PreArrivalDropDownList.DataSource = PreArr;
                PreArrivalDropDownList.DataTextField = "Pre_Arrival_Name";
                PreArrivalDropDownList.DataValueField = "Pre_Arrival_Name";
                PreArrivalDropDownList.AppendDataBoundItems = true;
                PreArrivalDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Pre_Arrival"].ToString(), ""));
                PreArrivalDropDownList.DataBind();

                DataSet Veri = Queries3.LoadVerification(Session["venueCountry"].ToString());

                VerificationDropDownList.DataSource = Veri;
                VerificationDropDownList.DataTextField = "Verification_Name";
                VerificationDropDownList.DataValueField = "Verification_Name";
                VerificationDropDownList.AppendDataBoundItems = true;
                VerificationDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Verification"].ToString(), ""));
                VerificationDropDownList.DataBind();


            }

            else
            {


               /* DataSet OfficeSou = Queries2.LoadOfficeSource();

                OfficeSourceDropDownList.DataSource = OfficeSou;
                OfficeSourceDropDownList.DataTextField = "Office_Source_Name";
                OfficeSourceDropDownList.DataValueField = "Office_Source_Name";
                OfficeSourceDropDownList.AppendDataBoundItems = true;
                OfficeSourceDropDownList.Items.Insert(0, new ListItem("", ""));
                OfficeSourceDropDownList.DataBind();*/



                DataSet Flyage = Queries3.LoadFlybuyAgent(Session["venueCountry"].ToString());

                FAgentDropDownList.DataSource = Flyage;
                FAgentDropDownList.DataTextField = "FAgent_Name";
                FAgentDropDownList.DataValueField = "FAgent_Name";
                FAgentDropDownList.AppendDataBoundItems = true;
                FAgentDropDownList.Items.Insert(0, new ListItem("", ""));
                FAgentDropDownList.DataBind();



                DataSet LeaSou = Queries2.LoadLeadSource();

                DropDownListFly.DataSource = LeaSou;
                DropDownListFly.DataTextField = "Lead_Source_Name";
                DropDownListFly.DataValueField = "Lead_Source_Name";
                DropDownListFly.AppendDataBoundItems = true;
                DropDownListFly.Items.Insert(0, new ListItem("", ""));
                DropDownListFly.DataBind();


                DataSet PreArr = Queries3.LoadPreArrival(Session["venueCountry"].ToString());

                PreArrivalDropDownList.DataSource = PreArr;
                PreArrivalDropDownList.DataTextField = "Pre_Arrival_Name";
                PreArrivalDropDownList.DataValueField = "Pre_Arrival_Name";
                PreArrivalDropDownList.AppendDataBoundItems = true;
                PreArrivalDropDownList.Items.Insert(0, new ListItem("", ""));
                PreArrivalDropDownList.DataBind();


                DataSet Veri = Queries3.LoadVerification(Session["venueCountry"].ToString());

                VerificationDropDownList.DataSource = Veri;
                VerificationDropDownList.DataTextField = "Verification_Name";
                VerificationDropDownList.DataValueField = "Verification_Name";
                VerificationDropDownList.AppendDataBoundItems = true;
                VerificationDropDownList.Items.Insert(0, new ListItem("", ""));
                VerificationDropDownList.DataBind();





            }




            //DataSet dssp2title = Queries.LoadSalutations();
            //subprofile2titleDropDownList.DataSource = dssp2title;
            //subprofile2titleDropDownList.DataTextField = "Salutation";
            //subprofile2titleDropDownList.DataValueField = "Salutation";
            //subprofile2titleDropDownList.AppendDataBoundItems = true;
            //subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            //subprofile2titleDropDownList.DataBind();

            //subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");
            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            SubP4FnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            if (SubP4FnameTextBox.Text != "")
            {
                SubP4LnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
                //sp2dobdatepicker.Text = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

                string datesp4 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Sub_Profile4_DOB"]);
                if (datesp4 == " " || datesp4 == "01-01-1900")
                {
                    SubP4DOB.Text = "";
                }
                else
                {
                    SubP4DOB.Text = datesp4;
                }




                SubP4MobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
                SubP4AMobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
                SubP4EmailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Email"].ToString();
                SubP4EmailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();

            }

            DataSet sp4nat = Queries2.LoadNationalityWithoutPrevValSP4(ProfileID);
            SubP4NationalityDropDownList.DataSource = sp4nat;
            SubP4NationalityDropDownList.DataTextField = "nationality_name";
            SubP4NationalityDropDownList.DataValueField = "nationality_name";
            SubP4NationalityDropDownList.AppendDataBoundItems = true;
            SubP4NationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
            SubP4NationalityDropDownList.DataBind();


            //DataSet dsp411 = Queries.LoadCountrySP2(ProfileID);
            //SubP4CountryDropDownList.DataSource = dsp411;
            //SubP4CountryDropDownList.DataTextField = "country_name";
            //SubP4CountryDropDownList.DataValueField = "country_name";
            //SubP4CountryDropDownList.AppendDataBoundItems = true;
            //SubP4CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            //SubP4CountryDropDownList.DataBind();

            //DataSet dsp411 = Queries2.LoadCountryPrevVal(ProfileID, "SP4");
            //SubP4CountryDropDownList.DataSource = dsp411;
            //SubP4CountryDropDownList.DataTextField = "country_name";
            //SubP4CountryDropDownList.DataValueField = "country_name";
            //SubP4CountryDropDownList.AppendDataBoundItems = true;
            //SubP4CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            //SubP4CountryDropDownList.DataBind();

            SubP4CountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString());



            DataSet dssp4 = Queries2.LoadCountryWithCodeSP4Mobile("");
            SubP4CCDropDownList.DataSource = dssp4;
            SubP4CCDropDownList.DataTextField = "name";
            SubP4CCDropDownList.DataValueField = "name";
            SubP4CCDropDownList.AppendDataBoundItems = true;
            SubP4CCDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
            SubP4CCDropDownList.DataBind();


             Session["oSubprofile4_CC"] = ds4.Tables[0].Rows[0]["Subprofile4_CC"].ToString();

            DataSet dsspalt4 = Queries2.LoadCountryWithCodeSP4Alt("");
            SubP4CCDropDownList2.DataSource = dsspalt4;
            SubP4CCDropDownList2.DataTextField = "name";
            SubP4CCDropDownList2.DataValueField = "name";
            SubP4CCDropDownList2.AppendDataBoundItems = true;
            SubP4CCDropDownList2.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
            SubP4CCDropDownList2.DataBind();

             Session["oSubprofile4_Alt_CC"] = ds4.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();

            //load gift

            DataSet tdsgift1 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList.DataSource = tdsgift1;
            giftoptionDropDownList.DataTextField = "item";
            giftoptionDropDownList.DataValueField = "item";
            giftoptionDropDownList.AppendDataBoundItems = true;
            giftoptionDropDownList.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList.DataBind();

            DataSet tdsgift2 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList2.DataSource = tdsgift2;
            giftoptionDropDownList2.DataTextField = "item";
            giftoptionDropDownList2.DataValueField = "item";
            giftoptionDropDownList2.AppendDataBoundItems = true;
            giftoptionDropDownList2.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList2.DataBind();


            DataSet tdsgift3 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList3.DataSource = tdsgift3;
            giftoptionDropDownList3.DataTextField = "item";
            giftoptionDropDownList3.DataValueField = "item";
            giftoptionDropDownList3.AppendDataBoundItems = true;
            giftoptionDropDownList3.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList3.DataBind();

            DataSet tdsgift4 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList4.DataSource = tdsgift4;
            giftoptionDropDownList4.DataTextField = "item";
            giftoptionDropDownList4.DataValueField = "item";
            giftoptionDropDownList4.AppendDataBoundItems = true;
            giftoptionDropDownList4.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList4.DataBind();

            DataSet tdsgift5 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList5.DataSource = tdsgift5;
            giftoptionDropDownList5.DataTextField = "item";
            giftoptionDropDownList5.DataValueField = "item";
            giftoptionDropDownList5.AppendDataBoundItems = true;
            giftoptionDropDownList5.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList5.DataBind();

            DataSet tdsgift6 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList6.DataSource = tdsgift6;
            giftoptionDropDownList6.DataTextField = "item";
            giftoptionDropDownList6.DataValueField = "item";
            giftoptionDropDownList6.AppendDataBoundItems = true;
            giftoptionDropDownList6.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList6.DataBind();

            DataSet tdsgift7 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList7.DataSource = tdsgift7;
            giftoptionDropDownList7.DataTextField = "item";
            giftoptionDropDownList7.DataValueField = "item";
            giftoptionDropDownList7.AppendDataBoundItems = true;
            giftoptionDropDownList7.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList7.DataBind();






            //stay details
            hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            roomnoTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            datepicker5.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString();
            datepicker6.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();

            string datep5 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]);
            if (datep5 == " " || datep5 == "01-01-1900")
            {
                datepicker5.Text = "";
            }
            else
            {
                datepicker5.Text = datep5;
            }


            string datep6 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]);
            if (datep6 == " " || datep6 == "01-01-1900")

            {
                datepicker6.Text = "";
            }
            else
            {
                datepicker6.Text = datep6;
            }


            //guest status


            //guest status

            DataSet dsgs = Queries.LoadGuestStatus();
            gueststatusDropDownList.DataSource = dsgs;
            gueststatusDropDownList.DataTextField = "Guest_Status_name";
            gueststatusDropDownList.DataValueField = "Guest_Status_name";
            gueststatusDropDownList.AppendDataBoundItems = true;
            gueststatusDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            gueststatusDropDownList.DataBind();


            //gueststatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString());
           // salesrepDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());

            DataSet dssr = Queries2.LoadSalesReps(vencountry, VenueDropDownListval,GroupVenueDropDownListval);
            salesrepDropDownList.DataSource = dssr;
            salesrepDropDownList.DataTextField = "sales_rep_name";
            salesrepDropDownList.DataValueField = "sales_rep_name";
            salesrepDropDownList.AppendDataBoundItems = true;
            salesrepDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            salesrepDropDownList.DataBind();

            //contsalesrepDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Contract_Finance_Sales_Rep"].ToString());
            deckcheckintimeTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            deckcheckouttimeTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            //tourdatedatepicker.Text = ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString();

            string datep7 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"]);
            if (datep7 == " " || datep7 == "01-01-1900")
            {
                tourdatedatepicker.Text = "";
            }
            else
            {
                tourdatedatepicker.Text = datep7;
            }

            /*string tpricein1 = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            if (tpricein1 == "0.0000")
            {
                taxipriceInTextBox.Text = "";
            }
            else
            {
                taxipriceInTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            }*/


		taxipriceInTextBox.Text = dsT.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();

           /* string tpriceout1 = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            if (tpriceout1 == "0.0000")
            {
                TaxiPriceOutTextBox.Text = "";
            }
            else
            {
                TaxiPriceOutTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            }*/

	TaxiPriceOutTextBox.Text = dsT.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();

            //taxipriceInTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            TaxiRefInTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
           // TaxiPriceOutTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            TaxiRefOutTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
            commentTextBox.Text = ds4.Tables[0].Rows[0]["Comments"].ToString();

            Session["Gofficeo"] = Queries2.getoffice(ProfileID);

            /*string[] ar = new string[10];
            string[] br = new string[10];
            string[] cr = new string[10];
            string[] dr = new string[10];
            int i = 0;
            SqlDataReader reader = Queries2.getgiftoption(ProfileID);
            while (reader.Read())
            {

                ar[i] = reader.GetString(0);
                br[i] = reader.GetString(1);
                cr[i] = reader.GetString(2);
                dr[i] = reader.GetString(3);

                //string id = "giftoptionDropDownList";

                i++;

            }*/




 string [] ar = new string[10];
            string[] br = new string[10];
            string[] cr = new string[10];
            string[] dr = new string[10];
 string[] er = new string[10];
		
	    Array.Clear(ar, 0, ar.Length);
            Array.Clear(br, 0, br.Length);
            Array.Clear(cr, 0, cr.Length);
            Array.Clear(dr, 0, dr.Length);
Array.Clear(er, 0, er.Length);

            int i = 0;
            //ogiftoptionDropDownList=""; ogiftoptionDropDownList2 = ""; ogiftoptionDropDownList3 = ""; ogiftoptionDropDownList4 = ""; ogiftoptionDropDownList5 = ""; ogiftoptionDropDownList6 = ""; ogiftoptionDropDownList7 = "";

            Session["ogiftprice1"] = ""; Session["ogiftprice2"] = ""; Session["ogiftprice3"] = ""; Session["ogiftprice4"] = ""; Session["ogiftprice5"] = ""; Session["ogiftprice6"] = ""; Session["ogiftprice7"] = "";
            Session["ovouchernoTextBox"] = ""; Session["ovouchernoTextBox2"] = ""; Session["ovouchernoTextBox3"] = ""; Session["ovouchernoTextBox4"] = ""; Session["ovouchernoTextBox5"] = ""; Session["ovouchernoTextBox6"] = ""; Session["ovouchernoTextBox7"] = "";
            Session["ogiftoptionDropDownList"] = ""; Session["ogiftoptionDropDownList2"] = ""; Session["ogiftoptionDropDownList3"] = ""; Session["ogiftoptionDropDownList4"] = ""; Session["ogiftoptionDropDownList5"] = ""; Session["ogiftoptionDropDownList6"] = ""; Session["ogiftoptionDropDownList7"] = "";


            SqlDataReader reader = Queries2.getgiftoption(ProfileID);
            while (reader.Read())
            {
                er[i] = reader.GetString(4);

                if (er[i] == Session["ProfileIDo"].ToString())
                {

                    ar[i] = reader.GetString(0);
                    br[i] = reader.GetString(1);
                    cr[i] = reader.GetString(2);
                    dr[i] = reader.GetString(3);

                    //string id = "giftoptionDropDownList";
                }
                i++;

            }


            if (string.IsNullOrEmpty(ar[0]) == false)
            // if (ar[0] != "")
            {
                giftoptionDropDownList.Items.Clear();
                DataSet dsgift1 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList.DataSource = dsgift1;
                giftoptionDropDownList.DataTextField = "item";
                giftoptionDropDownList.DataValueField = "item";
                giftoptionDropDownList.AppendDataBoundItems = true;

                giftoptionDropDownList.DataBind();
                giftoptionDropDownList.Items.Insert(0, new ListItem(ar[0]));

                vouchernoTextBox.Text = br[0];

                string gift_p = dr[0];

                if (gift_p != "0")
                {
                    TextBoxGPrice1.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[0]));//string.Format("{0:n0}", dr[0]);//dr[0];
                }
                else
                {
                    TextBoxGPrice1.Text = "0";
                }

                Session["ogiftoptionDropDownList"] = ar[0];
                Session["ovouchernoTextBox"] = br[0];
                //ogiftoptionDropDownList = ar[0];
                //ovouchernoTextBox = br[0];
                TextBoxChargeBack.Text = cr[0];
                Session["ogiftprice1"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[0])); //string.Format("{0:n0}", dr[0]); 
                string dsf = cr[0];

            }

            if (string.IsNullOrEmpty(ar[1]) == false)
            //if (ar[1] != "")
            {
                giftoptionDropDownList2.Items.Clear();
                DataSet dsgift2 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList2.DataSource = dsgift2;
                giftoptionDropDownList2.DataTextField = "item";
                giftoptionDropDownList2.DataValueField = "item";
                giftoptionDropDownList2.AppendDataBoundItems = true;

                giftoptionDropDownList2.DataBind();
                giftoptionDropDownList2.Items.Insert(0, new ListItem(ar[1]));

                vouchernoTextBox2.Text = br[1];
                string gift_p = dr[1];

                if (gift_p != "0")
                {
                    TextBoxGPrice2.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1])); //dr[1];
                }
                else
                {
                    TextBoxGPrice2.Text = "0";
                }
                //ogiftoptionDropDownList2 = ar[1];
                // ovouchernoTextBox2 = br[1];
                // ogiftprice2 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1]));//dr[1];
                Session["ogiftoptionDropDownList2"] = ar[1];
                Session["ovouchernoTextBox2"] = br[1];
                Session["ogiftprice2"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1]));//dr[1];
            }

            if (string.IsNullOrEmpty(ar[2]) == false)
            //if (ar[2] != "")
            {
                giftoptionDropDownList3.Items.Clear();
                DataSet dsgift3 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList3.DataSource = dsgift3;
                giftoptionDropDownList3.DataTextField = "item";
                giftoptionDropDownList3.DataValueField = "item";
                giftoptionDropDownList3.AppendDataBoundItems = true;

                giftoptionDropDownList3.DataBind();
                giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                vouchernoTextBox3.Text = br[2];

                string gift_p = dr[2];

                if (gift_p != "0")
                {
                    TextBoxGPrice3.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[2]));//dr[2];
                }
                else
                {
                    TextBoxGPrice3.Text = "0";
                }
                // ogiftoptionDropDownList3 = ar[2];
                // ovouchernoTextBox3 = br[2];
                // ogiftprice3 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[2]));//dr[2];

                Session["ogiftoptionDropDownList3"] = ar[2];
                Session["ovouchernoTextBox3"] = br[2];
                Session["ogiftprice3"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[2]));//dr[1];
            }

            if (string.IsNullOrEmpty(ar[3]) == false)
            //if (ar[3] != "")
            {
                giftoptionDropDownList4.Items.Clear();
                DataSet dsgift4 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList4.DataSource = dsgift4;
                giftoptionDropDownList4.DataTextField = "item";
                giftoptionDropDownList4.DataValueField = "item";
                giftoptionDropDownList4.AppendDataBoundItems = true;

                giftoptionDropDownList4.DataBind();
                giftoptionDropDownList4.Items.Insert(0, new ListItem(ar[3]));

                vouchernoTextBox4.Text = br[3];

                string gift_p = dr[3];

                if (gift_p != "0")
                {
                    TextBoxGPrice4.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[3])); //dr[3];
                }
                else
                {
                    TextBoxGPrice4.Text = "0";

                }
                //ogiftoptionDropDownList4 = ar[3];
                // ovouchernoTextBox4 = br[3];
                //ogiftprice4 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[3]));//dr[3];
                Session["ogiftoptionDropDownList4"] = ar[3];
                Session["ovouchernoTextBox4"] = br[3];
                Session["ogiftprice4"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[3]));//dr[1];
            }

            if (string.IsNullOrEmpty(ar[4]) == false)
            //if (ar[4] != "")
            {
                giftoptionDropDownList5.Items.Clear();
                DataSet dsgift5 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList5.DataSource = dsgift5;
                giftoptionDropDownList5.DataTextField = "item";
                giftoptionDropDownList5.DataValueField = "item";
                giftoptionDropDownList5.AppendDataBoundItems = true;

                giftoptionDropDownList5.DataBind();
                giftoptionDropDownList5.Items.Insert(0, new ListItem(ar[4]));

                vouchernoTextBox5.Text = br[4];

                string gift_p = dr[4];

                if (gift_p != "0")
                {
                    TextBoxGPrice5.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[4]));//dr[4];
                }
                else
                {
                    TextBoxGPrice5.Text = "0";
                }
                // ogiftoptionDropDownList5 = ar[4];
                // ovouchernoTextBox5 = br[4];
                // ogiftprice5 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[4])); //dr[4];

                Session["ogiftoptionDropDownList5"] = ar[4];
                Session["ovouchernoTextBox5"] = br[4];
                Session["ogiftprice5"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[4]));//dr[1];
            }


            if (string.IsNullOrEmpty(ar[5]) == false)
            //if (ar[5] != "")
            {
                giftoptionDropDownList6.Items.Clear();
                DataSet dsgift6 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList6.DataSource = dsgift6;
                giftoptionDropDownList6.DataTextField = "item";
                giftoptionDropDownList6.DataValueField = "item";
                giftoptionDropDownList6.AppendDataBoundItems = true;

                giftoptionDropDownList6.DataBind();
                giftoptionDropDownList6.Items.Insert(0, new ListItem(ar[5]));

                vouchernoTextBox6.Text = br[5];

                string gift_p = dr[5];

                if (gift_p != "0")
                {
                    TextBoxGPrice6.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[5])); //dr[5];
                }
                else
                {
                    TextBoxGPrice6.Text = "0";
                }
                // ogiftoptionDropDownList6 = ar[5];
                // ovouchernoTextBox6 = br[5];
                // ogiftprice6 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[5])); //dr[5];

                Session["ogiftoptionDropDownList6"] = ar[5];
                Session["ovouchernoTextBox6"] = br[5];
                Session["ogiftprice6"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[5]));//dr[1];
            }


            if (string.IsNullOrEmpty(ar[6]) == false)
            //if (ar[6] != "")
            {
                giftoptionDropDownList7.Items.Clear();
                DataSet dsgift7 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList7.DataSource = dsgift7;
                giftoptionDropDownList7.DataTextField = "item";
                giftoptionDropDownList7.DataValueField = "item";
                giftoptionDropDownList7.AppendDataBoundItems = true;

                giftoptionDropDownList7.DataBind();
                giftoptionDropDownList7.Items.Insert(0, new ListItem(ar[6]));

                vouchernoTextBox7.Text = br[6];
                string gift_p = dr[6];

                if (gift_p != "0")
                {
                    TextBoxGPrice7.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[6]));//dr[6];
                }
                else
                {
                    TextBoxGPrice7.Text = "0";
                }
                // ogiftoptionDropDownList7 = ar[6];
                // ovouchernoTextBox7 = br[6];
                // ogiftprice7 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[6]));//dr[6];

                Session["ogiftoptionDropDownList7"] = ar[6];
                Session["ovouchernoTextBox7"] = br[6];
                Session["ogiftprice7"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[6]));//dr[1];
            }


            TextVPID.Text = ds4.Tables[0].Rows[0]["VP_ID"].ToString();
            TextPrimaryAge.Text = ds4.Tables[0].Rows[0]["Primary_Age"].ToString();
            TextSecondAge.Text = ds4.Tables[0].Rows[0]["Secondary_Age"].ToString();
            TextSP1Age.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();
            TextSP2Age.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();
            TextSP3Age.Text = ds4.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();
            TextSP4Age.Text = ds4.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

            DataSet dsepr = Queries2.LoadQStatus();
            QStatusDropDownList1.DataSource = dsepr;
            QStatusDropDownList1.DataTextField = "Qstatus_Name";
            QStatusDropDownList1.DataValueField = "Qstatus_Name";
            QStatusDropDownList1.AppendDataBoundItems = true;
            QStatusDropDownList1.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Tour_Details_Qualified_Status"].ToString(), ""));
            QStatusDropDownList1.DataBind();

            string check = ds4.Tables[0].Rows[0]["RegTerms"].ToString();

            if (check == "Y")
            {
                Regterms1.Checked = true;
            }
            else
            {
                Regterms1.Checked = false;
            }

            string check2 = ds4.Tables[0].Rows[0]["RegTerms2"].ToString();

            if (check2 == "Y")
            {
                Regterms2.Checked = true;
            }
            else
            {
                Regterms2.Checked = false;
            }


            TextBoxPrimIDType.Text = ds4.Tables[0].Rows[0]["Primary_ID_Type"].ToString();
            TextBoxPrimID.Text = ds4.Tables[0].Rows[0]["Primary_ID_Num"].ToString();
            TextBoxSecoIDType.Text = ds4.Tables[0].Rows[0]["Secondary_ID_Type"].ToString();
            TextBoxSecoID.Text = ds4.Tables[0].Rows[0]["Secondary_ID_Num"].ToString();
            TextBoxSP1IDType.Text = ds4.Tables[0].Rows[0]["SP1_ID_Type"].ToString();
            TextBoxSP1ID.Text = ds4.Tables[0].Rows[0]["SP1_ID_Num"].ToString();
            TextBoxSP2IDType.Text = ds4.Tables[0].Rows[0]["SP2_ID_Type"].ToString();
            TextBoxSP2ID.Text = ds4.Tables[0].Rows[0]["SP2_ID_Num"].ToString();
            TextBoxSP3IDType.Text = ds4.Tables[0].Rows[0]["SP3_ID_Type"].ToString();
            TextBoxSP3ID.Text = ds4.Tables[0].Rows[0]["SP3_ID_Num"].ToString();
            TextBoxSP4IDType.Text = ds4.Tables[0].Rows[0]["SP4_ID_Type"].ToString();
            TextBoxSP4ID.Text = ds4.Tables[0].Rows[0]["SP4_ID_Num"].ToString();


            if (TextBoxPrimIDType.Text != "" || TextBoxSecoIDType.Text != "" || TextBoxSP1IDType.Text != "" || TextBoxSP2IDType.Text != "" || TextBoxSP3IDType.Text != "" || TextBoxSP4IDType.Text != "")
            {
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "uncheck()", true);

                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "uncheck();", true);

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>uncheck('Primchs', 'Prihidden');</script>", false);
            }

            Session["lastinstalldate"] = "";

            DataSet ds5 = Queries2.LoadAllContractFractionalDetails(fracid);
            DataSet ds5D = Queries2.LoadAllContractFractionalDetailsDates(fracid);
            // hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            DropDownList40.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Type"].ToString());
            string conttype = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Type"].ToString();
            TextICE.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Affil_ICE"].ToString();
            Session["Contract_Finance_Affil_ICEo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Affil_ICE"].ToString();
            TextHP.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Affil_HP"].ToString();

            TextBoxDummyOverride.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Override"].ToString();
            TextBoxDummyConoffcheck.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cool_OnOff"].ToString();
            Session["Contract_Finance_Cool_OnOffo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Cool_OnOff"].ToString();
            string t1 = ds5D.Tables[0].Rows[0]["Contract_Finance_Cool_Start_Date"].ToString();
            Session["Contract_Finance_Cool_Start_Dateo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Cool_Start_Date"].ToString();
            if (t1=="01-01-1900")
            {
                TextBoxCoolStart.Text = "";
            }
            else
            {
                TextBoxCoolStart.Text =  t1;
            }
            string t2 = ds5D.Tables[0].Rows[0]["Contract_Finance_Cool_End_Date"].ToString();
            Session["Contract_Finance_Cool_End_Dateo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Cool_End_Date"].ToString();
            if (t1 == "01-01-1900")
            {
                TextBoxCoolEnd.Text = "";
            }
            else
            {
                TextBoxCoolEnd.Text = t2;
            }


            Session["lastinstalldate"] = ds5D.Tables[0].Rows[0]["PS_PA_Last_Install_Date"].ToString(); 
            // contsalesrepDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Sales_Rep"].ToString());
            DataSet ds7 = Queries2.LoadSalesReps(vencountry, VenueDropDownListval,GroupVenueDropDownListval);
            contsalesrepDropDownList.DataSource = ds7;
            contsalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            contsalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            contsalesrepDropDownList.AppendDataBoundItems = true;
            contsalesrepDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Sales_Rep"].ToString(), ""));
            contsalesrepDropDownList.DataBind();
            //TOManagerDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_TO_Manager"].ToString());
            //ButtonUpDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Button_UP"].ToString());
            Session["contsalesrepDropDownListo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Sales_Rep"].ToString();

            string VenueDropDown = ds4.Tables[0].Rows[0]["Profile_Venue"].ToString();
           // oDealDrawer = ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Drawer"].ToString();
            Session["oDealDrawer"]= ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Drawer"].ToString();



            DataSet Cancelvenue = Queries2.LoadSubVenue2(GroupVenueDropDownListval);
            CGroupvenueDropDownList.DataSource = Cancelvenue;
            CGroupvenueDropDownList.DataTextField = "SVenue_Name";
            CGroupvenueDropDownList.DataValueField = "SVenue_Name";
            CGroupvenueDropDownList.AppendDataBoundItems = true;
            CGroupvenueDropDownList.Items.Insert(0, new ListItem("", ""));
            CGroupvenueDropDownList.DataBind();



            //DataSet Cancelvenue = Queries2.LoadSubVenue2(GroupVenueDropDownListval);
            //CGroupvenueDropDownList.DataSource = Cancelvenue;
            //CGroupvenueDropDownList.DataTextField = "SVenue_Name";
            //CGroupvenueDropDownList.DataValueField = "SVenue_Name";
            //CGroupvenueDropDownList.AppendDataBoundItems = true;
            //CGroupvenueDropDownList.Items.Insert(0, new ListItem("", ""));
            //CGroupvenueDropDownList.DataBind();

            // Session["CGroupvenueDropDownListo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Sales_Rep"].ToString();





            DataSet CanRea = Queries2.LoadCancelReason();
            CReasonDropDownList.DataSource = CanRea;
            CReasonDropDownList.DataTextField = "CR_Reasons";
            CReasonDropDownList.DataValueField = "CR_Reasons";
            CReasonDropDownList.AppendDataBoundItems = true;
            CReasonDropDownList.Items.Insert(0, new ListItem("", ""));
            CReasonDropDownList.DataBind();


            DataSet CanType = Queries2.LoadCancelType(ds5.Tables[0].Rows[0]["Contract_Finance_Cool_OnOff"].ToString());
            CTypeDropDownList.DataSource = CanType;
            CTypeDropDownList.DataTextField = "CT_Type";
            CTypeDropDownList.DataValueField = "CT_Type";
            CTypeDropDownList.AppendDataBoundItems = true;
            CTypeDropDownList.Items.Insert(0, new ListItem("", ""));
            CTypeDropDownList.DataBind();

            DataSet dsec19 = Queries2.LoadTOManager(Session["Gofficeo"].ToString(), VenueDropDown, vencountry, GroupVenueDropDownListval);
            TOManagerDropDownList.DataSource = dsec19;
            TOManagerDropDownList.DataTextField = "TO_Manager_name";
            TOManagerDropDownList.DataValueField = "TO_Manager_name";
            TOManagerDropDownList.AppendDataBoundItems = true;
            TOManagerDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_TO_Manager"].ToString(), ""));
            TOManagerDropDownList.DataBind();

            Session["TOManagerDropDownListo"] = ds5.Tables[0].Rows[0]["Contract_Finance_TO_Manager"].ToString();

            DataSet dsec20 = Queries2.LoadButtonUp(Session["Gofficeo"].ToString(), VenueDropDown, vencountry, GroupVenueDropDownListval);
            ButtonUpDropDownList.DataSource = dsec20;
            ButtonUpDropDownList.DataTextField = "ButtonUp_Name";
            ButtonUpDropDownList.DataValueField = "ButtonUp_Name";
            ButtonUpDropDownList.AppendDataBoundItems = true;
            ButtonUpDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Button_UP"].ToString(), ""));
            ButtonUpDropDownList.DataBind();

            Session["ButtonUpDropDownListo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Button_UP"].ToString();

            FinanceCurrencyDropDownList.Items.Clear();
            FinanceCurrencyDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Currency"].ToString());
            FinanceCurrencyDropDownList.Items.Clear();
            FinanceCurrencyDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Currency"].ToString());

	//ContractVenueVPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString());

            TextPurchasePrice.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["Contract_Finance_Purchase_Price"]);
            Session["Contract_Finance_Purchase_Priceo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Purchase_Price"].ToString();
            TextAdminFees.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees"]);
            Session["Contract_Finance_Admin_Feeso"] = ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees"].ToString();
            //TextMCFees.Text = ds5.Tables[0].Rows[0]["Contract_Finance_MC_Fees"].ToString();
            TextMCFees.Text = ds5.Tables[0].Rows[0]["Contract_Finance_MC_Fees"].ToString();
            Session["Contract_Finance_MC_Feeso"] = ds5.Tables[0].Rows[0]["Contract_Finance_MC_Fees"].ToString();

            Session["DealRegDate"]= ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Reg_Date"].ToString();


            Session["cweekno"] = Convert.ToInt32(ds5.Tables[0].Rows[0]["Contract_Finance_Week_No"].ToString());

            Session["scweekno"] = ds5.Tables[0].Rows[0]["Contract_Finance_Week_No"].ToString();

            //cweekno2 = cweekno;

            DataSet dsec1 = Queries2.LoadDealDrawer();
            DealDrawerDropDownList.DataSource = dsec1;
            DealDrawerDropDownList.DataTextField = "Deal_Drawer_Name";
            DealDrawerDropDownList.DataValueField = "Deal_Drawer_Name";
            DealDrawerDropDownList.AppendDataBoundItems = true;
            DealDrawerDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Drawer"].ToString(), ""));
            DealDrawerDropDownList.DataBind();

            Session["DealDrawerDropDownListo"] = ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Drawer"].ToString();

            //DealDrawerDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Drawer"].ToString());
            oBalance_Pay_Method = ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString();
            Session["oBalance_Pay_Method"] = ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString();
            //DataSet dsec2 = Queries2.LoadPayMethod2(ds5.Tables[0].Rows[0]["Contract_Finance_Currency"].ToString());
            //PayMethodDropDownList.DataSource = dsec2;
            //PayMethodDropDownList.DataTextField = "pay_method_name";
            //PayMethodDropDownList.DataValueField = "pay_method_name";
            //PayMethodDropDownList.AppendDataBoundItems = true;
            //PayMethodDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString(), ""));
            //PayMethodDropDownList.DataBind();


            DataSet dsec2 = Queries2.LoadPayMethod();
            PayMethodDropDownList.DataSource = dsec2;
            PayMethodDropDownList.DataTextField = "pay_method_name";
            PayMethodDropDownList.DataValueField = "pay_method_name";
            PayMethodDropDownList.AppendDataBoundItems = true;
            PayMethodDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString(), ""));
            PayMethodDropDownList.DataBind();

            Session["oPayMethodDropDownList"] = ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString();

            TextPayMethodDetails.Text= ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method_Details"].ToString();
            Session["oTextPayMethodDetails"] = ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method_Details"].ToString();

            //PayMethodDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString());
            string balancepaymethod = ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString();
            Session["obalancepaymethod"] = ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString();

            if (balancepaymethod == "Crown Finance")
            {

                TextPnumb.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Finance_Num"].ToString();
                Session["oTextPnumb"] = ds5.Tables[0].Rows[0]["Contract_Finance_Finance_Num"].ToString();
            }
            else if(balancepaymethod == "PARSHURAM FINANCE")
            {
                TextPnumb.Text= TextBoxINRFinaNumb.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Finance_Num"].ToString();
                

                TextBoxDIGSTRate.Text = TextBoxINRIGSTRate.Text = ds5.Tables[0].Rows[0]["PFDetails_IGST_Rate"].ToString();
                
                TextBoxDIntRate.Text = TextBoxINRIntRate.Text = ds5.Tables[0].Rows[0]["PFDetails_Interest_Rate"].ToString();
                
                TextBoxDDcocuFees.Text = TextBoxINRDoccuFees.Text = ds5.Tables[0].Rows[0]["PFDetails_Doccu_Fees"].ToString();
                
                TextBoxDIGSTAmt.Text = TextBoxIGSTAmt.Text = ds5.Tables[0].Rows[0]["PFDetails_IGST_Amount"].ToString();
                
                TextBoxDNoEMI.Text =TextBoxPFNoOfInstall.Text = TextBoxINREMI.Text = ds5.Tables[0].Rows[0]["PFDetails_No_Of_EMI"].ToString();
                
                TextBoxDEMIAmt.Text = TextBoxINREMIAmt.Text = ds5.Tables[0].Rows[0]["PFDetails_EMI_Install"].ToString();
                
                TextBoxDFinaMonth.Text = TextBoxINRFinaMonth.Text = ds5.Tables[0].Rows[0]["PFDetails_Finance_Month"].ToString();
                
                TextBoxDPrincipalAmt.Text = ds5.Tables[0].Rows[0]["PFDetails_Principle_amt"].ToString();
                Session["oTextBoxDPrincipalAmt"] = ds5.Tables[0].Rows[0]["PFDetails_Principle_amt"].ToString();
                Session["oTextBoxDFinaMonth"] = ds5.Tables[0].Rows[0]["PFDetails_Finance_Month"].ToString();
                Session["oTextBoxDEMIAmt"] = ds5.Tables[0].Rows[0]["PFDetails_EMI_Install"].ToString();
                Session["oTextBoxDNoEMI"] = ds5.Tables[0].Rows[0]["PFDetails_No_Of_EMI"].ToString();
                Session["oTextBoxDIGSTAmt"] = ds5.Tables[0].Rows[0]["PFDetails_IGST_Amount"].ToString();
                Session["oTextBoxDDcocuFees"] = ds5.Tables[0].Rows[0]["PFDetails_Doccu_Fees"].ToString();
                Session["oTextBoxDIntRate"] = ds5.Tables[0].Rows[0]["PFDetails_Interest_Rate"].ToString();
                Session["oTextBoxDIGSTRate"] = ds5.Tables[0].Rows[0]["PFDetails_IGST_Rate"].ToString();
                Session["oTextPnumb"] = ds5.Tables[0].Rows[0]["Contract_Finance_Finance_Num"].ToString();


            }
            //string BPaymethod = "";//BPMDropDownList.SelectedItem.Text;
            TextPan.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Pan_Card"].ToString();
            TextAdhar.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Adhar_Card"].ToString();
            TextOtherID.Text = ds5.Tables[0].Rows[0]["Contract_Finance_ID_Card"].ToString();
            TextBoxContractComment.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Comments"].ToString();
            //CrownFinanceCurrDropDownList.Items.Add();

            DataSet dsec66 = Queries2.CrownFinaCurr1();

            CrownFinanceCurrDropDownList.DataSource = dsec66;
            CrownFinanceCurrDropDownList.DataTextField = "Finance_Curr_Name";
            CrownFinanceCurrDropDownList.DataValueField = "Finance_Curr_Name";
            CrownFinanceCurrDropDownList.AppendDataBoundItems = true;
            CrownFinanceCurrDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Crown_Curr"].ToString(), ""));
            CrownFinanceCurrDropDownList.DataBind();

            Session["oCrownFinanceCurrDropDownList"] = ds5.Tables[0].Rows[0]["Contract_Finance_Crown_Curr"].ToString();

            DataSet dsec10 = Queries2.LoadDepositPayMethod(Session["Gofficeo"].ToString());
            DPMFractDropDownList.DataSource = dsec10;
            DPMFractDropDownList.DataTextField = "Deposit_pay_method_name";
            DPMFractDropDownList.DataValueField = "Deposit_pay_method_name";
            DPMFractDropDownList.AppendDataBoundItems = true;
            DPMFractDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["PS_Deposit_Pay_Method"].ToString(), ""));
            DPMFractDropDownList.DataBind();

            Session["oDPMFractDropDownList"] = ds5.Tables[0].Rows[0]["PS_Deposit_Pay_Method"].ToString();

            TextEuroRateP.Text = ds5.Tables[0].Rows[0]["PS_EURO_Rate"].ToString(); 
             TextAusRateP.Text = ds5.Tables[0].Rows[0]["PS_AUS_Rate"].ToString(); 
             TextGbpRateP.Text = ds5.Tables[0].Rows[0]["PS_GBP_Rate"].ToString(); 
             TextIdaRateP.Text = ds5.Tables[0].Rows[0]["PS_IDA_Rate"].ToString();


            DataSet dsec65 = Queries2.LoadYearOfInt();

            YearOfIntDropDownList.DataSource = dsec65;
            YearOfIntDropDownList.DataTextField = "name";
            YearOfIntDropDownList.DataValueField = "Year_Int_ID";
            YearOfIntDropDownList.AppendDataBoundItems = true;
            YearOfIntDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["PS_YOInterest"].ToString(), ""));
            YearOfIntDropDownList.DataBind();

            Session["oYearOfIntDropDownList"] = ds5.Tables[0].Rows[0]["PS_YOInterest"].ToString();

            TextAdminFees.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees"]);
            string kk = ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees"].ToString();


            DataSet Pcard = Queries2.LoadCCardType();
            CardPrimaryDropDownList.DataSource = Pcard;
            CardPrimaryDropDownList.DataTextField = "Card_Type_Name";
            CardPrimaryDropDownList.DataValueField = "Card_Type_Name";
            CardPrimaryDropDownList.AppendDataBoundItems = true;
            CardPrimaryDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Payment_Details_PCard_Type"].ToString(), ""));
            CardPrimaryDropDownList.DataBind();

            Session["oCardPrimaryDropDownList"] = ds5.Tables[0].Rows[0]["Payment_Details_PCard_Type"].ToString();

            TextIssuingP.Text = ds5.Tables[0].Rows[0]["Payment_Details_PIssuing_Bank"].ToString();
            TextCardNumbP.Text = ds5.Tables[0].Rows[0]["Payment_Details_PCredit_Card_No"].ToString();
            TextCardHNameP.Text = ds5.Tables[0].Rows[0]["Payment_Details_PCard_Holders_Name"].ToString();
            TextExpMonthP.Text = ds5.Tables[0].Rows[0]["Payment_Details_PExpiry"].ToString();
            TextSecurityP.Text = ds5.Tables[0].Rows[0]["Payment_Details_PSecurity_No"].ToString();
            TextPrimaryCCard.Text = ds5.Tables[0].Rows[0]["Payment_Details_PComments"].ToString();
            TextPrimaryCCard2.Text = ds5.Tables[0].Rows[0]["Payment_Details_PComments"].ToString();

            Session["oTextIssuingP"] = ds5.Tables[0].Rows[0]["Payment_Details_PIssuing_Bank"].ToString();
            Session["oTextCardNumbP"] = ds5.Tables[0].Rows[0]["Payment_Details_PCredit_Card_No"].ToString();
            Session["oTextCardHNameP"] = ds5.Tables[0].Rows[0]["Payment_Details_PCard_Holders_Name"].ToString();
            Session["oTextExpMonthP"] = ds5.Tables[0].Rows[0]["Payment_Details_PExpiry"].ToString();
            Session["oTextSecurityP"] = ds5.Tables[0].Rows[0]["Payment_Details_PSecurity_No"].ToString();
            Session["oTextPrimaryCCard"] = ds5.Tables[0].Rows[0]["Payment_Details_PComments"].ToString();
            Session["oTextPrimaryCCard2"] = ds5.Tables[0].Rows[0]["Payment_Details_PComments"].ToString();



            DataSet Scard = Queries2.LoadCCardType();
            CardSecondaryDropDownList.DataSource = Scard;
            CardSecondaryDropDownList.DataTextField = "Card_Type_Name";
            CardSecondaryDropDownList.DataValueField = "Card_Type_Name";
            CardSecondaryDropDownList.AppendDataBoundItems = true;
            CardSecondaryDropDownList.Items.Insert(0, new ListItem("", ""));
            CardSecondaryDropDownList.DataBind();

            //Session["oTextPrimaryCCard2"] = ds5.Tables[0].Rows[0]["Payment_Details_PComments"].ToString();


            TextIssuingS.Text = ds5.Tables[0].Rows[0]["Payment_Details_SIssuing_Bank"].ToString(); ;
            TextCardNumbS.Text = ds5.Tables[0].Rows[0]["Payment_Details_SCredit_Card_No"].ToString(); ;
            TextCardHNameS.Text = ds5.Tables[0].Rows[0]["Payment_Details_SCard_Holders_Name"].ToString(); ;
            TextExpiryS.Text = ds5.Tables[0].Rows[0]["Payment_Details_SExpiry"].ToString(); ;
            TextSecurityS.Text = ds5.Tables[0].Rows[0]["Payment_Details_SSecurity_No"].ToString(); ;
            TextSecondaryCCard.Text = ds5.Tables[0].Rows[0]["Payment_Details_SComments"].ToString();
            TextCPADepoComment.Text = ds5.Tables[0].Rows[0]["PS_Deposit_Comment"].ToString();

            Session["oPS_Deposit_Comment"] = ds5.Tables[0].Rows[0]["PS_Deposit_Comment"].ToString();

            string fdepo1 = ds5.Tables[0].Rows[0]["Payment_Details_PFor_Depo"].ToString();

            if(fdepo1 == "True")
            {
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "checkpp();", true);
            }


            //Session["oDealDrawer"].ToString()
            if (Session["oDealDrawer"].ToString() == "Cancel")
            {
                //string pp = ds5.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();
                //string pp2 = ds5.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString();
                //CGroupvenueDropDownList.Items.Add(ds5.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString());

                // CReasonDropDownList.Items.Add(ds5.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString());

                //CancelDateTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_Fractional_Int"].ToString();
                DataSet ds6 = Queries2.LoadStatusChange(fracid, Session["oDealDrawer"].ToString());
                oCGroupvenueDropDownList = ds6.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();
                Session["oCGroupvenueDropDownList"] = ds5.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();

                oCReasonDropDownList = ds6.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString();
                Session["oCReasonDropDownList"] = ds5.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString();

                DataSet Cancelvenue2 = Queries2.LoadSubVenue2(GroupVenueDropDownListval);
                CGroupvenueDropDownList.DataSource = Cancelvenue2;
                CGroupvenueDropDownList.DataTextField = "SVenue_Name";
                CGroupvenueDropDownList.DataValueField = "SVenue_Name";
                CGroupvenueDropDownList.AppendDataBoundItems = true;
                CGroupvenueDropDownList.Items.Insert(0, new ListItem(ds6.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString(), ""));
                CGroupvenueDropDownList.DataBind();

                Session["oCGroupvenueDropDownList"] = ds5.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();

                //oCGroupvenueDropDownList = ds6.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();

                //oCReasonDropDownList = ds6.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString();


                DataSet CanRea2 = Queries2.LoadCancelReason();
                CReasonDropDownList.DataSource = CanRea2;
                CReasonDropDownList.DataTextField = "CR_Reasons";
                CReasonDropDownList.DataValueField = "CR_Reasons";
                CReasonDropDownList.AppendDataBoundItems = true;
                CReasonDropDownList.Items.Insert(0, new ListItem(ds6.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString(), ""));
                CReasonDropDownList.DataBind();



                DataSet CanType2 = Queries2.LoadCancelType(ds5.Tables[0].Rows[0]["Contract_Finance_Cool_OnOff"].ToString());
                CTypeDropDownList.DataSource = CanType2;
                CTypeDropDownList.DataTextField = "CT_Type";
                CTypeDropDownList.DataValueField = "CT_Type";
                CTypeDropDownList.AppendDataBoundItems = true;
                CTypeDropDownList.Items.Insert(0, new ListItem(ds6.Tables[0].Rows[0]["SC_Cancel_Type"].ToString(), ""));
                CTypeDropDownList.DataBind();

                Session["oCReasonDropDownList"] = ds5.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();

                Session["oSC_Cancel_Type"] = ds6.Tables[0].Rows[0]["SC_Cancel_Type"].ToString();


                if(Session["oSC_Cancel_Type"].ToString() == "WITHDRAW")
                {

                    string datepc2 = String.Format("{0:dd-MM-yyyy}", ds6.Tables[0].Rows[0]["SC_Withdraw_Date"]);
                    if (datepc2 == " " || datepc2 == "01-01-1900")

                    //    string datepc1 = Convert.ToDateTime(ds6.Tables[0].Rows[0]["SC_Cancel_Date"]).ToString("yyyy-MM-dd");
                    //if (datep1 == " " || datep1 == "1900-01-01")
                    {
                        WithdrawDateTextBox.Text = "";
                        Session["oSC_Withdraw_Date"] = "";

                    }
                    else
                    {
                        WithdrawDateTextBox.Text = datepc2;
                        Session["oSC_Withdraw_Date"] = datepc2;

                    }

                }


                    Session["oSC_Cancel_Comment"]= ds5.Tables[0].Rows[0]["SC_Cancel_Comment"].ToString();


                string datepc1 = String.Format("{0:dd-MM-yyyy}", ds6.Tables[0].Rows[0]["SC_Cancel_Date"]);
                if (datepc1 == " " || datepc1 == "01-01-1900")

                //    string datepc1 = Convert.ToDateTime(ds6.Tables[0].Rows[0]["SC_Cancel_Date"]).ToString("yyyy-MM-dd");
                //if (datep1 == " " || datep1 == "1900-01-01")
                {
                    CancelDateTextBox.Text = "";
                    CancelDateTextBoxDummy.Text = "";

                }
                else
                {
                    CancelDateTextBox.Text = datepc1;
                    CancelDateTextBoxDummy.Text = datepc1;
                }
                oCancelDateTextBox = CancelDateTextBox.Text;
                Session["oCancelDateTextBox"] = oCancelDateTextBox;//ds5.Tables[0].Rows[0]["SC_Cancel_Date"].ToString();
            }

            string usepayprotect = ds5.Tables[0].Rows[0]["Finance_Details_PayProtect"].ToString();
            Session["ousepayprotect"] = ds5.Tables[0].Rows[0]["Finance_Details_PayProtect"].ToString();

            if (usepayprotect=="Yes")
            {
                UsePayProtectCheckBox.Checked = true;
            }
            else
            {
                UsePayProtectCheckBox.Checked = false;
            }

Session["exrate"]= ds5.Tables[0].Rows[0]["PS_ERate_INR"].ToString();
            TextBoxTempTDComment.Text = ds5.Tables[0].Rows[0]["PS_TP_Comment"].ToString();
            Session["oPS_TP_Comment"] = ds5.Tables[0].Rows[0]["PS_TP_Comment"].ToString();



            Session["oPS_Deposit_USD"] = ds5.Tables[0].Rows[0]["PS_Deposit_USD"].ToString();
           // string testff= ds5.Tables[0].Rows[0]["PS_Deposit_USD"].ToString();
            Session["oPS_Country_Tax_USD"] = ds5.Tables[0].Rows[0]["PS_Country_Tax_USD"].ToString();
            Session["oContract_Finance_Purchase_Price_USD"] = ds5.Tables[0].Rows[0]["Contract_Finance_Purchase_Price_USD"].ToString();
            Session["oContract_Finance_Admin_Fees_USD"] = ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees_USD"].ToString();


            if (conttype == "Fractional")
            {

                Session["ECGGlobContClub"] = "";
                ResortDropDownListF.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Resort"].ToString());
                Session["oResortDropDownListF"] = ds5.Tables[0].Rows[0]["Contract_Fractional_Resort"].ToString();
                //ResidenceNoDropDownListF.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_No"].ToString());
                ResidenceTypeDropDownListF.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_Type"].ToString());

                Session["oResidenceNoDropDownListF"] = ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_No"].ToString();
                Session["oResidenceTypeDropDownListF"] = ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_Type"].ToString();


                DataSet ResiNoF = Queries2.LoadResidenceNo(ds5.Tables[0].Rows[0]["Contract_Fractional_Resort"].ToString(), Session["office2"].ToString());
                ResidenceNoDropDownListF.DataSource = ResiNoF;
                ResidenceNoDropDownListF.DataTextField = "Contract_Residence_Name";
                ResidenceNoDropDownListF.DataValueField = "Contract_Residence_Name";
                ResidenceNoDropDownListF.AppendDataBoundItems = true;
                ResidenceNoDropDownListF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_No"].ToString(), ""));
                ResidenceNoDropDownListF.DataBind();




                //FractionalIDropDownListF.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Fractional_Int"].ToString());
                DataSet dsec21 = Queries2.LoadFractionalI();
                FractionalIDropDownListF.DataSource = dsec21;
                FractionalIDropDownListF.DataTextField = "Contract_Fractional_Int_Name";
                FractionalIDropDownListF.DataValueField = "Contract_Fractional_Int_Name";
                FractionalIDropDownListF.AppendDataBoundItems = true;
                FractionalIDropDownListF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Fractional_Fractional_Int"].ToString(), ""));
                FractionalIDropDownListF.DataBind();


                Session["oFractionalIDropDownListF"] = ds5.Tables[0].Rows[0]["Contract_Fractional_Fractional_Int"].ToString();

                //EntitlementFracDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Entitle"].ToString());
                DataSet dsEnt = Queries2.LoadEntitlement();
                EntitlementFracDropDownList.DataSource = dsEnt;
                EntitlementFracDropDownList.DataTextField = "Entitlement_Name";
                EntitlementFracDropDownList.DataValueField = "Entitlement_Name";
                EntitlementFracDropDownList.AppendDataBoundItems = true;
                EntitlementFracDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Fractional_Entitle"].ToString(), ""));
                EntitlementFracDropDownList.DataBind();

                Session["oEntitlementFracDropDownList"] = ds5.Tables[0].Rows[0]["Contract_Fractional_Entitle"].ToString();

                TextFOccuF.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_First_Occu"].ToString();
                TextFDuration.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_Duration"].ToString();
                TextFOccuL.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_Last_Occu"].ToString();

                Session["oTextFOccuF"] = ds5.Tables[0].Rows[0]["Contract_Fractional_First_Occu"].ToString();
                Session["oTextFDuration"] = ds5.Tables[0].Rows[0]["Contract_Fractional_Duration"].ToString();
                Session["oTextFOccuL"] = ds5.Tables[0].Rows[0]["Contract_Fractional_Last_Occu"].ToString();


                ContractNoFractTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();
 TextBoxDummyleaseoff.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_Lease_Back"].ToString();

                Session["oContractNoFractTextBox"] = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();
                Session["oTextBoxDummyleaseoff"] = ds5.Tables[0].Rows[0]["Contract_Fractional_Lease_Back"].ToString();



                /* TextDepositF.Text = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();

                 TextAdmissFeesF.Text = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                 TextAdminFeesF.Text = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();

                 TextTotalPurchasePriceF.Text = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                 TextCountryTaxF.Text = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();

                 TextBalanceDueF.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                 TextBalanceDueFTD.Text = ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"].ToString();

                 TextNoOfInstallF.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();
                 string PANoOfInstallTF = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();*/



                Session["ODeposit"] =  ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                TextDepositP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit"]);
                TextDepoPPA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit_PA"]);
                TextAdmissFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Admission"]);
                TextAdminFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Administration"]);
                TextPpurchasePrice.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Total_Purchase"]);
                TextCountryTaxP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax"]);
                TextGrandTotalP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Grand_Total"]);
                TextPBalaceDPA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"]);
                TextPBalaceDPATOPD.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"]);
                TextPPANoInstall.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();

                Session["oTextDepoPPA"] = ds5.Tables[0].Rows[0]["PS_Deposit_PA"].ToString();
                Session["oTextAdmissFeesP"] = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                Session["oTextAdminFeesP"] = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
                Session["oTextPpurchasePrice"] = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                Session["oTextCountryTaxP"] = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                Session["oTextGrandTotalP"] = ds5.Tables[0].Rows[0]["PS_Grand_Total"].ToString();
                Session["oTextPBalaceDPA"] = ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"].ToString();
                Session["oTextPBalaceDPATOPD"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                Session["oTextPPANoInstall"] = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();




                // datepicker10.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();

                // string datepc1 = String.Format("{0:dd-MM-yyyy}", ds5D.Tables[0].Rows[0]["PS_PA_FInstall_Date"]);
                /* string datepc1 = ds5D.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();
                 if (datepc1 == " " || datepc1 == "01-01-1900")



                   //  string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                // if (datep1 == " " || datep1 == "1900-01-01")
                 {
                     datepicker10.Text = "";
                 }
                 else
                 {
                     datepicker10.Text = datepc1;
                 }*/


                string datepc1 = ds5D.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();
                Session["oPS_PA_FInstall_Date"] = datepc1;// ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();

                if (datepc1 == " " || datepc1 == "01-01-1900")



                // string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                //if (datep1 == " " || datep1 == "1900-01-01")
                {
                    datepicker8.Text = "";
                }
                else
                {
                    datepicker8.Text = datepc1;
                }


		if(FinanceCurrencyDropDownList.SelectedItem.Text=="INR")
                {
                    TextBoxCGST.Text= string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax_CGST"]);
                    TextBoxSGST.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax_SGST"]);

                    Session["oTextBoxCGST"] = ds5.Tables[0].Rows[0]["PS_Country_Tax_CGST"].ToString();
                    Session["oTextBoxSGST"] = ds5.Tables[0].Rows[0]["PS_Country_Tax_SGST"].ToString();

                }

                TextPPAAmountInstall.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"]);
                TextPPAFInstall.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"]);
                TextPBalanceDDates.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                TextPBalanceDDates2.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();


               

                /*TextPDepositSA.Text = ds5.Tables[0].Rows[0]["PS_Deposit_SA"].ToString();
                TextAppliFeesP.Text = ds5.Tables[0].Rows[0]["PS_SA_Application"].ToString();
                TextAdminServiceP.Text = ds5.Tables[0].Rows[0]["PS_SA_Administration"].ToString();
                TextTotalServicePriceP.Text = ds5.Tables[0].Rows[0]["PS_Total_Service"].ToString();
                TextBalanceDueSAP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"].ToString();
                TextBalanceDDatesSAP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();
                TextBalanceDDatesSAP2.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates2"].ToString();*/
                TextRemarkP.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                TextRemarkP2.Text = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();

                TextTotalBalance.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["Total_Balance"]);

                Session["oTextPPAAmountInstall"] = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                Session["oTextPPAFInstall"] = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                Session["oTextPBalanceDDates"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                Session["oTextPBalanceDDates2"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();

                Session["oTextRemarkP"] = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                Session["oTextRemarkP2"] = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();
                Session["oTextTotalBalance"] = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();



                /* TextInstallAmtF.Text = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                 TextFirstInstallAmtF.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                 TextDueDatesPAF.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                 TextDueDatesPAF2.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();
                 TextTotalBalanceF.Text = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();

                 TextRemarksF.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                 TextRemarksF2.Text = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();


                 tPurchase.Text = TotalPurTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                 QDepo.Text = QualTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                 AmtCre.Text = AmountCreditTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                 CreCurr.Text =  AmountCreditCurrTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                 NoOfMonth.Text = NoMonthsTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                 RateOfInt.Text = RateInterestTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                 MonthlyRepay.Text = MonthRepayTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();*/


                tPurchase.Text = TotalPurTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                QDepo.Text = QualTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                AmtCre.Text = AmountCreditTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                CreCurr.Text = AmountCreditCurrTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                NoOfMonth.Text = NoMonthsTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                RateOfInt.Text = RateInterestTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                MonthlyRepay.Text = MonthRepayTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();
		TextFinaStartDate.Text = ds5.Tables[0].Rows[0]["Finance_Details_Finance_Date"].ToString();

               /*  TextBoxDIGSTRate.Text= TextBoxINRIGSTRate.Text =ds5.Tables[0].Rows[0]["PFDetails_IGST_Rate"].ToString(); 
                 TextBoxDIntRate.Text = TextBoxINRIntRate.Text = ds5.Tables[0].Rows[0]["PFDetails_Interest_Rate"].ToString();
                TextBoxDDcocuFees.Text = TextBoxINRDoccuFees.Text = ds5.Tables[0].Rows[0]["PFDetails_Doccu_Fees"].ToString();
                TextBoxDIGSTAmt.Text = TextBoxIGSTAmt.Text = ds5.Tables[0].Rows[0]["PFDetails_IGST_Amount"].ToString();
                TextBoxDNoEMI.Text = TextBoxINREMI.Text = ds5.Tables[0].Rows[0]["PFDetails_No_Of_EMI"].ToString();
                TextBoxDEMIAmt.Text = TextBoxINREMIAmt.Text = ds5.Tables[0].Rows[0]["PFDetails_EMI_Install"].ToString();
                TextBoxDFinaMonth.Text = TextBoxINRFinaMonth.Text = ds5.Tables[0].Rows[0]["PFDetails_Finance_Month"].ToString();*/



                TextInitDepo.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Initial_Deposit"]);
                TextBalDepo.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Bal_Deposit"]);
                TextPrimaryCCard2.Text = ds5.Tables[0].Rows[0]["PS_CPA_Comment"].ToString();

                //TextBoxNBDP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();


                 string baldatep = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_Deposit_Date"]);


                if (baldatep == " " || baldatep == "01-01-1900")


                {
                    TextBoxNBDP.Text = "";
                }
                else
                {
                    TextBoxNBDP.Text = baldatep;
                }

                Session["oPS_Deposit_Date"] = baldatep;//ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();




                // string baldatep = ds5D.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();


                Session["oTotalPurTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                Session["oQualTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                Session["oAmountCreditTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                Session["oAmountCreditCurrTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                Session["oNoMonthsTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                Session["oRateInterestTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();

                Session["oMonthRepayTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();
                Session["oTextInitDepo"] = ds5.Tables[0].Rows[0]["PS_Initial_Deposit"].ToString();
                Session["oTextBalDepo"] = ds5.Tables[0].Rows[0]["PS_Bal_Deposit"].ToString();
                Session["oTextPrimaryCCard2"] = ds5.Tables[0].Rows[0]["PS_CPA_Comment"].ToString();
              //  Session["oPS_Deposit_Date"] = ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();
               

                if (baldatep == " " || baldatep == "01-01-1900")


                {
                    TextBoxNBDP.Text = "";
                }
                else
                {
                    TextBoxNBDP.Text = baldatep;
                }



                TextIniInstP.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                TextIniInstAmtP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"]);

                Session["oTextIniInstP"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                Session["oTextIniInstAmtP"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"].ToString();



                //tPurchase1 = tPurchase.Text;
                //QDepo1 = QDepo.Text;
                //AmtCre1 = AmtCre.Text;
                //CreCurr1 = CreCurr.Text;
                //NoOfMonth1 = NoOfMonth.Text;
                //RateOfInt1 = RateOfInt.Text;
                //MonthlyRepay1 = MonthlyRepay.Text;

                //string NoofPoints = TextNoPoints.Text;
                //string PointsEntitle = .SelectedItem.Text;
                //string PointsMemFees = TextPMemFees.Text;
                //string PointsPropFees = TextPPropFees.Text;
                //string PointsFOccu = TextPFOccu.Text;
                //string PointsDura = TextPDura.Text;
                //string PointsLOccu = TextPLOccu.Text;


                string CheckBalloonP = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                Session["oPS_Balloon_Pay"] = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                if (CheckBalloonP == "BP")
                {
                    CheckBoxBalloonP.Checked = true;
                }
                else
                {
                    CheckBoxBalloonP.Checked = false;
                }


                string fcheckbox = ds5.Tables[0].Rows[0]["Contract_finance_OddEven50"].ToString();

                Session["oContract_finance_OddEven50"] = ds5.Tables[0].Rows[0]["Contract_finance_OddEven50"].ToString();

                if (fcheckbox == "Yes")
                {
                    FCheckBox1.Checked = true;
                }
                else
                {
                    FCheckBox1.Checked = false;
                }


               /* string CheckBalloonF = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                if (CheckBalloonF == "BP")
                {
                    CheckBoxBalloonF.Checked = true;
                }
                else
                {
                    CheckBoxBalloonF.Checked = false;
                }*/




             /*   TextInitDepoF.Text = ds5.Tables[0].Rows[0]["PS_Initial_Deposit"].ToString();
                TextBalDepoF.Text = ds5.Tables[0].Rows[0]["PS_Bal_Deposit"].ToString();

               // string baldatef = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_Deposit_Date"]);
                string baldatef = ds5D.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();
                if (baldatef == " " || baldatef == "01-01-1900")


                {
                    TextBoxNBDF.Text = "";
                }
                else
                {
                    TextBoxNBDF.Text = baldatef;
                }


                TextIniInstF.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                TextIniInstAmtF.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"].ToString();

                */

                //tPurchase1 = tPurchase.Text;
                //QDepo1 = QDepo.Text;
                //AmtCre1 = AmtCre.Text;
                //CreCurr1 = CreCurr.Text;
                //NoOfMonth1 = NoOfMonth.Text;
                //RateOfInt1 = RateOfInt.Text;
                //MonthlyRepay1 = MonthlyRepay.Text;

                ////System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                ////string var1, car1;
                //if (PANoOfInstallTF != "" || PANoOfInstallTF != "0")
                //{
                //    for (i = 1; i <= int.Parse(PANoOfInstallTF); i++)
                //    {
                //        text11 = "textBoxN_" + i + "1";
                //        desc = Request[text11];

                //        text12 = "textBoxN_" + i + "2";
                //        amot1 = Request[text12];
                //        //text15 = "textBoxN_" + i + "3";
                //        //amot2 = Request[text15];
                //        text13 = "textBox_" + i + "3";
                //        date = Request[text13];
                //        text14 = "textBox_" + i + "4";
                //        curr = Request[text14];


                //       // Request.Form[text11] = "hi";



                //        // if (int.Parse(amot1) != 0)
                //        //{
                //        //string finaInstI = Queries2.getFinanceInstallID(officeo);
                //        // int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                //        // }


                //    }


                //}



		DataSet dsec67 = Queries2.LoadContractVenueVP(vencountry, ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString());
                ContractVenueVPDropDownList.DataSource = dsec67;
                ContractVenueVPDropDownList.DataTextField = "CVenue_Venue";
                ContractVenueVPDropDownList.DataValueField = "CVenue_Venue";
                ContractVenueVPDropDownList.AppendDataBoundItems = true;
                ContractVenueVPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString(), ""));
                ContractVenueVPDropDownList.DataBind();

                Session["oContractVenueVPDropDownList"] = ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString();


            }
            else if (conttype == "Points")
            {
                ContractClubPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["CT_Points_Club"].ToString());
                Session["ECGGlobContClub"] = "";
               // Session["EGGlobContClub"] 
               string pclub= ds5.Tables[0].Rows[0]["CT_Points_Club"].ToString();
                Session["ECGGlobContClub"] = pclub;
                DataSet ds2 = Queries2.LoadEntitlement();
                EntitlementPoinDropDownList.DataSource = ds2;
                EntitlementPoinDropDownList.DataTextField = "Entitlement_Name";
                EntitlementPoinDropDownList.DataValueField = "Entitlement_Name";
                EntitlementPoinDropDownList.AppendDataBoundItems = true;
                EntitlementPoinDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["CT_Points_Entle"].ToString(), ""));
                EntitlementPoinDropDownList.DataBind();

                Session["oEntitlementPoinDropDownList"] = ds5.Tables[0].Rows[0]["CT_Points_Entle"].ToString();


                //EntitlementPoinDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_Type"].ToString());
                //string ContClub = .SelectedItem.Text;
                TextNoPoints.Text = ds5.Tables[0].Rows[0]["CT_Points_Noof_Points"].ToString();
                TextMemFeesp.Text = TextPMemFees.Text = ds5.Tables[0].Rows[0]["CT_Points_Member_fees"].ToString();
                TextPropFeesp.Text = TextPPropFees.Text = ds5.Tables[0].Rows[0]["CT_Points_Points_Property_fees"].ToString();
                TextPFOccu.Text = ds5.Tables[0].Rows[0]["CT_Points_FYear_Occ"].ToString();
                TextPDura.Text = ds5.Tables[0].Rows[0]["CT_Points_Duration"].ToString();
                TextPLOccu.Text = ds5.Tables[0].Rows[0]["CT_Points_LYear_Occ"].ToString();

                ContractNoPointsTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();


                Session["ODeposit"] =  ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                TextDepositP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit"]);
                TextDepoPPA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit_PA"]);
                TextAdmissFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Admission"]);
                TextAdminFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Administration"]);
                TextPpurchasePrice.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Total_Purchase"]);

                if(FinanceCurrencyDropDownList.SelectedItem.Text=="INR")
                {
                    TextBoxCGST.Text= string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax_CGST"]);
                    TextBoxSGST.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax_SGST"]);
                    Session["oTextBoxCGST"] = ds5.Tables[0].Rows[0]["PS_Country_Tax_CGST"].ToString();
                    Session["oTextBoxSGST"] = ds5.Tables[0].Rows[0]["PS_Country_Tax_SGST"].ToString();
                }

                

                

                TextCountryTaxP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax"]);
                TextGrandTotalP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Grand_Total"]);
                TextPBalaceDPA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"]);
                TextPBalaceDPATOPD.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"]);
                TextPPANoInstall.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();



                // datepicker10.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();

               // string datepc1 = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]);
                string datepc1 = ds5D.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();


                Session["oTextNoPoints"] = ds5.Tables[0].Rows[0]["CT_Points_Noof_Points"].ToString();
                Session["oTextMemFeesp"] = ds5.Tables[0].Rows[0]["CT_Points_Member_fees"].ToString();
                Session["oTextPropFeesp"] = ds5.Tables[0].Rows[0]["CT_Points_Points_Property_fees"].ToString();
                Session["oTextPFOccu"] = ds5.Tables[0].Rows[0]["CT_Points_FYear_Occ"].ToString();
                Session["oTextPDura"] = ds5.Tables[0].Rows[0]["CT_Points_Duration"].ToString();
                Session["oTextPLOccu"] = ds5.Tables[0].Rows[0]["CT_Points_LYear_Occ"].ToString();
                Session["oTextDepoPPA"] = ds5.Tables[0].Rows[0]["PS_Deposit_PA"].ToString();
                Session["oTextAdmissFeesP"] = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();

                Session["oTextAdminFeesP"] = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
              
                Session["oTextPpurchasePrice"] = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();

                Session["oTextCountryTaxP"] = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                Session["oTextGrandTotalP"] = ds5.Tables[0].Rows[0]["PS_Grand_Total"].ToString();
                Session["oTextPBalaceDPA"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                Session["oTextPBalaceDPATOPD"] = ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"].ToString();
                Session["oTextPPANoInstall"] = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();

                Session["oPS_PA_FInstall_Date"] = datepc1;// ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();










                if (datepc1 == " " || datepc1 == "01-01-1900")



                   // string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                //if (datep1 == " " || datep1 == "1900-01-01")
                {
                    datepicker8.Text = "";
                }
                else
                {
                    datepicker8.Text = datepc1;
                }


                TextPPAAmountInstall.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"]);
                TextPPAFInstall.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"]);
                TextPBalanceDDates.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                TextPBalanceDDates2.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();
                TextPDepositSA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit_SA"]);
                TextAppliFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_SA_Application"]);
                TextAdminServiceP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_SA_Administration"]);
                TextTotalServicePriceP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Total_Service"]);
                TextBalanceDueSAP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"]);
                TextBalanceDDatesSAP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();
                TextBalanceDDatesSAP2.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates2"].ToString();
                TextRemarkP.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                TextRemarkP2.Text = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();

                TextTotalBalance.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["Total_Balance"]);


                tPurchase.Text = TotalPurTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                QDepo.Text= QualTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                AmtCre.Text= AmountCreditTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                CreCurr.Text=AmountCreditCurrTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                NoOfMonth.Text=NoMonthsTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                RateOfInt.Text=RateInterestTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                MonthlyRepay.Text= MonthRepayTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();

                TextInitDepo.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Initial_Deposit"]);
                TextBalDepo.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Bal_Deposit"]);
                TextPrimaryCCard2.Text = ds5.Tables[0].Rows[0]["PS_CPA_Comment"].ToString();
                //TextBoxNBDP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();


                 string baldatep = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_Deposit_Date"]);
                //  string baldatep = ds5D.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();

                if (baldatep == " " || baldatep == "01-01-1900")


                {
                    TextBoxNBDP.Text = "";
                }
                else
                {
                    TextBoxNBDP.Text = baldatep;
                }

                Session["oPS_Deposit_Date"] = baldatep;//ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();

                Session["oTextPPAAmountInstall"] = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                Session["oTextPPAFInstall"] = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                Session["oTextPBalanceDDates"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                Session["oTextPBalanceDDates2"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();
                Session["oTextPDepositSA"] = ds5.Tables[0].Rows[0]["PS_Deposit_SA"].ToString();
                Session["oTextAppliFeesP"] = ds5.Tables[0].Rows[0]["PS_SA_Application"].ToString();
                Session["oTextAdminServiceP"] = ds5.Tables[0].Rows[0]["PS_SA_Administration"].ToString();
               

                Session["oTextTotalServicePriceP"] = ds5.Tables[0].Rows[0]["PS_Total_Service"].ToString();
                Session["oTextBalanceDueSAP"] = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"].ToString();
                Session["oTextBalanceDDatesSAP"] = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();
                Session["oTextBalanceDDatesSAP2"] = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates2"].ToString();

                Session["oTextRemarkP"] = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                Session["oTextRemarkP2"] = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();

                Session["oTextTotalBalance"] = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();


                Session["oTotalPurTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                Session["oQualTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                Session["oAmountCreditTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                Session["oAmountCreditCurrTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                Session["oNoMonthsTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                Session["oRateInterestTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                Session["oMonthRepayTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();
                Session["oTextInitDepo"] = ds5.Tables[0].Rows[0]["PS_Initial_Deposit"].ToString();
                Session["oTextBalDepo"] = ds5.Tables[0].Rows[0]["PS_Bal_Deposit"].ToString();
                Session["oTextPrimaryCCard2"] = ds5.Tables[0].Rows[0]["PS_CPA_Comment"].ToString();
                


              


                if (baldatep == " " || baldatep == "01-01-1900")


                {
                    TextBoxNBDP.Text = "";
                }
                else
                {
                    TextBoxNBDP.Text = baldatep;
                }



                TextIniInstP.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                TextIniInstAmtP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"]);
                //tPurchase1 = tPurchase.Text;
                //QDepo1 = QDepo.Text;
                //AmtCre1 = AmtCre.Text;
                //CreCurr1 = CreCurr.Text;
                //NoOfMonth1 = NoOfMonth.Text;
                //RateOfInt1 = RateOfInt.Text;
                //MonthlyRepay1 = MonthlyRepay.Text;

                //string NoofPoints = TextNoPoints.Text;
                //string PointsEntitle = .SelectedItem.Text;
                //string PointsMemFees = TextPMemFees.Text;
                //string PointsPropFees = TextPPropFees.Text;
                //string PointsFOccu = TextPFOccu.Text;
                //string PointsDura = TextPDura.Text;
                //string PointsLOccu = TextPLOccu.Text;

                string pcheckbox = ds5.Tables[0].Rows[0]["Contract_finance_OddEven50"].ToString();

                if (pcheckbox == "Yes")
                {
                    PCheckBox1.Checked = true;
                }
                else
                {
                    PCheckBox1.Checked = false;
                }


                string CheckBalloonP = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                if (CheckBalloonP == "BP")
                {
                    CheckBoxBalloonP.Checked = true;
                }
                else
                {
                    CheckBoxBalloonP.Checked = false;
                }



		DataSet dsec67 = Queries2.LoadContractVenueVP(vencountry, ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString());
                ContractVenueVPDropDownList.DataSource = dsec67;
                ContractVenueVPDropDownList.DataTextField = "CVenue_Venue";
                ContractVenueVPDropDownList.DataValueField = "CVenue_Venue";
                ContractVenueVPDropDownList.AppendDataBoundItems = true;
                ContractVenueVPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString(), ""));
                ContractVenueVPDropDownList.DataBind();

                Session["oTextIniInstP"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                Session["oTextIniInstAmtP"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"].ToString();
                Session["oContract_finance_OddEven50"] = ds5.Tables[0].Rows[0]["Contract_finance_OddEven50"].ToString();
                Session["oPS_Balloon_Pay"] = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();
                Session["oContractVenueVPDropDownList"] = ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString();



            }
           else if (conttype == "Trade Into Points")
            {


		DataSet dsec67 = Queries2.LoadContractVenueVP(vencountry, ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString());
                ContractVenueVPDropDownList.DataSource = dsec67;
                ContractVenueVPDropDownList.DataTextField = "CVenue_Venue";
                ContractVenueVPDropDownList.DataValueField = "CVenue_Venue";
                ContractVenueVPDropDownList.AppendDataBoundItems = true;
                ContractVenueVPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString(), ""));
                ContractVenueVPDropDownList.DataBind();

                Session["oContractVenueVPDropDownList"] = ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString();

                ContTypeTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Cont_Type"].ToString());

                string subconttype = ds5.Tables[0].Rows[0]["TP_Cont_Type"].ToString();

                //TextNoPoints.Text = ds5.Tables[0].Rows[0]["CT_Points_Noof_Points"].ToString();

                if (subconttype == "From Points To Points")
                {

                    TextOldAgreeNoTP1.Text = ds5.Tables[0].Rows[0]["TP_Old_Agree_Numb"].ToString();
                    ContractClubTPDropDownList1.Items.Add(ds5.Tables[0].Rows[0]["TP_Old_Club"].ToString());
                    TextOldNoPointsTP.Text = ds5.Tables[0].Rows[0]["TP_Old_No_Points"].ToString();
                    DataSet dsec46 = Queries2.LoadEntitlement();
                    EntitlementDropDownList1.DataSource = dsec46;
                    EntitlementDropDownList1.DataTextField = "Entitlement_Name";
                    EntitlementDropDownList1.DataValueField = "Entitlement_Name";
                    EntitlementDropDownList1.AppendDataBoundItems = true;
                    EntitlementDropDownList1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString(), ""));
                    EntitlementDropDownList1.DataBind();
                    // EntitlementDropDownList1.Items.Add(ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString());


                    Session["oTextOldAgreeNoTP1"] = ds5.Tables[0].Rows[0]["TP_Old_Agree_Numb"].ToString();
                    Session["oContractClubTPDropDownList1"] = ds5.Tables[0].Rows[0]["TP_Old_Club"].ToString();
                    Session["oTextOldNoPointsTP"] = ds5.Tables[0].Rows[0]["TP_Old_No_Points"].ToString();
                    Session["oEntitlementDropDownList1"] = ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString();

                }
                else if (subconttype == "From Weeks To Points")
                {
                    TextOldAgreeNoTP2.Text = ds5.Tables[0].Rows[0]["TP_Old_Agree_Numb"].ToString();
                    DataSet dsec47 = Queries2.LoadContResort(office);
                    ResortTPDropDownList.DataSource = dsec47;
                    ResortTPDropDownList.DataTextField = "Contract_Resort_Name";
                    ResortTPDropDownList.DataValueField = "Contract_Resort_Name";
                    ResortTPDropDownList.AppendDataBoundItems = true;
                    ResortTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Resort"].ToString(), ""));
                    ResortTPDropDownList.DataBind();

                    //ResortTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Resort"].ToString());
                    DataSet dsec50 = Queries2.LoadApartType();
                    AppartmentTypeTPDropDownList.DataSource = dsec50;
                    AppartmentTypeTPDropDownList.DataTextField = "Apart_Type_Name";
                    AppartmentTypeTPDropDownList.DataValueField = "Apart_Type_Name";
                    AppartmentTypeTPDropDownList.AppendDataBoundItems = true;
                    AppartmentTypeTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Appartment_Type"].ToString(), ""));
                    AppartmentTypeTPDropDownList.DataBind();

                    //AppartmentTypeTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Appartment_Type"].ToString());
                    DataSet ds49 = Queries2.LoadContNumbOccu();
                    NumbOccuTPDropDownList.DataSource = ds49;
                    NumbOccuTPDropDownList.DataTextField = "Numb_Occu_Numb";
                    NumbOccuTPDropDownList.DataValueField = "Numb_Occu_Numb";
                    NumbOccuTPDropDownList.AppendDataBoundItems = true;
                    NumbOccuTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Num_Occ"].ToString(), ""));
                    NumbOccuTPDropDownList.DataBind();

                    //NumbOccuTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Num_Occ"].ToString());
                    DataSet ds48 = Queries2.LoadContPeriod();
                    PeriodTPDropDownList.DataSource = ds48;
                    PeriodTPDropDownList.DataTextField = "Period_Name";
                    PeriodTPDropDownList.DataValueField = "Period_Name";
                    PeriodTPDropDownList.AppendDataBoundItems = true;
                    PeriodTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Period"].ToString(), ""));
                    PeriodTPDropDownList.DataBind();

                    // PeriodTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Period"].ToString());
                    DataSet ds44 = Queries2.LoadSeasType();
                    SeasonTPDropDownList.DataSource = ds44;
                    SeasonTPDropDownList.DataTextField = "Season_Name";
                    SeasonTPDropDownList.DataValueField = "Season_Name";
                    SeasonTPDropDownList.AppendDataBoundItems = true;
                    SeasonTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Season"].ToString(), ""));
                    SeasonTPDropDownList.DataBind();

                    //SeasonTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Season"].ToString());
                    DataSet ds45 = Queries2.LoadEntitlement();
                    EntitleTPDropDownList.DataSource = ds45;
                    EntitleTPDropDownList.DataTextField = "Entitlement_Name";
                    EntitleTPDropDownList.DataValueField = "Entitlement_Name";
                    EntitleTPDropDownList.AppendDataBoundItems = true;
                    EntitleTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString(), ""));
                    EntitleTPDropDownList.DataBind();

                    // EntitleTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString());
                    TextTPPoints.Text = ds5.Tables[0].Rows[0]["TP_Old_No_Points"].ToString();


                    Session["oTextOldAgreeNoTP2"] = ds5.Tables[0].Rows[0]["TP_Old_Agree_Numb"].ToString();
                    Session["oResortTPDropDownList"] = ds5.Tables[0].Rows[0]["TP_Resort"].ToString();
                    Session["oAppartmentTypeTPDropDownList"] = ds5.Tables[0].Rows[0]["TP_Appartment_Type"].ToString();
                    Session["oNumbOccuTPDropDownList"] = ds5.Tables[0].Rows[0]["TP_Num_Occ"].ToString();
                    Session["oPeriodTPDropDownList"] = ds5.Tables[0].Rows[0]["TP_Period"].ToString();
                    Session["oSeasonTPDropDownList"] = ds5.Tables[0].Rows[0]["TP_Season"].ToString();
                    Session["oEntitleTPDropDownList"] = ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString();
                    Session["oTP_Old_No_Points"] = ds5.Tables[0].Rows[0]["TP_Old_No_Points"].ToString();
                    



                }



                TextNewPointsTP.Text = ds5.Tables[0].Rows[0]["TP_New_No_Points"].ToString();
                TextTotalPointsTP.Text = ds5.Tables[0].Rows[0]["TP_Total_Points"].ToString();
                DataSet dsec18 = Queries2.LoadContractClub(Session["Gofficeo"].ToString());
                ContractClubTPDropDownList2.DataSource = dsec18;
                ContractClubTPDropDownList2.DataTextField = "Contract_Club_Name";
                ContractClubTPDropDownList2.DataValueField = "Contract_Club_Name";
                ContractClubTPDropDownList2.AppendDataBoundItems = true;
                ContractClubTPDropDownList2.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_New_CLub"].ToString(), ""));
                ContractClubTPDropDownList2.DataBind();
                Session["ECGGlobContClub"] = "";
               
                    string tpclub = ds5.Tables[0].Rows[0]["TP_New_CLub"].ToString();
                Session["ECGGlobContClub"] = tpclub;
                //ContractClubTPDropDownList2.Items.Add(ds5.Tables[0].Rows[0]["TP_New_CLub"].ToString());
                DataSet ds3 = Queries2.LoadEntitlement();
                EntitlementTPoinDropDownList.DataSource = ds3;
                EntitlementTPoinDropDownList.DataTextField = "Entitlement_Name";
                EntitlementTPoinDropDownList.DataValueField = "Entitlement_Name";
                EntitlementTPoinDropDownList.AppendDataBoundItems = true;
                EntitlementTPoinDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_New_Entitlement"].ToString(), ""));
                EntitlementTPoinDropDownList.DataBind();

                //EntitlementTPoinDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_New_Entitlement"].ToString());
                TextMemFeesp.Text = TextMembershipFeesTP.Text = ds5.Tables[0].Rows[0]["TP_Member_Fees"].ToString();
                TextPropFeesp.Text = TextPropertyFeesTP.Text = ds5.Tables[0].Rows[0]["TP_Property_Fees"].ToString();
                TextFYOccTP.Text = ds5.Tables[0].Rows[0]["TP_FY_Occu"].ToString();
                TextDurationTP.Text = ds5.Tables[0].Rows[0]["TP_Duration"].ToString();
                TextLYOccTP.Text = ds5.Tables[0].Rows[0]["TP_LY_Occu"].ToString();


                ContractNoTPTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();



               Session["ODeposit"] = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                TextDepositP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit"]);
                TextDepoPPA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit_PA"]);
                TextAdmissFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Admission"]);
                TextAdminFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Administration"]);
                TextPpurchasePrice.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Total_Purchase"]);
                TextCountryTaxP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax"]);
                TextGrandTotalP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Grand_Total"]);
                TextPBalaceDPA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"]);
                TextPBalaceDPATOPD.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"]);
                TextPPANoInstall.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();

                if (FinanceCurrencyDropDownList.SelectedItem.Text == "INR")
                {
                    TextBoxCGST.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax_CGST"]);
                    TextBoxSGST.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax_SGST"]);
                }


                Session["oTextNewPointsTP"] = ds5.Tables[0].Rows[0]["TP_New_No_Points"].ToString();
                Session["oTextTotalPointsTP"] = ds5.Tables[0].Rows[0]["TP_Total_Points"].ToString();
                Session["oContractClubTPDropDownList2"] = ds5.Tables[0].Rows[0]["TP_New_CLub"].ToString();
                Session["oEntitlementTPoinDropDownList"] = ds5.Tables[0].Rows[0]["TP_New_Entitlement"].ToString();
                Session["oTextMemFeesp"] = ds5.Tables[0].Rows[0]["TP_Member_Fees"].ToString();
                Session["oTextPropFeesp"] = ds5.Tables[0].Rows[0]["TP_Property_Fees"].ToString();
                Session["oTextFYOccTP"] = ds5.Tables[0].Rows[0]["TP_FY_Occu"].ToString();
                Session["oTextDurationTP"] = ds5.Tables[0].Rows[0]["TP_Duration"].ToString();
                Session["oTextLYOccTP"] = ds5.Tables[0].Rows[0]["TP_LY_Occu"].ToString();
                Session["oTextDepoPPA"] = ds5.Tables[0].Rows[0]["PS_Deposit_PA"].ToString();





                Session["oTextAdmissFeesP"] = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                Session["oTextAdminFeesP"] = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
                Session["oTextPpurchasePrice"] = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                Session["oTextCountryTaxP"] = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                Session["oTextGrandTotalP"] = ds5.Tables[0].Rows[0]["PS_Grand_Total"].ToString();
                Session["oTextPBalaceDPA"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                Session["oTextPBalaceDPATOPD"] = ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"].ToString();
                Session["oTextPPANoInstall"] = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();

               


                // datepicker10.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();

                // string datepc1 = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]);
                string datepc1 = ds5D.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();

                if (datepc1 == " " || datepc1 == "01-01-1900")



                // string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                //if (datep1 == " " || datep1 == "1900-01-01")
                {
                    datepicker8.Text = "";
                }
                else
                {
                    datepicker8.Text = datepc1;
                }


                TextPPAAmountInstall.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"]);
                TextPPAFInstall.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"]);
                TextPBalanceDDates.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                TextPBalanceDDates2.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();
                TextPDepositSA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit_SA"]);
                TextAppliFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_SA_Application"]);
                TextAdminServiceP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_SA_Administration"]);
                TextTotalServicePriceP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Total_Service"]);
                TextBalanceDueSAP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"]);
                TextBalanceDDatesSAP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();
                TextBalanceDDatesSAP2.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates2"].ToString();
                TextRemarkP.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                TextRemarkP2.Text = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();

                TextTotalBalance.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["Total_Balance"]);






                Session["oPS_PA_FInstall_Date"] = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();
                Session["oTextPPAAmountInstall"] = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                Session["oTextPPAFInstall"] = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                Session["oTextPBalanceDDates"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                Session["oTextPBalanceDDates2"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();
                Session["oTextPDepositSA"] = ds5.Tables[0].Rows[0]["PS_Deposit_SA"].ToString();
                Session["oTextAppliFeesP"] = ds5.Tables[0].Rows[0]["PS_SA_Application"].ToString();
                Session["oTextAdminServiceP"] = ds5.Tables[0].Rows[0]["PS_SA_Administration"].ToString();
                Session["oTextTotalServicePriceP"] = ds5.Tables[0].Rows[0]["PS_Total_Service"].ToString();
                Session["oTextBalanceDueSAP"] = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"].ToString();
                Session["oTextBalanceDDatesSAP"] = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();
                Session["oTextBalanceDDatesSAP2"] = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates2"].ToString();
                Session["oTextRemarkP"] = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                Session["oTextRemarkP2"] = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();
                Session["oTextTotalBalance"] = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();
            


                /*  TextDepositTP.Text = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                  TextDepositPATP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_PA"].ToString();
                  TextTotalBalanceTP.Text = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();
                  TextAdmissFTP.Text = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                  TextAdminFeesTP.Text = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
                  TextPurchasePriceTP.Text = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                  TextCountryTaxTP.Text = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                  TextGrandTotalTP.Text = ds5.Tables[0].Rows[0]["PS_Grand_Total"].ToString();
                  TextBalanceDuePATP.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                  TextBalanceDuePATPTD.Text = ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"].ToString();
                  TextNoOfInstallPATP.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();
                  TextInstallAmtPATP.Text = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                  TextFInstallAmtPATP.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                  TextDepositSATP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_SA"].ToString();
                  TextAppliFeesTP.Text = ds5.Tables[0].Rows[0]["PS_SA_Application"].ToString();
                  TextAdminServiceTP.Text = ds5.Tables[0].Rows[0]["PS_SA_Administration"].ToString();
                  TextTotalServiceTP.Text = ds5.Tables[0].Rows[0]["PS_Total_Service"].ToString();
                  TextBalanceDueSATP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"].ToString();

                  TextRemarksTP.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                  TextRemarksTP2.Text = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();
                  TextBalanceDueDatesPATP.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                  TextBalanceDueDatesSATP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();
                  TextBalanceDueDatesPATP2.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();
                  TextBalanceDueDatesSATP2.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates2"].ToString();*/

                // datepicker11.Text = ds5.Tables[0].Rows[0]["CT_Points_Noof_Points"].ToString();

                //string datepc1 = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]);
                /*  string datepc1 = ds5D.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();
                  if (datepc1 == " " || datepc1 == "01-01-1900")

                     // string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                  //if (datep1 == " " || datep1 == "1900-01-01")
                  {
                      datepicker11.Text = "";
                  }
                  else
                  {
                      datepicker11.Text = datepc1;
                  }*/



                tPurchase.Text = TotalPurTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                QDepo.Text = QualTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                AmtCre.Text = AmountCreditTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                CreCurr.Text = AmountCreditCurrTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                NoOfMonth.Text = NoMonthsTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                RateOfInt.Text = RateInterestTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                MonthlyRepay.Text = MonthRepayTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();
		TextFinaStartDate.Text = ds5.Tables[0].Rows[0]["Finance_Details_Finance_Date"].ToString();

                TextInitDepo.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Initial_Deposit"]);
                TextBalDepo.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Bal_Deposit"]);
                TextPrimaryCCard2.Text = ds5.Tables[0].Rows[0]["PS_CPA_Comment"].ToString();
                //TextBoxNBDP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();


                 string baldatep = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_Deposit_Date"]);
                //string baldatep = ds5D.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();
                if (baldatep == " " || baldatep == "01-01-1900")


                {
                    TextBoxNBDP.Text = "";
                }
                else
                {
                    TextBoxNBDP.Text = baldatep;
                }

                Session["oPS_Deposit_Date"] = baldatep; //ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();

                TextIniInstP.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                TextIniInstAmtP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"]);


                Session["oTotalPurTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                Session["oQualTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                Session["oAmountCreditTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                Session["oAmountCreditCurrTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                Session["oNoMonthsTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                Session["oRateInterestTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                Session["oMonthRepayTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();

                Session["oTextInitDepo"] = ds5.Tables[0].Rows[0]["PS_Initial_Deposit"].ToString();
                Session["oTextBalDepo"] = ds5.Tables[0].Rows[0]["PS_Bal_Deposit"].ToString();
                Session["oTextPrimaryCCard2"] = ds5.Tables[0].Rows[0]["PS_CPA_Comment"].ToString();
               
                Session["oTextIniInstP"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                Session["oTextIniInstAmtP"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"].ToString();

                /*  tPurchase.Text = TotalPurTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                  QDepo.Text = QualTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                  AmtCre.Text = AmountCreditTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                  CreCurr.Text = AmountCreditCurrTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                  NoOfMonth.Text = NoMonthsTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                  RateOfInt.Text = RateInterestTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                  MonthlyRepay.Text = MonthRepayTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();*/

                //tPurchase1 = tPurchase.Text;
                //QDepo1 = QDepo.Text;
                //AmtCre1 = AmtCre.Text;
                //CreCurr1 = CreCurr.Text;
                //NoOfMonth1 = NoOfMonth.Text;
                //RateOfInt1 = RateOfInt.Text;
                //MonthlyRepay1 = MonthlyRepay.Text;


                /* TextInitDepoTP.Text = ds5.Tables[0].Rows[0]["PS_Initial_Deposit"].ToString();
                 TextBalDepoTP.Text = ds5.Tables[0].Rows[0]["PS_Bal_Deposit"].ToString();*/
                //TextBoxNBDP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();


                // string baldatetp = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_Deposit_Date"]);
                /*  string baldatetp = ds5D.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();
                  if (baldatetp == " " || baldatetp == "01-01-1900")


                  {
                      TextBoxNBDTP.Text = "";
                  }
                  else
                  {
                      TextBoxNBDTP.Text = baldatetp;
                  }



                  TextIniInstTP.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                  TextIniInstAmtTP.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"].ToString();*/


                string tpcheckbox = ds5.Tables[0].Rows[0]["Contract_finance_OddEven50"].ToString();

                if (tpcheckbox == "Yes")
                {
                    TPCheckBox1.Checked = true;
                }
                else
                {
                    TPCheckBox1.Checked = false;
                }

                string CheckBalloonP = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                if (CheckBalloonP == "BP")
                {
                    CheckBoxBalloonP.Checked = true;
                }
                else
                {
                    CheckBoxBalloonP.Checked = false;
                }

                Session["oContract_finance_OddEven50"] = ds5.Tables[0].Rows[0]["Contract_finance_OddEven50"].ToString();
                Session["oPS_Balloon_Pay"] = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                /* string CheckBalloonTP = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                 if (CheckBalloonTP == "BP")
                 {
                     CheckBoxBalloonTP.Checked = true;
                 }
                 else
                 {
                     CheckBoxBalloonTP.Checked = false;
                 }*/





            }
             else if (conttype == "Trade Into Fractional")
             {

                 Session["ECGGlobContClub"] = "";
                 string OldAgreeNoTF = "", OldClubTF = "", OldNoOfPointsTF = "", OldEntitleTF = "", OldResortTF = "", OldAppartTypeTF = "", OldNoOccuTF = "", OldPeriodTF = "", OldSeasonTF = "", OldResidenceNoTF = "", OldResiTypeTF = "", OldFracIntTF = "";

                 //ContTypeTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Cont_Type"].ToString());

                 //string subconttype = ds5.Tables[0].Rows[0]["TP_Cont_Type"].ToString();

                 string tfcheckbox = ds5.Tables[0].Rows[0]["Contract_finance_OddEven50"].ToString();

                 if (tfcheckbox == "Yes")
                 {
                     TFCheckBox1.Checked = true;
                 }
                 else
                 {
                     TFCheckBox1.Checked = false;
                 }


                string CheckBalloonP = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                if (CheckBalloonP == "BP")
                {
                    CheckBoxBalloonP.Checked = true;
                }
                else
                {
                    CheckBoxBalloonP.Checked = false;
                }

                /* string CheckBalloonTF = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();

                  if (CheckBalloonTF == "BP")
                  {
                      CheckBoxBalloonTF.Checked = true;
                  }
                  else
                  {
                      CheckBoxBalloonTF.Checked = false;
                  }*/

                Session["oContract_finance_OddEven50"] = ds5.Tables[0].Rows[0]["Contract_finance_OddEven50"].ToString();
                Session["oPS_Balloon_Pay"] = ds5.Tables[0].Rows[0]["PS_Balloon_Pay"].ToString();



                string conttypeTF = ds5.Tables[0].Rows[0]["TF_Contract_Type"].ToString();
                 ContTypeDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Contract_Type"].ToString());

                 if (conttypeTF == "From Points To Fractional")
                 {
                      TextOldAgreeNoTF1.Text = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString(); 
                   // OldClubDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Club"].ToString());
                     DataSet dsec51 = Queries2.LoadContractClub(Session["Gofficeo"].ToString());
                     OldClubDropDownListTF.DataSource = dsec51;
                     OldClubDropDownListTF.DataTextField = "Contract_Club_Name";
                     OldClubDropDownListTF.DataValueField = "Contract_Club_Name";
                     OldClubDropDownListTF.AppendDataBoundItems = true;
                     OldClubDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Club"].ToString(), ""));
                     OldClubDropDownListTF.DataBind();

                     TextOldNoOfPointsTF.Text = ds5.Tables[0].Rows[0]["TF_Old_NoOf_Points"].ToString();
                     //EntitleDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString());
                     DataSet ds52 = Queries2.LoadEntitlement();
                     EntitleDropDownListTF1.DataSource = ds52;
                     EntitleDropDownListTF1.DataTextField = "Entitlement_Name";
                     EntitleDropDownListTF1.DataValueField = "Entitlement_Name";
                     EntitleDropDownListTF1.AppendDataBoundItems = true;
                     EntitleDropDownListTF1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString(), ""));
                     EntitleDropDownListTF1.DataBind();



                    Session["oTextOldAgreeNoTF1"] = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString();
                    Session["oOldClubDropDownListTF"] = ds5.Tables[0].Rows[0]["TF_Old_Club"].ToString();
                    Session["oTextOldNoOfPointsTF"] = ds5.Tables[0].Rows[0]["TF_Old_NoOf_Points"].ToString();
                    Session["oEntitleDropDownListTF1"] = ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString();
                    //OldResortTF = "";
                    //OldAppartTypeTF = "";
                    //OldNoOccuTF = "";
                    //OldPeriodTF = "";
                    //OldSeasonTF = "";
                    //OldResidenceNoTF = "";
                    //OldResiTypeTF = "";
                    //OldFracIntTF = "";
                }
                 else if (conttypeTF == "From Weeks To Fractional")
                 {
                     TextOldAgreeNoTF2.Text = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString();
                     //OldClubTF = "";
                     //OldNoOfPointsTF = "";
                     //EntitleDropDownListTF2.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString());
                     DataSet dsec53 = Queries2.LoadEntitlement();
                     EntitleDropDownListTF2.DataSource = dsec53;
                     EntitleDropDownListTF2.DataTextField = "Entitlement_Name";
                     EntitleDropDownListTF2.DataValueField = "Entitlement_Name";
                     EntitleDropDownListTF2.AppendDataBoundItems = true;
                     EntitleDropDownListTF2.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString(), ""));
                     EntitleDropDownListTF2.DataBind();

                     //ResortDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString());
                     DataSet dsec55 = Queries2.LoadFracResort();
                     ResortDropDownListTF1.DataSource = dsec55;
                     ResortDropDownListTF1.DataTextField = "Fract_Resort_Name";
                     ResortDropDownListTF1.DataValueField = "Fract_Resort_Name";
                     ResortDropDownListTF1.AppendDataBoundItems = true;
                     ResortDropDownListTF1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString(), ""));
                     ResortDropDownListTF1.DataBind();

                    // AppartTypeDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Apmnt_Type"].ToString());
                     DataSet dsec58 = Queries2.LoadApartType();
                     AppartTypeDropDownListTF.DataSource = dsec58;
                     AppartTypeDropDownListTF.DataTextField = "Apart_Type_Name";
                     AppartTypeDropDownListTF.DataValueField = "Apart_Type_Name";
                     AppartTypeDropDownListTF.AppendDataBoundItems = true;
                     AppartTypeDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Apmnt_Type"].ToString(), ""));
                     AppartTypeDropDownListTF.DataBind();

                    // NoOccuDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_No_Occu"].ToString());
                     DataSet dsec57 = Queries2.LoadContNumbOccu();
                     NoOccuDropDownListTF.DataSource = dsec57;
                     NoOccuDropDownListTF.DataTextField = "Numb_Occu_Numb";
                     NoOccuDropDownListTF.DataValueField = "Numb_Occu_Numb";
                     NoOccuDropDownListTF.AppendDataBoundItems = true;
                     NoOccuDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_No_Occu"].ToString(), ""));
                     NoOccuDropDownListTF.DataBind();

                     //PeriodDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Period"].ToString());
                     DataSet dsec56 = Queries2.LoadContPeriod();
                     PeriodDropDownListTF.DataSource = dsec56;
                     PeriodDropDownListTF.DataTextField = "Period_Name";
                     PeriodDropDownListTF.DataValueField = "Period_Name";
                     PeriodDropDownListTF.AppendDataBoundItems = true;
                     PeriodDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Period"].ToString(), ""));
                     PeriodDropDownListTF.DataBind();


                    // SeasonDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Season"].ToString());

                     DataSet dsec59 = Queries2.LoadSeasType();
                     SeasonDropDownListTF.DataSource = dsec59;
                     SeasonDropDownListTF.DataTextField = "Season_Name";
                     SeasonDropDownListTF.DataValueField = "Season_Name";
                     SeasonDropDownListTF.AppendDataBoundItems = true;
                     SeasonDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Season"].ToString(), ""));
                     SeasonDropDownListTF.DataBind();



                    Session["oTextOldAgreeNoTF2"] = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString();
                    Session["oEntitleDropDownListTF2"] = ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString();
                    Session["oResortDropDownListTF1"] = ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString();
                    Session["oAppartTypeDropDownListTF"] = ds5.Tables[0].Rows[0]["TF_Old_Apmnt_Type"].ToString();
                    Session["oNoOccuDropDownListTF"] = ds5.Tables[0].Rows[0]["TF_Old_No_Occu"].ToString();
                    Session["oPeriodDropDownListTF"] = ds5.Tables[0].Rows[0]["TF_Old_Period"].ToString();
                    Session["oSeasonDropDownListTF"] = ds5.Tables[0].Rows[0]["TF_Old_Season"].ToString();


                    //OldResidenceNoTF = "";
                    //OldResiTypeTF = "";
                    //OldFracIntTF = "";
                }
                 else if (conttypeTF == "From Fractional To Fractional")
                 {
                     TextOldAgreeNoTF3.Text = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString();
                     //OldClubTF = "";
                     //OldNoOfPointsTF = "";
                     //EntitleDropDownListTF3.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString());
                     DataSet dsec54 = Queries2.LoadEntitlement();
                     EntitleDropDownListTF3.DataSource = dsec54;
                     EntitleDropDownListTF3.DataTextField = "Entitlement_Name";
                     EntitleDropDownListTF3.DataValueField = "Entitlement_Name";
                     EntitleDropDownListTF3.AppendDataBoundItems = true;
                     EntitleDropDownListTF3.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString(), ""));
                     EntitleDropDownListTF3.DataBind();

                     //ResortDropDownListTF3.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString());
                     DataSet dsec62 = Queries2.LoadContResort(office);
                     ResortDropDownListTF3.DataSource = dsec62;
                     ResortDropDownListTF3.DataTextField = "Contract_Resort_Name";
                     ResortDropDownListTF3.DataValueField = "Contract_Resort_Name";
                     ResortDropDownListTF3.AppendDataBoundItems = true;
                     ResortDropDownListTF3.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString(), ""));
                     ResortDropDownListTF3.DataBind();

                     //OldAppartTypeTF = "";
                     //OldNoOccuTF = "";
                     //OldPeriodTF = "";
                     //OldSeasonTF = "";
                 //    ResidenceNoDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Resi_No"].ToString());


                    DataSet ResiNoTF = Queries2.LoadResidenceNo(ds5.Tables[0].Rows[0]["TF_Old_Resi_No"].ToString(), Session["office2"].ToString());
                    ResidenceNoDropDownListTF.DataSource = ResiNoTF;
                    ResidenceNoDropDownListTF.DataTextField = "Contract_Residence_Name";
                    ResidenceNoDropDownListTF.DataValueField = "Contract_Residence_Name";
                    ResidenceNoDropDownListTF.AppendDataBoundItems = true;
                    ResidenceNoDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Resi_No"].ToString(), ""));
                    ResidenceNoDropDownListTF.DataBind();





                    ResiTypeDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Resi_Type"].ToString());
                     //FracIntDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Frac_Int"].ToString());
                     DataSet dsec61 = Queries2.LoadFractionalI();
                     FracIntDropDownListTF.DataSource = dsec61;
                     FracIntDropDownListTF.DataTextField = "Contract_Fractional_Int_Name";
                     FracIntDropDownListTF.DataValueField = "Contract_Fractional_Int_Name";
                     FracIntDropDownListTF.AppendDataBoundItems = true;
                     FracIntDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Frac_Int"].ToString(), ""));
                     FracIntDropDownListTF.DataBind();




                    Session["oTextOldAgreeNoTF3"] = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString();
                    Session["oEntitleDropDownListTF3"] = ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString();
                    Session["oResortDropDownListTF3"] = ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString();
                    Session["oResidenceNoDropDownListTF"] = ds5.Tables[0].Rows[0]["TF_Old_Resi_No"].ToString();
                    Session["oResiTypeDropDownListTF"] = ds5.Tables[0].Rows[0]["TF_Old_Resi_Type"].ToString();
                    Session["oFracIntDropDownListTF"] = ds5.Tables[0].Rows[0]["TF_Old_Frac_Int"].ToString();
                  


                }


                 ResortDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Resort"].ToString());
               //  ResidenceNoDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Resi_No"].ToString());

                DataSet ResiNoTF1 = Queries2.LoadResidenceNo( ds5.Tables[0].Rows[0]["TF_Resort"].ToString(), Session["office2"].ToString());
                ResidenceNoDropDownListTF1.DataSource = ResiNoTF1;
                ResidenceNoDropDownListTF1.DataTextField = "Contract_Residence_Name";
                ResidenceNoDropDownListTF1.DataValueField = "Contract_Residence_Name";
                ResidenceNoDropDownListTF1.AppendDataBoundItems = true;
                ResidenceNoDropDownListTF1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Resi_No"].ToString(), ""));
                ResidenceNoDropDownListTF1.DataBind();



                ResiTypeDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Resi_Type"].ToString());





                //FracIntDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Frac_Int"].ToString());
                 DataSet dsec63 = Queries2.LoadFractionalI();
                 FracIntDropDownListTF1.DataSource = dsec63;
                 FracIntDropDownListTF1.DataTextField = "Contract_Fractional_Int_Name";
                 FracIntDropDownListTF1.DataValueField = "Contract_Fractional_Int_Name";
                 FracIntDropDownListTF1.AppendDataBoundItems = true;
                 FracIntDropDownListTF1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Frac_Int"].ToString(), ""));
                 FracIntDropDownListTF1.DataBind();

                 DataSet dsec5 = Queries2.LoadEntitlement();
                 EntitlementTFracDropDownList.DataSource = dsec5;
                 EntitlementTFracDropDownList.DataTextField = "Entitlement_Name";
                 EntitlementTFracDropDownList.DataValueField = "Entitlement_Name";
                 EntitlementTFracDropDownList.AppendDataBoundItems = true;
                 EntitlementTFracDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Entitle"].ToString(), ""));
                 EntitlementTFracDropDownList.DataBind();

                 //EntitlementTFracDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TF_Entitle"].ToString());
                  TextFYOccuTF.Text = ds5.Tables[0].Rows[0]["TF_First_Occ"].ToString();
                TextDurationTF.Text = ds5.Tables[0].Rows[0]["TF_Duration"].ToString();
                 TextLYOccuTF.Text = ds5.Tables[0].Rows[0]["TF_Last_Occ"].ToString();
                 ContractNoTFTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();

TextBoxDummyleaseoff.Text = ds5.Tables[0].Rows[0]["TF_Leas"].ToString();

               Session["ODeposit"] = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                TextDepositP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit"]);
                TextDepoPPA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Deposit_PA"]);
                TextAdmissFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Admission"]);
                TextAdminFeesP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Administration"]);
                TextPpurchasePrice.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Total_Purchase"]);
                TextCountryTaxP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax"]);
                TextGrandTotalP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Grand_Total"]);
                TextPBalaceDPA.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"]);
                TextPBalaceDPATOPD.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"]);
                TextPPANoInstall.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();


               



                /* TextDepositTF.Text = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                  // string DepoPPA = TextDepoPPA.Text;
                   TextAdmissFeeTF.Text = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                  TextAdminFeeTF.Text = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
                   TextPurchasePriceTF.Text = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                  TextCountryTaxTF.Text = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                  //string GrandTotalP = TextGrandTotalP.Text;
                   TextBalanceDuePATF.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                  TextBalanceDuePATFTD.Text = ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"].ToString();
                  TextNoOfInstallTF.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();*/

                // datepicker13.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();

                // string datepc1 = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]);


                string datepc1 = ds5D.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();

                if (datepc1 == " " || datepc1 == "01-01-1900")



                // string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                //if (datep1 == " " || datep1 == "1900-01-01")
                {
                    datepicker8.Text = "";
                }
                else
                {
                    datepicker8.Text = datepc1;
                }


                TextPPAAmountInstall.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"]);
                TextPPAFInstall.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"]);
                TextPBalanceDDates.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                TextPBalanceDDates2.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();
                //TextPDepositSA.Text = ds5.Tables[0].Rows[0]["PS_Deposit_SA"].ToString();
               // TextAppliFeesP.Text = ds5.Tables[0].Rows[0]["PS_SA_Application"].ToString();
                //TextAdminServiceP.Text = ds5.Tables[0].Rows[0]["PS_SA_Administration"].ToString();
               // TextTotalServicePriceP.Text = ds5.Tables[0].Rows[0]["PS_Total_Service"].ToString();
               // TextBalanceDueSAP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"].ToString();
               // TextBalanceDDatesSAP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();
               // TextBalanceDDatesSAP2.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates2"].ToString();
                TextRemarkP.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                TextRemarkP2.Text = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();

                TextTotalBalance.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["Total_Balance"]);
		

		if(FinanceCurrencyDropDownList.SelectedItem.Text=="INR")
                {
                    TextBoxCGST.Text= string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax_CGST"]);
                    TextBoxSGST.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Country_Tax_SGST"]);

                    Session["oTextBoxCGST"] = ds5.Tables[0].Rows[0]["PS_Country_Tax_CGST"].ToString();
                    Session["oTextBoxSGST"] = ds5.Tables[0].Rows[0]["PS_Country_Tax_SGST"].ToString();
                }

                Session["oResidenceNoDropDownListTF1"] = ds5.Tables[0].Rows[0]["TF_Resi_No"].ToString();
                Session["oResiTypeDropDownListTF1"] = ds5.Tables[0].Rows[0]["TF_Resi_Type"].ToString();
                Session["oFracIntDropDownListTF1"] = ds5.Tables[0].Rows[0]["TF_Frac_Int"].ToString();
                Session["oEntitlementTFracDropDownList"] = ds5.Tables[0].Rows[0]["TF_Entitle"].ToString();
                Session["oTextFYOccuTF"] = ds5.Tables[0].Rows[0]["TF_First_Occ"].ToString();
                Session["oTextDurationTF"] = ds5.Tables[0].Rows[0]["TF_Duration"].ToString();
                Session["oTextLYOccuTF"] = ds5.Tables[0].Rows[0]["TF_Last_Occ"].ToString();
                Session["oTextBoxDummyleaseoff"] = ds5.Tables[0].Rows[0]["TF_Leas"].ToString();
                Session["oTextDepoPPA"] = ds5.Tables[0].Rows[0]["PS_Deposit_PA"].ToString();
                Session["oTextAdmissFeesP"] = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                Session["oTextAdminFeesP"] = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
                Session["oTextPpurchasePrice"] = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                Session["oTextCountryTaxP"] = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                Session["oTextGrandTotalP"] = ds5.Tables[0].Rows[0]["PS_Grand_Total"].ToString();
                Session["oTextPBalaceDPA"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                Session["oTextPBalaceDPATOPD"] = ds5.Tables[0].Rows[0]["PS_BalanceDue_TD"].ToString();
                Session["oTextPPANoInstall"] = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();


                Session["oPS_PA_FInstall_Date"] = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();
                Session["oTextPPAAmountInstall"] = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                Session["oTextPPAFInstall"] = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                Session["oTextPBalanceDDates"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                Session["oTextPBalanceDDates2"] = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();
                Session["oTextRemarkP"] = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                Session["oTextRemarkP2"] = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();
                Session["oTextTotalBalance"] = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();
                



                /* string datepc1 = ds5D.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();
                  if (datepc1 == " " || datepc1 == "01-01-1900")

                    //  string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                  //if (datep1 == " " || datep1 == "1900-01-01")
                  {
                      datepicker13.Text = "";
                  }
                  else
                  {
                      datepicker13.Text = datepc1;
                  }


                  TextInstallAmtTF.Text = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                  TextFInstallAmtTF.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                   TextBalanceDueDatesPATF.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                  TextBalanceDueDatesPATF2.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates2"].ToString();

                  TextRemarksTF.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                  TextRemarksTF2.Text = ds5.Tables[0].Rows[0]["PS_Remarks2"].ToString();
                  TextTotalBalanceTF.Text = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();*/



                tPurchase.Text = TotalPurTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                QDepo.Text = QualTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                AmtCre.Text = AmountCreditTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                CreCurr.Text = AmountCreditCurrTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                NoOfMonth.Text = NoMonthsTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                RateOfInt.Text = RateInterestTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                MonthlyRepay.Text = MonthRepayTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();
		TextFinaStartDate.Text = ds5.Tables[0].Rows[0]["Finance_Details_Finance_Date"].ToString();

                TextInitDepo.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Initial_Deposit"]);
                TextBalDepo.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Bal_Deposit"]);
                TextPrimaryCCard2.Text = ds5.Tables[0].Rows[0]["PS_CPA_Comment"].ToString();
                //TextBoxNBDP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();
                //string baldatep = ds5D.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();

                 string baldatep = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_Deposit_Date"]);
              //  string baldatep = ds5D.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                if (baldatep == " " || baldatep == "01-01-1900")


                {
                    TextBoxNBDP.Text = "";
                }
                else
                {
                    TextBoxNBDP.Text = baldatep;
                }



                TextIniInstP.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                TextIniInstAmtP.Text = string.Format("{0:n0}", ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"]);

		   DataSet dsec67 = Queries2.LoadContractVenueVP(vencountry, ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString());
                ContractVenueVPDropDownList.DataSource = dsec67;
                ContractVenueVPDropDownList.DataTextField = "CVenue_Venue";
                ContractVenueVPDropDownList.DataValueField = "CVenue_Venue";
                ContractVenueVPDropDownList.AppendDataBoundItems = true;
                ContractVenueVPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString(), ""));
                ContractVenueVPDropDownList.DataBind();

                Session["oTotalPurTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                Session["oQualTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                Session["oAmountCreditTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                Session["oAmountCreditCurrTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                Session["oNoMonthsTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                Session["oRateInterestTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();

                Session["oMonthRepayTextBoxPFC"] = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();
                Session["oTextInitDepo"] = ds5.Tables[0].Rows[0]["PS_Initial_Deposit"].ToString();
                Session["oTextBalDepo"] = ds5.Tables[0].Rows[0]["PS_Bal_Deposit"].ToString();
                Session["oTextPrimaryCCard2"] = ds5.Tables[0].Rows[0]["PS_CPA_Comment"].ToString();
                Session["oPS_Ini_Bal_Install"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                Session["oTextIniInstP"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                Session["oTextIniInstAmtP"] = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"].ToString();
                Session["oContractVenueVPDropDownList"] = ds5.Tables[0].Rows[0]["Contract_Finance_Contract_Venue"].ToString();

            //    Session["oPS_Deposit_USD"] = ds5.Tables[0].Rows[0]["PS_Deposit_USD"].ToString();
             //   Session["oPS_Country_Tax_USD"] = ds5.Tables[0].Rows[0]["PS_Country_Tax_USD"].ToString();
            //    Session["oContract_Finance_Purchase_Price_USD"] = ds5.Tables[0].Rows[0]["Contract_Finance_Purchase_Price_USD"].ToString();
           //     Session["oContract_Finance_Admin_Fees_USD"] = ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees_USD"].ToString();


                /*
            PS_Deposit_USD	PS_Country_Tax_USD
497	0

Contract_Finance_Purchase_Price_USD	Contract_Finance_Admin_Fees_USD
4907	650    
            
            
            
            
            */

                /* tPurchase.Text=TotalPurTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                  QDepo.Text= QualTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                  AmtCre.Text = AmountCreditTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                  CreCurr.Text = AmountCreditCurrTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                  NoOfMonth.Text = NoMonthsTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                  RateOfInt.Text = RateInterestTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                  MonthlyRepay.Text = MonthRepayTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();



                  TextInitDepoTF.Text = ds5.Tables[0].Rows[0]["PS_Initial_Deposit"].ToString();
                  TextBalDepoTF.Text = ds5.Tables[0].Rows[0]["PS_Bal_Deposit"].ToString();
                  //TextBoxNBDP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();


                  //string baldatetf = String.Format("{0:dd-MM-yyyy}", ds5.Tables[0].Rows[0]["PS_Deposit_Date"]);
                  string baldatetf = ds5D.Tables[0].Rows[0]["PS_Deposit_Date"].ToString();
                  if (baldatetf == " " || baldatetf == "01-01-1900")


                  {
                      TextBoxNBDTF.Text = "";
                  }
                  else
                  {
                      TextBoxNBDTF.Text = baldatetf;
                  }


                  TextIniInstTF.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install"].ToString();
                  TextIniInstAmtTF.Text = ds5.Tables[0].Rows[0]["PS_Ini_Bal_Install_Amt"].ToString();*/

                //tPurchase1 = tPurchase.Text;
                //QDepo1 = QDepo.Text;
                //AmtCre1 = AmtCre.Text;
                //CreCurr1 = CreCurr.Text;
                //NoOfMonth1 = NoOfMonth.Text;
                //RateOfInt1 = RateOfInt.Text;
                //MonthlyRepay1 = MonthlyRepay.Text;
                // DeleteInvoiceOnEdit

            }


        }
        
      }

    public void Button5_Click(object sender, EventArgs e)
    {

        //try { 

        string conttype = DropDownList40.SelectedItem.Text;
        string Deposit_PM = DPMFractDropDownList.SelectedItem.Text;
        string resort = "";
        string Boverride = TextBoxDummyOverride.Text;

        string GenContNumb = Queries2.getcontnumbfromid(Session["fracido"].ToString());//ContractNoFractTextBox.Text;
        //GenContNumbglob = GenContNumb;
        Session["ECGetContnumb"] = GenContNumb;
        // string ContType = DropDownList40.SelectedItem.Text;
        string affilice = TextICE.Text;
        string affilhp = TextHP.Text;
        string salesrep = contsalesrepDropDownList.SelectedItem.Text;
        string tomanager = TOManagerDropDownList.SelectedItem.Text;
        string buttonup = ButtonUpDropDownList.SelectedItem.Text;
        string FinaCurrency = FinanceCurrencyDropDownList.SelectedItem.Text;
        string PurchasePrice = TextPurchasePrice.Text.Replace(",", "");
        string AdminFees = TextAdminFees.Text.Replace(",", "");
        string MCFees = TextMCFees.Text;
        string DealDrawer = DealDrawerDropDownList.SelectedItem.Text;
        string PaymentMethod = PayMethodDropDownList.SelectedItem.Text;
        string PaymentMethodDeatils = TextPayMethodDetails.Text;
        string FinanceNumb = TextPnumb.Text;
        string BPaymethod = "";//BPMDropDownList.SelectedItem.Text;
        string Pan = TextPan.Text;
        string Adhar = TextAdhar.Text;
        string ID_Card = TextOtherID.Text;
        string CrownCurr = CrownFinanceCurrDropDownList.SelectedItem.Text;
        string ContComment = TextBoxContractComment.Text;
	string Contractvenue = ContractVenueVPDropDownList.SelectedItem.Text;


        string EuroRatesF="", AusRatesF="", GbpRatesF="", IdaRatesF="";
        string YearOfInterestP="";
        string tPurchase1="", QDepo1="", AmtCre1="", CreCurr1="", NoOfMonth1="", RateOfInt1="", MonthlyRepay1="", MonthlyRepay110="", MonthlyRepay1Payprotectcharge="", PayProtect="",FinaDate=""; 
        string TYearOfInterestP = YearOfIntDropDownList.SelectedItem.Text;

        string SC_Cancel_Group_Venue, SC_Cancel_Reason, SC_Cancel_Date, SC_Cancel_Type, SC_Cancel_Comment, SC_Withdraw_Date;
        

       


        if (DealDrawer == "Cancel")
        {
            SC_Cancel_Group_Venue = CGroupvenueDropDownList.SelectedItem.Text;

            SC_Cancel_Reason = CReasonDropDownList.SelectedItem.Text;

           // SC_Cancel_Date = CancelDateTextBoxDummy.Text;//CancelDateTextBox.Text;

            SC_Cancel_Type = CTypeDropDownList.SelectedItem.Text;


            if (SC_Cancel_Type=="WITHDRAW")
            {
                DateTime dtt2 = DateTime.ParseExact(WithdrawDateTextBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //DateTime endDate = DateTime.ParseExact(DateBox2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                SC_Withdraw_Date = dtt2.ToString("yyyy-MM-dd");


            }
            else
            {
                SC_Withdraw_Date = "";
            }


                SC_Cancel_Comment = CCommentTextBox.Text;

    DateTime dtt = DateTime.ParseExact(CancelDateTextBoxDummy.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        //DateTime endDate = DateTime.ParseExact(DateBox2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        SC_Cancel_Date = dtt.ToString("yyyy-MM-dd");

        }
        else
        {
            SC_Cancel_Group_Venue = "";

            SC_Cancel_Reason = "";

            SC_Cancel_Date = "";

            SC_Cancel_Type = "";

            SC_Cancel_Comment = "";// CCommentTextBox.Text;

            SC_Withdraw_Date = "";
        }



            if (String.Compare(Session["oDealDrawer"].ToString(), DealDrawer) != 0)
        {

            if (DealDrawer == "Deal")
            {
                Session["DealRegDate"] = DateTime.Now.ToString("yyyy-MM-dd");
                Session["cweekno"] = Queries.GetWkNumber(DateTime.Now);
                Session["weeknoflag"] = 1;

            }
            else if (DealDrawer == "Top Drawer")
            {
                Session["DealRegDate"] = "";
                Session["cweekno"] = 0;
                Session["weeknoflag"] = 1;
                //ContComment = "dealregdate not coming " + oDealDrawer + "  " + DealDrawer;
            }
            else 
            {
               // Session["DealRegDate"] = "";
              //  Session["cweekno"] = 0;
                Session["weeknoflag"] = 1;
                //ContComment = "dealregdate not coming " + oDealDrawer + "  " + DealDrawer;
            }

            string scid = Queries2.GetStatusChangeID();

            int statchange = Queries2.InsertStatusChange(scid, Session["oDealDrawer"].ToString(), DealDrawer, SC_Cancel_Group_Venue, SC_Cancel_Reason, SC_Cancel_Date, user, Session["ProfileIDo"].ToString(), Session["fracido"].ToString(), DateTime.Now.ToString(),"", SC_Cancel_Type, SC_Cancel_Comment,SC_Withdraw_Date);
        }
            else
        {
            if(Session["oDealDrawer"].ToString() == "Cancel")
            {
                //oCGroupvenueDropDownList,oCReasonDropDownList,oCancelDateTextBox
                     if (String.Compare(Session["oCGroupvenueDropDownList"].ToString(), SC_Cancel_Group_Venue) != 0 || String.Compare(Session["oCReasonDropDownList"].ToString(), SC_Cancel_Reason) != 0 || String.Compare(Session["oCancelDateTextBox"].ToString(), SC_Cancel_Date) != 0 || String.Compare(Session["oSC_Cancel_Type"].ToString(), SC_Cancel_Type) != 0 || String.Compare(Session["oSC_Cancel_Comment"].ToString(), SC_Cancel_Comment) != 0 || String.Compare(Session["oSC_Withdraw_Date"].ToString(), SC_Withdraw_Date) != 0) 
                {
                    //SC_Cancel_Group_Venue,SC_Cancel_Reason,SC_Cancel_Date

                      int updstatuschange = Queries2.Update_Status_change(SC_Cancel_Group_Venue, SC_Cancel_Reason, SC_Cancel_Date,DateTime.Now.ToString(), Session["oDealDrawer"].ToString(), Session["fracido"].ToString(), SC_Cancel_Type, SC_Cancel_Comment,SC_Withdraw_Date);
                }
                    

                
            }

        }

        string IGSTRate, IntRate, DoccuFees, IGSTAmt, NoEMI, EMIAmt, Finamonth,princiamount ;

        
        if (PaymentMethod != "Crown Finance" && PaymentMethod != "PARSHURAM FINANCE")
        {
            EuroRatesF = "";
            AusRatesF = "";
            GbpRatesF = "";
            IdaRatesF = "";
           // YearOfInterestP = "";

            tPurchase1 = "";
            QDepo1 = "";
            AmtCre1 = "";
            CreCurr1 = "";
            NoOfMonth1 = "";
            RateOfInt1 = "";
            MonthlyRepay1 = "";
            MonthlyRepay110 = "";
            MonthlyRepay1Payprotectcharge = ""; 
            PayProtect="No";
            FinaDate = "";
            FinanceNumb = "";
            CrownCurr = "";
            YearOfInterestP = "";



            IGSTRate = "";
            IntRate = "";
            DoccuFees = "";
            IGSTAmt = "";
            NoEMI = "";
            EMIAmt = "";
            Finamonth = "";
            princiamount = "";



        }

        else if (PaymentMethod == "PARSHURAM FINANCE")
        {
            IGSTRate = TextBoxDIGSTRate.Text;
            IntRate = TextBoxDIntRate.Text;
            DoccuFees = TextBoxDDcocuFees.Text;
            IGSTAmt = TextBoxDIGSTAmt.Text;
            NoEMI = TextBoxDNoEMI.Text;
            EMIAmt = TextBoxDEMIAmt.Text;
            Finamonth = TextBoxDFinaMonth.Text;
            princiamount = TextBoxDPrincipalAmt.Text;


           // if (String.Compare(oBalance_Pay_Method, PaymentMethod) != 0)
          //  {

                int finacheck = Queries2.checkforexistingfinancedetails(Session["fracido"].ToString(),"0");
                if (finacheck == 1)
                {
                    int finadetails = Queries2.Update_Parshu_Finance_Details(IGSTRate, IntRate, DoccuFees, IGSTAmt, NoEMI, EMIAmt, Finamonth, Session["fracido"].ToString(), princiamount);
                }
                else
                {
                    string PFDID = Queries2.getFinanceDetailID();
                   // int FD = Queries2.InsertFDetails(FDID, tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, Session["ProfileIDo"].ToString(), Session["fracido"].ToString(), DateTime.Now.ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect, FinaDate);

                    int PFD = Queries2.InsertParshuramFDetails(PFDID, IGSTRate, IntRate, DoccuFees, IGSTAmt, NoEMI, EMIAmt, Finamonth, Session["fracido"].ToString(), ProfileIDTextBox.Text, DateTime.Now.ToString(), princiamount);

                    if (PaymentMethod == "PARSHURAM FINANCE")
                    {

                        int UpdatePnumber = Queries2.UpdatePnumberINR(Session["Gofficeo"].ToString(), Request.Form[GroupVenueDropDownList.UniqueID]);//Queries2.UpdatePnumber("INR");
                    }

                }

           // }






        }

        else if (PaymentMethod == "Crown Finance")
        {
            EuroRatesF = TextEuroRateP.Text;
            AusRatesF = TextAusRateP.Text;
            GbpRatesF = TextGbpRateP.Text;
            IdaRatesF = TextIdaRateP.Text;


            tPurchase1 = tPurchase.Text;
            QDepo1 = QDepo.Text;
            AmtCre1 = AmtCre.Text;
            CreCurr1 = CreCurr.Text;
            NoOfMonth1 = NoOfMonth.Text;
            RateOfInt1 = RateOfInt.Text;
            MonthlyRepay1 = MonthlyRepay.Text;
            FinaDate = TextFinaStartDate.Text; 

            MonthlyRepay110 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
            if (UsePayProtectCheckBox.Checked)
            {
                string s1 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                MonthlyRepay1Payprotectcharge = (float.Parse(s1) + float.Parse(MonthlyRepay1)).ToString("0.00");
                PayProtect = "Yes";
            }
            else
            {
                MonthlyRepay1Payprotectcharge = "0.00";
                PayProtect = "No";
            }



            if (TYearOfInterestP == "")
            {
                YearOfInterestP = "";
            }
            else
            {

                YearOfInterestP = Queries2.LoadYearOfIntValue(TYearOfInterestP);
            }

           // if (String.Compare(oBalance_Pay_Method, PaymentMethod) != 0)
            //{

                int finacheck = Queries2.checkforexistingfinancedetails(Session["fracido"].ToString(), "1");
                if (finacheck == 1)
                {
                    int finadetails = Queries2.Update_Finance_Details(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, Session["fracido"].ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect, FinaDate);
                }
                else
                {
                    string FDID = Queries2.getFinanceDetailID();
                    int FD = Queries2.InsertFDetails(FDID, tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, Session["ProfileIDo"].ToString(), Session["fracido"].ToString(), DateTime.Now.ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect, FinaDate);

                    if (PaymentMethod == "Crown Finance")
                    {
                        int UpdatePnumber = Queries2.UpdatePnumber(CrownCurr, Session["Gofficeo"].ToString());

                    }
                    


                }

           // }




        }


        //oBalance_Pay_Method=
        //     if (String.Compare(oBalance_Pay_Method, PaymentMethod) != 0)
        //{

        //    int finacheck = Queries2.checkforexistingfinancedetails(fracido);
        //    if (finacheck == 1)
        //    {
        //        int finadetails = Queries2.Update_Finance_Details(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, fracido, MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect,FinaDate);
        //    }
        //    else
        //    {
        //        string FDID = Queries2.getFinanceDetailID();
        //        int FD = Queries2.InsertFDetails(FDID, tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, ProfileIDo, contFinance, DateTime.Now.ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect, FinaDate);
        //    }

        //}
        //else { }

        int weeknoflag1 = Convert.ToInt32(Session["weeknoflag"]);
        if (weeknoflag1 != 1)
        {
            Session["cweekno"] = Convert.ToInt32(Session["scweekno"]);
        }

        string PCard_Type = CardPrimaryDropDownList.SelectedItem.Text;
        string PIssuing_Bank = TextIssuingP.Text;
        string PCredit_Card_No = TextCardNumbP.Text;
        string PCard_Holders_Name = TextCardHNameP.Text;
        string PExpiry = TextExpMonthP.Text;
        string PSecurity_No = TextSecurityP.Text;
        string PFor_Depo = TextFDepo1.Text;
        string PFor_Bala = TextFBala1.Text;
        string SCard_Type = CardSecondaryDropDownList.SelectedItem.Text;
        string SIssuing_Bank = TextIssuingS.Text;
        string SCredit_Card = TextCardNumbS.Text;
        string SCard_Holders_Name = TextCardHNameS.Text;
        string SExpiry = TextExpiryS.Text;
        string SSecurity_No = TextSecurityS.Text;
        string SFor_Depo = TextFDepo2.Text;
        string SFor_Bala = TextFBala2.Text;
        DateTime entrydate = DateTime.Now;
        string Pcomments = TextPrimaryCCard.Text;
        string Scomments = TextSecondaryCCard.Text;

        //string Payment_Details_SCredit_Card_No, string Payment_Details_SCard_Holders_Name, string Payment_Details_SExpiry, string Payment_Details_SSecurity_No, string Payment_Details_SFor_Depo, string Payment_Details_SFor_Bala,  string Contract_Finance_ID,  string Payment_Details_PComments, string Payment_Details_SComments
        //string Payment_Details_PIssuing_Bank, string Payment_Details_PCredit_Card_No, string Payment_Details_PCard_Holders_Name, string Payment_Details_PExpiry, string Payment_Details_PSecurity_No, string Payment_Details_PFor_Depo, string Payment_Details_PFor_Bala, string Payment_Details_SCard_Type, string Payment_Details_SIssuing_Bank, string Payment_Details_SCredit_Card_No, string Payment_Details_SCard_Holders_Name, string Payment_Details_SExpiry, string Payment_Details_SSecurity_No, string Payment_Details_SFor_Depo, string Payment_Details_SFor_Bala, string Profile_ID, string Contract_Finance_ID, string Payment_Details_Insert_Date, string Payment_Details_PComments, string Payment_Details_SComments

        int paycheck = Queries2.PaymentExists(Session["fracido"].ToString());

        if (paycheck == 1)
        {
            int paydetails = Queries2.UpdatePaymentDetails(PCard_Type, PIssuing_Bank, PCredit_Card_No, PCard_Holders_Name, PExpiry, PSecurity_No, PFor_Depo, PFor_Bala, SCard_Type, SIssuing_Bank, SCredit_Card, SCard_Holders_Name, SExpiry, SSecurity_No, SFor_Depo, SFor_Bala, Pcomments, Scomments, Session["fracido"].ToString());
        }
        else
        {

            string PmentDetailsId = Queries2.getPaymentDetailsID(Session["Gofficeo"].ToString());
            int PmentDetails = Queries2.InserPaymentDetails(PmentDetailsId, PCard_Type, PIssuing_Bank, PCredit_Card_No, PCard_Holders_Name, PExpiry, PSecurity_No,
                       PFor_Depo, PFor_Bala, SCard_Type, SIssuing_Bank, SCredit_Card, SCard_Holders_Name, SExpiry, SSecurity_No, SFor_Depo, SFor_Bala, Session["ProfileIDo"].ToString(), Session["fracido"].ToString(), entrydate, Session["Gofficeo"].ToString(), Pcomments, Scomments);

        }




        //logs 


        if (String.Compare(Session["oDPMFractDropDownList"].ToString(), Deposit_PM) != 0)
        {
            string act = "Deposit Pay Method changed from:" + Session["oDPMFractDropDownList"].ToString() + "To:" + Deposit_PM;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Pay Method Updated", Session["oDPMFractDropDownList"].ToString(), Deposit_PM);
        }
        if (String.Compare(Session["oDPMFractDropDownList"].ToString(), Deposit_PM) != 0)
        {
            string act = "Affiliation ICE changed from:" + Session["Contract_Finance_Affil_ICEo"].ToString() + "To:" + affilice;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Affiliation ICE Updated", Session["Contract_Finance_Affil_ICEo"].ToString(), affilice);
        }
        if (String.Compare(Session["contsalesrepDropDownListo"].ToString(), salesrep) != 0)
        {
            string act = "Sales Rep changed from:" + Session["contsalesrepDropDownListo"].ToString() + "To:" + salesrep;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Sales Rep Updated", Session["contsalesrepDropDownListo"].ToString(), salesrep);
        }
        if (String.Compare(Session["TOManagerDropDownListo"].ToString(), tomanager) != 0)
        {
            string act = "TOmanager changed from:" + Session["TOManagerDropDownListo"].ToString() + "To:" + tomanager;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "TOmanager Updated", Session["TOManagerDropDownListo"].ToString(), tomanager);
        }
        if (String.Compare(Session["Contract_Finance_Purchase_Priceo"].ToString(), PurchasePrice) != 0)
        {
            string act = "Purchase price changed from:" + Session["Contract_Finance_Purchase_Priceo"].ToString() + "To:" + PurchasePrice;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Purchase price Updated", Session["Contract_Finance_Purchase_Priceo"].ToString(), PurchasePrice);
        }
        if (String.Compare(Session["ButtonUpDropDownListo"].ToString(), buttonup) != 0)
        {
            string act = "Buttonup changed from:" + Session["ButtonUpDropDownListo"].ToString() + "To:" + buttonup;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Buttonup Updated", Session["ButtonUpDropDownListo"].ToString(), buttonup);
        }
        if (String.Compare(Session["Contract_Finance_Admin_Feeso"].ToString(), AdminFees) != 0)
        {
            string act = "admin fees changed from:" + Session["Contract_Finance_Admin_Feeso"].ToString() + "To:" + AdminFees;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "admin fees Updated", Session["Contract_Finance_Admin_Feeso"].ToString(), AdminFees);
        }
        if (String.Compare(Session["Contract_Finance_MC_Feeso"].ToString(), MCFees) != 0)
        {
            string act = "MC fees changed from:" + Session["Contract_Finance_MC_Feeso"].ToString() + "To:" + MCFees;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "MC fees Updated", Session["Contract_Finance_MC_Feeso"].ToString(), MCFees);
        }
        if (String.Compare(Session["DealDrawerDropDownListo"].ToString(), DealDrawer) != 0)
        {
            string act = "deal status changed from:" + Session["DealDrawerDropDownListo"].ToString() + "To:" + DealDrawer;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "deal status Updated", Session["DealDrawerDropDownListo"].ToString(), DealDrawer);
        }
        if (String.Compare(Session["oPayMethodDropDownList"].ToString(), PaymentMethod) != 0)
        {
            string act = "Payment method changed from:" + Session["oPayMethodDropDownList"].ToString() + "To:" + PaymentMethod;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Payment method Updated", Session["oPayMethodDropDownList"].ToString(), PaymentMethod);
        }
        if (String.Compare(Session["oTextPayMethodDetails"].ToString(), PaymentMethodDeatils) != 0)
        {
            string act = "Pay method details changed from:" + Session["oTextPayMethodDetails"].ToString() + "To:" + PaymentMethodDeatils;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Payment Method Details Updated", Session["oTextPayMethodDetails"].ToString(), PaymentMethodDeatils);
        }
        if (String.Compare(Session["oTextPnumb"].ToString(), FinanceNumb) != 0)
        {
            string act = "Finance number changed from:" + Session["oTextPnumb"].ToString() + "To:" + FinanceNumb;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Finance Number Updated", Session["oTextPnumb"].ToString(), FinanceNumb);
        }
        if (String.Compare(Session["oCrownFinanceCurrDropDownList"].ToString(), CrownCurr) != 0)
        {
            string act = "Crown Finance Currency changed from:" + Session["oCrownFinanceCurrDropDownList"].ToString() + "To:" + CrownCurr;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Crown Finance Currecny Details Updated", Session["oCrownFinanceCurrDropDownList"].ToString(), CrownCurr);
        }
        if (String.Compare(Session["oContractVenueVPDropDownList"].ToString(), Contractvenue) != 0)
        {
            string act = "Contract Venue changed from:" + Session["oContractVenueVPDropDownList"].ToString() + "To:" + Contractvenue;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Contract Venue Details Updated", Session["oContractVenueVPDropDownList"].ToString(), Contractvenue);
        }

        if (String.Compare(Session["oYearOfIntDropDownList"].ToString(), TYearOfInterestP) != 0)
        {
            string act = "Year Of Int changed from:" + Session["oYearOfIntDropDownList"].ToString() + "To:" + TYearOfInterestP;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Year Of Int Updated", Session["oYearOfIntDropDownList"].ToString(), TYearOfInterestP);
        }
        if (String.Compare(Session["oCGroupvenueDropDownList"].ToString(), SC_Cancel_Group_Venue) != 0)
        {
            string act = "Cancel Group Venue changed from:" + Session["oCGroupvenueDropDownList"].ToString() + "To:" + SC_Cancel_Group_Venue;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Cancel Group Venue Updated", Session["oCGroupvenueDropDownList"].ToString(), SC_Cancel_Group_Venue);
        }
        if (String.Compare(Session["oCReasonDropDownList"].ToString(), SC_Cancel_Reason) != 0)
        {
            string act = "Cancel Reason changed from:" + Session["oCReasonDropDownList"].ToString() + "To:" + SC_Cancel_Reason;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Cancel Reason Updated", Session["oCReasonDropDownList"].ToString(), SC_Cancel_Reason);
        }

        if (String.Compare(Session["oCGroupvenueDropDownList"].ToString(), SC_Cancel_Group_Venue) != 0)
        {
            string act = "Cancel Group Venue changed from:" + Session["oCGroupvenueDropDownList"].ToString() + "To:" + SC_Cancel_Group_Venue;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Cancel Group Venue Updated", Session["oCGroupvenueDropDownList"].ToString(), SC_Cancel_Group_Venue);
        }
        if (String.Compare(Session["oCReasonDropDownList"].ToString(), SC_Cancel_Reason) != 0)
        {
            string act = "Cancel Reason changed from:" + Session["oCReasonDropDownList"].ToString() + "To:" + SC_Cancel_Reason;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Cancel Reason Updated", Session["oCReasonDropDownList"].ToString(), SC_Cancel_Reason);
        }



        if (conttype == "Fractional")
        {



            string Resort1 = Request.Form[ResortDropDownListF.UniqueID];
            if (Resort1=="Fractional Member")
            {
                resort = "FM";
            }
            string ResortF = Request.Form[ResortDropDownListF.UniqueID];
            string ResidenceNoF = Request.Form[ResidenceNoDropDownListF.UniqueID];
            string ResidenceTypeF = Request.Form[ResidenceTypeDropDownListF.UniqueID];

            
            string FractionalInt = FractionalIDropDownListF.SelectedItem.Text;
            string FractEntitle = EntitlementFracDropDownList.SelectedItem.Text;
            string FractFOccu = TextFOccuF.Text;
            string FractDura = TextFDuration.Text;
            string FractLOccu = TextFOccuL.Text;
            string FractLease = TextBoxDummyleaseoff.Text;

            


            string DepositF = TextDepositP.Text.Replace(",", "");
            string DepoPPA = TextDepoPPA.Text.Replace(",", "");
            string AdmissFeesF = TextAdmissFeesP.Text.Replace(",", "");
            string AdminFeesF = TextAdminFeesP.Text.Replace(",", "");
            string PurchasePriceF = TextPpurchasePrice.Text.Replace(",", "");
            string CoutryTaxF = TextCountryTaxP.Text.Replace(",", "");
            string GrandTotalP = TextGrandTotalP.Text.Replace(",", "");
            string BalanceDuePAF = TextPBalaceDPA.Text.Replace(",", "");
            string BalanceDuePAFTD = TextPBalaceDPATOPD.Text.Replace(",", "");

            string tPAFirstPayDateF = datepicker8.Text;

            string PAFirstPayDateF = tPAFirstPayDateF;// Convert.ToDateTime(tPAFirstPayDateF).ToString("yyyy-MM-dd");

            string PAAmountInstallF = TextPPAAmountInstall.Text.Replace(",", "");
            string PAFirstInstallF = TextPPAFInstall.Text.Replace(",", "");
            string BalanceDueDatesPAF = TextPBalanceDDates.Text;
            
            string RemarksF = TextRemarkP.Text;
             //EuroRatesF = TextEuroRateP.Text;
            // AusRatesF = TextAusRateP.Text;
            // GbpRatesF = TextGbpRateP.Text;
            // IdaRatesF = TextIdaRateP.Text;
            string UsePayProtectF = "";
            string PANoOfInstallF = TextPPANoInstall.Text;

            string TDcommmentF = TextBoxTempTDComment.Text;


            string INRexch="0", PurchasePriceUSD, AdminFeesUSD;

           

            //

            string DepositPUSD, CoutryTaxPUSD, excR, CoutryTaxPCGST, CoutryTaxPSGST;


            


            if (FinaCurrency != "USD")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                DepositPUSD = Math.Round(float.Parse(DepositF) / float.Parse(INRexch), 0).ToString();
                CoutryTaxPUSD = Math.Round(float.Parse(CoutryTaxF) / float.Parse(INRexch), 0).ToString();
                excR = INRexch.ToString();

                if (FinaCurrency == "INR")
                {

                    CoutryTaxPCGST = TextBoxCGST.Text.Replace(",", "");
                    CoutryTaxPSGST = TextBoxSGST.Text.Replace(",", "");


                    string kk = Session["ODeposit"].ToString();
                    if (kk != DepositF)
                    {
                        string depositnotax = Math.Round((float.Parse(DepositF) / 118) * 100, 0).ToString();
                        string depositSCGST = Math.Round(((float.Parse(DepositF) / 118) * 18) / 2, 0).ToString();
                        string depositGST = Math.Round((float.Parse(DepositF) / 118) * 18, 0).ToString();

                        int updatedepo = Queries2.Update_DepositRecieptDetails(DepositF, depositnotax, depositSCGST, depositGST, Deposit_PM, Session["fracido"].ToString());
                    }
                }
                else
                {
                    CoutryTaxPCGST = "0";
                    CoutryTaxPSGST = "0";
                   // excR = "0";
                }

            }
            else
            {
                DepositPUSD = DepositF;// "0";
                CoutryTaxPUSD = CoutryTaxF;// "0";
                CoutryTaxPCGST = "0";
                CoutryTaxPSGST = "0";
                excR = "0";
            }




            // Session["Globcurr"] = FinaCurrency;
         //   string PurchasePrice = TextPurchasePrice.Text;
         //   string AdminFees = TextAdminFees.Text;
            if (FinaCurrency != "USD")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                PurchasePriceUSD = Math.Round(float.Parse(PurchasePrice) / float.Parse(INRexch), 0).ToString();
                AdminFeesUSD = Math.Round(float.Parse(AdminFees) / float.Parse(INRexch), 0).ToString();
            }
            else
            {
                 PurchasePriceUSD = PurchasePrice;// "0";
                AdminFeesUSD = AdminFees;// "0";
            }

            /*
             Session["oPS_Deposit_USD"] = "";
        Session["oPS_Country_Tax_USD"] = "";
        Session["oContract_Finance_Purchase_Price_USD"] = "";
        Session["oContract_Finance_Admin_Fees_USD"] = "";

            
            
            */




          


            string InitDepof = TextInitDepo.Text.Replace(",", "");

            string BalDepof = TextBalDepo.Text.Replace(",", "");

            string CPAF = TextPrimaryCCard2.Text;

            string CPADepoF = TextCPADepoComment.Text;

            string DepoDatef = TextBoxNBDP.Text;

            string BalanceDueDatesPAF2 = TextPBalanceDDates2.Text;

            string RemarksF2 = TextRemarkP2.Text;


            string IniBalNoInstallF = TextIniInstP.Text;
            string IniBalInstAmtF = TextIniInstAmtP.Text.Replace(",", "");



            

            // 

            string t1 = EntitlementFracDropDownList.SelectedItem.Text;
            int fyear = Convert.ToInt32(TextFOccuF.Text);
            string ft1, ft2, BalloonPay,LastInstDate= Session["lastinstalldate"].ToString();

            if (fyear % 2 == 0)
            {
                ft1 = "Even";
            }
            else
            {
                ft1 = "Odd";
            }

            if (FCheckBox1.Checked)
            {
                ft2 = "Yes";
            }
            else
            {
                ft2 = "No";
            }

            if (CheckBoxBalloonP.Checked)
            {
                BalloonPay = "BP";
            }
            else
            {
                BalloonPay = "";
            }



            string TotalBalanceF = TextTotalBalance.Text.Replace(",", "");

            int icnt = Queries2.checkforexistinginvoice(Session["fracido"].ToString());
            if (icnt == 0)
            {

                string desc, amot1, date, curr, text11, text12, text13, text14, desc1="";
                string PA = "PA";
                // string PANoOfInstallF = TextNoOfInstallF.Text;
                //string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                //string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallF); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12].Replace(",", "");
                    //text15 = "textBoxN_" + i + "3";
                    //amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                        // if (int.Parse(amot1) != 0)
                        //{

                        if (PANoOfInstallF != "1")
                        {
                            if (i == int.Parse(PANoOfInstallF))
                            {

                                text13 = "textBox_" + i + "3";
                                LastInstDate = Request[text13];
                            }
                        }

                    string finaInstI = Queries2.getFinanceInstallID(Session["Gofficeo"].ToString());
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, Session["ProfileIDo"].ToString(), PA, Session["Gofficeo"].ToString(), Session["fracido"].ToString(),DateTime.Now);
                    desc1 += "Installment Id: " + finaInstI + ",desc: " + desc + ",Date: " + date + ",amount: " + amot1 + ",Currency: " + curr + ",";


                    // }

                }

                int insertlognewInstall = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, GenContNumb, desc1, user, DateTime.Now.ToString(), "Edit_contract.aspx", "Installments Details Added", "", desc1);
            }
                int contFracPS = Queries2.UpdateContract_Fractional(ResortF, ResidenceNoF, ResidenceTypeF, FractionalInt, FractEntitle, FractFOccu, FractDura, FractLOccu,Session["fracido"].ToString(),FractLease);

            int contup = Queries2.UpdateFracPS(Deposit_PM,  DepositF,  AdmissFeesF,  AdminFeesF,  PurchasePriceF,  BalanceDuePAF, PANoOfInstallF,  PAFirstPayDateF,  PAAmountInstallF,  PAFirstInstallF,  BalanceDueDatesPAF, RemarksF,  EuroRatesF,  AusRatesF,  GbpRatesF,  IdaRatesF, YearOfInterestP, TotalBalanceF, DateTime.Now.ToString(), Session["fracido"].ToString(), InitDepof, BalDepof, DepoDatef, BalanceDueDatesPAF2, RemarksF2,CPAF,IniBalNoInstallF,IniBalInstAmtF,BalloonPay,LastInstDate,CPADepoF, BalanceDuePAFTD,DepoPPA,GrandTotalP, DepositPUSD, CoutryTaxPUSD, CoutryTaxPCGST, CoutryTaxPSGST, excR, TDcommmentF);

            int contFina = Queries2.UpdateContFrac(affilice, affilhp, salesrep, tomanager, buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, ID_Card, CrownCurr, Session["fracido"].ToString(), Session["DealRegDate"].ToString(),ft1,ft2,DateTime.Now, Convert.ToInt32(Session["cweekno"]),ContComment,PaymentMethodDeatils, Boverride, PurchasePriceUSD, AdminFeesUSD,Contractvenue);

            int contFinadetails = Queries2.UpdateFinanceDetails(tPurchase1,  QDepo1,  AmtCre1,  CreCurr1,  NoOfMonth1,  RateOfInt1,  MonthlyRepay1, Session["fracido"].ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect,FinaDate);



            if (String.Compare(Session["oResidenceNoDropDownListF"].ToString(), ResidenceNoF) != 0)
            {
                string act = "Residence no changed from:" + Session["oResidenceNoDropDownListF"].ToString() + "To:" + ResidenceNoF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Residence no Updated", Session["oResidenceNoDropDownListF"].ToString(), ResidenceNoF);
            }
            if (String.Compare(Session["oResidenceTypeDropDownListF"].ToString(), ResidenceTypeF) != 0)
            {
                string act = "Residence Type changed from:" + Session["oResidenceTypeDropDownListF"].ToString() + "To:" + ResidenceTypeF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Residence Type Updated", Session["oResidenceTypeDropDownListF"].ToString(), ResidenceTypeF);
            }
            if (String.Compare(Session["oFractionalIDropDownListF"].ToString(), FractionalInt) != 0)
            {
                string act = "Fractional Interest changed from:" + Session["oFractionalIDropDownListF"].ToString() + "To:" + FractionalInt;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Fractional Interest Updated", Session["oFractionalIDropDownListF"].ToString(), FractionalInt);
            }
            if (String.Compare(Session["oEntitlementFracDropDownList"].ToString(), FractEntitle) != 0)
            {
                string act = "Fractional Entitlement changed from:" + Session["oEntitlementFracDropDownList"].ToString() + "To:" + FractEntitle;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Fractional Entitlement Updated", Session["oEntitlementFracDropDownList"].ToString(), FractEntitle);
            }
            if (String.Compare(Session["oTextFOccuF"].ToString(), FractFOccu) != 0)
            {
                string act = "First year Occupancy changed from:" + Session["oTextFOccuF"].ToString() + "To:" + FractFOccu;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First year Occupancy Updated", Session["oTextFOccuF"].ToString(), FractFOccu);
            }
            if (String.Compare(Session["oTextFDuration"].ToString(), FractDura) != 0)
            {
                string act = "Duration changed from:" + Session["oTextFDuration"].ToString() + "To:" + FractDura;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Duration Updated", Session["oTextFDuration"].ToString(), FractDura);
            }
            if (String.Compare(Session["oTextFOccuL"].ToString(), FractLOccu) != 0)
            {
                string act = "Last year Occupancy changed from:" + Session["oTextFOccuL"].ToString() + "To:" + FractLOccu;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Last year Occupancy Updated", Session["oTextFOccuL"].ToString(), FractLOccu);
            }

            if (String.Compare(Session["oTextBoxDummyleaseoff"].ToString(), FractLease) != 0)
            {
                string act = "Fractional Lease Off changed from:" + Session["oTextBoxDummyleaseoff"].ToString() + "To:" + FractLease;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Fractional Lease Off Updated", Session["oTextBoxDummyleaseoff"].ToString(), FractLease);
            }

            if (String.Compare(Session["ODeposit"].ToString(), DepositF) != 0)
            {
                string act = "Deposit changed from:" + Session["ODeposit"].ToString() + "To:" + DepositF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Updated", Session["ODeposit"].ToString(), DepositF);
            }

            if (String.Compare(Session["oTextDepoPPA"].ToString(), DepoPPA) != 0)
            {
                string act = "Deposit PA changed from:" + Session["oTextDepoPPA"].ToString() + "To:" + DepoPPA;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit PA Updated", Session["oTextDepoPPA"].ToString(), DepoPPA);
            }

            if (String.Compare(Session["oTextAdmissFeesP"].ToString(), AdmissFeesF) != 0)
            {
                string act = "Admission Fees changed from:" + Session["oTextAdmissFeesP"].ToString() + "To:" + AdmissFeesF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admission Fees Updated", Session["oTextAdmissFeesP"].ToString(), AdmissFeesF);
            }

            if (String.Compare(Session["oTextAdminFeesP"].ToString(), AdminFeesF) != 0)
            {
                string act = "Administration Fees changed from:" + Session["oTextAdminFeesP"].ToString() + "To:" + AdminFeesF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Administration Fees Updated", Session["oTextAdminFeesP"].ToString(), AdminFeesF);
            }



            if (String.Compare(Session["oTextPpurchasePrice"].ToString(), PurchasePriceF) != 0)
            {
                string act = "Purchase Price changed from:" + Session["oTextPpurchasePrice"].ToString() + "To:" + PurchasePriceF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Purchase Price Updated", Session["oTextPpurchasePrice"].ToString(), PurchasePriceF);
            }

            if (String.Compare(Session["oTextCountryTaxP"].ToString(), CoutryTaxF) != 0)
            {
                string act = "Country Tax changed from:" + Session["oTextCountryTaxP"].ToString() + "To:" + CoutryTaxF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admission Fees Updated", Session["oTextCountryTaxP"].ToString(), CoutryTaxF);
            }

            if (String.Compare(Session["oTextGrandTotalP"].ToString(), GrandTotalP) != 0)
            {
                string act = "Grand Total changed from:" + Session["oTextGrandTotalP"].ToString() + "To:" + GrandTotalP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Grand Total Updated", Session["oTextGrandTotalP"].ToString(), GrandTotalP);
            }

            if (String.Compare(Session["oTextPBalaceDPA"].ToString(), BalanceDuePAF) != 0)
            {
                string act = "Balance Due changed from:" + Session["oTextPBalaceDPA"].ToString() + "To:" + BalanceDuePAF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Updated", Session["oTextPBalaceDPA"].ToString(), BalanceDuePAF);
            }

            if (String.Compare(Session["oTextPBalaceDPATOPD"].ToString(), BalanceDuePAFTD) != 0)
            {
                string act = "Balance Due TOP Drawer changed from:" + Session["oTextPBalaceDPATOPD"].ToString() + "To:" + BalanceDuePAFTD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due TOP Drawer Updated", Session["oTextPBalaceDPATOPD"].ToString(), BalanceDuePAFTD);
            }

            if (String.Compare(Session["oPS_PA_FInstall_Date"].ToString(), tPAFirstPayDateF) != 0)
            {
                string act = "First installment Date changed from:" + Session["oPS_PA_FInstall_Date"].ToString() + "To:" + tPAFirstPayDateF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First installment Date Updated", Session["oPS_PA_FInstall_Date"].ToString(), tPAFirstPayDateF);
            }

            if (String.Compare(Session["oTextPPAAmountInstall"].ToString(), PAAmountInstallF) != 0)
            {
                string act = "Other Installment changed from:" + Session["oTextPPAAmountInstall"].ToString() + "To:" + PAAmountInstallF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Other Installment Updated", Session["oTextPPAAmountInstall"].ToString(), PAAmountInstallF);
            }


            if (String.Compare(Session["oTextPPAFInstall"].ToString(), PAFirstInstallF) != 0)
            {
                string act = "First installment Date changed from:" + Session["oTextPPAFInstall"].ToString() + "To:" + PAFirstInstallF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First installment Date Updated", Session["oTextPPAFInstall"].ToString(), PAFirstInstallF);
            }

            if (String.Compare(Session["oTextPBalanceDDates"].ToString(), BalanceDueDatesPAF) != 0)
            {
                string act = "Balance Due Dates changed from:" + Session["oTextPBalanceDDates"].ToString() + "To:" + BalanceDueDatesPAF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Dates Updated", Session["oTextPBalanceDDates"].ToString(), BalanceDueDatesPAF);
            }

            if (String.Compare(Session["oPS_TP_Comment"].ToString(), TDcommmentF) != 0)
            {
                string act = "Top Drawer comment changed from:" + Session["oPS_TP_Comment"].ToString() + "To:" + TDcommmentF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Top Drawer comment Updated", Session["oPS_TP_Comment"].ToString(), TDcommmentF);
            }




            if (String.Compare(Session["oTextPPANoInstall"].ToString(), PANoOfInstallF) != 0)
            {
                string act = "PA No of Installment changed from:" + Session["oTextPPANoInstall"].ToString() + "To:" + PANoOfInstallF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "PA No of Installment Updated", Session["oTextPPANoInstall"].ToString(), PANoOfInstallF);
            }

            if (String.Compare(Session["oTextRemarkP"].ToString(), RemarksF) != 0)
            {
                string act = "Remarks changed from:" + Session["oTextRemarkP"].ToString() + "To:" + RemarksF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Remarks Updated", Session["oTextRemarkP"].ToString(), RemarksF);
            }


            if (String.Compare(Session["exrate"].ToString(), INRexch) != 0)
            {
                string act = "Exchange Rate changed from:" + Session["exrate"].ToString() + "To:" + INRexch;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Exchange Rate Updated", Session["exrate"].ToString(), INRexch);
            }

            if (String.Compare(Session["oPS_Deposit_USD"].ToString(), DepositPUSD) != 0)
            {
                string act = "Deposit USD changed from:" + Session["oPS_Deposit_USD"].ToString() + "To:" + DepositPUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit USD Updated", Session["oPS_Deposit_USD"].ToString(), DepositPUSD);
            }

            if (String.Compare(Session["oPS_Country_Tax_USD"].ToString(), CoutryTaxPUSD) != 0)
            {
                string act = "Country Tax USD changed from:" + Session["oPS_Country_Tax_USD"].ToString() + "To:" + CoutryTaxPUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Country Tax USD Updated", Session["oPS_Country_Tax_USD"].ToString(), CoutryTaxPUSD);
            }
            if (String.Compare(Session["oContract_Finance_Purchase_Price_USD"].ToString(), PurchasePriceUSD) != 0)
            {
                string act = "Purchase_Price USD changed from:" + Session["oContract_Finance_Purchase_Price_USD"].ToString() + "To:" + PurchasePriceUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Purchase_Price USD Updated", Session["oContract_Finance_Purchase_Price_USD"].ToString(), PurchasePriceUSD);
            }
            if (String.Compare(Session["oContract_Finance_Admin_Fees_USD"].ToString(), AdminFeesUSD) != 0)
            {
                string act = "Admin_Fees USD changed from:" + Session["oContract_Finance_Admin_Fees_USD"].ToString() + "To:" + AdminFeesUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admin_Fees USD Updated", Session["oContract_Finance_Admin_Fees_USD"].ToString(), AdminFeesUSD);
            }

            if (String.Compare(Session["oTextInitDepo"].ToString(), InitDepof) != 0)
            {
                string act = "Initial Deposit changed from:" + Session["oTextInitDepo"].ToString() + "To:" + InitDepof;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Deposit Updated", Session["oTextInitDepo"].ToString(), InitDepof);
            }
            if (String.Compare(Session["oTextBalDepo"].ToString(), BalDepof) != 0)
            {
                string act = "Balance Deposit changed from:" + Session["oTextBalDepo"].ToString() + "To:" + BalDepof;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Deposit  Updated", Session["oTextBalDepo"].ToString(), BalDepof);
            }

            if (String.Compare(Session["oTextPrimaryCCard2"].ToString(), CPAF) != 0)
            {
                string act = "CPA comment changed from:" + Session["oTextPrimaryCCard2"].ToString() + "To:" + CPAF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "CPA comment  Updated", Session["oTextPrimaryCCard2"].ToString(), CPAF);
            }

            if (String.Compare(Session["oPS_Deposit_Comment"].ToString(), CPADepoF) != 0)
            {
                string act = "CPA Deposit changed from:" + Session["oPS_Deposit_Comment"].ToString() + "To:" + CPADepoF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "CPA Deposit  Updated", Session["oPS_Deposit_Comment"].ToString(), CPADepoF);
            }

            if (String.Compare(Session["oTextPBalanceDDates2"].ToString(), BalanceDueDatesPAF2) != 0)
            {
                string act = "Balance Due dates 2 changed from:" + Session["oTextPBalanceDDates2"].ToString() + "To:" + BalanceDueDatesPAF2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due dates 2 Updated", Session["oTextPBalanceDDates2"].ToString(), BalanceDueDatesPAF2);
            }
            if (String.Compare(Session["oPS_Deposit_Date"].ToString(), DepoDatef) != 0)
            {
                string act = "Deposit Date changed from:" + Session["oPS_Deposit_Date"].ToString() + "To:" + DepoDatef;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Date Updated", Session["oPS_Deposit_Date"].ToString(), DepoDatef);
            }
            if (String.Compare(Session["oTextRemarkP2"].ToString(), RemarksF2) != 0)
            {
                string act = "Remarks 2 changed from:" + Session["oTextRemarkP2"].ToString() + "To:" + RemarksF2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Remarks 2 Updated", Session["oTextRemarkP2"].ToString(), RemarksF2);
            }


            if (String.Compare(Session["oTextIniInstP"].ToString(), IniBalNoInstallF) != 0)
            {
                string act = "Initial Bal No of Installment changed from:" + Session["oTextIniInstP"].ToString() + "To:" + IniBalNoInstallF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Bal No of Installment Updated", Session["oTextIniInstP"].ToString(), IniBalNoInstallF);
            }
            if (String.Compare(Session["oTextIniInstAmtP"].ToString(), IniBalInstAmtF) != 0)
            {
                string act = "Initial Bal No of Installment amount changed from:" + Session["oTextIniInstAmtP"].ToString() + "To:" + IniBalInstAmtF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Bal No of Installment amount Updated", Session["oTextIniInstAmtP"].ToString(), IniBalInstAmtF);
            }
            if (String.Compare(Session["oTextTotalBalance"].ToString(), TotalBalanceF) != 0)
            {
                string act = "Total balance changed from:" + Session["oTextTotalBalance"].ToString() + "To:" + TotalBalanceF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Total balance Updated", Session["oTextTotalBalance"].ToString(), TotalBalanceF);
            }




        }

        else if(conttype=="Points")
        {
           // string ContClub = ContractClubPDropDownList.SelectedItem.Text;
           // GlobContClub = ContClub;
            string NoofPoints = TextNoPoints.Text;
            string PointsEntitle = EntitlementPoinDropDownList.SelectedItem.Text;
            string PointsMemFees = TextPMemFees.Text;
            string PointsPropFees = TextPPropFees.Text;
            string PointsFOccu = TextPFOccu.Text;
            string PointsDura = TextPDura.Text;
            string PointsLOccu = TextPLOccu.Text;


           









            string DepositP = TextDepositP.Text.Replace(",", "");
            string DepoPPA = TextDepoPPA.Text.Replace(",", "");
            string AdmissFeesP = TextAdmissFeesP.Text.Replace(",", "");
            string AdminFeesP = TextAdminFeesP.Text.Replace(",", "");
            string PurchasePriceP = TextPpurchasePrice.Text.Replace(",", "");
            string CoutryTaxP = TextCountryTaxP.Text.Replace(",", "");
            string GrandTotalP = TextGrandTotalP.Text.Replace(",", "");
            string BalanceDuePAP = TextPBalaceDPA.Text.Replace(",", "");
            string BalanceDuePAPTOPD = TextPBalaceDPATOPD.Text.Replace(",", "");
            string PANoOfInstallP = TextPPANoInstall.Text;
            string tPAFirstPayDateP = datepicker8.Text;

            string PAFirstPayDateP = tPAFirstPayDateP;// Convert.ToDateTime(tPAFirstPayDateP).ToString("yyyy-MM-dd");

            string INRexch="0", PurchasePriceUSD, AdminFeesUSD;



            // Session["Globcurr"] = FinaCurrency;
            //string PurchasePrice = TextPurchasePrice.Text;
           // string AdminFees = TextAdminFees.Text;
            if (FinaCurrency != "USD")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                PurchasePriceUSD = Math.Round(float.Parse(PurchasePrice) / float.Parse(INRexch), 0).ToString();
                AdminFeesUSD = Math.Round(float.Parse(AdminFees) / float.Parse(INRexch), 0).ToString();
            }
            else
            {
                 PurchasePriceUSD = PurchasePrice;// "0";
                AdminFeesUSD = AdminFees;// "0";
            }



            string PAAmountInstallP = TextPPAAmountInstall.Text.Replace(",", "");
            string PAFirstInstallP = TextPPAFInstall.Text.Replace(",", "");
            string BalanceDueDatesPAP = TextPBalanceDDates.Text.Replace(",", "");
            string DepositSAP = TextPDepositSA.Text.Replace(",", "");
            string ApplicationFeesP = TextAppliFeesP.Text.Replace(",", "");
            string AdminServiceP = TextAdminServiceP.Text.Replace(",", "");
            string TotalServicePriceP = TextTotalServicePriceP.Text.Replace(",", "");
            string BalanceDueSAP = TextBalanceDueSAP.Text.Replace(",", "");
           
            string BalanceDueDatesSAP = TextBalanceDDatesSAP.Text;
            string RemarksP = TextRemarkP.Text;
            
            string UsePayProtectP = "";

            string TotalBalance = TextTotalBalance.Text.Replace(",", "");

            
            string InitDepop = TextInitDepo.Text.Replace(",", "");

            string BalDepop = TextBalDepo.Text.Replace(",", "");

            string CPAP = TextPrimaryCCard2.Text;

            string CPADepo = TextCPADepoComment.Text;

            string DepoDatep = TextBoxNBDP.Text;

            string BalanceDueDatesPAP2 = TextPBalanceDDates2.Text;
            string BalanceDueDatesSAP2 = TextBalanceDDatesSAP2.Text;
            string RemarksP2 = TextRemarkP2.Text;


            string IniBalNoInstallP = TextIniInstP.Text;
            string IniBalInstAmtP = TextIniInstAmtP.Text.Replace(",", "");

            string TDcommmentP = TextBoxTempTDComment.Text;

            string t1 = EntitlementPoinDropDownList.SelectedItem.Text;
            int fyear = Convert.ToInt32(TextPFOccu.Text);
            string ft1, ft2,BalloonPay, LastInstDate =  Session["lastinstalldate"].ToString();



           


            string DepositPUSD, CoutryTaxPUSD, excR, CoutryTaxPCGST, CoutryTaxPSGST;




            if (FinaCurrency != "USD")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                DepositPUSD = Math.Round(float.Parse(DepositP) / float.Parse(INRexch), 0).ToString();
                CoutryTaxPUSD = Math.Round(float.Parse(CoutryTaxP) / float.Parse(INRexch), 0).ToString();
                excR = INRexch.ToString();

                if (FinaCurrency == "INR")
                {

                    CoutryTaxPCGST = TextBoxCGST.Text.Replace(",", "");
                    CoutryTaxPSGST = TextBoxSGST.Text.Replace(",", "");


                    string kk = Session["ODeposit"].ToString();
                    if (kk != DepositP)
                    {
                        string depositnotax = Math.Round((float.Parse(DepositP) / 118) * 100, 0).ToString();
                        string depositSCGST = Math.Round(((float.Parse(DepositP) / 118) * 18) / 2, 0).ToString();
                        string depositGST = Math.Round((float.Parse(DepositP) / 118) * 18, 0).ToString();

                        int updatedepo = Queries2.Update_DepositRecieptDetails(DepositP, depositnotax, depositSCGST, depositGST, Deposit_PM, Session["fracido"].ToString());
                    }
                }
                else
                {
                    CoutryTaxPCGST = "0";
                    CoutryTaxPSGST = "0";
                   // excR = "0";
                }

            }


          


            /* if (FinaCurrency == "INR")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                DepositPUSD = Math.Round(float.Parse(DepositP) / float.Parse(INRexch), 0).ToString();
                CoutryTaxPUSD = Math.Round(float.Parse(CoutryTaxP) / float.Parse(INRexch), 0).ToString();
                CoutryTaxPCGST = TextBoxCGST.Text;
                CoutryTaxPSGST = TextBoxSGST.Text;
                excR = INRexch.ToString();


  string kk = Session["ODeposit"].ToString();
                if (kk != DepositP)
                {
                    string depositnotax = Math.Round((float.Parse(DepositP) / 118) * 100, 0).ToString();
                    string depositSCGST = Math.Round(((float.Parse(DepositP) / 118) * 18) / 2, 0).ToString();
                    string depositGST = Math.Round((float.Parse(DepositP) / 118) * 18, 0).ToString();

                    int updatedepo = Queries2.Update_DepositRecieptDetails(DepositP, depositnotax, depositSCGST, depositGST, Deposit_PM, Session["fracido"].ToString());
                }

            }*/
            else
            {
                DepositPUSD = DepositP;// "0";
                CoutryTaxPUSD = CoutryTaxP;// "0";
                CoutryTaxPCGST = "0";
                CoutryTaxPSGST = "0";
                excR = "0";
            }

            if (fyear % 2 == 0)
            {
                ft1 = "Even";
            }
            else
            {
                ft1 = "Odd";
            }

            if (PCheckBox1.Checked)
            {
                ft2 = "Yes";
            }
            else
            {
                ft2 = "No";
            }

            if (CheckBoxBalloonP.Checked)
            {
                BalloonPay = "BP";
            }
            else
            {
                BalloonPay = "";
            }


           


            int icnt = Queries2.checkforexistinginvoice(Session["fracido"].ToString());
            if (icnt == 0)
            {
                string desc, amot1, amot2, date,date1, curr, text11, text12, text13, text14, text15,desc1="";
                string PA = "PA";
                string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallP); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12].Replace(",", "");
                    text15 = "textBoxN_" + i + "3";
                    amot2 = Request[text15].Replace(",", "");
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                        //date = Convert.ToDateTime(date1).ToString("yyyy-MM-dd");


                        if (PANoOfInstallP != "1")
                        {
                            if (i == int.Parse(PANoOfInstallP))
                            {
                                text13 = "textBox_" + i + "3";
                                LastInstDate = Request[text13];
                            }
                        }


                    if (int.Parse(amot1) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(Session["Gofficeo"].ToString());
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, Session["ProfileIDo"].ToString(), PA, Session["Gofficeo"].ToString(), Session["fracido"].ToString(), DateTime.Now);
                        desc1 += "Installment Id: " + finaInstI + ",desc: " + desc + ",Date: " + date + ",amount: " + amot1 + ",Currency: " + curr + ",";
                    }
                    if (amot2 == "")
                    {
                        amot2 = "0";
                    }

                    if (int.Parse(amot2) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(Session["Gofficeo"].ToString());
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, Session["ProfileIDo"].ToString(), SA, Session["Gofficeo"].ToString(), Session["fracido"].ToString(), DateTime.Now);
                        desc1 += "Installment Id: " + finaInstI + ",desc: " + desc + ",Date: " + date + ",amount: " + amot1 + ",Currency: " + curr + ",";
                    }

                }

                int insertlognewInstall = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, GenContNumb, desc1, user, DateTime.Now.ToString(), "Edit_contract.aspx", "Installments Details Added", "", desc1);


            }

            int contFracPS = Queries2.UpdateCT_Points( NoofPoints,  PointsEntitle,  PointsMemFees,  PointsPropFees,  PointsFOccu,  PointsDura,  PointsLOccu,  Session["fracido"].ToString());
            int contup = Queries2.UpdatePointPS( Deposit_PM,  DepositP,  DepoPPA,  DepositSAP,  AdmissFeesP,  ApplicationFeesP,  AdminFeesP,  AdminServiceP,  PurchasePriceP,  TotalServicePriceP,  CoutryTaxP,  GrandTotalP,  BalanceDuePAP,  BalanceDueSAP,  PANoOfInstallP,  PAFirstPayDateP,  PAAmountInstallP,  PAFirstInstallP,  BalanceDueDatesPAP,  BalanceDueDatesSAP,  RemarksP,  TotalBalance, EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF, YearOfInterestP, DateTime.Now.ToString(), Session["fracido"].ToString(),InitDepop,BalDepop,DepoDatep,BalanceDueDatesPAP2,BalanceDueDatesSAP2,RemarksP2,CPAP,IniBalNoInstallP,IniBalInstAmtP,BalloonPay,LastInstDate,CPADepo, BalanceDuePAPTOPD, DepositPUSD, CoutryTaxPUSD, CoutryTaxPCGST, CoutryTaxPSGST, excR, TDcommmentP);
            int contFina = Queries2.UpdateContFrac(affilice, affilhp, salesrep, tomanager, buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, ID_Card, CrownCurr, Session["fracido"].ToString(), Session["DealRegDate"].ToString(), ft1, ft2, DateTime.Now, Convert.ToInt32(Session["cweekno"]),ContComment, PaymentMethodDeatils, Boverride, PurchasePriceUSD, AdminFeesUSD,Contractvenue);

            int contFinadetails = Queries2.UpdateFinanceDetails(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, Session["fracido"].ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect,FinaDate);



            if (String.Compare(Session["oTextNoPoints"].ToString(), NoofPoints) != 0)
            {
                string act = "No. of Points changed from:" + Session["oTextNoPoints"].ToString() + "To:" + NoofPoints;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "No. of Points Updated", Session["oTextNoPoints"].ToString(), NoofPoints);
            }

            if (String.Compare(Session["oEntitlementPoinDropDownList"].ToString(), PointsEntitle) != 0)
            {
                string act = "Entitlement changed from:" + Session["oEntitlementPoinDropDownList"].ToString() + "To:" + PointsEntitle;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Entitlement Updated", Session["oEntitlementPoinDropDownList"].ToString(), PointsEntitle);
            }

            if (String.Compare(Session["oTextMemFeesp"].ToString(), PointsMemFees) != 0)
            {
                string act = "Member Fees changed from:" + Session["oTextMemFeesp"].ToString() + "To:" + PointsMemFees;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Member Fees Updated", Session["oTextMemFeesp"].ToString(), PointsMemFees);
            }

            if (String.Compare(Session["oTextPropFeesp"].ToString(), PointsPropFees) != 0)
            {
                string act = "Property Fees changed from:" + Session["oTextPropFeesp"].ToString() + "To:" + PointsPropFees;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Property Fees Updated", Session["oTextPropFeesp"].ToString(), PointsPropFees);
            }

            if (String.Compare(Session["oTextPFOccu"].ToString(), PointsFOccu) != 0)
            {
                string act = "First year Occupancy changed from:" + Session["oTextPFOccu"].ToString() + "To:" + PointsFOccu;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First year Occupancy Updated", Session["oTextPFOccu"].ToString(), PointsFOccu);
            }
            if (String.Compare(Session["oTextPDura"].ToString(), PointsDura) != 0)
            {
                string act = "Duration changed from:" + Session["oTextPDura"].ToString() + "To:" + PointsDura;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Duration Updated", Session["oTextPDura"].ToString(), PointsDura);
            }
            if (String.Compare(Session["oTextPLOccu"].ToString(), PointsLOccu) != 0)
            {
                string act = "Last year Occupancy changed from:" + Session["oTextPLOccu"].ToString() + "To:" + PointsLOccu;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Last year Occupancy Updated", Session["oTextPLOccu"].ToString(), PointsLOccu);
            }



            if (String.Compare(Session["ODeposit"].ToString(), DepositP) != 0)
            {
                string act = "Deposit changed from:" + Session["ODeposit"].ToString() + "To:" + DepositP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Updated", Session["ODeposit"].ToString(), DepositP);
            }

            if (String.Compare(Session["oTextDepoPPA"].ToString(), DepoPPA) != 0)
            {
                string act = "Deposit PA changed from:" + Session["oTextDepoPPA"].ToString() + "To:" + DepoPPA;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit PA Updated", Session["oTextDepoPPA"].ToString(), DepoPPA);
            }

            if (String.Compare(Session["oTextAdmissFeesP"].ToString(), AdmissFeesP) != 0)
            {
                string act = "Admission Fees changed from:" + Session["oTextAdmissFeesP"].ToString() + "To:" + AdmissFeesP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admission Fees Updated", Session["oTextAdmissFeesP"].ToString(), AdmissFeesP);
            }

            if (String.Compare(Session["oTextAdminFeesP"].ToString(), AdminFeesP) != 0)
            {
                string act = "Administration Fees changed from:" + Session["oTextAdminFeesP"].ToString() + "To:" + AdminFeesP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Administration Fees Updated", Session["oTextAdminFeesP"].ToString(), AdminFeesP);
            }



            if (String.Compare(Session["oTextPpurchasePrice"].ToString(), PurchasePriceP) != 0)
            {
                string act = "Purchase Price changed from:" + Session["oTextPpurchasePrice"].ToString() + "To:" + PurchasePriceP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Purchase Price Updated", Session["oTextPpurchasePrice"].ToString(), PurchasePriceP);
            }

            if (String.Compare(Session["oTextCountryTaxP"].ToString(), CoutryTaxP) != 0)
            {
                string act = "Country Tax changed from:" + Session["oTextCountryTaxP"].ToString() + "To:" + CoutryTaxP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admission Fees Updated", Session["oTextCountryTaxP"].ToString(), CoutryTaxP);
            }

            if (String.Compare(Session["oTextGrandTotalP"].ToString(), GrandTotalP) != 0)
            {
                string act = "Grand Total changed from:" + Session["oTextGrandTotalP"].ToString() + "To:" + GrandTotalP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Grand Total Updated", Session["oTextGrandTotalP"].ToString(), GrandTotalP);
            }

            if (String.Compare(Session["oTextPBalaceDPA"].ToString(), BalanceDuePAP) != 0)
            {
                string act = "Balance Due changed from:" + Session["oTextPBalaceDPA"].ToString() + "To:" + BalanceDuePAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Updated", Session["oTextPBalaceDPA"].ToString(), BalanceDuePAP);
            }

            if (String.Compare(Session["oTextPBalaceDPATOPD"].ToString(), BalanceDuePAPTOPD) != 0)
            {
                string act = "Balance Due TOP Drawer changed from:" + Session["oTextPBalaceDPATOPD"].ToString() + "To:" + BalanceDuePAPTOPD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due TOP Drawer Updated", Session["oTextPBalaceDPATOPD"].ToString(), BalanceDuePAPTOPD);
            }

            if (String.Compare(Session["oPS_PA_FInstall_Date"].ToString(), tPAFirstPayDateP) != 0)
            {
                string act = "First installment Date changed from:" + Session["oPS_PA_FInstall_Date"].ToString() + "To:" + tPAFirstPayDateP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First installment Date Updated", Session["oPS_PA_FInstall_Date"].ToString(), tPAFirstPayDateP);
            }

            if (String.Compare(Session["oTextPPAAmountInstall"].ToString(), PAAmountInstallP) != 0)
            {
                string act = "Other Installment changed from:" + Session["oTextPPAAmountInstall"].ToString() + "To:" + PAAmountInstallP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Other Installment Updated", Session["oTextPPAAmountInstall"].ToString(), PAAmountInstallP);
            }


            if (String.Compare(Session["oTextPPAFInstall"].ToString(), PAFirstInstallP) != 0)
            {
                string act = "First installment Date changed from:" + Session["oTextPPAFInstall"].ToString() + "To:" + PAFirstInstallP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First installment Date Updated", Session["oTextPPAFInstall"].ToString(), PAFirstInstallP);
            }

            if (String.Compare(Session["oTextPBalanceDDates"].ToString(), BalanceDueDatesPAP) != 0)
            {
                string act = "Balance Due Dates changed from:" + Session["oTextPBalanceDDates"].ToString() + "To:" + BalanceDueDatesPAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Dates Updated", Session["oTextPBalanceDDates"].ToString(), BalanceDueDatesPAP);
            }

            if (String.Compare(Session["oPS_TP_Comment"].ToString(), TDcommmentP) != 0)
            {
                string act = "Top Drawer comment changed from:" + Session["oPS_TP_Comment"].ToString() + "To:" + TDcommmentP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Top Drawer comment Updated", Session["oPS_TP_Comment"].ToString(), TDcommmentP);
            }




            if (String.Compare(Session["oTextPPANoInstall"].ToString(), PANoOfInstallP) != 0)
            {
                string act = "PA No of Installment changed from:" + Session["oTextPPANoInstall"].ToString() + "To:" + PANoOfInstallP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "PA No of Installment Updated", Session["oTextPPANoInstall"].ToString(), PANoOfInstallP);
            }


            if (String.Compare(Session["oTextPDepositSA"].ToString(), DepositSAP) != 0)
            {
                string act = "Deposit SA changed from:" + Session["oTextPDepositSA"].ToString() + "To:" + DepositSAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit SA Updated", Session["oTextPDepositSA"].ToString(), DepositSAP);
            }


            if (String.Compare(Session["oTextAppliFeesP"].ToString(), ApplicationFeesP) != 0)
            {
                string act = "Application Fees changed from:" + Session["oTextAppliFeesP"].ToString() + "To:" + ApplicationFeesP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Application Fees Updated", Session["oTextAppliFeesP"].ToString(), ApplicationFeesP);
            }

            if (String.Compare(Session["oTextAdminServiceP"].ToString(), AdminServiceP) != 0)
            {
                string act = "Admin Service changed from:" + Session["oTextAdminServiceP"].ToString() + "To:" + AdminServiceP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admin Service Updated", Session["oTextAdminServiceP"].ToString(), AdminServiceP);
            }

            if (String.Compare(Session["oTextTotalServicePriceP"].ToString(), TotalServicePriceP) != 0)
            {
                string act = "Total Service Price changed from:" + Session["oTextTotalServicePriceP"].ToString() + "To:" + TotalServicePriceP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Total Service Price Updated", Session["oTextTotalServicePriceP"].ToString(), TotalServicePriceP);
            }

            if (String.Compare(Session["oTextBalanceDueSAP"].ToString(), BalanceDueSAP) != 0)
            {
                string act = "Balance Due SA changed from:" + Session["oTextBalanceDueSAP"].ToString() + "To:" + BalanceDueSAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due SA Updated", Session["oTextBalanceDueSAP"].ToString(), BalanceDueSAP);
            }

            if (String.Compare(Session["oTextBalanceDDatesSAP"].ToString(), BalanceDueDatesSAP) != 0)
            {
                string act = "Balance Due Dates SA changed from:" + Session["oTextBalanceDDatesSAP"].ToString() + "To:" + BalanceDueDatesSAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Dates SA Updated", Session["oTextBalanceDDatesSAP"].ToString(), BalanceDueDatesSAP);
            }


            if (String.Compare(Session["oTextRemarkP"].ToString(), RemarksP) != 0)
            {
                string act = "Remarks changed from:" + Session["oTextRemarkP"].ToString() + "To:" + RemarksP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Remarks Updated", Session["oTextRemarkP"].ToString(), RemarksP);
            }






            if (String.Compare(Session["oTextInitDepo"].ToString(), InitDepop) != 0)
            {
                string act = "Initial Deposit changed from:" + Session["oTextInitDepo"].ToString() + "To:" + InitDepop;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Deposit Updated", Session["oTextInitDepo"].ToString(), InitDepop);
            }
            if (String.Compare(Session["oTextBalDepo"].ToString(), BalDepop) != 0)
            {
                string act = "Balance Deposit changed from:" + Session["oTextBalDepo"].ToString() + "To:" + BalDepop;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Deposit  Updated", Session["oTextBalDepo"].ToString(), BalDepop);
            }

            if (String.Compare(Session["oTextPrimaryCCard2"].ToString(), CPAP) != 0)
            {
                string act = "CPA comment changed from:" + Session["oTextPrimaryCCard2"].ToString() + "To:" + CPAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "CPA comment  Updated", Session["oTextPrimaryCCard2"].ToString(), CPAP);
            }

            if (String.Compare(Session["oPS_Deposit_Comment"].ToString(), CPADepo) != 0)
            {
                string act = "CPA Deposit changed from:" + Session["oPS_Deposit_Comment"].ToString() + "To:" + CPADepo;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "CPA Deposit  Updated", Session["oPS_Deposit_Comment"].ToString(), CPADepo);
            }

            if (String.Compare(Session["oTextPBalanceDDates2"].ToString(), BalanceDueDatesPAP2) != 0)
            {
                string act = "Balance Due dates 2 changed from:" + Session["oTextPBalanceDDates2"].ToString() + "To:" + BalanceDueDatesPAP2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due dates 2 Updated", Session["oTextPBalanceDDates2"].ToString(), BalanceDueDatesPAP2);
            }

            if (String.Compare(Session["oTextBalanceDDatesSAP2"].ToString(), BalanceDueDatesSAP2) != 0)
            {
                string act = "Balance Due dates SA 2 changed from:" + Session["oTextBalanceDDatesSAP2"].ToString() + "To:" + BalanceDueDatesSAP2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due dates SA 2 Updated", Session["oTextBalanceDDatesSAP2"].ToString(), BalanceDueDatesSAP2);
            }

            if (String.Compare(Session["oPS_Deposit_Date"].ToString(), DepoDatep) != 0)
            {
                string act = "Deposit Date changed from:" + Session["oPS_Deposit_Date"].ToString() + "To:" + DepoDatep;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Date Updated", Session["oPS_Deposit_Date"].ToString(), DepoDatep);
            }
            if (String.Compare(Session["oTextRemarkP2"].ToString(), RemarksP2) != 0)
            {
                string act = "Remarks 2 changed from:" + Session["oTextRemarkP2"].ToString() + "To:" + RemarksP2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Remarks 2 Updated", Session["oTextRemarkP2"].ToString(), RemarksP2);
            }


            if (String.Compare(Session["oTextIniInstP"].ToString(), IniBalNoInstallP) != 0)
            {
                string act = "Initial Bal No of Installment changed from:" + Session["oTextIniInstP"].ToString() + "To:" + IniBalNoInstallP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Bal No of Installment Updated", Session["oTextIniInstP"].ToString(), IniBalNoInstallP);
            }
            if (String.Compare(Session["oTextIniInstAmtP"].ToString(), IniBalInstAmtP) != 0)
            {
                string act = "Initial Bal No of Installment amount changed from:" + Session["oTextIniInstAmtP"].ToString() + "To:" + IniBalInstAmtP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Bal No of Installment amount Updated", Session["oTextIniInstAmtP"].ToString(), IniBalInstAmtP);
            }
            if (String.Compare(Session["oTextTotalBalance"].ToString(), TotalBalance) != 0)
            {
                string act = "Total balance changed from:" + Session["oTextTotalBalance"].ToString() + "To:" + TotalBalance;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Total balance Updated", Session["oTextTotalBalance"].ToString(), TotalBalance);
            }

            if (String.Compare(Session["exrate"].ToString(), INRexch) != 0)
            {
                string act = "Exchange Rate changed from:" + Session["exrate"].ToString() + "To:" + INRexch;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Exchange Rate Updated", Session["exrate"].ToString(), INRexch);
            }

            if (String.Compare(Session["oPS_Deposit_USD"].ToString(), DepositPUSD) != 0)
            {
                string act = "Deposit USD changed from:" + Session["oPS_Deposit_USD"].ToString() + "To:" + DepositPUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit USD Updated", Session["oPS_Deposit_USD"].ToString(), DepositPUSD);
            }

            if (String.Compare(Session["oPS_Country_Tax_USD"].ToString(), CoutryTaxPUSD) != 0)
            {
                string act = "Country Tax USD changed from:" + Session["oPS_Country_Tax_USD"].ToString() + "To:" + CoutryTaxPUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Country Tax USD Updated", Session["oPS_Country_Tax_USD"].ToString(), CoutryTaxPUSD);
            }
            if (String.Compare(Session["oContract_Finance_Purchase_Price_USD"].ToString(), PurchasePriceUSD) != 0)
            {
                string act = "Purchase_Price USD changed from:" + Session["oContract_Finance_Purchase_Price_USD"].ToString() + "To:" + PurchasePriceUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Purchase_Price USD Updated", Session["oContract_Finance_Purchase_Price_USD"].ToString(), PurchasePriceUSD);
            }
            if (String.Compare(Session["oContract_Finance_Admin_Fees_USD"].ToString(), AdminFeesUSD) != 0)
            {
                string act = "Admin_Fees USD changed from:" + Session["oContract_Finance_Admin_Fees_USD"].ToString() + "To:" + AdminFeesUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admin_Fees USD Updated", Session["oContract_Finance_Admin_Fees_USD"].ToString(), AdminFeesUSD);
            }

            //PurchasePriceUSD = "0";
            // AdminFeesUSD = "0";
        }
        else if(conttype == "Trade Into Points")
        {



            string OldAgreeNo = "";
            string OldClub = "", OldNoPoints = "", OldEntitle = "", ContResort = "", AppartmentType = "", NumbOccuTP = "", ContPeriod = "", ContSeason = "";


            string ContTPType = hiddentconttype.Text;

            if (ContTPType == "From Points To Points")
            {
                OldAgreeNo = TextOldAgreeNoTP1.Text;
                //OldAgreeNo = OldAgreeNo1;
                if (ContractClubTPDropDownList1.SelectedItem.Text == "")
                { OldClub = ""; }
                else
                { OldClub = ContractClubTPDropDownList1.SelectedItem.Text; }


                OldNoPoints = TextOldNoPointsTP.Text;

                if (EntitlementDropDownList1.SelectedItem.Text == "")
                { OldEntitle = ""; }
                else
                { OldEntitle = EntitlementDropDownList1.SelectedItem.Text; }


                ContResort = "";
                AppartmentType = "";
                NumbOccuTP = "";
                ContPeriod = "";
                ContSeason = "";



                

            if (String.Compare(Session["oTextOldAgreeNoTP1"].ToString(), OldAgreeNo) != 0)
            {
                string act = "Old Agreement No changed from:" + Session["oTextOldAgreeNoTP1"].ToString() + "To:" + OldAgreeNo;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Agreement No Updated", Session["oTextOldAgreeNoTP1"].ToString(), OldAgreeNo);
            }

            if (String.Compare(Session["oEntitlementDropDownList1"].ToString(), OldEntitle) != 0)
            {
                string act = "Old Entitlement changed from:" + Session["oEntitlementDropDownList1"].ToString() + "To:" + OldEntitle;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Entitlement Updated", Session["oEntitlementDropDownList1"].ToString(), OldEntitle);
            }

            if (String.Compare(Session["oTextOldNoPointsTP"].ToString(), OldNoPoints) != 0)
            {
                string act = "Old no of points changed from:" + Session["oTextOldNoPointsTP"].ToString() + "To:" + OldNoPoints;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old no of points Updated", Session["oTextOldNoPointsTP"].ToString(), OldNoPoints);
            }

            if (String.Compare(Session["oContractClubTPDropDownList1"].ToString(), OldClub) != 0)
            {
                string act = "Old Club changed from:" + Session["oContractClubTPDropDownList1"].ToString() + "To:" + OldClub;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Club Updated", Session["oContractClubTPDropDownList1"].ToString(), OldClub);
            }




            }
            else if (ContTPType == "From Weeks To Points")
            {
                OldAgreeNo = TextOldAgreeNoTP2.Text;
                ContResort = ResortTPDropDownList.SelectedItem.Text;
                if (AppartmentTypeTPDropDownList.SelectedItem.Text == "")
                {
                    AppartmentType = "";
                }
                else
                {
                    AppartmentType = AppartmentTypeTPDropDownList.SelectedItem.Text;
                }

                if (NumbOccuTPDropDownList.SelectedItem.Text == "")
                {
                    NumbOccuTP = "";
                }
                else
                {
                    NumbOccuTP = NumbOccuTPDropDownList.SelectedItem.Text;
                }

                if (PeriodTPDropDownList.SelectedItem.Text == "")
                {
                    ContPeriod = "";
                }
                else
                {
                    ContPeriod = PeriodTPDropDownList.SelectedItem.Text;
                }

                if (SeasonTPDropDownList.SelectedItem.Text == "")
                {
                    ContSeason = "";
                }
                else
                {
                    ContSeason = SeasonTPDropDownList.SelectedItem.Text;
                }

                if (EntitleTPDropDownList.SelectedItem.Text == "")
                {
                    OldEntitle = "";
                }
                else
                {
                    OldEntitle = EntitleTPDropDownList.SelectedItem.Text;
                }

                OldNoPoints = TextTPPoints.Text;
                OldClub = "";



                if (String.Compare(Session["oTextOldAgreeNoTP2"].ToString(), OldAgreeNo) != 0)
                {
                    string act = "Old Agreement No changed from:" + Session["oTextOldAgreeNoTP2"].ToString() + "To:" + OldAgreeNo;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Agreement No Updated", Session["oTextOldAgreeNoTP2"].ToString(), OldAgreeNo);
                }

                if (String.Compare(Session["oResortTPDropDownList"].ToString(), ContResort) != 0)
                {
                    string act = "Resort changed from:" + Session["oResortTPDropDownList"].ToString() + "To:" + ContResort;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Resort Updated", Session["oResortTPDropDownList"].ToString(), ContResort);
                }

                if (String.Compare(Session["oAppartmentTypeTPDropDownList"].ToString(), AppartmentType) != 0)
                {
                    string act = "Appartment Type changed from:" + Session["oAppartmentTypeTPDropDownList"].ToString() + "To:" + AppartmentType;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Appartment Type Updated", Session["oAppartmentTypeTPDropDownList"].ToString(), AppartmentType);
                }

                if (String.Compare(Session["oNumbOccuTPDropDownList"].ToString(), NumbOccuTP) != 0)
                {
                    string act = "Old Club changed from:" + Session["oNumbOccuTPDropDownList"].ToString() + "To:" + NumbOccuTP;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Club Updated", Session["oNumbOccuTPDropDownList"].ToString(), NumbOccuTP);
                }

                if (String.Compare(Session["oPeriodTPDropDownList"].ToString(), ContPeriod) != 0)
                {
                    string act = "Period changed from:" + Session["oPeriodTPDropDownList"].ToString() + "To:" + ContPeriod;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Period Updated", Session["oPeriodTPDropDownList"].ToString(), ContPeriod);
                }

                if (String.Compare(Session["oSeasonTPDropDownList"].ToString(), ContSeason) != 0)
                {
                    string act = "Season changed from:" + Session["oSeasonTPDropDownList"].ToString() + "To:" + ContSeason;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Season Updated", Session["oSeasonTPDropDownList"].ToString(), ContSeason);
                }

                if (String.Compare(Session["oEntitleTPDropDownList"].ToString(), OldEntitle) != 0)
                {
                    string act = "Old Entitlement changed from:" + Session["oEntitleTPDropDownList"].ToString() + "To:" + OldEntitle;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Entitlement Updated", Session["oEntitleTPDropDownList"].ToString(), OldEntitle);
                }

                if (String.Compare(Session["oTP_Old_No_Points"].ToString(), OldNoPoints) != 0)
                {
                    string act = "Old No Of changed from:" + Session["oTP_Old_No_Points"].ToString() + "To:" + OldNoPoints;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "ContSeason Updated", Session["oTP_Old_No_Points"].ToString(), OldNoPoints);
                }

            }







            


            string NewPoints = TextNewPointsTP.Text;
            string TotalPoints = TextTotalPointsTP.Text;
           // string ContNewClub = ContractClubTPDropDownList2.Text;
            //Session["ECGGlobContClub"] = ContNewClub;
            string ContNewEntitle = EntitlementTPoinDropDownList.SelectedItem.Text;
            string Memberfees = TextMembershipFeesTP.Text;
            string PropertyFees = TextPropertyFeesTP.Text;
            string FYOcc = TextFYOccTP.Text;
            string DurationTP = TextDurationTP.Text;
            string LYOcc = TextLYOccTP.Text;


           







            string DepositP = TextDepositP.Text.Replace(",", "");
            string DepoPPA = TextDepoPPA.Text.Replace(",", "");
            string AdmissFeesP = TextAdmissFeesP.Text.Replace(",", "");
            string AdminFeesP = TextAdminFeesP.Text.Replace(",", "");
            string PurchasePriceP = TextPpurchasePrice.Text.Replace(",", "");
            string CoutryTaxP = TextCountryTaxP.Text.Replace(",", "");
            string GrandTotalP = TextGrandTotalP.Text.Replace(",", "");
            string BalanceDuePAP = TextPBalaceDPA.Text.Replace(",", "");
            string BalanceDuePATPTD = TextPBalaceDPATOPD.Text.Replace(",", "");
            string PANoOfInstallP = TextPPANoInstall.Text;
            string tPAFirstPayDateP = datepicker8.Text;

            string PAFirstPayDateP = tPAFirstPayDateP;// Convert.ToDateTime(tPAFirstPayDateP).ToString("yyyy-MM-dd");


            string PAAmountInstallP = TextPPAAmountInstall.Text.Replace(",", "");
            string PAFirstInstallP = TextPPAFInstall.Text.Replace(",", "");
            string BalanceDueDatesPAP = TextPBalanceDDates.Text;
            string DepositSAP = TextPDepositSA.Text.Replace(",", "");
            string ApplicationFeesP = TextAppliFeesP.Text.Replace(",", "");
            string AdminServiceP = TextAdminServiceP.Text.Replace(",", "");
            string TotalServicePriceP = TextTotalServicePriceP.Text.Replace(",", "");
            string BalanceDueSAP = TextBalanceDueSAP.Text.Replace(",", "");

            string BalanceDueDatesSAP = TextBalanceDDatesSAP.Text;
            string RemarksP = TextRemarkP.Text;

            string UsePayProtectP = ""; ;

            string TotalBalance = TextTotalBalance.Text.Replace(",", "");


          
            string InitDepotp = TextInitDepo.Text.Replace(",", "");

            string BalDepotp = TextBalDepo.Text.Replace(",", "");

            string CPATP = TextPrimaryCCard2.Text;

            string CPADepoTP = TextCPADepoComment.Text;

            string DepoDatetp = TextBoxNBDP.Text;

            string remarkTP2 = TextRemarkP2.Text;
            string BalanceDueDatesPATP2 = TextPBalanceDDates2.Text;
            string BalanceDueDatesSATP2 = TextBalanceDDatesSAP2.Text;


            string IniBalNoInstallTP = TextIniInstP.Text;
            string IniBalInstAmtTP = TextIniInstAmtP.Text.Replace(",", "");
            string TDcommmentTP = TextBoxTempTDComment.Text;



          



            string INRexch="0", PurchasePriceUSD, AdminFeesUSD;

            string DepositPUSD, CoutryTaxPUSD, excR, CoutryTaxPCGST, CoutryTaxPSGST;



            if (FinaCurrency != "USD")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                DepositPUSD = Math.Round(float.Parse(DepositP) / float.Parse(INRexch), 0).ToString();
                CoutryTaxPUSD = Math.Round(float.Parse(CoutryTaxP) / float.Parse(INRexch), 0).ToString();
                excR = INRexch.ToString();

                if (FinaCurrency == "INR")
                {

                    CoutryTaxPCGST = TextBoxCGST.Text.Replace(",", "");
                    CoutryTaxPSGST = TextBoxSGST.Text.Replace(",", "");


                    string kk = Session["ODeposit"].ToString();
                    if (kk != DepositP)
                    {
                        string depositnotax = Math.Round((float.Parse(DepositP) / 118) * 100, 0).ToString();
                        string depositSCGST = Math.Round(((float.Parse(DepositP) / 118) * 18) / 2, 0).ToString();
                        string depositGST = Math.Round((float.Parse(DepositP) / 118) * 18, 0).ToString();

                        int updatedepo = Queries2.Update_DepositRecieptDetails(DepositP, depositnotax, depositSCGST, depositGST, Deposit_PM, Session["fracido"].ToString());
                    }
                }
                else
                {
                    CoutryTaxPCGST = "0";
                    CoutryTaxPSGST = "0";
                   // excR = "0";
                }

            }



            /* if (FinaCurrency == "INR")
             {
                 INRexch = Session["exrate"].ToString();//Erates("INR");
                 DepositPUSD = Math.Round(float.Parse(DepositP) / float.Parse(INRexch), 0).ToString();
                 CoutryTaxPUSD = Math.Round(float.Parse(CoutryTaxP) / float.Parse(INRexch), 0).ToString();
                 CoutryTaxPCGST = TextBoxCGST.Text;
                 CoutryTaxPSGST = TextBoxSGST.Text;
                 excR = INRexch.ToString();


  string kk = Session["ODeposit"].ToString();
                 if (kk != DepositP)
                 {
                     string depositnotax = Math.Round((float.Parse(DepositP) / 118) * 100, 0).ToString();
                     string depositSCGST = Math.Round(((float.Parse(DepositP) / 118) * 18) / 2, 0).ToString();
                     string depositGST = Math.Round((float.Parse(DepositP) / 118) * 18, 0).ToString();

                     int updatedepo = Queries2.Update_DepositRecieptDetails(DepositP, depositnotax, depositSCGST, depositGST, Deposit_PM, Session["fracido"].ToString());
                 }

             }*/
            else
            {
                DepositPUSD = DepositP;// "0";
                CoutryTaxPUSD = CoutryTaxP;// "0";
                CoutryTaxPCGST = "0";
                CoutryTaxPSGST = "0";
                excR = "0";
            }


            // Session["Globcurr"] = FinaCurrency;
           // string PurchasePrice = TextPurchasePrice.Text;
           // string AdminFees = TextAdminFees.Text;
            if (FinaCurrency != "USD")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                PurchasePriceUSD = Math.Round(float.Parse(PurchasePrice) / float.Parse(INRexch), 0).ToString();
                AdminFeesUSD = Math.Round(float.Parse(AdminFees) / float.Parse(INRexch), 0).ToString();
            }
            else
            {
               PurchasePriceUSD = PurchasePrice;// "0";
                AdminFeesUSD = AdminFees;// "0";
            }








            string t1 = EntitlementTPoinDropDownList.SelectedItem.Text;
            int fyear = Convert.ToInt32(TextFYOccTP.Text);
            string ft1, ft2,BalloonPay, LastInstDate =  Session["lastinstalldate"].ToString(); 

            if (fyear % 2 == 0)
            {
                ft1 = "Even";
            }
            else
            {
                ft1 = "Odd";
            }

            if (FCheckBox1.Checked)
            {
                ft2 = "Yes";
            }
            else
            {
                ft2 = "No";
            }

            if (CheckBoxBalloonP.Checked)
            {
                BalloonPay = "BP";
            }
            else
            {
                BalloonPay = "";
            }



           

            int icnt = Queries2.checkforexistinginvoice(Session["fracido"].ToString());
            if (icnt == 0)
            {
                string desc, amot1, amot2, date,date1, curr, text11, text12, text13, text14, text15,desc1="";
                string PA = "PA";
                string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallP); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12].Replace(",", "");
                    text15 = "textBoxN_" + i + "3";
                    amot2 = Request[text15].Replace(",", "");
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                        //date = Convert.ToDateTime(date1).ToString("yyyy-MM-dd");

                        if (PANoOfInstallP != "1")
                        {
                            if (i == int.Parse(PANoOfInstallP))
                            {
                                text13 = "textBox_" + i + "3";
                                LastInstDate = Request[text13];
                            }
                        }


                    if (int.Parse(amot1) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(Session["Gofficeo"].ToString());
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, Session["ProfileIDo"].ToString(), PA, Session["Gofficeo"].ToString(), Session["fracido"].ToString(), DateTime.Now);
                        desc1 += "Installment Id: " + finaInstI + ",desc: " + desc + ",Date: " + date + ",amount: " + amot1 + ",Currency: " + curr + ",";
                    }

                    if (amot2 == "")
                    {
                        amot2 = "0";
                    }

                    if (int.Parse(amot2) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(Session["Gofficeo"].ToString());
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, Session["ProfileIDo"].ToString(), SA, Session["Gofficeo"].ToString(), Session["fracido"].ToString(), DateTime.Now);
                        desc1 += "Installment Id: " + finaInstI + ",desc: " + desc + ",Date: " + date + ",amount: " + amot1 + ",Currency: " + curr + ",";
                    }

                }

                int insertlognewInstall = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, GenContNumb, desc1, user, DateTime.Now.ToString(), "Edit_contract.aspx", "Installments Details Added", "", desc1);
            }

            //Session["EGGlobContClub"] = OldClub;

                int contract_TP = Queries2.Update_Contract_TP(ContResort, AppartmentType, NumbOccuTP, ContPeriod, ContSeason, OldEntitle, OldNoPoints, NewPoints, TotalPoints, ContNewEntitle, Memberfees, PropertyFees, FYOcc, DurationTP, LYOcc, Session["fracido"].ToString(), OldAgreeNo, OldClub);

            int contup = Queries2.UpdatePointPS(Deposit_PM, DepositP, DepoPPA, DepositSAP, AdmissFeesP, ApplicationFeesP, AdminFeesP, AdminServiceP, PurchasePriceP, TotalServicePriceP, CoutryTaxP, GrandTotalP, BalanceDuePAP, BalanceDueSAP, PANoOfInstallP, PAFirstPayDateP, PAAmountInstallP, PAFirstInstallP, BalanceDueDatesPAP, BalanceDueDatesSAP, RemarksP, TotalBalance, EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF, YearOfInterestP, DateTime.Now.ToString(), Session["fracido"].ToString(), InitDepotp, BalDepotp, DepoDatetp, BalanceDueDatesPATP2, BalanceDueDatesSATP2, remarkTP2, CPATP,IniBalNoInstallTP,IniBalInstAmtTP,BalloonPay,LastInstDate,CPADepoTP, BalanceDuePATPTD, DepositPUSD, CoutryTaxPUSD, CoutryTaxPCGST, CoutryTaxPSGST, excR, TDcommmentTP);
            int contFina = Queries2.UpdateContFrac(affilice, affilhp, salesrep, tomanager, buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, ID_Card, CrownCurr, Session["fracido"].ToString(), Session["DealRegDate"].ToString(), ft1, ft2, DateTime.Now, Convert.ToInt32(Session["cweekno"]), ContComment, PaymentMethodDeatils, Boverride, PurchasePriceUSD, AdminFeesUSD,Contractvenue);

            int contFinadetails = Queries2.UpdateFinanceDetails(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, Session["fracido"].ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect,FinaDate);

            if (String.Compare(Session["oTextNewPointsTP"].ToString(), NewPoints) != 0)
            {
                string act = "New Points changed from:" + Session["oTextNewPointsTP"].ToString() + "To:" + NewPoints;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "New Points Updated", Session["oTextNewPointsTP"].ToString(), NewPoints);
            }

            if (String.Compare(Session["oTextTotalPointsTP"].ToString(), TotalPoints) != 0)
            {
                string act = "Total Points changed from:" + Session["oTextTotalPointsTP"].ToString() + "To:" + TotalPoints;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Total Points Updated", Session["oTextTotalPointsTP"].ToString(), TotalPoints);
            }

            if (String.Compare(Session["oEntitlementTPoinDropDownList"].ToString(), ContNewEntitle) != 0)
            {
                string act = "Entitlement changed from:" + Session["oEntitlementTPoinDropDownList"].ToString() + "To:" + ContNewEntitle;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Entitlement Updated", Session["oEntitlementTPoinDropDownList"].ToString(), ContNewEntitle);
            }

            if (String.Compare(Session["oTextMemFeesp"].ToString(), Memberfees) != 0)
            {
                string act = "Member Fees changed from:" + Session["oTextMemFeesp"].ToString() + "To:" + Memberfees;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Member Fees Updated", Session["oTextMemFeesp"].ToString(), Memberfees);
            }

            if (String.Compare(Session["oTextPropFeesp"].ToString(), PropertyFees) != 0)
            {
                string act = "Property Fees changed from:" + Session["oTextPropFeesp"].ToString() + "To:" + PropertyFees;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Property Fees Updated", Session["oTextPropFeesp"].ToString(), PropertyFees);
            }

            //Session["oTextPropFeesp"] =



            if (String.Compare(Session["oTextFYOccTP"].ToString(), FYOcc) != 0)
            {
                string act = "First year Occupancy changed from:" + Session["oTextFYOccTP"].ToString() + "To:" + FYOcc;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First year Occupancy Updated", Session["oTextFYOccTP"].ToString(), FYOcc);
            }
            if (String.Compare(Session["oTextDurationTP"].ToString(), DurationTP) != 0)
            {
                string act = "Duration changed from:" + Session["oTextDurationTP"].ToString() + "To:" + DurationTP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Duration Updated", Session["oTextDurationTP"].ToString(), DurationTP);
            }
            if (String.Compare(Session["oTextLYOccTP"].ToString(), LYOcc) != 0)
            {
                string act = "Last year Occupancy changed from:" + Session["oTextLYOccTP"].ToString() + "To:" + LYOcc;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Last year Occupancy Updated", Session["oTextLYOccTP"].ToString(), LYOcc);
            }


            if (String.Compare(Session["ODeposit"].ToString(), DepositP) != 0)
            {
                string act = "Deposit changed from:" + Session["ODeposit"].ToString() + "To:" + DepositP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Updated", Session["ODeposit"].ToString(), DepositP);
            }

            if (String.Compare(Session["oTextDepoPPA"].ToString(), DepoPPA) != 0)
            {
                string act = "Deposit PA changed from:" + Session["oTextDepoPPA"].ToString() + "To:" + DepoPPA;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit PA Updated", Session["oTextDepoPPA"].ToString(), DepoPPA);
            }

            if (String.Compare(Session["oTextAdmissFeesP"].ToString(), AdmissFeesP) != 0)
            {
                string act = "Admission Fees changed from:" + Session["oTextAdmissFeesP"].ToString() + "To:" + AdmissFeesP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admission Fees Updated", Session["oTextAdmissFeesP"].ToString(), AdmissFeesP);
            }

            if (String.Compare(Session["oTextAdminFeesP"].ToString(), AdminFeesP) != 0)
            {
                string act = "Administration Fees changed from:" + Session["oTextAdminFeesP"].ToString() + "To:" + AdminFeesP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Administration Fees Updated", Session["oTextAdminFeesP"].ToString(), AdminFeesP);
            }



            if (String.Compare(Session["oTextPpurchasePrice"].ToString(), PurchasePriceP) != 0)
            {
                string act = "Purchase Price changed from:" + Session["oTextPpurchasePrice"].ToString() + "To:" + PurchasePriceP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Purchase Price Updated", Session["oTextPpurchasePrice"].ToString(), PurchasePriceP);
            }

            if (String.Compare(Session["oTextCountryTaxP"].ToString(), CoutryTaxP) != 0)
            {
                string act = "Country Tax changed from:" + Session["oTextCountryTaxP"].ToString() + "To:" + CoutryTaxP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admission Fees Updated", Session["oTextCountryTaxP"].ToString(), CoutryTaxP);
            }

            if (String.Compare(Session["oTextGrandTotalP"].ToString(), GrandTotalP) != 0)
            {
                string act = "Grand Total changed from:" + Session["oTextGrandTotalP"].ToString() + "To:" + GrandTotalP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Grand Total Updated", Session["oTextGrandTotalP"].ToString(), GrandTotalP);
            }

            if (String.Compare(Session["oTextPBalaceDPA"].ToString(), BalanceDuePAP) != 0)
            {
                string act = "Balance Due changed from:" + Session["oTextPBalaceDPA"].ToString() + "To:" + BalanceDuePAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Updated", Session["oTextPBalaceDPA"].ToString(), BalanceDuePAP);
            }

            if (String.Compare(Session["oTextPBalaceDPATOPD"].ToString(), BalanceDuePATPTD) != 0)
            {
                string act = "Balance Due TOP Drawer changed from:" + Session["oTextPBalaceDPATOPD"].ToString() + "To:" + BalanceDuePATPTD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due TOP Drawer Updated", Session["oTextPBalaceDPATOPD"].ToString(), BalanceDuePATPTD);
            }

            if (String.Compare(Session["oPS_PA_FInstall_Date"].ToString(), tPAFirstPayDateP) != 0)
            {
                string act = "First installment Date changed from:" + Session["oPS_PA_FInstall_Date"].ToString() + "To:" + tPAFirstPayDateP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First installment Date Updated", Session["oPS_PA_FInstall_Date"].ToString(), tPAFirstPayDateP);
            }

            if (String.Compare(Session["oTextPPAAmountInstall"].ToString(), PAAmountInstallP) != 0)
            {
                string act = "Other Installment changed from:" + Session["oTextPPAAmountInstall"].ToString() + "To:" + PAAmountInstallP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Other Installment Updated", Session["oTextPPAAmountInstall"].ToString(), PAAmountInstallP);
            }


            if (String.Compare(Session["oTextPPAFInstall"].ToString(), PAFirstInstallP) != 0)
            {
                string act = "First installment Date changed from:" + Session["oTextPPAFInstall"].ToString() + "To:" + PAFirstInstallP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First installment Date Updated", Session["oTextPPAFInstall"].ToString(), PAFirstInstallP);
            }

            if (String.Compare(Session["oTextPBalanceDDates"].ToString(), BalanceDueDatesPAP) != 0)
            {
                string act = "Balance Due Dates changed from:" + Session["oTextPBalanceDDates"].ToString() + "To:" + BalanceDueDatesPAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Dates Updated", Session["oTextPBalanceDDates"].ToString(), BalanceDueDatesPAP);
            }

            if (String.Compare(Session["oPS_TP_Comment"].ToString(), TDcommmentTP) != 0)
            {
                string act = "Top Drawer comment changed from:" + Session["oPS_TP_Comment"].ToString() + "To:" + TDcommmentTP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Top Drawer comment Updated", Session["oPS_TP_Comment"].ToString(), TDcommmentTP);
            }

            if (String.Compare(Session["oTextPPANoInstall"].ToString(), PANoOfInstallP) != 0)
            {
                string act = "PA No of Installment changed from:" + Session["oTextPPANoInstall"].ToString() + "To:" + PANoOfInstallP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "PA No of Installment Updated", Session["oTextPPANoInstall"].ToString(), PANoOfInstallP);
            }


            if (String.Compare(Session["oTextPDepositSA"].ToString(), DepositSAP) != 0)
            {
                string act = "Deposit SA changed from:" + Session["oTextPDepositSA"].ToString() + "To:" + DepositSAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit SA Updated", Session["oTextPDepositSA"].ToString(), DepositSAP);
            }


            if (String.Compare(Session["oTextAppliFeesP"].ToString(), ApplicationFeesP) != 0)
            {
                string act = "Application Fees changed from:" + Session["oTextAppliFeesP"].ToString() + "To:" + ApplicationFeesP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Application Fees Updated", Session["oTextAppliFeesP"].ToString(), ApplicationFeesP);
            }

            if (String.Compare(Session["oTextAdminServiceP"].ToString(), AdminServiceP) != 0)
            {
                string act = "Admin Service changed from:" + Session["oTextAdminServiceP"].ToString() + "To:" + AdminServiceP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admin Service Updated", Session["oTextAdminServiceP"].ToString(), AdminServiceP);
            }

            if (String.Compare(Session["oTextTotalServicePriceP"].ToString(), TotalServicePriceP) != 0)
            {
                string act = "Total Service Price changed from:" + Session["oTextTotalServicePriceP"].ToString() + "To:" + TotalServicePriceP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Total Service Price Updated", Session["oTextTotalServicePriceP"].ToString(), TotalServicePriceP);
            }

            if (String.Compare(Session["oTextBalanceDueSAP"].ToString(), BalanceDueSAP) != 0)
            {
                string act = "Balance Due SA changed from:" + Session["oTextBalanceDueSAP"].ToString() + "To:" + BalanceDueSAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due SA Updated", Session["oTextBalanceDueSAP"].ToString(), BalanceDueSAP);
            }

            if (String.Compare(Session["oTextBalanceDDatesSAP"].ToString(), BalanceDueDatesSAP) != 0)
            {
                string act = "Balance Due Dates SA changed from:" + Session["oTextBalanceDDatesSAP"].ToString() + "To:" + BalanceDueDatesSAP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Dates SA Updated", Session["oTextBalanceDDatesSAP"].ToString(), BalanceDueDatesSAP);
            }


            if (String.Compare(Session["oTextRemarkP"].ToString(), RemarksP) != 0)
            {
                string act = "Remarks changed from:" + Session["oTextRemarkP"].ToString() + "To:" + RemarksP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Remarks Updated", Session["oTextRemarkP"].ToString(), RemarksP);
            }







            if (String.Compare(Session["oTextInitDepo"].ToString(), IniBalNoInstallTP) != 0)
            {
                string act = "Initial Deposit changed from:" + Session["oTextInitDepo"].ToString() + "To:" + IniBalNoInstallTP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Deposit Updated", Session["oTextInitDepo"].ToString(), IniBalNoInstallTP);
            }
            if (String.Compare(Session["oTextBalDepo"].ToString(), BalDepotp) != 0)
            {
                string act = "Balance Deposit changed from:" + Session["oTextBalDepo"].ToString() + "To:" + BalDepotp;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Deposit  Updated", Session["oTextBalDepo"].ToString(), BalDepotp);
            }

            if (String.Compare(Session["oTextPrimaryCCard2"].ToString(), CPATP) != 0)
            {
                string act = "CPA comment changed from:" + Session["oTextPrimaryCCard2"].ToString() + "To:" + CPATP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "CPA comment  Updated", Session["oTextPrimaryCCard2"].ToString(), CPATP);
            }

            if (String.Compare(Session["oPS_Deposit_Comment"].ToString(), CPADepoTP) != 0)
            {
                string act = "CPA Deposit changed from:" + Session["oPS_Deposit_Comment"].ToString() + "To:" + CPADepoTP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "CPA Deposit  Updated", Session["oPS_Deposit_Comment"].ToString(), CPADepoTP);
            }

            if (String.Compare(Session["oTextPBalanceDDates2"].ToString(), BalanceDueDatesPATP2) != 0)
            {
                string act = "Balance Due dates 2 changed from:" + Session["oTextPBalanceDDates2"].ToString() + "To:" + BalanceDueDatesPATP2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due dates 2 Updated", Session["oTextPBalanceDDates2"].ToString(), BalanceDueDatesPATP2);
            }

            if (String.Compare(Session["oTextBalanceDDatesSAP2"].ToString(), BalanceDueDatesSATP2) != 0)
            {
                string act = "Balance Due dates SA 2 changed from:" + Session["oTextBalanceDDatesSAP2"].ToString() + "To:" + BalanceDueDatesSATP2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due dates SA 2 Updated", Session["oTextBalanceDDatesSAP2"].ToString(), BalanceDueDatesSATP2);
            }

            if (String.Compare(Session["oPS_Deposit_Date"].ToString(), DepoDatetp) != 0)
            {
                string act = "Deposit Date changed from:" + Session["oPS_Deposit_Date"].ToString() + "To:" + DepoDatetp;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Date Updated", Session["oPS_Deposit_Date"].ToString(), DepoDatetp);
            }
            if (String.Compare(Session["oTextRemarkP2"].ToString(), remarkTP2) != 0)
            {
                string act = "Remarks 2 changed from:" + Session["oTextRemarkP2"].ToString() + "To:" + remarkTP2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Remarks 2 Updated", Session["oTextRemarkP2"].ToString(), remarkTP2);
            }


            if (String.Compare(Session["oTextIniInstP"].ToString(), IniBalNoInstallTP) != 0)
            {
                string act = "Initial Bal No of Installment changed from:" + Session["oTextIniInstP"].ToString() + "To:" + IniBalNoInstallTP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Bal No of Installment Updated", Session["oTextIniInstP"].ToString(), IniBalNoInstallTP);
            }
            if (String.Compare(Session["oTextIniInstAmtP"].ToString(), IniBalInstAmtTP) != 0)
            {
                string act = "Initial Bal No of Installment amount changed from:" + Session["oTextIniInstAmtP"].ToString() + "To:" + IniBalInstAmtTP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Bal No of Installment amount Updated", Session["oTextIniInstAmtP"].ToString(), IniBalInstAmtTP);
            }
            if (String.Compare(Session["oTextTotalBalance"].ToString(), TotalBalance) != 0)
            {
                string act = "Total balance changed from:" + Session["oTextTotalBalance"].ToString() + "To:" + TotalBalance;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Total balance Updated", Session["oTextTotalBalance"].ToString(), TotalBalance);
            }


            if (String.Compare(Session["exrate"].ToString(), INRexch) != 0)
            {
                string act = "Exchange Rate changed from:" + Session["exrate"].ToString() + "To:" + INRexch;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Exchange Rate Updated", Session["exrate"].ToString(), INRexch);
            }

            if (String.Compare(Session["oPS_Deposit_USD"].ToString(), DepositPUSD) != 0)
            {
                string act = "Deposit USD changed from:" + Session["oPS_Deposit_USD"].ToString() + "To:" + DepositPUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit USD Updated", Session["oPS_Deposit_USD"].ToString(), DepositPUSD);
            }

            if (String.Compare(Session["oPS_Country_Tax_USD"].ToString(), CoutryTaxPUSD) != 0)
            {
                string act = "Country Tax USD changed from:" + Session["oPS_Country_Tax_USD"].ToString() + "To:" + CoutryTaxPUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Country Tax USD Updated", Session["oPS_Country_Tax_USD"].ToString(), CoutryTaxPUSD);
            }
            if (String.Compare(Session["oContract_Finance_Purchase_Price_USD"].ToString(), PurchasePriceUSD) != 0)
            {
                string act = "Purchase_Price USD changed from:" + Session["oContract_Finance_Purchase_Price_USD"].ToString() + "To:" + PurchasePriceUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Purchase_Price USD Updated", Session["oContract_Finance_Purchase_Price_USD"].ToString(), PurchasePriceUSD);
            }
            if (String.Compare(Session["oContract_Finance_Admin_Fees_USD"].ToString(), AdminFeesUSD) != 0)
            {
                string act = "Admin_Fees USD changed from:" + Session["oContract_Finance_Admin_Fees_USD"].ToString() + "To:" + AdminFeesUSD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admin_Fees USD Updated", Session["oContract_Finance_Admin_Fees_USD"].ToString(), AdminFeesUSD);
            }


        }

        else if (conttype == "Trade Into Fractional")
        {
            string OldAgreeNoTF = "", OldClubTF = "", OldNoOfPointsTF = "", OldEntitleTF = "", OldResortTF = "", OldAppartTypeTF = "", OldNoOccuTF = "", OldPeriodTF = "", OldSeasonTF = "", OldResidenceNoTF = "", OldResiTypeTF = "", OldFracIntTF = "";


            string Resort1 = Request.Form[ResortDropDownListTF.UniqueID];
            if (Resort1 == "Fractional Member")
            {
                resort = "FM";
            }


            string conttypeTF = Request.Form[ContTypeDropDownListTF.UniqueID];

            if (conttypeTF == "From Points To Fractional")
            {
                OldAgreeNoTF = TextOldAgreeNoTF1.Text;
                OldClubTF = OldClubDropDownListTF.SelectedItem.Text;
                OldNoOfPointsTF = TextOldNoOfPointsTF.Text;
                OldEntitleTF = EntitleDropDownListTF1.SelectedItem.Text;
                OldResortTF = "";
                OldAppartTypeTF = "";
                OldNoOccuTF = "";
                OldPeriodTF = "";
                OldSeasonTF = "";
                OldResidenceNoTF = "";
                OldResiTypeTF = "";
                OldFracIntTF = "";

                if (String.Compare(Session["oTextOldAgreeNoTF1"].ToString(), OldAgreeNoTF) != 0)
                {
                    string act = "Old Agreement No changed from:" + Session["oTextOldAgreeNoTF1"].ToString() + "To:" + OldAgreeNoTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Agreement No Updated", Session["oTextOldAgreeNoTF1"].ToString(), OldAgreeNoTF);
                }

                if (String.Compare(Session["oEntitleDropDownListTF1"].ToString(), OldEntitleTF) != 0)
                {
                    string act = "Old Entitlement changed from:" + Session["oEntitleDropDownListTF1"].ToString() + "To:" + OldEntitleTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Entitlement Updated", Session["oEntitleDropDownListTF1"].ToString(), OldEntitleTF);
                }
                if (String.Compare(Session["oOldClubDropDownListTF"].ToString(), OldClubTF) != 0)
                {
                    string act = "Old club changed from:" + Session["oOldClubDropDownListTF"].ToString() + "To:" + OldClubTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old club Updated", Session["oOldClubDropDownListTF"].ToString(), OldClubTF);
                }

                if (String.Compare(Session["oTextOldNoOfPointsTF"].ToString(), OldNoOfPointsTF) != 0)
                {
                    string act = "Old No of Points changed from:" + Session["oTextOldNoOfPointsTF"].ToString() + "To:" + OldNoOfPointsTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old No of Points Updated", Session["oTextOldNoOfPointsTF"].ToString(), OldNoOfPointsTF);
                }

            }
            else if (conttypeTF == "From Weeks To Fractional")
            {
                OldAgreeNoTF = TextOldAgreeNoTF2.Text;
                OldClubTF = "";
                OldNoOfPointsTF = "";
                OldEntitleTF = EntitleDropDownListTF2.SelectedItem.Text;
                OldResortTF = ResortDropDownListTF1.SelectedItem.Text;
                OldAppartTypeTF = AppartTypeDropDownListTF.SelectedItem.Text;
                OldNoOccuTF = NoOccuDropDownListTF.SelectedItem.Text;
                OldPeriodTF = PeriodDropDownListTF.SelectedItem.Text;
                OldSeasonTF = SeasonDropDownListTF.SelectedItem.Text;
                OldResidenceNoTF = "";
                OldResiTypeTF = "";
                OldFracIntTF = "";

                if (String.Compare(Session["oTextOldAgreeNoTF2"].ToString(), OldAgreeNoTF) != 0)
                {
                    string act = "Old Agreement No changed from:" + Session["oTextOldAgreeNoTF2"].ToString() + "To:" + OldAgreeNoTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Agreement No Updated", Session["oTextOldAgreeNoTF2"].ToString(), OldAgreeNoTF);
                }

                if (String.Compare(Session["oEntitleDropDownListTF2"].ToString(), OldEntitleTF) != 0)
                {
                    string act = "Old Entitlement changed from:" + Session["oEntitleDropDownListTF2"].ToString() + "To:" + OldEntitleTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Entitlement Updated", Session["oEntitleDropDownListTF2"].ToString(), OldEntitleTF);
                }
                if (String.Compare(Session["oResortDropDownListTF1"].ToString(), OldResortTF) != 0)
                {
                    string act = "Resort changed from:" + Session["oResortDropDownListTF1"].ToString() + "To:" + OldResortTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Resort Updated", Session["oResortDropDownListTF1"].ToString(), OldResortTF);
                }
                if (String.Compare(Session["oAppartTypeDropDownListTF"].ToString(), OldAppartTypeTF) != 0)
                {
                    string act = "Appartment type changed from:" + Session["oAppartTypeDropDownListTF"].ToString() + "To:" + OldAppartTypeTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Appartment type Updated", Session["oAppartTypeDropDownListTF"].ToString(), OldAppartTypeTF);
                }
                if (String.Compare(Session["oNoOccuDropDownListTF"].ToString(), OldNoOccuTF) != 0)
                {
                    string act = "No Of Occu changed from:" + Session["oNoOccuDropDownListTF"].ToString() + "To:" + OldNoOccuTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "No Of Occu Updated", Session["oNoOccuDropDownListTF"].ToString(), OldNoOccuTF);
                }
                if (String.Compare(Session["oPeriodDropDownListTF"].ToString(), OldPeriodTF) != 0)
                {
                    string act = "Period changed from:" + Session["oPeriodDropDownListTF"].ToString() + "To:" + OldPeriodTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Period Updated", Session["oPeriodDropDownListTF"].ToString(), OldPeriodTF);
                }
                if (String.Compare(Session["oSeasonDropDownListTF"].ToString(), OldSeasonTF) != 0)
                {
                    string act = "Season changed from:" + Session["oSeasonDropDownListTF"].ToString() + "To:" + OldSeasonTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Season Updated", Session["oSeasonDropDownListTF"].ToString(), OldSeasonTF);
                }
            }
            else if (conttypeTF == "From Fractional To Fractional")
            {
                OldAgreeNoTF = TextOldAgreeNoTF3.Text;
                OldClubTF = "";
                OldNoOfPointsTF = "";
                OldEntitleTF = EntitleDropDownListTF3.SelectedItem.Text;
                OldResortTF = ResortDropDownListTF3.SelectedItem.Text;
                OldAppartTypeTF = "";
                OldNoOccuTF = "";
                OldPeriodTF = "";
                OldSeasonTF = "";
                OldResidenceNoTF = Request.Form[ResidenceNoDropDownListTF.UniqueID];
                OldResiTypeTF = Request.Form[ResiTypeDropDownListTF.UniqueID];
                OldFracIntTF = Request.Form[FracIntDropDownListTF.UniqueID];



                if (String.Compare(Session["oTextOldAgreeNoTF3"].ToString(), OldAgreeNoTF) != 0)
                {
                    string act = "Old Agreement No changed from:" + Session["oTextOldAgreeNoTF3"].ToString() + "To:" + OldAgreeNoTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Agreement No Updated", Session["oTextOldAgreeNoTF3"].ToString(), OldAgreeNoTF);
                }

                if (String.Compare(Session["oEntitleDropDownListTF3"].ToString(), OldEntitleTF) != 0)
                {
                    string act = "Old Entitlement changed from:" + Session["oEntitleDropDownListTF3"].ToString() + "To:" + OldEntitleTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Old Entitlement Updated", Session["oEntitleDropDownListTF3"].ToString(), OldEntitleTF);
                }

                if (String.Compare(Session["oResortDropDownListTF3"].ToString(), OldResortTF) != 0)
                {
                    string act = "Resort changed from:" + Session["oResortDropDownListTF3"].ToString() + "To:" + OldResortTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Resort Updated", Session["oResortDropDownListTF3"].ToString(), OldResortTF);
                }

                if (String.Compare(Session["oResidenceNoDropDownListTF1"].ToString(), OldResidenceNoTF) != 0)
                {
                    string act = "Residence No changed from:" + Session["oResidenceNoDropDownListTF1"].ToString() + "To:" + OldResidenceNoTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Residence No Updated", Session["oResidenceNoDropDownListTF1"].ToString(), OldResidenceNoTF);
                }

                if (String.Compare(Session["oResiTypeDropDownListTF"].ToString(), OldResiTypeTF) != 0)
                {
                    string act = "Residence Type changed from:" + Session["oResiTypeDropDownListTF"].ToString() + "To:" + OldResiTypeTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Residence Type Updated", Session["oResiTypeDropDownListTF"].ToString(), OldResiTypeTF);
                }

                if (String.Compare(Session["oFracIntDropDownListTF1"].ToString(), OldFracIntTF) != 0)
                {
                    string act = "Fractional Interest changed from:" + Session["oFracIntDropDownListTF1"].ToString() + "To:" + OldFracIntTF;
                    int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Fractional Interest Updated", Session["oFracIntDropDownListTF1"].ToString(), OldFracIntTF);
                }


            }


            
           

          

           
            //Session["oTextOldAgreeNoTF2"]

            string ResortTF = Request.Form[ResortDropDownListTF.UniqueID];
            string ResidenceNoTF = Request.Form[ResidenceNoDropDownListTF1.UniqueID];
            string ResidenceTypeTF = Request.Form[ResiTypeDropDownListTF1.UniqueID];

            //string ResortF = Request.Form[ResortDropDownListF.UniqueID];
            // string ResidenceNoF = ResidenceNoDropDownListF.SelectedItem.Text;
            // string ResidenceTypeF = ResidenceTypeDropDownListF.SelectedItem.Text;
            // string ResidenceNoF = Request.Form[ResidenceNoDropDownListF.UniqueID];
            // string ResidenceTypeF = Request.Form[ResidenceTypeDropDownListF.UniqueID];
            string TFractionalInt = FracIntDropDownListTF1.SelectedItem.Text;
            string TFractEntitle = EntitlementTFracDropDownList.SelectedItem.Text;
            string TFractFOccu = TextFYOccuTF.Text;
            string TFractDura = TextDurationTF.Text;
            string TFractLOccu = TextLYOccuTF.Text;
            string TFractLease = TextBoxDummyleaseoff.Text;




          



            string DepositF  = TextDepositP.Text.Replace(",", "");
            string DepoPPA = TextDepoPPA.Text.Replace(",", "");
            string AdmissFeesF= TextAdmissFeesP.Text.Replace(",", "");
            string AdminFeesF  = TextAdminFeesP.Text.Replace(",", "");
            string PurchasePriceF  = TextPpurchasePrice.Text.Replace(",", "");
            string CoutryTaxF = TextCountryTaxP.Text.Replace(",", "");
            string GrandTotalP = TextGrandTotalP.Text.Replace(",", "");
            string BalanceDuePAF   = TextPBalaceDPA.Text.Replace(",", "");
            string BalanceDuePATFTD = TextPBalaceDPATOPD.Text.Replace(",", "");

            string tPAFirstPayDateF = datepicker8.Text;


            string PAFirstPayDateF = tPAFirstPayDateF;// Convert.ToDateTime(tPAFirstPayDateF).ToString("yyyy-MM-dd");


           

            string PAAmountInstallF = TextPPAAmountInstall.Text.Replace(",", "");
            string PAFirstInstallF = TextPPAFInstall.Text.Replace(",", "");
            string BalanceDueDatesPAF = TextPBalanceDDates.Text;

            string RemarksF = TextRemarkP.Text;
            //EuroRatesF = TextEuroRateP.Text;
            // AusRatesF = TextAusRateP.Text;
            // GbpRatesF = TextGbpRateP.Text;
            // IdaRatesF = TextIdaRateP.Text;
            string UsePayProtectF = "";
            string PANoOfInstallF = TextPPANoInstall.Text;

            
            //string InitDepof = TextInitDepo.Text;

          //  string BalDepof = TextBalDepo.Text;

          //  string CPAF = TextPrimaryCCard2.Text;

           // string CPADepoF = TextCPADepoComment.Text;

          //  string DepoDatef = TextBoxNBDP.Text;

          //  string BalanceDueDatesPAF2 = TextPBalanceDDates2.Text;

        //   string RemarksF2 = TextRemarkP2.Text;


           // string IniBalNoInstallF = TextIniInstP.Text;
           // string IniBalInstAmtF = TextIniInstAmtP.Text;




            //string PAAmountInstallF  =    TextInstallAmtTF.Text;
           // string PAFirstInstallF =  TextFInstallAmtTF.Text;
           // string BalanceDueDatesPAF =   TextBalanceDueDatesPATF.Text;

            //string RemarksF   =   TextRemarksTF.Text;
            string TotalBalanceF   = TextTotalBalance.Text.Replace(",", "");
          //  string PANoOfInstallF  =  TextNoOfInstallTF.Text;


            string InitDepotf = TextInitDepo.Text.Replace(",", "");

            string BalDepotf = TextBalDepo.Text.Replace(",", "");

            string CPATF = TextPrimaryCCard2.Text;

            string CPADepoTF = TextCPADepoComment.Text;

            string DepoDatetf = TextBoxNBDP.Text;

            string BalanceDueDatesPATF2 = TextPBalanceDDates2.Text;

            string RemarksTF2 = TextRemarkP2.Text;


            string IniBalNoInstallTF = TextIniInstP.Text;
            string IniBalInstAmtTF = TextIniInstAmtP.Text.Replace(",", "");
            string TDcommmentTF = TextBoxTempTDComment.Text;

            string INRexch="0", PurchasePriceUSD, AdminFeesUSD;

            string DepositPUSD, CoutryTaxPUSD, excR, CoutryTaxPCGST, CoutryTaxPSGST;

           

            if (FinaCurrency != "USD")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                DepositPUSD = Math.Round(float.Parse(DepositF) / float.Parse(INRexch), 0).ToString();
                CoutryTaxPUSD = Math.Round(float.Parse(CoutryTaxF) / float.Parse(INRexch), 0).ToString();
                excR = INRexch.ToString();

                if (FinaCurrency == "INR")
                {

                    CoutryTaxPCGST = TextBoxCGST.Text.Replace(",", "");
                    CoutryTaxPSGST = TextBoxSGST.Text.Replace(",", "");


                    string kk = Session["ODeposit"].ToString();
                    if (kk != DepositF)
                    {
                        string depositnotax = Math.Round((float.Parse(DepositF) / 118) * 100, 0).ToString();
                        string depositSCGST = Math.Round(((float.Parse(DepositF) / 118) * 18) / 2, 0).ToString();
                        string depositGST = Math.Round((float.Parse(DepositF) / 118) * 18, 0).ToString();

                        int updatedepo = Queries2.Update_DepositRecieptDetails(DepositF, depositnotax, depositSCGST, depositGST, Deposit_PM, Session["fracido"].ToString());
                    }
                }
                else
                {
                    CoutryTaxPCGST = "0";
                    CoutryTaxPSGST = "0";
                  //  excR = "0";
                }

            }




            /*if (FinaCurrency == "INR")
            {
                INRexch = Session["exrate"].ToString();//Erates("INR");
                DepositPUSD = Math.Round(float.Parse(DepositF) / float.Parse(INRexch), 0).ToString();
                CoutryTaxPUSD = Math.Round(float.Parse(CoutryTaxF) / float.Parse(INRexch), 0).ToString();
                CoutryTaxPCGST = TextBoxCGST.Text;
                CoutryTaxPSGST = TextBoxSGST.Text;
                excR = INRexch.ToString();


 string kk = Session["ODeposit"].ToString();
                if (kk != DepositF)
                {
                    string depositnotax = Math.Round((float.Parse(DepositF) / 118) * 100, 0).ToString();
                    string depositSCGST = Math.Round(((float.Parse(DepositF) / 118) * 18) / 2, 0).ToString();
                    string depositGST = Math.Round((float.Parse(DepositF) / 118) * 18, 0).ToString();

                    int updatedepo = Queries2.Update_DepositRecieptDetails(DepositF, depositnotax, depositSCGST, depositGST, Deposit_PM, Session["fracido"].ToString());
                }

            }*/
            else
            {
                DepositPUSD = DepositF;// "0";
                CoutryTaxPUSD = CoutryTaxF;// "0";
                CoutryTaxPCGST = "0";
                CoutryTaxPSGST = "0";
                excR = "0";
            }


            if (FinaCurrency != "USD")
            {
                INRexch =Session["exrate"].ToString();// Erates("INR");
                PurchasePriceUSD = Math.Round(float.Parse(PurchasePrice) / float.Parse(INRexch), 0).ToString();
                AdminFeesUSD = Math.Round(float.Parse(AdminFees) / float.Parse(INRexch), 0).ToString();
            }
            else
            {
                PurchasePriceUSD = PurchasePrice;// "0";
                AdminFeesUSD = AdminFees;// "0";
            }



            string t1 = EntitlementTFracDropDownList.SelectedItem.Text;
            int fyear = Convert.ToInt32(TextFYOccuTF.Text);
            string ft1, ft2, BalloonPay, LastInstDate =  Session["lastinstalldate"].ToString();

            /*
            
            string InitDepotf = TextInitDepo.Text;

            string BalDepotf = TextBalDepo.Text;

            string CPATF = TextPrimaryCCard2.Text;

            string CPADepoTF = TextCPADepoComment.Text;

            string DepoDatetf = TextBoxNBDP.Text;

            string BalanceDueDatesPATF2 = TextPBalanceDDates2.Text;

            string RemarksTF2 = TextRemarkP2.Text;


            string IniBalNoInstallTF = TextIniInstP.Text;
            string IniBalInstAmtTF = TextIniInstAmtP.Text;
            string TDcommmentTF = TextBoxTempTDComment.Text;
            
            */


          

            if (fyear % 2 == 0)
            {
                ft1 = "Even";
            }
            else
            {
                ft1 = "Odd";
            }

            if (FCheckBox1.Checked)
            {
                ft2 = "Yes";
            }
            else
            {
                ft2 = "No";
            }

            if (CheckBoxBalloonP.Checked)
            {
                BalloonPay = "BP";
            }
            else
            {
                BalloonPay = "";
            }


            int icnt = Queries2.checkforexistinginvoice(Session["fracido"].ToString());
            if (icnt == 0)
            {

                string desc, amot1, date,date1, curr, text11, text12, text13, text14,desc1="";
                string PA = "PA";
                // string PANoOfInstallF = TextNoOfInstallF.Text;
                //string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                //string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallF); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12].Replace(",", "");
                    //text15 = "textBoxN_" + i + "3";
                    //amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                        if (PANoOfInstallF != "1")
                        {
                            if (i == int.Parse(PANoOfInstallF))
                            {

                                text13 = "textBox_" + i + "3";
                                LastInstDate = Request[text13];
                            }
                        }

                    //date = Convert.ToDateTime(date1).ToString("yyyy-MM-dd");
                    // if (int.Parse(amot1) != 0)
                    //{
                    string finaInstI = Queries2.getFinanceInstallID(Session["Gofficeo"].ToString());
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, Session["ProfileIDo"].ToString(), PA, Session["Gofficeo"].ToString(), Session["fracido"].ToString(), DateTime.Now);
                    desc1 += "Installment Id: " + finaInstI + ",desc: " + desc + ",Date: " + date + ",amount: " + amot1 + ",Currency: " + curr + ",";
                    // }

                }
                int insertlognewInstall = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, GenContNumb, desc1, user, DateTime.Now.ToString(), "Edit_contract.aspx", "Installments Details Added", "", desc1);

            }

            int contract_TF = Queries2.Update_Contract_TF(OldAgreeNoTF, OldClubTF, OldNoOfPointsTF, OldEntitleTF, OldResortTF, OldAppartTypeTF, OldNoOccuTF, OldPeriodTF, OldSeasonTF, OldResidenceNoTF, OldResiTypeTF, OldFracIntTF, ResortTF, ResidenceNoTF, ResidenceTypeTF, TFractionalInt, TFractEntitle, TFractFOccu, TFractDura, TFractLOccu, Session["fracido"].ToString(),TFractLease);
            int contup = Queries2.UpdateFracPS(Deposit_PM, DepositF, AdmissFeesF, AdminFeesF, PurchasePriceF, BalanceDuePAF, PANoOfInstallF, PAFirstPayDateF, PAAmountInstallF, PAFirstInstallF, BalanceDueDatesPAF, RemarksF, EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF, YearOfInterestP, TotalBalanceF, DateTime.Now.ToString(), Session["fracido"].ToString(), InitDepotf ,BalDepotf ,DepoDatetf ,BalanceDueDatesPATF2, RemarksTF2,CPATF,IniBalNoInstallTF,IniBalInstAmtTF,BalloonPay,LastInstDate,CPADepoTF, BalanceDuePATFTD,DepoPPA,GrandTotalP, DepositPUSD, CoutryTaxPUSD, CoutryTaxPCGST, CoutryTaxPSGST, excR, TDcommmentTF);

            int contFina = Queries2.UpdateContFrac(affilice, affilhp, salesrep, tomanager, buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, ID_Card, CrownCurr, Session["fracido"].ToString(), Session["DealRegDate"].ToString(), ft1, ft2, DateTime.Now, Convert.ToInt32(Session["cweekno"]), ContComment, PaymentMethodDeatils, Boverride, PurchasePriceUSD, AdminFeesUSD,Contractvenue);

            int contFinadetails = Queries2.UpdateFinanceDetails(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, Session["fracido"].ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect,FinaDate);


            if (String.Compare(Session["oResidenceNoDropDownListTF1"].ToString(), ResidenceNoTF) != 0)
            {
                string act = "Residence no changed from:" + Session["oResidenceNoDropDownListTF1"].ToString() + "To:" + ResidenceNoTF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Residence no Updated", Session["oResidenceNoDropDownListTF1"].ToString(), ResidenceNoTF);
            }
            if (String.Compare(Session["oResiTypeDropDownListTF1"].ToString(), ResidenceTypeTF) != 0)
            {
                string act = "Residence Type changed from:" + Session["oResiTypeDropDownListTF1"].ToString() + "To:" + ResidenceTypeTF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Residence Type Updated", Session["oResiTypeDropDownListTF1"].ToString(), ResidenceTypeTF);
            }
            if (String.Compare(Session["oFracIntDropDownListTF1"].ToString(), TFractionalInt) != 0)
            {
                string act = "Fractional Interest changed from:" + Session["oFracIntDropDownListTF1"].ToString() + "To:" + TFractionalInt;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Fractional Interest Updated", Session["oFracIntDropDownListTF1"].ToString(), TFractionalInt);
            }
            if (String.Compare(Session["oEntitlementTFracDropDownList"].ToString(), TFractEntitle) != 0)
            {
                string act = "Fractional Entitlement changed from:" + Session["oEntitlementTFracDropDownList"].ToString() + "To:" + TFractEntitle;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Fractional Entitlement Updated", Session["oEntitlementTFracDropDownList"].ToString(), TFractEntitle);
            }
            if (String.Compare(Session["oTextFYOccuTF"].ToString(), TFractFOccu) != 0)
            {
                string act = "First year Occupancy changed from:" + Session["oTextFYOccuTF"].ToString() + "To:" + TFractFOccu;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First year Occupancy Updated", Session["oTextFYOccuTF"].ToString(), TFractFOccu);
            }
            if (String.Compare(Session["oTextDurationTF"].ToString(), TFractDura) != 0)
            {
                string act = "Duration changed from:" + Session["oTextDurationTF"].ToString() + "To:" + TFractDura;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Duration Updated", Session["oTextDurationTF"].ToString(), TFractDura);
            }
            if (String.Compare(Session["oTextLYOccuTF"].ToString(), TFractLOccu) != 0)
            {
                string act = "Last year Occupancy changed from:" + Session["oTextLYOccuTF"].ToString() + "To:" + TFractLOccu;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Last year Occupancy Updated", Session["oTextLYOccuTF"].ToString(), TFractLOccu);
            }

            if (String.Compare(Session["oTextBoxDummyleaseoff"].ToString(), TFractLease) != 0)
            {
                string act = "Fractional Lease Off changed from:" + Session["oTextBoxDummyleaseoff"].ToString() + "To:" + TFractLease;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Fractional Lease Off Updated", Session["oTextBoxDummyleaseoff"].ToString(), TFractLease);
            }


            if (String.Compare(Session["ODeposit"].ToString(), DepositF) != 0)
            {
                string act = "Deposit changed from:" + Session["ODeposit"].ToString() + "To:" + DepositF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Updated", Session["ODeposit"].ToString(), DepositF);
            }

            if (String.Compare(Session["oTextDepoPPA"].ToString(), DepoPPA) != 0)
            {
                string act = "Deposit PA changed from:" + Session["oTextDepoPPA"].ToString() + "To:" + DepoPPA;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit PA Updated", Session["oTextDepoPPA"].ToString(), DepoPPA);
            }

            if (String.Compare(Session["oTextAdmissFeesP"].ToString(), AdmissFeesF) != 0)
            {
                string act = "Admission Fees changed from:" + Session["oTextAdmissFeesP"].ToString() + "To:" + AdmissFeesF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admission Fees Updated", Session["oTextAdmissFeesP"].ToString(), AdmissFeesF);
            }

            if (String.Compare(Session["oTextAdminFeesP"].ToString(), AdminFeesF) != 0)
            {
                string act = "Administration Fees changed from:" + Session["oTextAdminFeesP"].ToString() + "To:" + AdminFeesF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Administration Fees Updated", Session["oTextAdminFeesP"].ToString(), AdminFeesF);
            }



            if (String.Compare(Session["oTextPpurchasePrice"].ToString(), PurchasePriceF) != 0)
            {
                string act = "Purchase Price changed from:" + Session["oTextPpurchasePrice"].ToString() + "To:" + PurchasePriceF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Purchase Price Updated", Session["oTextPpurchasePrice"].ToString(), PurchasePriceF);
            }

            if (String.Compare(Session["oTextCountryTaxP"].ToString(), CoutryTaxF) != 0)
            {
                string act = "Country Tax changed from:" + Session["oTextCountryTaxP"].ToString() + "To:" + CoutryTaxF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Admission Fees Updated", Session["oTextCountryTaxP"].ToString(), CoutryTaxF);
            }

            if (String.Compare(Session["oTextGrandTotalP"].ToString(), GrandTotalP) != 0)
            {
                string act = "Grand Total changed from:" + Session["oTextGrandTotalP"].ToString() + "To:" + GrandTotalP;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Grand Total Updated", Session["oTextGrandTotalP"].ToString(), GrandTotalP);
            }

            if (String.Compare(Session["oTextPBalaceDPA"].ToString(), BalanceDuePAF) != 0)
            {
                string act = "Balance Due changed from:" + Session["oTextPBalaceDPA"].ToString() + "To:" + BalanceDuePAF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Updated", Session["oTextPBalaceDPA"].ToString(), BalanceDuePAF);
            }

            if (String.Compare(Session["oTextPBalaceDPATOPD"].ToString(), BalanceDuePATFTD) != 0)
            {
                string act = "Balance Due TOP Drawer changed from:" + Session["oTextPBalaceDPATOPD"].ToString() + "To:" + BalanceDuePATFTD;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due TOP Drawer Updated", Session["oTextPBalaceDPATOPD"].ToString(), BalanceDuePATFTD);
            }

            if (String.Compare(Session["oPS_PA_FInstall_Date"].ToString(), tPAFirstPayDateF) != 0)
            {
                string act = "First installment Date changed from:" + Session["oPS_PA_FInstall_Date"].ToString() + "To:" + tPAFirstPayDateF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First installment Date Updated", Session["oPS_PA_FInstall_Date"].ToString(), tPAFirstPayDateF);
            }

            if (String.Compare(Session["oTextPPAAmountInstall"].ToString(), PAAmountInstallF) != 0)
            {
                string act = "Other Installment changed from:" + Session["oTextPPAAmountInstall"].ToString() + "To:" + PAAmountInstallF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Other Installment Updated", Session["oTextPPAAmountInstall"].ToString(), PAAmountInstallF);
            }


            if (String.Compare(Session["oTextPPAFInstall"].ToString(), PAFirstInstallF) != 0)
            {
                string act = "First installment Date changed from:" + Session["oTextPPAFInstall"].ToString() + "To:" + PAFirstInstallF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "First installment Date Updated", Session["oTextPPAFInstall"].ToString(), PAFirstInstallF);
            }

            if (String.Compare(Session["oTextPBalanceDDates"].ToString(), BalanceDueDatesPAF) != 0)
            {
                string act = "Balance Due Dates changed from:" + Session["oTextPBalanceDDates"].ToString() + "To:" + BalanceDueDatesPAF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due Dates Updated", Session["oTextPBalanceDDates"].ToString(), BalanceDueDatesPAF);
            }

            if (String.Compare(Session["oPS_TP_Comment"].ToString(), TDcommmentTF) != 0)
            {
                string act = "Top Drawer comment changed from:" + Session["oPS_TP_Comment"].ToString() + "To:" + TDcommmentTF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Top Drawer comment Updated", Session["oPS_TP_Comment"].ToString(), TDcommmentTF);
            }




            if (String.Compare(Session["oTextPPANoInstall"].ToString(), PANoOfInstallF) != 0)
            {
                string act = "PA No of Installment changed from:" + Session["oTextPPANoInstall"].ToString() + "To:" + PANoOfInstallF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "PA No of Installment Updated", Session["oTextPPANoInstall"].ToString(), PANoOfInstallF);
            }

            if (String.Compare(Session["oTextRemarkP"].ToString(), RemarksF) != 0)
            {
                string act = "Remarks changed from:" + Session["oTextRemarkP"].ToString() + "To:" + RemarksF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Remarks Updated", Session["oTextRemarkP"].ToString(), RemarksF);
            }


            if (String.Compare(Session["oTextInitDepo"].ToString(), InitDepotf) != 0)
            {
                string act = "Initial Deposit changed from:" + Session["oTextInitDepo"].ToString() + "To:" + InitDepotf;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Deposit Updated", Session["oTextInitDepo"].ToString(), InitDepotf);
            }
            if (String.Compare(Session["oTextBalDepo"].ToString(), BalDepotf) != 0)
            {
                string act = "Balance Deposit changed from:" + Session["oTextBalDepo"].ToString() + "To:" + BalDepotf;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Deposit  Updated", Session["oTextBalDepo"].ToString(), BalDepotf);
            }

            if (String.Compare(Session["oTextPrimaryCCard2"].ToString(), CPATF) != 0)
            {
                string act = "CPA comment changed from:" + Session["oTextPrimaryCCard2"].ToString() + "To:" + CPATF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "CPA comment  Updated", Session["oTextPrimaryCCard2"].ToString(), CPATF);
            }

            if (String.Compare(Session["oPS_Deposit_Comment"].ToString(), CPADepoTF) != 0)
            {
                string act = "CPA Deposit changed from:" + Session["oPS_Deposit_Comment"].ToString() + "To:" + CPADepoTF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "CPA Deposit  Updated", Session["oPS_Deposit_Comment"].ToString(), CPADepoTF);
            }

            if (String.Compare(Session["oTextPBalanceDDates2"].ToString(), BalanceDueDatesPATF2) != 0)
            {
                string act = "Balance Due dates 2 changed from:" + Session["oTextPBalanceDDates2"].ToString() + "To:" + BalanceDueDatesPATF2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Balance Due dates 2 Updated", Session["oTextPBalanceDDates2"].ToString(), BalanceDueDatesPATF2);
            }
            if (String.Compare(Session["oPS_Deposit_Date"].ToString(), DepoDatetf) != 0)
            {
                string act = "Deposit Date changed from:" + Session["oPS_Deposit_Date"].ToString() + "To:" + DepoDatetf;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Deposit Date Updated", Session["oPS_Deposit_Date"].ToString(), DepoDatetf);
            }
            if (String.Compare(Session["oTextRemarkP2"].ToString(), RemarksTF2) != 0)
            {
                string act = "Remarks 2 changed from:" + Session["oTextRemarkP2"].ToString() + "To:" + RemarksTF2;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Remarks 2 Updated", Session["oTextRemarkP2"].ToString(), RemarksTF2);
            }


            if (String.Compare(Session["oTextIniInstP"].ToString(), IniBalNoInstallTF) != 0)
            {
                string act = "Initial Bal No of Installment changed from:" + Session["oTextIniInstP"].ToString() + "To:" + IniBalNoInstallTF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Bal No of Installment Updated", Session["oTextIniInstP"].ToString(), IniBalNoInstallTF);
            }
            if (String.Compare(Session["oTextIniInstAmtP"].ToString(), IniBalInstAmtTF) != 0)
            {
                string act = "Initial Bal No of Installment amount changed from:" + Session["oTextIniInstAmtP"].ToString() + "To:" + IniBalInstAmtTF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Initial Bal No of Installment amount Updated", Session["oTextIniInstAmtP"].ToString(), IniBalInstAmtTF);
            }
            if (String.Compare(Session["oTextTotalBalance"].ToString(), TotalBalanceF) != 0)
            {
                string act = "Total balance changed from:" + Session["oTextTotalBalance"].ToString() + "To:" + TotalBalanceF;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileIDo"].ToString(), GenContNumb , act, user, DateTime.Now.ToString(), "Edit_Contract.aspx", "Total balance Updated", Session["oTextTotalBalance"].ToString(), TotalBalanceF);
            }

        }

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

         if(resort != "BRR" || resort != "KRR" || resort != "PRR" || resort != "FM")
            {
                resort = "";
            }

        // string globcontclub = "";
        //globcontclub= Session["EGGlobContClub"].ToString();
        //Session["EPConttype"] = DropDownList40.SelectedItem.Text;
        //Session["EPofficeo"] = Session["Gofficeo"].ToString();
        // Session["EPGlobContClub"] = "";
        // Session["EPGlobContClub"] = globcontclub;// Session["EGGlobContClub"].ToString();
        //Session["EPPaymentMethod"] = PaymentMethod2;
        //Session["EPAffil"] = affil2;
        // Session["EPCrownCurr"] = CrownCurr;

        if (Session["Gofficeo"].ToString() == "GER" || Session["Gofficeo"].ToString() == "GRE" || Session["Gofficeo"].ToString() == "FRA" || Session["Gofficeo"].ToString() == "ITA" || Session["Gofficeo"].ToString() == "IRE")
        {
            if (TextBoxDummyConoffcheck.Text == "1")
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
            Session["Pofficeo"] = Session["Gofficeo"].ToString();
        }

        // string globcontclub = "";
        //globcontclub= Session["EGGlobContClub"].ToString();
        //Session["EPConttype"] = DropDownList40.SelectedItem.Text;
        //Session["EPofficeo"] = Session["Gofficeo"].ToString();
        // Session["EPGlobContClub"] = "";
        // Session["EPGlobContClub"] = globcontclub;// Session["EGGlobContClub"].ToString();
        //Session["EPPaymentMethod"] = PaymentMethod2;
        //Session["EPAffil"] = affil2;
        // Session["EPCrownCurr"] = CrownCurr;

        Session["EPConttype"] = DropDownList40.SelectedItem.Text;
        //Session["EPofficeo"]= Session["Gofficeo"].ToString();
        Session["EPGlobContClub"]= Session["ECGGlobContClub"].ToString();
        Session["EPPaymentMethod"]= PaymentMethod2;
        Session["EPAffil"]= affil2;
        Session["EPCrownCurr"]= CrownCurr;
        Session["EPresort"] = resort;
Session["EPFinaCurrency"] = FinaCurrency;


        if (FinaCurrency == "INR")


        {

            if (PaymentMethod == "PARSHURAM FINANCE")
            {
                PaymentMethod2 = "Parshuram";
            }
            else
            {
                PaymentMethod2 = "NP";
            }


            PrintPdfDropDownList.Items.Clear();
            string ContType1 = DropDownList40.SelectedItem.Text;
            DataSet ds21 = Queries2.LoadPrintFiles3(ContType1, Session["Pofficeo"].ToString(), Session["ECGGlobContClub"].ToString(), PaymentMethod2, affil2, FinaCurrency, resort);
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
            string ContType1 = DropDownList40.SelectedItem.Text;
            DataSet ds21 = Queries2.LoadPrintFiles2(ContType1, Session["Pofficeo"].ToString(), Session["ECGGlobContClub"].ToString(), PaymentMethod2, affil2, CrownCurr, resort, Session["Cooloff"].ToString(), Session["EPFinaCurrency"].ToString());
            PrintPdfDropDownList.DataSource = ds21;
            PrintPdfDropDownList.DataTextField = "Printpdf_name";
            PrintPdfDropDownList.DataValueField = "Printpdf_name";
            PrintPdfDropDownList.AppendDataBoundItems = true;
            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
            PrintPdfDropDownList.DataBind();
        }




      /*  PrintPdfDropDownList.Items.Clear();
        string ContType1 = DropDownList40.SelectedItem.Text;
        DataSet ds21 = Queries2.LoadPrintFiles2(ContType1, Session["Gofficeo"].ToString(), Session["ECGGlobContClub"].ToString(), PaymentMethod2, affil2, CrownCurr,resort);
        PrintPdfDropDownList.DataSource = ds21;
        PrintPdfDropDownList.DataTextField = "Printpdf_name";
        PrintPdfDropDownList.DataValueField = "Printpdf_name";
        PrintPdfDropDownList.AppendDataBoundItems = true;
        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
        PrintPdfDropDownList.DataBind();*/



        //string PmentDetailsId = Queries2.getPaymentDetailsID(officeo);
        //string PCard_Type = CardPrimaryDropDownList.SelectedItem.Text;
        //string PIssuing_Bank = TextIssuingP.Text;
        //string PCredit_Card_No = TextCardNumbP.Text;
        //string PCard_Holders_Name = TextCardHNameP.Text;
        //string PExpiry = TextExpMonthP.Text;
        //string PSecurity_No = TextSecurityP.Text;
        //string PFor_Depo = TextFDepo1.Text;
        //string PFor_Bala = TextFBala1.Text;
        //string SCard_Type = CardSecondaryDropDownList.SelectedItem.Text;
        //string SIssuing_Bank = TextIssuingS.Text;
        //string SCredit_Card = TextCardNumbS.Text;
        //string SCard_Holders_Name = TextCardHNameS.Text;
        //string SExpiry = TextExpiryS.Text;
        //string SSecurity_No = TextSecurityS.Text;
        //string SFor_Depo = TextFDepo2.Text;
        //string SFor_Bala = TextFBala2.Text;
        //DateTime entrydate = DateTime.Now;
        //string Pcomments = TextPrimaryCCard.Text;
        //string Scomments = TextSecondaryCCard.Text;



        //int PmentDetails = Queries2.InserPaymentDetails(PmentDetailsId, PCard_Type, PIssuing_Bank, PCredit_Card_No, PCard_Holders_Name, PExpiry, PSecurity_No,
        //    PFor_Depo, PFor_Bala, SCard_Type, SIssuing_Bank, SCredit_Card, SCard_Holders_Name, SExpiry, SSecurity_No, SFor_Depo, SFor_Bala, ProfileIDo, contFinance, entrydate, officeo, Pcomments, Scomments);

        string script = "<script> $(function() { $('#tabs').tabs({ disabled: [] }); $( '#tabs' ).tabs({ active: 4 }); });</script> ";
        //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);



       /* }
        catch (Exception ex)
        {


            //MessageBox.Show("Error while Updating profile " + ex.Message);


            string msg = "Error while Updating coontract " + ex.Message;
            //MessageBox.Show("Error while creating profile " + ex.Message);
            //string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

            //int delete = Queries2.Deleteprofileonerror(ProfileIDo);

            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

        }*/


    }


    protected void Button4_Click(object sender, EventArgs e)
    {

        var printr = PrintPdfTextBox2.Text; //PrintPdfDropDownList.SelectedItem.Text;
        DataTable datatable = Queries2.loadreport(Session["ECGetContnumb"].ToString(), printr, Session["Pofficeo"].ToString());

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
        crystalReport.Close();
        crystalReport.Dispose();
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
        // Response.Close();







        //  string ContType = PrintPdfDropDownList.SelectedItem.Text;
        // string text2 = "reports"+ ContType + ".rpt";
        // ReportDocument cryRpt = new ReportDocument();
        // cryRpt.Load(Server.MapPath("~/reports/NEW POINTS CPA.rpt"));
        //  cryRpt.FileName = Server.MapPath("~/reports/NEW POINTS CPA.rpt");
        // CrystalReportViewer1.ReportSource = cryRpt;
    }


    public class resort
    {
        public string ResortID { get; set; }
        public string ResortName { get; set; }
    }

    [WebMethod]
    public static string PopulateDropDownList()
    {
        DataTable dt = new DataTable();
        List<resort> listRes = new List<resort>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //  using (SqlCommand cmd = new SqlCommand("select Contract_Resort_ID,Contract_Resort_Name from Contract_Resort where Contract_Resort_Status='Active' order by 1", con))
            using (SqlCommand cmd = new SqlCommand("select Contract_Resort_ID,Contract_Resort_Name from Contract_Resort where Contract_Resort_Status='Active' and office='IVO' order by 1", con))
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

                        resort objst = new resort();

                        objst.ResortID = Convert.ToString(dt.Rows[i]["Contract_Resort_ID"]);

                        objst.ResortName = Convert.ToString(dt.Rows[i]["Contract_Resort_Name"]);

                        listRes.Insert(i, objst);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class resortno
    {
        public string ResortNoID { get; set; }
        public string ResortNoName { get; set; }
    }


    [WebMethod]
    public static string PopulateResortNoDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<resortno> listRes = new List<resortno>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Contract_Residence_ID,Contract_Residence_Name from Contract_Residence_No where Contract_Resort_ID in (select Contract_Resort_ID from Contract_Resort where Contract_Resort_Name ='" + id + "') ", con))
            using (SqlCommand cmd = new SqlCommand("select Contract_Residence_ID,Contract_Residence_Name from Contract_Residence_No where Contract_Resort_ID in (select Contract_Resort_ID from Contract_Resort where Contract_Resort_Name ='" + id + "' and office='IVO') ", con))
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

                        resortno objst2 = new resortno();

                        objst2.ResortNoID = Convert.ToString(dt.Rows[i]["Contract_Residence_ID"]);

                        objst2.ResortNoName = Convert.ToString(dt.Rows[i]["Contract_Residence_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class ResidenceType
    {
        public string ResidenceTypeID { get; set; }
        public string ResidenceTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateResidenceTypeDropDownList(string id, string id2)
    {
        DataTable dt = new DataTable();
        List<ResidenceType> listRes = new List<ResidenceType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            // using (SqlCommand cmd = new SqlCommand("select Contract_Resi_Type_ID,Contract_Resi_Type_Name from Contract_Residence_Type where Contract_Residence_ID in (select Contract_Residence_ID from Contract_Residence_No where Contract_Residence_Name='" + id + "')", con))
            using (SqlCommand cmd = new SqlCommand("select Contract_Resi_Type_ID,Contract_Resi_Type_Name from Contract_Residence_Type where Contract_Residence_ID in (select Contract_Residence_ID from Contract_Residence_No where Contract_Resort_ID in (select Contract_Resort_ID from Contract_Resort where Contract_Resort_Name ='" + id2 + "' and office='IVO') and Contract_Residence_Name ='" + id + "')", con))
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

                        ResidenceType objst2 = new ResidenceType();

                        objst2.ResidenceTypeID = Convert.ToString(dt.Rows[i]["Contract_Resi_Type_ID"]);

                        objst2.ResidenceTypeName = Convert.ToString(dt.Rows[i]["Contract_Resi_Type_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //for contract type


    public class Contracttype
    {
        public string ContracttypeID { get; set; }
        public string ContracttypeName { get; set; }
    }


    [WebMethod]
    public static string ContracttypeDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<Contracttype> listRes = new List<Contracttype>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Type_Name from contract_type where contract_type_contract_type = '" + id + "'and Contract_Type_Status = 'Active' order by 1 ", con))
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

                        Contracttype objst2 = new Contracttype();

                        // objst2.ResortNoID = Convert.ToString(dt.Rows[i]["Contract_Residence_ID"]);

                        objst2.ContracttypeName = Convert.ToString(dt.Rows[i]["Contract_Type_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //for venue dropdownlist
    public class VenueType
    {
        public string VenueTypeID { get; set; }
        public string VenueTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateVenueDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<VenueType> listRes = new List<VenueType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select v.Venue_Name,v.Venue_ID  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID   where vc.Venue_Country_Name = '" + id + "'", con))
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

                        VenueType objst2 = new VenueType();

                        objst2.VenueTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.VenueTypeName = Convert.ToString(dt.Rows[i]["Venue_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class VenueGroupType
    {
        public string VenueGroupTypeID { get; set; }
        public string VenueGroupTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateVenueGroupDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<VenueGroupType> listRes = new List<VenueGroupType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select Venue2_Name from venue2 where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "')  and venue2_status='Active' ", con))
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

                        VenueGroupType objst2 = new VenueGroupType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.VenueGroupTypeName = Convert.ToString(dt.Rows[i]["Venue2_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //load sub venue

    public class SubVenueGroupType
    {
        public string SubVenueGroupTypeID { get; set; }
        public string SubVenueGroupTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateSubVenueGroupDropDownList(string venueid, string countid, string venue)
    {
        DataTable dt = new DataTable();
        List<SubVenueGroupType> listRes = new List<SubVenueGroupType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
           // using (SqlCommand cmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name='" + venueid + "')", con))
		using (SqlCommand cmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue2_ID in (select Venue2_ID from Venue2 where Venue2_Name='" + venueid + "' and Venue_ID = (select Venue_ID from venue where Venue_Name='" + venue + "' and Venue_Status='Active' and Venue_Country_ID= (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))) and SVenue_Status='Active'", con))
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

                        SubVenueGroupType objst2 = new SubVenueGroupType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.SubVenueGroupTypeName = Convert.ToString(dt.Rows[i]["SVenue_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



    public class MrktProgType
    {
        public string MrktProgTypeID { get; set; }
        public string MrktProgTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateMrktProgDropDownList(string venueGroupid, string countid,string venueid)
    {
        DataTable dt = new DataTable();
        List<MrktProgType> listRes = new List<MrktProgType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
            //using (SqlCommand cmd = new SqlCommand("select MProgram2_Name from Marketing_Program2 where Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueid + "') and MProgram2_Status='Active'", con))
	using (SqlCommand cmd = new SqlCommand("select MProgram2_Name from Marketing_Program2 where Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueGroupid + "' and Venue_ID = (select Venue_ID from venue where Venue_Name='" + venueid + "' and Venue_Status='Active'  and Venue_Country_ID= (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')) and MProgram2_Status='Active')", con))

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

                        MrktProgType objst2 = new MrktProgType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.MrktProgTypeName = Convert.ToString(dt.Rows[i]["MProgram2_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class AgentType
    {
        public string AgentTypeID { get; set; }
        public string AgentTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentDropDownList(string markid, string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<AgentType> listRes = new List<AgentType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            // using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
            using (SqlCommand cmd = new SqlCommand("select distinct MSource_Name from Marketing_Source where MProgram2_ID in (select MProgram2_ID from Marketing_Program2 where MProgram2_Name='" + markid + "' and Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name='" + venueid + "')) and MSource_Status='Active'", con))
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

                        AgentType objst2 = new AgentType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.AgentTypeName = Convert.ToString(dt.Rows[i]["MSource_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



    public class AgentCodeType
    {
        public string AgentCodeTypeID { get; set; }
        public string AgentCodeTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentCodeDropDownList(string markid, string agentid, string venueid)
    {
        DataTable dt = new DataTable();
        List<AgentCodeType> listRes = new List<AgentCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Agent_Code from Agent_Code where Agent_id in (select Agent_ID from Agent_marketing where Agent_Name = '" + agentid + "' and marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select distinct SCode_Name from Source_code where MSource_ID in (select MSource_ID from Marketing_Source where MSource_Name = '" + agentid + "' and MProgram2_ID in (select MProgram2_ID from Marketing_Program2 where MProgram2_Name = '" + markid + "' and  Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueid + "')) )  and SCode_Status='Active'", con))
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

                        AgentCodeType objst2 = new AgentCodeType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.AgentCodeTypeName = Convert.ToString(dt.Rows[i]["SCode_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //public class CountryCodeType
    //{
    //    public string CountryCodeTypeID { get; set; }
    //    public string CountryCodeTypeName { get; set; }
    //}


    //[WebMethod]
    //public static string PopulateCountryCodeDropDownList(string Countid)
    //{
    //    DataTable dt = new DataTable();
    //    List<CountryCodeType> listRes = new List<CountryCodeType>();

    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("select Country_Code from Country where Country_Name='" + Countid + "'", con))
    //        {
    //            con.Open();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
    //            da.Fill(dt);
    //            if (dt.Rows.Count > 0)
    //            {
    //                for (int i = 0; i < dt.Rows.Count; i++)
    //                {
    //                    /*objRes.Add(new resort
    //                    {
    //                        //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
    //                        ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
    //                    });*/

    //                    CountryCodeType objst2 = new CountryCodeType();

    //                    //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

    //                    objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["Country_Code"]);

    //                    listRes.Insert(i, objst2);


    //                }
    //            }
    //            JavaScriptSerializer jscript = new JavaScriptSerializer();

    //            return jscript.Serialize(listRes);
    //        }
    //    }
    //}


    public class CountryCodeType
    {
        public string CountryCodeTypeID { get; set; }
        public string CountryCodeTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateCountryCodeDropDownList(string Countid)
    {
        DataTable dt = new DataTable();
        List<CountryCodeType> listRes = new List<CountryCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Nationality_Country_Name from Nationality where Nationality_Name='" + Countid + "'", con))
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

                        CountryCodeType objst2 = new CountryCodeType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["Nationality_Country_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



    //load sales rep with 

    public class SalesRepType
    {
        public string SalesRepTypeID { get; set; }
        public string SalesRepTypeName { get; set; }
    }


    [WebMethod]
     public static string SalesRepTypeList(string venueid, string countid,string venue)
    {

        string vencountry = Queries2.GetVenueCountryCode(countid);
        DataTable dt = new DataTable();
        List<SalesRepType> listRes = new List<SalesRepType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            if (venue != "Inhouse")
            {
                if ((venueid != "Flybuy") && (venueid != "FLYBUY"))
                {
                    using (SqlCommand cmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID='" + vencountry + "' and venue= '" + venue + "' and Group_Venue= '" + venueid + "'and Sales_Rep_Status='Active' order by Sales_Rep_Name", con))
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

                                SalesRepType objst2 = new SalesRepType();

                                //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                                objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                                listRes.Insert(i, objst2);


                            }
                        }
                        JavaScriptSerializer jscript = new JavaScriptSerializer();

                        return jscript.Serialize(listRes);
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID='" + vencountry + "'and Sales_Rep_Status='Active' order by Sales_Rep_Name ", con))
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

                                SalesRepType objst2 = new SalesRepType();

                                //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                                objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                                listRes.Insert(i, objst2);


                            }
                        }
                        JavaScriptSerializer jscript = new JavaScriptSerializer();

                        return jscript.Serialize(listRes);
                    }


                }
            }
            else
            {

                using (SqlCommand cmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID='" + vencountry + "' and venue= '" + venue + "'and Sales_Rep_Status='Active' order by Sales_Rep_Name", con))
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

                            SalesRepType objst2 = new SalesRepType();

                            //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                            objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }

            }
        }
    }





    /* public class contnumbgen
     {
         public string contnumbgenno { get; set; }
         //public string ResidenceTypeName { get; set; }
     }*/

    [WebMethod]

    public static string loadpointcont1(string venuecountry)
    {
        //contnumbgen c1 = new contnumbgen();

        // DataSet dt = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            /*SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = officeo;
            SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            // da = new SqlDataAdapter(SqlCmd);
            //dt = new DataSet();
            //da.Fill(dt);*/

            SqlCommand SqlCmd = new SqlCommand("select Venue_Country_ID from VenueCountry where Venue_Country_Name = @venuecountry", con);
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            //cs1.Open();
            //SqlDataReader rd = SqlCmd.ExecuteReader();
            DataTable data = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            //dt = new DataSet();
            da.Fill(data);

            if (data.Rows.Count > 0)
            {
                return data.Rows[0].ItemArray[0].ToString();//rd["Venue_Country_ID"].ToString();

            }
            //cs1.Close();
        }
        return "hi";

    }



   /* [System.Web.Services.WebMethod]
    public static string helo1(string name, string venue, string club, string mark, string conttype)
    {
        //return "Hello "+name;
        string finaInstI = "";

        if (conttype == "Points" || conttype == "Trade Into Points")
        {
            finaInstI = Queries2.LoadPointCont(HttpContext.Current.Session["Gofficeo"].ToString(), club, name, venue, mark,"");
        }
        else if (conttype == "Fractional" || conttype == "Trade Into Fractional")
        {
            finaInstI = Queries2.LoadFracCont(HttpContext.Current.Session["Gofficeo"].ToString(), club, name, venue, mark,"");
        }
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        //{
        //    /*SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", cs1);
        //    SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = Session["Gofficeo"].ToString();
        //    SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
        //    SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
        //    SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        //    // da = new SqlDataAdapter(SqlCmd);
        //    //dt = new DataSet();
        //    //da.Fill(dt);*/

        //    // SqlCommand SqlCmd = new SqlCommand("select Venue_Country_ID from VenueCountry where Venue_Country_Name = @venuecountry", con);
        //    SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", con);
        //    SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = officeo;
        //    SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club;
        //    SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = name;
        //    SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;


        //    //SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = name;
        //    //cs1.Open();
        //    //SqlDataReader rd = SqlCmd.ExecuteReader();
        //    DataTable data = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
        //    //dt = new DataSet();
        //    da.Fill(data);

        //    if (data.Rows.Count > 0)
        //    {
        //        return data.Rows[0].ItemArray[0].ToString();//rd["Venue_Country_ID"].ToString();

        //    }
        //    //cs1.Close();
        //}
       /* return finaInstI;


    }*/

    [System.Web.Services.WebMethod]
    public static string[] LoadPropfess(string cur, string FOccu, string club)
    {
        // string[] finaInstI = new string[3];
        //return "Hello "+name;
        string[] s = new string[2];
        string finaInstI = Queries2.LoadPropfess(cur, FOccu, club);
        //return finaInstI;

        //var k = finaInstI.Split('-');



        //string str = null;
        string[] strArr = new string[10];
        //int count = 0;
        //str = "CSharp split test";
        char[] splitchar = { '-' };
        strArr = finaInstI.Split(splitchar);

        return strArr;
        // return NoPoints;
    }

    //gift option
    [System.Web.Services.WebMethod]
    public static int totalgift()
    {
        //return "Hello "+name;
        int finaInstI;

        finaInstI = Queries2.countgift(HttpContext.Current.Session["ProfileIDo"].ToString());
        return finaInstI;

        //  return "hi";


    }

    [System.Web.Services.WebMethod]
    public static string pnumberCount(string id)
    {
        //return "Hello "+name;
        string Pnumb="";

       // Pnumb = Queries2.PnumbCount(id);
        


        string off = HttpContext.Current.Session["Gofficeo"].ToString();

      //  if (off != "GER" || off != "GRE")
     //   {
            Pnumb = Queries2.PnumbCount(id, HttpContext.Current.Session["Gofficeo"].ToString());

     //   }

        return Pnumb;

        // return "hi";


    }




    [System.Web.Services.WebMethod]
    public static string pnumberCountINR(string id)
    {
        //return "Hello "+name;
        string Pnumb;

        Pnumb = Queries2.PnumbCountINR(HttpContext.Current.Session["Gofficeo"].ToString(), id);
        return Pnumb;

        // return "hi";


    }





    [System.Web.Services.WebMethod]
    public static string Erates(string id)
    {
        //return "Hello "+name;
        string ER;

        ER = Queries2.getExchangeRate(id);
        return ER;

        // return "hi";


    }

    [System.Web.Services.WebMethod]
    public static string gmcharge(string id, string id2)
    {
        //return "Hello "+name;
        string mcval;

        mcval = Queries2.loadmcharge(id, id2);
        return mcval;

        // return "hi";


    }




    public class PayMethodType
    {
        public string PayMethodTypeID { get; set; }
        public string PayMethodTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateBalancePayMethod(string Currtype)
    {
        DataTable dt = new DataTable();
        List<PayMethodType> listRes = new List<PayMethodType>();

        if (Currtype != "INR")
        {
            Currtype = "USD";
        }

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select pay_method_name from pay_method where currency='" + Currtype + "'", con))
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

                        PayMethodType objst2 = new PayMethodType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.PayMethodTypeName = Convert.ToString(dt.Rows[i]["pay_method_name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
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
        string P1Conttype = HttpContext.Current.Session["EPConttype"].ToString();
        string P1officeo = "";// HttpContext.Current.Session["EPofficeo"].ToString();
        string P1GlobContClub = HttpContext.Current.Session["EPGlobContClub"].ToString();
        string P1PaymentMethod = HttpContext.Current.Session["EPPaymentMethod"].ToString();
        string P1Affil = HttpContext.Current.Session["EPAffil"].ToString();
        string P1CrownCurr = HttpContext.Current.Session["EPCrownCurr"].ToString();
        string P1resort = HttpContext.Current.Session["EPresort"].ToString();
string P1Finacurrency = HttpContext.Current.Session["EPFinaCurrency"].ToString();
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
                //using (SqlCommand cmd = new SqlCommand("select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' union select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr= '" + P1CrownCurr + "' and  Printpdf_Lang='" + Lang + "'  and  Printpdf_FracMem='" + P1resort + "'", con))
                 using (SqlCommand cmd = new SqlCommand("select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr= '" + P1CrownCurr + "' and  Printpdf_Lang='" + Lang + "'  and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' union select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='' and Printpdf_Fina_Curr= '" + P1Finacurrency + "' and  Printpdf_Lang='" + Lang + "'  and  Printpdf_FracMem='" + P1resort + "' and Printpdf_Cool='" + coolonoff + "' ", con))
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











    [System.Web.Services.WebMethod]
    public static string DeleteInvoiceOnEdit()
    {
        //return "Hello "+name;
        string p1,p2;
        p1 = HttpContext.Current.Session["ProfileIDo"].ToString();
        p2 = HttpContext.Current.Session["fracido"].ToString();
        int delete = Queries2.DeleteInvoiceOnEdit(p1,p2);
        //mcval = Queries2.loadmcharge(id, id2);
        // return mcval;

        return p1;


    }



    public class FlyTeleType
    {
        public string FlyTeleTypeID { get; set; }
        public string FlyTeleTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateFlyTeleDropDownList(string countid)
    {
        DataTable dt = new DataTable();
        List<FlyTeleType> listRes = new List<FlyTeleType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
            using (SqlCommand cmd = new SqlCommand("select FAgent_Name from Flybuy_Agent where country in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "') and FAgent_Status='Active'", con))
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

                        FlyTeleType objst2 = new FlyTeleType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.FlyTeleTypeName = Convert.ToString(dt.Rows[i]["FAgent_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }

    public class FlyPreArivType
    {
        public string FlyPreArivTypeID { get; set; }
        public string FlyPreArivTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateFlyPreArivDropDownList(string countid)
    {
        DataTable dt = new DataTable();
        List<FlyPreArivType> listRes = new List<FlyPreArivType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
            using (SqlCommand cmd = new SqlCommand("select Pre_Arrival_Name from Flybuy_Pre_Arrival where country in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "') and Pre_Arrival_Status='Active'", con))
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

                        FlyPreArivType objst2 = new FlyPreArivType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.FlyPreArivTypeName = Convert.ToString(dt.Rows[i]["Pre_Arrival_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class FlyVerifiType
    {
        public string FlyVerifiTypeID { get; set; }
        public string FlyVerifiTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateFlyVerifiDropDownList(string countid)
    {
        DataTable dt = new DataTable();
        List<FlyVerifiType> listRes = new List<FlyVerifiType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
            using (SqlCommand cmd = new SqlCommand("select Verification_Name from Flybuy_Verification where country in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "') and Verification_Status='Active'", con))
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

                        FlyVerifiType objst2 = new FlyVerifiType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.FlyVerifiTypeName = Convert.ToString(dt.Rows[i]["Verification_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    protected void Button6_Click(object sender, EventArgs e)
    {

        try
        {
            string pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3mobile, sp3alternate, sp4mobile, sp4alternate, sp3cc, sp3altcc, sp4cc, sp4altcc, homecc, officecc, homenum, officenum;
            string pemail, semail, sp1email, sp2email, pemail2, semail2, sp1email2, sp2email2, sp3email, sp3email2, sp4email, sp4email2;
            string venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, membertype2, employmentstatus, Secondemploymentstatus, maritalstatus, primarytitle, primarynationality, leadsource, prearrival, verifi, comm1, promosource = "", teleagent = "";
            string primarycountry, secondarytitle, secondarynationality, secondarycountry, sp1title, sp1nationality, sp1country, sp2title, sp2nationality, sp2country, sp3title, sp4title;
            string gueststatus, salesrep, gift_option;
            string reception, subvenue;

            string primaryidtype, secondaryidtype, sp1idtype, sp2idtype, sp3idtype, sp4idtype;
            string primaryidnum, secondaryidnum, sp1idnum, sp2idnum, sp3idnum, sp4idnum;

            string profile = ProfileIDTextBox.Text;
            string createdby = CreatedByTextBox.Text;

            string VPID = TextVPID.Text;



            /* DataSet ds = Queries2.LoadProfielDetailsFull(ProfileIDTextBox.Text);
             oProfile_Venue_Country = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
             oProfile_Venue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
             oProfile_Group_Venue = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
             oProfile_Marketing_Program = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
             oProfile_Agent = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
             oProfile_Agent_Code = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
             oProfile_Member_Type1 = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
             oProfile_Member_Number1 = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
             oProfile_Member_Type2 = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
             oProfile_Member_Number2 = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
             oProfile_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
             oSecond_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
             oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
             oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
             oreception = ds.Tables[0].Rows[0]["Reception"].ToString();
             oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
             oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
             oManager = ds.Tables[0].Rows[0]["Manager"].ToString();

             oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
             oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
             oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
             oProfile_Primary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
             oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
             oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();

             oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
             oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
             oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
             oProfile_Secondary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
             oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
             oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();

             oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
             oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
             oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
             oSub_Profile1_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
             oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
             oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();

             oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
             oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
             oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
             oSub_Profile2_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
             oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
             oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();


             oSub_Profile3_Title = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
             oSub_Profile3_Fname = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
             if (oSub_Profile3_Fname != "")
             {
                 oSub_Profile3_Lname = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
                 oSub_Profile3_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
                 oSub_Profile3_Nationality = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
                 oSub_Profile3_Country = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
                 oSubprofile3_CC = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
                 oSubprofile3_Mobile = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
                 oSubprofile3_Alt_CC = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
                 oSubprofile3_Alternate = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();

             }

             oSub_Profile4_Title = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
             oSub_Profile4_Fname = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
             if (oSub_Profile4_Fname != "")
             {
                 oSub_Profile4_Lname = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
                 oSub_Profile4_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
                 oSub_Profile4_Nationality = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
                 oSub_Profile4_Country = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
                 oSubprofile4_CC = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
                 oSubprofile4_Mobile = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
                 oSubprofile4_Alt_CC = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
                 oSubprofile4_Alternate = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
             }

             oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
             oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
             oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
             oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
             oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
             oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
             oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();

             oPrimary_CC = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
             oPrimary_Mobile = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
             oPrimary_Alt_CC = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
             oPrimary_Alternate = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
             oSecondary_CC = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
             oSecondary_Mobile = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
             oSecondary_Alt_CC = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
             oSecondary_Alternate = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
             oSubprofile1_CC = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
             oSubprofile1_Mobile = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
             oSubprofile1_Alt_CC = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
             oSubprofile1_Alternate = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
             oSubprofile2_CC = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
             oSubprofile2_Mobile = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
             oSubprofile2_Alt_CC = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
             oSubprofile2_Alternate = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
             oofficec= ds.Tables[0].Rows[0]["Primary_office_cc"].ToString();
             oofficenum= ds.Tables[0].Rows[0]["Primary_office_num"].ToString();
             ohomec = ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString();
             ohomenum = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();



             oPrimary_Email = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
             oSecondary_Email = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
             oSubprofile1_Email = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
             oSubprofile2_Email = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
             oPrimary_Email2 = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
             oSecondary_Email2 = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
             oSubprofile1_Email2 = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
             oSubprofile2_Email2 = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();

             oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
             oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
             oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
             oProfile_Stay_Arrival_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
             oProfile_Stay_Departure_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

             oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
             oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
             oTour_Details_Tour_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
             oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
             oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
             oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
             oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
             oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
             oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();*/


            //-------- session variables for profilem details ------------//
            Session["office"] = "";
            Session["oProfile_Venue_Country"] = ""; Session["oProfile_Venue"] = ""; Session["oProfile_Group_Venue"] = "";
            Session["oProfile_Marketing_Program"] = ""; Session["oAgent_marketingSource"] = ""; Session["oToName_sourceCode"] = "";
            Session["oToManager"] = ""; Session["oPromoSource"] = ""; Session["oTeleMarktAgent"] = ""; Session["oPreArrival"] = "";
            Session["oVerification"] = ""; Session["oGuestRelations"] = ""; Session["oProfile_Sub_Venue"] = "";
            Session["oProfile_Reception"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            //-------- session variables for primary  profile details ------------//
            Session["oProfile_Primary_Title"] = ""; Session["oProfile_Primary_Fname"] = ""; Session["oProfile_Primary_Lname"] = "";
            Session["oProfile_Primary_DOB"] = ""; Session["oProfile_Primary_Nationality"] = ""; Session["oProfile_Primary_Country"] = "";
            Session["oPrimary_Designation"] = ""; Session["oPrimary_Language"] = ""; Session["oPrimary_Age"] = "";

            Session["oPrimary_CC"] = ""; Session["oPrimary_Mobile"] = ""; Session["oPrimary_Alt_CC"] = ""; Session["oPrimary_Alternate"] = "";
            Session["oPrimary_Home_CC"] = ""; Session["oPrimary_Home"] = ""; Session["oPrimary_Office_CC"] = ""; Session["oPrimary_Office"] = "";
            Session["oPrimary_Email"] = ""; Session["oPrimary_Email2"] = ""; Session["oPrimary_ID_Type"] = ""; Session["oPrimary_ID_Num"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//

            //-------- session variables for Secondary profile details ------------//
            Session["oProfile_Secondary_Title"] = ""; Session["oProfile_Secondary_Fname"] = ""; Session["oProfile_Secondary_Lname"] = "";
            Session["oProfile_Secondary_DOB"] = ""; Session["oProfile_Secondary_Nationality"] = ""; Session["oProfile_Secondary_Country"] = "";
            Session["oSecondary_Age"] = ""; Session["oSecondary_Designation"] = ""; Session["oSecondary_Language"] = "";

            Session["oSecondary_CC"] = ""; Session["oSecondary_Mobile"] = ""; Session["oSecondary_Alt_CC"] = ""; Session["oSecondary_Alternate"] = "";
            Session["oSecondary_Home_CC"] = ""; Session["oSecondary_Home"] = ""; Session["oSecondary_Office_CC"] = ""; Session["oSecondary_Office"] = "";
            Session["oSecondary_Email"] = ""; Session["oSecondary_Email2"] = ""; Session["oSecondary_ID_Type"] = ""; Session["oSecondary_ID_Num"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//

            //-------- session variables for Sub profile 1 profile details ------------//
            Session["oSub_Profile1_Title"] = ""; Session["oSub_Profile1_Fname"] = ""; Session["oSub_Profile1_Lname"] = "";
            Session["oSub_Profile1_DOB"] = ""; Session["oSub_Profile1_Nationality"] = ""; Session["oSub_Profile1_Country"] = "";
            Session["oSub_Profile1_Age"] = "";

            Session["oSubprofile1_CC"] = ""; Session["oSubprofile1_Mobile"] = ""; Session["oSubprofile1_Alt_CC"] = ""; Session["oSubprofile1_Alternate"] = "";
            Session["oSubprofile1_Email"] = ""; Session["oSubprofile1_Email2"] = ""; Session["oSubprofile1_ID_Type"] = ""; Session["oSubprofile1_ID_Num"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//

            //-------- session variables for Sub profile 2 profile details ------------//
            Session["oSub_Profile2_Title"] = ""; Session["oSub_Profile2_Fname"] = ""; Session["oSub_Profile2_Lname"] = "";
            Session["oSub_Profile2_DOB"] = ""; Session["oSub_Profile2_Nationality"] = ""; Session["oSub_Profile2_Country"] = "";
            Session["oSub_Profile2_Age"] = "";

            Session["oSubprofile2_CC"] = ""; Session["oSubprofile2_Mobile"] = ""; Session["oSubprofile2_Alt_CC"] = ""; Session["oSubprofile2_Alternate"] = "";
            Session["oSubprofile2_Email"] = ""; Session["oSubprofile2_Email2"] = ""; Session["oSubprofile2_ID_Type"] = ""; Session["oSubprofile2_ID_Num"] = "";
            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            //-------- session variables for Sub profile 3 profile details ------------//
            Session["oSub_Profile3_Title"] = ""; Session["oSub_Profile3_Fname"] = ""; Session["oSub_Profile3_Lname"] = "";
            Session["oSub_Profile3_DOB"] = ""; Session["oSub_Profile3_Nationality"] = ""; Session["oSub_Profile3_Country"] = "";
            Session["oSub_Profile3_Age"] = "";

            Session["oSubprofile3_CC"] = ""; Session["oSubprofile3_Mobile"] = ""; Session["oSubprofile3_Alt_CC"] = "";
            Session["oSubprofile3_Alternate"] = "";
            Session["oSubprofile3_Email"] = ""; Session["oSubprofile3_Email2"] = ""; Session["oSubprofile3_ID_Type"] = ""; Session["oSubprofile3_ID_Num"] = "";
            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            //-------- session variables for Sub profile 4 profile details ------------//
            Session["oSub_Profile4_Title"] = ""; Session["oSub_Profile4_Fname"] = ""; Session["oSub_Profile4_Lname"] = "";
            Session["oSub_Profile4_DOB"] = ""; Session["oSub_Profile4_Nationality"] = ""; Session["oSub_Profile4_Country"] = "";
            Session["oSub_Profile4_Age"] = "";
            Session["oSubprofile4_CC"] = ""; Session["oSubprofile4_Mobile"] = ""; Session["oSubprofile4_Alt_CC"] = "";
            Session["oSubprofile4_Alternate"] = "";
            Session["oSubprofile4_Email"] = ""; Session["oSubprofile4_Email2"] = ""; Session["oSubprofile4_ID_Type"] = ""; Session["oSubprofile4_ID_Num"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//

            //-------- session variables for Address details ------------//

            Session["oProfile_Address_Line1"] = ""; Session["oProfile_Address_Line2"] = ""; Session["oSecond_Employment_status"] = "";
            Session["oProfile_Address_State"] = ""; Session["oProfile_Address_city"] = ""; Session["oProfile_Address_Postcode"] = "";
            Session["oProfile_Employment_status"] = ""; Session["oProfile_Marital_status"] = ""; Session["oProfile_NOY_Living_as_couple"] = "";

            Session["oProfile_Photo_Identity"] = ""; Session["oProfile_Card"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            //-------- session variables for Stay details ------------//
            Session["oResort_Name"] = ""; Session["oResort_RoomNo"] = ""; Session["oArrival_Date"] = ""; Session["oDepature_Date"] = "";

            Session["oGuest_Status"] = ""; Session["oSales_Rep"] = ""; Session["oTour_Date"] = ""; Session["oCheck_In_Time"] = "";
            Session["oCheck_Out_Time"] = ""; Session["oTaxi_In_Price"] = ""; Session["oTaxi_Out_Price"] = ""; Session["oTaxi_In_Ref"] = "";
            Session["oTaxi_Out_Ref"] = ""; Session["oQstatus"] = ""; Session["oWeekNo"] = ""; Session["oComments"] = ""; Session["oComments2"] = "";
            Session["oRegTerms"] = ""; Session["oRegTerms2"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            // --------------------------- profile details --------------------------------//
            DataSet ds = Queries3.LoadProfielDetailsFull(ProfileIDTextBox.Text);
            Session["office"] = ds.Tables[0].Rows[0]["Office"].ToString();
            Session["oProfile_Venue_Country"] = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
            Session["oProfile_Venue"] = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
            Session["oProfile_Group_Venue"] = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
            Session["oProfile_Sub_Venue"] = ds.Tables[0].Rows[0]["SubVenue"].ToString();
            Session["oProfile_Marketing_Program"] = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
            Session["oAgent_marketingSource"] = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
            Session["oToName_sourceCode"] = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
            Session["oToManager"] = ds.Tables[0].Rows[0]["Manager"].ToString();

            Session["oPromoSource"] = ds.Tables[0].Rows[0]["Promo_Source"].ToString();
            Session["oTeleMarktAgent"] = ds.Tables[0].Rows[0]["Tele_Agent"].ToString();
            Session["oPreArrival"] = ds.Tables[0].Rows[0]["Pre_Arrival"].ToString();
            Session["oVerification"] = ds.Tables[0].Rows[0]["Verification"].ToString();
            Session["oGuestRelations"] = ds.Tables[0].Rows[0]["Lead_Source"].ToString();
            Session["oProfile_Reception"] = ds.Tables[0].Rows[0]["Reception"].ToString();
            //-----------------------------------XXXXXXXXX-------------------------------------//


            //--------------------------------------profile primary -----------------------------//
            Session["oProfile_Primary_Title"] = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
            Session["oProfile_Primary_Fname"] = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            Session["oProfile_Primary_Lname"] = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            Session["oProfile_Primary_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oPrimary_Age"] = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            Session["oProfile_Primary_Nationality"] = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
            Session["oProfile_Primary_Country"] = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();

            Session["oPrimary_Designation"] = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
            Session["oPrimary_Language"] = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

            Session["oPrimary_CC"] = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
            Session["oPrimary_Mobile"] = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            Session["oPrimary_Alt_CC"] = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
            Session["oPrimary_Alternate"] = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();

            Session["oPrimary_Home_CC"] = ds.Tables[0].Rows[0]["Primary_home_CC"].ToString();
            Session["oPrimary_Home"] = ds.Tables[0].Rows[0]["Primary_home_num"].ToString();

            Session["oPrimary_Office_CC"] = ds.Tables[0].Rows[0]["Primary_office_CC"].ToString();
            Session["oPrimary_Office"] = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();

            Session["oPrimary_Email"] = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            Session["oPrimary_Email2"] = ds.Tables[0].Rows[0]["Primary_Email2"].ToString();

            Session["oPrimary_ID_Type"] = ds.Tables[0].Rows[0]["Primary_ID_Type"].ToString();
            Session["oPrimary_ID_Num"] = ds.Tables[0].Rows[0]["Primary_ID_Num"].ToString();

            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile Secondary -----------------------------//
            Session["oProfile_Secondary_Title"] = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            Session["oProfile_Secondary_Fname"] = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            Session["oProfile_Secondary_Lname"] = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            Session["oProfile_Secondary_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSecondary_Age"] = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            Session["oProfile_Secondary_Nationality"] = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            Session["oProfile_Secondary_Country"] = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();

            Session["oSecondary_Designation"] = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
            Session["oSecondary_Language"] = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

            Session["oSecondary_CC"] = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
            Session["oSecondary_Mobile"] = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            Session["oSecondary_Alt_CC"] = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
            Session["oSecondary_Alternate"] = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();

            Session["oSecondary_Home_CC"] = ds.Tables[0].Rows[0]["Secondary_home_CC"].ToString();
            Session["oSecondary_Home"] = ds.Tables[0].Rows[0]["Secondary_home_num"].ToString();

            Session["oSecondary_Office_CC"] = ds.Tables[0].Rows[0]["Secondary_office_CC"].ToString();
            Session["oSecondary_Office"] = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();

            Session["oSecondary_Email"] = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            Session["oSecondary_Email2"] = ds.Tables[0].Rows[0]["Secondary_Email2"].ToString();

            Session["oSecondary_ID_Type"] = ds.Tables[0].Rows[0]["Secondary_ID_Type"].ToString();
            Session["oSecondary_ID_Num"] = ds.Tables[0].Rows[0]["Secondary_ID_Num"].ToString();
            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile Sub 1 -----------------------------//

            Session["oSub_Profile1_Title"] = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            Session["oSub_Profile1_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            Session["oSub_Profile1_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            Session["oSub_Profile1_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);//Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile1_Age"] = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

            Session["oSub_Profile1_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            Session["oSub_Profile1_Country"] = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();



            Session["oSubprofile1_CC"] = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
            Session["oSubprofile1_Mobile"] = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            Session["oSubprofile1_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
            Session["oSubprofile1_Alternate"] = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();

            Session["oSubprofile1_Email"] = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            Session["oSubprofile1_Email2"] = ds.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();

            Session["oSubprofile1_ID_Type"] = ds.Tables[0].Rows[0]["SP1_ID_Type"].ToString();
            Session["oSubprofile1_ID_Num"] = ds.Tables[0].Rows[0]["SP1_ID_Num"].ToString();
            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile Sub 2 -----------------------------//
            Session["oSub_Profile2_Title"] = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            Session["oSub_Profile2_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            Session["oSub_Profile2_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            Session["oSub_Profile2_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile2_Age"] = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();
            Session["oSub_Profile2_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            Session["oSub_Profile2_Country"] = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();

            Session["oSubprofile2_CC"] = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
            Session["oSubprofile2_Mobile"] = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            Session["oSubprofile2_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
            Session["oSubprofile2_Alternate"] = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();

            Session["oSubprofile2_Email"] = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            Session["oSubprofile2_Email2"] = ds.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();


            Session["oSubprofile2_ID_Type"] = ds.Tables[0].Rows[0]["SP2_ID_Type"].ToString();
            Session["oSubprofile2_ID_Num"] = ds.Tables[0].Rows[0]["SP2_ID_Num"].ToString();

            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile Sub 3 -----------------------------//

            Session["oSub_Profile3_Title"] = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
            Session["oSub_Profile3_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();

            Session["oSub_Profile3_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
            Session["oSub_Profile3_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]);  //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile3_Age"] = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();
            Session["oSub_Profile3_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
            Session["oSub_Profile3_Country"] = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();

            Session["oSubprofile3_CC"] = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
            Session["oSubprofile3_Mobile"] = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
            Session["oSubprofile3_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
            Session["oSubprofile3_Alternate"] = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();

            Session["oSubprofile3_Email"] = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
            Session["oSubprofile3_Email2"] = ds.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();

            Session["oSubprofile2_ID_Type"] = ds.Tables[0].Rows[0]["SP2_ID_Type"].ToString();
            Session["oSubprofile2_ID_Num"] = ds.Tables[0].Rows[0]["SP2_ID_Num"].ToString();
            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//



            //--------------------------------------profile Sub 4 -----------------------------//
            Session["oSub_Profile4_Title"] = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
            Session["oSub_Profile4_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();

            Session["oSub_Profile4_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
            Session["oSub_Profile4_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile4_Age"] = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();
            Session["oSub_Profile4_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
            Session["oSub_Profile4_Country"] = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();

            Session["oSubprofile4_CC"] = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
            Session["oSubprofile4_Mobile"] = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
            Session["oSubprofile4_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
            Session["oSubprofile4_Alternate"] = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();

            Session["oSubprofile4_Email"] = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();
            Session["oSubprofile4_Email2"] = ds.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();

            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//


            //--------------------------------------profile Address details-----------------------------//
            Session["oProfile_Address_Line1"] = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            Session["oProfile_Address_Line2"] = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            Session["oProfile_Address_Country"] = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();
            Session["oProfile_Address_State"] = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            Session["oProfile_Address_city"] = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            Session["oProfile_Address_Postcode"] = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            Session["oProfile_Employment_status"] = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            Session["oSecond_Employment_status"] = ds.Tables[0].Rows[0]["Secondary_Employment_Status"].ToString();
            Session["oProfile_Marital_status"] = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            Session["oProfile_NOY_Living_as_couple"] = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

            Session["oProfile_Photo_Identity"] = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
            Session["oProfile_Card"] = ds.Tables[0].Rows[0]["Card_Holder"].ToString();

            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile stay details-----------------------------//

            Session["oResort_Name"] = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            Session["oResort_RoomNo"] = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            Session["oArrival_Date"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString();
            Session["oDepature_Date"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]); //ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();

            Session["oGuest_Status"] = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
            Session["oSales_Rep"] = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
            Session["oTour_Date"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]); //ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString();
            Session["oCheck_In_Time"] = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            Session["oCheck_Out_Time"] = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            Session["oTaxi_In_Price"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            Session["oTaxi_Out_Price"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            Session["oTaxi_In_Ref"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            Session["oTaxi_Out_Ref"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
            Session["oQstatus"] = ds.Tables[0].Rows[0]["Tour_Details_Qualified_Status"].ToString();
            Session["oWeekNo"] = ds.Tables[0].Rows[0]["Week_number"].ToString();
            Session["oComments"] = ds.Tables[0].Rows[0]["Comments"].ToString();
            Session["oComments2"] = ds.Tables[0].Rows[0]["comment2"].ToString();
            Session["oRegTerms"] = ds.Tables[0].Rows[0]["RegTerms"].ToString();
            Session["oRegTerms2"] = ds.Tables[0].Rows[0]["RegTerms2"].ToString();
            Session["otourStartTime"] = ds.Tables[0].Rows[0]["Tour_Start_Time"].ToString();
            Session["otourEndTime"] = ds.Tables[0].Rows[0]["Tour_End_Time"].ToString();

            // --------------------------------------XXXXXXXXXXXXXXX--------------------------//



            /* string[] ar = new string[10];
             string[] br = new string[10];
             string[] cr = new string[10];


             int i = 0;
             SqlDataReader reader = Queries2.getgiftoption(ProfileIDTextBox.Text);
             while (reader.Read())
             {

                 ar[i] = reader.GetString(0);
                 br[i] = reader.GetString(1);
                 cr[i] = reader.GetString(3);


                 //string id = "giftoptionDropDownList";

                 i++;

             }

             if (string.IsNullOrEmpty(ar[0]) == false)
             //if (ar[0] != "" || ar[0] != null)
             {
                 //DataSet dsgift1 = Queries2.LoadGiftOption(ProfileIDTextBox.Text);
                 //giftoptionDropDownList.DataSource = dsgift1;
                 //giftoptionDropDownList.DataTextField = "item";
                 //giftoptionDropDownList.DataValueField = "item";
                 //giftoptionDropDownList.AppendDataBoundItems = true;

                 //giftoptionDropDownList.DataBind();
                 //giftoptionDropDownList.Items.Insert(0, new ListItem(ar[0]));

                 //vouchernoTextBox.Text = br[0];

                 ogiftoptionDropDownList = ar[0];
                 ovouchernoTextBox = br[0];
                 ogiftprice1 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[0]));//cr[0];


             }


             if (string.IsNullOrEmpty(ar[1]) == false)
             //if (ar[1] != "" || ar[1] != null)
             {
                 //DataSet dsgift2 = Queries2.LoadGiftOption(office);
                 //giftoptionDropDownList2.DataSource = dsgift2;
                 //giftoptionDropDownList2.DataTextField = "item";
                 //giftoptionDropDownList2.DataValueField = "item";
                 //giftoptionDropDownList2.AppendDataBoundItems = true;

                 //giftoptionDropDownList2.DataBind();
                 //giftoptionDropDownList2.Items.Insert(0, new ListItem(ar[1]));

                 //vouchernoTextBox2.Text = br[1];
                 ogiftoptionDropDownList2 = ar[1];
                 ovouchernoTextBox2 = br[1];
                 ogiftprice2 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[1]));//cr[1];
             }

             if (string.IsNullOrEmpty(ar[2]) == false)
             //if (ar[2] != "" || ar[2] != null)
             {
                 //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                 //giftoptionDropDownList3.DataSource = dsgift3;
                 //giftoptionDropDownList3.DataTextField = "item";
                 //giftoptionDropDownList3.DataValueField = "item";
                 //giftoptionDropDownList3.AppendDataBoundItems = true;

                 //giftoptionDropDownList3.DataBind();
                 //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                 //vouchernoTextBox3.Text = br[2];
                 ogiftoptionDropDownList3 = ar[2];
                 ovouchernoTextBox3 = br[2];
                 ogiftprice3 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[2])); //cr[2];
             }

             if (string.IsNullOrEmpty(ar[3]) == false)
             //if (ar[3] != "" || ar[3] != null)
             {
                 //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                 //giftoptionDropDownList3.DataSource = dsgift3;
                 //giftoptionDropDownList3.DataTextField = "item";
                 //giftoptionDropDownList3.DataValueField = "item";
                 //giftoptionDropDownList3.AppendDataBoundItems = true;

                 //giftoptionDropDownList3.DataBind();
                 //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                 //vouchernoTextBox3.Text = br[2];
                 ogiftoptionDropDownList4 = ar[3];
                 ovouchernoTextBox4 = br[3];
                 ogiftprice4 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[3]));//cr[3];
             }


             if (string.IsNullOrEmpty(ar[4]) == false)
             //if (ar[4] != "" || ar[4] != null)
             {
                 //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                 //giftoptionDropDownList3.DataSource = dsgift3;
                 //giftoptionDropDownList3.DataTextField = "item";
                 //giftoptionDropDownList3.DataValueField = "item";
                 //giftoptionDropDownList3.AppendDataBoundItems = true;

                 //giftoptionDropDownList3.DataBind();
                 //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                 //vouchernoTextBox3.Text = br[2];
                 ogiftoptionDropDownList5 = ar[4];
                 ovouchernoTextBox5 = br[4];
                 ogiftprice5 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[4]));//cr[4];
             }


             if (string.IsNullOrEmpty(ar[5]) == false)
             //if (ar[5] != "" || ar[5] != null)
             {
                 //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                 //giftoptionDropDownList3.DataSource = dsgift3;
                 //giftoptionDropDownList3.DataTextField = "item";
                 //giftoptionDropDownList3.DataValueField = "item";
                 //giftoptionDropDownList3.AppendDataBoundItems = true;

                 //giftoptionDropDownList3.DataBind();
                 //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                 //vouchernoTextBox3.Text = br[2];
                 ogiftoptionDropDownList6 = ar[5];
                 ovouchernoTextBox6 = br[5];
                 ogiftprice6 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[5]));//cr[5];
             }


             if (string.IsNullOrEmpty(ar[6]) == false)
             //if (ar[6] != "" || ar[6] != null)
             {
                 //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                 //giftoptionDropDownList3.DataSource = dsgift3;
                 //giftoptionDropDownList3.DataTextField = "item";
                 //giftoptionDropDownList3.DataValueField = "item";
                 //giftoptionDropDownList3.AppendDataBoundItems = true;

                 //giftoptionDropDownList3.DataBind();
                 //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                 //vouchernoTextBox3.Text = br[2];
                 ogiftoptionDropDownList7 = ar[6];
                 ovouchernoTextBox7 = br[6];
                 ogiftprice7 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[6]));//cr[6];
             }*/






            if (VenueCountryDropDownList.SelectedItem.Text == "")
            {
                venuecountry = "";
            }
            else
            {
                venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            }

            if (ReceptionistDropDownList.SelectedItem.Text == "")
            {
                reception = "";
            }
            else
            {
                reception = ReceptionistDropDownList.SelectedItem.Text;
            }

            if (VenueDropDownList.SelectedItem.Text == "")
            {
                venue = "";
            }
            else
            {
                venue = VenueDropDownList.SelectedItem.Text;
            }


            //venue = Request.Form[VenueDropDownList.UniqueID];
            venuegroup = Request.Form[GroupVenueDropDownList.UniqueID];
            mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];

            comm1 = commentTextBox.Text;


            //if (venue == "Flybuys")
            if (venuegroup == "Flybuy")

            {

                agents = Request.Form[AgentsDropDownList.UniqueID]; //Request.Form[AgentsDropDownList.UniqueID];
                agentcode = Request.Form[AgentCodeDropDownList.UniqueID];//Request.Form[AgentCodeDropDownList.UniqueID];
                promosource = OfficeSourceTextBox.Text;//OfficeSourceDropDownList.SelectedItem.Text;
                teleagent = FAgentDropDownList.SelectedItem.Text;
                leadsource = DropDownListFly.SelectedItem.Text;
                prearrival = PreArrivalDropDownList.SelectedItem.Text;
                verifi = VerificationDropDownList.SelectedItem.Text;
            }
            else if (venuegroup == "Coldline" || venuegroup == "COLDLINE")
            {
                agents = Request.Form[AgentsDropDownList.UniqueID];
                agentcode = sourcecodetext.Text;//Request.Form[AgentCodeDropDownList.UniqueID];
                teleagent = "";
                promosource = "";
                leadsource = "";
                prearrival = "";
                verifi = "";
            }
            else
            {
                agents = Request.Form[AgentsDropDownList.UniqueID];
                agentcode = Request.Form[AgentCodeDropDownList.UniqueID];
                teleagent = "";
                promosource = "";
                leadsource = "";
                prearrival = "";
                verifi = "";
            }




            //agents = Request.Form[AgentsDropDownList.UniqueID];
            //agentcode = Request.Form[AgentCodeDropDownList.UniqueID];
            // subvenue = Request.Form[VenueDropDownList2.UniqueID];

            if (VenueDropDownList2.SelectedItem.Text == "")
            {
                subvenue = "";
            }
            else
            {
                subvenue = VenueDropDownList2.SelectedItem.Text;
            }





            //member details
            if (MemType1DropDownList.SelectedItem.Text == "")
            {
                membertype1 = "";
            }
            else
            {
                membertype1 = MemType1DropDownList.SelectedItem.Text;
            }

            if (MemType2DropDownList.SelectedItem.Text == "")
            {
                membertype2 = "";
            }
            else
            {
                membertype2 = MemType2DropDownList.SelectedItem.Text;
            }
            //string agentcode = AgentCodeDropDownList.SelectedItem.Text;


            string memno1 = Memno1TextBox.Text;

            string memno2 = Memno2TextBox.Text;

            //other details

            if (employmentstatusDropDownList.SelectedItem.Text == "")
            {
                employmentstatus = "";
            }
            else
            {
                employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
            }


            if (SecondemploymentstatusDropDownList.SelectedItem.Text == "")
            {
                Secondemploymentstatus = "";
            }
            else
            {
                Secondemploymentstatus = SecondemploymentstatusDropDownList.SelectedItem.Text;
            }


            if (MaritalStatusDropDownList.SelectedItem.Text == "")
            {
                maritalstatus = "";
            }
            else
            {
                maritalstatus = MaritalStatusDropDownList.SelectedItem.Text;
            }

            string livingyrs = livingyrsTextBox.Text;


            if (Regterms1.Checked)
            {


                regTerms = "Y";
            }
            else
            {
                regTerms = "N";

            }

            if (Regterms2.Checked)
            {


                regTerms2 = "Y";
            }
            else
            {
                regTerms2 = "N";

            }

            primaryidtype = TextBoxPrimIDType.Text.ToUpper();
            primaryidnum = TextBoxPrimID.Text;
            secondaryidtype = TextBoxSecoIDType.Text.ToUpper();
            secondaryidnum = TextBoxSecoID.Text;
            sp1idtype = TextBoxSP1IDType.Text.ToUpper();
            sp1idnum = TextBoxSP1ID.Text;
            sp2idtype = TextBoxSP2IDType.Text.ToUpper();
            sp2idnum = TextBoxSP2ID.Text;
            sp3idtype = TextBoxSP3IDType.Text.ToUpper();
            sp3idnum = TextBoxSP3ID.Text;
            sp4idtype = TextBoxSP4IDType.Text.ToUpper();
            sp4idnum = TextBoxSP4ID.Text;

            int updateID_Card = Queries2.UpdateIDCard(ProfileIDTextBox.Text, primaryidtype, primaryidnum, secondaryidtype, secondaryidnum, sp1idtype, sp1idnum, sp2idtype, sp2idnum, sp3idtype, sp3idnum, sp4idtype, sp4idnum);



            int updateprofile = Queries2.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, "", "", "", comm1, reception, subvenue, regTerms, VPID, regTerms2, Secondemploymentstatus, leadsource, prearrival, verifi, promosource, teleagent);


            //primary profile

            if (primarytitleDropDownList.SelectedItem.Text == "")
            {
                primarytitle = "";
            }
            else
            {
                primarytitle = primarytitleDropDownList.SelectedItem.Text;
            }


            string primaryfname = pfnameTextBox.Text;
            string primaylname = plnameTextBox.Text;
            string primarydob = datepicker1.Text;
            string primaryage = TextPrimaryAge.Text;
            string tprimarydob;
            if (primarydob == "")
            {
                tprimarydob = "1900-01-01";
            }
            else
            {
                tprimarydob = primarydob;// Convert.ToDateTime(primarydob).ToString("yyyy-MM-dd");
            }


            if (primarynationalityDropDownList.SelectedItem.Text == "")
            {
                primarynationality = "";
            }
            else
            {
                primarynationality = primarynationalityDropDownList.SelectedItem.Text;
            }

            //if (PrimaryCountryDropDownList.SelectedItem.Text == "")
            //{
            //    primarycountry = "";
            //}
            //else
            //{
            //    primarycountry = PrimaryCountryDropDownList.SelectedItem.Text;
            //}
            primarycountry = Request.Form[PrimaryCountryDropDownList.UniqueID];
            int primary = Queries2.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, tprimarydob, primarynationality, primarycountry, primaryage, "", "");

            //Secondary Profile

            if (secondarytitleDropDownList.SelectedItem.Text == "")
            {
                secondarytitle = "";
            }
            else
            {
                secondarytitle = secondarytitleDropDownList.SelectedItem.Text;
            }



            string secondaryfname = sfnameTextBox.Text;
            string secondarylname = slnameTextBox.Text;
            string secondarydob = datepicker2.Text;
            string secondaryage = TextSecondAge.Text;
            string tsecondarydob;
            if (secondarydob == "")
            {
                tsecondarydob = "1900-01-01";
            }
            else
            {
                tsecondarydob = secondarydob;// Convert.ToDateTime(secondarydob).ToString("yyyy-MM-dd");
            }

            if (secondarynationalityDropDownList.SelectedItem.Text == "")
            {
                secondarynationality = "";
            }
            else
            {
                secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
            }

            //if (SecondaryCountryDropDownList.SelectedItem.Text == "")
            //{
            //    secondarycountry = "";
            //}
            //else
            //{
            //    secondarycountry = SecondaryCountryDropDownList.SelectedItem.Text;
            //}

            secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID];

            int secondary1 = Queries2.checksubprofile("secondary", profile);

            if (CheckBoxDeleSecondProfile.Checked == true)
            {
                int deletesecond = Queries2.DeleteSecondaryProfile(ProfileIDTextBox.Text);

            }
            else
            {
                if (secondaryfname != "")
                {
                    if (secondary1 == 0)
                    {
                        int year = DateTime.Now.Year;
                        string secondaryprofileid = Queries.GetSecondaryProfileID(Session["GlobOffice"].ToString());
                        int secondary = Queries2.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, ProfileIDTextBox.Text, secondaryage, "", "");
                        string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Profile Secondary Age:" + secondaryage;
                        int insertlog3 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log3, "ProfileSecondary", user, DateTime.Now);
                        int updates = Queries.UpdateSecondaryValue(Session["GlobOffice"].ToString(), year);
                    }

                    else
                    {
                        int secondary = Queries2.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, secondaryage, "", "");

                        if (String.Compare((string)Session["oProfile_Secondary_Title"], secondarytitle) != 0)
                        {
                            string act = "secondary title changed from:" + Session["oProfile_Secondary_Title"] + "To:" + secondarytitle;
                            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile Title Updated", Session["oProfile_Secondary_Title"].ToString(), secondarytitle);
                        }
                        else { }
                        if (String.Compare((string)Session["oProfile_Secondary_Fname"], secondaryfname.ToUpper()) != 0)
                        {
                            string act = "secondary fname changed from:" + Session["oProfile_Secondary_Fname"] + "To:" + secondaryfname.ToUpper();
                            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile First Name Updated", Session["oProfile_Secondary_Fname"].ToString(), secondaryfname.ToUpper());
                        }
                        else { }
                        if (String.Compare((string)Session["oProfile_Secondary_Lname"], secondarylname.ToUpper()) != 0)
                        {
                            string act = "secondary lname changed from:" + Session["oProfile_Secondary_Lname"] + "To:" + secondarylname.ToUpper();
                            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile Last Name Updated", Session["oProfile_Secondary_Lname"].ToString(), secondarylname.ToUpper());
                        }
                        else { }
                        if (String.Compare((string)Session["oProfile_Secondary_DOB"], tsecondarydob) != 0)
                        {
                            string act = "secondary dob changed from:" + Session["oProfile_Secondary_DOB"] + "To:" + tsecondarydob;
                            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile DOB Updated", Session["oProfile_Secondary_DOB"].ToString(), tsecondarydob);
                        }
                        else { }

                        if (String.Compare((string)Session["oSecondary_Age"], secondaryage) != 0)
                        {
                            string act = "secondaryage changed from:" + Session["oSecondary_Age"] + "To:" + secondaryage;
                            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile Age Updated", Session["oSecondary_Age"].ToString(), secondaryage);
                        }
                        else { }

                        if (String.Compare((string)Session["oProfile_Secondary_Nationality"], secondarynationality) != 0)
                        {
                            string act = "secondary nationality changed from:" + Session["oProfile_Secondary_Nationality"] + "To:" + secondarynationality;
                            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile Nationality Updated", Session["oProfile_Secondary_Nationality"].ToString(), secondarynationality);
                        }
                        else { }
                        if (String.Compare((string)Session["oProfile_Secondary_Country"], secondarycountry) != 0)
                        {
                            string act = "secondary country changed from:" + Session["oProfile_Secondary_Country"] + "To:" + secondarycountry;
                            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile Country Updated", Session["oProfile_Secondary_Country"].ToString(), secondarycountry);
                        }
                        else { }
                    }

                }
            }

            // int secondary = Queries2.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, secondaryage, "","");


            // subprofile1
            if (subprofile1titleDropDownList.SelectedItem.Text == "")
            {
                sp1title = "";
            }
            else
            {
                sp1title = subprofile1titleDropDownList.SelectedItem.Text;
            }

            string sp1fname = sp1fnameTextBox.Text;
            string sp1lname = sp1lnameTextBox.Text;
            string sp1dob = datepicker3.Text;
            string SubProfile1age = TextSP1Age.Text;
            string tsp1dob;
            if (sp1dob == "")
            {
                tsp1dob = "";
            }
            else
            {
                tsp1dob = sp1dob;//  Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            if (subprofile1nationalityDropDownList.SelectedItem.Text == "")
            {
                sp1nationality = "";
            }
            else
            {
                sp1nationality = subprofile1nationalityDropDownList.SelectedItem.Text;
            }

            //if (SubProfile1CountryDropDownList.SelectedItem.Text == "")
            //{
            //    sp1country = "";
            //}
            //else
            //{
            //    sp1country = SubProfile1CountryDropDownList.SelectedItem.Text;
            //}
            sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID];


            int subprofilecheck1 = Queries2.checksubprofile("SP1", profile);

            if (sp1fname != "")
            {
                if (subprofilecheck1 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile1id = Queries.GetSubProfile1ID(Session["GlobOffice"].ToString());
                    int subprofielid = Queries2.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, ProfileIDTextBox.Text, SubProfile1age);
                    string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Sub Profile 1 Age:" + SubProfile1age;
                    int insertlog5 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log5, "ProfileSubProfie1", user, DateTime.Now);
                    int updatesp2 = Queries.UpdateSubprofile1Value(Session["GlobOffice"].ToString(), year);
                }
                else
                {
                    int sp1 = Queries2.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, SubProfile1age);

                    if (String.Compare((string)Session["oSub_Profile1_Title"], sp1title) != 0)
                    {
                        string act = "subprofile1 title changed from:" + Session["oSub_Profile1_Title"] + "To:" + sp1title;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Title Updated", Session["oSub_Profile1_Title"].ToString(), sp1title);
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile1_Fname"], sp1fname.ToUpper()) != 0)
                    {
                        string act = "subprofile1 fname changed from:" + Session["oSub_Profile1_Fname"] + "To:" + sp1fname.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 First Name Updated", Session["oSub_Profile1_Fname"].ToString(), sp1fname.ToUpper());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile1_Lname"], sp1lname.ToUpper()) != 0)
                    {
                        string act = "subprofile1 lname changed from:" + Session["oSub_Profile1_Lname"] + "To:" + sp1lname.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Last Name Updated", Session["oSub_Profile1_Lname"].ToString(), sp1lname.ToUpper());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile1_DOB"], tsp1dob) != 0)
                    {
                        string act = "subprofile1 dob changed from:" + Session["oSub_Profile1_DOB"] + "To:" + tsp1dob;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 DOB Updated", Session["oSub_Profile1_DOB"].ToString(), tsp1dob);
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile1_Age"], SubProfile1age) != 0)
                    {
                        string act = "SubProfile1age changed from:" + Session["oSub_Profile1_Age"] + "To:" + SubProfile1age;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Age Updated", Session["oSub_Profile1_Age"].ToString(), SubProfile1age);
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile1_Nationality"], sp1nationality) != 0)
                    {
                        string act = "subprofile1 nationality changed from:" + Session["oSub_Profile1_Nationality"] + "To:" + sp1nationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Nationlaity Updated", Session["oSub_Profile1_Nationality"].ToString(), sp1nationality);
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile1_Country"], sp1country) != 0)
                    {
                        string act = "subprofile1 country changed from:" + Session["oSub_Profile1_Country"] + "To:" + sp1country;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Country Updated", Session["oSub_Profile1_Country"].ToString(), sp1country);
                    }
                    else { }

                }
            }


            //int sp1 = Queries2.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, SubProfile1age);

            // subprofile2
            if (subprofile2titleDropDownList.SelectedItem.Text == "")
            {
                sp2title = "";
            }
            else
            {
                sp2title = subprofile2titleDropDownList.SelectedItem.Text;
            }

            string sp2fname = sp2fnameTextBox.Text;
            string sp2lname = sp2lnameTextBox.Text;
            string sp2dob = datepicker4.Text;
            string Subprofile2 = TextSP2Age.Text;
            string tsp2dob;
            if (sp2dob == "")
            {
                tsp2dob = "";
            }
            else
            {
                tsp2dob = sp2dob;// Convert.ToDateTime(sp2dob).ToString("yyyy-MM-dd");
            }

            if (subprofile2nationalityDropDownList.SelectedItem.Text == "")
            {
                sp2nationality = "";
            }
            else
            {
                sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
            }


            //if (SubProfile2CountryDropDownList.SelectedItem.Text == "")
            //{
            //    sp2country = "";
            //}
            //else
            //{
            //    sp2country = SubProfile2CountryDropDownList.SelectedItem.Text;
            //}

            sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID];

            int subprofilecheck2 = Queries2.checksubprofile("SP2", profile);


            if (sp2fname != "")
            {
                if (subprofilecheck2 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile2id = Queries.GetSubProfile2ID(Session["GlobOffice"].ToString());
                    int subprofielid2 = Queries2.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, ProfileIDTextBox.Text, Subprofile2);
                    string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Sub Profile 2 Age:" + Subprofile2;
                    int insertlog6 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log6, "ProfileSubProfie2", user, DateTime.Now);
                    int updatesp2 = Queries.UpdateSubprofile2Value(Session["GlobOffice"].ToString(), year);
                }
                else
                {
                    int sp2 = Queries2.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, Subprofile2);

                    if (String.Compare((string)Session["oSub_Profile2_Title"], sp2title) != 0)
                    {
                        string act = "subprofile2 title changed from:" + Session["oSub_Profile2_Title"] + "To:" + sp2title;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Title Updated", Session["oSub_Profile2_Title"].ToString(), sp2title);
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile2_Fname"], sp2fname.ToUpper()) != 0)
                    {
                        string act = "subprofile2 fname changed from:" + Session["oSub_Profile2_Fname"] + "To:" + sp2fname.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 First Name Updated", Session["oSub_Profile2_Fname"].ToString(), sp2fname.ToUpper());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile2_Lname"], sp2lname.ToUpper()) != 0)
                    {
                        string act = "subprofile2 lname changed from:" + Session["oSub_Profile2_Lname"] + "To:" + sp2lname.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Last Name Updated", Session["oSub_Profile2_Lname"].ToString(), sp2lname.ToUpper());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile2_DOB"], tsp2dob) != 0)
                    {
                        string act = "subprofile2 dob changed from:" + Session["oSub_Profile2_DOB"] + "To:" + tsp2dob;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 DOB Updated", Session["oSub_Profile2_DOB"].ToString(), tsp2dob);
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile2_Age"], Subprofile2) != 0)
                    {
                        string act = "SubProfile2 age changed from:" + Session["oSub_Profile2_Age"] + "To:" + Subprofile2;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Age Updated", Session["oSub_Profile2_Age"].ToString(), Subprofile2);
                    }
                    else { }


                    if (String.Compare((string)Session["oSub_Profile2_Nationality"], sp2nationality) != 0)
                    {
                        string act = "subprofile2 nationality changed from:" + Session["oSub_Profile2_Nationality"] + "To:" + sp2nationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Nationlaity Updated", Session["oSub_Profile2_Nationality"].ToString(), sp2nationality);
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile2_Country"], sp2country) != 0)

                    {
                        string act = "subprofile2 country changed from:" + Session["oSub_Profile2_Country"] + "To:" + sp2country;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Country Updated", Session["oSub_Profile2_Country"].ToString(), sp2country);
                    }
                    else { }

                }
            }


            //int sp2 = Queries2.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, Subprofile2);


            //subprofile3


            if (SubP3TitleDropDownList.SelectedItem.Text == "")
            {
                sp3title = "";
            }
            else
            {
                sp3title = SubP3TitleDropDownList.SelectedItem.Text;
            }

            string Subprofile3 = "";

            sp3fname = SubP3FnameTextBox.Text;
            //   if (sp3fname != "")
            //  {

            sp3lname = SubP3LnameTextBox.Text;
            sp3dob = SubP3DOB.Text;
            Subprofile3 = TextSP3Age.Text;
            //string tsp3dob;
            if (sp3dob == "")
            {
                tsp3dob = "";
            }
            else
            {
                tsp3dob = sp3dob;// Convert.ToDateTime(sp3dob).ToString("yyyy-MM-dd");
            }



            if (SubP3NationalityDropDownList.SelectedItem.Text == "")
            {
                sp3nationality = "";
            }
            else
            {
                sp3nationality = SubP3NationalityDropDownList.SelectedItem.Text;
            }

            //if (SubP3CountryDropDownList.SelectedItem.Text == "")
            //{
            //    sp3country = "";
            //}
            //else
            //{
            //    sp3country = SubP3CountryDropDownList.SelectedItem.Text;
            //}
            sp3country = Request.Form[SubP3CountryDropDownList.UniqueID];

            int subprofilecheck3 = Queries2.checksubprofile("SP3", profile);
            if (sp3fname != "")
            {
                if (subprofilecheck3 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile3id = Queries.GetSubProfile3ID(Session["GlobOffice"].ToString());
                    int subprofielid3 = Queries2.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, ProfileIDTextBox.Text, Subprofile3);
                    string log11 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Age:" + Subprofile3;
                    int insertlog11 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log11, "ProfileSubProfie2", user, DateTime.Now);
                    int updatesp3 = Queries2.UpdateSubprofile3Value(Session["GlobOffice"].ToString(), year);
                }
                else
                {
                    int sp3 = Queries2.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, Subprofile3);

                    if (String.Compare((string)Session["oSub_Profile3_Title"], sp3title) != 0)
                    {
                        string act = "subprofile3 title changed from:" + Session["oSub_Profile3_Title"] + "To:" + sp3title;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Title Updated", Session["oSub_Profile3_Title"].ToString(), sp3title);
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile3_Fname"], sp3fname.ToUpper()) != 0)
                    {
                        string act = "subprofile3 fname changed from:" + Session["oSub_Profile3_Fname"] + "To:" + sp3fname.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 First Name Updated", Session["oSub_Profile3_Fname"].ToString(), sp3fname.ToUpper());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile3_Lname"], sp3lname.ToUpper()) != 0)
                    {
                        string act = "subprofile3 lname changed from:" + Session["oSub_Profile3_Lname"] + "To:" + sp3lname.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Last Name Updated", Session["oSub_Profile3_Lname"].ToString(), sp3lname.ToUpper());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile3_DOB"], tsp3dob) != 0)
                    {
                        string act = "subprofile3 dob changed from:" + Session["oSub_Profile3_DOB"] + "To:" + tsp3dob;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 DOB Updated", Session["oSub_Profile3_DOB"].ToString(), tsp3dob);
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile3_Age"], Subprofile3) != 0)

                    {
                        string act = "Subprofile3age changed from:" + Session["oSub_Profile3_Age"] + "To:" + Subprofile3;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Age Updated", Session["oSub_Profile3_Age"].ToString(), Subprofile3);
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile3_Nationality"], sp3nationality) != 0)
                    {
                        string act = "subprofile3 nationality changed from:" + Session["oSub_Profile3_Nationality"] + "To:" + sp3nationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Nationality Updated", Session["oSub_Profile3_Nationality"].ToString(), sp3nationality);
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile3_Country"], sp3country) != 0)

                    {
                        string act = "subprofile3 country changed from:" + Session["oSub_Profile3_Country"] + "To:" + sp3country;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Country Updated", Session["oSub_Profile3_Country"].ToString(), sp3country);
                    }
                    else { }



                    //int sp4 = Queries2.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, Subprofile4);


                }

            }



            //int sp3 = Queries.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, Subprofile3);
            //  }

            //subprofile4

            string Subprofile4 = "";
            if (SubP4TitleDropDownList.SelectedItem.Text == "")
            {
                sp4title = "";
            }
            else
            {
                sp4title = SubP4TitleDropDownList.SelectedItem.Text;
            }

            sp4fname = SubP4FnameTextBox.Text;
            //  if (sp4fname != "")
            //  {
            sp4lname = SubP4LnameTextBox.Text;
            sp4dob = SubP4DOB.Text;
            Subprofile4 = TextSP4Age.Text;

            if (sp4dob == "")
            {
                tsp4dob = "";
            }
            else
            {
                tsp4dob = sp4dob;// Convert.ToDateTime(sp4dob).ToString("yyyy-MM-dd"); //SubP4DOB.Text;
            }

            //string sp4nationality = Request.Form[SubP4NationalityDropDownList.UniqueID];
            //string sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];

            if (SubP4NationalityDropDownList.SelectedItem.Text == "")
            {
                sp4nationality = "";
            }
            else
            {
                sp4nationality = SubP4NationalityDropDownList.SelectedItem.Text;
            }

            //if (SubP4CountryDropDownList.SelectedItem.Text == "")
            //{
            //    sp4country = "";
            //}
            //else
            //{
            //    sp4country = SubP4CountryDropDownList.SelectedItem.Text;
            //}
            sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];
            int subprofilecheck4 = Queries2.checksubprofile("SP4", profile);
            if (sp4fname != "")
            {
                if (subprofilecheck4 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile4id = Queries.GetSubProfile4ID(Session["GlobOffice"].ToString());
                    int subprofielid4 = Queries2.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, ProfileIDTextBox.Text, Subprofile4);
                    string log12 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Age:" + Subprofile4;
                    int insertlog12 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log12, "ProfileSubProfie2", user, DateTime.Now);
                    int updatesp4 = Queries2.UpdateSubprofile4Value(Session["GlobOffice"].ToString(), year);

                }
                else
                {
                    int sp4 = Queries2.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, Subprofile4);

                    if (String.Compare((string)Session["oSub_Profile4_Title"], sp4title) != 0)
                    {
                        string act = "subprofile4 title changed from:" + Session["oSub_Profile4_Title"] + "To:" + sp4title;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Title Updated", Session["oSub_Profile4_Title"].ToString(), sp4title);
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile4_Fname"], sp4fname.ToUpper()) != 0)
                    {
                        string act = "subprofile4 fname changed from:" + Session["oSub_Profile4_Fname"] + "To:" + sp4fname.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 First Name Updated", Session["oSub_Profile4_Fname"].ToString(), sp4fname.ToUpper());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile4_Lname"], sp4lname.ToUpper()) != 0)
                    {
                        string act = "subprofile4 lname changed from:" + Session["oSub_Profile4_Lname"] + "To:" + sp4lname.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Last Name Updated", Session["oSub_Profile4_Lname"].ToString(), sp4lname.ToUpper());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile4_DOB"], tsp4dob) != 0)
                    {
                        string act = "subprofile4 dob changed from:" + Session["oSub_Profile4_DOB"] + "To:" + tsp4dob;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 DOB Updated", Session["oSub_Profile4_DOB"].ToString(), tsp4dob);
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile4_Age"], String.IsNullOrEmpty(Subprofile4) ? "" : Subprofile4) != 0)
                    {
                        string act = "Subprofile4age changed from:" + Session["oSub_Profile4_Age"] + "To:" + Subprofile4;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Age Updated", Session["oSub_Profile4_Age"].ToString(), Subprofile4);
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile4_Nationality"], sp4nationality) != 0)
                    {
                        string act = "subprofile4 nationality changed from:" + Session["oSub_Profile4_Nationality"] + "To:" + sp4nationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Nationlaity Updated", Session["oSub_Profile4_Nationality"].ToString(), sp4nationality);
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile4_Country"], sp4country) != 0)

                    {
                        string act = "subprofile4 country changed from:" + Session["oSub_Profile4_Country"] + "To:" + sp4country;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Country Updated", Session["oSub_Profile4_Country"].ToString(), sp4country);
                    }
                    else { }
                }
            }




            //  }


            //address

            string address1 = address1TextBox.Text.ToUpper();
            string address2 = address2TextBox.Text.ToUpper();
            string state = stateTextBox.Text.ToUpper();
            string city = cityTextBox.Text.ToUpper();
            string pincode = pincodeTextBox.Text.ToUpper();

            string acountry = AddCountryDropDownList.SelectedItem.Text;

            int address = Queries2.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);

            //pcc = primarymobileDropDownList.SelectedItem.Text;


            // paltrcc = primaryalternateDropDownList.SelectedItem.Text;

            /*  if (primarymobileDropDownList.SelectedItem.Text == "")
              {
                  pcc = "";

              }
              else
              { //Request.Form[primarymobileDropDownList.UniqueID];
                  string pcc1;
                  pcc = primarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];

                  if (String.Compare(oPrimary_CC, pcc) != 0)
                  {
                      pcc1 = Queries2.getcountrycodefromstring(pcc);
                      pcc = pcc1;
                  }
                  //pcc1 = Queries2.getcountrycodefromstring(pcc);
                  //pcc = pcc1;

              }
              if (primaryalternateDropDownList.SelectedItem.Text == "")
              {
                  paltrcc = "";
              }
              else
              {
                  string paltrcc1;
                  paltrcc = primaryalternateDropDownList.SelectedItem.Text;
                  if (String.Compare(oPrimary_Alt_CC, paltrcc) != 0)
                  {
                      paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                      paltrcc = paltrcc1;
                  }

                  //paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                  //paltrcc = paltrcc1;
              }


              if (HomeCodeDropDownList.SelectedItem.Text == "")
              {
                  homecc = "";
              }
              else
              {
                  string homecc1;
                  homecc = HomeCodeDropDownList.SelectedItem.Text;
                  if (String.Compare(ohomec, homecc) != 0)
                  {
                      homecc1 = Queries2.getcountrycodefromstring(homecc);
                      homecc = homecc1;
                  }

                  //paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                  //paltrcc = paltrcc1;
              }

              if (OfficeCodeDropDownList.SelectedItem.Text == "")
              {
                  officecc = "";
              }
              else
              {
                  string officecc1;
                  officecc = OfficeCodeDropDownList.SelectedItem.Text;
                  if (String.Compare(oofficec, officecc) != 0)
                  {
                      officecc1 = Queries2.getcountrycodefromstring(officecc);
                      officecc = officecc1;
                  }

                  //paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                  //paltrcc = paltrcc1;
              }




              pmobile = pmobileTextBox.Text;

              palternate = palternateTextBox.Text;

              pemail = pemailTextBox.Text;

              pemail2 = pemailTextBox2.Text;

              officenum = OfficeNumTextBox.Text;

              homenum = HomeNumTextBox.Text;




              //scc = secondarymobileDropDownList.SelectedItem.Text;


              // saltcc = secondaryalternateDropDownList.SelectedItem.Text;

              if (secondarymobileDropDownList.SelectedItem.Text == "")
              {
                  scc = "";
              }
              else
              {
                  //Request.Form[secondarymobileDropDownList.UniqueID];
                  //scc = Request.Form[secondarymobileDropDownList.UniqueID];
                  string scc1;
                  scc = secondarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];

                  if (String.Compare(oSecondary_CC, scc) != 0)
                  {
                      scc1 = Queries2.getcountrycodefromstring(scc);
                      scc = scc1;
                  }


                  //Request.Form[primarymobileDropDownList.UniqueID];
                  //scc1 = Queries2.getcountrycodefromstring(scc);
                  //scc = scc1;

              }
              //secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID];
              if (secondaryalternateDropDownList.SelectedItem.Text == "")
              {
                  saltcc = "";
              }
              else
              {
                  string saltcc1;
                  saltcc = secondaryalternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                  if (String.Compare(oSecondary_Alt_CC, saltcc) != 0)
                  {
                      saltcc1 = Queries2.getcountrycodefromstring(saltcc);
                      saltcc = saltcc1;
                  }

                  //saltcc1 = Queries2.getcountrycodefromstring(saltcc);
                  // saltcc = saltcc1;

              }


              smobile = smobileTextBox.Text;

              salternate = salternateTextBox.Text;


              semail = semailTextBox.Text;
              semail2 = semailTextBox2.Text;



              // sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;


              // sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;


              if (subprofile1mobileDropDownList.SelectedItem.Text == "")
              {
                  sp1cc = "";
              }
              else
              {
                  //Request.Form[subprofile1mobileDropDownList.UniqueID];
                  //sp1cc = Request.Form[subprofile1mobileDropDownList.UniqueID];

                  string sp1cc1;
                  sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];


                  if (String.Compare(oSubprofile1_CC, sp1cc) != 0)
                  {
                      sp1cc1 = Queries2.getcountrycodefromstring(sp1cc);
                      sp1cc = sp1cc1;
                  }

                  //sp1cc1 = Queries2.getcountrycodefromstring(sp1cc);
                  //sp1cc = sp1cc1;

              }
              // sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID];

              if (subprofile1alternateDropDownList.SelectedItem.Text == "")
              {
                  sp1altcc = "";
              }
              else
              {

                  //sp1altcc = Request.Form[subprofile1alternateDropDownList.UniqueID];

                  string sp1altcc1;
                  sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];


                  if (String.Compare(oSubprofile1_Alt_CC, sp1altcc) != 0)
                  {
                      sp1altcc1 = Queries2.getcountrycodefromstring(sp1altcc);
                      sp1altcc = sp1altcc1;
                  }
                  //sp1altcc1 = Queries2.getcountrycodefromstring(sp1altcc);
                  //sp1altcc = sp1altcc1;

              }



              sp1mobile = sp1mobileTextBox.Text;

              sp1alternate = sp1alternateTextBox.Text;


              sp1email = sp1emailTextBox.Text;
              sp1email2 = sp1emailTextBox2.Text;



              // sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;


              // sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;

              if (subprofile2mobileDropDownList.SelectedItem.Text == "")
              {
                  sp2cc = "";
              }
              else
              {
                  // Request.Form[subprofile2mobileDropDownList.UniqueID];
                  //sp2cc = Request.Form[subprofile2mobileDropDownList.UniqueID];

                  string sp2cc1;
                  sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                  if (String.Compare(oSubprofile2_CC, sp2cc) != 0)
                  {
                      sp2cc1 = Queries2.getcountrycodefromstring(sp2cc);
                      sp2cc = sp2cc1;
                  }
                  //sp2cc1 = Queries2.getcountrycodefromstring(sp2cc);
                  //sp2cc = sp2cc1;

              }
              //sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID];
              if (subprofile2alternateDropDownList.SelectedItem.Text == "")
              {
                  sp2altccc = "";
              }
              else
              {

                  //sp2altccc = Request.Form[subprofile2alternateDropDownList.UniqueID];

                  string sp2altccc1;
                  sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                  if (String.Compare(oSubprofile2_Alt_CC, sp2altccc) != 0)
                  {
                      sp2altccc1 = Queries2.getcountrycodefromstring(sp2altccc);
                      sp2altccc = sp2altccc1;
                  }
                  //sp2altccc1 = Queries2.getcountrycodefromstring(sp2altccc);
                  //sp2altccc = sp2altccc1;


              }


              sp2mobile = sp2mobileTextBox.Text;


              sp2alternate = sp2alternateTextBox.Text;



              sp2email = sp2emailTextBox.Text;
              sp2email2 = sp2emailTextBox2.Text;


              //sub profile 3


              if (sp3country == "" || sp3country==null)
              {
                  sp3cc = "";
                  sp3altcc = "";
                  sp3mobile = "";
                  sp3alternate = "";
              }
              else
              {




                  //sp3cc = SubP3CCDropDownList.SelectedItem.Text;//  Request.Form[SubP3CCDropDownList.UniqueID];


                  //sp3altcc = SubP3CCDropDownList2.SelectedItem.Text;


                  if (SubP3CCDropDownList.SelectedItem.Text == "")
                  {
                      sp3cc = "";
                  }
                  else
                  {
                      string sp3cc1;
                      sp3cc = SubP3CCDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];


                      if (String.Compare(oSubprofile3_CC, sp3cc) != 0)
                      {
                          sp3cc1 = Queries2.getcountrycodefromstring(sp3cc);
                          sp3cc = sp3cc1;
                      }
                      //sp3cc1 = Queries2.getcountrycodefromstring(sp3cc);
                      //sp3cc = sp3cc1;


                      // sp3cc =  Request.Form[SubP3CCDropDownList.UniqueID];
                  }

                  if (SubP3CCDropDownList2.SelectedItem.Text == "")
                  {
                      sp3altcc = "";
                  }
                  else
                  {

                      //sp3altcc = Request.Form[SubP3CCDropDownList2.UniqueID];

                      string sp3altcc1;
                      sp3altcc = SubP3CCDropDownList2.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                      if (String.Compare(oSubprofile3_Alt_CC, sp3altcc) != 0)
                      {
                          sp3altcc1 = Queries2.getcountrycodefromstring(sp3altcc);
                          sp3altcc = sp3altcc1;
                      }
                      //sp3altcc1 = Queries2.getcountrycodefromstring(sp3altcc);
                      // sp3altcc = sp3altcc1;

                  }



                  if (SubP3MobileTextBox.Text == "" || SubP3MobileTextBox.Text == null)
                  {
                      sp3mobile = "";
                  }
                  else
                  {
                      sp3mobile = SubP3MobileTextBox.Text;
                  }
                  if (SubP3AMobileTextBox.Text == "" || SubP3AMobileTextBox.Text == null)
                  {
                      sp3alternate = "";
                  }
                  else
                  {
                      sp3alternate = SubP3AMobileTextBox.Text;
                  }
              }
              if (SubP3EmailTextBox.Text == "" || SubP3EmailTextBox.Text == null)
              {
                  sp3email = "";
              }
              else
              {
                  sp3email = SubP3EmailTextBox.Text;
              }

              if (SubP3EmailTextBox2.Text == "" || SubP3EmailTextBox2.Text == null)
              {
                  sp3email2 = "";
              }
              else
              {
                  sp3email2 = SubP3EmailTextBox2.Text;
              }

              //sub profile 4

              if (sp4country == "" || sp4country==null)
              {
                  sp4cc = "";
                  sp4altcc = "";
                  sp4mobile = "";
                  sp4alternate = "";
              }
              else
              {

                  //sp4cc = SubP4CCDropDownList.SelectedItem.Text;

                  //sp4altcc = SubP4CCDropDownList2.SelectedItem.Text;


                  if (SubP4CountryDropDownList.SelectedItem.Text == "")
                  {
                      sp4cc = "";
                  }
                  else
                  {

                      //sp4cc = SubP4CCDropDownList.SelectedItem.Text;
                      //sp4cc = Request.Form[SubP4CCDropDownList.UniqueID];

                      string sp4cc1;
                      sp4cc = SubP4CCDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                      if (String.Compare(oSubprofile4_CC, sp4cc) != 0)
                      {
                          sp4cc1 = Queries2.getcountrycodefromstring(sp4cc);
                          sp4cc = sp4cc1;
                      }
                      //sp4cc1 = Queries2.getcountrycodefromstring(sp4cc);
                      // sp4cc = sp4cc1;
                  }
                  //sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];

                  if (SubP4CCDropDownList2.SelectedItem.Text == "")
                  {
                      sp4altcc = "";
                  }
                  else
                  {

                      //sp4altcc = Request.Form[SubP4CCDropDownList2.UniqueID];

                      string sp4altcc1;
                      sp4altcc = SubP4CCDropDownList2.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                      if (String.Compare(oSubprofile4_Alt_CC, sp4altcc) != 0)
                      {
                          sp4altcc1 = Queries2.getcountrycodefromstring(sp4altcc);
                          sp4altcc = sp4altcc1;
                      }
                      //sp4altcc1 = Queries2.getcountrycodefromstring(sp4altcc);
                      //sp4altcc = sp4altcc1;

                  }


                  if (SubP4MobileTextBox.Text == "" || SubP4MobileTextBox.Text == null)
                  {
                      sp4mobile = "";
                  }
                  else
                  {
                      sp4mobile = SubP4MobileTextBox.Text;
                  }
                  if (SubP4AMobileTextBox.Text == "" || SubP4AMobileTextBox.Text == null)
                  {
                      sp4alternate = "";
                  }
                  else
                  {
                      sp4alternate = SubP4AMobileTextBox.Text;
                  }
              }
              if (SubP4EmailTextBox.Text == "" || SubP4EmailTextBox.Text == null)
              {
                  sp4email = "";
              }
              else
              {
                  sp4email = SubP4EmailTextBox.Text;
              }

              if (SubP4EmailTextBox2.Text == "" || SubP4EmailTextBox2.Text == null)
              {
                  sp4email2 = "";
              }
              else
              {
                  sp4email2 = SubP4EmailTextBox2.Text;
              }*/

            if (primarymobileDropDownList.SelectedItem.Text == "")
            {
                pcc = "";

            }
            else
            { //Request.Form[primarymobileDropDownList.UniqueID];
                string pcc1;
                pcc = primarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];

                if (String.Compare(Session["oPrimary_CC"].ToString(), pcc) != 0)
                {
                    pcc1 = Queries2.getcountrycodefromstring(pcc);
                    pcc = pcc1;
                }
                //pcc1 = Queries2.getcountrycodefromstring(pcc);
                //pcc = pcc1;

            }
            if (primaryalternateDropDownList.SelectedItem.Text == "")
            {
                paltrcc = "";
            }
            else
            {
                string paltrcc1;
                paltrcc = primaryalternateDropDownList.SelectedItem.Text;
                if (String.Compare(Session["oPrimary_Alt_CC"].ToString(), paltrcc) != 0)
                {
                    paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                    paltrcc = paltrcc1;
                }

                //paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                //paltrcc = paltrcc1;
            }

            if (HomeCodeDropDownList.SelectedItem.Text == "")
            {
                homecc = "";
            }
            else
            {
                string homecc1;
                homecc = HomeCodeDropDownList.SelectedItem.Text;
                if (String.Compare(Session["ohomec"].ToString(), homecc) != 0)
                {
                    homecc1 = Queries2.getcountrycodefromstring(homecc);
                    homecc = homecc1;
                }

                //paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                //paltrcc = paltrcc1;
            }

            if (OfficeCodeDropDownList.SelectedItem.Text == "")
            {
                officecc = "";
            }
            else
            {
                string officecc1;
                officecc = OfficeCodeDropDownList.SelectedItem.Text;
                if (String.Compare(Session["oofficec"].ToString(), officecc) != 0)
                {
                    officecc1 = Queries2.getcountrycodefromstring(officecc);
                    officecc = officecc1;
                }

                //paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                //paltrcc = paltrcc1;
            }


            pmobile = pmobileTextBox.Text;

            palternate = palternateTextBox.Text;

            pemail = pemailTextBox.Text;

            pemail2 = pemailTextBox2.Text;

            officenum = OfficeNumTextBox.Text;

            homenum = HomeNumTextBox.Text;


            //scc = secondarymobileDropDownList.SelectedItem.Text;


            //saltcc = secondaryalternateDropDownList.SelectedItem.Text;

            if (secondarymobileDropDownList.SelectedItem.Text == "")
            {
                scc = "";
            }
            else
            {
                //Request.Form[secondarymobileDropDownList.UniqueID];
                //scc = Request.Form[secondarymobileDropDownList.UniqueID];
                string scc1;
                scc = secondarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];

                if (String.Compare(Session["oSecondary_CC"].ToString(), scc) != 0)
                {
                    scc1 = Queries2.getcountrycodefromstring(scc);
                    scc = scc1;
                }


                //Request.Form[primarymobileDropDownList.UniqueID];
                //scc1 = Queries2.getcountrycodefromstring(scc);
                //scc = scc1;

            }
            //secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID];
            if (secondaryalternateDropDownList.SelectedItem.Text == "")
            {
                saltcc = "";
            }
            else
            {
                string saltcc1;
                saltcc = secondaryalternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                if (String.Compare(Session["oSecondary_Alt_CC"].ToString(), saltcc) != 0)
                {
                    saltcc1 = Queries2.getcountrycodefromstring(saltcc);
                    saltcc = saltcc1;
                }

                //saltcc1 = Queries2.getcountrycodefromstring(saltcc);
                // saltcc = saltcc1;

            }


            smobile = smobileTextBox.Text;

            salternate = salternateTextBox.Text;


            semail = semailTextBox.Text;
            semail2 = semailTextBox2.Text;



            //sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;


            //sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;


            if (subprofile1mobileDropDownList.SelectedItem.Text == "")
            {
                sp1cc = "";
            }
            else
            {
                //Request.Form[subprofile1mobileDropDownList.UniqueID];
                //sp1cc = Request.Form[subprofile1mobileDropDownList.UniqueID];

                string sp1cc1;
                sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];


                if (String.Compare(Session["oSubprofile1_CC"].ToString(), sp1cc) != 0)
                {
                    sp1cc1 = Queries2.getcountrycodefromstring(sp1cc);
                    sp1cc = sp1cc1;
                }

                //sp1cc1 = Queries2.getcountrycodefromstring(sp1cc);
                //sp1cc = sp1cc1;

            }
            // sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID];

            if (subprofile1alternateDropDownList.SelectedItem.Text == "")
            {
                sp1altcc = "";
            }
            else
            {

                //sp1altcc = Request.Form[subprofile1alternateDropDownList.UniqueID];

                string sp1altcc1;
                sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];


                if (String.Compare(Session["oSubprofile1_Alt_CC"].ToString(), sp1altcc) != 0)
                {
                    sp1altcc1 = Queries2.getcountrycodefromstring(sp1altcc);
                    sp1altcc = sp1altcc1;
                }
                //sp1altcc1 = Queries2.getcountrycodefromstring(sp1altcc);
                //sp1altcc = sp1altcc1;

            }



            sp1mobile = sp1mobileTextBox.Text;

            sp1alternate = sp1alternateTextBox.Text;


            sp1email = sp1emailTextBox.Text;
            sp1email2 = sp1emailTextBox2.Text;



            //sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;


            //sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;


            if (subprofile2mobileDropDownList.SelectedItem.Text == "")
            {
                sp2cc = "";
            }
            else
            {
                // Request.Form[subprofile2mobileDropDownList.UniqueID];
                //sp2cc = Request.Form[subprofile2mobileDropDownList.UniqueID];

                string sp2cc1;
                sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                if (String.Compare(Session["oSubprofile2_CC"].ToString(), sp2cc) != 0)
                {
                    sp2cc1 = Queries2.getcountrycodefromstring(sp2cc);
                    sp2cc = sp2cc1;
                }
                //sp2cc1 = Queries2.getcountrycodefromstring(sp2cc);
                //sp2cc = sp2cc1;

            }
            //sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID];
            if (subprofile2alternateDropDownList.SelectedItem.Text == "")
            {
                sp2altccc = "";
            }
            else
            {

                //sp2altccc = Request.Form[subprofile2alternateDropDownList.UniqueID];

                string sp2altccc1;
                sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                if (String.Compare(Session["oSubprofile2_Alt_CC"].ToString(), sp2altccc) != 0)
                {
                    sp2altccc1 = Queries2.getcountrycodefromstring(sp2altccc);
                    sp2altccc = sp2altccc1;
                }
                //sp2altccc1 = Queries2.getcountrycodefromstring(sp2altccc);
                //sp2altccc = sp2altccc1;


            }


            sp2mobile = sp2mobileTextBox.Text;


            sp2alternate = sp2alternateTextBox.Text;



            sp2email = sp2emailTextBox.Text;
            sp2email2 = sp2emailTextBox2.Text;


            //sub profile 3


            if (sp3country == "" || sp3country == null)
            {
                sp3cc = "";
                sp3altcc = "";
                sp3mobile = "";
                sp3alternate = "";
            }
            else
            {




                //sp3cc = SubP3CCDropDownList.SelectedItem.Text;//  Request.Form[SubP3CCDropDownList.UniqueID];


                // sp3altcc = SubP3CCDropDownList2.SelectedItem.Text;

                if (SubP3CCDropDownList.SelectedItem.Text == "")
                {
                    sp3cc = "";
                }
                else
                {
                    string sp3cc1;
                    sp3cc = SubP3CCDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];


                    if (String.Compare(Session["oSubprofile3_CC"].ToString(), sp3cc) != 0)
                    {
                        sp3cc1 = Queries2.getcountrycodefromstring(sp3cc);
                        sp3cc = sp3cc1;
                    }
                    //sp3cc1 = Queries2.getcountrycodefromstring(sp3cc);
                    //sp3cc = sp3cc1;


                    // sp3cc =  Request.Form[SubP3CCDropDownList.UniqueID];
                }

                if (SubP3CCDropDownList2.SelectedItem.Text == "")
                {
                    sp3altcc = "";
                }
                else
                {

                    //sp3altcc = Request.Form[SubP3CCDropDownList2.UniqueID];

                    string sp3altcc1;
                    sp3altcc = SubP3CCDropDownList2.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                    if (String.Compare(Session["oSubprofile3_Alt_CC"].ToString(), sp3altcc) != 0)
                    {
                        sp3altcc1 = Queries2.getcountrycodefromstring(sp3altcc);
                        sp3altcc = sp3altcc1;
                    }
                    //sp3altcc1 = Queries2.getcountrycodefromstring(sp3altcc);
                    // sp3altcc = sp3altcc1;

                }



                if (SubP3MobileTextBox.Text == "" || SubP3MobileTextBox.Text == null)
                {
                    sp3mobile = "";
                }
                else
                {
                    sp3mobile = SubP3MobileTextBox.Text;
                }
                if (SubP3AMobileTextBox.Text == "" || SubP3AMobileTextBox.Text == null)
                {
                    sp3alternate = "";
                }
                else
                {
                    sp3alternate = SubP3AMobileTextBox.Text;
                }
            }
            if (SubP3EmailTextBox.Text == "" || SubP3EmailTextBox.Text == null)
            {
                sp3email = "";
            }
            else
            {
                sp3email = SubP3EmailTextBox.Text;
            }

            if (SubP3EmailTextBox2.Text == "" || SubP3EmailTextBox2.Text == null)
            {
                sp3email2 = "";
            }
            else
            {
                sp3email2 = SubP3EmailTextBox2.Text;
            }

            //sub profile 4

            if (sp4country == "" || sp4country == null)
            {
                sp4cc = "";
                sp4altcc = "";
                sp4mobile = "";
                sp4alternate = "";
            }
            else
            {

                // sp4cc = SubP4CCDropDownList.SelectedItem.Text;

                // sp4altcc = SubP4CCDropDownList2.SelectedItem.Text;

                if (SubP4CountryDropDownList.SelectedItem.Text == "")
                {
                    sp4cc = "";
                }
                else
                {

                    //sp4cc = SubP4CCDropDownList.SelectedItem.Text;
                    //sp4cc = Request.Form[SubP4CCDropDownList.UniqueID];

                    string sp4cc1;
                    sp4cc = SubP4CCDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                    if (String.Compare(Session["oSubprofile4_CC"].ToString(), sp4cc) != 0)
                    {
                        sp4cc1 = Queries2.getcountrycodefromstring(sp4cc);
                        sp4cc = sp4cc1;
                    }
                    //sp4cc1 = Queries2.getcountrycodefromstring(sp4cc);
                    // sp4cc = sp4cc1;
                }
                //sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];

                if (SubP4CCDropDownList2.SelectedItem.Text == "")
                {
                    sp4altcc = "";
                }
                else
                {

                    //sp4altcc = Request.Form[SubP4CCDropDownList2.UniqueID];

                    string sp4altcc1;
                    sp4altcc = SubP4CCDropDownList2.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                    if (String.Compare(Session["oSubprofile4_Alt_CC"].ToString(), sp4altcc) != 0)
                    {
                        sp4altcc1 = Queries2.getcountrycodefromstring(sp4altcc);
                        sp4altcc = sp4altcc1;
                    }
                    //sp4altcc1 = Queries2.getcountrycodefromstring(sp4altcc);
                    //sp4altcc = sp4altcc1;

                }



                if (SubP4MobileTextBox.Text == "" || SubP4MobileTextBox.Text == null)
                {
                    sp4mobile = "";
                }
                else
                {
                    sp4mobile = SubP4MobileTextBox.Text;
                }
                if (SubP4AMobileTextBox.Text == "" || SubP4AMobileTextBox.Text == null)
                {
                    sp4alternate = "";
                }
                else
                {
                    sp4alternate = SubP4AMobileTextBox.Text;
                }
            }
            if (SubP4EmailTextBox.Text == "" || SubP4EmailTextBox.Text == null)
            {
                sp4email = "";
            }
            else
            {
                sp4email = SubP4EmailTextBox.Text;
            }

            if (SubP4EmailTextBox2.Text == "" || SubP4EmailTextBox2.Text == null)
            {
                sp4email2 = "";
            }
            else
            {
                sp4email2 = SubP4EmailTextBox2.Text;
            }





            int phone = Queries2.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3cc, sp3mobile, sp4cc, sp4mobile, sp3altcc, sp3alternate, sp4altcc, sp4alternate, officecc, officenum, homecc, homenum);
            int email = Queries2.UpdateEmail(profile, pemail, semail, sp1email, sp2email, pemail2, semail2, sp1email2, sp1email2, sp3email, sp3email2, sp4email, sp4email2);


            //stay details
            string resort = hotelTextBox.Text.ToUpper();
            string roomno = roomnoTextBox.Text;
            string arrivaldate = datepicker5.Text;
            string tarrivaldate;
            if (arrivaldate == "")
            {
                tarrivaldate = "1900-01-01";
            }
            else
            {
                tarrivaldate = arrivaldate;// Convert.ToDateTime(arrivaldate).ToString("yyyy-MM-dd"); //datepicker5.Text;
            }
            string departuredate = datepicker6.Text;
            string tdeparturedate;
            if (departuredate == "")
            {
                tdeparturedate = "1900-01-01";
            }
            else
            {
                tdeparturedate = departuredate;// Convert.ToDateTime(departuredate).ToString("yyyy-MM-dd"); //datepicker6.Text;
            }

            //guest status

            if (gueststatusDropDownList.SelectedItem.Text == "")
            {
                gueststatus = "";
            }
            else
            {

                gueststatus = gueststatusDropDownList.SelectedItem.Text;
            }

            if (salesrepDropDownList.SelectedItem.Text == "")
            {
                salesrep = "";
            }
            else
            {

                salesrep = salesrepDropDownList.SelectedItem.Text;
            }


            string timeIn = deckcheckintimeTextBox.Text;
            string timeOut = deckcheckouttimeTextBox.Text;
            string tourdate = tourdatedatepicker.Text;
            string ttourdate;
            int weekno;
            if (tourdate == "")
            {
                ttourdate = "1900-01-01";
                weekno = 0;
            }
            else
            {
                ttourdate = tourdate;// Convert.ToDateTime(tourdate).ToString("yyyy-MM-dd");
                weekno = Queries2.GetWkNumber(ttourdate);
            }
            //if (tourdate == "")
            //{
            //    ttourdate = "1900-01-01";
            //}
            //else
            //{
            //    ttourdate = tourdate;// Convert.ToDateTime(tourdate).ToString("yyyy-MM-dd"); //tourdatedatepicker.Text;
            //}
            string taxin1, taxiout1, taxin, taxiout;


            taxin1 = taxipriceInTextBox.Text;

            if (taxin1 == "")
            {
                taxin = "0";
            }
            else
            {
                taxin = taxipriceInTextBox.Text;
            }
            string taxirefin = TaxiRefInTextBox.Text.ToUpper();
            taxiout1 = TaxiPriceOutTextBox.Text;

            if (taxiout1 == "")
            {
                taxiout = "0";
            }
            else
            {
                taxiout = TaxiPriceOutTextBox.Text;
            }


            string taxirefout = TaxiRefOutTextBox.Text.ToUpper();

            //string comm1 = commentTextBox.Text;


            string QualiStatus = QStatusDropDownList1.SelectedItem.Text;




            /*if (GiftOptDropDownList.SelectedItem.Text == "")
            {
                gift_option = "";
            }
            else
            {

                gift_option = GiftOptDropDownList.SelectedItem.Text;
            }*/
            //string VoucherNo = TextVoucherNo.Text;
            //string giftcomm = TextComment.Text;




            int stay = Queries2.UpdateProfileStay(profile, resort, roomno, tarrivaldate, tdeparturedate);
            int tour = Queries2.UpdateTourDetails(profile, gueststatus, salesrep, ttourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout, QualiStatus, weekno);

            //int giftoption = Queries2.Updategiftoption(profile, gift_option, VoucherNo, giftcomm);


            string gifto1, gifto2, gifto3, gifto4, gifto5, gifto6, gifto7;
            if (giftoptionDropDownList.SelectedItem.Text == "")
            {
                gifto1 = "";
            }
            else
            {
                gifto1 = giftoptionDropDownList.SelectedItem.Text;
            }

            if (giftoptionDropDownList2.SelectedItem.Text == "")
            {
                gifto2 = "";
            }
            else
            {
                gifto2 = giftoptionDropDownList2.SelectedItem.Text;
            }

            if (giftoptionDropDownList3.SelectedItem.Text == "")
            {
                gifto3 = "";
            }
            else
            {
                gifto3 = giftoptionDropDownList3.SelectedItem.Text;
            }

            if (giftoptionDropDownList4.SelectedItem.Text == "")
            {
                gifto4 = "";
            }
            else
            {
                gifto4 = giftoptionDropDownList4.SelectedItem.Text;
            }
            if (giftoptionDropDownList5.SelectedItem.Text == "")
            {
                gifto5 = "";
            }
            else
            {
                gifto5 = giftoptionDropDownList5.SelectedItem.Text;
            }
            if (giftoptionDropDownList6.SelectedItem.Text == "")
            {
                gifto6 = "";
            }
            else
            {
                gifto6 = giftoptionDropDownList6.SelectedItem.Text;
            }
            if (giftoptionDropDownList7.SelectedItem.Text == "")
            {
                gifto7 = "";
            }
            else
            {
                gifto7 = giftoptionDropDownList7.SelectedItem.Text;
            }

            string voucher1 = vouchernoTextBox.Text;
            string voucher2 = vouchernoTextBox2.Text;
            string voucher3 = vouchernoTextBox3.Text;
            string voucher4 = vouchernoTextBox4.Text;
            string voucher5 = vouchernoTextBox5.Text;
            string voucher6 = vouchernoTextBox6.Text;
            string voucher7 = vouchernoTextBox7.Text;



            string giftprice1 = TextBoxGPrice1.Text;
            string giftprice2 = TextBoxGPrice2.Text;
            string giftprice3 = TextBoxGPrice3.Text;
            string giftprice4 = TextBoxGPrice4.Text;
            string giftprice5 = TextBoxGPrice5.Text;
            string giftprice6 = TextBoxGPrice6.Text;
            string giftprice7 = TextBoxGPrice7.Text;


            if (giftprice1 == "")
            {
                giftprice1 = "0";
            }

            if (giftprice2 == "")
            {
                giftprice2 = "0";
            }

            if (giftprice3 == "")
            {
                giftprice3 = "0";
            }

            if (giftprice4 == "")
            {
                giftprice4 = "0";
            }

            if (giftprice5 == "")
            {
                giftprice5 = "0";
            }

            if (giftprice6 == "")
            {
                giftprice6 = "0";
            }

            if (giftprice7 == "")
            {
                giftprice7 = "0";
            }




            //if (giftoptionDropDownList.SelectedItem.Text != "")
            //{
            //    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList, gifto1, voucher1, ProfileIDo,"");
            //}
            //if (giftoptionDropDownList2.SelectedItem.Text != "")
            //{
            //    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList2, gifto2, voucher2, ProfileIDo,"");
            //}
            //if (giftoptionDropDownList3.SelectedItem.Text != "")
            //{
            //    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList3, gifto3, voucher3, ProfileIDo,"");
            //}

            string chargeback = TextBoxChargeBack.Text;


            if (DeleGiftCheckBox1.Checked == true)
            {

                // Session["ogiftoptionDropDownList2"] = ar[1];
                // Session["ovouchernoTextBox2"] = br[1];
                // Session["ogiftprice2"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1]));//dr[1];
                int deletegift = Queries2.DeleteGift(Session["ogiftoptionDropDownList"].ToString(), Session["ovouchernoTextBox"].ToString(), ProfileIDTextBox.Text);
                string act = "Deleted gift :" + Session["ogiftoptionDropDownList"].ToString() + "  " + Session["ovouchernoTextBox"].ToString();
                int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else
            {

                if (giftoptionDropDownList.SelectedItem.Text != "")
                {
                    if (Session["ogiftoptionDropDownList"].ToString() == "" || Session["ogiftoptionDropDownList"].ToString() == null)
                    {
                        string giftid = Queries.GetProfileGift(Session["GlobOffice"].ToString());

                        int insert = Queries2.InsertGiftOption(giftid, gifto1, voucher1, chargeback, ProfileIDTextBox.Text, "", giftprice1);
                        int update1 = Queries.UpdateGiftValue(Session["GlobOffice"].ToString(), DateTime.Now.Year);
                    }
                    else
                    {
                        int gift = Queries2.UpdateGiftValue(Session["ogiftoptionDropDownList"].ToString(), gifto1, voucher1, ProfileIDTextBox.Text, chargeback, giftprice1);
                    }
                }
            }


            if (DeleGiftCheckBox2.Checked == true)
            {

                // Session["ogiftoptionDropDownList2"] = ar[1];
                // Session["ovouchernoTextBox2"] = br[1];
                // Session["ogiftprice2"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1]));//dr[1];
                int deletegift = Queries2.DeleteGift(Session["ogiftoptionDropDownList2"].ToString(), Session["ovouchernoTextBox2"].ToString(), ProfileIDTextBox.Text);
                string act = "Deleted gift :" + Session["ogiftoptionDropDownList2"].ToString() + "  " + Session["ovouchernoTextBox2"].ToString();
                int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else
            {

                if (giftoptionDropDownList2.SelectedItem.Text != "")
                {
                    if (Session["ogiftoptionDropDownList2"].ToString() == "" || Session["ogiftoptionDropDownList2"].ToString() == null)
                    {
                        string giftid = Queries.GetProfileGift(Session["GlobOffice"].ToString());

                        int insert = Queries2.InsertGiftOption(giftid, gifto2, voucher2, "", ProfileIDTextBox.Text, "", giftprice2);
                        int update1 = Queries.UpdateGiftValue(Session["GlobOffice"].ToString(), DateTime.Now.Year);
                    }
                    else
                    {
                        int gift = Queries2.UpdateGiftValue(Session["ogiftoptionDropDownList2"].ToString(), gifto2, voucher2, ProfileIDTextBox.Text, "", giftprice2);
                    }
                }
            }


            if (DeleGiftCheckBox3.Checked == true)
            {


                int deletegift = Queries2.DeleteGift(Session["ogiftoptionDropDownList3"].ToString(), Session["ovouchernoTextBox3"].ToString(), ProfileIDTextBox.Text);
                string act = "Deleted gift :" + Session["ogiftoptionDropDownList3"].ToString() + "  " + Session["ovouchernoTextBox3"].ToString();
                int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else
            {
                if (giftoptionDropDownList3.SelectedItem.Text != "")
                {
                    if (Session["ogiftoptionDropDownList3"].ToString() == "" || Session["ogiftoptionDropDownList3"].ToString() == null)
                    {
                        string giftid = Queries.GetProfileGift(Session["GlobOffice"].ToString());

                        int insert = Queries2.InsertGiftOption(giftid, gifto3, voucher3, "", ProfileIDTextBox.Text, "", giftprice3);
                        int update1 = Queries.UpdateGiftValue(Session["GlobOffice"].ToString(), DateTime.Now.Year);
                    }
                    else
                    {

                        int gift = Queries2.UpdateGiftValue(Session["ogiftoptionDropDownList3"].ToString(), gifto3, voucher3, ProfileIDTextBox.Text, "", giftprice3);
                    }
                }
            }


            if (DeleGiftCheckBox4.Checked == true)
            {


                int deletegift = Queries2.DeleteGift(Session["ogiftoptionDropDownList4"].ToString(), Session["ovouchernoTextBox4"].ToString(), ProfileIDTextBox.Text);
                string act = "Deleted gift :" + Session["ogiftoptionDropDownList4"].ToString() + "  " + Session["ovouchernoTextBox4"].ToString();
                int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else
            {
                if (giftoptionDropDownList4.SelectedItem.Text != "")
                {
                    if (Session["ogiftoptionDropDownList4"].ToString() == "" || Session["ogiftoptionDropDownList4"].ToString() == null)
                    {
                        string giftid = Queries.GetProfileGift(Session["GlobOffice"].ToString());

                        int insert = Queries2.InsertGiftOption(giftid, gifto4, voucher4, "", ProfileIDTextBox.Text, "", giftprice4);
                        int update1 = Queries.UpdateGiftValue(Session["GlobOffice"].ToString(), DateTime.Now.Year);
                    }
                    else
                    {

                        int gift = Queries2.UpdateGiftValue(Session["ogiftoptionDropDownList4"].ToString(), gifto4, voucher4, ProfileIDTextBox.Text, "", giftprice4);
                    }
                }
            }


            if (DeleGiftCheckBox5.Checked == true)
            {


                int deletegift = Queries2.DeleteGift(Session["ogiftoptionDropDownList5"].ToString(), Session["ovouchernoTextBox5"].ToString(), ProfileIDTextBox.Text);
                string act = "Deleted gift :" + Session["ogiftoptionDropDownList5"].ToString() + "  " + Session["ovouchernoTextBox5"].ToString();
                int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else
            {

                if (giftoptionDropDownList5.SelectedItem.Text != "")
                {
                    if (Session["ogiftoptionDropDownList5"].ToString() == "" || Session["ogiftoptionDropDownList5"].ToString() == null)
                    {
                        string giftid = Queries.GetProfileGift(Session["GlobOffice"].ToString());

                        int insert = Queries2.InsertGiftOption(giftid, gifto5, voucher5, "", ProfileIDTextBox.Text, "", giftprice5);
                        int update1 = Queries.UpdateGiftValue(Session["GlobOffice"].ToString(), DateTime.Now.Year);
                    }
                    else
                    {

                        int gift = Queries2.UpdateGiftValue(Session["ogiftoptionDropDownList5"].ToString(), gifto5, voucher5, ProfileIDTextBox.Text, "", giftprice5);
                    }
                }
            }


            if (DeleGiftCheckBox6.Checked == true)
            {


                int deletegift = Queries2.DeleteGift(Session["ogiftoptionDropDownList6"].ToString(), Session["ovouchernoTextBox6"].ToString(), ProfileIDTextBox.Text);
                string act = "Deleted gift :" + Session["ogiftoptionDropDownList6"].ToString() + "  " + Session["ovouchernoTextBox6"].ToString();
                int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else
            {

                if (giftoptionDropDownList6.SelectedItem.Text != "")
                {
                    if (Session["ogiftoptionDropDownList6"].ToString() == "" || Session["ogiftoptionDropDownList6"].ToString() == null)
                    {
                        string giftid = Queries.GetProfileGift(Session["GlobOffice"].ToString());

                        int insert = Queries2.InsertGiftOption(giftid, gifto6, voucher6, "", ProfileIDTextBox.Text, "", giftprice6);
                        int update1 = Queries.UpdateGiftValue(Session["GlobOffice"].ToString(), DateTime.Now.Year);
                    }
                    else
                    {

                        int gift = Queries2.UpdateGiftValue(Session["ogiftoptionDropDownList6"].ToString(), gifto6, voucher6, ProfileIDTextBox.Text, "", giftprice6);
                    }
                }
            }

            if (DeleGiftCheckBox7.Checked == true)
            {


                int deletegift = Queries2.DeleteGift(Session["ogiftoptionDropDownList7"].ToString(), Session["ovouchernoTextBox7"].ToString(), ProfileIDTextBox.Text);
                string act = "Deleted gift :" + Session["ogiftoptionDropDownList7"].ToString() + "  " + Session["ovouchernoTextBox7"].ToString();
                int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else
            {

                if (giftoptionDropDownList7.SelectedItem.Text != "")
                {
                    if (Session["ogiftoptionDropDownList7"].ToString() == "" || Session["ogiftoptionDropDownList7"].ToString() == null)
                    {
                        string giftid = Queries.GetProfileGift(Session["GlobOffice"].ToString());

                        int insert = Queries2.InsertGiftOption(giftid, gifto7, voucher7, "", ProfileIDTextBox.Text, "", giftprice7);
                        int update1 = Queries.UpdateGiftValue(Session["GlobOffice"].ToString(), DateTime.Now.Year);
                    }
                    else
                    {

                        int gift = Queries2.UpdateGiftValue(Session["ogiftoptionDropDownList7"].ToString(), gifto7, voucher7, ProfileIDTextBox.Text, "", giftprice7);
                    }
                }
            }


            if (String.Compare((string)Session["oProfile_Venue_Country"], venuecountry) != 0)
            {
                string act = "venue country changed from:" + Session["oProfile_Venue_Country"] + "To:" + venuecountry;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Venue Country Updated", Session["oProfile_Venue_Country"].ToString(), venuecountry);
                //int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oProfile_Venue"], venue) != 0)
            {
                string act = "venue changed from:" + Session["oProfile_Venue"] + "To:" + venue;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Venue Updated", Session["oProfile_Venue"].ToString(), venue);
            }
            else { }

            if (String.Compare((string)Session["oProfile_Group_Venue"], venuegroup) != 0)
            {
                string act = "venue group changed from:" + Session["oProfile_Group_Venue"] + "To:" + venuegroup;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Venue Group Updated", Session["oProfile_Group_Venue"].ToString(), venuegroup);
            }
            else { }

            if (String.Compare((string)Session["oProfile_Sub_Venue"], subvenue) != 0)
            {
                string act = "Sub venue changed from:" + Session["oProfile_Sub_Venue"] + "To:" + subvenue;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Sub Venue Updated", Session["oProfile_Sub_Venue"].ToString(), subvenue);
            }
            else { }

            if (String.Compare((string)Session["oProfile_Marketing_Program"], mktg) != 0)
            {
                string act = "marketing prgm changed from:" + Session["oProfile_Marketing_Program"] + "To:" + mktg;
                int insertlog2 = Queries3.InsertContractLogs(Session["ProfileID"].ToString(), "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oAgent_marketingSource"], agents) != 0)
            {
                string act = "agent name changed from:" + Session["oAgent_marketingSource"] + "To:" + agents;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Agent Marketing Source Updated", Session["oAgent_marketingSource"].ToString(), agents);
            }
            else { }
            if (String.Compare((string)Session["oToName_sourceCode"], agentcode) != 0)
            {
                string act = "To Name changed from:" + Session["oToName_sourceCode"] + "To:" + agentcode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile To Name Updated", Session["oToName_sourceCode"].ToString(), agentcode);
            }
            else { }




            if (String.Compare((string)Session["oPromoSource"], promosource) != 0)
            {
                string act = "Promo Source changed from:" + Session["oPromoSource"] + "To:" + promosource;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Promo Source Updated", Session["oPromoSource"].ToString(), promosource);
            }
            else { }


            if (String.Compare((string)Session["oTeleMarktAgent"], teleagent) != 0)
            {
                string act = "Tele Marketing Agent changed from:" + Session["oTeleMarktAgent"] + "To:" + teleagent;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Telemarketing Agent Updated", Session["oTeleMarktAgent"].ToString(), teleagent);
            }
            else { }
            // int updateprofile = Queries2.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, "","","",comm1,reception,subvenue, regTerms, VPID,regTerms2,Secondemploymentstatus, leadsource,prearrival,verifi,promosource,teleagent);
            if (String.Compare((string)Session["oPreArrival"], prearrival) != 0)
            {
                string act = "Pre Arrival changed from:" + Session["oPreArrival"] + "To:" + prearrival;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile PreArrival Updated", Session["oPreArrival"].ToString(), prearrival);
            }
            else { }

            if (String.Compare((string)Session["oVerification"], verifi) != 0)
            {
                string act = "Verification changed from:" + Session["oVerification"] + "To:" + verifi;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Verification Updated", Session["oVerification"].ToString(), verifi);
            }
            else { }

            if (String.Compare((string)Session["oGuestRelations"], leadsource) != 0)
            {
                string act = "guest Relations changed from:" + Session["oGuestRelations"] + "To:" + leadsource;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Guest Relations Updated", Session["oGuestRelations"].ToString(), leadsource);
            }
            else { }

            if (String.Compare((string)Session["oProfile_Reception"], reception) != 0)
            {
                string act = "Reception changed from:" + Session["oProfile_Reception"] + "To:" + reception;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Receptionist Updated", Session["oProfile_Reception"].ToString(), reception);
            }
            else { }


            //int primary = Queries2.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, tprimarydob, primarynationality, primarycountry, primaryage, "","");
            if (String.Compare((string)Session["oProfile_Primary_Title"], primarytitle) != 0)
            {
                string act = "primary title changed from:" + Session["oProfile_Primary_Title"] + "To:" + primarytitle;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile Title Updated", Session["oProfile_Primary_Title"].ToString(), primarytitle);
            }
            else { }
            if (String.Compare((string)Session["oProfile_Primary_Fname"], primaryfname.ToUpper()) != 0)
            {
                string act = "primary fname changed from:" + Session["oProfile_Primary_Fname"] + "To:" + primaryfname.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile First Name Updated", Session["oProfile_Primary_Fname"].ToString(), primaryfname.ToUpper());
            }
            else { }
            if (String.Compare((string)Session["oProfile_Primary_Lname"], primaylname.ToUpper()) != 0)
            {
                string act = "primay lname changed from:" + Session["oProfile_Primary_Lname"] + "To:" + primaylname.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile Last Name Updated", Session["oProfile_Primary_Lname"].ToString(), primaylname.ToUpper());
            }
            else { }
            if (String.Compare((string)Session["oProfile_Primary_DOB"], tprimarydob) != 0)
            {
                string act = "primary dob changed from:" + Session["oProfile_Primary_DOB"] + "To:" + tprimarydob;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile DOB Updated", Session["oProfile_Primary_DOB"].ToString(), tprimarydob);
            }
            else { }

            if (String.Compare((string)Session["oPrimary_Age"], primaryage) != 0)
            {
                string act = "primary Age changed from:" + Session["oPrimary_Age"] + "To:" + primaryage;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile Age Updated", Session["oPrimary_Age"].ToString(), primaryage);
            }
            else { }


            if (String.Compare((string)Session["oProfile_Primary_Nationality"], primarynationality) != 0)
            {
                string act = "primary nationality changed from:" + Session["oProfile_Primary_Nationality"] + "To:" + primarynationality;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile Nationlaity Updated", Session["oProfile_Primary_Nationality"].ToString(), primarynationality);
            }
            else { }
            if (String.Compare((string)Session["oProfile_Primary_Country"], primarycountry) != 0)
            {
                string act = "primary country changed from:" + Session["oProfile_Primary_Country"] + "To:" + primarycountry;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile Country Updated", Session["oProfile_Primary_Country"].ToString(), primarycountry);
            }
            else { }

            //if (String.Compare((string)Session["oPrimary_Designation"], primaryDesignation.ToUpper()) != 0)
            //{
            //    string act = "primary Designation changed from:" + Session["oPrimary_Designation"] + "To:" + primaryDesignation.ToUpper();
            //    int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile Designation Updated", Session["oPrimary_Designation"].ToString(), primaryDesignation.ToUpper());
            //}
            //else { }


            //if (String.Compare((string)Session["oPrimary_Language"], primaryLanguage) != 0)
            //{
            //    string act = "primary Language changed from:" + Session["oPrimary_Language"] + "To:" + primaryLanguage;
            //    int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Profile Language Updated", Session["oPrimary_Language"].ToString(), primaryLanguage);
            //}
            //else { }

            //int secondary = Queries2.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, secondaryage, "", "");



            //if (String.Compare((string)Session["oSecondary_Designation"], secondaryDesignation.ToUpper()) != 0)
            //{
            //    string act = "secondary Designation changed from:" + Session["oSecondary_Designation"] + "To:" + secondaryDesignation.ToUpper();
            //    int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile Designation Updated", Session["oSecondary_Designation"].ToString(), secondaryDesignation.ToUpper());
            //}
            //else { }

            //if (String.Compare((string)Session["oSecondary_Language"], secondaryLanguage) != 0)
            //{
            //    string act = "secondary Language changed from:" + Session["oSecondary_Language"] + "To:" + secondaryLanguage;
            //    int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Profile Language Updated", Session["oSecondary_Language"].ToString(), secondaryLanguage);
            //}
            //else { }

            //int sp1 = Queries2.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, SubProfile1age);



            //int sp2 = Queries2.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, Subprofile2);




            //int sp3 = Queries2.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, Subprofile3);




            //int address = Queries2.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);

            if (String.Compare((string)Session["oProfile_Address_Line1"], address1.ToUpper()) != 0)
            {
                string act = "Address line 1 changed from:" + Session["oProfile_Address_Line1"] + "To:" + address1.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Address Line 1 Field", Session["oProfile_Address_Line1"].ToString(), address1.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oProfile_Address_Line2"], address2.ToUpper()) != 0)
            {
                string act = "Address line 2 changed from:" + Session["oProfile_Address_Line2"] + "To:" + address2.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Address Line 2 Field", Session["oProfile_Address_Line2"].ToString(), address2.ToUpper());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Address_Country"], acountry) != 0)
            {
                string act = "Address Country changed from:" + Session["oProfile_Address_Country"] + "To:" + acountry;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Address Country Field", Session["oProfile_Address_Country"].ToString(), acountry);
            }
            else { }

            if (String.Compare((string)Session["oProfile_Address_State"], state.ToUpper()) != 0)
            {
                string act = "Address State changed from:" + Session["oProfile_Address_State"] + "To:" + state.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Address State Field", Session["oProfile_Address_State"].ToString(), state.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oProfile_Address_city"], city.ToUpper()) != 0)
            {
                string act = "Address City changed from:" + Session["oProfile_Address_city"] + "To:" + city.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Address City Field", Session["oProfile_Address_city"].ToString(), city.ToUpper());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Address_Postcode"], pincode.ToUpper()) != 0)
            {
                string act = "Address Postal code changed from:" + Session["oProfile_Address_Postcode"] + "To:" + pincode.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Profile Address Postal Code Field", Session["oProfile_Address_Postcode"].ToString(), pincode.ToUpper());
            }
            else { }


            //    int stay = Queries2.UpdateProfileStay(profile, resort, roomno, tarrivaldate, tdeparturedate);


            if (String.Compare((string)Session["oResort_Name"], resort.ToUpper()) != 0)
            {
                string act = "Resort Name changed from:" + Session["oResort_Name"] + "To:" + resort.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Resort Name Updated", Session["oResort_Name"].ToString(), resort.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oResort_RoomNo"], roomno) != 0)
            {
                string act = "Resort Room No changed from:" + Session["oResort_RoomNo"] + "To:" + roomno;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Resort Room No Updated", Session["oResort_RoomNo"].ToString(), roomno);
            }
            else { }


            if (String.Compare((string)Session["oArrival_Date"], tarrivaldate) != 0)
            {
                string act = "Arrival Date changed from:" + Session["oArrival_Date"] + "To:" + tarrivaldate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Arrival Date Updated", Session["oArrival_Date"].ToString(), tarrivaldate);
            }
            else { }


            if (String.Compare((string)Session["oDepature_Date"], tdeparturedate) != 0)
            {
                string act = "Depature Date changed from:" + Session["oDepature_Date"] + "To:" + tdeparturedate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Departure Date Updated", Session["oDepature_Date"].ToString(), tdeparturedate);
            }
            else { }


            //     int tour = Queries2.UpdateTourDetails(profile, gueststatus, salesrep, ttourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout, QualiStatus, weekno);

            if (String.Compare((string)Session["oGuest_Status"], gueststatus) != 0)
            {
                string act = "Guest Status changed from:" + Session["oGuest_Status"] + "To:" + gueststatus;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Guest Status Updated", Session["oGuest_Status"].ToString(), gueststatus);
            }
            else { }


            if (String.Compare((string)Session["oSales_Rep"], salesrep) != 0)
            {
                string act = "Sales Representative changed from:" + Session["oSales_Rep"] + "To:" + salesrep;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sales Rep Updated", Session["oSales_Rep"].ToString(), salesrep);
            }
            else { }


            if (String.Compare((string)Session["oTour_Date"], ttourdate) != 0)
            {
                string act = "Tour Date changed from:" + Session["oTour_Date"] + "To:" + ttourdate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Tour Date Updated", Session["oTour_Date"].ToString(), ttourdate);
            }
            else { }


            if (String.Compare((string)Session["oCheck_In_Time"], timeIn) != 0)
            {
                string act = "Check In Time changed from:" + Session["oCheck_In_Time"] + "To:" + timeIn;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "CheckIn Time Updated", Session["oCheck_In_Time"].ToString(), timeIn);
            }
            else { }

            if (String.Compare((string)Session["oCheck_Out_Time"], timeOut) != 0)
            {
                string act = "Check Out Time changed from:" + Session["oCheck_Out_Time"] + "To:" + timeOut;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Checkout Time Updated", Session["oCheck_Out_Time"].ToString(), timeOut);
            }
            else { }


            if (String.Compare((string)Session["oTaxi_In_Price"], taxin) != 0)
            {
                string act = "Taxi In Price changed from:" + Session["oTaxi_In_Price"] + "To:" + taxin;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Taxi In Price Updated", Session["oTaxi_In_Price"].ToString(), taxin);
            }
            else { }


            if (String.Compare((string)Session["oTaxi_Out_Price"], taxiout) != 0)
            {
                string act = "Taxi Out Price changed from:" + Session["oTaxi_Out_Price"] + "To:" + taxiout;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Taxi Out Price Updated", Session["oTaxi_Out_Price"].ToString(), taxiout);
            }
            else { }

            if (String.Compare((string)Session["oTaxi_In_Ref"], taxirefin.ToUpper()) != 0)
            {
                string act = "Taxi In Ref changed from:" + Session["oTaxi_In_Ref"] + "To:" + taxirefin.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Taxi In Ref Updated", Session["oTaxi_In_Ref"].ToString(), taxirefin.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oTaxi_Out_Ref"], taxirefout.ToUpper()) != 0)
            {
                string act = "Taxi Out Ref changed from:" + Session["oTaxi_Out_Ref"] + "To:" + taxirefout.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Taxi Out Ref. Updated", Session["oTaxi_Out_Ref"].ToString(), taxirefout.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oQstatus"], QualiStatus) != 0)
            {
                string act = "Qstatus changed from:" + Session["oQstatus"] + "To:" + QualiStatus;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Q Status Updated", Session["oQstatus"].ToString(), QualiStatus);
            }
            else { }


            if (String.Compare((string)Session["oWeekNo"], weekno.ToString()) != 0)
            {
                string act = "Week No changed from:" + Session["oWeekNo"] + "To:" + weekno.ToString();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Week No. Updated", Session["oWeekNo"].ToString(), weekno.ToString());
            }
            else { }




            //int updateID_Card = Queries2.UpdateIDCard(ProfileIDTextBox.Text, primaryidtype, primaryidnum, secondaryidtype, secondaryidnum, sp1idtype, sp1idnum, sp2idtype, sp2idnum, sp3idtype, sp3idnum, sp4idtype, sp4idnum);


            if (String.Compare((string)Session["oPrimary_ID_Type"], primaryidtype.ToUpper()) != 0)
            {
                string act = "Primary ID Type changed from:" + Session["oPrimary_ID_Type"] + "To:" + primaryidtype.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary ID Type Updated", Session["oPrimary_ID_Type"].ToString(), primaryidtype.ToUpper());
            }
            else { }

            if (String.Compare((string)Session["oPrimary_ID_Num"], primaryidnum) != 0)
            {
                string act = "Primary ID Num changed from:" + Session["oPrimary_ID_Num"] + "To:" + primaryidnum;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary ID No. Updated", Session["oPrimary_ID_Num"].ToString(), primaryidnum);
            }
            else { }


            if (String.Compare((string)Session["oSecondary_ID_Type"], secondaryidtype.ToUpper()) != 0)
            {
                string act = "Secondary ID Type changed from:" + Session["oSecondary_ID_Type"] + "To:" + secondaryidtype.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary ID Type Updated", Session["oSecondary_ID_Type"].ToString(), secondaryidtype.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_ID_Num"], secondaryidnum) != 0)
            {
                string act = "Secondary ID Num changed from:" + Session["oSecondary_ID_Num"] + "To:" + secondaryidnum;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary ID No. Updated", Session["oSecondary_ID_Num"].ToString(), secondaryidnum);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile1_ID_Type"], sp1idtype.ToUpper()) != 0)
            {
                string act = "Sub Profile 1 ID Type changed from:" + Session["oSubprofile1_ID_Type"] + "To:" + sp1idtype.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 ID Type Updated", Session["oSubprofile1_ID_Type"].ToString(), sp1idtype.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile1_ID_Num"], sp1idnum) != 0)
            {
                string act = "Sub Profile 1 ID Num changed from:" + Session["oSubprofile1_ID_Num"] + "To:" + sp1idnum;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 ID No. Updated", Session["oSubprofile1_ID_Num"].ToString(), sp1idnum);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_ID_Type"], sp2idtype.ToUpper()) != 0)
            {
                string act = "Sub Profile 2 ID Type changed from:" + Session["oSubprofile2_ID_Type"] + "To:" + sp2idtype.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 ID Type Updated", Session["oSubprofile2_ID_Type"].ToString(), sp2idtype.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_ID_Num"], sp2idnum) != 0)
            {
                string act = "Sub Profile 2 ID Num changed from:" + Session["oSubprofile2_ID_Num"] + "To:" + sp2idnum;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 ID Type Updated", Session["oSubprofile2_ID_Num"].ToString(), sp2idnum);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile3_ID_Type"], sp3idtype.ToUpper()) != 0)
            {
                string act = "Sub Profile 3 ID Type changed from:" + Session["oSubprofile3_ID_Type"] + "To:" + sp3idtype.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 ID Type Updated", Session["oSubprofile3_ID_Type"].ToString(), sp3idtype.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile3_ID_Num"], sp3idnum) != 0)
            {
                string act = "Sub Profile 3 ID Num changed from:" + Session["oSubprofile3_ID_Num"] + "To:" + sp3idnum;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 ID No. Updated", Session["oSubprofile3_ID_Num"].ToString(), sp3idnum);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_ID_Type"], sp4idtype.ToUpper()) != 0)
            {
                string act = "Sub Profile 4 ID Type changed from:" + Session["oSubprofile4_ID_Type"] + "To:" + sp4idtype.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 ID Type Updated", Session["oSubprofile4_ID_Type"].ToString(), sp4idtype.ToUpper());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_ID_Num"], sp4idnum) != 0)
            {
                string act = "Sub Profile 4 ID Num changed from:" + Session["oSubprofile4_ID_Num"] + "To:" + sp4idnum;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 ID No. Updated", Session["oSubprofile4_ID_Num"].ToString(), sp4idnum);
            }
            else { }
            //int updateprofile = Queries2.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, "","","",comm1,reception,subvenue, regTerms, VPID,regTerms2,Secondemploymentstatus, leadsource,prearrival,verifi,promosource,teleagent);

            if (String.Compare((string)Session["oComments"], comm1.ToUpper()) != 0)
            {
                string act = "Comments changed from:" + Session["oComments"] + "To:" + comm1.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Comments Updated", Session["oComments"].ToString(), comm1.ToUpper());
            }
            else { }



            if (String.Compare((string)Session["oRegTerms"], regTerms) != 0)
            {
                string act = "Reg Terms changed from:" + Session["oRegTerms"] + "To:" + regTerms;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Reg Terms1 Updated", Session["oRegTerms"].ToString(), regTerms);
            }
            else { }

            if (String.Compare((string)Session["oRegTerms2"], regTerms2) != 0)
            {
                string act = "Reg Terms 2 changed from:" + Session["oRegTerms2"] + "To:" + regTerms2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Reg Terms2 Updated", Session["oRegTerms2"].ToString(), regTerms2);
            }
            else { }


            //  int phone = Queries2.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3cc, sp3mobile, sp4cc, sp4mobile, sp3altcc, sp3alternate, sp4altcc, sp4alternate, officecc, officenum, homecc, homenum);
            //int email = Queries2.UpdateEmail(profile, pemail, semail, sp1email, sp2email, pemail2, semail2, sp1email2, sp1email2, sp3email, sp3email2, sp4email, sp4email2);



            if (String.Compare((string)Session["oPrimary_CC"], pcc) != 0)
            {
                string act = "primary mobile code changed from:" + Session["oPrimary_CC"] + "To:" + pcc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Mobile Code Updated", Session["oPrimary_CC"].ToString(), pcc);
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Mobile"], pmobile) != 0)
            {
                string act = "primary mobile no changed from:" + Session["oPrimary_Mobile"] + "To:" + pmobile;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Mobile No Updated", Session["oPrimary_Mobile"].ToString(), pmobile);
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Alt_CC"], paltrcc) != 0)
            {
                string act = "primary mobile changed from:" + Session["oPrimary_Alt_CC"] + "To:" + paltrcc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Alternate Code Updated", Session["oPrimary_Alt_CC"].ToString(), paltrcc);
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Alternate"], palternate) != 0)
            {
                string act = "primary alternate no changed from:" + Session["oPrimary_Alternate"] + "To:" + palternate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Alternate No. Updated", Session["oPrimary_Alternate"].ToString(), palternate);
            }
            else { }

            if (String.Compare((string)Session["oPrimary_Home_CC"], homecc) != 0)
            {
                string act = "primary Home code changed from:" + Session["oPrimary_Home_CC"] + "To:" + homecc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Home Code Updated", Session["oPrimary_Home_CC"].ToString(), homecc);
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Home"], homenum) != 0)
            {
                string act = "primary Home no changed from:" + Session["oPrimary_Home"] + "To:" + homenum;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Home No. Updated", Session["oPrimary_Home"].ToString(), homenum);
            }
            else { }


            if (String.Compare((string)Session["oPrimary_Office_CC"], officecc) != 0)
            {
                string act = "primary Office code changed from:" + Session["oPrimary_Office_CC"] + "To:" + officecc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Office Code Updated", Session["oPrimary_Office_CC"].ToString(), officecc);
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Office"], officenum) != 0)
            {
                string act = "primary Office no changed from:" + Session["oPrimary_Office"] + "To:" + officenum;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Office No. Updated", Session["oPrimary_Office"].ToString(), officenum);
            }
            else { }



            if (String.Compare((string)Session["oSecondary_CC"], scc) != 0)
            {
                string act = "Secondary mobile code changed from:" + Session["oSecondary_CC"] + "To:" + scc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Mobile Code Updated", Session["oSecondary_CC"].ToString(), scc);
            }
            else { }

            if (String.Compare((string)Session["oSecondary_Mobile"], smobile) != 0)
            {
                string act = "Secondary mobile No changed from:" + Session["oSecondary_Mobile"] + "To:" + smobile;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Mobile No. Updated", Session["oSecondary_Mobile"].ToString(), smobile);
            }
            else { }


            if (String.Compare((string)Session["oSecondary_Alt_CC"], saltcc) != 0)
            {
                string act = "Secondary alternate code changed from:" + Session["oSecondary_Alt_CC"] + "To:" + saltcc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Alternate Code Updated", Session["oSecondary_Alt_CC"].ToString(), saltcc);
            }
            else { }

            if (String.Compare((string)Session["oSecondary_Alternate"], sp1alternate) != 0)
            {
                string act = "Secondary alternate No changed from:" + Session["oSecondary_Alternate"] + "To:" + sp1alternate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Alternate No Updated", Session["oSecondary_Alternate"].ToString(), sp1alternate);
            }
            else { }


            //if (String.Compare((string)Session["oSecondary_Home_CC"], secondaryHomeCode) != 0)
            //{
            //    string act = "Secondary Home code changed from:" + Session["oSecondary_Home_CC"] + "To:" + secondaryHomeCode;
            //    int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Home Code Updated", Session["oSecondary_Home_CC"].ToString(), secondaryHomeCode);
            //}
            //else { }


            //if (String.Compare((string)Session["oSecondary_Home"], secondaryHomeNumber) != 0)
            //{
            //    string act = "Secondary Home No changed from:" + Session["oSecondary_Home"] + "To:" + secondaryHomeNumber;
            //    int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Home No. Updated", Session["oSecondary_Home"].ToString(), secondaryHomeNumber);
            //}
            //else { }


            //if (String.Compare((string)Session["oSecondary_Office_CC"], secondaryOfficeCode) != 0)
            //{
            //    string act = "Secondary Office code changed from:" + Session["oSecondary_Office_CC"] + "To:" + secondaryOfficeCode;
            //    int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Office Code Updated", Session["oSecondary_Office_CC"].ToString(), secondaryOfficeCode);
            //}
            //else { }


            //if (String.Compare((string)Session["oSecondary_Office"], secondaryOfficeNumber) != 0)
            //{
            //    string act = "Secondary Office No changed from:" + Session["oSecondary_Office"] + "To:" + secondaryOfficeNumber;
            //    int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Office No. Updated", Session["oSecondary_Office"].ToString(), secondaryOfficeNumber);
            //}
            //else { }

            //  int phone = Queries2.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3cc, sp3mobile, sp4cc, sp4mobile, sp3altcc, sp3alternate, sp4altcc, sp4alternate, officecc, officenum, homecc, homenum);
            if (String.Compare((string)Session["oSubprofile1_CC"], sp1cc) != 0)
            {
                string act = "Sub Profile 1 Mobile code changed from:" + Session["oSubprofile1_CC"] + "To:" + sp1cc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Mobile Code Updated", Session["oSubprofile1_CC"].ToString(), sp1cc);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile1_Mobile"], sp1mobile) != 0)
            {
                string act = "Sub profile 1 Mobile  No changed from:" + Session["oSubprofile1_Mobile"] + "To:" + sp1mobile;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Mobile No Updated", Session["oSubprofile1_Mobile"].ToString(), sp1mobile);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile1_Alt_CC"], sp1altcc) != 0)
            {
                string act = "Sub Profile 1 alternate code changed from:" + Session["oSubprofile1_Alt_CC"] + "To:" + sp1altcc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Alternate Code Updated", Session["oSubprofile1_Alt_CC"].ToString(), sp1altcc);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile1_Alternate"], sp1alternate) != 0)
            {
                string act = "Sub profile 1 alternate No changed from:" + Session["oSubprofile1_Alternate"] + "To:" + sp1alternate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Alternate No Updated", Session["oSubprofile1_Alternate"].ToString(), sp1alternate);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_CC"], sp2cc) != 0)
            {
                string act = "Sub Profile 2 Mobile code changed from:" + Session["oSubprofile2_CC"] + "To:" + sp2cc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Mobile Code Updated", Session["oSubprofile2_CC"].ToString(), sp2cc);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_Mobile"], sp2mobile) != 0)
            {
                string act = "Sub profile 2 Mobile No changed from:" + Session["oSubprofile2_Mobile"] + "To:" + sp2mobile;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Mobile No. Updated", Session["oSubprofile2_Mobile"].ToString(), sp2mobile);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_Alt_CC"], sp2altccc) != 0)
            {
                string act = "Sub Profile 2 Alternate code changed from:" + Session["oSubprofile2_Alt_CC"] + "To:" + sp2altccc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Alternate Code Updated", Session["oSubprofile2_Alt_CC"].ToString(), sp2altccc);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_Alternate"], sp2alternate) != 0)
            {
                string act = "Sub profile 2 alternate No changed from:" + Session["oSubprofile2_Alternate"] + "To:" + sp2alternate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Alternate No. Updated", Session["oSubprofile2_Alternate"].ToString(), sp2alternate);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile3_CC"], sp3cc) != 0)
            {
                string act = "Sub Profile 3 Mobile code changed from:" + Session["oSubprofile3_CC"] + "To:" + sp3cc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Mobile Code Updated", Session["oSubprofile3_CC"].ToString(), sp3cc);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile3_Mobile"], sp3mobile) != 0)
            {
                string act = "Sub profile 3 Mobile No changed from:" + Session["oSubprofile3_Mobile"] + "To:" + sp3mobile;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Mobile No. Updated", Session["oSubprofile3_Mobile"].ToString(), sp3mobile);
            }
            else { }



            if (String.Compare((string)Session["oSubprofile3_Alt_CC"], sp3altcc) != 0)
            {
                string act = "Sub Profile 3 Alternate code changed from:" + Session["oSubprofile3_Alt_CC"] + "To:" + sp3altcc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Alternate Code Updated", Session["oSubprofile3_Alt_CC"].ToString(), sp3altcc);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile3_Alternate"], sp3alternate) != 0)
            {
                string act = "Sub profile 3 Alternate No changed from:" + Session["oSubprofile3_Alternate"] + "To:" + sp3alternate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Alternate No. Updated", Session["oSubprofile3_Alternate"].ToString(), sp3alternate);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_CC"], sp4cc) != 0)
            {
                string act = "Sub Profile 4 Mobile code changed from:" + Session["oSubprofile4_CC"] + "To:" + sp4cc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Mobile Code Updated", Session["oSubprofile4_CC"].ToString(), sp4cc);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_Mobile"], sp4mobile) != 0)
            {
                string act = "Sub profile 4 Mobile No changed from:" + Session["oSubprofile4_Mobile"] + "To:" + sp4mobile;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Mobile No. Updated", Session["oSubprofile4_Mobile"].ToString(), sp4mobile);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_Alt_CC"], sp4altcc) != 0)
            {
                string act = "Sub Profile 4 Alternate code changed from:" + Session["oSubprofile4_Alt_CC"] + "To:" + sp4altcc;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Alternate Code Updated", Session["oSubprofile4_Alt_CC"].ToString(), sp4altcc);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile4_Alternate"], sp4alternate) != 0)
            {
                string act = "Sub profile 4 Alternate No changed from:" + Session["oSubprofile4_Alternate"] + "To:" + sp4alternate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Alternate No. Updated", Session["oSubprofile4_Alternate"].ToString(), sp4alternate);
            }
            else { }


            if (String.Compare((string)Session["oPrimary_Email"], pemail) != 0)
            {
                string act = "Primary email 1 changed from:" + Session["oPrimary_Email"] + "To:" + pemail;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Email1 Updated", Session["oPrimary_Email"].ToString(), pemail);
            }
            else { }

            if (String.Compare((string)Session["oPrimary_Email2"], pemail2) != 0)
            {
                string act = "Primary email 2 changed from:" + Session["oPrimary_Email2"] + "To:" + pemail2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Primary Email2 Updated", Session["oPrimary_Email2"].ToString(), pemail2);
            }
            else { }



            if (String.Compare((string)Session["oSecondary_Email"], semail) != 0)
            {
                string act = "Secondary email 1 changed from:" + Session["oSecondary_Email"] + "To:" + semail;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Email1 Updated", Session["oSecondary_Email"].ToString(), semail);
            }
            else { }


            if (String.Compare((string)Session["oSecondary_Email2"], semail2) != 0)
            {
                string act = "Secondary email 2 changed from:" + Session["oSecondary_Email2"] + "To:" + semail2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Secondary Email2 Updated", Session["oSecondary_Email2"].ToString(), semail2);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile1_Email"], sp1email) != 0)
            {
                string act = "Sub profile 1 email 1 changed from:" + Session["oSubprofile1_Email"] + "To:" + sp1email;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Email1 Updated", Session["oSubprofile1_Email"].ToString(), sp1email);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile1_Email2"], sp1email2) != 0)
            {
                string act = "Sub profile 1 email 2 changed from:" + Session["oSubprofile1_Email2"] + "To:" + sp1email2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile1 Email2 Updated", Session["oSubprofile1_Email2"].ToString(), sp1email2);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile2_Email"], sp2email) != 0)
            {
                string act = "Sub profile 2 email 1 changed from:" + Session["oSubprofile2_Email"] + "To:" + sp2email;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Email1 Updated", Session["oSubprofile2_Email"].ToString(), sp2email);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_Email2"], sp2email2) != 0)
            {
                string act = "Sub profile 2 email 2 changed from:" + Session["oSubprofile2_Email2"] + "To:" + sp2email2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile2 Email2 Updated", Session["oSubprofile2_Email2"].ToString(), sp2email2);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile3_Email"], sp3email) != 0)
            {
                string act = "Sub profile 3 email 1 changed from:" + Session["oSubprofile3_Email"] + "To:" + sp3email;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Email1 Updated", Session["oSubprofile3_Email"].ToString(), sp3email);
            }
            else { }


            if (String.Compare((string)Session["oSubprofile3_Email2"], sp3email2) != 0)
            {
                string act = "Sub profile 3 email 2 changed from:" + Session["oSubprofile3_Email2"] + "To:" + sp3email2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile3 Email2 Updated", Session["oSubprofile3_Email2"].ToString(), sp3email2);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile4_Email"], sp4email) != 0)
            {
                string act = "Sub profile 4 email 1 changed from:" + Session["oSubprofile4_Email"] + "To:" + sp4email;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Email1 Updated", Session["oSubprofile4_Email"].ToString(), sp4email);
            }
            else { }

            if (String.Compare((string)Session["oSubprofile4_Email2"], sp4email2) != 0)
            {
                string act = "Sub profile 4 email 2 changed from:" + Session["oSubprofile4_Email2"] + "To:" + sp4email2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString(), "Edit_contracts.aspx", "Sub Profile4 Email2 Updated", Session["oSubprofile4_Email2"].ToString(), sp4email2);
            }
            else { }




            string msg = "Details updated for Profile :" + " " + profile;
            // Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele()", true);
            //Response.Write("<script>pele();</script>");
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('hi')", true);

            string str = "<script>pele('" + msg + "');</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);

        }
        catch (Exception ex)
        {


            //MessageBox.Show("Error while Updating profile " + ex.Message);


            string msg = "Error while Updating profile " + ex.Message;
            //MessageBox.Show("Error while creating profile " + ex.Message);
            //string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

            //int delete = Queries2.Deleteprofileonerror(ProfileIDo);

            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

        }

    }



}