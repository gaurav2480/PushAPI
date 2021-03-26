﻿<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Indian_contracts_Edit1.aspx.cs" Inherits="_Default" %>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">

       <style>

           /*#check{
    display: none;
}*/
           #task-table td, th{
    border: 1px solid black;
  background-color: #fff;
    font-size:13px;

}
   #task-table th{
       background-color: lightskyblue;
   }

   #task-table1 td, th{
    border: 1px solid black;
  background-color: #fff;
    font-size:13px;

}
   #task-table1 th{
       background-color: lightskyblue;
   }
   
    #myBtn {
  display: block;
  position: fixed;
  bottom: 20px;
  right: 30px;
  z-index: 99;

  border: none;
  outline: none;
  background-color: #555;
  color: white;
  cursor: pointer;
  padding: 15px;
  border-radius: 10px;
}

#myBtn:hover {
  background-color: #555;
}  
#hidden1, #Label205,#ManagerDropDownList,#Label126,#SubVenueDropDownList,#Label159,#SubVenueGroupDropDownList,#LeadOfficeDropDownList,#Label127,
#lbltotaltax,#TotalTaxTextBox,#monthlyPremiumprotectionplanTextBox
{
    display:none;
}
</style>
<script src="jquery-3.2.1.min.js"></script>

<meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Contracts</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

  <link rel="stylesheet" href="/resources/demos/style.css">

  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#tabs").tabs();//{ disabled: [1, 2, 3, 4] }
          //$("#Btn1").on('click', function () {
          //    $("#tabs").tabs({ disabled: [2, 3, 4] });
          //    $("#tabs").tabs("option", "active", 1);
          //});
          //$("#Btn2").on('click', function () {
          //    $("#tabs").tabs({ disabled: [3, 4] });
          //    $("#tabs").tabs("option", "active", 2);
          //});

      });

      $(function () {
          $("#primarydobdatepicker,#secondarydobdatepicker,#sp1dobdatepicker,#sp2dobdatepicker,#sp3dobdatepicker,#sp4dobdatepicker,#arrivaldatedatepicker,#departuredatedatepicker, #invoicedateTextBox,#baladepamtdateTextBox,#dealdateTextBox").datepicker({
              changeMonth: true,
              changeYear: true,
              yearRange: "-100:+0",
              dateFormat: 'dd-mm-yy'

          });

          $("#tourdatedatepicker").datepicker({
              changeMonth: true,
              changeYear: true,
              yearRange: "-100:+0",
              dateFormat: 'yy-mm-dd'

          });
          $("#ReturnHomeDateTextBox").datepicker({
              changeMonth: true,
              changeYear: true,
              yearRange: "-100:+0",
              dateFormat: 'mm-dd-yy'

          });
      });

      /*$("#btn").on('click', function () {
          $("#tabs").tabs("option", "active", 2);
      });*/

  </script>
       <script type="text/javascript">

             function topFunction()
           {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location='<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

             }

           function Func() {
               $("#task-table1").hide();
           }

          
          


           function shows() {
               var checkbox1 = document.getElementById('chs');
               if (checkbox1.checked) {
                   document.getElementById("hidden").style.display = "block";
               }
               else {
                   document.getElementById("hidden").style.display = "none";
               }

           }
          

       </script>
 
            

<script type="text/javascript">


    function shows2() {
        //alert("shows2");
        var checkbox3 = document.getElementById('chs2');

        if (checkbox3.checked) {

            document.getElementById("panel").style.display = "block";

        }
        else {
            document.getElementById("panel").style.display = "none";

        }

    }

    function shows3() {
        //alert("shows2");
        var checkbox3 = document.getElementById('chs3');

        if (checkbox3.checked) {

            document.getElementById("panel2").style.display = "block";

        }
        else {
            document.getElementById("panel2").style.display = "none";

        }

    }

    function shows3a() {
        //alert("shows2");
        var checkbox3 = document.getElementById('chs3a');

        if (checkbox3.checked) {

            document.getElementById("panel3").style.display = "block";

        }
        else {
            document.getElementById("panel3").style.display = "none";

        }

    }

    function shows4a() {
        //alert("shows2");
        var checkbox3 = document.getElementById('chs4a');

        if (checkbox3.checked) {

            document.getElementById("panel4").style.display = "block";

        }
        else {
            document.getElementById("panel4").style.display = "none";

        }

    }
   






        function Procedure_Generation_Contract() {

            var contracttype = document.getElementById("contracttypeTextBox").value;
            var contractno = document.getElementById("contractnoTextBox").value;
            var ccode;

            if (contracttype == "Fractional" || contracttype == "Trade-In-Fractionals") {
                var firstyr = document.getElementById("fwfirstyrTextBox").value;
                var tenure = document.getElementById("fwtenureTextBox").value;
                //  var lastyr = parseInt(firstyr) + (tenure - 1);
                var lastyr = parseInt(firstyr) + (parseInt(tenure) - 1);
                if (isNaN(lastyr))
                {
                    document.getElementById("fwlastyrTextBox").value = "";

                }
                else {
                    document.getElementById("fwlastyrTextBox").value = lastyr;
                }

            }
            else {
                var firstyr = document.getElementById("firstyrTextBox").value;
                var tenure = document.getElementById("tenureTextBox").value;
                //var lastyr = parseInt(firstyr) + (tenure - 1);
                var lastyr = parseInt(firstyr) + (parseInt(tenure) - 1);
                if (isNaN(lastyr)) {
                    document.getElementById("lastyrTextBox").value = "";

                }
                else {
                    document.getElementById("lastyrTextBox").value = lastyr;
                }
 
            }
        }









        //function MCWaiver() {

        //    var ccode;
        //    if ((document.getElementById("mcRadioButtonList").checked == true)) {
        //        ccode = document.getElementById("contractnoTextBox").value + "W";
        //        document.getElementById("contractnoTextBox").value = ccode;
        //    }

        //    else {
        //        ccode1 = document.getElementById("contractnoTextBox").value;
        //        ccode = ccode1.slice(0, -1);
        //        document.getElementById("contractnoTextBox").value = ccode;


        //    }


        //}
        function pointscalculation() {

         //   alert("1st");
            var contracttype = document.getElementById("contracttypeTextBox").value;
        //    alert(contracttype);

         //   alert("inside");
            if (contracttype == "Points") {
           //     alert("points");
                var new_points = document.getElementById("newpointsrightTextBox").value;
                document.getElementById("totalptrightsTextBox").value = new_points;
            }
            else if (contracttype == "Trade-In-Points") {

                var tradeinpoints = document.getElementById("tipnopointsTextBox").value;
                document.getElementById("tipptsvalueTextBox").value = tradeinpoints;
                document.getElementById("tipactualptsvalueTextBox").value = tradeinpoints;
                var new_points = document.getElementById("newpointsrightTextBox").value;
                if (new_points == "" || new_points == "0") {
                    document.getElementById("totalptrightsTextBox").value = tradeinpoints;

                }
                else {
                    var totalpoints = parseInt(new_points) + parseInt(tradeinpoints);
                    document.getElementById("totalptrightsTextBox").value = totalpoints;
                }
            }
            else if (contracttype == "Trade-In-Weeks") {
                var tradeinpoints = document.getElementById("tipptsvalueTextBox").value;
                //    document.getElementById("tipptsvalueTextBox").value = tradeinpoints;
                document.getElementById("tipactualptsvalueTextBox").value = tradeinpoints;
                var new_points = document.getElementById("newpointsrightTextBox").value;
                if (new_points == "" || new_points == "0") {
                    document.getElementById("totalptrightsTextBox").value = tradeinpoints;

                }
                else {
                    var totalpoints = parseInt(new_points) + parseInt(tradeinpoints);
                    document.getElementById("totalptrightsTextBox").value = totalpoints;
                }

            }
            else if (contracttype == "Trade-In-Fractionals") {
                var oct = document.getElementById("oldcontracttypeDropDownList");
                var ocontracttype = oct.options[oct.selectedIndex].text;
                if (ocontracttype == "Points") {
                    var tradeinpoints = document.getElementById("tipnopointsTextBox").value;
                    document.getElementById("tipptsvalueTextBox").value = tradeinpoints;

                }
                else if (ocontracttype == "Weeks") {
                    var tradeinpoints = document.getElementById("tipnopointsTextBox").value;
                    document.getElementById("tipptsvalueTextBox").value = tradeinpoints;

                }
            }
        }

         
        function caldays(d, m, y) {


            var dmax;
            if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) {
                if (d > 31) {
                    dmax = 31;
                }
                else {
                    dmax = d
                }

            }
            else if (m == 4 || m == 6 || m == 9 || m == 11) {
                if (d > 30) {
                    dmax = 30;
                }
                else {
                    dmax = d
                }

            }
            else if (m == 2) {

                if ((y % 4 == 0) || (y % 400 == 0 && y % 100 != 0)) {
                    if (d > 29) {
                        dmax = 29;
                    }
                    else {
                        dmax = d
                    }

                }
                else {
                    if (d > 28) {
                        dmax = 28;
                    }
                    else {
                        dmax = d
                    }
                }

            }

            if (m == 1) {
                //alert('hi');
                m = '01';
            }
            else if (m == 2) {
                m = '02';
            }
            else if (m == 3) {
                m = '03';
            }
            else if (m == 4) {
                m = '04';
            }
            else if (m == 5) {
                m = '05';
            }
            else if (m == 6) {
                m = '06';
            }
            else if (m == 7) {
                m = '07';
            }
            else if (m == 8) {
                m = '08';
            }
            else if (m == 9) {
                m = '09';
            }



            if (dmax == 1) {
                //alert('hi');
                dmax = '01';
            }
            else if (dmax == 2) {
                dmax = '02';
            }
            else if (dmax == 3) {
                dmax = '03';
            }
            else if (dmax == 4) {
                dmax = '04';
            }
            else if (dmax == 5) {
                dmax = '05';
            }
            else if (dmax == 6) {
                dmax = '06';
            }
            else if (dmax == 7) {
                dmax = '07';
            }
            else if (dmax == 8) {
                dmax = '08';
            }
            else if (dmax == 9) {
                dmax = '09';
            }

            //var k = dmax+"-"+m+"-"+y;
            //var k = m + "-" + dmax + "-" + y;
            var k = dmax + "-" + m + "-" + y;
            // var k =  + "-" + m + "-" + y;
            //var k = y + "-" + m + "-" + dmax;
            //alert("gd"+k);

            // return k;

            //    var k = y + "-" + m + "-" + dmax;


            return k;



        }
        function re(noofInstall, remark, balamddate,curr) {
            // alert('hi');

            // alert(noofInstall + '     ' + remark);
            var am, k, l, m;
            var p = 0, d = 0;
            var da = "";
            var re = "";
            //11
            var temp = "", temp2 = 0;
            var arr = [];

            if (curr == "Rs." || curr == "Rs") {
 for (k = 1; k <= noofInstall ; k++) {


                //alert('s ' + temp2 + document.getElementById("t" + k + "1").value);
                for (m = 0; m < arr.length; m++) {
                    //alert('m '+m);
                    var kk = k + m;

                    if (document.getElementById("textBox_" + k + "1").value == arr[m]) {
                        temp2 = 1;
                    }
                }


                if (temp2 != 1) {

                    for (l = 1; l <= noofInstall ; l++) {



                        if (document.getElementById("textBox_" + k + "1").value == document.getElementById("textBox_" + l + "1").value) {
                            //alert('loop2');
                            p++;

                            da += document.getElementById("textBox_" + l + "2").value + ", ";


                        }


                    }

                }
                arr[k - 1] = document.getElementById("textBox_" + k + "1").value;
                temp = document.getElementById("textBox_" + k + "1").value;
                //alert(k+"  "+temp);
                //alert('arr   '+arr+'          '+p);
                if (temp2 != 1) {
                    // alert('inloop');
                    if (p > 1) {
                        //alert('p>1');
                        re += curr + "." + document.getElementById("textBox_" + k + "1").value + "/- X " + p + " INST ON " + da + " ";
                        // alert('p>1   '+re);
                    }
                    else {
                        // alert(' else p>1');
                        re += curr + "." + document.getElementById("textBox_" + k + "1").value + "/- " + " INST ON " + da + " ";//document.getElementById("t" + l + "2").value+",";
                        // alert(' else p>1 '+re);
                    }
                }

                p = 0; da = ""; temp2 = 0;
                // alert(re);

            }


}
else{
 for (k = 1; k <= noofInstall ; k++) {


                //alert('s ' + temp2 + document.getElementById("t" + k + "1").value);
                for (m = 0; m < arr.length; m++) {
                    //alert('m '+m);
                    var kk = k + m;

                    if (document.getElementById("textBox_" + k + "1").value == arr[m]) {
                        temp2 = 1;
                    }
                }


                if (temp2 != 1) {

                    for (l = 1; l <= noofInstall ; l++) {



                        if (document.getElementById("textBox_" + k + "1").value == document.getElementById("textBox_" + l + "1").value) {
                            //alert('loop2');
                            p++;

                            da += document.getElementById("textBox_" + l + "2").value + ", ";


                        }


                    }

                }
                arr[k - 1] = document.getElementById("textBox_" + k + "1").value;
                temp = document.getElementById("textBox_" + k + "1").value;
                //alert(k+"  "+temp);
                //alert('arr   '+arr+'          '+p);
                if (temp2 != 1) {
                    // alert('inloop');
                    if (p > 1) {
                        //alert('p>1');
                        re += curr + document.getElementById("textBox_" + k + "1").value + " X " + p + " INST ON " + da + " ";
                        // alert('p>1   '+re);
                    }
                    else {
                        // alert(' else p>1');
                        re += curr + document.getElementById("textBox_" + k + "1").value + " " + "INST ON " + da + " ";//document.getElementById("t" + l + "2").value+",";
                        // alert(' else p>1 '+re);
                    }
                }

                p = 0; da = ""; temp2 = 0;
                // alert(re);

            }


}
           

            re = re.slice(0, -3);

            //re = balamddate + re;
            var re1 = balamddate + re;

            //alert(re);
            document.getElementById(remark).value = re1;

        }
        function sum(numi, bamt) {

            var t23 = "";
            var pe;
            var sum = 0;
            var pam = bamt;
            //  var baldue = "";
            var baldue;
            var baldepamount = document.getElementById("baldepamtTextBox").value;
            var baldepdate = document.getElementById("baladepamtdateTextBox").value;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var curr;
            if (currency == "INR") {
                curr = "Rs.";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount + "/-" + "  on " + baldepdate + ",";
                }
            }
            else if (currency == "USD") {
                curr = "US$";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount + "  on " + baldepdate + ",";
                }
            }
            
            for (pe = 1; pe <= numi; pe++) {
                sum = sum + parseInt(document.getElementById("textBox_" + pe + "1").value);

                //baldue += curr + " " + document.getElementById("textBox_" + pe + "1").value + "/-" + " " + "on" + " " + document.getElementById("textBox_" + pe + "2").value + " ";

            }

            document.getElementById('totalamt').value = parseInt(pam) - sum;
            //document.getElementById("balancedueTextBox").value = baldue;

            var remarkt = "balancedueTextBox";
            re(numi, remarkt, baldue,curr);

        }
   function sumbaldep() {

            var contract_type = document.getElementById("contracttypeTextBox").value;
           
            var baldue;
            var baldepamount = document.getElementById("baldepamtTextBox").value;
            var baldepdate = document.getElementById("baladepamtdateTextBox").value;

            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var curr;
            if (currency == "INR") {
                curr = "Rs.";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount + "/-" + "  on " + baldepdate;// + ",";
                }
            }
            else if (currency == "USD") {
                curr = "US$";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount + "  on " + baldepdate;// + ",";
                }
            }
           

            //   baldue = baldue.slice(0, -1);

            if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals")
            {
                document.getElementById("balancedueTextBox").value = baldue;
            }
            else {
                document.getElementById("balancedueTextBox").value = baldue;

            }



        }
        function sumf(numi, bamt) {

            var t23 = "";
            var pe;
            var sum = 0;
            var pam = bamt;
            //   var baldue = "";
            var baldue;
            var baldepamount = document.getElementById("baldepamtTextBox").value;
            var baldepdate = document.getElementById("baladepamtdateTextBox").value;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var curr;
            if (currency == "INR") {
                curr = "Rs.";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount + "/-" + "  on " + baldepdate + ",";
                }
            }
            else if (currency == "USD") {
                curr = "US$";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount + "  on " + baldepdate + ",";
                }
            }
         

            for (pe = 1; pe <= numi; pe++) {
                sum = sum + parseInt(document.getElementById("textBox_" + pe + "1").value);

               // baldue += curr + " " + document.getElementById("textBox_" + pe + "1").value + "/-" + " " + "on" + " " + document.getElementById("textBox_" + pe + "2").value + " ";

            }

            document.getElementById('totalamt').value = parseInt(pam) - sum;
           

            var remarkt = "balancedueTextBox";
            re(numi, remarkt, baldue, curr);

        }
        function RemoveTextBox() {

            document.getElementById("installmentDIV").innerHTML = "";
        }

        function InstallmentGeneration(no, amt, balamt)
        {
            document.getElementById("instalheading").style.display = 'block';
            RemoveTextBox();
            //alert('points');

            var noinstallment = no;
            var instalmentamt = amt;
            var bal = balamt;

            //  var bal = document.getElementById("balinitialdepamtTextBox").value;
            //   document.getElementById('totalamt').value = bal;
            if (bal == "0" || bal == "" || bal == "NaN") {
                document.getElementById('totalamt').value = "0";
            }
            else {
                document.getElementById('totalamt').value = bal;

            }

            var baldue;
            var baldepamount = document.getElementById("baldepamtTextBox").value;
            var baldepdate = document.getElementById("baladepamtdateTextBox").value;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var curr;
            if (currency == "INR") {
                curr = "Rs.";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount + "/-" + " on " + baldepdate + ",";
                }
            }
            else if (currency == "USD") {
                curr = "US$";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount +  " on " + baldepdate + ",";
                }
            }
         

            var ch = document.getElementById("installmentDIV");
            var newdate;
            var date = "2017-10-30";
            var yr1 = parseInt(date.substring(0, 4));
            var mon1 = parseInt(date.substring(5, 7));
            var dt1 = parseInt(date.substring(8, 10));
            var amt = 2420;
            var amt2 = 2416;
            var smon1;
            var syr1, tsyr1;
            var s = yr1 + "-" + mon1 + "-" + dt1;

            var d = new Date();

 

            var n = d.getDate();
            var m = d.getMonth() + 2;
            var y = d.getFullYear();
            var currdate = y + "-" + m + "-" + n;

            //alert(currdate);
            var zy;

            smon1 = m;
            syr1 = y;
            var cr = parseInt(m);// + 1;

            if(noinstallment=="0"||noinstallment=="NaN")
            {

            }
            else
                {
            for (i = 1; i <= noinstallment ; i++) {
                //   alert(i);

                for (j = 1; j < 3; j++) {
                    //alert('f2');
                    var input = document.createElement("input");

                    input.type = 'text';
                    input.id = 'textBox_' + i + j;
                    input.name = 'textBox_' + i + j;
                    input.onkeyup = function () { sum(noinstallment, bal); };
                    input.className = 'space';
                    ch.appendChild(input);
                    var id1 = input.id;


                }//j loop
                var space1 = document.createElement("BR");
                var space2 = document.createElement("BR");
                ch.appendChild(space1);
                ch.appendChild(space2);
                var z = 'textBox_' + i + '1';
                document.getElementById(z).value = instalmentamt;
                // alert('out of if' + cr);
                if (cr > 12) {
                    cr = "1";
                    y = parseInt(y) + 1;
                    //alert(y);
                    newdate = y + "-" + cr + "-" + n;
                    zy = caldays(n, cr, y);
                    cr = parseInt(cr) + 1;
                    //cr = 1;
                }
                else {

                    newdate = y + "-" + cr + "-" + n;
                    zy = caldays(n, cr, y);
                    cr = parseInt(cr) + 1;
                    //alert('else '+ y);

                }
               
                newdate = zy;

                var indate = 'textBox_' + i + '2';

                document.getElementById(indate).value = newdate;


            }
        }
            var remarkt = "balancedueTextBox";
            re(noinstallment, remarkt, baldue, curr);


        }
         
        function RemoveTextBoxFractional() {
            //document.getElementById("installmentDIV").removeChild(installmentDIV.parentNode);
            document.getElementById("installmentDIV").innerHTML = "";
        }
        function InstallmentGenerationFractional(no, amt, balamt) {
            RemoveTextBoxFractional();
            //  alert(no);
            var noinstallment = no;
            var instalmentamt = amt;
            //  var baldue = "";
            var bal = balamt; //document.getElementById("balinitialdepamtTextBox").value;
            //    document.getElementById('totalamt').value = bal;
            if (bal == "0" || bal == "" || bal == "NaN") {
                document.getElementById('totalamt').value = "0";
            }
            else {
                document.getElementById('totalamt').value = bal;

            }
            var baldue;
            var baldepamount = document.getElementById("baldepamtTextBox").value;
            var baldepdate = document.getElementById("baladepamtdateTextBox").value;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var curr;
            if (currency == "INR") {
                curr = "Rs.";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount + "/-" + " on " + baldepdate + ",";
                }
            }
            else if (currency == "USD") {
                curr = "US$";
                if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
                    baldue = "";

                }
                else {
                    baldue = curr + " " + baldepamount +" on " + baldepdate + ",";
                }
            }
            
            var ch = document.getElementById("installmentDIV");
            var newdate;
            var date = "2017-10-30";
            var yr1 = parseInt(date.substring(0, 4));
            var mon1 = parseInt(date.substring(5, 7));
            var dt1 = parseInt(date.substring(8, 10));
            var amt = 2420;
            var amt2 = 2416;
            var smon1;
            var syr1, tsyr1;
            var s = yr1 + "-" + mon1 + "-" + dt1;

            var d = new Date();
            var n = d.getDate();
            var m = d.getMonth() + 2;
            var y = d.getFullYear();
            var zy;
            var currdate = y + "-" + m + "-" + n;
            //  var currdate = dt.setMonth(dt.getMonth() + noinstallment);
            smon1 = m;
            syr1 = y;
            var cr = parseInt(m);//+ 1;

            if(noinstallment=="0"||noinstallment=="NaN")
            {}
            else
                {
            for (i = 1; i <= noinstallment ; i++) {
                //   alert(i);

                for (j = 1; j < 3; j++) {
                    //alert('f2');
                    var input = document.createElement("input");

                    input.type = 'text';
                    input.id = 'textBox_' + i + j;
                    input.name = 'textBox_' + i + j;
                    input.className = 'space';
                    input.onkeyup = function () { sumf(noinstallment, bal); };
                    ch.appendChild(input);
                    var id1 = input.id;


                }//j loop
                var space1 = document.createElement("BR");
                var space2 = document.createElement("BR");
                ch.appendChild(space1);
                ch.appendChild(space2);
                var z = 'textBox_' + i + '1';
                document.getElementById(z).value = instalmentamt;

                if (cr > 12) {
                    cr = "1";
                    y = parseInt(y) + 1;
                    // alert(y);
                    newdate = y + "-" + cr + "-" + n;
                    zy = caldays(n, cr, y);
                    cr = parseInt(cr) + 1;
                }
                else {

                    newdate = y + "-" + cr + "-" + n;
                    zy = caldays(n, cr, y);
                    cr = parseInt(cr) + 1;

                }

                //var zy = caldays(n, cr, y);
                newdate = zy;

                var indate = 'textBox_' + i + '2';

                document.getElementById(indate).value = newdate;

               


            }
        }
            var remarkt = "balancedueTextBox";
            re(noinstallment, remarkt, baldue, curr);

        }
        function DisplayInstallmentAmt() {
            
            var contract_type = document.getElementById("contracttypeTextBox").value;
           
            var i;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            
            if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals") {
                if (checkvalue == "Finance") {
                    // var balpayable = document.getElementById("balamtpayableTextBox").value;
                    var balpayable = document.getElementById("balinitialdepamtTextBox").value;
                    var balamt = document.getElementById("balamtpayableTextBox").value;
                    var instalmentamt;
                    var noinstallment = document.getElementById("NoinstallmentTextBox").value;
                    if (noinstallment == "0" || noinstallment == null || noinstallment == "NaN")
                    {
                        instalmentamt = "0";

                    }
                    else if (isNaN(noinstallment)) {
                        instalmentamt = "0";
                    }
                    else
                    {

                        instalmentamt = Math.round(parseInt(balpayable) / parseInt(noinstallment));
                        document.getElementById("installmentamtTextBox").value = instalmentamt;
                        InstallmentGenerationFractional(noinstallment, instalmentamt, balpayable);
                    }

                }

                else if (checkvalue == "Non Finance") {
                    var balpayable = document.getElementById("balamtpayableTextBox").value;
                    var instalmentamt;
                    var balamt = document.getElementById("balamtpayableTextBox").value;
                    var noinstallment = document.getElementById("NoinstallmentTextBox").value;
                    if (noinstallment == "0" || noinstallment == null || noinstallment == "NaN")
                    {
                        instalmentamt = "0";

                    }
                    else if (isNaN(noinstallment)) {
                        instalmentamt = "0";
                    }
                    else {

                        instalmentamt = Math.round(parseInt(balpayable) / parseInt(noinstallment));
                        document.getElementById("installmentamtTextBox").value = instalmentamt;

                        InstallmentGenerationFractional(noinstallment, instalmentamt, balpayable);
                    }


                }


            }
            else
            { 

                if (checkvalue == "Finance")
                {
                    // var balpayable = document.getElementById("balamtpayableTextBox").value;
                    var balpayable = document.getElementById("balinitialdepamtTextBox").value;
                    var balamt = document.getElementById("balamtpayableTextBox").value;
                    var instalmentamt;
                    var noinstallment = document.getElementById("NoinstallmentTextBox").value;
                    if (noinstallment == "0" || noinstallment == null || noinstallment == "NaN")
                    {
                        instalmentamt = "0";

                    }
                    else if (isNaN(noinstallment)) {
                        instalmentamt = "0";
                    }
                    else {
                        instalmentamt = Math.round(parseInt(balpayable) / parseInt(noinstallment));

                        document.getElementById("installmentamtTextBox").value = instalmentamt;
                        InstallmentGeneration(noinstallment, instalmentamt, balpayable);
                    }

                }

                else if (checkvalue == "Non Finance")
                {
                     
                 
                    var baldep = document.getElementById("balinitialdepamtTextBox").value;
                    var instalmentamt;
                  var  balpayable = document.getElementById("balamtpayableTextBox").value
                  var noinstallment = document.getElementById("NoinstallmentTextBox").value;
                  if (noinstallment == "0" || noinstallment == null || noinstallment == "NaN")
                  {
                      instalmentamt = "0";

                  }
                  else if (isNaN(noinstallment)) {
                      instalmentamt = "0";
                  }
                  else {
                      instalmentamt = Math.round(parseInt(balpayable) / parseInt(noinstallment));
                      document.getElementById("installmentamtTextBox").value = instalmentamt;


                      InstallmentGeneration(noinstallment, instalmentamt, balpayable);
                  }

                }
            }

        }
        function RemoveSORAdditionalNames() {

            document.getElementById("sorDIV").innerHTML = "";
        }

        function SORAdditionalNames() {
            RemoveSORAdditionalNames();           
            var num = document.getElementById("asornoTextBox").value;
            var ch = document.getElementById("sorDIV");
            for (i = 1; i <= num ; i++) {
             //   for (j = 1; j <6; j++) {
                    for (j = 1; j < 3; j++) {
                        var input = document.createElement("textarea");
                         input.cols =45;
                        //input.rows =6;
                    input.type = 'text';
                    input.id = 'textBox1_' + i + j;
                    input.name = 'textBox1_' + i + j;
                    input.className = 'space';
                    ch.appendChild(input);
                    var id1 = input.id;


                }//j loop
                var space1 = document.createElement("BR");
                var space2 = document.createElement("BR");
                ch.appendChild(space1);
                ch.appendChild(space2);
                
                var indate = 'textBox1_' + i + '2';
            }


        }

        function lease_back(p1, p2) {
            var g1 = p1;
            var g2 = p2;
            var checkbox2 = document.getElementById(p1);

            if (checkbox2.checked) {

                document.getElementById(p2).value = 0;

            }
            else {
                document.getElementById(p2).value = "";
            }

        }

        function VoidAgreementamt() {
           

            var contract_type = document.getElementById("contracttypeTextBox").value;
           
          
            var oldcontno = document.getElementById("CanxContractNoTextBox").value;

          
          
            var depositmethod="";
       
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
      
            var curr;
            var strrmk;
            if (currency == "INR")
            {
                curr = "Rs.";
            }
            else if (currency == "USD")
            {
                curr = "$";
            }
       
            if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals")
            {
                var depamt = document.getElementById("intialdeppercentTextBox").value;

                var oamt = document.getElementById("pdoldamtTextBox").value;
                var actualdep = parseInt(depamt) - parseInt(oamt);
                //var strrmk = curr + oamt + "/-" + " " + "TRANSFERRED FROM " + oldcontno + " " + "& " + curr + actualdep + "/-" + " " + "BY " + depositmethod;
                //document.getElementById("remarksTextBox").value = strrmk;
               
                if (curr == "Rs." || curr == "INR" || curr == "Rs" || cur == "RS" || cur == "RS.")
                {
                    strrmk = curr + oamt + "/-" + " " + "TRANSFERRED FROM " + oldcontno + " " + "& " + curr + actualdep + "/-" + " " + "BY " + depositmethod;

                } else
                {
                    strrmk = curr + oamt + " " + "TRANSFERRED FROM " + oldcontno + " " + "& " + curr + actualdep + " " + "BY " + depositmethod;

                }
              
                document.getElementById("remarksTextBox").value = strrmk;
            }
            else
            {
            
                var depamt = document.getElementById("intialdeppercentTextBox").value;
                var oamt = document.getElementById("pdoldamtTextBox").value;
                var actualdep = parseInt(depamt) - parseInt(oamt);
           
                //  var strrmk = curr + oamt + "/-" + " " + "TRANSFERRED FROM " + oldcontno + " " + "& " + curr + actualdep + "/-" + " " + "BY " + depositmethod;
              
                if (curr == "Rs." || curr == "INR" || curr == "Rs" || cur == "RS" || cur == "RS.") {
                    strrmk = curr + oamt + "/-" + " " + "TRANSFERRED FROM " + oldcontno + " " + "& " + curr + actualdep + "/-" + " " + "BY " + depositmethod;

                }
                else
                {
                    strrmk = curr + oamt + " " + "TRANSFERRED FROM " + oldcontno + " " + "& " + curr + actualdep + " " + "BY " + depositmethod;
                }
               
            }
            document.getElementById("remarksTextBox").value = strrmk;
        }
        function EMICrownFinance() {

            var term = document.getElementById("noemiTextBox").value;
         
            var eurorate = document.getElementById("eurorateTextBox").value;
 
            var monthly_interest;
            var interest;
            if (term == "24")
            {
                interest = "12";
                monthly_interest = parseInt(interest) / 1200;
            }
            else if (term == "36") {
                interest = "17";
                monthly_interest = parseInt(interest) / 1200;
            }
            else if (term == "60") {
                interest = "19";
                monthly_interest = parseInt(interest) / 1200;
            }
            document.getElementById("interestrateTextBox").value = interest+"%";
        
            var principalloanamt;
            var LoanAmt;
            var contract_type = document.getElementById("contracttypeTextBox").value;
     
            if (contract_type == "Trade-In-Fractionals")
            {
              
               
                    var oldloanamt1;
                    var oldloanamt = document.getElementById("foldloanamountTextBox").value;
                    var newfinanceamt = document.getElementById("balamtpayableTextBox").value;
                    if (isNaN(oldloanamt)) {
                        oldloanamt1 = "0";
                        principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);

                    }
                    else if (oldloanamt == "0" || oldloanamt == "") {
                        oldloanamt1 = "0";
                        principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);
                    }
                    else {
                        principalloanamt = parseInt(oldloanamt) + parseInt(newfinanceamt);
                    }


               
            }
               
            else
            {

                principalloanamt = document.getElementById("balamtpayableTextBox").value;
            }

     

            LoanAmt = (parseInt(principalloanamt) * parseFloat(eurorate));
            

            document.getElementById("loanamtINEuroTextBox").value = LoanAmt;

            var igst = "0";
            var emiamt = ((parseFloat(LoanAmt) * monthly_interest) / (1 - Math.pow(1 / (1 + monthly_interest), parseInt(term)))).toFixed(2);

            //  alert("Emi:" + (emiamt));
            document.getElementById("emiamtTextBox").value = emiamt;

            var caldocfee = "200";
            //  alert("Acceptance:"+caldocfee);
            document.getElementById("findocfeeTextBox").value = caldocfee;


            var caligst = (parseFloat(emiamt) * 0.10).toFixed(2);

            //   alert(("Monthly premium:"+caligst));
            document.getElementById("monthlyPremiumprotectionplanTextBox").value = caligst;


        }
        function EMICalculation_fractional()
        {
           // var emaival = "60";
          //  document.getElementById("noemiTextBox").value = emaival;            
             var emi = document.getElementById("noemiTextBox").value;
           
             var principalloanamt;
            var months = "12";
            var term = parseInt(emi) / parseInt(months);
            //  alert(term)
            var rateofinterest = "12%";// "11%";
            document.getElementById("interestrateTextBox").value = rateofinterest;
    
            var contract_type = document.getElementById("contracttypeTextBox").value;
            var oct = document.getElementById("oldcontracttypeDropDownList");
            var ocontract_type = oct.options[oct.selectedIndex].text;
            var newfinanceamt = document.getElementById("balamtpayableTextBox").value;
            if (contract_type == "Trade-In-Fractionals") {
                if (ocontract_type == "Points")
                {
                    var oldloanamt1;
                    var oldloanamt = document.getElementById("foldloanamountTextBox").value;//
                    
              //      var newfinanceamt = document.getElementById("balamtpayableTextBox").value;
                    if (isNaN(oldloanamt)) {
                        oldloanamt1 = "0";
                        principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);

                    }
                    else if (oldloanamt == "0" || oldloanamt == "") {
                        oldloanamt1 = "0";
                        principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);
                    }
                    else {

                        principalloanamt = parseInt(oldloanamt) + parseInt(newfinanceamt);

                    }
                   

                }
                else if (ocontract_type == "Weeks") {
                    var oldloanamt1;
                    var oldloanamt = document.getElementById("foldloanamountTextBox").value;
                  //  var newfinanceamt = document.getElementById("balamtpayableTextBox").value;
                    if (isNaN(oldloanamt)) {
                        oldloanamt1 = "0";
                        principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);

                    }
                    else if (oldloanamt == "0" || oldloanamt == "") {
                        oldloanamt1 = "0";
                        principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);
                    }
                    else {

                        principalloanamt = parseInt(oldloanamt) + parseInt(newfinanceamt);

                    }

                }
                else if (ocontract_type == "Fractionals") {
                    var oldloanamt1;
                    var oldloanamt = document.getElementById("foldloanamountTextBox").value; 
                 
                    if (isNaN(oldloanamt)) {
                        oldloanamt1 = "0";
                        principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);

                    }
                    else if (oldloanamt == "0" || oldloanamt == "") {
                        oldloanamt1 = "0";
                        principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);
                    }
                    else {

                        principalloanamt = parseInt(oldloanamt) + parseInt(newfinanceamt);

                    }
                }
            }
            else {
                principalloanamt = document.getElementById("balamtpayableTextBox").value;
            }

            var interest = parseInt(rateofinterest) / 100;
            //  alert(interest);
          //  var principalloanamt = document.getElementById("balamtpayableTextBox").value;
            //  alert(principalloanamt);
            var documentationfee = "1";
            var igst = "18";
            document.getElementById("isgtrateTextBox").value = igst+"%";
            var r = parseFloat(interest) / parseInt(months);
            var exponent = parseInt(term) * parseInt(months);
            var emiamt = Math.round(parseInt(principalloanamt) * parseFloat(r) * (Math.pow((1 + parseFloat(r)), parseInt(exponent))) / ((Math.pow((1 + parseFloat(r)), parseInt(exponent))) - 1));
          
            document.getElementById("emiamtTextBox").value = emiamt;
       
            var caldocfee = parseInt(newfinanceamt) * (parseInt(documentationfee) / 100);
              
            document.getElementById("findocfeeTextBox").value = caldocfee;
               

            var caligst = Math.round(parseInt(caldocfee) * (parseInt(igst) / 100));

              
            document.getElementById("igstamtTextBox").value = caligst;
            var startvalue, endvalue, financeno;
            var contract_type = document.getElementById("contracttypeTextBox").value;
            var v = document.getElementById("VenueDropDownList");
            var venue = v.options[v.selectedIndex].text;
          //  var lastno = document.getElementById("lastfingennoTextBox").value;

        }


     
    /*  function EMICalculation()
        {
            //var emaival = "60";
            //document.getElementById("noemiTextBox").value = emaival;
            var emi = document.getElementById("noemiTextBox").value;

            var months = "12";
            var term = parseInt(emi) / parseInt(months);
            //  alert(term)
            var rateofinterest = "19%";
            document.getElementById("interestrateTextBox").value = rateofinterest;
            var interest = parseInt(rateofinterest) / 100;
            //  alert(interest);
            var principalloanamt = document.getElementById("balamtpayableTextBox").value;
            //  alert(principalloanamt);
            var documentationfee = "1";
            var igst = "18";
            document.getElementById("isgtrateTextBox").value= igst+"%";          
           
            var r = parseFloat(interest) / parseInt(months);
            var exponent = parseInt(term) * parseInt(months);
            var emiamt = Math.round(parseInt(principalloanamt) * parseFloat(r) * (Math.pow((1 + parseFloat(r)), parseInt(exponent))) / ((Math.pow((1 + parseFloat(r)), parseInt(exponent))) - 1));
            //  alert(emiamt);
            document.getElementById("emiamtTextBox").value = emiamt;
            //  alert(emiamt);
            var caldocfee = parseInt(principalloanamt) * (parseInt(documentationfee) / 100);
            //  alert(caldocfee);
            document.getElementById("findocfeeTextBox").value = caldocfee;
            //  alert(igst);

            var caligst = Math.round(parseInt(caldocfee) * (parseInt(igst) / 100));

            //   alert(caligst);
            document.getElementById("igstamtTextBox").value = caligst;
            var startvalue, endvalue, financeno;
            var contract_type = document.getElementById("contracttypeTextBox").value;
            var v = document.getElementById("VenueDropDownList");
            var venue = v.options[v.selectedIndex].text;
            

      }*/

      function EMICalculation() {
          //var emaival = "60";
          //document.getElementById("noemiTextBox").value = emaival;
          var contract_type = document.getElementById("contracttypeTextBox").value;
          var emi = document.getElementById("noemiTextBox").value;

          var months = "12";
          var term = parseInt(emi) / parseInt(months);
          //  alert(term)
          var rateofinterest = "19%";
          document.getElementById("interestrateTextBox").value = rateofinterest;
          var interest = parseInt(rateofinterest) / 100;
          //  alert(interest);
          var principalloanamt, oldloanamt1;// = document.getElementById("balamtpayableTextBox").value;
          var newfinanceamt = document.getElementById("balamtpayableTextBox").value;
          var oldloanamt = document.getElementById("foldloanamountTextBox").value;
          //  alert(principalloanamt);
          var documentationfee = "1";
          var igst = "18";
       //   alert(contract_type);
          document.getElementById("isgtrateTextBox").value = igst + "%";

          if (contract_type == "Trade-In-Points" || contract_type == "Trade-In-Weeks")
          {
              if(isNaN(oldloanamt))
              {
                  oldloanamt1 = "0";
                  principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);

              }
              else if (oldloanamt == "0" || oldloanamt == "") {
                  oldloanamt1 = "0";
                  principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);
              }
              else
              {
                 // principalloanamt =  parseInt(newfinanceamt);
       principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);
              }
          }
          else
          {
              principalloanamt = parseInt(newfinanceamt);
          }
         // alert(principalloanamt);
          var r = parseFloat(interest) / parseInt(months);
          var exponent = parseInt(term) * parseInt(months);
          var emiamt = Math.round(parseInt(principalloanamt) * parseFloat(r) * (Math.pow((1 + parseFloat(r)), parseInt(exponent))) / ((Math.pow((1 + parseFloat(r)), parseInt(exponent))) - 1));
          //  alert(emiamt);
          document.getElementById("emiamtTextBox").value = emiamt;
          //  alert(emiamt);
          var caldocfee = parseInt(newfinanceamt) * (parseInt(documentationfee) / 100);
          //  alert(caldocfee);
          document.getElementById("findocfeeTextBox").value = caldocfee;
          //  alert(igst);

          var caligst = Math.round(parseInt(caldocfee) * (parseInt(igst) / 100));

          document.getElementById("igstamtTextBox").value = caligst;
          var startvalue, endvalue, financeno;
   
          var v = document.getElementById("VenueDropDownList");
          var venue = v.options[v.selectedIndex].text;


      }


   /*     function EMICalculation() {
            var contract_type = document.getElementById("contracttypeTextBox").value;
            var oldloanamt1;
           
            var principalloanamt;// = document.getElementById("balamtpayableTextBox").value;
            var emi = document.getElementById("noemiTextBox").value;
            var term = parseInt(emi) / parseInt(months);
            var rateofinterest = "19%";
            document.getElementById("interestrateTextBox").value = rateofinterest;
            var interest = parseInt(rateofinterest) / 100;   
                   
            var documentationfee = "1";
            var igst = "18";
            document.getElementById("isgtrateTextBox").value = igst + "%";
            var newfinanceamt = document.getElementById("balamtpayableTextBox").value;
            if (contract_type == "Trade-In-Points" || contract_type == "Trade-In-Weeks")
            {
                var oldloanamt = document.getElementById("foldloanamountTextBox").value;
                alert(oldloanamt);
                if (isNaN(oldloanamt)) {
                    oldloanamt1 = "0";
                    principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);

                }
                else if (oldloanamt == "0" || oldloanamt == "") {
                    oldloanamt1 = "0";
                    principalloanamt = parseInt(oldloanamt1) + parseInt(newfinanceamt);
                }
                else {

                    principalloanamt = parseInt(oldloanamt) + parseInt(newfinanceamt);

                }
            }
            else
            {
                principalloanamt=document.getElementById("balamtpayableTextBox").value;
            }
            var r = parseFloat(interest) / parseInt(months);
            var exponent = parseInt(term) * parseInt(months);
            var emiamt = Math.round(parseInt(principalloanamt) * parseFloat(r) * (Math.pow((1 + parseFloat(r)), parseInt(exponent))) / ((Math.pow((1 + parseFloat(r)), parseInt(exponent))) - 1));
            document.getElementById("emiamtTextBox").value = emiamt;       
            var caldocfee = parseInt(newfinanceamt) * (parseInt(documentationfee) / 100);
            document.getElementById("findocfeeTextBox").value = caldocfee;
            var caligst = Math.round(parseInt(caldocfee) * (parseInt(igst) / 100)); 
            document.getElementById("igstamtTextBox").value = caligst;
            var startvalue, endvalue, financeno;
            var contract_type = document.getElementById("contracttypeTextBox").value;
            var v = document.getElementById("VenueDropDownList");
            var venue = v.options[v.selectedIndex].text;
     

        }*/

        function LoanEMICalculation() {
            var contract_type = document.getElementById("contracttypeTextBox").value;
            var ent1 = document.getElementById("financemethodDropDownList");
            var financetype = ent1.options[ent1.selectedIndex].text;
            
            if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals")
            {
                if (financetype == "Pashuram Finance")
                {
                    EMICalculation_fractional();
                }
                else if(financetype == "Crown Finance")
                {
                    EMICrownFinance();
                }
            }
            else
            {
                if (financetype == "Pashuram Finance") {
                    EMICalculation();
                }
                else if (financetype == "Crown Finance")
                {
                    EMICrownFinance();
                }
                
            }

        }
        function InitialBalCalculation()
        {
            var contract_type = document.getElementById("contracttypeTextBox").value;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }

            if (contract_type == "Fractional")
            {
                var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                var depositamt = document.getElementById("intialdeppercentTextBox").value;
                var intitalbal = document.getElementById("balinitialdepamtTextBox").value;
                var intitaldepbal = document.getElementById("baldepamtTextBox").value;
                var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                if (checkvalue == "Finance")
                {
                    if (isNaN(percent)) {
                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';


                        document.getElementById("balamtpayableTextBox").value = "0";
                        var totalbalpayable = "0";
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var noinstallment = "0";
                        document.getElementById("NoinstallmentTextBox").value = noinstallment;
                        var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                        if (isNaN(instalmentamt)) {

                            document.getElementById("installmentamtTextBox").value = "0";
                        }

                    }
                    else if (percent < 10) {

                        var bal = document.getElementById("baldepamtTextBox").value;
                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(intitalbal));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var totalval = "0";
                        document.getElementById("ftradeinvalueTextBox").value = totalval;
                        document.getElementById("ftotalvalueTextBox").value = totalval;

                    }
                    else {

                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var totalval = "0";
                        document.getElementById("ftradeinvalueTextBox").value = totalval;
                        document.getElementById("ftotalvalueTextBox").value = totalval;
                    }


                    if (currency == "INR" || currency == "Rs.") {
                        EMICalculation_fractional();
                    }
                    else {
                        EMICrownFinance();
                    }


                    DisplayInstallmentAmt();

                }
                else {
                    if (isNaN(percent)) {
                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';


                        document.getElementById("balamtpayableTextBox").value = "0";
                        var totalbalpayable = "0";
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var noinstallment = "0";
                        document.getElementById("NoinstallmentTextBox").value = noinstallment;
                        var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                        if (isNaN(instalmentamt)) {

                            document.getElementById("installmentamtTextBox").value = "0";
                        }

                    }
                    else if (percent < 10) {

                        var bal = document.getElementById("baldepamtTextBox").value;
                        var intitalbal2="0";
                        document.getElementById("balinitialdepamtTextBox").value = intitalbal2;
                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(intitalbal2));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var totalval = "0";
                        document.getElementById("ftradeinvalueTextBox").value = totalval;
                        document.getElementById("ftotalvalueTextBox").value = totalval;

                    }
                    else {
                        var intitalbal2 = "0";
                        document.getElementById("balinitialdepamtTextBox").value = intitalbal2;
                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal2));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var totalval = "0";
                        document.getElementById("ftradeinvalueTextBox").value = totalval;
                        document.getElementById("ftotalvalueTextBox").value = totalval;
                    }

                     


                    DisplayInstallmentAmt();
                }
            }
            else if (contract_type == "Trade-In-Fractionals")
            {
                
                var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;               
                var depositamt = document.getElementById("intialdeppercentTextBox").value;             
                var intitalbal = document.getElementById("balinitialdepamtTextBox").value;              
                var intitaldepbal = document.getElementById("baldepamtTextBox").value;
 

                var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
              
                if (checkvalue == "Finance")
                {
                    if (isNaN(percent)) {
                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';


                        document.getElementById("balamtpayableTextBox").value = "0";
                        var totalbalpayable = "0";
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var noinstallment = "0";
                        document.getElementById("NoinstallmentTextBox").value = noinstallment;
                        var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                        if (isNaN(instalmentamt)) {

                            document.getElementById("installmentamtTextBox").value = "0";
                        }

                    }
                    else if (percent < 10) {
                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';
                        var bal = document.getElementById("baldepamtTextBox").value;// bal of intital dep(if <10)

                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(intitalbal));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;




                        var oldloanamt = document.getElementById("foldloanamountTextBox").value;
                        var loan1;
                        if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                            loan1 = "0";
                            var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                        }
                        else {
                            var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                        }




                        document.getElementById("balanceTextBox").value = totalbalpayable;



                    }
                    else {

                        document.getElementById("lblbaladepamt").style.display = 'none';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamtdate").style.display = 'none';
                        document.getElementById("baladepamtdateTextBox").style.display = 'none';

                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal));
                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);



                        var oldloanamt = document.getElementById("foldloanamountTextBox").value;
                        var loan1;
                        if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                            loan1 = "0";
                            var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                        }
                        else {
                            var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                        }



                    }

                    if (currency == "INR" || currency == "Rs.") {
                        EMICalculation_fractional();
                    }
                    else {
                        EMICrownFinance();
                    }


                    DisplayInstallmentAmt();
                }
                else if(checkvalue=="Non Finance")
                {
                    if (isNaN(percent)) {
                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';


                        document.getElementById("balamtpayableTextBox").value = "0";
                        var totalbalpayable = "0";
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var noinstallment = "0";
                        document.getElementById("NoinstallmentTextBox").value = noinstallment;
                        var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                        if (isNaN(instalmentamt)) {

                            document.getElementById("installmentamtTextBox").value = "0";
                        }

                    }
                    else if (percent < 10)
                    {
                       
                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';
                        var baldepamt;
                        var bal = document.getElementById("baldepamtTextBox").value;
                        if (bal = "")
                        {
                              baldepamt = "0";
                        }
                        else
                        {
                            baldepamt = document.getElementById("baldepamtTextBox").value;
                        }
                       
                       var intitalbal2 = "0";                         

                        document.getElementById("balinitialdepamtTextBox").value = intitalbal2;
                         
                     var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(baldepamt) + parseInt(intitalbal2));
                        
                        document.getElementById("balamtpayableTextBox").value = intitalbal1;




                        var oldloanamt = document.getElementById("foldloanamountTextBox").value;
                        var loan1;
                        if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                            loan1 = "0";
                            var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                        }
                        else {
                            var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                        }




                        document.getElementById("balanceTextBox").value = totalbalpayable;



                    }
                    else {
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamtdate").style.display = 'none';
                        document.getElementById("baladepamtdateTextBox").style.display = 'none';
                        var intitalbal2 = "0";
                        document.getElementById("balinitialdepamtTextBox").value = intitalbal2;
                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal2));
                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);



                        var oldloanamt = document.getElementById("foldloanamountTextBox").value;
                        var loan1;
                        if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                            loan1 = "0";
                            var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                        }
                        else {
                            var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                        }



                    }

                  //  EMICalculation_fractional();

                    DisplayInstallmentAmt();
                }

            }
            else {

               

                var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                var depositamt = document.getElementById("intialdeppercentTextBox").value;//deposit amt
                var intitalbal = document.getElementById("balinitialdepamtTextBox").value;

                var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                if (checkvalue == "Finance")
                {
                    if (isNaN(percent)) {
                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';


                        document.getElementById("balamtpayableTextBox").value = "0";
                        var totalbalpayable = "0";
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var noinstallment = "0";
                        document.getElementById("NoinstallmentTextBox").value = noinstallment;
                        var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                        if (isNaN(instalmentamt)) {

                            document.getElementById("installmentamtTextBox").value = "0";
                        }



                    }
                    else if (percent < 10) {

                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';
                        var bal = document.getElementById("baldepamtTextBox").value;// bal of intital dep(if <10)

                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(intitalbal));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                    }
                    else {

                        document.getElementById("lblbaladepamt").style.display = 'none';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamtdate").style.display = 'none';
                        document.getElementById("baladepamtdateTextBox").style.display = 'none';
                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                    }
                    if (currency == "INR" || currency == "Rs.") {
                        EMICalculation();
                    }
                    else {
                        EMICrownFinance();
                    }

                    
                    DisplayInstallmentAmt();
                }
                else if (checkvalue == "Non Finance")
                {

                    if (isNaN(percent)) {
                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';


                        document.getElementById("balamtpayableTextBox").value = "0";
                        var totalbalpayable = "0";
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                        var noinstallment = "0";
                        document.getElementById("NoinstallmentTextBox").value = noinstallment;
                        var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                        if (isNaN(instalmentamt)) {

                            document.getElementById("installmentamtTextBox").value = "0";
                        }



                    }
                    else if (percent < 10) {

                        document.getElementById("lblbaladepamt").style.display = 'block';
                        document.getElementById("baldepamtTextBox").style.display = 'block';
                        document.getElementById("lblbaladepamtdate").style.display = 'block';
                        document.getElementById("baladepamtdateTextBox").style.display = 'block';
                        var bal = document.getElementById("baldepamtTextBox").value;// bal of intital dep(if <10)
                        var intitalbal2 = "0";
                        document.getElementById("balinitialdepamtTextBox").value = intitalbal2;
                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(intitalbal2));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                    }
                    else {

                        document.getElementById("lblbaladepamt").style.display = 'none';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamtdate").style.display = 'none';
                        document.getElementById("baladepamtdateTextBox").style.display = 'none';
                        var intitalbal2 = "0";
                        document.getElementById("balinitialdepamtTextBox").value = intitalbal2;
                        var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal2));

                        document.getElementById("balamtpayableTextBox").value = intitalbal1;
                        var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balanceTextBox").value = totalbalpayable;
                    }
                  
                    DisplayInstallmentAmt();
                }
                
            }



        }

        function AmountBreakupCalculation() {

             

            var contract_type = document.getElementById("contracttypeTextBox").value;
           
            //get venue name
            var v = document.getElementById("VenueDropDownList");
            var venue = v.options[v.selectedIndex].text;
            //get venue grp name
            var vg = document.getElementById("GroupVenueDropDownList");
            var venuegroup = vg.options[vg.selectedIndex].text;
            var m = document.getElementById("MarketingProgramDropDownList");
            var mktg = m.options[m.selectedIndex].text;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            var nl = document.getElementById("PrimarynationalityDropDownList");
            var nationality = nl.options[nl.selectedIndex].text;
 

            if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals") {
                if (nationality == "Indian" || nationality == "INDIAN" || nationality == "OCI" || nationality == "PIO") {
                    if (checkvalue == "Finance") {
                        if (currency == "INR")
                        {

                           
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            
                            
                            //enter initial deposit amt in respective dep textbox
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                           // if(isNaN(percent))
                           // {
                           //     document.getElementById("lblbaladepamt").style.display = 'block';
                           //     document.getElementById("baldepamtTextBox").style.display = 'block';
                           //     document.getElementById("lblbaladepamtdate").style.display = 'block';
                           //     document.getElementById("baladepamtdateTextBox").style.display = 'block';


                           //     document.getElementById("balamtpayableTextBox").value = "0";
                           //     var totalbalpayable = "0";
                           //     document.getElementById("balanceTextBox").value = totalbalpayable;
                           //     var noinstallment = "0";
                           //     document.getElementById("NoinstallmentTextBox").value = noinstallment;
                           //     var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                           //     if (isNaN(instalmentamt)) {

                           //         document.getElementById("installmentamtTextBox").value = "0";
                           //     }


                               
                           // }
                            //else  if (percent < 10)
                            if (percent < 10)
                            {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                              

                                var intitalbal = parseInt(totalpurchase) - ((parseInt(depositamt) + parseInt(bal) + parseInt(bald)));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                           else
                           {

                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }


                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';

                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                             InitialBalCalculation();


                                                  
                             

                        }
                        else if (currency == "USD") {
                          
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';

                            var depositamt = document.getElementById("intialdeppercentTextBox").value;



                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);

                            if (isNaN(percent))
                            {
                                document.getElementById("balamtpayableTextBox").value = "0";
                                var totalbalpayable = "0";
                                document.getElementById("balanceTextBox").value = totalbalpayable;
                                var noinstallment = "0";
                                document.getElementById("NoinstallmentTextBox").value = noinstallment;
                                var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                                if (isNaN(instalmentamt)) {

                                    document.getElementById("installmentamtTextBox").value = "0";
                                }

                            }

                           else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;

                                // var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                                var intitalbal = parseInt(totalpurchase) - ((parseInt(depositamt) + parseInt(bal) + parseInt(bald)));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                //var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }




                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();
                        }
                    }
                    else if (checkvalue == "Non Finance")
                    {
                        if (currency == "INR") {

                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                           
                            
                        
                           

                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            
                            ////if (isNaN(Percent))
                            //{
                            //    alert("1");
                            //    document.getElementById("balamtpayableTextBox").value = "0";
                            //    var totalbalpayable = "0";
                            //    document.getElementById("balanceTextBox").value = totalbalpayable;
                            //    var noinstallment = "0";
                            //    document.getElementById("NoinstallmentTextBox").value = noinstallment;
                            //    var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                            //    if (isNaN(instalmentamt)) {

                            //        document.getElementById("installmentamtTextBox").value = "0";
                            //    }

                            //}
                            //else if (percent < 10
                            if (percent < 10)
                            {
                               
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            
                                var bal = document.getElementById("baldepamtTextBox").value;
                              
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(bald));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else
                            {
                                 
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }

                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'none';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();
                        }
                        else if (currency == "USD") {

                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';

                            var depositamt = document.getElementById("intialdeppercentTextBox").value;

                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            //if (isNaN(percent))
                            //{
                            //    document.getElementById("balamtpayableTextBox").value = "0";
                            //    var totalbalpayable = "0";
                            //    document.getElementById("balanceTextBox").value = totalbalpayable;
                            //    var noinstallment = "0";
                            //    document.getElementById("NoinstallmentTextBox").value = noinstallment;
                            //    var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                            //    if (isNaN(instalmentamt)) {

                            //        document.getElementById("installmentamtTextBox").value = "0";
                            //    }

                            //}
                            //else if (percent < 10) {
                          if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;

                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(bald));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }




                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';

                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'none';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();

                        }

                    }
                }
                else {
                    if (checkvalue == "Finance") {
                        if (currency == "INR") {
                           

                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;


                            //enter initial deposit amt in respective dep textbox
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent))
                            {
                                document.getElementById("balamtpayableTextBox").value = "0";
                                var totalbalpayable = "0";
                                document.getElementById("balanceTextBox").value = totalbalpayable;
                                var noinstallment = "0";
                                document.getElementById("NoinstallmentTextBox").value = noinstallment;
                                var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                                if (isNaN(instalmentamt)) {

                                    document.getElementById("installmentamtTextBox").value = "0";
                                }

                            }
                            else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;


                                var intitalbal = parseInt(totalpurchase) - ((parseInt(depositamt) + parseInt(bal) + parseInt(bald)));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {

                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }


                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';

                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();
                        }
                        else if (currency == "USD") {
                             
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';

                            var depositamt = document.getElementById("intialdeppercentTextBox").value;



                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent))
                            {
                                document.getElementById("balamtpayableTextBox").value = "0";
                                var totalbalpayable = "0";
                                document.getElementById("balanceTextBox").value = totalbalpayable;
                                var noinstallment = "0";
                                document.getElementById("NoinstallmentTextBox").value = noinstallment;
                                var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                                if (isNaN(instalmentamt)) {

                                    document.getElementById("installmentamtTextBox").value = "0";
                                }

                            }
                           else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;

                                // var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                                var intitalbal = parseInt(totalpurchase) - ((parseInt(depositamt) + parseInt(bal) + parseInt(bald)));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                //var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }




                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();

                        }
                    }
                    else if (checkvalue == "Non Finance") {
                        if (currency == "INR") {

                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';

                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent))
                            {
                                document.getElementById("balamtpayableTextBox").value = "0";
                                var totalbalpayable = "0";
                                document.getElementById("balanceTextBox").value = totalbalpayable;
                                var noinstallment = "0";
                                document.getElementById("NoinstallmentTextBox").value = noinstallment;
                                var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                                if (isNaN(instalmentamt)) {

                                    document.getElementById("installmentamtTextBox").value = "0";
                                }

                            }
                           else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;

                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(bald));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {

                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }

                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';

                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'none';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();
                        }
                        else if (currency == "USD") {

                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';

                            var depositamt = document.getElementById("intialdeppercentTextBox").value;

                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent))
                            {
                                document.getElementById("balamtpayableTextBox").value = "0";
                                var totalbalpayable = "0";
                                document.getElementById("balanceTextBox").value = totalbalpayable;
                                var noinstallment = "0";
                                document.getElementById("NoinstallmentTextBox").value = noinstallment;
                                var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                                if (isNaN(instalmentamt)) {

                                    document.getElementById("installmentamtTextBox").value = "0";
                                }

                            }
                           else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;

                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(bald));

                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }




                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';

                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'none';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();

                        }

                    }
                }
            }//END of contract type 
            else {
                if (nationality == "Indian" || nationality == "INDIAN" || nationality == "OCI" || nationality == "PIO") {
                    if (checkvalue == "Finance") {
                        if (currency == "INR") {
                             
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                         
                            document.getElementById("lblbaladepamt").style.display = 'none';
                        
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                     

                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent))
                            {
                                document.getElementById("balamtpayableTextBox").value = "0";
                                var totalbalpayable = "0";
                                document.getElementById("balanceTextBox").value = totalbalpayable;
                                var noinstallment = "0";
                                document.getElementById("NoinstallmentTextBox").value = noinstallment;
                                var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                                if (isNaN(instalmentamt)) {

                                    document.getElementById("installmentamtTextBox").value = "0";
                                }

                            }

                            else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                               
                             
                                var intitalbal = parseInt(totalpurchase) - ((parseInt(depositamt) + parseInt(bal)+ parseInt(bald)));
                        
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {

                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt)+ parseInt(bald));
                               
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
 

                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                           
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                              InitialBalCalculation();

                        }
                        else if (currency == "USD") {
                            
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';
                             
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                         

                          
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent))
                            {
                                document.getElementById("balamtpayableTextBox").value = "0";
                                var totalbalpayable = "0";
                                document.getElementById("balanceTextBox").value = totalbalpayable;
                                var noinstallment = "0";
                                document.getElementById("NoinstallmentTextBox").value = noinstallment;
                                var instalmentamt = Math.round(parseInt(totalbalpayable) / parseInt(noinstallment));
                                if (isNaN(instalmentamt)) {

                                    document.getElementById("installmentamtTextBox").value = "0";
                                }

                            }
                           else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                                
                                // var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                                var intitalbal = parseInt(totalpurchase) - ((parseInt(depositamt) + parseInt(bal) + parseInt(bald)));
                              
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                //var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt)+ parseInt(bald));                               
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }


                      

                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';                           
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();

                        }
                    }
                    else if (checkvalue == "Non Finance")
                    {
                         
                        if (currency == "INR") {
                  
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';
                            
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            
                            if (isNaN(percent))
                            {
                                
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;

                             
                                document.getElementById("balamtpayableTextBox").value = "0";

                            }
                           else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                                
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(bald));
                          
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                           else
                           {
                                
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bald));
                                
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            } 

                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                            
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'none';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();
                        }
                        else if (currency == "USD") {
                            
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';
                         
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                             
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent)) {

                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;


                                document.getElementById("balamtpayableTextBox").value = "0";

                            }
                            else if (percent < 10)
                            {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                               
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal)+parseInt(bald));
                            
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt)+parseInt(bald));                               
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }

                           
                            

                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                            
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'none';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();

                        }

                    }
                }
                else {
                    if (checkvalue == "Finance") {
                        if (currency == "INR") {
                            
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald=document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';
                           
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                            
                          
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent)) {

                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;


                                document.getElementById("balamtpayableTextBox").value = "0";

                            }
                            else if (percent < 10)
                            {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                               
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal)+parseInt(bald));
                               
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt)+parseInt(bald));                              
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }

                           // document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                           

                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                           
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();
                        }
                        else if (currency == "USD") {
                             
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';
                           
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                           

                            
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent)) {

                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;


                                document.getElementById("balamtpayableTextBox").value = "0";

                            }
                           else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                               
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal)+parseInt(bald));
                                
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt)+parseInt(bald));
                               
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }

                          
                            
                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                            
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';

                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();

                        }
                    }
                    else if (checkvalue == "Non Finance") {
                        if (currency == "INR") {
                             
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';
                           
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                           

                          
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent)) {

                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;


                                document.getElementById("balamtpayableTextBox").value = "0";

                            }
                            else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                                
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal)+parseInt(bald));
                              
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt)+parseInt(Bald));
                        
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }

                        
                            
                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                            
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'none';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();
                        }
                        else if (currency == "USD") {
                           
                            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                            var bald = document.getElementById("balinitialdepamtTextBox").value;
                            document.getElementById("lblbaladepamt").style.display = 'none';
                         
                            var depositamt = document.getElementById("intialdeppercentTextBox").value;
                   

                         
                            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                            if (isNaN(percent)) {

                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;


                                document.getElementById("balamtpayableTextBox").value = "0";

                            }
                           else if (percent < 10) {
                                document.getElementById("lblbaladepamt").style.display = 'block';
                                document.getElementById("baldepamtTextBox").style.display = 'block';
                                document.getElementById("lblbaladepamtdate").style.display = 'block';
                                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                                var bal = document.getElementById("baldepamtTextBox").value;
                                
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal)+parseInt(bald));
                               
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            }
                            else {
                                document.getElementById("lblbaladepamt").style.display = 'none';
                                document.getElementById("baldepamtTextBox").style.display = 'none';
                                document.getElementById("lblbaladepamtdate").style.display = 'none';
                                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                                var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt)+parseInt(bald));
                             
                                document.getElementById("balamtpayableTextBox").value = intitalbal;
                            } 

                            document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                           
                            document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                            document.getElementById("lblbalinitialdep").style.display = 'none';
                            document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                            document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                            document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                            document.getElementById("balamtpayableTextBox").style.color = 'Green';
                            InitialBalCalculation();

                        }

                    }
                }

            }

        }
    

        function InitialDepositCalculation1() {

          
          
            var contract_type = document.getElementById("contracttypeTextBox").value;
          
            //get venue name
            var v = document.getElementById("VenueDropDownList");
            var venue = v.options[v.selectedIndex].text;
            //get venue grp name
            var vg = document.getElementById("GroupVenueDropDownList");
            var venuegroup = vg.options[vg.selectedIndex].text;
            var m = document.getElementById("MarketingProgramDropDownList");
            var mktg = m.options[m.selectedIndex].text;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var nl = document.getElementById("PrimarynationalityDropDownList");
            var nationality = nl.options[nl.selectedIndex].text;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (contract_type == "Fractional")
            {
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    // if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner") {
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")
                   {
                        AmountBreakupCalculation();
                        InitialBalCalculation();
                    }
                    else {

                        AmountBreakupCalculation();
                        InitialBalCalculation();
                    }
                }
                else {

                    AmountBreakupCalculation();
                    InitialBalCalculation();
                }
            }
            else if (contract_type == "Points")
            {
                

                AmountBreakupCalculation();
                InitialBalCalculation();


            }
            else if (contract_type == "Trade-In-Points") {

                AmountBreakupCalculation();
                InitialBalCalculation();

            }

            else if (contract_type == "Trade-In-Weeks") {


                AmountBreakupCalculation();
                InitialBalCalculation();
            }
            else if (contract_type == "Trade-In-Fractionals") {
                InitialBalCalculation();
                AmountBreakupCalculation();
               

            }

        }
        function DisplayonPayMethod() {
            var radio = document.getElementsByName('financeradiobuttonlist');
            var method = document.getElementById("PayMethodDropDownList").value;
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (checkvalue == "Finance") {
                if (method == "INSTALLMENT" || method == "Installment") {
                    document.getElementById("lblnoinstallment").style.display = 'BLOCK';
                    document.getElementById("NoinstallmentTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinstallmentamt").style.display = 'BLOCK';
                    document.getElementById("installmentamtTextBox").style.display = 'BLOCK';
                }
                else {
                    document.getElementById("lblnoinstallment").style.display = 'NONE';
                    document.getElementById("NoinstallmentTextBox").style.display = 'NONE';
                    document.getElementById("lblinstallmentamt").style.display = 'NONE';
                    document.getElementById("installmentamtTextBox").style.display = 'NONE';

                }
            }
            else if (checkvalue == "Non Finance") {
                if (method == "INSTALLMENT" || method == "Installment") {
                    document.getElementById("lblnoinstallment").style.display = 'BLOCK';
                    document.getElementById("NoinstallmentTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinstallmentamt").style.display = 'BLOCK';
                    document.getElementById("installmentamtTextBox").style.display = 'BLOCK';
                    
                    document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                    document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalpriceInTaxTextBox").value;
                    var depositpercent = document.getElementById("intialdeppercentTextBox").value;
                   

                }
                else {
                    
                    document.getElementById("lblbalamtpayable").style.display = 'NONE';
                    document.getElementById("balamtpayableTextBox").style.display = 'NONE';
                    document.getElementById("lblnoinstallment").style.display = 'NONE';
                    document.getElementById("NoinstallmentTextBox").style.display = 'NONE';
                    document.getElementById("lblinstallmentamt").style.display = 'NONE';
                    document.getElementById("installmentamtTextBox").style.display = 'NONE';


                }

            }


        }

        function fractionaltradeinamt() {
            
            var ct = document.getElementById("oldcontracttypeDropDownList");
            var ocontract_type = ct.options[ct.selectedIndex].text;
            if (ocontract_type == "Weeks") {
                var tradein = document.getElementById("tradeinamtTextBox").value;
                document.getElementById("ftradeinvalueTextBox").value = tradein;
                if (tradein == 0) {
                    var totalvalue = "0";
                    document.getElementById("ftotalvalueTextBox").value = totalvalue;

                }
                else {
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var totalvalue = parseInt(tradein) + parseInt(totalpurchase);
                    document.getElementById("ftotalvalueTextBox").value = totalvalue;
                }
             

            }
            else if (ocontract_type == "Points") {
      
                var tradein = document.getElementById("tradeinamtTextBox").value;
                document.getElementById("ftradeinvalueTextBox").value = tradein;
           
                if (tradein == 0) {
                    var totalvalue = "0";
                    document.getElementById("ftotalvalueTextBox").value = totalvalue;

                }
                else {
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var totalvalue = parseInt(tradein) + parseInt(totalpurchase);
                    document.getElementById("ftotalvalueTextBox").value = totalvalue;
                }
                

            }
            else if (ocontract_type == "Fractionals") {

                var tradein = document.getElementById("tradeinamtTextBox").value;
                document.getElementById("ftradeinvalueTextBox").value = tradein;

                if (tradein == 0) {
                    var totalvalue = "0";
                    document.getElementById("ftotalvalueTextBox").value = totalvalue;

                }
                else {
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var totalvalue = parseInt(tradein) + parseInt(totalpurchase);
                    document.getElementById("ftotalvalueTextBox").value = totalvalue;
                }


            }


        }
        function ConversionfeeWithNewPoints() {
            
            //var contract_type = document.getElementById("contracttypetextBox").value;

            ////get venue name
            //var v = document.getElementById("VenueDropDownList");
            //var venue = v.options[v.selectedIndex].text;
            ////get venue grp name
            //var vg = document.getElementById("GroupVenueDropDownList");
            //var venuegroup = vg.options[vg.selectedIndex].text;
            //var m = document.getElementById("MarketingProgramDropDownList");
            //var mktg = m.options[m.selectedIndex].text;
            //var cy = document.getElementById("currencyDropDownList");
            //var currency = cy.options[cy.selectedIndex].text;
            var newpointsprice = document.getElementById("newpointsTextBox").value;           
            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
           var admintotal = document.getElementById("adminfeeTextBox").value;          
            var totpurchaseprice = document.getElementById("totpurchpriceTextBox").value  
            var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));            
            document.getElementById("conversionfeeTextBox").value = convfee;

        }
        function PACalculationOwner(tot, aftotal) {

            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;

            var totalpurchase = tot;
            var total = aftotal;

            document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }

            if (checkvalue == "Finance") {

                if (currency == "INR") {

                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    if (totalpurchase >=240000) {

                        //  var adminfees = "30000";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "30000";
                        }
                       

                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "18";//document.getElementById("pointstaxTextBox").value;

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;

                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;

                        var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = true;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 240000) {

                        var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "18";//document.getElementById("pointstaxTextBox").value;

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;

                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;

                        var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = true;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
                else if (currency == "USD") {
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    if (totalpurchase > "5984") {

                        // var adminfees = "748";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "748";
                        }
                     
                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;


                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 5984) {

                        var adminfees = Math.round(parseInt(totalpurchase) * (12.5 / 100));

                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;

                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';


                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }

                }
            }
            else if (checkvalue == "Non Finance") {
                
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    if (totalpurchase >=240000) {
                        //   var adminfees = "30000";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "30000";
                        }
                      
                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "18";

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;


                        var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = true;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 240000) {
                        var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "18";//document.getElementById("pointstaxTextBox").value;

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;


                        var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = true;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }

                }
                else if (currency == "USD") {
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    if (totalpurchase > "5984") {

                        //var adminfees = "748";                     

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "748";
                        }

                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;


                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 5984) {

                        var adminfees = Math.round(parseInt(totalpurchase) * (12.5 / 100));

                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;
                        var tax = "0"; 
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;

                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
            }
        }
        function PACalculationOwnerFractional(tot, atotal) {


            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;

            var nl = document.getElementById("PrimarynationalityDropDownList");
            var nationality = nl.options[nl.selectedIndex].text;
            var totalpurchase = tot;
            var total = atotal;

            //document.getElementById("TotalPurchasePriceTextBox").value = totalpurchase;
          //  document.getElementById("totpurchpriceTextBox").value = totalpurchase;
            
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (nationality == "INDIAN" || nationality == "Indian" || nationality == "OCI" || nationality == "PIO") {
                if (checkvalue == "Finance") {

                    if (currency == "INR") {

                       
                       
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                        document.getElementById("Label148").style.display = 'block';
                        document.getElementById("cgstTextBox").style.display = 'block';
                        document.getElementById("Label149").style.display = 'block';
                        document.getElementById("sgstTextBox").style.display = 'block';
                        document.getElementById("Label150").style.display = 'block';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';

                        //   var adminfees = "77050";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "108650";
                        }
                       

                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "18";

                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;


                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);

                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;


                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;




                    }
                    else if (currency == "USD") {
                     
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';
                        

                        //  var adminfees = "1110";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "1582";
                        }
                        
                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("AdministrationFeesTextBox").value = admintotal;
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;



                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        // var dep = document.getElementById("fractionaldepositTextBox").value;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }
                }
                else if (checkvalue == "Non Finance") {

                    if (currency == "INR") {


                      

                        // var adminfees = "77050";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "108650";
                        }
                       

                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "18";

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;


                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;



                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        //  var dep = document.getElementById("fractionaldepositTextBox").value;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;




                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';

                        //   var adminfees = "1110";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "1582";
                        }
                       

                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;



                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        //var dep = document.getElementById("fractionaldepositTextBox").value;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }



                }
            }
                //as of my understanding this part of fin n noon finance is same for all nationalities
            else {
                if (checkvalue == "Finance") {

                    if (currency == "INR") {

                    

                        //  var adminfees = "77050";                      

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "108650";
                        }

                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "18";

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;


                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);

                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;


                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;




                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                      //  document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';
                        //  var adminfees = "1110";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "1582";
                        }
                      
                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("AdministrationFeesTextBox").value = admintotal;
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }
                }
                else if (checkvalue == "Non Finance") {

                    if (currency == "INR") {


                       
                        //  var adminfees = "77050";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "108650";
                        }


                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "18";

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);


                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;


                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);

                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;


                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;




                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';


                        // var adminfees = "1110";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "1582";
                        }
                       
                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;


                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }



                }

            }
        }
        function PACalculationOwnerTradeIn_Fractional(tot, atotal) {


            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;

            var nl = document.getElementById("PrimarynationalityDropDownList");
            var nationality = nl.options[nl.selectedIndex].text;

            var cl = document.getElementById("oldcontracttypeDropDownList");
            var ocontracttype = cl.options[cl.selectedIndex].text;
            // alert(ocontracttype);

            var totalpurchase = tot;
            var total = atotal;


            //document.getElementById("TotalPurchasePriceTextBox").value = totalpurchase;
          //  document.getElementById("totpurchpriceTextBox").value = totalpurchase;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (nationality == "INDIAN" || nationality == "Indian" || nationality == "OCI" || nationality == "PIO") {
                if (checkvalue == "Finance") {

                    if (currency == "INR") {

                  
                        //  var adminfees = "77050";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "77050";
                        }
                        var twoyrs = "31600";
                        var admintotal;
                        if (ocontracttype == "Points" || ocontracttype == "Weeks") {
                            admintotal = parseInt(total) + parseInt(adminfees) + parseInt(twoyrs);
                        }
                        else if (ocontracttype = "Fractionals") {
                            admintotal = parseInt(total) + parseInt(adminfees);
                        }

                    //    var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "18";

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);


                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;


                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;



                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value;    
                        
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);

                        document.getElementById("balanceTextBox").value = bal;




                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';

                        //  var adminfees = "1110";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "1110";
                        }

                        // var admintotal = parseInt(total) + parseInt(adminfees);
                        var twoyrs = "472";
                        var admintotal;
                        if (ocontracttype == "Points" || ocontracttype == "Weeks") {
                            admintotal = parseInt(total) + parseInt(adminfees) + parseInt(twoyrs);
                        }
                        else if (ocontracttype = "Fractionals") {
                            admintotal = parseInt(total) + parseInt(adminfees);
                        }
                        document.getElementById("AdministrationFeesTextBox").value = admintotal;
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;



                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;
                     
                        var bal = parseInt(totalpurchase) - parseInt(dep);

                        document.getElementById("balanceTextBox").value = bal;




                    }
                }
                else if (checkvalue == "Non Finance") {

                    if (currency == "INR") {


                       

                        //    var adminfees = "77050";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "77050";
                        }

                        var twoyrs = "31600";
                        var admintotal;
                        if (ocontracttype == "Points" || ocontracttype == "Weeks") {
                            admintotal = parseInt(total) + parseInt(adminfees) + parseInt(twoyrs);
                        }
                        else if (ocontracttype = "Fractionals") {
                            admintotal = parseInt(total) + parseInt(adminfees);
                        }
                     //   var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "18";

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);


                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;


                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);

                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;



                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;
                        //  var dep = document.getElementById("fractionaldepositTextBox").value;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;




                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';

                        //  var adminfees = "1110";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "1110";
                        }


                        // var admintotal = parseInt(total) + parseInt(adminfees);
                        var twoyrs = "472";
                        var admintotal;
                        if (ocontracttype == "Points" || ocontracttype == "Weeks") {
                            admintotal = parseInt(total) + parseInt(adminfees) + parseInt(twoyrs);
                        }
                        else if (ocontracttype = "Fractionals") {
                            admintotal = parseInt(total) + parseInt(adminfees);
                        }

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;



                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;
                 
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;




                    }



                }
            }
                //as of my understanding this part of fin n noon finance is same for all nationalities
            else {
                if (checkvalue == "Finance") {

                    if (currency == "INR") {

                        //  var adminfees = "77050";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "77050";
                        }


                        //   var admintotal = parseInt(total) + parseInt(adminfees);
                        var twoyrs = "31600";
                        var admintotal;
                        if (ocontracttype == "Points" || ocontracttype == "Weeks") {
                            admintotal = parseInt(total) + parseInt(adminfees) + parseInt(twoyrs);
                        }
                        else if (ocontracttype = "Fractionals") {
                            admintotal = parseInt(total) + parseInt(adminfees);
                        }

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "18";

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);


                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;


                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);

                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;

                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;

                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;





                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';

                        //  var adminfees = "1110";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "1110";
                        }

                        //  var admintotal = parseInt(total) + parseInt(adminfees);
                        var twoyrs = "472";
                        var admintotal;
                        if (ocontracttype == "Points" || ocontracttype == "Weeks") {
                            admintotal = parseInt(total) + parseInt(adminfees) + parseInt(twoyrs);
                        }
                        else if (ocontracttype = "Fractionals") {
                            admintotal = parseInt(total) + parseInt(adminfees);
                        }
                        document.getElementById("AdministrationFeesTextBox").value = admintotal;
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;

                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
                else if (checkvalue == "Non Finance") {

                    if (currency == "INR")
                    {
                        //var adminfees = "77050";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "77050";
                        }
                        var twoyrs = "31600";
                        var admintotal;
                        if (ocontracttype == "Points" || ocontracttype == "Weeks") {
                            admintotal = parseInt(total) + parseInt(adminfees) + parseInt(twoyrs);
                        }
                        else if (ocontracttype = "Fractionals") {
                            admintotal = parseInt(total) + parseInt(adminfees);
                        }
                        //var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("AdministrationFeesTextBox").value = admintotal;
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;


                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);

                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;


                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;
                     
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;





                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        //document.getElementById("lblconversionfee").style.display = 'none';
                        //document.getElementById("conversionfeeTextBox").style.display = 'none';

                        // var adminfees = "1110";                      

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "1110";
                        }

                        //    var admintotal = parseInt(total) + parseInt(adminfees);
                        var twoyrs = "472";
                        var admintotal;
                        if (ocontracttype == "Points" || ocontracttype == "Weeks") {
                            admintotal = parseInt(total) + parseInt(adminfees) + parseInt(twoyrs);
                        }
                        else if (ocontracttype = "Fractionals") {
                            admintotal = parseInt(total) + parseInt(adminfees);
                        }

                        document.getElementById("AdministrationFeesTextBox").value = admintotal;

                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }

            }
            fractionaltradeinamt();
        }


        function PACalculationOwner_TradeIn(tot, aftotal) {


            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var totalpurchase = tot;
            var total = aftotal;
            document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (checkvalue == "Finance") {

                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';

                    if (totalpurchase >=240000) {
                        // var adminfees = "30000";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "30000";
                        }
                        /* var adminfees;
                         var adminfees1 = "30000";
                         var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                         if (adminfees1 == oadminfees) {
                             adminfees = adminfees1;
                         }
                         else {
                             adminfees = oadminfees;
                         }*/
                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));

                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;

                        //var newpointsprice = document.getElementById("newpointsTextBox").value;
                        //document.getElementById("newpointsTextBox").readOnly = false;
                        var newpts = "0";
                        var newpointsprice = newpts;
                        //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = false;
                        var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                        // alert("confee:" + convfee);
                        document.getElementById("conversionfeeTextBox").value = convfee;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 240000) {
                        // alert(totalpurchase);
                        var adminfees = parseInt(totalpurchase) * (12.5 / 100);
                        //alert(adminfees);
                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "18";//document.getElementById("pointstaxTextBox").value;

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;

                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));

                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;

                        //var newpointsprice =   document.getElementById("newpointsTextBox").value;
                        //
                        var newpts = "0";
                        var newpointsprice = newpts;
                        //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = false;
                        var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                        document.getElementById("conversionfeeTextBox").value = convfee;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
                else if (currency == "USD") {
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    if (totalpurchase > "5984") {

                        // var adminfees = "748";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "748";
                        }
                        /*   var adminfees;
                           var adminfees1 = "748";
                           var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                           if (adminfees1 == oadminfees) {
                               adminfees = adminfees1;
                           }
                           else {
                               adminfees = oadminfees;
                           }*/

                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "0";//document.getElementById("pointstaxTextBox").value;
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;


                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 5984) {

                        var adminfees =Math.Round(parseInt(totalpurchase) * (12.5 / 100));

                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "0";//document.getElementById("pointstaxTextBox").value;
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;

                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';


                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }

                }
            }
            else if (checkvalue == "Non Finance") {

                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';

                    if (totalpurchase >=240000) {
                        // var adminfees = "30000";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "30000";
                        }
                         
                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "18";//document.getElementById("pointstaxTextBox").value;

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));

                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;

                        var newpts = "0";
                        var newpointsprice = newpts;

                        //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = false;
                        var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                        document.getElementById("conversionfeeTextBox").value = convfee;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 240000) {
                        var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "18";//document.getElementById("pointstaxTextBox").value;

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;

                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));

                        document.getElementById("TotalTaxTextBox").value = tottax;
                       
                       var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;

                        //var newpointsprice = document.getElementById("newpointsTextBox").value;
                        //document.getElementById("newpointsTextBox").readOnly = false;
                        var newpts = "0";
                        var newpointsprice = newpts;
                        //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = false;
                        var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                        document.getElementById("conversionfeeTextBox").value = convfee;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }

                }
                else if (currency == "USD") {
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    if (totalpurchase > "5984") {

                        //var adminfees = "748";

                        var adminfees;
                        if (totalpurchase == "0") {
                            adminfees = "0";
                        }
                        else {
                            adminfees = "748";
                        }
                      

                        var admintotal = parseInt(total) + parseInt(adminfees);

                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "0";//document.getElementById("pointstaxTextBox").value;
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;


                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 5984) {

                        var adminfees = Math.round(parseInt(totalpurchase) * (12.5 / 100));

                        var admintotal = parseInt(total) + parseInt(adminfees);
                        document.getElementById("adminfeeTextBox").value = admintotal;

                        var tax = "0";//document.getElementById("pointstaxTextBox").value;
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase)- parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;

                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';


                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
            }
        }
        function PACalculationNonMember(tot, aftotal) {
            
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var totalpurchase = tot;// document.getElementById("totalfinpriceIntaxTextBox").value;
            var total = aftotal;
           

            document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
             
            if (checkvalue == "Finance") {
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';

                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';



                    var adminfees;
                    if (totalpurchase == "0")
                    {
                        adminfees="0";
                    }
                    else

                    {
                        adminfees = "30000";
                    }
                    
                   



                    var admintotal = parseInt(total) + parseInt(adminfees);
                    
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                   
                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));

                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;

                    
                    var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                   
                    document.getElementById("newpointsTextBox").readOnly = true;

                    var dep = document.getElementById("intialdeppercentTextBox").value;
                 
                    document.getElementById("depositTextBox").value = dep;
                   
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    
                    document.getElementById("balanceTextBox").value = bal;
                }
                else if (currency == "USD") {
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    
                    var adminfees;
                    if (totalpurchase == "0") {
                        adminfees = "0";
                    }
                    else {
                        adminfees = "748";
                    }


                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;
                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';


                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }
            else if (checkvalue == "Non Finance") {
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';


                    var adminfees;
                    if (totalpurchase == "0") {
                        adminfees = "0";
                    }
                    else {
                        adminfees = "30000";
                    }
                    /*  var adminfees;
                      var adminfees1 = "30000";
                      var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                      if (adminfees1 == oadminfees) {
                          adminfees = adminfees1;
                      }
                      else {
                          adminfees = oadminfees;
                      }*/
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));

                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;

                    var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = true;
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
                else if (currency == "USD") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';

                    var adminfees;
                    if (totalpurchase == "0") {
                        adminfees = "0";
                    }
                    else {
                        adminfees = "748";
                    }

                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;

                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }

        }
        function PACalculationNonMember_TradeIn(tot, aftotal) {
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var totalpurchase = tot;// document.getElementById("totalfinpriceIntaxTextBox").value;
            document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            var total = aftotal;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (checkvalue == "Finance") {
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';
                    //   var adminfees = "30000";

                    var adminfees;
                    if (totalpurchase == "0") {
                        adminfees = "0";
                    }
                    else {
                        adminfees = "30000";
                    }
                    /*  var adminfees;
                      var adminfees1 = "30000";
                      var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                      if (adminfees1 == oadminfees) {
                          adminfees = adminfees1;
                      }
                      else {
                          adminfees = oadminfees;
                      }*/
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));

                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;

                    //var newpointsprice = document.getElementById("newpointsTextBox").value;
                    //document.getElementById("newpointsTextBox").readOnly = false;
                    var newpts = "0";
                    var newpointsprice = newpts;
                    //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    //    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;

                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
                else if (currency == "USD") {

                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';

                    //  var adminfees = "748";

                    var adminfees;
                    if (totalpurchase == "0") {
                        adminfees = "0";
                    }
                    else {
                        adminfees = "748";
                    }
                   
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;
                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
            }
            else if (checkvalue == "Non Finance") {
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';

                    // var adminfees = "30000";

                    var adminfees;
                    if (totalpurchase == "0") {
                        adminfees = "0";
                    }
                    else {
                        adminfees = "30000";
                    }
                 
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;

                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));

                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;




                    //var newpointsprice = document.getElementById("newpointsTextBox").value;
                    //document.getElementById("newpointsTextBox").readOnly = false;
                    var newpts = "0";
                    var newpointsprice = newpts;
                    //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;


                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
                else if (currency == "USD") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';

                    //     var adminfees = "748";

                    var adminfees;
                    if (totalpurchase == "0") {
                        adminfees = "0";
                    }
                    else {
                        adminfees = "748";
                    }
                   
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;
                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
            }
        }

        function PACalculationOwnerAdminfee(tot, aftotal) {

            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;

            var totalpurchase = tot;
            var total = aftotal;
            var admintotal;
            document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }

            if (checkvalue == "Finance") {

                if (currency == "INR") {

                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';                     
                    if (totalpurchase >=240000) 
                    {
                      
                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18"; 
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;

                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;

                        var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = true;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 240000) {
                       
                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = true;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
                else if (currency == "USD") {
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                   
                    if (totalpurchase > "5984") {
                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 5984) {                       
                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }

                }
            }
            else if (checkvalue == "Non Finance") {
                
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    if (totalpurchase >=240000) {                      
                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = true;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 240000) {                        
                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";//document.getElementById("pointstaxTextBox").value;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = true;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }

                }
                else if (currency == "USD") {
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    //document.getElementById("lblconversionfee").style.display = 'none';
                    //document.getElementById("conversionfeeTextBox").style.display = 'none';
                    if (totalpurchase > "5984") {                     
                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (totalpurchase < 5984) {

                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var totpurchaseprice = Math.round(parseInt(totalpurchase)- parseInt(admintotal));
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        document.getElementById("lblnewpoints").style.display = 'none';
                        document.getElementById("newpointsTextBox").style.display = 'none';
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
            }
        }
        function PACalculationOwnerFractionalAdminfee(tot, atotal) {


            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;

            var nl = document.getElementById("PrimarynationalityDropDownList");
            var nationality = nl.options[nl.selectedIndex].text;
            var totalpurchase = tot;
            var total = atotal;
            var admintotal ;
             
            
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (nationality == "INDIAN" || nationality == "Indian" || nationality == "OCI" || nationality == "PIO") {
                if (checkvalue == "Finance") {

                    if (currency == "INR") {

                        document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                        document.getElementById("Label148").style.display = 'block';
                        document.getElementById("cgstTextBox").style.display = 'block';
                        document.getElementById("Label149").style.display = 'block';
                        document.getElementById("sgstTextBox").style.display = 'block';
                        document.getElementById("Label150").style.display = 'block'; 
                        
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;
                    }
                    else if (currency == "USD") {
                     
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;                      
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }
                }
                else if (checkvalue == "Non Finance") {

                    if (currency == "INR") {

                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;                     
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;
                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';                    
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        //var dep = document.getElementById("fractionaldepositTextBox").value;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }



                }
            }
                //as of my understanding this part of fin n noon finance is same for all nationalities
            else {
                if (checkvalue == "Finance") {

                    if (currency == "INR") {

                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;

                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;
                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none'; 
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;

                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }
                }
                else if (checkvalue == "Non Finance") {

                    if (currency == "INR") {

                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;

                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;


                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }



                }

            }
        }
        function PACalculationOwnerTradeIn_FractionalAdminfee(tot, atotal) {


            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;

            var nl = document.getElementById("PrimarynationalityDropDownList");
            var nationality = nl.options[nl.selectedIndex].text;

            var cl = document.getElementById("oldcontracttypeDropDownList");
            var ocontracttype = cl.options[cl.selectedIndex].text;
            // alert(ocontracttype);

            var totalpurchase = tot;
            var total = atotal;
            var admintotal ;

           
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (nationality == "INDIAN" || nationality == "Indian" || nationality == "OCI" || nationality == "PIO") {
                if (checkvalue == "Finance") {

                    if (currency == "INR") {

                  
                       
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }

                        var tax = "18";

                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                       
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;                     
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
                else if (checkvalue == "Non Finance") {

                    if (currency == "INR") {
                    
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;
                        //  var dep = document.getElementById("fractionaldepositTextBox").value;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;                 
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }



                }
            }
                //as of my understanding this part of fin n noon finance is same for all nationalities
            else {
                if (checkvalue == "Finance") {

                    if (currency == "INR") {

                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';                       
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }
                else if (checkvalue == "Non Finance") {

                    if (currency == "INR")
                    {
                     
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;
                        var tottax = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)));
                        document.getElementById("TotalTaxTextBox").value = tottax;

                        var sgst = Math.round((parseInt(totalpurchase) - (parseInt(totalpurchase) / (parseInt(tax) + 100) * 100)) / 2);
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var dep = document.getElementById("intialdeppercentTextBox").value; 
                        document.getElementById("depositTextBox").value = dep;                     
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;


                    }
                    else if (currency == "USD") {
                        document.getElementById("Label148").style.display = 'none';
                        document.getElementById("cgstTextBox").style.display = 'none';
                        document.getElementById("Label149").style.display = 'none';
                        document.getElementById("sgstTextBox").style.display = 'none';
                        document.getElementById("Label150").style.display = 'none';
                        document.getElementById("totalpriceInTaxTextBox").style.display = 'none';                        
                        var ad = document.getElementById("AdministrationFeesTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "0";
                        var tottax = "0";
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                        document.getElementById("adminfeeTextBox").value = AdmissionFees;
                        var sgst = "0";
                        document.getElementById("sgstTextBox").value = sgst;
                        var cgst = "0";
                        document.getElementById("cgstTextBox").value = cgst;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;

                    }
                }

            }
            fractionaltradeinamt();
        }


        function PACalculationOwner_TradeInAdminfee(tot, aftotal) {


            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var totalpurchase = tot;
            var total = aftotal;
            var admintotal;
            document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (checkvalue == "Finance") {

                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block'; 

                    if (totalpurchase >=240000) 
                    {
                        var ad = document.getElementById("adminfeeTextBox").value;

                        if (ad == total) {
                            admintotal = total;
                        }
                        else {
                            admintotal = ad;
                        }
                        var tax = "18";
                        var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                        document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                        //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("sgstTextBox").value = sgst;
                        //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                        //document.getElementById("cgstTextBox").value = cgst;    
                        var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                        document.getElementById("TotalTaxTextBox").value = tottax;
                        var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                        document.getElementById("sgstTextBox").value = sgst;
                        document.getElementById("cgstTextBox").value = sgst;
                        var newpts = "0";
                        var newpointsprice = newpts;                        
                        document.getElementById("newpointsTextBox").value = newpointsprice;
                        document.getElementById("newpointsTextBox").readOnly = false;
                        var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));                         
                        document.getElementById("conversionfeeTextBox").value = convfee;
                        var dep = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = dep;
                        var bal = parseInt(totalpurchase) - parseInt(dep);
                        document.getElementById("balanceTextBox").value = bal;
                    }                
                else if (totalpurchase < 240000) {
                  
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }

                    var tax = "18"; 

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("sgstTextBox").value = sgst;
                    //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("cgstTextBox").value = cgst;
                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;

                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }
            else if (currency == "USD") {
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    
                if (totalpurchase > "5984") {

                       
                         
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }
                    var tax = "0";//document.getElementById("pointstaxTextBox").value;
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;

                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 5984) {

                       
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }
                    var tax = "0";//document.getElementById("pointstaxTextBox").value;
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase)- parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;
                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;
                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }

            }
        }
        else if (checkvalue == "Non Finance") {

            if (currency == "INR") {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';
                document.getElementById("lblconversionfee").style.display = 'block';
                document.getElementById("conversionfeeTextBox").style.display = 'block';

                if (totalpurchase >=240000) {
                         
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }
                    var tax = "18";//document.getElementById("pointstaxTextBox").value;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    //var sgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("sgstTextBox").value = sgst;
                    //var cgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("cgstTextBox").value = cgst;
                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;
                    var newpts = "0";
                    var newpointsprice = newpts;
                    //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 240000) {
                       
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }
                    var tax = "18";//document.getElementById("pointstaxTextBox").value;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("sgstTextBox").value = sgst;
                    //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("cgstTextBox").value = cgst;
                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;
                        
                    var newpts = "0";
                    var newpointsprice = newpts;                        
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;

                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }

            }
            else if (currency == "USD") {
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    
                if (totalpurchase > "5984") {

                     
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;


                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 5984) {

                         
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;

                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';


                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }
        }
        }
        function PACalculationNonMemberAdminfee(tot, aftotal) {
            
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var totalpurchase = tot;// document.getElementById("totalfinpriceIntaxTextBox").value;
            var total = aftotal;
            var admintotal; 
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
             
            if (checkvalue == "Finance") {
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
 
                    var ad = document.getElementById("adminfeeTextBox").value;
                    if (ad == total)
                    {
                        admintotal = total;
                    }
                    else
                    {
                        admintotal = ad;
                    }                      

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("sgstTextBox").value = sgst;
                    //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("cgstTextBox").value = cgst;       
                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;
                    var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                    document.getElementById("newpointsTextBox").value = newpointsprice;                   
                    document.getElementById("newpointsTextBox").readOnly = true;
                    var dep = document.getElementById("intialdeppercentTextBox").value;                 
                    document.getElementById("depositTextBox").value = dep;                   
                    var bal = parseInt(totalpurchase) - parseInt(dep);                    
                    document.getElementById("balanceTextBox").value = bal;
                }
                else if (currency == "USD") {
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';                    
                    var ad = document.getElementById("adminfeeTextBox").value;
                    
                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }
                    var tax = "0";
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;
                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;
                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }
            else if (checkvalue == "Non Finance") {
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';                    
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }
                    var tax = "18";//document.getElementById("pointstaxTextBox").value;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    //  var sgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("sgstTextBox").value = sgst;
                    //// var cgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("cgstTextBox").value = cgst;
                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;
                    var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = true;
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
                else if (currency == "USD") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }

                    var tax = "0";
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;

                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }

        }
        function PACalculationNonMember_TradeInAdminfee(tot, aftotal) {
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var totalpurchase = tot;// document.getElementById("totalfinpriceIntaxTextBox").value;
            document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            var total = aftotal;
            var admintotal;
            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }
            if (checkvalue == "Finance") {
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';
                    
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    //  var sgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("sgstTextBox").value = sgst;
                    //// var cgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("cgstTextBox").value = cgst;
                    //var newpointsprice = document.getElementById("newpointsTextBox").value;
                    //document.getElementById("newpointsTextBox").readOnly = false;
                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;
                    var newpts = "0";
                    var newpointsprice = newpts;
                    //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    //    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;

                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
                else if (currency == "USD") {

                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';

                     
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }

                    var tax = "0";
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;
                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
            }
            else if (checkvalue == "Non Finance") {
                if (currency == "INR") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                    document.getElementById("Label148").style.display = 'block';
                    document.getElementById("cgstTextBox").style.display = 'block';
                    document.getElementById("Label149").style.display = 'block';
                    document.getElementById("sgstTextBox").style.display = 'block';
                    document.getElementById("Label150").style.display = 'block';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';

                  
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }
                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    ////  var sgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("sgstTextBox").value = sgst;

                    //// var cgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    //document.getElementById("cgstTextBox").value = cgst;

                    var tottax = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)));
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var sgst = Math.round((parseInt(totalpurchase) / (parseInt(tax) + 100) * (parseInt(tax)) / 2));
                    document.getElementById("sgstTextBox").value = sgst;
                    document.getElementById("cgstTextBox").value = sgst;

                   
                    var newpts = "0";
                    var newpointsprice = newpts;
                   
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;


                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
                else if (currency == "USD") {
                    document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                    document.getElementById("Label148").style.display = 'none';
                    document.getElementById("cgstTextBox").style.display = 'none';
                    document.getElementById("Label149").style.display = 'none';
                    document.getElementById("sgstTextBox").style.display = 'none';
                    document.getElementById("Label150").style.display = 'none';
                    document.getElementById("lblconversionfee").style.display = 'block';
                    document.getElementById("conversionfeeTextBox").style.display = 'block';

                    
                    var ad = document.getElementById("adminfeeTextBox").value;

                    if (ad == total) {
                        admintotal = total;
                    }
                    else {
                        admintotal = ad;
                    }

                    var tax = "0";
                    var tottax = "0";
                    document.getElementById("TotalTaxTextBox").value = tottax;
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;
                    document.getElementById("lblnewpoints").style.display = 'none';
                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;
                }
            }
        }
        function AdminfeeCalculation()
        {
            var contract_type = document.getElementById("contracttypeTextBox").value;
            var vg = document.getElementById("GroupVenueDropDownList");
            var venuegroup = vg.options[vg.selectedIndex].text;
            var m = document.getElementById("MarketingProgramDropDownList");
            var mktg = m.options[m.selectedIndex].text;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
            //document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            var total = document.getElementById("testadminfeeTextBox").value;
            if (contract_type == "Fractional") {

                
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    //  if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")  {
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")
                        {
                        PACalculationOwnerFractionalAdminfee(totalpurchase, total);
                    }

                    else
                    {                       
                        PACalculationOwnerFractionalAdminfee(totalpurchase, total);
                    }

                }
                else
                {
                     
                    PACalculationOwnerFractionalAdminfee(totalpurchase, total);
                }
            }

            else if (contract_type == "Points") {


                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    //if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")  
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")

                    {
                        PACalculationOwnerAdminfee(totalpurchase, total);

                    }//if block mktg
                    else {

                        PACalculationNonMemberAdminfee(totalpurchase, total);

                    }//else block mktg
                }//if block venuegrp
                else {

                    PACalculationNonMemberAdminfee(totalpurchase, total);

                }//else block venuegrp

            }//else contract type
            else if (contract_type == "Trade-In-Points") {
                
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    // if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")

                    {

                        PACalculationOwner_TradeInAdminfee(totalpurchase, total);
                    }
                    else {
                        PACalculationNonMember_TradeInAdminfee(totalpurchase, total);

                    }
                }
                else {
                    PACalculationNonMember_TradeInAdminfee(totalpurchase, total);

                }

            }
            else if (contract_type == "Trade-In-Weeks") {
                // if (venuegroup == "Inhouse")
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    // if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")  {
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")
                    {

                        PACalculationOwner_TradeInAdminfee(totalpurchase, total);
                    }
                    else {
                        PACalculationNonMember_TradeInAdminfee(totalpurchase, total);

                    }
                }
                else {
                    PACalculationNonMember_TradeInAdminfee(totalpurchase, total);

                }

            }
            else if (contract_type == "Trade-In-Fractionals") {
                //            
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    //if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")

                    {

                        PACalculationOwnerTradeIn_FractionalAdminfee(totalpurchase, total);

                    }
                    else {
                        PACalculationOwnerTradeIn_FractionalAdminfee(totalpurchase, total);
                    }
                }
                else {

                    PACalculationOwnerTradeIn_FractionalAdminfee(totalpurchase, total);

                }

            }
        }

        function pay_method() {
            var startvalue, endvalue, financeno;
            var contract_type = document.getElementById("contracttypeTextBox").value;
             
            var v = document.getElementById("VenueDropDownList");
            var venue = v.options[v.selectedIndex].text;
            var ent1 = document.getElementById("financemethodDropDownList");
            var ent = ent1.options[ent1.selectedIndex].text;
            var emi = "60";
            document.getElementById("noemiTextBox").value = emi;
            if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals")
            {
                if (ent == "CROWN FINANCE" || ent == "Crown Finance") {
                    //  document.getElementById("pnumb").style.display = 'block';
                    document.getElementById("lblfinanceno").style.display = 'none';// 'block';
                    document.getElementById("FinancenoTextBox").style.display = 'none';// 'block';
                    document.getElementById("lblnoemi").style.display = 'block';
                    document.getElementById("noemiTextBox").style.display = 'block';
                    document.getElementById("lblemiamt").style.display = 'block';
                    document.getElementById("emiamtTextBox").style.display = 'block';
                    
                        EMICrownFinance();
                   

                }
                else if (ent == "PASHURAM FINANCE" || ent == "Pashuram Finance") {
                    //  document.getElementById("pnumb").style.display = 'block';
                    document.getElementById("lblfinanceno").style.display = 'none';//'block';
                    document.getElementById("FinancenoTextBox").style.display = 'none';// 'block';
                    document.getElementById("lblnoemi").style.display = 'block';
                    document.getElementById("noemiTextBox").style.display = 'block';
                    document.getElementById("lblemiamt").style.display = 'block';
                    document.getElementById("emiamtTextBox").style.display = 'block';
                    //calculation
                    EMICalculation_fractional();


                }
                else
                {
                    //document.getElementById("pnumb").style.display = 'none';
                    document.getElementById("lblfinanceno").style.display = 'none';
                    document.getElementById("FinancenoTextBox").style.display = 'none';
                    document.getElementById("lblnoemi").style.display = 'none';
                    document.getElementById("noemiTextBox").style.display = 'none';
                    document.getElementById("lblemiamt").style.display = 'none';
                    document.getElementById("emiamtTextBox").style.display = 'none';

                }
            }
            else
            {
                
                if (ent == "CROWN FINANCE" || ent == "Crown Finance")
                {
                    //  document.getElementById("pnumb").style.display = 'block';
                    document.getElementById("lblfinanceno").style.display = 'none';// 'block';
                    document.getElementById("FinancenoTextBox").style.display = 'none';//'block';
                    document.getElementById("lblnoemi").style.display = 'block';
                    document.getElementById("noemiTextBox").style.display = 'block';
                    document.getElementById("lblemiamt").style.display = 'block';
                    document.getElementById("emiamtTextBox").style.display = 'block';
                  
                        EMICrownFinance();
                   


                }
                else if (ent == "PASHURAM FINANCE" || ent == "Pashuram Finance")
                {
                  
                     
                    document.getElementById("lblfinanceno").style.display = 'none';// 'block';
                    document.getElementById("FinancenoTextBox").style.display = 'none';//'block';
                    document.getElementById("lblnoemi").style.display = 'block';
                    document.getElementById("noemiTextBox").style.display = 'block';
                    document.getElementById("lblemiamt").style.display = 'block';
                    document.getElementById("emiamtTextBox").style.display = 'block';
             
                    EMICalculation();

                }
              
            }
        }
    

        function PointsPurchase1() {
           
            var holidayplus, emerald, total, registry;

            var contract_type = document.getElementById("contracttypeTextBox").value;
           
            //get venue name
            var v = document.getElementById("VenueDropDownList");
            var venue = v.options[v.selectedIndex].text;
            //get venue grp name
            var vg = document.getElementById("GroupVenueDropDownList");
            var venuegroup = vg.options[vg.selectedIndex].text;
            var m = document.getElementById("MarketingProgramDropDownList");
            var mktg = m.options[m.selectedIndex].text;
            var cy = document.getElementById("currencyDropDownList");
            var currency = cy.options[cy.selectedIndex].text;
            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
            document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
            document.getElementById("intialdeppercentTextBox").style.display = 'BLOCK';
            var regcollterm = document.getElementById("regcollectiontermTextBox").value;
            
            //load affilaiation values based on selected checkbox

            if (currency == "INR") {
                if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false)) {
                    emerald = "0";
                    holidayplus = "0";
                    registry = "0";
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    document.getElementById("nonfinbalamtTextBox").value = total;

                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true)) {

                    emerald = "0";
                    holidayplus = "0";
                    if (regcollterm < 5) {
                        // alert("less than 5");
                        var regcollamt = document.getElementById("regcollamtTextBox").value;
                        //  alert("textbox value:" + regcollamt);
                        registry = regcollamt;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //  alert(total);
                    }

                    else if (regcollterm = 5) {
                        registry = "47302";
                        document.getElementById("regcollamtTextBox").value = registry;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //alert(total);
                    }
                    document.getElementById("nonfinbalamtTextBox").value = total;

                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false)) {
                    emerald = "0";
                    holidayplus = "2680";
                    registry = "0";
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    document.getElementById("nonfinbalamtTextBox").value = total;
                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true)) {
                    emerald = "0";
                    holidayplus = "2680";
                    //registry = "47302";
                    if (regcollterm < 5) {
                        // alert("less than 5");
                        var regcollamt = document.getElementById("regcollamtTextBox").value;
                        //  alert("textbox value:" + regcollamt);
                        registry = regcollamt;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        
                    }

                    else if (regcollterm = 5) {
                        registry = "47302";
                        document.getElementById("regcollamtTextBox").value = registry;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //alert(total);
                    }
                    document.getElementById("nonfinbalamtTextBox").value = total;
                }
                if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false)) {
                    emerald ="0";// "23852";
                    holidayplus = "0";
                    registry = "0";
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    document.getElementById("nonfinbalamtTextBox").value = total;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true)) {
                    emerald = "0";//"23852";
                    holidayplus = "0";
                    //registry = "47302";
                    if (regcollterm < 5) {
                        // alert("less than 5");
                        var regcollamt = document.getElementById("regcollamtTextBox").value;
                        //  alert("textbox value:" + regcollamt);
                        registry = regcollamt;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //  alert(total);
                    }

                    else if (regcollterm = 5)
                    {
                        registry = "47302";
                        document.getElementById("regcollamtTextBox").value = registry;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //alert(total);
                    }
                    document.getElementById("nonfinbalamtTextBox").value = total;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false)) {
                    emerald ="0";// "23852";
                    holidayplus = "2680";
                    registry = "0";
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    document.getElementById("nonfinbalamtTextBox").value = total;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true)) {
                    emerald = "0";//"23852";
                    holidayplus = "2680";
                    if (regcollterm < 5) {
                        // alert("less than 5");
                        var regcollamt = document.getElementById("regcollamtTextBox").value;
                        //  alert("textbox value:" + regcollamt);
                        registry = regcollamt;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //  alert(total);
                    }

                    else if (regcollterm = 5) {
                        registry = "47302";
                        document.getElementById("regcollamtTextBox").value = registry;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //alert(total);
                    }
                    document.getElementById("nonfinbalamtTextBox").value = total;
                   
                }
                

            }
            else if (currency == "USD") {
                if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false)) {
                    emerald = "0";
                    holidayplus = "0";
                    registry = "0";
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true)) {
                    emerald = "0";
                    holidayplus = "0";
                    //registry = "706";
                    //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    if (regcollterm < 5) {
                        // alert("less than 5");
                        var regcollamt = document.getElementById("regcollamtTextBox").value;
                        //  alert("textbox value:" + regcollamt);
                        registry = regcollamt;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //  alert(total);
                    }

                    else if (regcollterm = 5) {
                        registry = "706";
                        document.getElementById("regcollamtTextBox").value = registry;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //alert(total);
                    }
                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false)) {
                    emerald = "0";
                    holidayplus = "40";
                    registry = "0";
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true)) {
                    emerald = "0";
                    holidayplus = "40";
                    //registry = "706";
                    //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    if (regcollterm < 5) {
                        // alert("less than 5");
                        var regcollamt = document.getElementById("regcollamtTextBox").value;
                        //  alert("textbox value:" + regcollamt);
                        registry = regcollamt;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //  alert(total);
                    }

                    else if (regcollterm = 5) {
                        registry = "706";
                        document.getElementById("regcollamtTextBox").value = registry;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //alert(total);
                    }
                }
                if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false)) {
                    emerald = "0";//"150";
                    holidayplus = "0";
                    registry = "0";
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true)) {
                    emerald = "0";//"150";
                    holidayplus = "0";
                    //registry = "706";
                    //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    if (regcollterm < 5) {
                        // alert("less than 5");
                        var regcollamt = document.getElementById("regcollamtTextBox").value;
                        //  alert("textbox value:" + regcollamt);
                        registry = regcollamt;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //  alert(total);
                    }

                    else if (regcollterm = 5) {
                        registry = "706";
                        document.getElementById("regcollamtTextBox").value = registry;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //alert(total);
                    }
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false)) {
                    emerald ="0";// "150";
                    holidayplus = "40";
                    registry = "0";
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true)) {
                    emerald ="0";// "150";
                    holidayplus = "40";
                    //registry = "706";
                    //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    if (regcollterm < 5) {
                        // alert("less than 5");
                        var regcollamt = document.getElementById("regcollamtTextBox").value;
                        //  alert("textbox value:" + regcollamt);
                        registry = regcollamt;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //  alert(total);
                    }

                    else if (regcollterm = 5) {
                        registry = "706";
                        document.getElementById("regcollamtTextBox").value = registry;
                        // alert(registry);
                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                        //alert(total);
                    }
                }
                // var ad = "1110";
                //  document.getElementById("adminamtfeesTextBox").value = ad;

            }


            var radio = document.getElementsByName('financeradiobuttonlist');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    var checkvalue = radio[i].value;
                }
            }

            if (contract_type == "Fractional") {

                //if (venuegroup == "Inhouse")
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    //if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner") 
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")

                    {
                        PACalculationOwnerFractional(totalpurchase, total);


                    }

                    else {
                        // PACalculationNonMember(totalpurchase, total);
                        PACalculationOwnerFractional(totalpurchase, total);

                    }

                }
                else {
                    //  PACalculationNonMember(totalpurchase, total);
                    PACalculationOwnerFractional(totalpurchase, total);
                }
            }
             
            else if (contract_type == "Points") {
                  
             
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    // if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")  
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" ||mktg=="MEMBER MARKETING GOA"||mktg=="MMG" )

                    {
                        PACalculationOwner(totalpurchase, total);

                    }//if block mktg
                    else {

                        PACalculationNonMember(totalpurchase, total);

                    }//else block mktg
                }//if block venuegrp
                else
                {
                     
                    PACalculationNonMember(totalpurchase, total);

                }//else block venuegrp

            }//else contract type
            else if (contract_type == "Trade-In-Points") {
                //  if (venuegroup == "Inhouse")
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    //   if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")

                    {

                        PACalculationOwner_TradeIn(totalpurchase, total);
                    }
                    else {
                        PACalculationNonMember_TradeIn(totalpurchase, total);

                    }
                }
                else {
                    PACalculationNonMember_TradeIn(totalpurchase, total);

                }

            }
            else if (contract_type == "Trade-In-Weeks") {
                // if (venuegroup == "Inhouse")
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    //  if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")

                    {

                        PACalculationOwner_TradeIn(totalpurchase, total);
                    }
                    else {
                        PACalculationNonMember_TradeIn(totalpurchase, total);

                    }
                }
                else {
                    PACalculationNonMember_TradeIn(totalpurchase, total);

                }

            }
            else if (contract_type == "Trade-In-Fractionals") {
                //            
                if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY") {
                    //if (mktg == "OWNER" || mktg == "OWNER DOWNGRADE" || mktg == "Owner Downgrade" || mktg == "Owner")
                    if (mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "OWNER" || mktg == "RCIOWN" || mktg == "RCIOwn" || mktg == "Member" || mktg == "MEMBER" || mktg == "RCIMBR" || mktg == "RCIMbr" || mktg == "MEMBER MARKETING GOA" || mktg == "MMG")

                    {

                        PACalculationOwnerTradeIn_Fractional(totalpurchase, total);

                    }
                    else
                    {
                        PACalculationOwnerTradeIn_Fractional(totalpurchase, total);
                    }
                }
                else
                {
                    
                    PACalculationOwnerTradeIn_Fractional(totalpurchase, total);
                   
                }

            }
             
        }
 






        function GetRDBValue() {
            var radio = document.getElementsByName('rdbGender');
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {
                    //  alert(radio[i].value);
                }
            }
        }

        
    
    
</script>

        <style type="text/css">
            #tabs {
                padding: 10px;
                border: 1px solid #4c4c4c;
                /* max-width:1000px;*/
            }
             #MemType2DropDownList, #Memno2TextBox,#Label12,#Label16{
                  display: none;
             }
           

           #panel, #chs2, #chs3,#chs3a,#chs4a,#panel2,#panel3,#panel4 ,#lblforeigncurrency, #foreigncurrencyTextBox,#testadminfeeTextBox,#invoicedateTextBox,#lblinvoicedate,
           #lbloldcanxamt,#oldcanxamtTextBox
           {
                display: none;
            }

            #TextBox22 {
                vertical-align: top;
            }

            #cleft {
                float: left;
            }

            #cright {
                float: right;
                display: block;
            } 

            #financetitle {
                float: right;
               display: block; 
                width: 600px;
            }

            #cdiv1, #cdiv2, #cdiv3, #cdiv4, #cdivtradeinweeks, #cdivtradeinpoints,#fractionalweeks,#fractionalpoints {
               display: block; 
            }
           /*#lblfinancemethod, #financemethodDropDownList, #lblfinanceno, #FinancenoTextBox, #lblbaladepamt, #baldepamtTextBox, */
             #identitytable, #yes, #yes1, #yess1, #yes2, #yess2, #ptyes1,#pyess1, #remarks, #Points, #pnumb,    #lblbalamtpayable, #balamtpayableTextBox, #lblnoinstallment, #NoinstallmentTextBox, #lblinstallmentamt, #installmentamtTextBox,  #lblbalinitialdep, #balinitialdepamtTextBox {
                 display: block; 
            }

         
            .space {
                margin-right: 10px;
            }

            body 
            {
            }
            /*#incrTextBox,*/
            #ffractional1, #tfractional, #pointsamtTextBox, #pointstaxTextBox, #testTextBox,#nonfinbalamtTextBox, #AffiliationamtTextBox,#incrTextBox,#lastfingennoTextBox, #AffiliationvalueTextBox,#ContractdetailsIDTextBox,   #officeTextBox,
             #lblchk2,
            #ca2
 {
                float:left;
              display: none;
            }

            p {
                margin: 0px;
                padding: 0px;
            }

            .auto-style1 {
                width: 157px;
            }
            .auto-style2 {
                height: 30px;
            }
            

            .auto-style3 {
                width: 99px;
            }
            .auto-style4 {
                width: 14px;
            }
            

            .auto-style5 {
                width: 127px;
            }
            .auto-style6 {
                width: 129px;
            }
            .auto-style7 {
                width: 492px;
            }
            

        </style>

</head>
<body>
 
<div id="tabs">
     <button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
  <form id="form1" runat="server"> 
        
  <ul>
    <li><a href="#tabs-1">Profile</a></li>
    <li><a href="#tabs-2">Contract</a></li>
     <li><a href="#tabs-3">SOR/Additional Names</a></li>   
    <li><a href="#tabs-4">Finance Details</a></li>
    <li><a href="#tabs-5">Print</a></li>
      <li><a href="#tabs-6">Additional Receipt</a></li>
  </ul>
        <a href="#tabs-5">
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
      </a>

  <div id="tabs-1">
    <div style="border:thin solid #C0C0C0;">
      
        
       <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PROFILE</h3><asp:TextBox ID="TextBox3" runat="server" Enabled="True" style="display:none;" Font-Size="Small"></asp:TextBox>
        <hr />
        <br />
          
         <table style="width:100%; ">

             <tbody>
               <tr>
                   <td class="auto-style2"><asp:Label ID="Label1" runat="server" Text="Profile ID" Font-Size="Medium"></asp:Label> </td>
                   <td class="auto-style2"><asp:TextBox ID="profileidTextBox" runat="server" style="width:170px; height:20px" Enabled="True" ReadOnly="True" Font-Size="Small"></asp:TextBox> </td>
                   <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="Date Insert" Font-Size="Medium"></asp:Label></td>
                   <td class="auto-style2"><asp:TextBox ID="indateTextBox" runat="server" Enabled="False" style="width:170px; height:20px" ReadOnly="True" Font-Size="Small"></asp:TextBox></td>
                   <td class="auto-style2"><asp:Label ID="Label3" runat="server" Text="Created By" Font-Size="Medium"></asp:Label></td>
                   <td class="auto-style2"><asp:TextBox ID="createdbyTextBox" runat="server" Enabled="True" style="width:170px; height:20px" ReadOnly="True" Font-Size="Small"></asp:TextBox></td>
                    <td class="auto-style2"><asp:Label ID="Label7" runat="server" Font-Size="Medium" Text="Label">Marketing Program</asp:Label></td>
                   <td class="auto-style2"><asp:DropDownList ID="MarketingProgramDropDownList" style="width:170px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                   <%--   <td>   &nbsp;</td>
                   <td>   &nbsp;</td>--%>
               </tr>
           
               <tr>
                   <td>   <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Label">Venue Country</asp:Label></td>
                   <td>  <asp:DropDownList ID="VenueCountryDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server" ></asp:DropDownList></td>
                   <td>  <asp:Label ID="Label5" runat="server" Font-Size="Medium"  Text="Label">Venue</asp:Label></td>
                   <td>  <asp:DropDownList ID="VenueDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td>  <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Label">Group Venue</asp:Label></td>
                   <td>  <asp:DropDownList ID="GroupVenueDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label126" runat="server" Font-Size="Medium" Text="Label">Sub Venue</asp:Label></td>
                   <td><asp:DropDownList ID="SubVenueDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                  
               </tr>
               <tr>
                   <td><asp:Label ID="Label8" runat="server" Font-Size="Medium" Text="Label">Agents</asp:Label></td>
                   <td><asp:DropDownList ID="AgentDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td><asp:Label ID="Label9" runat="server" Text="TO Name" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="TONameDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td><asp:Label ID="Label205" runat="server" Text="Manager" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="ManagerDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label127" runat="server" Text="Lead Office" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="LeadOfficeDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>

                   <td><asp:TextBox ID="officeTextBox" runat="server" Font-Size="Small" ReadOnly="True"   Width="47px"></asp:TextBox></td>
                   <td>&nbsp;</td>
               </tr>
                  <tr>
                  
                    <td><asp:Label ID="Label159" runat="server" Text="Sub VGroups" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="SubVenueGroupDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" >
                       <asp:ListItem Value="">Select an Option</asp:ListItem>
                       <asp:ListItem Value="ODYSSEY">ODYSSEY</asp:ListItem>
                        <asp:ListItem Value="COLLECTIONS">COLLECTIONS</asp:ListItem>
                        <asp:ListItem Value="MC">MC</asp:ListItem>
                       </asp:DropDownList></td>

                 </tr>
                 <tr>

                     <td>
                         <input id="chs" type="checkbox" onclick="shows();" />
                         <asp:Label ID="Label10" runat="server" Text="Label">Are you a Member?</asp:Label></td>
                 </tr>

             </tbody>
         </table>
           <br />
           <table style="width:57%;">

               <tbody id="hidden1">
                   <tr>
                       <td><asp:Label ID="Label11" runat="server" Font-Size="Medium"  Text="Label">Choose source</asp:Label></td>
                       <td><asp:DropDownList ID="MemType1DropDownList" Font-Size="Small" Style="width:150px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label15" runat="server" Font-Size="Medium"  Text="Label">Member Number</asp:Label></td>
                       <td><asp:TextBox ID="Memno1TextBox" runat="server" Font-Size="Small" Style="width: 150px; height: 20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label114" runat="server" Font-Size="Medium" Text="Label">Type</asp:Label></td>
                       <td><asp:DropDownList ID="TypeDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label12" runat="server"  Font-Size="Medium"  Text="Label">Choose Member Type</asp:Label></td>
                       <td><asp:DropDownList ID="MemType2DropDownList" Font-Size="Small" Style="width: 150px; height: 25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label16" runat="server" Font-Size="Medium"  Text="Label">Member Number</asp:Label></td>
                       <td><asp:TextBox ID="Memno2TextBox" Font-Size="Small" Style="width:150px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                   </tr>


               </tbody>

           </table>
           <br />
        <br />
        </div>
       
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PRIMARY PROFILE</h3>
        <hr />
        <br />
          <table style="width:100%;">
              <tr>

                  <td><asp:Label ID="Label86" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                  <td><asp:DropDownList ID="PrimaryTitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label13" runat="server"  Text="Label">First Name</asp:Label></td>
                   <td> <asp:TextBox ID="pfnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td> <asp:Label ID="Label14" runat="server" Text="Label">Last Name</asp:Label></td>
                   <td> <asp:TextBox ID="plnameTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                   <td>  <asp:Label ID="Label17" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                   <td> <asp:TextBox ID="primarydobdatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
              </tr>

              <tr>
                  <td></td>
                  <td></td>
                   <td> <asp:Label ID="Label18" runat="server" Text="Label">Nationality</asp:Label></td>
                   <td> <asp:DropDownList ID="PrimarynationalityDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server">
                        <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList></td>
                   <td> <asp:Label ID="Label19" runat="server" Text="Label">Country</asp:Label></td>
                   <td> <asp:DropDownList ID="primarycountryDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server">
                        <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList></td>
                  <td> <asp:Label ID="Label107" runat="server" Text="Label">Age</asp:Label></td>
                  <td>  <asp:TextBox ID="primaryAge" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
              </tr>

              <tr>
                  <td></td>
                  <td></td>
                   <td> <asp:Label ID="Label21" runat="server" Text="Label">Mobile #</asp:Label></td>
                   <td> <asp:DropDownList ID="primarymobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                        <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:TextBox ID="pmobileTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td> <asp:Label ID="Label22" runat="server" Text="Label">Alt Mob #</asp:Label></td>
                   <td> <asp:DropDownList ID="primaryalternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                        <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:TextBox ID="palternateTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label121" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                   <td><asp:DropDownList ID="pofficecodeDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px">
                        <asp:ListItem Value=" "></asp:ListItem>
                       </asp:DropDownList>&nbsp;<asp:TextBox ID="pofficenoTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   
                   
              </tr>
              <tr>
                  <td></td>
                  <td></td>
                    <td> <asp:Label ID="Label20" runat="server" Text="Label">Email</asp:Label></td>
                  <td>  <asp:TextBox ID="pemailTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    <td> <asp:Label ID="Label71" runat="server" Text="Label">Email2</asp:Label></td>
                  <td>  <asp:TextBox ID="pemail2TextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                  <td><asp:Label ID="Label160" runat="server" Font-Size="Medium" Text="Home #"></asp:Label></td>
                    <td><asp:DropDownList ID="phomecodeDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px">
                          <asp:ListItem Value=" "></asp:ListItem>
                    </asp:DropDownList>&nbsp;<asp:TextBox ID="phomenoTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
              </tr>
             
               <tr>
                  <td></td>
                   <td></td>
                  <td><asp:Label ID="Label80" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                  <td><select multiple="multiple"  style="width:175px; height:70px" id="primlg" name="primarylang" >
                             <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
              </tr>


          </table>
          <br />
        <br />
         </div>
     
         
        <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>SECONDARY PROFILE</h3>
        <hr />
         <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label81" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td> <asp:DropDownList ID="secondarytitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td> <asp:Label ID="Label23" runat="server" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sfnameTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label24" runat="server" Text="Label">Last Name</asp:Label></td>
                        <td> <asp:TextBox ID="slnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px"  Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label25" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                        <td> <asp:TextBox ID="secondarydobdatepicker" Font-Size="Small" style="width:170px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td>  <asp:Label ID="Label26" runat="server" Text="Label">Nationality</asp:Label></td>
                        <td>  <asp:DropDownList ID="secondarynationalityDropDownList" style="width:175px; height:25px"  Font-Size="Small"  runat="server"></asp:DropDownList></td>
                        <td> <asp:Label ID="Label27" runat="server" Text="Label">Country</asp:Label></td>
                        <td>  <asp:DropDownList ID="secondarycountryDropDownList" Font-Size="Small" style="width:175px; height:25px"  runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label108" runat="server" Text="Label">Age</asp:Label></td>
                        <td> <asp:TextBox ID="secondaryAge" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td></td>
                        <td></td>
                        <td><asp:Label ID="Label29" runat="server" Text="Label">Mobile #</asp:Label></td>
                        <td> <asp:DropDownList ID="secondarymobileDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server">
                             <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="smobileTextBox" runat="server" Style="width: 95px; height: 20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>

                        <td> <asp:Label ID="Label30" runat="server" Text="Label">Alt.Mob #</asp:Label></td>
                        <td><asp:DropDownList ID="secondaryalternateDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server">
                             <asp:ListItem Value=" "></asp:ListItem>
                            </asp:DropDownList>&nbsp;<asp:TextBox ID="salternateTextBox" runat="server" Style="width: 95px; height: 20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label122" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                        <td><asp:DropDownList ID="sofficecodeDropDownList" runat="server" Font-Size="Small" Style="width: 70px; height: 25px">
                             <asp:ListItem Value=" "></asp:ListItem>
                            </asp:DropDownList>&nbsp;<asp:TextBox ID="sofficenoTextBox" runat="server" Font-Size="Small" Style="width: 95px; height: 20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                          <td><asp:Label ID="Label28" runat="server" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="semailTextBox" runat="server" Style="width: 170px; height: 20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label73" runat="server" Text="Label">Email2</asp:Label></td>
                  <td>  <asp:TextBox ID="semail2TextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td>
                            <asp:Label ID="Label161" runat="server" Font-Size="Medium" Text="Home #"></asp:Label></td>
                         <td>
                            <asp:DropDownList ID="shomecodeDropDownList" runat="server" Font-Size="Small" Style="width: 70px; height: 25px">
                                <asp:ListItem Value=" "></asp:ListItem>
                            </asp:DropDownList>&nbsp;<asp:TextBox ID="shomenoTextBox" runat="server" Font-Size="Small" Style="width: 95px; height: 20px" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                  <td></td>
                   <td></td>
                  <td><asp:Label ID="Label87" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" id="seclang" name="seclang">
                             <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
              </tr>
                </tbody>
            </table>
         <br />
        <br />
        </div>
 
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>ADDRESS</h3>
        <hr />
        <br />

          <table style="width:100%;">
              <tbody>
                  <tr>

                      <td ><asp:Label ID="Label31" runat="server" Font-Size="Medium" Style="width:200px;" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address1TextBox" Font-Size="Small" runat="server" Enabled="True" Width="250px" Height="62px"></asp:TextBox></td>
                      <td ><asp:Label ID="Label32" Font-Size="Medium" runat="server"  Text="Label">Address Line2</asp:Label></td>
                      <td><asp:TextBox ID="address2TextBox" Font-Size="Small" runat="server"  Enabled="True" Width="250px" Height="62px"></asp:TextBox></td>
                       <td ><asp:Label ID="Label112" Font-Size="Medium" runat="server"  Text="Label">Country</asp:Label></td>
                      <td><asp:DropDownList ID="AddCountryDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                  </tr>
                  <tr>

                      <%-- <td><asp:Label ID="Label33" runat="server" Text="Label">State</asp:Label></td>
                      <td><asp:TextBox ID="stateTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>--%>
                          <td><asp:Label ID="Label333" runat="server" Text="Label">State</asp:Label></td>
                      <td><asp:DropDownList ID="StateDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label34" runat="server" Text="Label">City</asp:Label></td>
                      <td><asp:TextBox ID="cityTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label39" runat="server" Text="Label">Pincode</asp:Label></td>
                      <td><asp:TextBox ID="pincodeTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small"  Enabled="True"></asp:TextBox></td>
                  </tr>
                 
              </tbody>
          </table>
       <br />
       <br />
    </div>
         <br />
            <table style="width:100%;">
               <tbody>       
            <tr>
                <td width="100px">
                   <div id="coradd"> 
                       <asp:CheckBox ID="coraddCheckBox" runat="server" BorderStyle="None"    Font-Bold="true" Font-Italic="true" ForeColor="RosyBrown"  Font-Size="Large" Text="Same as Permanent Address" Width="483px" /></div>
                </td>
            </tr> 
           </tbody>           
           </table>
                <br />
          <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>CORRESPONDENCE ADDRESS</h3>
        <hr />
        <br />

          <table style="width:100%;">
              <tbody>
                  <tr>
                     
                      <td ><asp:Label ID="lblcadd1" runat="server" Font-Size="Medium" Style="width:200px;" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="cadd1TextBox" Font-Size="Small" runat="server" Enabled="True" Width="250px" Height="62px"></asp:TextBox></td>
                      <td ><asp:Label ID="lblcadd2" Font-Size="Medium" runat="server"  Text="Label">Address Line2</asp:Label></td>
                      <td><asp:TextBox ID="cadd2TextBox" Font-Size="Small" runat="server"  Enabled="True" Width="250px" Height="62px"></asp:TextBox></td>
                       <td ><asp:Label ID="lblccountry" Font-Size="Medium" runat="server"  Text="Label">Country</asp:Label></td>
                      <td><asp:DropDownList ID="ccountryDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="lblcstate" runat="server" Text="Label">State</asp:Label></td>
                      <td><asp:DropDownList ID="cstateDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="lblccity" runat="server" Text="Label">City</asp:Label></td>
                      <td><asp:TextBox ID="ccityTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="lblcpincode" runat="server" Text="Label">Pincode</asp:Label></td>
                      <td><asp:TextBox ID="cpincodeTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small"  Enabled="True"></asp:TextBox></td>
                  </tr>
                 
              </tbody>
          </table>
       <br />
       <br />
    </div>

        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>OTHER DETAILS</h3>
        <hr />
        <br />
            <table style="width:100%;">
              <tbody>
                   <tr>
                      <td><asp:Label ID="Label40" runat="server" Text="Label">Employee Status</asp:Label></td>
                       <td><asp:DropDownList ID="employmentstatusDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label35" runat="server" Text="Label">Marital Status</asp:Label></td>
                       <td><asp:DropDownList ID="maritalstatusDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label41" runat="server" Text="Label">No of Year living together as a couple</asp:Label></td>
                       <td><asp:TextBox ID="livingyrsTextBox" Font-Size="Small" style="width:150px; height:20px"  runat="server"></asp:TextBox></td>
                  </tr>

                   <tr>
                      <td><asp:Label ID="Label90" runat="server" Font-Size="Medium" Text="Label">Professional/Designation</asp:Label></td>
                      <td></td>
                      <td><asp:Label ID="Label103" runat="server" Font-Size="Medium" Text="Label">Male</asp:Label></td>
                      <td><asp:TextBox ID="pdesginationTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label104" runat="server" Font-Size="Medium" Text="Label">Female</asp:Label></td>
                      <td><asp:TextBox ID="sdesignationTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>

                  </tr>

                   <tr>
                     <td><asp:Label ID="Label334" runat="server" Font-Size="Medium" Text="Company Name" BorderStyle="None"></asp:Label></td>
                      <td><asp:TextBox ID="companynameTextBox" Font-Size="Small" runat="server" Height="30px" TextMode="MultiLine" Width="251px"></asp:TextBox></td>
                      <td><asp:Label ID="Label335" runat="server" Font-Size="Medium" Text="GSTIN No" BorderStyle="None"></asp:Label></td>
                      <td><asp:TextBox ID="gstinTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label336" runat="server" Font-Size="Medium" Text="Pan Card #" BorderStyle="None"></asp:Label></td>
                      <td><asp:TextBox ID="PancardspellTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>
                         <td><asp:Label ID="Label91" runat="server" Font-Size="Medium" Text="Co.Pan Card" BorderStyle="None"></asp:Label></td>
                        <td><asp:TextBox ID="companypanoTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>
                       

                  </tr>
                  <tr>
                    <td><asp:Label ID="Label105" runat="server" Font-Size="Medium" Text="Label">Photo Identity</asp:Label></td>
                    <td><select multiple="multiple" style="width:155px; height:70px" id="phid" name="pidentity">
                        <option value="Membership Card">Membership Card(if member with any club)</option>
                          <option value="Driving License">Driving License</option>
                          <option value="Pan Card">PAN Card</option>
                          <option value="Passport">Passport</option>
                           <option value="Adhar Card">Adhar Card</option>
                          <option value="Others">Others</option>


                        </select></td>
                    <td><asp:Label ID="Label106" runat="server" Font-Size="Medium" Text="Label">Kind Of Card</asp:Label></td>
                     <td><select multiple="multiple" style="width:155px; height:70px"id="card" name="card">
                        <option value="Titanium">Titanium</option>
                        <option value="Platinum">Platinum</option>
                        <option value="Gold">Gold</option>
                        <option value="Silver">Silver</option>
                        <option value="Visa">Visa</option>
                        <option value="Mastercard">Mastercard</option>
                        <option value="Debit Card">Debit Card</option>
                        <option value="Others">Others</option>
                        </select></td>

                  </tr>

                  </tbody>
                </table>
             <br />
       <br />
            </div>
      
   <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs2" type="checkbox" onclick="shows2();"/>
       
 <label for="chs2">SUB PROFILE 1</label>      
        <div id="panel" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
           <tbody>

               <tr>
                   <td><asp:Label ID="Label200" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                   <td><asp:DropDownList ID="sp1titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                    <td><asp:Label ID="Label36" runat="server"  Text="Label">First Name</asp:Label></td>
                    <td><asp:TextBox ID="sp1fnameTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label37" runat="server" Text="Label">Last Name</asp:Label></td>
                    <td><asp:TextBox ID="sp1lnameTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label38" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                    <td><asp:TextBox ID="sp1dobdatepicker" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    
               </tr>

               <tr>
                   <td></td>
                   <td></td>
                   <td><asp:Label ID="Label42" runat="server" Text="Label">Nationality</asp:Label></td>
                   <td><asp:DropDownList ID="sp1nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td><asp:Label ID="Label43" runat="server" Text="Label">Country</asp:Label></td>
                   <td><asp:DropDownList ID="sp1countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td><asp:Label ID="Label109" runat="server" Text="Label">Age</asp:Label></td>
                   <td><asp:TextBox ID="subProfile1Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                  
               </tr>
               <tr>
                   <td></td>
                   <td></td>
                    <td><asp:Label ID="Label45" runat="server" Text="Label">Mobile Number</asp:Label></td>
                    <td> <asp:DropDownList ID="sp1mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                          <asp:ListItem Value=" "></asp:ListItem>
                         </asp:DropDownList>&nbsp;<asp:TextBox ID="sp1mobileTextBox" style="width:95px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                    <td> <asp:Label ID="Label46" runat="server" Text="Label">Alternate Number</asp:Label></td>
                    <td><asp:DropDownList ID="sp1alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                          <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:TextBox ID="sp1alternateTextBox" runat="server" style="width:95px;  height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                     <td><asp:Label ID="Label44" runat="server" Text="Label">Email</asp:Label></td>
                   <td><asp:TextBox ID="sp1pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                   
                    <td> <asp:Label ID="Label74" runat="server" Text="Label">Email2</asp:Label></td>
                  <td>  <asp:TextBox ID="sp1pemail2TextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
               </tr>
           </tbody>
       </table>
          <br />
          <br /> 
    </div>
       <br />
     <br />
   </div>
     
     <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs3" type="checkbox" onclick="shows3();"/>
 <label for="chs3">SUB PROFILE 2</label>      
        <div id="panel2" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label78" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp2titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label47" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp2fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label48" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp2lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label49" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp2dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label50" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp2nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label51" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp2countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label110" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile2Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>

                    </tr>

                    <tr> 
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label53" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp2mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                               <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp2mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label54" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp2alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                               <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp2alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label52" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp2pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        
  <td> <asp:Label ID="Label75" runat="server" Text="Label">Email2</asp:Label></td>
                  <td>  <asp:TextBox ID="sp2pemail2TextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>

         <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs3a" type="checkbox" onclick="shows3a();"/>
 <label for="chs3a">SUB PROFILE 3</label>      
        <div id="panel3" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label129" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp3titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label130" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp3fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label131" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp3lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label132" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp3dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                  
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label133" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp3nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label134" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp3countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label135" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile3Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>

                    </tr>
                          
                    <tr> 
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label136" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp3mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                               <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp3mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label137" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp3alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                               <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp3alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label138" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp3pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                          <td> <asp:Label ID="Label76" runat="server" Text="Label">Email2</asp:Label></td>
                  <td>  <asp:TextBox ID="sp3pemail2TextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                    
                </tbody>
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>


        
             <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs4a" type="checkbox" onclick="shows4a();"/>
 <label for="chs4a">SUB PROFILE 4</label>      
        <div id="panel4" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label139" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp4titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label140" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp4fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label141" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp4lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label142" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp4dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label143" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp4nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label144" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp4countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label145" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile4Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                          

                    </tr>     
                    <tr>     
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label155" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp4mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                               <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp4mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label156" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp4alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                               <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp4alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label157" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp4pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                          <td> <asp:Label ID="Label85" runat="server" Text="Label">Email2</asp:Label></td>
                  <td>  <asp:TextBox ID="sp4pemail2TextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>


 
        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>STAY DETAILS</h3>
        <hr />
        <br />
           
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td> <asp:Label ID="Label55" runat="server" Text="Label">Resort Name</asp:Label></td>
                         <td>   <asp:TextBox ID="resortTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label56" runat="server" Text="Label">Resort Room No</asp:Label></td>
                         <td> <asp:TextBox ID="roomnoTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label57" runat="server" Text="Label">Arrival</asp:Label></td>
                         <td> <asp:TextBox ID="arrivaldatedatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label58" runat="server" Text="Label">Departure</asp:Label></td>
                        <td><asp:TextBox ID="departuredatedatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label59" runat="server" Text="Label">Choose Gift Option</asp:Label></td>
                        <td> <asp:DropDownList ID="DropDownList32" Font-Size="Small" style="width:175px; height:25px"  runat="server"></asp:DropDownList></td>
                        <td> <asp:Label ID="Label60" runat="server" Text="Label">Voucher No.</asp:Label></td>
                        <td><asp:TextBox ID="TextBox13" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td> <asp:Label ID="Label61" runat="server" Text="Label">Comment if Any</asp:Label></td>
                        <td> <asp:TextBox ID="TextBox22" runat="server" style="width:170px; height:30px" Font-Size="Small" Enabled="True" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                        <td> <asp:Label ID="Label62" runat="server" Text="Label">Guest Status</asp:Label></td>
                        <td><asp:DropDownList ID="guestatusDropDownList" style="width:175px; height:25px" Font-Size="Small"  runat="server"></asp:DropDownList></td>
                    </tr>
                  
                    <tr>
                        <td><asp:Label ID="Label202" runat="server" Text="Tour Date"></asp:Label></td>
                         <td><asp:TextBox ID="tourdatedatepicker" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label63" runat="server" Text="Label">Sales Represntative</asp:Label></td>
                         <td><asp:DropDownList ID="toursalesrepDropDownList"  Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label64" runat="server" Text="Label">Sales Deck Check-In Time</asp:Label></td>
                         <td><asp:TextBox ID="timeinTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label65" runat="server" Text="Label">Sales Deck Check-Out Time</asp:Label></td>
                         <td><asp:TextBox ID="timeoutTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label66" runat="server" Text="Label">Taxi in Price</asp:Label></td>
                         <td><asp:TextBox ID="inpriceTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label67" runat="server" Text="Label">Taxi in Reference</asp:Label></td>
                         <td><asp:TextBox ID="inrefTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label68" runat="server" Text="Label">Taxi out Price</asp:Label></td>
                         <td><asp:TextBox ID="outpriceTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label69" runat="server" Text="Label">Taxi out Reference</asp:Label></td>
                         <td> <asp:TextBox ID="outrefTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table> 

              <table style="width: 56.5%;">

                <tr>
                    <td>
                        <asp:Label ID="Label33" runat="server" Font-Size="Medium" Text="Comment1" BorderStyle="None"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="commentsTextBox" runat="server" Style="width: 300px; height: 120px" TextMode="MultiLine"></asp:TextBox></td>

                </tr>

<tr>

 <td>
                        <asp:Label ID="Label339" runat="server" Font-Size="Medium" Text="Comment2" BorderStyle="None"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="comment2" runat="server" Style="width: 300px; height: 120px" TextMode="MultiLine"></asp:TextBox></td>
</tr>

            </table>
            <br />
            <br />
            <table style="width: 59%;">
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="Registration Card Terms" /></td>


                </tr>
            </table>
        <br />
        <br />
        </div>
        <br />
      
            <asp:Button ID="Button1" runat="server" Text="Spell Check" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
   &nbsp;&nbsp;&nbsp;&nbsp;  <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Update Profile" Width="160px" /> &nbsp;&nbsp;&nbsp;&nbsp;  
 
        <br />
         <br />
</div>
     
      <br />
      
  </div>

    <div id="tabs-2" style="background-color:#e9e9e9">
   
       <div id="contract_tab" style="margin-top:10px;margin-left:5px;margin-right:5px; margin-bottom:10px; border:thin solid #999999; overflow:hidden; ">
        
           <br />
             <table style="width:100%;">
                       <asp:Label ID="lblfcurr" runat="server"></asp:Label>
               <tbody>       
            <tr>
                <td width="100px">
                   <div id="bucheck"> 
                       <asp:CheckBox ID="BUCheckBox" runat="server" BorderStyle="None"  Font-Bold="true" Font-Italic="true" ForeColor="RosyBrown"  Font-Size="Large" Text="BU After 6 PM" Width="165px"/>

                   </div>
                </td>
                <td class="auto-style5">
                   <asp:CheckBox ID="repreportCheckBox" runat="server" BorderStyle="None"  Font-Bold="true" Font-Italic="true" ForeColor="RosyBrown"  Font-Size="Large" Text="Rep Report" Width="120px"/>
               </td>
                 <td class="auto-style6">
                   <asp:CheckBox ID="toreportCheckBox" runat="server" BorderStyle="None"  Font-Bold="true" Font-Italic="true" ForeColor="RosyBrown"  Font-Size="Large" Text="TO Report" Width="118px"/>
               </td>
                 <td class="auto-style7">
                   <asp:CheckBox ID="smsCheckBox" runat="server" BorderStyle="None"  Font-Bold="true" Font-Italic="true" ForeColor="RosyBrown"  Font-Size="Large" Text="SMS" Width="86px"/>
               </td>
            </tr> 
           </tbody>           
           </table>
                <br />
            <table style="width:100%;">
                <tbody>
                <tr>
                    <td class="auto-style1"> <asp:Label ID="Label206" runat="server"  BorderStyle="None" Font-Size="Medium" style="width:200px;"  Text="Choose Contract Type:"></asp:Label></td>
                    <td> 
                        <asp:TextBox ID="contracttypeTextBox" runat="server"></asp:TextBox>
                    </td>
                  
                </tr>
                      <tr>
                     <td class="auto-style1"> <asp:Label ID="Label123" runat="server"  BorderStyle="None" Font-Size="Medium" style="width:200px;"  Text="Select Option:"></asp:Label></td>
                     <td>
                         <%--<asp:RadioButtonList ID="updowngradeRadioButtonList" runat="server"  Font-Size="Medium"  RepeatDirection="Horizontal" Height="25px" Width="205px">
                            <asp:ListItem>Upgrade</asp:ListItem>
                            <asp:ListItem>Downgrade</asp:ListItem>                             
                        </asp:RadioButtonList>--%>
                          <asp:CheckBox ID="upCheckBox" runat="server" BorderStyle="None"  Font-Bold="true" Font-Italic="true" Font-Size="Medium" Text="Upgrade" Width="165px"/>
                         <asp:CheckBox ID="downCheckBox" runat="server" BorderStyle="None"  Font-Bold="true" Font-Italic="true" Font-Size="Medium" Text="Downgrade" Width="165px"/>

                     </td>
                  
                </tr>
                    
                <tr><td></td></tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="Label82" runat="server" Text="Sales Rep" BorderStyle="None" Font-Size="Medium"></asp:Label> </td>
                    <td><asp:TextBox ID="contsalesrepTextBox" Font-Size="Small" runat="server" Height="28px" TextMode="MultiLine" Width="202px"></asp:TextBox></td>
                    <td><asp:Label ID="Label83" runat="server" Text="TO Manager" BorderStyle="None" Font-Size="Medium"></asp:Label></td>
                    <td><asp:DropDownList ID="TOManagerDropDownList" runat="server" Font-Size="Small" style="width:200px; height:25px"><asp:ListItem></asp:ListItem></asp:DropDownList></td>
                    <td><asp:Label ID="Label84" runat="server" Text="Button Up" BorderStyle="None" Font-Size="Medium"></asp:Label></td>
                    <td><asp:DropDownList ID="ButtonUpDropDownList" Font-Size="Small" runat="server" style="width:200px; height:25px"><asp:ListItem Value=" "></asp:ListItem></asp:DropDownList></td>
                </tr>
                      <tr>
                      <td><asp:Label ID="lblLoanBUOfficer" runat="server" Text="Loan BU Officer" BorderStyle="None" Font-Size="Medium"></asp:Label></td>
                     <td>
                         <asp:DropDownList ID="LoanBUDropDownList" runat="server" Height="16px" Width="194px">
                             <asp:ListItem></asp:ListItem>
                         </asp:DropDownList>
                          </td>
                  </tr>
                 <tr>
                     <td><h5>CONTRACT NUMBER</h5></td>
               </tr>
               <tr>
                <td><asp:Label ID="Label96" runat="server" Font-Size="Medium" Text="Label">Generated Contract #</asp:Label></td>
                <td><asp:TextBox ID="contractnoTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                  
                 
                   <td><asp:Label ID="Label203"  Font-Size="Medium" runat="server" Text="Deal Registered Date"></asp:Label></td>
                <td><asp:TextBox ID="dealdateTextBox" style="width:200px; height:20px"  Font-Size="Small" runat="server" Enabled="True" ReadOnly="False"></asp:TextBox></td>
                <td><asp:Label ID="Label204" runat="server"  Font-Size="Medium" Text="Deal Status"></asp:Label></td>
                <td><asp:DropDownList ID="dealstatusDropDownList" style="width:200px;  height:25px" Font-Size="Small"  runat="server"></asp:DropDownList></td>
              </tr>
                <tr>
                <td><asp:Label ID="Label158" runat="server" Font-Size="Medium" Text="Label">Canx Contract #</asp:Label></td>
                <td><asp:TextBox ID="CanxContractNoTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
               
                       <td><asp:Label ID="lblReturnHomeDate"  Font-Size="Medium" runat="server" Text="Return Home Date"></asp:Label></td>
                <td><asp:TextBox ID="ReturnHomeDateTextBox" style="width:200px; height:20px"  Font-Size="Small" runat="server" Enabled="True" ReadOnly="False"></asp:TextBox></td>
               
                <td><asp:TextBox ID="ContractdetailsIDTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"  ></asp:TextBox></td>
                </tr>  
                      <tr>
                    <td width="100px" ><asp:Label ID="lblwoldLoanAgreement" runat="server" Font-Size="Medium" Text="Canx Loan Agreement No" BorderStyle="None" Width="180px"></asp:Label></td>
                    <td width="100px"><asp:TextBox ID="woldLoanAgreementTextBox" Font-Size="Small"  style="width:200px;   height:20px" runat="server" Enabled="True" Text="" ></asp:TextBox></td> 

                     <td width="100px" ><asp:Label ID="lblcontractgroup" runat="server" Font-Size="Medium" Text="Contract Group" BorderStyle="None" Width="158px"></asp:Label></td>
                     <td><asp:DropDownList ID="contractgroupDropDownList" style="width:200px;  height:25px" Font-Size="Small"  runat="server"></asp:DropDownList></td>
                   
                    <td width="100px" ><asp:Label ID="lblcontractvenue" runat="server" Font-Size="Medium" Text="Contract Venue" BorderStyle="None" Width="158px"></asp:Label></td>
                    <td><asp:DropDownList ID="contractvenueDropDownList" style="width:200px;  height:25px" Font-Size="Small"  runat="server"></asp:DropDownList></td>  
                           
                    </tr>
                    <tr>
                        <td></td><td></td><td></td>
                         <td width="100px" align="center"><asp:Button ID="Button2" runat="server" Text="Update Deal Status" OnClick="Button2_Click" Visible="False" /></td>
                    </tr>
                   
                </tbody>
            </table>
           <br /> 
           <table style="width:100%;">
               <tbody>       
            <tr>
                <td width="100px">
                   <div id="check"> 
                       <asp:CheckBox ID="mcRadioButtonList" runat="server"   BorderStyle="None" Font-Size="Small" Text="MC Waiver Applicable" Width="165px" /></div>
                </td>
            </tr> 
           </tbody>           
           </table>
         <div id="divref" >
                <table>
                    <tbody>                    
                    <tr>
                        <td class="auto-style4"><asp:Label ID="Label162" runat="server" Font-Size="Medium" Text="Label">Program Source</asp:Label></td>
                        <td width="50px"><asp:TextBox ID="PrgmsrcTextBox" runat="server" Width="230px" TextMode="MultiLine"></asp:TextBox></td>
                     
                        <td class="auto-style3"><asp:Label ID="Label163" runat="server" Font-Size="Medium" Text="Label">Referred By</asp:Label></td>
                       <td width="50px"><asp:TextBox ID="RefByTextBox" runat="server" Width="330px" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
                    </tr> 
                      
                    
                 </tbody>
                </table>

                </div>
           <br />
           <div id="contract-container">
          
            <div id="cleft" style="">
                <div id="cdiv1" >
                <table style="width:100%;">
                    <tbody>
                         <tr>                        
                             <td width="200px"><asp:Label ID="Label70" Font-Size="Medium" runat="server" Text="Label">OLD CONTRACT DETAILS</asp:Label></td>
                    </tr>
                    <tr>
                    <td width="200px"><asp:Label ID="Label111" Font-Size="Medium" runat="server" Text="Label">From Contract Type</asp:Label></td>
                    <td width="100px"><asp:DropDownList ID="oldcontracttypeDropDownList" runat="server"   style="width:205px; height:25px"></asp:DropDownList></td>
               
                        </tr>
                        <tr>
                        <td width="200px"><asp:Label ID="lbllabelname" Font-Size="Medium"  runat="server" Text="Label">TRADE IN DETAILS</asp:Label></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbltmresort" Font-Size="Medium"  runat="server" Text="Label">Resort</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tnmresortTextBox" Font-Size="Small"  runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbltmapttype" runat="server" Font-Size="Medium"  Text="Label">Apt Type</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tnmapttypeTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lbltnmseason" runat="server" Font-Size="Medium"  Text="Label">Season</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="tnmseasonDropDownList" Font-Size="Small" style="width:205px; height:25px" runat="server" ></asp:DropDownList></td>

                     </tr>                               
                      
                    <tr>
                        <td width="200px"><asp:Label ID="lnltnmnowks" runat="server" Font-Size="Medium"  Text="Label">No.Of Weeks</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmnowksTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbltnmcontrcino" runat="server" Font-Size="Medium"  Text="Label">Cont.No / Rci No</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmcontrcinoTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lbltwoldmtype" runat="server" Font-Size="Medium"  Text="Label">Membership Type</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="twoldmtypeTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lbltipnopoints" runat="server" Font-Size="Medium"  Text="Label">No. Of Points</asp:Label></td>
                        <td><asp:TextBox ID="tipnopointsTextBox" Font-Size="Small" onchange="pointscalculation();"   style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                  
                     <tr>
                        <td><asp:Label ID="lbltipptsvalue" Font-Size="Medium"  runat="server" Text="Label">Points Value</asp:Label></td>
                        <td><asp:TextBox ID="tipptsvalueTextBox" Font-Size="Small"  style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>  
                      
                      <tr>
                        <td><asp:Label ID="lbltipactualptsvalue" Font-Size="Medium"  runat="server" Text="Label">Actual Points Value</asp:Label></td>
                        <td><asp:TextBox ID="tipactualptsvalueTextBox" Font-Size="Small"  style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>  

                    <tr>
                     <td width="200px"><asp:Label ID="lblcontractlabel" Font-Size="Medium"  runat="server" Visible="false"  Text="Label"></asp:Label></td>  
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lblclub" Font-Size="Medium"  runat="server" Text="Label">Club</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="clubTextBox"   runat="server" Font-Size="Small"  style="width:205px; height:25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lblnewpts" runat="server" Font-Size="Medium"  Text="Label">New Points Rights</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="newpointsrightTextBox" onchange="pointscalculation();" Font-Size="Small" style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lblentitlement" runat="server" Font-Size="Medium"  Text="Label">Type Of Membership</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="EntitlementPoinDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>                               
                      
                    <tr>
                        <td width="200px"><asp:Label ID="lbltotalpoints" runat="server" Font-Size="Medium"  Text="Label">Total Points Rights</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="totalptrightsTextBox" Font-Size="Small"  runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lblfirstyr" runat="server" Font-Size="Medium"  Text="Label">First Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="firstyrTextBox" Font-Size="Small" style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td> <%--onchange="Procedure_Generation_Contract();" --%>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lbltenure" Font-Size="Medium"  runat="server" Text="Label">Tenure</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tenureTextBox" onchange="Procedure_Generation_Contract();" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbllastyr" runat="server" Font-Size="Medium"  Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="lastyrTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblNoPersons" Font-Size="Medium"  runat="server" Text="Label">No.Persons</asp:Label></td>
                        <td><asp:TextBox ID="NoPersonsTextBox" Font-Size="Small"  style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td><asp:Label ID="lbltradeinamt" runat="server" Text="Label">Trade In Value</asp:Label></td>
                        <td><asp:TextBox ID="tradeinamtTextBox" runat="server" onchange="fractionaltradeinamt();" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                      <tr>
                <td width="100px" ><asp:Label ID="lblopenLoanAgreement" runat="server" Font-Size="Medium" Text="Open Loan Agreement No" BorderStyle="None" Width="168px"></asp:Label></td>
                <td width="100px"><asp:TextBox ID="openLoanAgreementTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>    
                 <tr>
                <td width="100px" ><asp:Label ID="lblfoldloanamount" runat="server" Font-Size="Medium" Text="Open Loan Amount" BorderStyle="None" Width="119px"></asp:Label></td>
                <td width="100px"><asp:TextBox ID="foldloanamountTextBox" Font-Size="Small"  onchange="LoanEMICalculation();"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>  
               
                        <tr>
                        <td><asp:Label ID="lblfwresort" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td><asp:DropDownList ID="fwresortDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwresidenceno" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:DropDownList ID="fwresidencenoDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    
                     <tr>
                        <td><asp:Label ID="lblfwresidencetype" runat="server" Text="Label">Choose Residence Type</asp:Label></td>
                        <td><asp:DropDownList ID="fwresidencetypeDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                  
                     <tr>
                        <td><asp:Label ID="lblfwfractInt" runat="server" Text="Label">Fractional Interest</asp:Label></td>
                        <td><asp:DropDownList ID="fwfractIntDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwentitlement" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td><asp:DropDownList ID="fwentitlementDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwfirstyr" runat="server" Text="Label">First Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="fwfirstyrTextBox" runat="server" onchange="Procedure_Generation_Contract();" style="width:200px; height:20px"  Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfwtenure" runat="server" Text="Label">Tenure</asp:Label></td>
                        <td><asp:TextBox ID="fwtenureTextBox"  onchange="Procedure_Generation_Contract();" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwlastyr" runat="server" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="fwlastyrTextBox" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                 
                        </tbody>
                </table>

                </div>
                <div id="cdiv2">

                       
                        <asp:TextBox ID="incrTextBox" runat="server" Enabled="True"   Visible="False"  ></asp:TextBox>
                   
                    <asp:TextBox ID="lastfingennoTextBox" runat="server" Enabled="True"   Visible="False"  ></asp:TextBox>
                      <asp:TextBox ID="AffiliationvalueTextBox" runat="server" Enabled="True"   ></asp:TextBox>
                </div>
                
                
                
            </div>
                <div id="financetitle" style=" width:605px;">
                   <table style="width:100%;">
                   <tr>
                        <td width="100px">
                        <h5>FINANCE</h5>
                        </td>
                        <td><asp:RadioButtonList ID="financeradiobuttonlist"  runat="server"  Font-Size="large"  RepeatDirection="Horizontal"> 
                            <asp:ListItem Value="Finance">Finance</asp:ListItem>
                            <asp:ListItem Value="Non Finance">Non Finance</asp:ListItem>                             
                        </asp:RadioButtonList></td>
                       </tr>
                   
                     </table>
               </div>
              
            <div id="cright" style=" width:605px;">
                
            <table  cellpadding="3px" cellspacing="3px"> 
              <tr>
                <td width="100px"><asp:Label ID="lblMCFees" runat="server" Font-Size="Small" Text="Label">MC FEES</asp:Label></td>
                <td width="100px"><asp:TextBox ID="MCFeesTextBox"  Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
            </tr>  
             <tr>
                <td width="100px"><asp:Label ID="lblmcdate" runat="server" Font-Size="Small" Text="Label">MC PAYABLE DATE</asp:Label></td>
                <td width="100px"><asp:TextBox ID="MCdateTextBox"  Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
            </tr> 
                 <tr>
                <td width="100px"><asp:Label ID="lblmemberfee" runat="server" Font-Size="Small" Text="Label">MEMBER FEE</asp:Label></td>
                <td width="100px"><asp:TextBox ID="memberfeeTextBox"  Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
            </tr> 
                  <tr>
                <td width="100px"><asp:Label ID="lblmemcgst" runat="server" Font-Size="Small" Text="Label">CGST RATE</asp:Label></td>
                <td width="100px"><asp:TextBox ID="memcgstTextBox"  Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                </tr>
                <tr>
                <td width="100px"><asp:Label ID="lblmemsgst" runat="server" Font-Size="Small" Text="Label">SGST RATE</asp:Label></td>
                <td width="100px"><asp:TextBox ID="memsgstTextBox"  Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr> 
            <tr>
                <td width="100px"><asp:Label ID="Label77" runat="server" Font-Size="Small" Width="75px" Text="Label">CURRENCY</asp:Label></td>
                <td width="80px"><asp:DropDownList ID="currencyDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>            
            </tr>  
                <tr>
                    <td width="100px"><asp:Label ID="Label79" runat="server" Font-Size="Small" Text="Label">SELECTED AFFILIATE TYPE</asp:Label></td>
                    <td width="100px"><asp:Label ID="lblafftype" runat="server" Font-Size="Small" Text="Label" Visible="false"></asp:Label></td>
                    </tr>
                <tr>
                      <td width="100px"></td>
                   <td  width="200px"> 
                     <input id="ca1" type="checkbox"  onchange="PointsPurchase1();" value="Emerald" /><asp:Label ID="lblchk1"  runat="server" Font-Size="Small" Text="Label">Emerald</asp:Label>
                     <input id="ca2" type="checkbox" onchange="PointsPurchase1();"  value="Holiday Plus"  /><asp:Label ID="lblchk2"    runat="server" Font-Size="Small" Text="Label">Holiday Plus</asp:Label><br />
                     <input id="ca3" type="checkbox" onchange="PointsPurchase1();" value="Registry Collection"  /><asp:Label ID="lblchk3"   runat="server" Font-Size="Small" Text="Label">Registry Collection</asp:Label></td>
                </tr> 
                  <tr>
                <td width="100px"><asp:Label ID="lblregcoll" runat="server" Font-Size="Small"  Width="100px" Text="Label">REGISTRY COLLECTION TERM</asp:Label></td>
                <td width="100px"><asp:TextBox ID="regcollectiontermTextBox"   Font-Size="Small" style="width:200px; height:20px" runat="server"  Text="5"></asp:TextBox></td>
              
            </tr>    
                <tr>
                <td width="100px"><asp:Label ID="lblregcollamt" runat="server" Font-Size="Small"  Width="100px" Text="Label">REGISTRY COLLECTION AMOUNT</asp:Label></td>
                <td width="100px"><asp:TextBox ID="regcollamtTextBox"   Font-Size="Small" style="width:200px; height:20px" runat="server"></asp:TextBox></td>
              
            </tr>            
             <tr>
                <td width="100px"><asp:Label ID="Label101" runat="server" Font-Size="Small"  Width="100px" Text="Label">TOTAL PRICE INCLUDING TAX</asp:Label></td>
                <td width="100px"><asp:TextBox ID="totalfinpriceIntaxTextBox" onchange="PointsPurchase1();"   Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
              
            </tr> 
             <tr>
                <td width="100px"><asp:Label ID="lblinitialdeppercent" runat="server" Font-Size="Small"    Text="Label">DEPOSIT AMOUNT</asp:Label></td> 
                <td width="100px"><asp:TextBox ID="intialdeppercentTextBox" onchange="PointsPurchase1();InitialDepositCalculation1();" Font-Size="Small" runat="server" Enabled="True"   style="width:200px; height:20px"></asp:TextBox></td>  
            </tr> 
           
             
                <tr>

                <td width="100px"><asp:Label ID="lblbaladepamt" runat="server" Font-Size="Small" Text="Label">BALANCE</asp:Label></td>
                <td width="100px"><asp:TextBox ID="baldepamtTextBox" runat="server" Enabled="True" onchange="AmountBreakupCalculation();"  Font-Size="Small" style="width:200px; height:20px" ></asp:TextBox></td>
              
            </tr> 
             <tr>
                <td width="100px"><asp:Label ID="lblbaladepamtdate" runat="server" Font-Size="Small" Text="Label">Date</asp:Label></td>
                <td width="100px"><asp:TextBox ID="baladepamtdateTextBox" runat="server" onchange="sumbaldep();" Enabled="True" Font-Size="Small" style="width:200px; height:20px" ></asp:TextBox></td>
              </tr> 
            <tr>
                <td width="100px"><asp:Label ID="lblbalinitialdep" Font-Size="Small" runat="server" Text="Label">BALANCE DEPOSIT</asp:Label></td>
                <td width="100px"><asp:TextBox ID="balinitialdepamtTextBox" runat="server" Font-Size="Small"  onchange="InitialBalCalculation();"  Enabled="True"  style="width:200px; height:20px"></asp:TextBox></td>
                <td width="100px"><asp:TextBox ID="nonfinbalamtTextBox" runat="server" Font-Size="Small"     Enabled="True"  style="width:200px; height:20px"></asp:TextBox>
                  
                </td>
                 
            </tr> 
            
            <tr>
                <td width="100px"><asp:Label ID="Label89" runat="server" Font-Size="Small" Text="Label">PAYMENT METHOD</asp:Label></td>
                <td width="100px"><asp:DropDownList ID="PayMethodDropDownList"   Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
            </tr>
             
             <tr>
                <td width="100px"><asp:Label ID="lblnoinstallment" runat="server" Font-Size="Small" Text="Label"># OF INSTALLMENTS</asp:Label></td>
                <td width="100px"><asp:TextBox ID="NoinstallmentTextBox" Font-Size="Small"  onchange="DisplayInstallmentAmt();"  style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
               <td width="100px"><asp:CheckBox ID="CheckBox1" runat="server" Font-Size="Small"  onclick="DisplayInstallmentAmt();" Text="Change Installment" Width="165px"  Enabled="True" ></asp:CheckBox></td>
                   
            </tr> 
              <tr>
                <td width="100px"><asp:Label ID="lblinstallmentamt" runat="server" Font-Size="Small" Text="Label">INSTALLMENT AMOUNT</asp:Label></td>
                <td width="100px"><asp:TextBox ID="installmentamtTextBox" runat="server" Font-Size="Small" Enabled="True"  style="width:200px; height:20px" ></asp:TextBox></td>
            </tr>      
                 <tr>
              <td width="100px"><asp:Label ID="lblbalamtpayable" runat="server" Font-Size="Small" Text="Label">BAL.AMOUNT PAYABLE</asp:Label></td>
              <td width="100px"><asp:TextBox ID="balamtpayableTextBox" runat="server" Font-Size="Small" Enabled="True"    style="width:200px; height:20px"></asp:TextBox></td>
            </tr> 
                                   
            <tr>
                <td width="100px"><asp:Label ID="lblfinancemethod" runat="server" Font-Size="Small" Text="Label">FINANCE TYPE</asp:Label></td>
                <td width="100px"><asp:DropDownList ID="financemethodDropDownList"  onchange="pay_method();"  Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
            </tr>
              
               <tr>
                 <td width="100px"><asp:Label ID="lblfinanceno" runat="server" Font-Size="Small" Text="Label">FINANCE #</asp:Label></td>
                <td width="100px"><asp:TextBox ID="FinancenoTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                
                   </tr>
                <tr>
                 <td width="100px"><asp:Label ID="lblfinmonth" runat="server" Font-Size="Small" Text="Label">FINANCE MONTH</asp:Label></td>
                <td width="100px"><asp:TextBox ID="finmonthTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                
                   </tr>
                 <tr>
                 <td width="100px"><asp:Label ID="lblinterestrate" runat="server" Font-Size="Small" Text="Label">INTEREST RATE</asp:Label></td>
                <td width="100px"><asp:TextBox ID="interestrateTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                
                   </tr>
               <tr>
                   <td width="100px"><asp:Label ID="lblisgtrate" runat="server" Font-Size="Small" Text="Label">IGST RATE</asp:Label></td>
                     <td width="100px"><asp:TextBox ID="isgtrateTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>      
                   </tr>
                <tr>
                    <td width="100px"><asp:Label ID="lbligstamt" runat="server" Font-Size="Small" Text="Label">IGST</asp:Label></td>
                    <td width="100px"><asp:TextBox ID="igstamtTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>      
                   </tr>
                <tr>                    
                   <td width="100px"><asp:Label ID="lblfindocfee" runat="server" Font-Size="Small" Text="Label">DOCUMENTATION FEE</asp:Label></td>
                     <td width="100px"><asp:TextBox ID="findocfeeTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                                              
              </tr>
                 <tr>                    
                   <td width="100px"><asp:Label ID="lbleurorate" runat="server" Font-Size="Small" Text="Label">EURO RATE</asp:Label></td>
                     <td width="100px"><asp:TextBox ID="eurorateTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                                              
              </tr>
                  <tr>                    
                   <td width="100px"><asp:Label ID="lblloanamtINEuro" runat="server" Font-Size="Small" Text="Label">LOAN AOUNT (IN EUROS)</asp:Label></td>
                     <td width="100px"><asp:TextBox ID="loanamtINEuroTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                                              
                      <td width="100px"><asp:TextBox ID="monthlyPremiumprotectionplanTextBox" Font-Size="Small"  runat="server" Enabled="True"></asp:TextBox></td>                                              
              </tr>
                     
                  
                 <tr>
                <td width="100px"><asp:Label ID="lblnoemi" runat="server" Font-Size="Small" Text="Label">NO.EMI #</asp:Label></td>
                <td width="100px"><asp:TextBox ID="noemiTextBox" Font-Size="Small" onchange="LoanEMICalculation();"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                
               </tr>
                <tr>
                <td width="100px" ><asp:Label ID="lblemiamt" runat="server" Font-Size="Small" Text="Label">EMI INSTALLMENT</asp:Label></td>
                <td width="100px"><asp:TextBox ID="emiamtTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>   
                
                 <tr>
                <td width="100px"><asp:Label ID="lbldepositmethod" runat="server" Font-Size="Small" Text="DEPOSIT PAYMENT MODE" Visible="False"></asp:Label></td>
                <td width="100px"><asp:DropDownList ID="depositmethodDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px" Visible="False"></asp:DropDownList></td>
                    <%--  <td width="100px"><asp:TextBox ID="depositmethodTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  --%>
                  </tr> 
                <tr> 
                 <td width="100px" ><asp:Label ID="lblinvoicedate" runat="server" Font-Size="Small" Text="INVOICE DATE" Visible="False"></asp:Label></td>
                <td width="100px"><asp:TextBox ID="invoicedateTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True" Visible="False"></asp:TextBox></td>  
                </tr>     
                
                <tr> 
                 <td width="100px" ><asp:Label ID="lblinvoiceno" runat="server" Font-Size="Small" Text="INVOICE#" Visible="False"></asp:Label></td>
                <td width="100px"><asp:TextBox ID="invoicenoTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True" Visible="False"></asp:TextBox></td>  
                </tr>                     
                                     
            </table>
                <div>
                <table id="identitytable" >
                  <tr>  
                <td width="120px"><asp:Label ID="Label92" runat="server"  style="width:200px;"    Font-Size="Small" Text="Label">PAN CARD #</asp:Label></td>
                     
                <td width="50px"><asp:TextBox ID="pancardnoTextBox" runat="server"   style="width:200px; height:20px"  Font-Size="Small" Enabled="True"></asp:TextBox></td>                
                </tr> 
             <tr>  
            <td width="100px"><asp:Label ID="Label93" runat="server"    Font-Size="Small"  Text="Label">ADHAR CARD #</asp:Label></td>
            <td width="100px"><asp:TextBox ID="adharcardTextBox" runat="server" Font-Size="Small"  style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>                
            </tr> 
                </table>
                    </div>
                
              
            </div>
          </div>
           <br /> 
      </div>
        <br />
        
          
   </div>
       <div id="tabs-3" style="background-color:#e9e9e9;">
          <div id="Tab3cont">
              <table>
                  <tr>
                       <td><asp:Label ID="Label113" runat="server" Text="Label">Select Option</asp:Label></td>
                        <td><asp:DropDownList ID="SORDropDownList" runat="server">
                             <asp:ListItem Text=""></asp:ListItem>
                            <asp:ListItem Text="SOR Name"></asp:ListItem>
                            <asp:ListItem Text="Additional Name"></asp:ListItem>
                            </asp:DropDownList> </td>
                  </tr>
                  <tr>
                       <td><asp:Label ID="Label115" runat="server" Text="Label">Enter No</asp:Label></td>
                        <td><asp:TextBox ID="asornoTextBox" type="number" runat="server" onchange="SORAdditionalNames();" Enabled="True" Width="328px"></asp:TextBox></td>
                  </tr>
                  </table>
                   </div>
                            <div id="sorheading1">                            
                           <table>
                          <tr>
                              <td width="200px" align="center"><asp:Label ID="Label116" runat="server" Text="Label">Name</asp:Label> </td>
                              <td width="600px" align="center"><asp:Label ID="Label117" runat="server" Text="Label">Address</asp:Label> </td>
                            <%--  <td width="180px" align="center"><asp:Label ID="Label118" runat="server" Text="Label">State</asp:Label> </td>
                              <td width="180px" align="center"><asp:Label ID="Label119" runat="server" Text="Label">Country</asp:Label> </td>                              
                               <td width="210px" align="center"><asp:Label ID="Label120" runat="server" Text="Label">Post Code</asp:Label> </td>--%>
                          </tr>
                      </table>

                            <div id="sorDIV">                   
                     
                      
                       </div>  
                       <asp:Button ID="Button7" runat="server" Text="Add" OnClick="Button7_Click" Width="55px" />                           
                             <div id="gridadd">
                                 <table>
                                     <tr>
                                      <td width="100px"><asp:Label ID="lblsoraname" runat="server"    Font-Size="Small"  Text="Name"></asp:Label></td>
                                     <td width="100px"><asp:TextBox ID="soranameTextBox" runat="server" Font-Size="Small"  style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>                
                                     </tr>
                                     <tr>
                                      <td width="100px"><asp:Label ID="lblsoraaddress" runat="server"    Font-Size="Small"  Text="Address"></asp:Label></td>
                                     <td width="100px"><asp:TextBox ID="soraaddressTextBox" runat="server" Font-Size="Small" Enabled="True" Height="67px" Width="206px" TextMode="MultiLine"></asp:TextBox></td>                
                                     </tr>
                                      <tr>
                                      <td width="100px"><asp:Label ID="lblsorastate" runat="server"    Font-Size="Small"  Text="State"></asp:Label></td>
                                     <td width="100px"><asp:TextBox ID="sorastateTextBox" runat="server" Font-Size="Small"  style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>                                             
                                     </tr>
                                      <tr>
                                      <td width="100px"><asp:Label ID="lblsoracountry" runat="server"    Font-Size="Small"  Text="Country"></asp:Label></td>
                                     <td width="100px"><asp:TextBox ID="soracountryTextBox" runat="server" Font-Size="Small"  style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>                                              
                                     </tr>
                                     <tr>
                                     <td width="100px"><asp:Label ID="lblsorapincode" runat="server"    Font-Size="Small"  Text="Post Code" BorderStyle="None" Width="66px"></asp:Label></td>
                                     <td width="100px"><asp:TextBox ID="sorapincodeTextBox" runat="server" Font-Size="Small"  style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>                       
                                     </tr>
                                     <tr>
                                         <td width="100px"><asp:Button ID="btnupdate" runat="server" Text="Update"  Width="55px" Font-Names="Times New Roman" Font-Size="Small" /> </td>
                                         <td width="100px"><asp:Button ID="btndelete" runat="server" Text="Delete"  Width="55px" Font-Names="Times New Roman" Font-Size="Small" /> </td>
                                     </tr>
                                       
                                 </table>
                              <%--   <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Times New Roman" Font-Size="Small"  OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AutoGenerateSelectButton="True"  >
                                    <%--  <Columns>
                                   <asp:TemplateField> OnRowCommand="GridView2_RowCommand"
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkbtn1" OnClick="LinkbtnClick" Text='<%#Eval("otherNamesID") %>' runat="server">Linkbtn</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                          </Columns>
                                     <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                     <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                     <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                     <RowStyle BackColor="White" ForeColor="#003399" />
                                     <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                     <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                     <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                     <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                     <SortedDescendingHeaderStyle BackColor="#002876" />
                          </asp:GridView> --%>

               <%--                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Width="270px" onrowcommand="GridView2_RowCommand"
            onrowdeleting="GridView2_RowDeleting" Font-Names="Times New Roman" Font-Size="Small">
            <Columns>
                							
                <asp:BoundField DataField="ContractNo" HeaderText="ContractNo" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="State" HeaderText="State" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="Postcode" HeaderText="Postcode" />                
                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False"
                            CommandName="Delete" OnClientClick="javascript: return confirm('Do you want to delete this record?')" CommandArgument='<%#Bind("OtherNamesID") %>' Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                     
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>--%>

                                  <div class="table-responsive">

                              <table id="task-table1" width="60%">
                                  <thead>
                                      <tr>
                                          <th>ID</th>
                                          <th>CONTRACT NO</th>
                                          <th>TYPE</th>
                                          <th>NAME</th>
                                          <th>ADDRESS</th>
                                          <th>STATE</th>
                                          <th>COUNTRY</th>
                                          <th>POST CODE</th>
                                          <th>ACCEPTANCE / DOC STATUS</th>
                                           <th>ENROLLMENT</th>
                                          <th>DELETE</th>
                                      </tr>
                                  </thead>
                                  <tbody id="myTable1">
                                      <%Response.Write(getsorAdditionalDetails()); %>
                                  </tbody>
                              </table>
                          </div>
                     
                      </div>
              
              
           

          </div>
           </div>

       <div id="tabs-6" style="background-color:#e9e9e9;">
             <asp:Label ID="lblfcurr3" runat="server"></asp:Label>
          <div id="Tab6cont">
              <table>
               <asp:TextBox ID="TextBox1"  runat="server"   Enabled="True" Width="204px" style="display:none;"></asp:TextBox>
               
                 <tr>
                <td width="100px"><asp:Label ID="lbldepositmethodadd" runat="server" Font-Size="Small" Text="DEPOSIT PAYMENT MODE" BorderStyle="None" Width="137px"></asp:Label></td>
                <td width="100px"><asp:DropDownList ID="depositmethodaddDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                  </tr>  
                    <tr>
                <td width="100px"><asp:Label ID="lblreceipttype" runat="server" Font-Size="Small" Text="SELECT TYPE" BorderStyle="None" Width="137px"></asp:Label></td>
                <td width="100px"><asp:DropDownList ID="receipttypeDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="Deposit">Deposit</asp:ListItem>
                    <asp:ListItem Value="Additional Receipt">Additional Receipt</asp:ListItem>
                    </asp:DropDownList></td>
                  </tr>    
                  <tr>
                       <td><asp:Label ID="Label72" runat="server" Text="ENTER AMOUNT" BorderStyle="None" Font-Names="Times New Roman" Font-Size="Small"></asp:Label></td>
                        <td><asp:TextBox ID="ReceiptamtTextBox" type="number" runat="server"   Enabled="True" Width="200px"></asp:TextBox></td>
                  </tr>
                    <tr>
                <td width="100px"><asp:Label ID="lblforeigncurrency" runat="server" Font-Size="Small"  BorderStyle="None" Width="137px"   Text="Text">CURRENT RATE IN Rs.</asp:Label></td> 
                <td width="100px"><asp:TextBox ID="foreigncurrencyTextBox"  Font-Size="Small" runat="server" Enabled="True"    style="width:205px; height:25px"></asp:TextBox></td>
             </tr>  
                     <tr>
                <td width="100px"><asp:Label ID="lbloldcanxamt" runat="server" Font-Size="Small"  BorderStyle="None" Width="137px"   Text="Text">PREVIOUS AMT OF CANX.CONTRACT</asp:Label></td> 
                <td width="100px"><asp:TextBox ID="oldcanxamtTextBox"  Font-Size="Small" runat="server" Enabled="True"    style="width:205px; height:25px"></asp:TextBox></td>
             </tr>  


                        <tr>
                <td width="100px"><asp:Label ID="ReceiptNumber" runat="server" Font-Size="Small"  BorderStyle="None" Width="137px" style="display:none;"  Text="Text">RECEIPT NO.</asp:Label></td> 
                
                            <td width="100px"><asp:TextBox ID="TextBox2"  Font-Size="Small" runat="server" Enabled="True"    style="display:none; width:200px; height:20px "></asp:TextBox></td>
             </tr>  
              
                  </table>
              <br />
         
             <asp:Button ID="Button8" runat="server" Text="Generate Receipt" OnClick="Button8_Click" Width="200px" /> 
              <asp:Button ID="Button9" runat="server" Text="Update Receipt" Width="150px" style="display:none;"/> 
               </div>
           <br />   
                                  
                             <div id="gridadd1">


                                  <div class="table-responsive">

                              <table id="task-table" width="80%">
                                  <thead id="head1">
                                      <tr>
                                          <th>ID</th>
                                          <th>CONTRACT NO</th>
                                          <th>RECEIPT NO</th>
                                          <th>RECEIPT DATE</th>
                                          <th>TAXABLE AMT</th>
                                          <th>TOTAL AMT</th>
                                          <th>MODE</th>
                                           <th>RECEIPT TYPE</th>
                                          <th>ACTUAL CURRENCY</th>
                                          <th>CONVERTED CURRENCY</th>
                                          <th>CONVERTED RATE</th>
                                          <th>ACTUAL AMT</th>   
                                          <th>PREVIOUS DEPOSIT AMT</th>                                  
                                          <th>EDIT</th>
                                          <th>DELETE</th>
                                      </tr>
                                  </thead>
                                  <tbody id="myTable">
                                    

                                      <%

                                          
                                          Response.Write(getReceiptDetails()); %>
                                  </tbody>
                              </table>
                          </div>

                                <%--<asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Times New Roman" Font-Size="Small">
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                          </asp:GridView>


                     --%>

      <%--          <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
            CellPadding="4" Width="270px" onrowcommand="GridView3_RowCommand"
            onrowdeleting="GridView3_RowDeleting" Font-Names="Times New Roman" Font-Size="Small">
            <Columns>
                <asp:BoundField DataField="ContractNo" HeaderText="ContractNo" />
                <asp:BoundField DataField="Receipt_No" HeaderText="Receipt No" />
                <asp:BoundField DataField="Receipt_Date" HeaderText="Receipt Date" />
                <asp:BoundField DataField="taxable_value" HeaderText="Taxable Amt" />
                <asp:BoundField DataField="totalamt" HeaderText="Total amt" />
                <asp:BoundField DataField="Payment_Mode" HeaderText="Mode" />
                <asp:BoundField DataField="actual_currency" HeaderText="Actual Currency" />
                <asp:BoundField DataField="converted_currency" HeaderText="Converted Currency" />
                <asp:BoundField DataField="Converted_rate" HeaderText="Converted Rate" />
                         <asp:BoundField DataField="Actual_Amt" HeaderText="Actual Amt" />
               
                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete1" runat="server" CausesValidation="false"
                            CommandName="Delete" OnClientClick="javascript: return confirm('Do you want to delete this record?')" CommandArgument='<%#Bind("Receipt_No") %>' Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>--%>


                                 

                      </div>
              
              
           

          
           </div>

  
       <div id="tabs-4" style="background-color:#e9e9e9;">
          <div id="finance-container1" style="margin-top:10px;padding-top:10px; ">    
                  <asp:Label ID="lblfcurr2" runat="server"></asp:Label>          
              <div id="Points" style="margin:10px 0px;padding-top:10px; overflow:hidden;">
               <div id="PA1" style="width:650px; float:left;">
                   <h4>PURCHASE AGREEMENT</h4>
                <table  cellpadding="5px" cellspacing="5px">                 
                              
                    <tr>
                        <td><asp:Label ID="lblnewpoints" runat="server" Text="Label">NEW POINTS PRICE</asp:Label></td>
                        <td><asp:TextBox ID="newpointsTextBox" runat="server" onchange="ConversionfeeWithNewPoints();"   Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblconversionfee" runat="server" Text="Label">CONVERSION FEE</asp:Label></td>
                        <td><asp:TextBox ID="conversionfeeTextBox" runat="server"    Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                 <tr>
                        <td><asp:Label ID="lblftotalvalue" runat="server" Text="Label">TOTAL VALUE</asp:Label></td>
                        <td><asp:TextBox ID="ftotalvalueTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr><tr>
                        <td><asp:Label ID="lblftradeinvalue" runat="server" Text="Label">TRADE - IN-VALUE</asp:Label></td>
                        <td><asp:TextBox ID="ftradeinvalueTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label88" runat="server" Text="Label">ADMIN FEE</asp:Label></td>
                        <td><asp:TextBox ID="adminfeeTextBox"  onchange="AdminfeeCalculation();"    runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           <td><asp:TextBox ID="testadminfeeTextBox"       runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblAdministrationFees" runat="server" Text="Label">ADMINISTRATION FEES</asp:Label></td>
                        <td><asp:TextBox ID="AdministrationFeesTextBox"  onchange="AdminfeeCalculation();"   runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label128" runat="server" Text="Label">TOTAL PURCHASE PRICE</asp:Label></td>
                        <td><asp:TextBox ID="totpurchpriceTextBox"    runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td><asp:Label ID="lbltotaltax" runat="server" Text="Label">Total Tax</asp:Label></td>
                        <td><asp:TextBox ID="TotalTaxTextBox"   runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>

                     <tr>
                        <td><asp:Label ID="Label148" runat="server" Text="Label">CGST(9%)</asp:Label></td>
                        <td><asp:TextBox ID="cgstTextBox"   runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label149" runat="server" Text="Label">SGST(9%)</asp:Label></td>
                        <td><asp:TextBox ID="sgstTextBox"    runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label150" runat="server" Text="Label">TOTAL PRICE INCLUDING TAX</asp:Label></td>
                        <td><asp:TextBox ID="totalpriceInTaxTextBox"  runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>

                     <tr>
                        <td><asp:Label ID="Label153" runat="server" Text="Label">DEPOSIT</asp:Label></td>
                        <td><asp:TextBox ID="depositTextBox"  runat="server" Enabled="True" Width="328px"></asp:TextBox></td><!--onchange="balanceAmtCalculation();" -->
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label154" runat="server" Text="Label">BALANCE</asp:Label></td>
                        <td><asp:TextBox ID="balanceTextBox"    runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr> 
                     <tr>
                        <td><asp:Label ID="lbloldamt" runat="server" Text="Label">PREVIOUS PAID AMT</asp:Label></td>
                        <td><asp:TextBox ID="pdoldamtTextBox" runat="server" Enabled="True" Width="328px" Text="0" onchange="VoidAgreementamt();" ></asp:TextBox></td>
                    </tr>    
                    <tr>
                        <td><p>Balance Due Dates in PA</p></td>
                    <td><asp:TextBox ID="balancedueTextBox" runat="server" Enabled="True" Width="328px" TextMode="MultiLine" Height="54px"></asp:TextBox></td>
                    </tr>
                   
                </table>
              </div>
               
                      <div  id="instalheading" style="float:left;">                           
                          
                           <table>
                              <tr>
                             <td><asp:Label ID="lblinstallmentlabel" runat="server" Text="Label">INSTALLMENT DETAILS</asp:Label></td>
                            </tr>
                          <tr>
                              <td width="250px" align="center"><asp:Label ID="lblamt" runat="server" Text="Label">Amount</asp:Label> </td>
                              <td width="100px" align="center"><asp:Label ID="lbldate" runat="server" Text="Label">Date</asp:Label> </td>
                          </tr>
                      </table>
                            <div id="installmentDIV" style="float:left;">                   
                     
                      
                       </div>
                            <input id="totalamt" type="text" name="ter"  />
                      </div>
                 
              </div>
              </div>
              
              <div id="remarks" >
                  <p>PA Remarks</p>
                  <asp:TextBox ID="remarksTextBox" runat="server" Enabled="True" Width="1200px" TextMode="MultiLine"></asp:TextBox>
                  <br />
                   <p>DSR Comment(Any approval, payment details etc)</p>
                  <asp:TextBox ID="contractcommentTextBox" runat="server" Enabled="True" Width="1200px" TextMode="MultiLine"></asp:TextBox>
                  <br />
                    <p>Contract Comment</p>
                  <asp:TextBox ID="contractremarkTextBox" runat="server" Enabled="True" Width="1200px" TextMode="MultiLine"></asp:TextBox>
                  <br />
                  
              </div>
           <div id="grid">
                  <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Times New Roman" Font-Size="Small">
                      <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                      <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                      <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                      <RowStyle BackColor="White" ForeColor="#003399" />
                      <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                      <SortedAscendingCellStyle BackColor="#EDF6F6" />
                      <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                      <SortedDescendingCellStyle BackColor="#D6DFDF" />
                      <SortedDescendingHeaderStyle BackColor="#002876" />
             
                          </asp:GridView>
                 
              </div>
         <br />
            <asp:Button ID="CreateButton" runat="server" Text="Update Contract" OnClick="CreateButton_Click"></asp:Button> <!--OnClick="CreateButton_Click " -->
           
   </div>
      <div id="tabs-5" style="background-color:#e9e9e9;">
          <div id="Tab4cont">

              <asp:DropDownList ID="PrintPdfDropDownList" runat="server" ></asp:DropDownList> &nbsp;&nbsp <asp:Button ID="Button5" runat="server" Text="Print" OnClick="Button5_Click" />

          </div>
      </div>

        </form>
   </div>
      
    
 
  <script>

        $(document).ready(function () {
           // $("#hidden1").hide();
            $("#chs").click(function () {
                if ($("#chs").is(':checked')) {

                    $("#hidden1").show();
                } else {
                    $("#hidden1").hide();
                }
            });
        });


    </script>
   
    
    


           <script>
        $(document).ready(function () {
            $("#primarydobdatepicker").change(function () {
                
                var date = $("#primarydobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#primaryAge').val(age);
            });
        });
  </script>

                  

    <script>
        $(document).ready(function () {
            $("#secondarydobdatepicker").change(function () {
                var date = $("#secondarydobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#secondaryAge').val(age);
            });



        });
    </script>

     <script>
        $(document).ready(function () {
            $("#sp1dobdatepicker").change(function () {
                var date = $("#sp1dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile1Age').val(age);
            });



        });
    </script>

    <script>
        $(document).ready(function () {
            $("#sp2dobdatepicker").change(function () {
                var date = $("#sp2dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile2Age').val(age);
            });



        });
    </script>


     <script>
        $(document).ready(function () {
            $("#sp3dobdatepicker").change(function () {
                var date = $("#sp3dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile3Age').val(age);
            });



        });
    </script>

     <script>
        $(document).ready(function () {
            $("#sp4dobdatepicker").change(function () {
                var date = $("#sp4dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile4Age').val(age);
            });



        });
    </script>


    <script>
        $(document).ready(function () {
            $("#VenueCountryDropDownList").change(function () {
                var v = document.getElementById("VenueCountryDropDownList");
                var countryName = v.options[v.selectedIndex].text;
               // alert(countryName)
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/getVenueOnCountry',
                    data: "{'countryName':'" + countryName + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#VenueDropDownList").empty();
                        $("#VenueDropDownList").append("<option disabled selected value>select an option  </option>");
                       
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#VenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong getVenueOnCountry");
                    }



                });
                return false;
               
 

            });
        });
    </script>
  
 
     <script>

        $(document).ready(function () {


            $("#VenueDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;
                // alert(countryName)
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/getVenueGroupOnVenue',
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#GroupVenueDropDownList").empty();
                        $("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>");
                       
                        $("#MarketingProgramDropDownList").empty();
                        $("#MarketingProgramDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#GroupVenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong getVenueGroupOnVenue");
                    }



                });

                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadManagersOnVenue',
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#ManagerDropDownList").empty();
                        $("#ManagerDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#ManagerDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong LoadManagersOnVenue");
                    }



                });


                //get sales rep name
                var v = document.getElementById("VenueCountryDropDownList");
                var vcountry = v.options[v.selectedIndex].text;

               // alert(vcountry);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadSalesRepOnVenue',
                    data: "{'venue':'" + venue + "','country':'" + vcountry + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#toursalesrepDropDownList").empty();
                        $("#toursalesrepDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#toursalesrepDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong LoadSalesRepOnVenue");
                    }



                });
                return false;



            });


        });


    </script>

    <script>
        $(document).ready(function () {
          
                $("#GroupVenueDropDownList").change(function () {
                    var v = document.getElementById("VenueDropDownList");
                    var venue = v.options[v.selectedIndex].text;

                    var vg = document.getElementById("GroupVenueDropDownList");
                    var venueGroup = vg.options[vg.selectedIndex].text;

                  
                    if (venueGroup == "Inhouse" || venueGroup == "INHOUSE") {
                      //  alert('hiee');
                        $("#Label126").show();
                        $("#SubVenueDropDownList").show();

                        if (venue == "South Goa" || venue == "SOUTH GOA") {
                            $("#Label159").show();
                            $("#SubVenueGroupDropDownList").show();
                        }
                        else {
                            $("#Label159").hide();
                            $("#SubVenueGroupDropDownList").hide();
                            $("#SubVenueGroupDropDownList").val('');
                        }


                        $("#Label127").hide();
                        $("#LeadOfficeDropDownList").hide();
                        $("#LeadOfficeDropDownList").val("");


                    } else if (venueGroup == "FlyBuy" || venueGroup == "FLYBUY") {

                        $("#Label126").show();
                        $("#SubVenueDropDownList").show();

                        $("#Label159").hide();
                        $("#SubVenueGroupDropDownList").hide();
                        $("#SubVenueGroupDropDownList").val('');

                        $("#Label127").show();
                        $("#LeadOfficeDropDownList").show();
                    } else
                    {
                        $("#Label126").hide();
                        $("#SubVenueDropDownList").hide();

                        $("#Label159").hide();
                        $("#SubVenueGroupDropDownList").hide();

                        $("#Label127").hide();
                        $("#LeadOfficeDropDownList").hide();
                        $("#SubVenueGroupDropDownList").val('');
                        $("#LeadOfficeDropDownList").val('');
                        $("#SubVenueDropDownList").val('');
                    }


                    var profileID = $("#profileidTextBox").val();

                    if (venueGroup == "Coldline" || venueGroup == "COLDLINE") {
                        //alert("hello");

                        $("#Label205").show();
                        $("#ManagerDropDownList").show();
                    }
                    else {
                        $("#Label205").hide();
                        $("#ManagerDropDownList").hide();
                    }


                    $.ajax({

                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        url: 'Indian_contracts_Edit.aspx/getMarketingProgram',
                        data: "{'venue':'" + venue + "','venueGroup':'" + venueGroup + "','profileID':'" + profileID + "'}",
                        async: false,
                        success: function (data) {
                            // alert(data.d);
                            $("#MarketingProgramDropDownList").empty();
                            $("#MarketingProgramDropDownList").append("<option disabled selected value>select an option  </option>");
                            subJson = JSON.parse(data.d);


                            $.each(subJson, function (key, value) {
                                $.each(value, function (index1, value1) {

                                    $("#MarketingProgramDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                                });
                            });
                        },
                        error: function () {
                            alert("wrong");
                        }



                    });


                    $.ajax({

                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        url: 'Indian_contracts_Edit.aspx/getSubVenue',
                        data: "{'venue':'" + venue + "','venueGroup':'" + venueGroup + "'}",
                        async: false,
                        success: function (data) {
                            // alert(data.d);
                            $("#SubVenueDropDownList").empty();
                            $("#SubVenueDropDownList").append("<option value=''>select an option  </option>");
                            subJson = JSON.parse(data.d);


                            $.each(subJson, function (key, value) {
                                $.each(value, function (index1, value1) {

                                    $("#SubVenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                                });
                            });
                        },
                        error: function () {
                            alert("wrong");
                        }



                    });

                    var v = document.getElementById("VenueDropDownList");
                    var venue = v.options[v.selectedIndex].text;

                    var vg = document.getElementById("GroupVenueDropDownList");
                    var venueGroup = vg.options[vg.selectedIndex].text;
                    $.ajax({

                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        url: 'Indian_contracts_Edit.aspx/LoadAgentsOnVenuegrp',
                        data: "{'venue':'" + venue + "','vgrp':'" + venueGroup + "'}",
                        async: false,
                        success: function (data) {
                            // alert(data.d);
                            $("#AgentDropDownList").empty();
                            $("#AgentDropDownList").append("<option disabled selected value>select an option  </option>")
                            subJson = JSON.parse(data.d);

                            // alert(subJson);
                            $.each(subJson, function (key, value) {
                                $.each(value, function (index1, value1) {

                                    $("#AgentDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                });
                            });
                        },
                        error: function () {
                            alert("wrong LoadAgentsOnVenuegrp");
                        }



                    });
                    var v = document.getElementById("VenueDropDownList");
                    var venue = v.options[v.selectedIndex].text;

                    var vg = document.getElementById("GroupVenueDropDownList");
                    var venueGroup = vg.options[vg.selectedIndex].text;


                    $.ajax({

                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        url: 'Indian_contracts_Edit.aspx/LoadTOOnVenueNVGrp',
                        data: "{'venue':'" + venue + "','vgrp':'" + venueGroup + "'}",
                        async: false,
                        success: function (data) {
                            //    alert(data.d);
                            $("#TONameDropDownList").empty();
                            $("#TONameDropDownList").append("<option disabled selected value>select an option  </option>")
                            subJson = JSON.parse(data.d);

                            // alert(subJson);
                            $.each(subJson, function (key, value) {
                                $.each(value, function (index1, value1) {

                                    $("#TONameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                });
                            });
                        },
                        error: function () {
                            alert("wrong LoadTOOnVenueNVGrp");
                        }



                    });
                    return false;

                });
           
        });
       

    </script>
     <script>
        $(document).ready(function () {
          //  alert("hiee");
            var prid = $("#profileidTextBox").val();
           // alert(prid);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts_Edit.aspx/primaryl',
                data: "{'prid':'"+prid+"'}",
                async: false,
                success: function (data) {
                  //   alert(data.d);
                  
                    subJson = JSON.parse(data.d);

                   
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                          

                            var valArr = [value1[0]],
                                
                            i = 0, size = valArr.length,
                            $options = $('#primlg option');
                           // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong p");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts_Edit.aspx/Secondarylang',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#seclang option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong s");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts_Edit.aspx/PhotoIdentity',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#phid option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong pi");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts_Edit.aspx/CardType',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#card option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong CardType");
                }

            });
            return false;

        });

    </script>

    <script>
        $(document).ready(function () {
            // hide show manager based on venue group
            
            
            var value = $("#GroupVenueDropDownList option:selected").text();
            // alert(value);
            if (value == "Coldline"||value == "COLDLINE") {

                $("#Label205").css("display", "block");
                $("#ManagerDropDownList").css("display", "block");
            }
            else {
                $("#Label205").css("display", "none");
                $("#ManagerDropDownList").css("display", "none");
            }
            //end//

            $("#Label11").hide();
            $("#MemType1DropDownList").hide();
            $("#Label15").hide();
            $("#Memno1TextBox").hide();
            $("#Label114").hide();
            $("#TypeDropDownList").hide();
         
           

            //  MarketingPrgmDropDownList
            var marketingValue = $("#MarketingProgramDropDownList option:selected").text();
           
           // if (marketingValue == "OWNER" || marketingValue == "Owner" || marketingValue == "owner" || marketingValue == "OWNER DOWNGRADE" || marketingValue == "Owner Downgrade")
            if (marketingValue == "FRACTIONAL OWNER" || marketingValue == "FRACTIONAL OWNER RCI" || marketingValue == "T/S MEMBER" || marketingValue == "T/S MEMBER RCI" || marketingValue == "OWNER" || marketingValue == "RCIOWN" || marketingValue == "RCIOwn" || marketingValue == "Member" || marketingValue == "MEMBER" || marketingValue == "RCIMBR" || marketingValue == "RCIMbr" || marketingValue == "MEMBER MARKETING GOA" || marketingValue == "MMG")

            {

                $("#Label11").show();
                $("#MemType1DropDownList").show();
                $("#Label15").show();
                $("#Memno1TextBox").show();
                $("#Label114").hide();
                $("#TypeDropDownList").hide();
              
                
                
            } else {
                $("#Label11").show();
                $("#MemType1DropDownList").show();
                $("#Label15").hide();
                $("#Memno1TextBox").hide();
                $("#Label114").show();
                $("#TypeDropDownList").show();

            }

        });

    </script>


     
    <script>
        $(document).ready(function () {
            var value = $("#financeradiobuttonlist").find('input[type=radio]:checked').val();

  
            if (value == "Finance")
            {
              //  var emival = "60";
                $("#lblfinancemethod").show();
                $("#financemethodDropDownList").show();
                var value1 = $("#financemethodDropDownList option:selected").text();
            
           
                if (value1 == "Pashuram Finance")
                {
                    
                    $("#lblfinanceno").show();
                    $("#FinancenoTextBox").show();
                    $("#lblfinmonth").show();
                    $("#finmonthTextBox").show();
                    $("#lblinterestrate").show();
                    $("#interestrateTextBox").show();
                    $("#lblisgtrate").show();
                    $("#isgtrateTextBox").show();
                    $("#lbligstamt").show();
                    $("#igstamtTextBox").show();
                    $("#lblfindocfee").show();
                    $("#lblfindocfee").text("DOCUMENTATION FEE");
                    $("#findocfeeTextBox").show();
                    $("#lblnoemi").show();
                    $("#noemiTextBox").show();

                    $("#lblemiamt").show();
                    $("#emiamtTextBox").show();
                    $("#lblbalinitialdep").show();
                    $("#balinitialdepamtTextBox").show();
                     
                    $("#lbleurorate").hide();
                    $("#eurorateTextBox").hide();
                    $("#lblloanamtINEuro").hide();
                    $("#loanamtINEuroTextBox").hide();

                }
                else if(value1=="Crown Finance")
                {

                    $("#lblfinanceno").show();
                    $("#FinancenoTextBox").show();
                    $("#lblfinmonth").show();
                    $("#finmonthTextBox").show();
                    $("#lblinterestrate").show();
                    $("#interestrateTextBox").show();
                    $("#lblisgtrate").show();
                    $("#isgtrateTextBox").show();
                    $("#lbligstamt").show();
                    $("#igstamtTextBox").show();
                    $("#lblfindocfee").show();
                    $("#lblfindocfee").text("ACCEPTANCE FEE");
                    $("#findocfeeTextBox").show();
                    $("#lblnoemi").show();
                    $("#noemiTextBox").show();

                    $("#lblemiamt").show();
                    $("#emiamtTextBox").show();
                    $("#lblbalinitialdep").show();
                    $("#balinitialdepamtTextBox").show();

                    $("#lbleurorate").show();
                    $("#eurorateTextBox").show();
                    $("#lblloanamtINEuro").show();
                    $("#loanamtINEuroTextBox").show();

                }
                
             
            } else {

                $("#lblfinancemethod").hide();
                $("#financemethodDropDownList").hide();
                $("#lblfinanceno").hide();
                $("#FinancenoTextBox").hide();
                $("#lblfinmonth").hide();
                $("#finmonthTextBox").hide();
                $("#lblinterestrate").hide();
                $("#interestrateTextBox").hide();
                $("#lblisgtrate").hide();
                $("#isgtrateTextBox").hide();
                $("#lbligstamt").hide();
                $("#igstamtTextBox").hide();
                $("#lblfindocfee").hide();
                $("#findocfeeTextBox").hide();
                $("#lblnoemi").hide();
                $("#noemiTextBox").hide();
                $("#lblemiamt").hide();
                $("#emiamtTextBox").hide();
                $("#lblbalinitialdep").hide();
                $("#balinitialdepamtTextBox").hide();
                $("#lbleurorate").hide();
                $("#eurorateTextBox").hide();
                $("#lblloanamtINEuro").hide();
                $("#loanamtINEuroTextBox").hide();
               
            }
                    $("#financeradiobuttonlist").find('input[type=radio]').change(function () {
                        var value = $("#financeradiobuttonlist").find('input[type=radio]:checked').val();

                        var curr = $("#currencyDropDownList option:selected").text();
                        
                       
                        
               
               
                        if (value == "Finance")
                        {
                  
                    $("#lblfinancemethod").show();
                    $("#financemethodDropDownList").show();
                        
                    $("#lblfinanceno").hide();//.show();
                    $("#FinancenoTextBox").hide();//.show();
                    $("#lblfinmonth").show();
                    $("#finmonthTextBox").show();
                    $("#lblinterestrate").hide();
                    $("#interestrateTextBox").hide();
                    if (curr == "INR")
                    {
                        $("#lblisgtrate").hide();
                        $("#isgtrateTextBox").hide();
                        $("#lbligstamt").hide();
                        $("#igstamtTextBox").hide();
                        $("#lblfindocfee").hide();
                        $("#lblfindocfee").hide("DOCUMENTATION FEE");
                        $("#findocfeeTextBox").hide();
                        $("#lblnoemi").hide();
                        $("#noemiTextBox").hide();
                        $("#lblemiamt").hide();
                        $("#emiamtTextBox").hide();
                        $("#lbleurorate").hide();
                        $("#eurorateTextBox").hide();
                        $("#lblloanamtINEuro").hide();
                        $("#loanamtINEuroTextBox").hide();

                    }
                  
                    else if(curr=="USD")
                    {
                        $("#lblisgtrate").hide();
                        $("#isgtrateTextBox").hide();
                        $("#lbligstamt").hide();
                        $("#igstamtTextBox").hide();
                        $("#lblfindocfee").hide();
                        $("#lblfindocfee").text("ACCEPTANCE FEE");
                        $("#findocfeeTextBox").hide();
                        $("#lblnoemi").hide();
                        $("#noemiTextBox").hide();
                        $("#lblemiamt").hide();
                        $("#emiamtTextBox").hide();
                        $("#lbleurorate").hide();
                        $("#eurorateTextBox").hide();
                        $("#lblloanamtINEuro").hide();
                        $("#loanamtINEuroTextBox").hide();
                        $.ajax({

                            type: 'post',
                            contentType: "application/json; charset=utf-8",
                            url: 'Indian_contracts_Edit.aspx/getCurrentEuroRate',
                            data: "{'finance':'" + curr + "'}",
                            async: false,
                            success: function (data) {

                                subJson = JSON.parse(data.d);

                                alert(subJson);
                                $.each(subJson, function (key, value) {
                                    $.each(value, function (index1, value1) {
                                        $("#eurorateTextBox").val(value1[0]);

                                    });
                                });
                            },
                            error: function () {
                                alert("wrong");
                            }



                        });



                    }

                    $("#lblbalinitialdep").show();
                    $("#balinitialdepamtTextBox").show();
                    var b = $("#baldepamtTextBox").val();
                    var t = $("#balinitialdepamtTextBox").val();
                    var f = $("#totalfinpriceIntaxTextBox").val();
                    var intial = $("#intialdeppercentTextBox").val();
                    var office = $("#officeTextBox").val();
                     
                    var ContractDetails_ID = $("#ContractdetailsIDTextBox").val();
                    var financeval = $("#financeradiobuttonlist").find('input[type=radio]:checked').val();
                    $.ajax({

                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        url: 'Indian_contracts_Edit.aspx/LoadFinancemethod1',
                        data: "{'office':'" + office + "','ContractDetails_ID':'" + ContractDetails_ID + "'}",
                     //   url: 'Indian_contracts_Edit.aspx/LoadFinancemethod1',
                      //  data: "{'office':'" + office + "','ContractDetails_ID':'" + ContractDetails_ID + "','finance_type':'" + financeval + "'}",
                        async: false,
                        success: function (data)
                        {
                             

                                $("#financemethodDropDownList").empty();
                                  $("#financemethodDropDownList").append("<option disabled selected value>  </option>")
                                subJson = JSON.parse(data.d);
                    
                                $.each(subJson, function (key, value) {
                                    $.each(value, function (index1, value1) {
                                        

                                            $("#financemethodDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                         
                                    });
                                });
                               
                                pay_method();
                        },
                        //complete: function (data) {
                        //    pay_method();
                        // //   LoanEMICalculation();
                        //},
                        error: function () {
                           // alert("wrong LoadFinancemethod");
                        }



                    });
                   // return false;
                   
                    if (b == "" || b == "0" || b == "NaN")
                    {
                        var bb = "0";
                        

                      //  var test1 = (parseInt(intial) + parseInt(bb) + parseInt(t));
                        var test1 = (parseInt(intial) + parseInt(t));
                      //  alert("tot dep:" + test1);
                        var test = Math.round(parseInt(f) - parseInt(test1));
                   //     alert("finance amt:"+test);
                        $("#balamtpayableTextBox").val(test);
                        var inst = $("#NoinstallmentTextBox").val();
                        var instamt = Math.round(parseInt(test) / parseInt(inst));
                        $("#installmentamtTextBox").val(instamt);

                       /* var test = parseInt(f) -  parseInt(t);
                        $("#balamtpayableTextBox").val(test);
                        var inst = $("#NoinstallmentTextBox").val();
                        var instamt = Math.round(parseInt(t) / parseInt(inst));
                        $("#installmentamtTextBox").val(instamt);*/

                    }
                    else {

                        
                        var test1 = (parseInt(intial) + parseInt(b) + parseInt(t));
                        var test = Math.round(parseInt(f) - parseInt(test1));

                        $("#balamtpayableTextBox").val(test);
                        var inst = $("#NoinstallmentTextBox").val();
                        var instamt = Math.round(parseInt(test) / parseInt(inst));
                        $("#installmentamtTextBox").val(instamt);

                       /* var test = parseInt(f)-(parseInt(b) + parseInt(t));
                        $("#balamtpayableTextBox").val(test);
                        var inst = $("#NoinstallmentTextBox").val();
                        var instamt = Math.round(parseInt(t) / parseInt(inst));
                        $("#installmentamtTextBox").val(instamt);*/

                       

                    }


                
                } else {
                      //  alert("htghd");
                    $("#lblfinancemethod").hide();
                    $("#financemethodDropDownList").hide();
                    $("#lblfinanceno").hide();
                    $("#FinancenoTextBox").hide();
                    $("#lblfinmonth").hide();
                    $("#finmonthTextBox").hide();
                    $("#lblinterestrate").hide();
                    $("#interestrateTextBox").hide();
                    $("#lblisgtrate").hide();
                    $("#isgtrateTextBox").hide();
                    $("#lbligstamt").hide();
                    $("#igstamtTextBox").hide();
                    $("#lblfindocfee").hide();
                    $("#findocfeeTextBox").hide();
                    $("#lblnoemi").hide();
                    $("#noemiTextBox").hide();
                    $("#lblemiamt").hide();
                    $("#emiamtTextBox").hide();
                    $("#lblbalinitialdep").hide();
                    $("#balinitialdepamtTextBox").hide();
                    $("#lbleurorate").hide();
                    $("#eurorateTextBox").hide();
                    $("#lblloanamtINEuro").hide();
                    $("#loanamtINEuroTextBox").hide();
                   
                    var tot = $("#totalfinpriceIntaxTextBox").val();
                    
                    if (tot == "0")
                    {
                        var t = "0";
                        var f = "0";
                        var b = "0";
                        var intial = "0";

                        if (b == "" || b == "0" || b == "NaN") {
                            var bb = "0";
                            //   var test = Math.round(parseInt(tot) - (parseInt(intial) + parseInt(bb)));
                            var test = Math.round(parseInt(tot) - parseInt(intial));
                            $("#balamtpayableTextBox").val(test);
                            var instno = "0";
                            $("#NoinstallmentTextBox").val(instno);
                            $("#installmentamtTextBox").val(instno);
                            var inst = $("#NoinstallmentTextBox").val();
                            var instamt = Math.round(parseInt(test) / parseInt(inst));
                            $("#installmentamtTextBox").val(instamt);



                        }
                        else {

                            var test = Math.round(parseInt(tot) - (parseInt(intial) + parseInt(b)));
                            $("#balamtpayableTextBox").val(test);
                            var instno = "0";
                            $("#NoinstallmentTextBox").val(instno);
                            $("#installmentamtTextBox").val(instno);
                            var inst = $("#NoinstallmentTextBox").val();
                            var instamt = Math.round(parseInt(test) / parseInt(inst));
                            $("#installmentamtTextBox").val(instamt);




                        }
                    }
                    else
                    {
                        var t = $("#balinitialdepamtTextBox").val();
                        var f = $("#balamtpayableTextBox").val();
                        var b = $("#baldepamtTextBox").val();
                        var intial = $("#intialdeppercentTextBox").val();
                       // alert("b:"+b);
                        if (b == "" || b == "0" || b == "NaN")
                        {
                           // alert("hi");
                            
                            
                            //   var test = Math.round(parseInt(tot) - (parseInt(intial) + parseInt(bb)));
                            var test = Math.round(parseInt(tot) - parseInt(intial));
                           // alert(test);
                            $("#balamtpayableTextBox").val(test);
                            var inst = $("#NoinstallmentTextBox").val();
                            var instamt = Math.round(parseInt(test) / parseInt(inst));
                            $("#installmentamtTextBox").val(instamt);



                        }
                        else {

                            var test = Math.round(parseInt(tot) - (parseInt(intial) + parseInt(b)));
                            $("#balamtpayableTextBox").val(test);
                            var inst = $("#NoinstallmentTextBox").val();
                            var instamt = Math.round(parseInt(test) / parseInt(inst));
                            $("#installmentamtTextBox").val(instamt);




                        }
                    }
            
                }



            });



        });


    </script>

    <%--<script>
        $(document).ready(function (){
        
        
            $("#financemethodDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var value2 = document.getElementById("contracttypeTextBox").value;
              
                //   var value3 = $("#financemethodDropDownList option:selected").text();

                var v1 = document.getElementById("financemethodDropDownList");
                var value3 = v1.options[v1.selectedIndex].text;

                var ContractDetails_ID = $("#ContractdetailsIDTextBox").val();
                var financeval = $("#financeradiobuttonlist").find('input[type=radio]:checked').val();

                
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/getFinanceNo',
                    data: "{'venue':'" + value + "','finance':'" + value3 + "','type':'" + value2 + "','contractdetails_id':'" + ContractDetails_ID + "','financevalue':'" + financeval + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#FinancenoTextBox").val(value1[0]);
                             //   $("#noemiTextBox").val('60');

                            });
                        });
                    },
                    error: function () {
                        alert("wrong getFinanceNo");
                    }



                });
                return false;
            });
        
        });
        
         

       
  

    </script>--%>

    
    
   <script>
       $(document).ready(function(){
           var emerald, holidayplus, registry, total;
           var regcollterm = $("#regcollectiontermTextBox").val();
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts_Edit.aspx/getAffiliate',
                data: "{}",
                async: false,
                success: function (data) {
               //    alert(data.d);
                    subJson = JSON.parse(data.d);

                    //alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            if (value1[1] == "INR")
                            {
                                if (value1[0] == "Emerald  " || value1[0] == "Emerald") {
                                    $("#ca1").prop('checked', true);
                                    $("#ca2").prop('checked', false);
                                    $("#ca3").prop('checked', false);
                                    emerald = "0";// "23852";
                                    holidayplus = "0";
                                    registry = "0";
                                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    $("#nonfinbalamtTextBox").val(total);
                                }
                                else if (value1[0] == " Holiday Plus " || value1[0] == "Holiday Plus") {
                                    $("#ca1").prop('checked', false);
                                    $("#ca2").prop('checked', true);
                                    $("#ca3").prop('checked', false);
                                    emerald = "0";
                                    holidayplus = "0";// "2680";
                                    registry = "0";
                                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    $("#nonfinbalamtTextBox").val(total);
                                }
                                else if (value1[0] == "  Registry Collection" || value1[0] == "Registry Collection") {
                                    $("#ca1").prop('checked', false);
                                    $("#ca2").prop('checked', false);
                                    $("#ca3").prop('checked', true);
                                    emerald = "0";
                                    holidayplus = "0";
                                    if (regcollterm < 5)
                                    {
                                        var regcollamt = $("#regcollamtTextBox").val();
                                        registry = regcollamt;                                        
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                       
                                    }

                                    else if (regcollterm = 5)
                                    {
                                        registry = "0";// "47302";
                                        $("#regcollamtTextBox").val(registry);                                        
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);                                        
                                    }
                                    document.getElementById("nonfinbalamtTextBox").value = total;

                                }
                                else if (value1[0] == "Emerald Holiday Plus " || value1[0] == "Emerald Holiday Plus") {
                                    $("#ca1").prop('checked', true);
                                    $("#ca2").prop('checked', true);
                                    $("#ca3").prop('checked', false);
                                    emerald ="0";// "23852";
                                    holidayplus = "0";// "2680";
                                    registry = "0";
                                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    $("#nonfinbalamtTextBox").val(total);


                                }
                                else if (value1[0] == "Emerald  Registry Collection" || value1[0] == "Emerald Registry Collection") {
                                    $("#ca1").prop('checked', true);
                                    $("#ca2").prop('checked', false);
                                    $("#ca3").prop('checked', true);
                                    emerald = "0";//"23852";
                                    holidayplus = "0";
                                    if (regcollterm < 5) {
                                        var regcollamt = $("#regcollamtTextBox").val();
                                        registry = regcollamt;
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                                    }

                                    else if (regcollterm = 5) {
                                        registry = "0";//"47302";
                                        $("#regcollamtTextBox").val(registry);
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    }
                                    document.getElementById("nonfinbalamtTextBox").value = total;


                                } else if (value1[0] == " Holiday Plus Registry Collection" || value1[0] == "Holiday Plus Registry Collection") {
                                    $("#ca1").prop('checked', false);
                                    $("#ca2").prop('checked', true);
                                    $("#ca3").prop('checked', true);
                                    emerald = "0";
                                    holidayplus = "0";// "2680";
                                    if (regcollterm < 5) {
                                        var regcollamt = $("#regcollamtTextBox").val();
                                        registry = regcollamt;
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                                    }

                                    else if (regcollterm = 5) {
                                        registry = "0";//"47302";
                                        $("#regcollamtTextBox").val(registry);
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    }
                                    document.getElementById("nonfinbalamtTextBox").value = total;
                                }
                                else if (value1[0] == "Emerald Holiday Plus Registry Collection") {
                                    $("#ca1").prop('checked', true);
                                    $("#ca2").prop('checked', true);
                                    $("#ca3").prop('checked', true);
                                    emerald ="0";// "23852";
                                    holidayplus = "0";// "2680";
                                    if (regcollterm < 5) {
                                        var regcollamt = $("#regcollamtTextBox").val();
                                        registry = regcollamt;
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                                    }

                                    else if (regcollterm = 5) {
                                        registry = "0";// "47302";
                                        $("#regcollamtTextBox").val(registry);
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    }
                                    document.getElementById("nonfinbalamtTextBox").value = total;

                                }
                                else if (value1[0] == "" || value1[0] == "  ") {
                                    $("#ca1").prop('checked', false);
                                    $("#ca2").prop('checked', false);
                                    $("#ca3").prop('checked', false);
                                    emerald = "0";
                                    holidayplus = "0";
                                    registry = "0";
                                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    document.getElementById("nonfinbalamtTextBox").value = total;
                                }
                            }
                            else if(value1[1]=="USD")
                            {
                                if (value1[0] == "Emerald  " || value1[0] == "Emerald") {
                                    $("#ca1").prop('checked', true);
                                    $("#ca2").prop('checked', false);
                                    $("#ca3").prop('checked', false);
                                    emerald = "0";//"150";
                                    holidayplus = "0";
                                    registry = "0";
                                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    $("#nonfinbalamtTextBox").val(total);
                                }
                                else if (value1[0] == " Holiday Plus " || value1[0] == "Holiday Plus") {
                                    $("#ca1").prop('checked', false);
                                    $("#ca2").prop('checked', true);
                                    $("#ca3").prop('checked', false);
                                    emerald = "0";
                                    holidayplus = "0";// "40";
                                    registry = "0";
                                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    $("#nonfinbalamtTextBox").val(total);
                                }
                                else if (value1[0] == "  Registry Collection" || value1[0] == "Registry Collection") {
                                    $("#ca1").prop('checked', false);
                                    $("#ca2").prop('checked', false);
                                    $("#ca3").prop('checked', true);
                                    emerald = "0";
                                    holidayplus = "0";
                                    if (regcollterm < 5) {
                                        var regcollamt = $("#regcollamtTextBox").val();
                                        registry = regcollamt;
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                                    }

                                    else if (regcollterm = 5) {
                                        registry = "0";// "706";
                                        $("#regcollamtTextBox").val(registry);
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    }
                                    document.getElementById("nonfinbalamtTextBox").value = total;

                                }
                                else if (value1[0] == "Emerald Holiday Plus " || value1[0] == "Emerald Holiday Plus") {
                                    $("#ca1").prop('checked', true);
                                    $("#ca2").prop('checked', true);
                                    $("#ca3").prop('checked', false);
                                    emerald ="0";// "150";
                                    holidayplus = "0";// "40";
                                    registry = "0";
                                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    $("#nonfinbalamtTextBox").val(total);


                                }
                                else if (value1[0] == "Emerald  Registry Collection" || value1[0] == "Emerald Registry Collection") {
                                    $("#ca1").prop('checked', true);
                                    $("#ca2").prop('checked', false);
                                    $("#ca3").prop('checked', true);
                                    emerald ="0";// "150";
                                    holidayplus = "0";
                                    if (regcollterm < 5) {
                                        var regcollamt = $("#regcollamtTextBox").val();
                                        registry = regcollamt;
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                                    }

                                    else if (regcollterm = 5) {
                                        registry = "0";// "706";
                                        $("#regcollamtTextBox").val(registry);
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    }
                                    document.getElementById("nonfinbalamtTextBox").value = total;


                                } else if (value1[0] == " Holiday Plus Registry Collection" || value1[0] == "Holiday Plus Registry Collection") {
                                    $("#ca1").prop('checked', false);
                                    $("#ca2").prop('checked', true);
                                    $("#ca3").prop('checked', true);
                                    emerald = "0";
                                    holidayplus = "0";// "40";
                                    if (regcollterm < 5) {
                                        var regcollamt = $("#regcollamtTextBox").val();
                                        registry = regcollamt;
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                                    }

                                    else if (regcollterm = 5) {
                                        registry = "706";
                                        $("#regcollamtTextBox").val(registry);
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    }
                                    document.getElementById("nonfinbalamtTextBox").value = total;
                                }
                                else if (value1[0] == "Emerald Holiday Plus Registry Collection") {
                                    $("#ca1").prop('checked', true);
                                    $("#ca2").prop('checked', true);
                                    $("#ca3").prop('checked', true);
                                    emerald = "0";//"150";
                                    holidayplus = "0";//"40";
                                    if (regcollterm < 5) {
                                        var regcollamt = $("#regcollamtTextBox").val();
                                        registry = regcollamt;
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

                                    }

                                    else if (regcollterm = 5) {
                                        registry = "0";// "706";
                                        $("#regcollamtTextBox").val(registry);
                                        total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    }
                                    document.getElementById("nonfinbalamtTextBox").value = total;

                                }
                                else if (value1[0] == "" || value1[0] == "  ") {
                                    $("#ca1").prop('checked', false);
                                    $("#ca2").prop('checked', false);
                                    $("#ca3").prop('checked', false);
                                    emerald = "0";
                                    holidayplus = "0";
                                    registry = "0";
                                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                                    document.getElementById("nonfinbalamtTextBox").value = total;
                                }

                            }
                           
                       if (value1[0] == "Emerald  " || value1[0] == "Emerald") {
                                $("#ca1").prop('checked',true);
                                $("#ca2").prop('checked',false);
                                $("#ca3").prop('checked', false);
                                
                            }
                            else if (value1[0] == " Holiday Plus " || value1[0] == "Holiday Plus")
                            {
                                $("#ca1").prop('checked',false);
                                $("#ca2").prop('checked',true);
                                $("#ca3").prop('checked', false);
                            }
                            else if (value1[0] == "  Registry Collection" || value1[0] == "Registry Collection") {
                                $("#ca1").prop('checked',false);
                                $("#ca2").prop('checked',false);
                                $("#ca3").prop('checked',true);

                            }
                            else if (value1[0] == "Emerald Holiday Plus " || value1[0] == "Emerald Holiday Plus") {
                                $("#ca1").prop('checked',true);
                                $("#ca2").prop('checked',true);
                                $("#ca3").prop('checked', false);
                                 

                            }
                            else if (value1[0] == "Emerald  Registry Collection" || value1[0] == "Emerald Registry Collection") {
                                $("#ca1").prop('checked',true);
                                $("#ca2").prop('checked',false);
                                $("#ca3").prop('checked', true);
                               

                            } else if (value1[0] == " Holiday Plus Registry Collection" || value1[0] == "Holiday Plus Registry Collection")
                            {
                                $("#ca1").prop('checked',false);
                                $("#ca2").prop('checked',true);
                                $("#ca3").prop('checked',true);
                            }
                            else if(value1[0]=="Emerald Holiday Plus Registry Collection")
                            {   $("#ca1").prop('checked',true);
                                $("#ca2").prop('checked',true);
                                $("#ca3").prop('checked', true);
                               
                            }
                            else if (value1[0] == "" || value1[0] == "  ")
                            {
                                $("#ca1").prop('checked',false);
                                $("#ca2").prop('checked',false);
                                $("#ca3").prop('checked', false);
                             
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong getAffiliate");
                }


            });
            return false;


        
        });

    </script>
    
       <script>
           $(document).ready(function () {
               var marketingText = $("#MarketingProgramDropDownList option:selected").text();
               $("#TextBox3").val(marketingText);
               $("#MarketingProgramDropDownList").change(function () {
                   var marketingText = $("#MarketingProgramDropDownList option:selected").text();
                   $("#TextBox3").val(marketingText);

                var marketingValue1 = $("#MarketingProgramDropDownList option:selected").val();
               // alert(marketingValue1);
                // if (marketingValue1 == "OWNER" || marketingValue1 == "Owner" || marketingValue1 == "owner" || marketingValue1 == "OWNER DOWNGRADE" || marketingValue1 == "Owner Downgrade") 
                if (marketingValue1 == "FRACTIONAL OWNER" || marketingValue1 == "FRACTIONAL OWNER RCI" || marketingValue1 == "T/S MEMBER" || marketingValue1 == "T/S MEMBER RCI" || marketingValue1 == "OWNER" || marketingValue1 == "RCIOWN" || marketingValue1 == "RCIOwn" || marketingValue1 == "Member" || marketingValue1 == "MEMBER" || marketingValue1 == "RCIMBR" || marketingValue1 == "RCIMbr" || marketingvalue1 == "MEMBER MARKETING GOA" || marketingvalue1 == "MMG")
                {

                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").show();
                    $("#Memno1TextBox").show();
                    $("#Label114").hide();
                    $("#TypeDropDownList").hide();



                } else {
                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").hide();
                    $("#Memno1TextBox").hide();
                    $("#Label114").show();
                    $("#TypeDropDownList").show();

                }


            });



        });

    </script>

    
    <script>
        $(document).ready(function () {

            // loading country code primary for primary as per country//
            $("#primarycountryDropDownList").change(function () {
                var country = $("#primarycountryDropDownList option:selected").text();
                 //alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#primarymobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loading country code primary for primary as per country");
                    }





                });

                // end//


                // loding all country code alternative for primary as per country//


                var country = $("#primarycountryDropDownList option:selected").text();
               // alert(country);
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#primaryalternateDropDownList").empty();
                        $("#primaryalternateDropDownList").append("<option value=''>select an option </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for primary as per country");
                    }



                });
         

                //end//

                // loding all country code office for primary as per country//


                var country = $("#primarycountryDropDownList option:selected").text();
                // alert(country);
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#pofficecodeDropDownList").empty();
                        $("#pofficecodeDropDownList").append("<option value=''>select an option  </option>");

                        $("#phomecodeDropDownList").empty();
                        $("#phomecodeDropDownList").append("<option value=''>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#pofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#phomecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code office for primary as per country");
                    }



                });
                  return false;

                //end//


            });

        });
    </script>

    <script>
        $(document).ready(function () {

            // loading country code primary for secondary as per country//
            $("#secondarycountryDropDownList").change(function () {
                var country = $("#secondarycountryDropDownList option:selected").text();
                //alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#secondarymobileDropDownList").empty();
                        $("#secondarymobileDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loading country code primary for secondary as per country");
                    }




                });

                // end//


                // loding all country code alternative for secondary as per country//


                var country = $("#secondarycountryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#secondaryalternateDropDownList").empty();
                        $("#secondaryalternateDropDownList").append("<option value=''>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for secondary as per country");
                    }
                });
                //end//


                // loding all country code office for secondary as per country//


                var country = $("#secondarycountryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sofficecodeDropDownList").empty();
                        $("#sofficecodeDropDownList").append("<option value=''>select an option  </option>");

                        $("#shomecodeDropDownList").empty();
                        $("#shomecodeDropDownList").append("<option value=''>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#shomecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code office for secondary as per country");
                    }
                });
                return false;

                //end//
            });
        });


    </script>

      <script>

        $(document).ready(function () {
            // loading states on country////
            $("#AddCountryDropDownList").change(function () {
                var country = $("#AddCountryDropDownList option:selected").text();
                //   alert(country);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadStates',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#StateDropDownList").empty();
                        $("#StateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#StateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong load states");
                    }

                });
                return false;

            });
            //end///
        });
    </script>
    <script>

        $(document).ready(function () {
            // loading states on country////
            $("#ccountryDropDownList").change(function () {
                var country = $("#ccountryDropDownList option:selected").text();
                //   alert(country);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadStates',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#cstateDropDownList").empty();
                        $("#cstateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#cstateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong load states");
                    }

                });
                return false;

            });
            //end///
        });
    </script>
     <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 1 as per country//
            $("#sp1countryDropDownList").change(function () {
                var country = $("#sp1countryDropDownList option:selected").text();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp1mobileDropDownList").empty();
                        $("#sp1mobileDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 1 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 1 as per country//

                
                
                var country = $("#sp1countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp1alternateDropDownList").empty();
                        $("#sp1alternateDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp1alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 1 as per country");
                    }



                });
                return false;

                //end//


            });



        });


    </script>

     <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 2 as per country//
            $("#sp2countryDropDownList").change(function () {
                var country = $("#sp2countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp2mobileDropDownList").empty();
                        $("#sp2mobileDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 1 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 2 as per country//

                
                
                var country = $("#sp2countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp2alternateDropDownList").empty();
                        $("#sp2alternateDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp2alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 2 as per country");
                    }

                });
                return false;

                //end//
            });
        });


    </script>

     <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 3 as per country//
            $("#sp3countryDropDownList").change(function () {
                var country = $("#sp3countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp3mobileDropDownList").empty();
                        $("#sp3mobileDropDownList").append("<option  value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp3mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 3 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 3 as per country//

                
                
                var country = $("#sp3countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp3alternateDropDownList").empty();
                        $("#sp3alternateDropDownList").append("<option  value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 3 as per country");
                    }

                });
                return false;

                //end//
            });
        });


    </script>

    <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 4 as per country//
            $("#sp4countryDropDownList").change(function () {
                var country = $("#sp4countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp4mobileDropDownList").empty();
                        $("#sp4mobileDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp4mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 4 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 4 as per country//

                
                
                var country = $("#sp4countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp4alternateDropDownList").empty();
                        $("#sp4alternateDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp4alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 4 as per country");
                    }

                });
                return false;

                //end//
            });
        });


    </script>

     <script>
    $(document).ready(function(){
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'Indian_contracts_Edit.aspx/loadRegTerms',
            data: "{}",
            async: false,
            success: function (data) {

                //alert("hello"+data.d);

                subJson = JSON.parse(data.d);


                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {
                        if (value1[0] == "Y") {
                            $('#CheckBox2').prop('checked', true);
                        } else {
                            $('#CheckBox2').prop('checked', false);
                        }
                      
                    });
                });
            },
            error: function () {
                alert("wrong loadRegTerms");
            }



        });


   });
   </script>


     

        <script>
        $(document).ready(function () {
            $("#pmobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#pmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');

                    $("#pmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;

                }

            });

            $("#palternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#palternateTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');
                    $("#palternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });

            $("#smobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#smobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#smobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#salternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#salternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#salternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });








            $("#sp1mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp1mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp1mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });









            $("#sp1alternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;// /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#sp1alternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp1alternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });



            $("#sp2mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp2mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp2mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp2alternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;// /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp2alternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp2alternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp3mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp3mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp3mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp3altmobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;// /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp3altmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp3altmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp4mobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp4mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp4mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp4altmobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;///^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {

                    if (mobNum.length <= 15) {
                        //  alert("valid");


                    } else {
                        alert('Enter valid number');


                        return false;
                    }
                    $("#sp4altmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');

                    $("#sp4altmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });

        });


    </script>

      <script>
     /*   $(document).ready(function () {
              var value1 = $("#oldcontracttypeDropDownList option:selected").val();
            //var v = document.getElementById("oldcontracttypeDropDownList");
            //var value1 = v.options[v.selectedIndex].text;
            alert(value1);
            if (value1 == "Points") {

                $("#lbltmresort").show();
                $("#tnmresortTextBox").show();
                $("#lbltipnopoints").show();
                $("#tipnopointsTextBox").show();
                $("#lbltnmcontrcino").show();
                $("#nmcontrcinoTextBox").show();
                $("#lbltipptsvalue").show();
                $("#tipptsvalueTextBox").show();

                $("#lblfwresort").show();
                $("#fwresortDropDownList").show();

                $("#lblfwresidenceno").show();
                $("#fwresidencenoDropDownList").show();
                $("#lblfwresidencetype").show();
                $("#fwresidencetypeDropDownList").show();
                $("#lblfwfractInt").show();
                $("#fwfractIntDropDownList").show();
                $("#lblfwentitlement").show();
                $("#fwentitlementDropDownList").show();
                $("#lblfwfirstyr").show();
                $("#fwfirstyrTextBox").show();
                $("#lblfwtenure").show();
                $("#fwtenureTextBox").show();
                $("#lblfwlastyr").show();
                $("#fwlastyrTextBox").show();

                $("#lbltmapttype").hide();
                $("#tnmapttypeTextBox").hide();
                $("#lbltnmseason").hide();
                $("#tnmseasonDropDownList").hide();
                $("#lnltnmnowks").hide();
                $("#nmnowksTextBox").hide();

                $("#clubTextBox").hide();
                $("#newpointsrightTextBox").hide();
                $("#EntitlementPoinDropDownList").hide();
                $("#totalptrightsTextBox").hide();
                $("#firstyrTextBox").hide();
                $("#tenureTextBox").hide();
                $("#lastyrTextBox").hide();


            } else {
                $("#lbltmresort").show();
                $("#tnmresortTextBox").show();

                $("#lbltmapttype").show();
                $("#tnmapttypeTextBox").show();
                $("#lbltnmseason").show();
                $("#tnmseasonDropDownList").show();
                $("#lnltnmnowks").show();
                $("#nmnowksTextBox").show();

                $("#lbltnmcontrcino").show();
                $("#nmcontrcinoTextBox").show();
                $("#lbltipptsvalue").show();
                $("#tipptsvalueTextBox").show();


                $("#lblfwresort").show();
                $("#fwresortDropDownList").show();

                $("#lblfwresidenceno").show();
                $("#fwresidencenoDropDownList").show();
                $("#lblfwresidencetype").show();
                $("#fwresidencetypeDropDownList").show();
                $("#lblfwfractInt").show();
                $("#fwfractIntDropDownList").show();
                $("#lblfwentitlement").show();
                $("#fwentitlementDropDownList").show();
                $("#lblfwfirstyr").show();
                $("#fwfirstyrTextBox").show();
                $("#lblfwtenure").show();
                $("#fwtenureTextBox").show();
                $("#lblfwlastyr").show();
                $("#fwlastyrTextBox").show();

                $("#clubTextBox").hide();
                $("#newpointsrightTextBox").hide();
                $("#EntitlementPoinDropDownList").hide();
                $("#totalptrightsTextBox").hide();
                $("#firstyrTextBox").hide();
                $("#tenureTextBox").hide();
                $("#lastyrTextBox").hide();

            }




        });*/

    </script>

    <script>
         $(document).ready(function ()
         {
             
            $("#oldcontracttypeDropDownList").change(function () {
                var value1 = $("#oldcontracttypeDropDownList option:selected").text();
                //var v = document.getElementById("oldcontracttypeDropDownList");
                //var value1 = v.options[v.selectedIndex].text;
               
                if (value1 == "Points") 
                {
                    $("#lblfwresort").show();
                    $("#fwresortDropDownList").show();
                    $("#lblfwresidenceno").show();
                    $("#fwresidencenoDropDownList").show();
                    $("#lblfwresidencetype").show();
                    $("#fwresidencetypeDropDownList").show();
                    $("#lblfwfractInt").show();
                    $("#fwfractIntDropDownList").show();
                    $("#lblfwentitlement").show();
                    $("#fwentitlementDropDownList").show();
                    $("#lblfwfirstyr").show();
                    $("#fwfirstyrTextBox").show();
                    $("#lblfwtenure").show();
                    $("#fwtenureTextBox").show();
                    $("#lblfwlastyr").show();
                    $("#fwlastyrTextBox").show();

                    $("#lbltmapttype").hide();
                    $("#tnmapttypeTextBox").hide();
                    $("#lbltnmseason").hide();
                    $("#tnmseasonDropDownList").hide();
                    $("#lnltnmnowks").hide();
                    $("#nmnowksTextBox").hide();
                    $("#twoldmtypeTextBox").show();

                    $("#clubTextBox").hide();
                    $("#newpointsrightTextBox").hide();
                    $("#EntitlementPoinDropDownList").hide();
                    $("#totalptrightsTextBox").hide();
                    $("#firstyrTextBox").hide();
                    $("#tenureTextBox").hide();
                    $("#lastyrTextBox").hide();
                

                } else if (value1 == "Weeks") {
                    $("#lbltmresort").show();
                    $("#tnmresortTextBox").show();

                    $("#lbltmapttype").show();
                    $("#tnmapttypeTextBox").show();
                    $("#lbltnmseason").show();
                    $("#tnmseasonDropDownList").show();
                    $("#lnltnmnowks").show();
                    $("#nmnowksTextBox").show();
                    $("#twoldmtypeTextBox").show();
                    $("#lbltnmcontrcino").show();
                    $("#nmcontrcinoTextBox").show();
                    $("#lbltipptsvalue").show();
                    $("#tipptsvalueTextBox").show();

                    $("#lbltipactualptsvalue").show();
                    $("#tipactualptsvalueTextBox").show();

                    $("#lblfwresort").show();
                    $("#fwresortDropDownList").show();

                    $("#lblfwresidenceno").show();
                    $("#fwresidencenoDropDownList").show();
                    $("#lblfwresidencetype").show();
                    $("#fwresidencetypeDropDownList").show();
                    $("#lblfwfractInt").show();
                    $("#fwfractIntDropDownList").show();
                    $("#lblfwentitlement").show();
                    $("#fwentitlementDropDownList").show();
                    $("#lblfwfirstyr").show();
                    $("#fwfirstyrTextBox").show();
                    $("#lblfwtenure").show();
                    $("#fwtenureTextBox").show();
                    $("#lblfwlastyr").show();
                    $("#fwlastyrTextBox").show();

                    $("#clubTextBox").hide();
                    $("#newpointsrightTextBox").hide();
                    $("#EntitlementPoinDropDownList").hide();
                    $("#totalptrightsTextBox").hide();
                    $("#firstyrTextBox").hide();
                    $("#tenureTextBox").hide();
                    $("#lastyrTextBox").hide();

                }
                else if (value1 == "Fractionals") {
                    $("#lbltmresort").show();
                    $("#tnmresortTextBox").show();

                    $("#lbltmapttype").show();
                    $("#tnmapttypeTextBox").show();
                    $("#lbltnmseason").hide();
                    $("#tnmseasonDropDownList").hide();
                    $("#lnltnmnowks").show();
                    $("#nmnowksTextBox").show();
                    $("#twoldmtypeTextBox").show();
                    $("#lbltnmcontrcino").show();
                    $("#nmcontrcinoTextBox").show();
                    $("#lbltipptsvalue").hide();
                    $("#tipptsvalueTextBox").hide();

                    $("#lbltipactualptsvalue").hide();
                    $("#tipactualptsvalueTextBox").hide();

                    $("#lblfwresort").show();
                    $("#fwresortDropDownList").show();

                    $("#lblfwresidenceno").show();
                    $("#fwresidencenoDropDownList").show();
                    $("#lblfwresidencetype").show();
                    $("#fwresidencetypeDropDownList").show();
                    $("#lblfwfractInt").show();
                    $("#fwfractIntDropDownList").show();
                    $("#lblfwentitlement").show();
                    $("#fwentitlementDropDownList").show();
                    $("#lblfwfirstyr").show();
                    $("#fwfirstyrTextBox").show();
                    $("#lblfwtenure").show();
                    $("#fwtenureTextBox").show();
                    $("#lblfwlastyr").show();
                    $("#fwlastyrTextBox").show();

                    $("#clubTextBox").hide();
                    $("#newpointsrightTextBox").hide();
                    $("#EntitlementPoinDropDownList").hide();
                    $("#totalptrightsTextBox").hide();
                    $("#firstyrTextBox").hide();
                    $("#tenureTextBox").hide();
                    $("#lastyrTextBox").hide();

                }

            });


        }); 



    </script>
  


    <script>
        $(document).ready(function () {

            //  var value = $("#contracttypeTextBox").val();
            var value = document.getElementById("contracttypeTextBox").value;
           
            var marketprogram = $("#MarketingProgramDropDownList :selected").text();
            if (value == "Points") {
                $("#lbltmresort").hide();
                $("#tnmresortTextBox").hide();
                $("#lbltipnopoints").hide();
                $("#tipnopointsTextBox").hide();
                $("#lbltnmcontrcino").hide();
                $("#nmcontrcinoTextBox").hide();
                $("#lbltipptsvalue").hide();
                $("#tipptsvalueTextBox").hide();
                $("#lbltipactualptsvalue").hide();
                $("#tipactualptsvalueTextBox").hide();

                $("#lbllabelname").hide();
                 $("#lbllabelname").hide();
                $("#lblclub").show();
                $("#clubTextBox").show();
                $("#lblnewpts").show();
                $("#newpointsrightTextBox").show();
                $("#lblentitlement").show();
                $("#EntitlementPoinDropDownList").show();

                $("#lbltotalpoints").show();
                $("#totalptrightsTextBox").show();
                $("#lblfirstyr").show();              
                $("#firstyrTextBox").show();
                $("#lbltenure").show();
                $("#tenureTextBox").show();

                $("#lbllastyr").show();
                $("#lastyrTextBox").show();
                $("#lblcontractlabel").hide();
                $("#Label70").hide();
                $("#Label111").hide();
                 $("#oldcontracttypeDropDownList").hide();
                // trade in weeks///

                $("#lbltmresort").hide();
                $("#tnmresortTextBox").hide();

                $("#lbltmapttype").hide();
                $("#tnmapttypeTextBox").hide();
                $("#lbltnmseason").hide();
                $("#tnmseasonDropDownList").hide();
                $("#lnltnmnowks").hide();
                $("#nmnowksTextBox").hide();

                $("#lbltnmcontrcino").hide();
                $("#nmcontrcinoTextBox").hide();
                $("#lbltipptsvalue").hide();
                $("#tipptsvalueTextBox").hide();
                $("#lbltipactualptsvalue").hide();
                $("#tipactualptsvalueTextBox").hide();
                $("#lbltipnopoints").hide();
                $("#tipnopointsTextBox").hide();
                // end//

                // fractional/////
                $("#lblfwresort").hide();
                $("#fwresortDropDownList").hide();

                $("#lblfwresidenceno").hide();
                $("#fwresidencenoDropDownList").hide();
                $("#lblfwresidencetype").hide();
                $("#fwresidencetypeDropDownList").hide();
                $("#lblfwfractInt").hide();
                $("#fwfractIntDropDownList").hide();
                $("#lblfwentitlement").hide();
                $("#fwentitlementDropDownList").hide();
                $("#lblfwfirstyr").hide();
                $("#fwfirstyrTextBox").hide();
                $("#lblfwtenure").hide();
                $("#fwtenureTextBox").hide();
                $("#lblfwlastyr").hide();
                $("#fwlastyrTextBox").hide();
              //  $("#lbloldLoanAgreement").hide();
              //  $("#oldLoanAgreementTextBox").hide();
                $("#lbltradeinamt").hide();
                $("#tradeinamtTextBox").hide();
                $("#lblfoldloanamount").hide();
                $("#foldloanamountTextBox").hide();

                $("#lblopenLoanAgreement").hide();
                $("#openLoanAgreementTextBox").hide();

                $("#ca3").hide();
                $("#lblchk3").hide();
                $("#ca1").show();
                $("#lblchk1").show();
              
                
                
                $("#ca3").hide();
                $("#lblchk3").hide();
                $("#ca2").hide();
                $("#lblchk2").hide();

                $("#lblregcoll").hide();
                $("#regcollectiontermTextBox").hide();
                $("#lblregcollamt").hide();
                $("#regcollamtTextBox").hide();

                $("#lblftotalvalue").hide();
                $("#ftotalvalueTextBox").hide();
                $("#lblftradeinvalue").hide();
                $("#ftradeinvalueTextBox").hide();
 
                
                $("#lbltwoldmtype").hide();
                $("#twoldmtypeTextBox").hide();
                
                $("#NoPersonsTextBox").show();
                $("#lblNoPersons").show();

                //if (marketprogram == "OWNER" || marketprogram == "OWNER DOWNGRADE" || marketprogram == "Owner Downgrade" || marketprogram == "Owner") {
                if (marketprogram == "FRACTIONAL OWNER" || marketprogram == "FRACTIONAL OWNER RCI" || marketprogram == "T/S MEMBER" || marketprogram == "T/S MEMBER RCI" || marketprogram == "OWNER" || marketprogram == "RCIOWN" || marketprogram == "RCIOwn" || marketprogram == "Member" || marketprogram == "MEMBER" || marketprogram == "RCIMBR" || marketprogram == "RCIMbr" || marketprogram == "MEMBER MARKETING GOA" || marketprogram == "MMG")
                   
                {
                    $('#check').css('display', 'block');
                    
                } else {
                    $('#check').css('display', 'none');
                    
                }

               
            }
            else if (value == "Fractional") {
               
               // $("#Label111").show();
              //  $("#oldcontracttypeDropDownList").show();
                $("#lblfwresort").show();
                $("#fwresortDropDownList").show();

                $("#lblfwresidenceno").show();
                $("#fwresidencenoDropDownList").show();
                $("#lblfwresidencetype").show();
                $("#fwresidencetypeDropDownList").show();
                $("#lblfwfractInt").show();
                $("#fwfractIntDropDownList").show();
                $("#lblfwentitlement").show();
                $("#fwentitlementDropDownList").show();
                $("#lblfwfirstyr").show();
                $("#fwfirstyrTextBox").show();
                $("#lblfwtenure").show();
                $("#fwtenureTextBox").show();
                $("#lblfwlastyr").show();
                $("#fwlastyrTextBox").show();
                 // $("#Label70").show();
                //  $("#lblAdministrationFees").show();
               // $("#AdministrationFeesTextBox").show();

                // points///
                $("#lbllabelname").hide();
                $("#lblclub").hide();
                $("#clubTextBox").hide();
                $("#lblnewpts").hide();
                $("#newpointsrightTextBox").hide();
                $("#lblentitlement").hide();
                $("#EntitlementPoinDropDownList").hide();

                $("#lbltotalpoints").hide();
                $("#totalptrightsTextBox").hide();
                $("#lblfirstyr").hide();

                $("#firstyrTextBox").hide();
                $("#lbltenure").hide();
                $("#tenureTextBox").hide();

                $("#lbllastyr").hide();
                $("#lastyrTextBox").hide();
                $("#lblcontractlabel").hide();
                $("#Label70").hide();
                $("#Label111").hide();
                $("#oldcontracttypeDropDownList").hide();
                /// end///

                // trade in weeks///

                $("#lbltmresort").hide();
                $("#tnmresortTextBox").hide();

                $("#lbltmapttype").hide();
                $("#tnmapttypeTextBox").hide();
                $("#lbltnmseason").hide();
                $("#tnmseasonDropDownList").hide();
                $("#lnltnmnowks").hide();
                $("#nmnowksTextBox").hide();

                $("#lbltnmcontrcino").hide();
                $("#nmcontrcinoTextBox").hide();
                $("#lbltipptsvalue").hide();
                $("#tipptsvalueTextBox").hide();
                $("#lbltipactualptsvalue").hide();
                $("#tipactualptsvalueTextBox").hide();

                $("#lbltipnopoints").hide();
                $("#tipnopointsTextBox").hide();
              //  $("#lbloldLoanAgreement").hide();
                //$("#oldLoanAgreementTextBox").hide();

                $("#lbltradeinamt").hide();
                $("#tradeinamtTextBox").hide();
                $("#lblfoldloanamount").hide();
                $("#foldloanamountTextBox").hide();

                $("#lblopenLoanAgreement").hide();
                $("#openLoanAgreementTextBox").hide();

                $("#lblregcoll").hide();// show();
                $("#regcollectiontermTextBox").hide();// show();
                $("#lblregcollamt").hide();// show();
                $("#regcollamtTextBox").hide();// show();

                $("#lblftotalvalue").show();
                $("#ftotalvalueTextBox").show();
                $("#lblftradeinvalue").show();
                $("#ftradeinvalueTextBox").show();
                $("#ca3").hide();// show();
                $("#lblchk3").hide();// show();

                $("#NoPersonsTextBox").hide();
                $("#lblNoPersons").hide();
                $("#check").hide();
                $("#mcradiobuttonlist").hide();

                $("#ca1").show();
                $("#lblchk1").show();
                $("#ca2").hide();
                $("#lblchk2").hide();

                $("#Label79").hide();
                $("#lblafftype").hide();

                $("#lbltwoldmtype").hide();
                $("#twoldmtypeTextBox").hide();
            }

            else if(value=="Trade-In-Points"){
           

                $("#lbltmresort").hide();
                $("#tnmresortTextBox").hide();

                $("#lbltmapttype").hide();
                $("#tnmapttypeTextBox").hide();
                $("#lbltnmseason").hide();
                $("#tnmseasonDropDownList").hide();
                $("#lnltnmnowks").hide();
                $("#nmnowksTextBox").hide();
              //  lbllabelname.Text = "TRADE IN DETAILS";
               
                $("#lbltmresort").show();
                $("#tnmresortTextBox").show();
                $("#lbltipnopoints").show();
                $("#tipnopointsTextBox").show();
                $("#lbltnmcontrcino").show();
                $("#nmcontrcinoTextBox").show();
                $("#lbltipptsvalue").show();
                $("#tipptsvalueTextBox").show();
                $("#lbltipactualptsvalue").show();
                $("#tipactualptsvalueTextBox").show();
                $("#lbltwoldmtype").show();
                $("#twoldmtypeTextBox").show();
                
              //  $("#lbllabelname").show();
                // $("#lbllabelname").show();
                $("#lblclub").show();
                $("#clubTextBox").show();
                $("#lblnewpts").show();
                $("#newpointsrightTextBox").show();
                $("#lblentitlement").show();
                $("#EntitlementPoinDropDownList").show();

                $("#lbltotalpoints").show();
                $("#totalptrightsTextBox").show();
                $("#lblfirstyr").show();

                $("#firstyrTextBox").show();
                $("#lbltenure").show();
                $("#tenureTextBox").show();

                $("#lbllastyr").show();
                $("#lastyrTextBox").show();
                $("#lblcontractlabel").show();
                // $("#lblcontractlabel").show();
              

                // fractional///
                $("#lblfwresort").hide();
                $("#fwresortDropDownList").hide();

                $("#lblfwresidenceno").hide();
                $("#fwresidencenoDropDownList").hide();
                $("#lblfwresidencetype").hide();
                $("#fwresidencetypeDropDownList").hide();
                $("#lblfwfractInt").hide();
                $("#fwfractIntDropDownList").hide();
                $("#lblfwentitlement").hide();
                $("#fwentitlementDropDownList").hide();
                $("#lblfwfirstyr").hide();
                $("#fwfirstyrTextBox").hide();
                $("#lblfwtenure").hide();
                $("#fwtenureTextBox").hide();
                $("#lblfwlastyr").hide();
                $("#fwlastyrTextBox").hide();
                //$("#lbloldLoanAgreement").hide();
                //$("#oldLoanAgreementTextBox").hide();
                $("#lbltradeinamt").hide();
                $("#tradeinamtTextBox").hide();
                $("#lblfoldloanamount").show();
                $("#foldloanamountTextBox").show();
                $("#lblopenLoanAgreement").show();
                $("#openLoanAgreementTextBox").show();

                //end//

                $("#Label70").hide();
                $("#Label111").hide();
                $("#oldcontracttypeDropDownList").hide();

                $("#lblregcoll").hide();
                $("#regcollectiontermTextBox").hide();
                $("#lblregcollamt").hide();
                $("#regcollamtTextBox").hide();

                $("#lblftotalvalue").hide();
                $("#ftotalvalueTextBox").hide();
                $("#lblftradeinvalue").hide();
                $("#ftradeinvalueTextBox").hide();
                $("#ca3").hide();
                $("#lblchk3").hide();
                $("#NoPersonsTextBox").show();
                $("#lblNoPersons").show();

               
                $("#ca2").hide();
                $("#lblchk2").hide();
                //if (marketprogram == "OWNER" || marketprogram == "OWNER DOWNGRADE" || marketprogram == "Owner Downgrade" || marketprogram == "Owner") 
                if (marketprogram == "FRACTIONAL OWNER" || marketprogram == "FRACTIONAL OWNER RCI" || marketprogram == "T/S MEMBER" || marketprogram == "T/S MEMBER RCI" || marketprogram == "OWNER" || marketprogram == "RCIOWN" || marketprogram == "RCIOwn" || marketprogram == "Member"
                    || marketprogram == "MEMBER" || marketprogram == "RCIMBR" || marketprogram == "RCIMbr" || marketprogram == "MEMBER MARKETING GOA" || marketprogram == "MMG")
                {
                    $('#check').css('display', 'block');

                } else
                {
                    $('#check').css('display', 'none');

                }
            }
            else if(value=="Trade-In-Weeks"){

                // trade in week //
                $("#lbltmresort").show();
                $("#tnmresortTextBox").show();
               
                $("#lbltmapttype").show();
                $("#tnmapttypeTextBox").show();
                $("#lbltnmseason").show();
                $("#tnmseasonDropDownList").show(); 
                $("#lnltnmnowks").show();
                $("#nmnowksTextBox").show();

                $("#lbltnmcontrcino").show();
                $("#nmcontrcinoTextBox").show();
                $("#lbltipptsvalue").show();
                $("#tipptsvalueTextBox").show();
                $("#lbltipactualptsvalue").show();
                $("#tipactualptsvalueTextBox").show();

                $("#lblclub").show();
                $("#clubTextBox").show();
                $("#lblnewpts").show();
                $("#newpointsrightTextBox").show();
                $("#lblentitlement").show();
                $("#EntitlementPoinDropDownList").show();

                $("#lbltotalpoints").show();
                $("#totalptrightsTextBox").show();
                $("#lblfirstyr").show();

                $("#firstyrTextBox").show();
                $("#lbltenure").show();
                $("#tenureTextBox").show();

                $("#lbllastyr").show();
                $("#lastyrTextBox").show();
                $("#lblcontractlabel").show();
                $("#lbltwoldmtype").show();
                $("#twoldmtypeTextBox").show();
                // end//

                // fractional/////
                $("#lblfwresort").hide();
                $("#fwresortDropDownList").hide();

                $("#lblfwresidenceno").hide();
                $("#fwresidencenoDropDownList").hide();
                $("#lblfwresidencetype").hide();
                $("#fwresidencetypeDropDownList").hide();
                $("#lblfwfractInt").hide();
                $("#fwfractIntDropDownList").hide();
                $("#lblfwentitlement").hide();
                $("#fwentitlementDropDownList").hide();
                $("#lblfwfirstyr").hide();
                $("#fwfirstyrTextBox").hide();
                $("#lblfwtenure").hide();
                $("#fwtenureTextBox").hide();
                $("#lblfwlastyr").hide();
                $("#fwlastyrTextBox").hide();
                //end///
                $("#lblcontractlabel").hide();
                $("#Label70").hide();
                $("#Label111").hide();
                $("#oldcontracttypeDropDownList").hide();
                //$("#lbloldLoanAgreement").hide();
                //$("#oldLoanAgreementTextBox").hide();

                $("#lbltradeinamt").hide();
                $("#tradeinamtTextBox").hide();
                $("#lblfoldloanamount").show();
                $("#foldloanamountTextBox").show();
                $("#lblopenLoanAgreement").show();
                $("#openLoanAgreementTextBox").show();

                $("#lblregcoll").hide();
                $("#regcollectiontermTextBox").hide();
                $("#lblregcollamt").hide();
                $("#regcollamtTextBox").hide();

                $("#lblftotalvalue").hide();
                $("#ftotalvalueTextBox").hide();
                $("#lblftradeinvalue").hide();
                $("#ftradeinvalueTextBox").hide();
                $("#ca3").hide();
                $("#lblchk3").hide();
                $("#NoPersonsTextBox").show();
                $("#lblNoPersons").show();
                $("#ca2").hide();
                $("#lblchk2").hide();
                
                // if (marketprogram == "OWNER" || marketprogram == "OWNER DOWNGRADE" || marketprogram == "Owner Downgrade" || marketprogram == "Owner") 
                if (marketprogram == "FRACTIONAL OWNER" || marketprogram == "FRACTIONAL OWNER RCI" || marketprogram == "T/S MEMBER" || marketprogram == "T/S MEMBER RCI" || marketprogram == "OWNER" || marketprogram == "RCIOWN" || marketprogram == "RCIOwn" || marketprogram == "Member" || marketprogram == "MEMBER" || marketprogram == "RCIMBR" || marketprogram == "RCIMbr" || marketprogram == "MEMBER MARKETING GOA" || marketprogram == "MMG")
                {
                    $('#check').css('display', 'block');

                } else {
                    $('#check').css('display', 'none');

                }
            }
            else if (value == "Trade-In-Fractionals") {


                $("#Label111").show();
                $("#oldcontracttypeDropDownList").show();

               // var value1 = $("#oldcontracttypeDropDownList option:selected").val();
                var v = document.getElementById("oldcontracttypeDropDownList");
                var value1 = v.options[v.selectedIndex].text;
           
                if (value1 == "Points") {

                    $("#lbltmresort").show();
                    $("#tnmresortTextBox").show();
                    $("#lbltipnopoints").show();
                    $("#tipnopointsTextBox").show();
                    $("#lbltnmcontrcino").show();
                    $("#nmcontrcinoTextBox").show();
                    $("#lbltipptsvalue").show();
                    $("#tipptsvalueTextBox").show();
                    $("#lbltipactualptsvalue").hide();
                    $("#tipactualptsvalueTextBox").hide();
                    $("#lblfwresort").show();
                    $("#fwresortDropDownList").show();

                    $("#lblfwresidenceno").show();
                    $("#fwresidencenoDropDownList").show();
                    $("#lblfwresidencetype").show();
                    $("#fwresidencetypeDropDownList").show();
                    $("#lblfwfractInt").show();
                    $("#fwfractIntDropDownList").show();
                    $("#lblfwentitlement").show();
                    $("#fwentitlementDropDownList").show();
                    $("#lblfwfirstyr").show();
                    $("#fwfirstyrTextBox").show();
                    $("#lblfwtenure").show();
                    $("#fwtenureTextBox").show();
                    $("#lblfwlastyr").show();
                    $("#fwlastyrTextBox").show();

                    $("#lbltmapttype").hide();
                    $("#tnmapttypeTextBox").hide();
                    $("#lbltnmseason").hide();
                    $("#tnmseasonDropDownList").hide();
                    $("#lnltnmnowks").hide();
                    $("#nmnowksTextBox").hide();
                    $("#lbltwoldmtype").show();
                    $("#twoldmtypeTextBox").show();

                    $("#clubTextBox").hide();
                    $("#newpointsrightTextBox").hide();
                    $("#EntitlementPoinDropDownList").hide();
                    $("#totalptrightsTextBox").hide();
                    $("#firstyrTextBox").hide();
                    $("#tenureTextBox").hide();
                    $("#lastyrTextBox").hide();

                  
                } else {
                    $("#lbltmresort").show();
                    $("#tnmresortTextBox").show();

                    $("#lbltmapttype").show();
                    $("#tnmapttypeTextBox").show();
                    $("#lbltnmseason").show();
                    $("#tnmseasonDropDownList").show();
                    $("#lnltnmnowks").show();
                    $("#nmnowksTextBox").show();

                    $("#lbltnmcontrcino").show();
                    $("#nmcontrcinoTextBox").show();
                    $("#lbltipptsvalue").show();
                    $("#tipptsvalueTextBox").show();
                    $("#lbltipactualptsvalue").hide();
                    $("#tipactualptsvalueTextBox").hide();

                    $("#lblfwresort").show();
                    $("#fwresortDropDownList").show();

                    $("#lblfwresidenceno").show();
                    $("#fwresidencenoDropDownList").show();
                    $("#lblfwresidencetype").show();
                    $("#fwresidencetypeDropDownList").show();
                    $("#lblfwfractInt").show();
                    $("#fwfractIntDropDownList").show();
                    $("#lblfwentitlement").show();
                    $("#fwentitlementDropDownList").show();
                    $("#lblfwfirstyr").show();
                    $("#fwfirstyrTextBox").show();
                    $("#lblfwtenure").show();
                    $("#fwtenureTextBox").show();
                    $("#lblfwlastyr").show();
                    $("#fwlastyrTextBox").show();

                    $("#clubTextBox").hide();
                    $("#newpointsrightTextBox").hide();
                    $("#EntitlementPoinDropDownList").hide();
                    $("#totalptrightsTextBox").hide();
                    $("#firstyrTextBox").hide();
                    $("#tenureTextBox").hide();
                    $("#lastyrTextBox").hide();


                }
                $("#lblcontractlabel").hide();
                $("#Label70").show();
         

                // points///
                $("#lbllabelname").hide();
                $("#lblclub").hide();
                $("#clubTextBox").hide();
                $("#lblnewpts").hide();
                $("#newpointsrightTextBox").hide();
                $("#lblentitlement").hide();
                $("#EntitlementPoinDropDownList").hide();

                $("#lbltotalpoints").hide();
                $("#totalptrightsTextBox").hide();
                $("#lblfirstyr").hide();

                $("#firstyrTextBox").hide();
                $("#lbltenure").hide();
                $("#tenureTextBox").hide();

                $("#lbllastyr").hide();
                $("#lastyrTextBox").hide();
                //end//
                //$("#lbloldLoanAgreement").show();
                //$("#oldLoanAgreementTextBox").show();
                $("#lbltradeinamt").show();
                $("#tradeinamtTextBox").show();
                $("#lblfoldloanamount").show();
                $("#foldloanamountTextBox").show();
                $("#lblopenLoanAgreement").show();
                $("#openLoanAgreementTextBox").show();

                $("#lblregcoll").hide();// show();
                $("#regcollectiontermTextBox").hide();// show();
                $("#lblregcollamt").hide();// show();
                $("#regcollamtTextBox").hide();// show();

                $("#lblftotalvalue").show();
                $("#ftotalvalueTextBox").show();
                $("#lblftradeinvalue").show();
                $("#ftradeinvalueTextBox").show();
                $("#ca3").hide();// show();
                $("#lblchk3").hide();// show();
                $("#NoPersonsTextBox").hide();
                $("#lblNoPersons").hide();
                $("#check").hide();
                $("#mcradiobuttonlist").hide();
                $("#ca2").hide();
                $("#lblchk2").hide();
                $("#ca1").hide();
                $("#lblchk1").hide();

                $("#Label79").hide();
                $("#lblafftype").hide();
            }



        });


    </script>


   
     <script>
        $(document).ready(function () {
            var val="",val1="",val2="";
            $("#cright").click(function () {
                if ($("#ca1").is(':checked')) {
                    val = $("#ca1").val();

                }
                else {
                    val="";
                }
               // alert(val);
                if ($("#ca2").is(':checked')) {
                    val1 = $("#ca2").val();

                }
                else {
                    val1="";
                }
               // alert(val1);
                if ($("#ca3").is(':checked')) {
                    val2 = $("#ca3").val();

                } else {
                    val2="";
                }
                //alert(val2);
                var value = val + " " + val1 + " " + val2;
                var valaf;
                if (value == "  " || value == " ")
                {
                    valaf = "";
                }
                else
                {
                    valaf = value;

                }
                //alert("val:"+valaf);
           
                $("#AffiliationvalueTextBox").val(valaf);//value);
                
              
            });
          
        
        });
    </script>
  <script>
   $(document).ready(function () {
       var value = $("#currencyDropDownList option:selected").text();

       var result = "Contract Currency : " + value + "  &  " + "MC Currency:" + value;
       document.getElementById("lblfcurr").innerHTML = result;
       document.getElementById("lblfcurr").style.color = "Red";
       document.getElementById("lblfcurr").style.fontStyle = "Bold";
       document.getElementById("lblfcurr").style.fontStyle = "Italic";
       document.getElementById("lblfcurr").style.fontSize = "Medium";

       var result = "Contract Currency : " + value + "  &  " + "MC Currency:" + value;
       document.getElementById("lblfcurr2").innerHTML = result;
       document.getElementById("lblfcurr2").style.color = "Red";
       document.getElementById("lblfcurr2").style.fontStyle = "Bold";
       document.getElementById("lblfcurr2").style.fontStyle = "Italic";
       document.getElementById("lblfcurr2").style.fontSize = "Medium";

       var result = "Contract Currency : " + value + "  &  " + "MC Currency:" + value;
       document.getElementById("lblfcurr3").innerHTML = result;
       document.getElementById("lblfcurr3").style.color = "Red";
       document.getElementById("lblfcurr3").style.fontStyle = "Bold";
       document.getElementById("lblfcurr3").style.fontStyle = "Italic";
       document.getElementById("lblfcurr3").style.fontSize = "Medium";
          
                if (value == "USD")
                {
                    $("#lblforeigncurrency").show();
                    $("#foreigncurrencyTextBox").show();
                }
                else {
                   
                    $("#lblforeigncurrency").hide();
                    $("#foreigncurrencyTextBox").hide();
                }
                      
        });
    </script>
      <script>

        $(document).ready(function () {


            $("#currencyDropDownList").change(function () {
                var value = $("#currencyDropDownList").val();
                var result = "Contract Currency : " + value + "  &  " + "MC Currency:" + value;
                document.getElementById("lblfcurr").innerHTML = result;
                document.getElementById("lblfcurr").style.color = "Red";
                document.getElementById("lblfcurr").style.fontStyle = "Bold";
                document.getElementById("lblfcurr").style.fontStyle = "Italic";
                document.getElementById("lblfcurr").style.fontSize = "Medium";

                var result = "Contract Currency : " + value + "  &  " + "MC Currency:" + value;
                document.getElementById("lblfcurr2").innerHTML = result;
                document.getElementById("lblfcurr2").style.color = "Red";
                document.getElementById("lblfcurr2").style.fontStyle = "Bold";
                document.getElementById("lblfcurr2").style.fontStyle = "Italic";
                document.getElementById("lblfcurr2").style.fontSize = "Medium";

                var result = "Contract Currency : " + value + "  &  " + "MC Currency:" + value;
                document.getElementById("lblfcurr3").innerHTML = result;
                document.getElementById("lblfcurr3").style.color = "Red";
                document.getElementById("lblfcurr3").style.fontStyle = "Bold";
                document.getElementById("lblfcurr3").style.fontStyle = "Italic";
                document.getElementById("lblfcurr3").style.fontSize = "Medium";

                if (value == "USD")
                {
                    $("#lblforeigncurrency").show();
                    $("#foreigncurrencyTextBox").show();
                }
                else {
                   
                    $("#lblforeigncurrency").hide();
                    $("#foreigncurrencyTextBox").hide();
                }
                      });
        });
    </script>
     <script>
        $(document).ready(function () {
            $("#firstyrTextBox").change(function () {
                var value2 = document.getElementById("contracttypeTextBox").value;
                var club =document.getElementById("clubTextBox").value;
                var year=document.getElementById("firstyrTextBox").value;
                var v = document.getElementById("currencyDropDownList");
                var curr = v.options[v.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadManagementCharges',
                  
                    data: "{'club':'" + club + "','year':'" + year + "','curr':'" + curr + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#MCFeesTextBox").val(value1[0]);
                                $("#memberfeeTextBox").val(value1[1]);
                                $("#memcgstTextBox").val(value1[2]);
                                $("#memsgstTextBox").val(value1[3]);
                                
                                
                                
                                
                            });
                        });
                    },
                    error: function () {
                        alert("wrong output");
                    }



                });
               
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $("#fwfirstyrTextBox").change(function () {
                var value2 = document.getElementById("contracttypeTextBox").value;
                var c = document.getElementById("fwresortDropDownList");
                var club = c.options[c.selectedIndex].text;
                var year = document.getElementById("fwfirstyrTextBox").value;
                var v = document.getElementById("currencyDropDownList");
                var curr = v.options[v.selectedIndex].text;
                var v1 = document.getElementById("fwresidencetypeDropDownList");
                var type = v1.options[v1.selectedIndex].text;
                var v2 = document.getElementById("fwfractIntDropDownList");
                var wk = v2.options[v2.selectedIndex].text;
                
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/LoadManagementChargesFract',
                  
                    data: "{'club':'" + club + "','year':'" + year + "','curr':'" + curr + "','wk':'" + wk + "','type':'" + type + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                 
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#MCFeesTextBox").val(value1[0]);
                                $("#memberfeeTextBox").val(value1[1]);
                                $("#memcgstTextBox").val(value1[2]);
                                $("#memsgstTextBox").val(value1[3]);
                                
                            });
                        });
                    },
                    error: function () {
                        alert("wrong output");
                    }



                });
               
            });
        });
    </script>

    <script>

            $(document).ready(function () {
                $(document).on('click','#btn-delete',function () {
                    var row = $(this).closest("tr");
                    var receiptID = row.find("td:eq(0)").text();
                    //alert(ToManagerID);
                    var contractNO = row.find("td:eq(1)").text();
                    var receiptNO = row.find("td:eq(2)").text();
                    var confirmation = confirm("are you sure you want to delete Receipt for " + contractNO + " ?");

                    if (confirmation) {
                        $.ajax({
                            type: 'POST',
                            url: 'Indian_contracts_Edit.aspx/deleteReceipts',
                            contentType: "application/json; charset=utf-8",
                            data: "{'receiptID':'" + receiptID + "','contractNO':'" + contractNO + "','receiptNO':'" + receiptNO + "'}",
                            async: false,
                            success: function (data) {
                                //$("#TextBox5").val("");
                              

                            },
                            error: function () {
                                $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                    $("#danger-alert").slideUp(500);
                                });
                            }

                        });
                        $(this).parents("tr").remove();
                    }
                   
                    return false;
                   

                });


             

                });

         
        </script>


     <script>

            $(document).ready(function () {
                $(document).on('click','#btn-delete1',function () {
                    var row = $(this).closest("tr");
                    var sorID = row.find("td:eq(0)").text();
                    //alert(ToManagerID);
                    var contractNO = row.find("td:eq(1)").text();
                    var type = row.find("td:eq(2)").text();
                    var confirmation = confirm("are you sure you want to delete Sor/Additional Name for " + contractNO + " ?");

                    if (confirmation) {
                        $.ajax({
                            type: 'POST',
                            url: 'Indian_contracts_Edit.aspx/deleteSorAdd',
                            contentType: "application/json; charset=utf-8",
                            data: "{'sorID':'" + sorID + "','contractNO':'" + contractNO + "','type':'" + type + "'}",
                            async: false,
                            success: function (data) {
                                //$("#TextBox5").val("");
                              

                            },
                            error: function () {
                                $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                    $("#danger-alert").slideUp(500);
                                });
                            }

                        });
                        $(this).parents("tr").remove();
                    }
                   
                    return false;
                   

                });


             

                });

         
        </script>
    <script>
       
       $(document).ready(function () {
          
           $("#contractnoTextBox").blur(function () {

               var value = $("#contractnoTextBox").val();

               $.ajax({

                   type: 'post',
                   contentType: "application/json; charset=utf-8",
                   url: 'Indian_contracts_Edit.aspx/ContractnoExists',

                   data: "{'contractno':'" + value + "'}",
                   async: false,
                   success: function (data) {

                       subJson = JSON.parse(data.d);

                       //alert(subJson);
                       $.each(subJson, function (key, value) {
                           $.each(value, function (index1, value1) {
                              
                               if(value1[0]=="1"){
                                   $("#contractnoTextBox").css({

                                       "border": "1px solid red",

                                       "background": "#FFCECE"
                                      
                                   });
                                   alert("Contract Number Already Exists!!");
                               }else{


                       }
                           });
                       });
                   },
                   error: function () {
                       alert("wrong output");
                   }



               });


           });


               });
    </script>

   <script>
        $(document).ready(function () {
          
            
            var value1 = $("#MarketingProgramDropDownList option:selected").text();
                
                if (value1 == "GUEST OF FRACTIONAL OWNER") {
                   
                    $("#divref").show();

                 

                }
                else if (value1 == "GUEST OF T/S MEMBER")
                {
                    $("#divref").show();

                     
                }
                else if (value1 == "MEMBER AMBASSADOR") {
                    $("#divref").show();

                   
                     
                }
                else if (value1 == "RCI GUEST") {
                    $("#divref").show();

                   
                }
                
                else
                {
                    $("#divref").hide();
                  

                }
                
                 
           


        }); 



    </script>
     <script>

        $(document).ready(function () {
          
            var venueGroup = $("#GroupVenueDropDownList option:selected").text();
            var venue = $("#VenueDropDownList option:selected").text();
            if (venueGroup == "Inhouse" || venueGroup == "INHOUSE")
            {
                $("#Label126").show();
                $("#SubVenueDropDownList").show();
                if (venue == "South Goa" || venue == "SOUTH GOA")
                {

                    $("#Label159").show();
                    $("#SubVenueGroupDropDownList").show();
                }
                else
                {
                    
                        $("#Label159").hide();
                        $("#SubVenueGroupDropDownList").hide();
                        $("#SubVenueGroupDropDownList").val('');
                     
                }

            $("#Label127").hide();
            $("#LeadOfficeDropDownList").hide();

            }
            else if (venueGroup == "FlyBuy" || venueGroup == "FLYBUY" || venueGroup == "CallCenter" || venueGroup == "CALLCENTER") {

                $("#Label126").show();
                $("#SubVenueDropDownList").show();

                $("#Label159").hide();
                $("#SubVenueGroupDropDownList").hide();

                $("#Label127").show();
                $("#LeadOfficeDropDownList").show();
            } else {
                $("#Label126").hide();
                $("#SubVenueDropDownList").hide();

                $("#Label159").hide();
                $("#SubVenueGroupDropDownList").hide();

                $("#Label127").hide();
                $("#LeadOfficeDropDownList").hide();

            }


        });
    </script>

     <script>
        $(document).ready(function () {
          
            //   var value1 = document.getElementById("MarketingProgramDropDownList");
            var value1 = $("#MarketingProgramDropDownList option:selected").text();
                if (value1 == "GUEST OF FRACTIONAL OWNER") {
                   
                    $("#divref").show();

                    

                }
                else if (value1 == "GUEST OF T/S MEMBER")
                {
                    $("#divref").show();

                   
                     
                }
                else if (value1 == "MEMBER AMBASSADOR") {
                    $("#divref").show();

                   
                     
                }              
                
                else
                {
                    $("#divref").hide();
                 

                }
                
                 
           


        }); 



    </script>
     <script>
         //balnce due
        $(document).ready(function () {
          
            // var value1 = document.getElementById("baldepamtTextBox");
            var value1 = $("#baldepamtTextBox").val();
                if (value1 == ""||value1=="0") {
                   
                    $("#lblbaladepamt").hide();
                    $("#baldepamtTextBox").hide();
                    $("#lblbaladepamtdate").hide();
                    $("#baladepamtdateTextBox").hide();
                 
                }
            else 
                {
                    $("#lblbaladepamt").show();
                    $("#baldepamtTextBox").show();
                    $("#lblbaladepamtdate").show();
                    $("#baladepamtdateTextBox").show();
                }
                
                 
           


        }); 



    </script>

    <script>

        $(document).ready(function () {
            $(document).on('click', '#btn-edit', function () {

                $("#Button9").show();
                $("#ReceiptNumber").show();
                $("#TextBox2").show();
                var curr = $("#currencyDropDownList option:selected").text();
                var row = $(this).closest("tr");
                var ID = row.find("td:eq(0)").text();
                if (curr == "INR") {


                    var totalAmt = row.find("td:eq(5)").text();
                    var mode = row.find("td:eq(6)").text();
                    var receiptType = row.find("td:eq(7)").text();
                    var receiptNo = row.find("td:eq(2)").text();
                    var previousamt = row.find("td:eq(12)").text();
                    var forcuur = row.find("td:eq(10)").text();

                    //     alert(receiptNo);
                    // alert(ID);
                  //  alert(previousamt);

                    $("#TextBox1").val(ID);
                    $("#ReceiptamtTextBox").val(totalAmt);
                    $("#TextBox2").val(receiptNo);
                    $("#depositmethodaddDropDownList option[value='" + mode + "']").prop('selected', true);
                    $("#receipttypeDropDownList option[value='" + receiptType + "']").prop('selected', true);
                    $("#oldcanxamtTextBox").val(previousamt);
                }
                else
                {
                    var totalAmt = row.find("td:eq(11)").text();
                    var mode = row.find("td:eq(6)").text();
                    var receiptType = row.find("td:eq(7)").text();
                    var receiptNo = row.find("td:eq(2)").text();
                    var previousamt = row.find("td:eq(12)").text();
                    var forcuur = row.find("td:eq(10)").text();

                    //     alert(receiptNo);
                    // alert(ID);
                  //  alert(previousamt);

                    $("#TextBox1").val(ID);
                    $("#ReceiptamtTextBox").val(totalAmt);
                    $("#TextBox2").val(receiptNo);
                    $("#depositmethodaddDropDownList option[value='" + mode + "']").prop('selected', true);
                    $("#receipttypeDropDownList option[value='" + receiptType + "']").prop('selected', true);
                    $("#oldcanxamtTextBox").val(previousamt);
                    $("#foreigncurrencyTextBox").val(forcuur);
                }

            });

        });
    </script>

    <script>

        $(document).ready(function () {
            $("#Button9").click(function () {
                var receiptID = $("#TextBox1").val();
                var curr = $("#currencyDropDownList option:selected").text();
               
                var depositMethod = $("#depositmethodaddDropDownList").val();
                if (depositMethod == "" || depositMethod == null) {
                    depositMethod = "";
                } else {
                    depositMethod = $("#depositmethodaddDropDownList").val();
                }

                var type = $("#receipttypeDropDownList").val();
                if (type == "" || type == null) {
                    type = "";
                } else {
                    type = $("#receipttypeDropDownList").val();
                }

                var amount = $("#ReceiptamtTextBox").val();
                if (amount == "" || amount == null) {
                    amount = "";
                } else {
                    amount = $("#ReceiptamtTextBox").val();
                }

                var receiptNum = $("#TextBox2").val();
                if (receiptNum == "" || receiptNum == null) {
                    receiptNum = "";
                } else {
                    receiptNum = $("#TextBox2").val();
                }
                var oldcanxamt = $("#oldcanxamtTextBox").val();
                if (oldcanxamt == "" || oldcanxamt == null) {
                    oldcanxamt = "";
                } else {
                    oldcanxamt = $("#oldcanxamtTextBox").val();
                }
                var foreigncurr = $("#foreigncurrencyTextBox").val();
                if (foreigncurr == "" || foreigncurr == null) {
                    foreigncurr = "";
                } else {
                    foreigncurr = $("#foreigncurrencyTextBox").val();
                }
                //alert(receiptID); alert(curr);
                //alert(depositMethod); alert(type);
                //alert(amount); alert(receiptNum);
                //alert(oldcanxamt); alert(foreigncurr);
                $.ajax({
                    type: 'POST',
                    url: 'Indian_contracts_Edit.aspx/updateReceipt',
                    contentType: "application/json; charset=utf-8",
                    data: "{'receiptID':'" + receiptID + "','depositMethod':'" + depositMethod + "','type':'" + type + "','amount':'" + amount + "','receiptNum':'" + receiptNum + "','oldcanxamt':'" + oldcanxamt + "','curr':'" + curr + "','foreigncurr':'" + foreigncurr + "'  }",
                    async: false,
                    success: function (data) {
                        $("#TextBox1").val("");
                        $("#TextBox2").val("");
                        $("#depositmethodaddDropDownList").val('');
                        $("#receipttypeDropDownList").val('');
                        $("#ReceiptamtTextBox").val("");
                        $("#oldcanxamtTextBox").val("");
                        window.location.reload();
                    },
                    error: function () {
                        $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                            $("#danger-alert").slideUp(500);
                        });
                    }

                });


            });


        });


    </script>

    <script>
   $(document).ready(function () {
             var value = document.getElementById("CanxContractNoTextBox").value;
          
                if (value == "")
                {
                    $("#lbloldcanxamt").hide();
                    $("#oldcanxamtTextBox").hide();
                }
                else {
                   
                    $("#lbloldcanxamt").show();
                    $("#oldcanxamtTextBox").show();
                }
                      
        });
    </script>
      <script>

        $(document).ready(function () {


             $("#CanxContractNoTextBox").change(function () {
                var value = document.getElementById("CanxContractNoTextBox").value;
                 if (value == "")
                {
                    $("#lbloldcanxamt").hide();
                    $("#oldcanxamtTextBox").hide();
                }
                else {
                   
                    $("#lbloldcanxamt").show();
                    $("#oldcanxamtTextBox").show();
                }
                      });
        });
    </script>
    <script>

        $(document).ready(function () {
            $('#coraddCheckBox').on('click', function () {
                if ($('#coraddCheckBox').is(':checked')) {
                 
                    var address1= $("#address1TextBox").val();
                    var address2 = $("#address2TextBox").val();
                    var addCountry = $("#AddCountryDropDownList option:selected").text();
                    var addState = $("#StateDropDownList option:selected").text();
                    var addCity = $("#cityTextBox").val();
                    var addPincode = $("#pincodeTextBox").val();

                    $('#cadd1TextBox').css('pointer-events', 'none');
                    $('#cadd2TextBox').css('pointer-events', 'none');
                    $('#ccountryDropDownList').css('pointer-events', 'none');
                    $('#cstateDropDownList').css('pointer-events', 'none');
                    $('#ccityTextBox').css('pointer-events', 'none');
                    $('#cpincodeTextBox').css('pointer-events', 'none');

                    $("#cadd1TextBox").val(address1);
                    $("#cadd2TextBox").val(address2);
                    $("#ccountryDropDownList").empty();
                    $("#ccountryDropDownList").append("<option value='" + addCountry + "'>" + addCountry + "</option>")
                    $("#cstateDropDownList").empty();
                    $("#cstateDropDownList").append("<option value='" + addState + "'>" + addState + "</option>")
                    $("#ccityTextBox").val(addCity);
                    $("#cpincodeTextBox").val(addPincode);
                } else {

                    $('#cadd1TextBox').css('pointer-events', 'auto');
                    $('#cadd2TextBox').css('pointer-events', 'auto');
                    $('#ccountryDropDownList').css('pointer-events', 'auto');
                    $('#cstateDropDownList').css('pointer-events', 'auto');
                    $('#ccityTextBox').css('pointer-events', 'auto');
                    $('#cpincodeTextBox').css('pointer-events', 'auto');

                    $("#cadd1TextBox").val("");
                    $("#cadd2TextBox").val("");

                    $.ajax({

                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        url: 'Indian_contracts_Edit.aspx/LoadCoressCountry',
                        data: "{}",
                        async: false,
                        success: function (data) {
                            // alert(data.d);
                            $("#ccountryDropDownList").empty();
                            $("#ccountryDropDownList").append("<option disabled selected value>select an option  </option>")
                            subJson = JSON.parse(data.d);

                            // alert(subJson);
                            $.each(subJson, function (key, value) {
                                $.each(value, function (index1, value1) {

                                    $("#ccountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                });
                            });
                        },
                        error: function () {
                            alert("wrong LoadCoressCountry");
                        }



                    });
                 
                    $("#cstateDropDownList").empty();
                    $("#ccityTextBox").val("");
                    $("#cpincodeTextBox").val("");

                 

                }

            });
         
        });


    </script>

     <script>

        $(document).ready(function () {


            $("#financemethodDropDownList").change(function ()
            {
                var value = $("#currencyDropDownList option:selected").text();
          
               
                var value1 = $("#financemethodDropDownList").val();
            
                if (value1 == "Pashuram Finance") {
                    $("#lblfinanceno").hide();//.show();
                    $("#FinancenoTextBox").hide();//.show();
                    $("#lblfinmonth").show();
                    $("#finmonthTextBox").show();
                    $("#lblinterestrate").show();
                    $("#interestrateTextBox").show();
                    $("#lblisgtrate").show();
                    $("#isgtrateTextBox").show();
                    $("#lbligstamt").show();
                    $("#igstamtTextBox").show();
                    $("#lblfindocfee").show();
                    $("#lblfindocfee").text("DOCUMENTATION FEE");
                    $("#findocfeeTextBox").show();
                    $("#lblnoemi").show();
                    $("#noemiTextBox").show();
                    $("#lblemiamt").show();
                    $("#emiamtTextBox").show();
                    $("#lbleurorate").hide();
                    $("#eurorateTextBox").hide();
                    $("#lblloanamtINEuro").hide();
                    $("#loanamtINEuroTextBox").hide();
                }
                else if (value1 == "Crown Finance")
                {
                     
                    $("#lblfinanceno").hide();
                    $("#FinancenoTextBox").hide();
                    $("#lblfinmonth").show();
                    $("#finmonthTextBox").show();
                    $("#lblinterestrate").hide();
                    $("#interestrateTextBox").hide();
                    $("#lblisgtrate").hide();
                    $("#isgtrateTextBox").hide();
                    $("#lbligstamt").hide();
                    $("#igstamtTextBox").hide();
                    $("#lblfindocfee").show();
                    $("#lblfindocfee").text("ACCEPTANCE FEE");
                    $("#findocfeeTextBox").show();
                    $("#lblnoemi").show();
                    $("#noemiTextBox").show();
                    $("#lblemiamt").show();
                    $("#emiamtTextBox").show();
                    $("#lbleurorate").hide();
                    $("#eurorateTextBox").hide();
                    $("#lblloanamtINEuro").show();
                    $("#loanamtINEuroTextBox").show();
                    
                   

                }
 
                      });
        });
    </script>
    <script>
        $(document).ready(function () {
            $("#contractgroupDropDownList").change(function () {
                var cv = document.getElementById("contractgroupDropDownList");
                var cvenue = cv.options[cv.selectedIndex].text;
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;
                // alert(countryName)
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/GetContractVenue',
                    data: "{'cvenue':'" + cvenue + "','venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#contractvenueDropDownList").empty();
                        $("#contractvenueDropDownList").append("<option disabled selected value>select an option  </option>")


                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#contractvenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });
        });
        
    </script>
  
    <script>


        $(document).ready(function () {

            $("input[name='acceptance0'],input[name='acceptance1'],input[name='acceptance2'],input[name='acceptance3'],input[name='acceptance4'],input[name='acceptance5'],input[name='acceptance6'],input[name='acceptance7'],input[name='acceptance8'],input[name='acceptance9'],input[name='acceptance10'],input[name='acceptance11'],input[name='acceptance12'],input[name='acceptance13'],input[name='acceptance14'],input[name='acceptance15'],input[name='acceptance16'],input[name='acceptance17'],input[name='acceptance18'],input[name='acceptance19'],input[name='acceptance20']").change(function () {
                var identity = "acceptance";
                var Val = "";
                var row = $(this).closest("tr");
                var id = row.find("td:eq(0)").text();
                var contractNo = row.find("td:eq(1)").text();
                //alert(contractNo);
                if ($(this).is(":checked")) {
                    Val = $(this).val();
                }

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/updateSor_Add',
                    data: "{'Val':'" + Val + "','id':'" + id + "','contractNo':'" + contractNo + "','identity':'" + identity + "'}",
                    async: false,
                    success: function (data) {


                    },
                    error: function () {
                        alert("wrong acceptance");
                    }



                });

            });


            $("input[name='enrollment0'],input[name='enrollment1'],input[name='enrollment2'],input[name='enrollment3'],input[name='enrollment4'],input[name='enrollment5'],input[name='enrollment6'],input[name='enrollment7'],input[name='enrollment8'],input[name='enrollment9'],input[name='enrollment10'],input[name='enrollment11'],input[name='enrollment12'],input[name='enrollment13'],input[name='enrollment14'],input[name='enrollment15'],input[name='enrollment16'],input[name='enrollment17'],input[name='enrollment18'],input[name='enrollment19'],input[name='enrollment20']").change(function () {
                var identity = "enrollment";
                var Val = "";
                var row = $(this).closest("tr");
                var id = row.find("td:eq(0)").text();
                var contractNo = row.find("td:eq(1)").text();
                //alert(contractNo);
                if ($(this).is(":checked")) {
                    Val = $(this).val();
                }

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/updateSor_Add',
                    data: "{'Val':'" + Val + "','id':'" + id + "','contractNo':'" + contractNo + "','identity':'" + identity + "'}",
                    async: false,
                    success: function (data) {


                    },
                    error: function () {
                        alert("wrong enrollment");
                    }



                });

            });

            $("input[name='documentStatus0'],input[name='documentStatus1'],input[name='documentStatus2'],input[name='documentStatus3'],input[name='documentStatus4'],input[name='documentStatus5'],input[name='documentStatus6'],input[name='documentStatus7'],input[name='documentStatus8'],input[name='documentStatus9'],input[name='documentStatus10'],input[name='documentStatus11'],input[name='documentStatus12'],input[name='documentStatus13'],input[name='documentStatus14'],input[name='documentStatus15'],input[name='documentStatus16'],input[name='documentStatus17'],input[name='documentStatus18'],input[name='documentStatus19'],input[name='documentStatus20']").change(function () {
                var identity = "documentStatus";
                var Val = "";
                var row = $(this).closest("tr");
                var id = row.find("td:eq(0)").text();
                var contractNo = row.find("td:eq(1)").text();
                //alert(contractNo);
                if ($(this).is(":checked")) {
                    Val = $(this).val();
                }

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts_Edit.aspx/updateSor_Add',
                    data: "{'Val':'" + Val + "','id':'" + id + "','contractNo':'" + contractNo + "','identity':'" + identity + "'}",
                    async: false,
                    success: function (data) {


                    },
                    error: function () {
                        alert("wrong document status");
                    }



                });

            });

        });

    </script>
   
</body>

</html>
