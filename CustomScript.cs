function Validate(type)
{
    var returnVal = true;
    var dateExpression = /^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$/;
     var timeExpression1 = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/;
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    //var letters = /^[a-zA-Z_ \n]*$/;
    var numericexpression = /^\d+$/;
    var timeExpression = /^(0?[1-9]|1[012])(:[0-5]\d) [APap][mM]$/
    var freq_interval = 0;
    var NamewithspaceRegular = /^[a-zA-Z0-9_ \-#()]*$/;
    
    var letters = /^[a-zA-Z \n]*$/;

    if (type == 'Task')
    {
        if ($("#ddlpriority option:selected").text() == "Please choose..") {
            $("#divpriority").addClass("ErrorFocus");

            returnVal = false;
        }
        else {
            $("#divpriority").removeClass("ErrorFocus");
        }

        if ($("#txttaskname").val() == "") {
            $("#divtaskName").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divtaskName").removeClass("ErrorFocus");
            
        }

        if ($("#txtservername").val() == "") {
            $("#divServername").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divServername").removeClass("ErrorFocus");

        }
        if ($("#ddlteam option:selected").text() == "Please choose..") {
            $("#divddlteam").addClass("ErrorFocus");

            returnVal = false;
        }
        else {
            $("#divddlteam").removeClass("ErrorFocus");
        }
        
    }


   else if (type == 'Shiftdetails')
    {
        if ($("#ddlMonths option:selected").text() == "Please choose..") {
            $("#divMonths").addClass("ErrorFocus");

            returnVal = false;
        }
        else {
            $("#divMonths").removeClass("ErrorFocus");
        }
        if ($("#ddlYears option:selected").text() == "Please choose..") {
            $("#divYears").addClass("ErrorFocus");

            returnVal = false;
        }
        else {
            $("#divYears").removeClass("ErrorFocus");
        }
    }
    else if (type == 'HierarchyInsertvalidate') {
        if ($("#txthierarchy").val() == "") {
            $("#divHierarchy").addClass("ErrorFocus");

            returnVal = false;
        }
        else {
            $("#divHierarchy").removeClass("ErrorFocus");
        }
        
    }
    else if (type == 'Update')
    {
       

        var NewShiftType = $("#ddlshifttype option:selected").val();
        if(NewShiftType==2)
        {
            var date = $("#txtdate").val();
            if (date == "")
            {
                $("#divdate").addClass("ErrorFocus");

                returnVal = false;
            }
            else
            {
                if (!$("#txtdate").val().match(dateExpression)) {
                    $("#divdate").addClass("ErrorFocus");
                    $("#txtdate").focus();
                    alert("Date format Should be YYYY-MM-DD")
                    returnVal = false;
                }
                else {
                    $("#divdate").removeClass("ErrorFocus");
                }
            }
            var time = $("#txttime").val();
            if (time == "") {
                $("#divtime").addClass("ErrorFocus");

                returnVal = false;
            }
            else
            {
                if (!$("#txttime").val().match(timeExpression1))
                {
                    $("#divtime").addClass("ErrorFocus");
                    $("#txttime").focus();
                    alert("Time format Should be HH:MM")
                    returnVal = false;
                }
                else
                {
                    $("#divtime").removeClass("ErrorFocus");
                }
            }
           
        }
        else
        {
            var date = $("#txtdate").val();
            if (date == "")
            {
                $("#divdate").addClass("ErrorFocus");

                returnVal = false;
            }
            else
            {


                if (!$("#txtdate").val().match(dateExpression)) {
                    $("#divdate").addClass("ErrorFocus");
                    $("#txtdate").focus();
                    alert("Date format Should be YYYY-MM-DD")
                    returnVal = false;
                }
                else {
                    $("#divdate").removeClass("ErrorFocus");
                }

            }

        }

    }
    
    else if (type == 'EmployeeReg')
    {
        var firstname = $("#txtfirstname").val();
        var middlename = $("#txtmiddlename").val();
        var lastname = $("#txtlastname").val();
        var excelname = $("#txtexcelname").val();
        if ($("#txtfirstname").val() == "")
        {
            $("#divfirstname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {

            if (!$("#txtfirstname").val().match(letters)) {
                $("#divfirstname").addClass("ErrorFocus");
                $("#txtfirstname").focus();
                $("#pvalidateMessage").text("* Only Alphabets are allowed");
                returnVal = false;
            }
            else {
                $("#divfirstname").removeClass("ErrorFocus");
            }
           // $("#divfirstname").removeClass("ErrorFocus");
        }
        if (!$("#txtmiddlename").val().match(letters)) {
            $("#divmiddlename").addClass("ErrorFocus");
            $("#txtmiddlename").focus();
            $("#pvalidateMessage").text("* Only Alphabets are allowed");
            returnVal = false;
        }
        else {
            $("#divmiddlename").removeClass("ErrorFocus");
        }

        if (!$("#txtexcelname").val().match(letters)) {
            $("#divexcelname").addClass("ErrorFocus");
            $("#txtexcelname").focus();
            $("#pvalidateMessage").text("* Only Alphabets are allowed");
            returnVal = false;
        }
        else {
            $("#divexcelname").removeClass("ErrorFocus");
        }
        if ($("#txtlastname").val() == "")
        {
            $("#divlastname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            if (!$("#txtlastname").val().match(letters)) {
                $("#divlastname").addClass("ErrorFocus");
                $("#txtlastname").focus();
                $("#pvalidateMessage").text("* Only Alphabets are allowed");
                returnVal = false;
            }
            else {
                $("#divlastname").removeClass("ErrorFocus");
            }
        }
       
        
        if ($("#txtPassword").val().trim() == '') {
            $("#divPassword").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divPassword").removeClass("ErrorFocus");
        }

        if ($("#txtReTypePassword").val().trim() == '') {
            $("#divReTypePassword").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divReTypePassword").removeClass("ErrorFocus");
        }

        if ($("#txtReTypePassword").val().trim() != '') {

            if ($("#txtPassword").val() != $("#txtReTypePassword").val()) {
                $("#divPassword").addClass("ErrorFocus");
                $("#divReTypePassword").addClass("ErrorFocus");
                $('#pvalidateMessage').text("* Password doesn't match");
                $('#txtPassword').val('');
                $('#txtReTypePassword').val('');
                returnVal = false;
            }
            else {
                $("#divPassword").removeClass("ErrorFocus");
                $("#divReTypePassword").removeClass("ErrorFocus");
            }
        }

        if ($("#txtEmailId").val().trim() == '') {
            $("#divEmailId").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divEmailId").removeClass("ErrorFocus");
        }

        if ($("#txtEmailId").val().trim() != '') {
            if (!filter.test($("#txtEmailId").val())) {
                $("#divEmailId").addClass("ErrorFocus");
                $('#pvalidateMessage').text("* Invalid Email Id");
                returnVal = false;

            }
            else {
                $("#divEmailId").removeClass("ErrorFocus");
            }
        }




    }
    else if (type == 'EmployeeUpdate') {
        var firstname = $("#txtfirstname").val();
        var middlename = $("#txtmiddlename").val();
        var lastname = $("#txtlastname").val();
        var excelname = $("#txtexcelname").val();
        if ($("#txtfirstname").val() == "") {
            $("#divfirstname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {

            if (!$("#txtfirstname").val().match(letters)) {
                $("#divfirstname").addClass("ErrorFocus");
                $("#txtfirstname").focus();
                $("#pvalidateMessage").text("* Only Alphabets are allowed");
                returnVal = false;
            }
            else {
                $("#divfirstname").removeClass("ErrorFocus");
            }
            // $("#divfirstname").removeClass("ErrorFocus");
        }
        if (!$("#txtmiddlename").val().match(letters)) {
            $("#divmiddlename").addClass("ErrorFocus");
            $("#txtmiddlename").focus();
            $("#pvalidateMessage").text("* Only Alphabets are allowed");
            returnVal = false;
        }
        else {
            $("#divmiddlename").removeClass("ErrorFocus");
        }
        if (!$("#txtexcelname").val().match(letters)) {
            $("#divexcelname").addClass("ErrorFocus");
            $("#txtexcelname").focus();
            $("#pvalidateMessage").text("* Only Alphabets are allowed");
            returnVal = false;
        }
        else {
            $("#divexcelname").removeClass("ErrorFocus");
        }

        if ($("#txtlastname").val() == "") {
            $("#divlastname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            if (!$("#txtlastname").val().match(letters)) {
                $("#divlastname").addClass("ErrorFocus");
                $("#txtlastname").focus();
                $("#pvalidateMessage").text("* Only Alphabets are allowed");
                returnVal = false;
            }
            else {
                $("#divlastname").removeClass("ErrorFocus");
            }
        }
    }
    else if (type == 'ChangePassword')
    {
        var oldpassword = $("#txtOldPassword").val();
        var Newpassword = $("#txtNewPassword").val();
        var Confirmpassword = $("#txtConfirmPassword").val();
        if ($("#txtOldPassword").val() == "") {
            $('#lblMessageChangePwd').removeClass("lblMessage");
            $('#lblMessageChangePwd').addClass("lblError");
            $("#divOldpassword").addClass("ErrorFocus");
            $("#lblMessageChangePwd").text("* Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#divOldpassword").removeClass("ErrorFocus");
        if ($("#txtNewPassword").val() == "") {
            $('#lblMessageChangePwd').removeClass("lblMessage");
            $('#lblMessageChangePwd').addClass("lblError");
            $("#divNewpassword").addClass("ErrorFocus");
            $("#lblMessageChangePwd").text("* Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#divNewpassword").removeClass("ErrorFocus");
        if ($("#txtConfirmPassword").val() == "") {
            $('#lblMessageChangePwd').removeClass("lblMessage");
            $('#lblMessageChangePwd').addClass("lblError");
            $("#divConfirmpassword").addClass("ErrorFocus");
            $("#lblMessageChangePwd").text("* Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#divConfirmpassword").removeClass("ErrorFocus");

    }
    else if (type == 'taskscheduleweekly') {
        var checkBoxvalue = $('#chkActive').is(':checked');
        var checkkActivevalue = checkBoxvalue ? 1 : 0;
        if (checkkActivevalue == 0) {
            if ($("#dtEndDate").val() == "") {
                $("#divEndDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else
                $("#divEndDate").removeClass("ErrorFocus");

            if ($("#dtStartDate").val() == "") {
                $("#divStartDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else
                $("#divStartDate").removeClass("ErrorFocus");


            if ($("#dtStartDate").val() != "" && $("#dtEndDate").val() != "") {
                var arrDate1 = $('#dtStartDate').val().split("/");
                var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
                var arrDate2 = $('#dtEndDate').val().split("/");
                var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
                if (useDate1 > useDate2) {
                    $("#lblerror").text("The End Date must be greater than the Start Date");

                    $("#divEndDate").addClass("ErrorFocus");
                    returnVal = false;
                }
                else {
                    $("#lblerror").text('');

                    $("#divEndDate").removeClass("ErrorFocus");
                }
            }

        }
        else {
            $("#divEndDate").removeClass("ErrorFocus");
            if ($("#dtStartDate").val() == "") {
                $("#divStartDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else
                $("#divStartDate").removeClass("ErrorFocus");

        }

        if ($("#radioocurevery").prop("checked")) {
            var NumberEveryvalue = $("#txtevery").val();
            if ($("#txtevery").val() == "") {
                $("#divevery").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!NumberEveryvalue.match(numericexpression)) {
                    $("#divevery").addClass("ErrorFocus");
                    $("#txtevery").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 100");
                    returnVal = false;
                }
                else if (NumberEveryvalue > 100 || NumberEveryvalue <= 0) {
                    $("#divevery").addClass("ErrorFocus");
                    $("#txtevery").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 100");
                    returnVal = false;
                }
                else {

                    $("#divevery").removeClass("ErrorFocus");

                }
            }

            var TextstartTime = $("#txtstartime").val();
            if ($("#txtstartime").val() == "") {
                $("#divtstartime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                // if (!TextstartTime.match(timeExpression)) {
                //   $("#txtstartime").focus();
                // $("#divtstartime").addClass("ErrorFocus");
                //$('#lblerror').text("* Time should be valid with format HH:MM (AM|PM)");
                // returnVal = false;
                //  }
                // else {
                $("#divtstartime").removeClass("ErrorFocus");

                //}
            }
            var TextendTime = $("#txtendtime").val();
            if ($("#txtendtime").val() == "") {
                $("#divtendtime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                // if (!TextendTime.match(timeExpression)) {
                // $("#txtendtime").focus();
                // $("#divtendtime").addClass("ErrorFocus");
                //$('#lblerror').text("* Time should be valid with format HH:MM (AM|PM)");
                //returnVal = false;
                //}
                //else {
                $("#divtendtime").removeClass("ErrorFocus");

                // }
            }
            if ($("#txtstartime").val() != "" && $("#txtendtime").val() != "") {
                var newTexttime = $("#txtstartime").val();
                var newendTexttime = $("#txtendtime").val();
                if (newTexttime == newendTexttime) {
                    $("#txtendtime").focus();
                    $("#lblerror").text("* The job schedule ending time must be after the starting time");
                    $("#divtendtime").addClass("ErrorFocus");
                    returnVal = false;
                }
                else {

                }
            }


        }
        var length = $('[name="cbox[]"]:checked').length;
        if (length == 0) {
            $('#lblerror').text(" A weekly frequency requires you to select at least one weekday");
            returnVal = false;

        }
        if ($("#radioocursonce").prop("checked")) {
            var TextOccursstartTime = $("#txttime").val();
            if ($("#txttime").val() == "") {
                $("#divtime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {

                $("#divtime").removeClass("ErrorFocus");

            }

        }
        //var NumberEvery = $("#txtrecurs").val();
        //if ($("#txtrecurs").val() == "") {
        //    $("#divrecurs").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else {
        //    if (!NumberEvery.match(numericexpression)) {
        //        $("#divrecurs").addClass("ErrorFocus");
        //        $("#txtrecurs").focus();
        //        $('#lblerror').text("* Only numeric values are allowed between 1 and 100");
        //        returnVal = false;
        //    }
        //    else if (NumberEvery > 100 || NumberEvery <= 0) {
        //        $("#divrecurs").addClass("ErrorFocus");
        //        $('#lblerror').text("* Only numeric values are allowed between 1 and 100");
        //        returnVal = false;
        //    }
        //    else {

        //        $("#divrecurs").removeClass("ErrorFocus");

        //    }
        //}


        if ($("#ddlTask option:selected").text() == "please choose...") {
            $("#divpname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divpname").removeClass("ErrorFocus");
        }
    }
    else if (type == 'taskschedulemonthly') {
        var checkBoxvalue = $('#chkActive').is(':checked');
        var checkkActivevalue = checkBoxvalue ? 1 : 0;
        if (checkkActivevalue == 0) {
            if ($("#dtEndDate").val() == "") {
                $("#divEndDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else
                $("#divEndDate").removeClass("ErrorFocus");

            if ($("#dtStartDate").val() == "") {
                $("#divStartDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else
                $("#divStartDate").removeClass("ErrorFocus");


            if ($("#dtStartDate").val() != "" && $("#dtEndDate").val() != "") {
                var arrDate1 = $('#dtStartDate').val().split("/");
                var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
                var arrDate2 = $('#dtEndDate').val().split("/");
                var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
                if (useDate1 > useDate2) {
                    $("#lblerror").text(" The End Date must be greater than the Start Date");

                    $("#divEndDate").addClass("ErrorFocus");
                    returnVal = false;
                }
                else {
                    $("#lblerror").text('');

                    $("#divEndDate").removeClass("ErrorFocus");
                }
            }

        }
        else {
            $("#divEndDate").removeClass("ErrorFocus");
            if ($("#dtStartDate").val() == "") {
                $("#divStartDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else
                $("#divStartDate").removeClass("ErrorFocus");

        }

        if ($("#radioocurevery").prop("checked")) {
            var NumberEveryvalue = $("#txtevery").val();
            if ($("#txtevery").val() == "") {
                $("#divevery").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!NumberEveryvalue.match(numericexpression)) {
                    $("#divevery").addClass("ErrorFocus");
                    $("#txtevery").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 100");
                    returnVal = false;
                }
                else if (NumberEveryvalue > 100 || NumberEveryvalue <= 0) {
                    $("#divevery").addClass("ErrorFocus");
                    $("#txtevery").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 100");
                    returnVal = false;
                }
                else {

                    $("#divevery").removeClass("ErrorFocus");

                }
            }

            var TextstartTime = $("#txtstartime").val();
            if ($("#txtstartime").val() == "") {
                $("#divtstartime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                //if (!TextstartTime.match(timeExpression)) {
                //    $("#txtstartime").focus();
                //    $("#divtstartime").addClass("ErrorFocus");
                //    $('#lblerror').text("* Time should be valid with format HH:MM (AM|PM)");
                //    returnVal = false;
                //}
                //else {
                    $("#divtstartime").removeClass("ErrorFocus");

               // }
            }
            var TextendTime = $("#txtendtime").val();
            if ($("#txtendtime").val() == "") {
                $("#divtendtime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                //if (!TextendTime.match(timeExpression)) {
                //    $("#txtendtime").focus();
                //    $("#divtendtime").addClass("ErrorFocus");
                //    $('#lblerror').text("* Time should be valid with format HH:MM (AM|PM)");
                //    returnVal = false;
                //}
                //else {
                    $("#divtendtime").removeClass("ErrorFocus");

                //}
            }
            if ($("#txtstartime").val() != "" && $("#txtendtime").val() != "") {
                var newTexttime = $("#txtstartime").val();
                var newendTexttime = $("#txtendtime").val();
                if (newTexttime == newendTexttime) {
                    $("#txtendtime").focus();
                    $("#lblerror").text("* The job schedule ending time must be after the starting time");
                    $("#divtendtime").addClass("ErrorFocus");
                    returnVal = false;
                }
                else {

                    //$("#divtendtime").removeClass("ErrorFocus");

                }
            }


        }
        //if ($("#radioocursonce").prop("checked")) {
           var TextOccursstartTime = $("#txttime").val();
           if ($("#txttime").val() == "") {
               $("#divtime").addClass("ErrorFocus");
               returnVal = false;
           }
           else {
        //        if (!TextOccursstartTime.match(timeExpression)) {
        //            $("#divtime").addClass("ErrorFocus");
        //            $("#txttime").focus();
        //            $('#lblerror').text("* Time should be valid with format HH:MM (AM|PM)");
        //            returnVal = false;
        //        }
        //        else {
                  $("#divtime").removeClass("ErrorFocus");

                }
        //    }
        //    // $("#divtime").removeClass("ErrorFocus");
        //}



        //
        if ($("#radioday").prop("checked")) {
            var NumberDayEveryvalue = $("#txtdayevery").val();
            if ($("#txtdayevery").val() == "") {
                $("#divtxtdayevery").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!NumberDayEveryvalue.match(numericexpression)) {
                    $("#divtxtdayevery").addClass("ErrorFocus");
                    $("#txtdayevery").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 31");
                    returnVal = false;
                }
                else if (NumberDayEveryvalue > 31 || NumberDayEveryvalue <= 0) {
                    $("#divtxtdayevery").addClass("ErrorFocus");
                    $("#txtdayevery").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 31");
                    returnVal = false;
                }
                else {

                    $("#divtxtdayevery").removeClass("ErrorFocus");

                }
            }

            var NumberMonthsEveryvalue = $("#txtdaymonths").val();
            if ($("#txtdaymonths").val() == "") {
                $("#divtxtdaymonths").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!NumberMonthsEveryvalue.match(numericexpression)) {
                    $("#divtxtdaymonths").addClass("ErrorFocus");
                    $("#txtdaymonths").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 99");
                    returnVal = false;
                }
                else if (NumberMonthsEveryvalue > 99 || NumberMonthsEveryvalue <= 0) {
                    $("#divtxtdaymonths").addClass("ErrorFocus");
                    $("#txtdaymonths").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 99");
                    returnVal = false;
                }
                else {

                    $("#divtxtdaymonths").removeClass("ErrorFocus");

                }
            }

        }

        if ($("#radiothe").prop("checked")) {
            if ($("#ddlthepart option:selected").text() == "") {
                $("#divddlthepart").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                $("#divddlthepart").removeClass("ErrorFocus");
            }
            if ($("#ddlthemonths option:selected").text() == "") {
                $("#divddlthemonths").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                $("#divddlthemonths").removeClass("ErrorFocus");
            }


            var NumbertheMonthvalue = $("#txtthemonths").val();
            if ($("#txtthemonths").val() == "") {
                $("#divtxtthemonths").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!NumbertheMonthvalue.match(numericexpression)) {
                    $("#divtxtthemonths").addClass("ErrorFocus");
                    $("#txtthemonths").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 99");
                    returnVal = false;
                }
                else if (NumbertheMonthvalue > 99 || NumbertheMonthvalue <= 0) {
                    $("#divtxtthemonths").addClass("ErrorFocus");
                    $("#txtthemonths").focus();
                    $('#lblerror').text("* Only numeric values are allowed between 1 and 99");
                    returnVal = false;
                }
                else {

                    $("#divtxtthemonths").removeClass("ErrorFocus");

                }
            }

        }
        if ($("#ddlTask option:selected").text() == "please choose...") {
            $("#divpname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divpname").removeClass("ErrorFocus");
        }


    }
  
        
    
    return returnVal;
}
function LoadDdls(pathUrl, ddlObject, KeyField, ValueField) {
    $.ajax({
        url: pathUrl,
        type: "GET",
        async: false,
        success: function (result) {

            var resultVals = $.parseJSON(result);

            if (resultVals["Error"] == undefined || resultVals["Error"] == null) {
                for (var i = 0; i < resultVals.length; i++) {
                    ddlObject.append('<option value=' + resultVals[i][KeyField] + '>' + resultVals[i][ValueField] + '</option>');
                }
            }
        }
        ,
        error: function (err) {
            //alert(err.statusText);
        }
    });
}

//Clear all controls
function ClearAllControlValues(divID) {
    var searchElms = document.getElementById(divID).getElementsByTagName("*");
    for (i = 0; i < searchElms.length; i++) {
        var elmt = searchElms[i];
        var type = searchElms[i].type;
        var tag = searchElms[i].tagName.toLowerCase(); // normalize case

        // to reset the value attr of text inputs,
        // password inputs, fileUpload and textareas
        if (type == 'text' || type == 'password' || type == 'textarea' || tag == 'textarea' || type == 'file' || type == "hidden")
            elmt.value = "";
            // checkboxes and radios need to have their checked state cleared                
        else if (type == 'checkbox' || type == 'radio')
            elmt.checked = false;
            //single select elements need to have their 'selectedIndex' property set to -1               
        else if (type == 'select-one') {
            //elmt.options[0].selected = true;
            $(elmt).attr("value", "");

        }
            //multi select elements need to have their selection clear
        else if (type == 'select-multiple') {
            while (elmt.selectedIndex != -1) {
                indx = elmt.selectedIndex;
                elmt.options[indx].selected = false;
            }
            elmt.selected = false;
        }
            //else if (tag == "span" && (elmt.className != "ms-inputuserfield" && elmt.className != "rightpeoplepickertextbox") && elmt.className != "required")
            //    elmt.innerText = "";
      
        
       
        
    }

    
    
    return false;
}
function ClearAllControlValues(divID) {
    var searchElms = document.getElementById(divID).getElementsByTagName("*");
    for (i = 0; i < searchElms.length; i++) {
        var elmt = searchElms[i];
        var type = searchElms[i].type;
        var tag = searchElms[i].tagName.toLowerCase(); // normalize case

        // to reset the value attr of text inputs,
        // password inputs, fileUpload and textareas
        if (type == 'text' || type == 'password' || type == 'textarea' || tag == 'textarea' || type == 'file' || type == "hidden")
            elmt.value = "";
            // checkboxes and radios need to have their checked state cleared                
        else if (type == 'checkbox' || type == 'radio')
            elmt.checked = false;
            //single select elements need to have their 'selectedIndex' property set to -1               
        else if (type == 'select-one') {
            //elmt.options[0].selected = true;
            $(elmt).attr("value", "");

        }
            //multi select elements need to have their selection clear
        else if (type == 'select-multiple') {
            while (elmt.selectedIndex != -1) {
                indx = elmt.selectedIndex;
                elmt.options[indx].selected = false;
            }
            elmt.selected = false;
        }
        //else if (tag == "span" && (elmt.className != "ms-inputuserfield" && elmt.className != "rightpeoplepickertextbox") && elmt.className != "required")
        //    elmt.innerText = "";




    }



    return false;
}

//function ValidateAll(divID, label) {
//    var returnVal = true; var returnMail = true; var startDate, endDate;
//    var returnDate = true; var returnEDate = true; var returnRDate = true; var returnDob = true;
//    var returnPhNo = true; var returnNumeric = true; var returnFax = true;
//    var todayDate = new Date().toDateString();
//    var returnStartEnd = true;
//    var returnI94 = true;
//    var returnEntryExit = true;
//    var returnFamilyEntryExit = true;
  
//    //TextBox
//    $("#" + divID).find(".vinput").each(function () {
//        var returnFamilyEntryExit = true;
//        if ($(this).val() == "") {
//            //$(this).focus();
//            $(this).addClass("ErrorFocus");
//            returnVal = false;
//        }
//        else
//            $(this).removeClass("ErrorFocus");
//    });
//    // CheckBox and Radio buttons
//    $("#" + divID).find(".vcheckBoxOrRadio").each(function () {
//        var checkFields = $("input[name='checkBoxOrRadio']").serializeArray();
//        if (checkFields.length === 0) {
//            $(this).addClass("ErrorFocus");
//            returnVal = false;
//        }
//        else
//            $(this).removeClass("ErrorFocus");
//    });
//    //Dropdown
//    $("#" + divID).find(".vselect").each(function () {
//        if ($(this).val() == "" || $(this).val() == "0") {
//            //$(this).focus();
//            $(this).addClass("ErrorFocus");
//            returnVal = false;
//        }
//        else
//            $(this).removeClass("ErrorFocus");
//    });
//    //managerlist
//    $("#" + divID).find(".vmanager").each(function () {

//        if ($("#listManager").is(':empty')) {
//            $("#divManager").addClass("ErrorFocus");

//            returnVal = false;
//        }
//        else
//            $("#divManager").removeClass("ErrorFocus");

//    });
//    //Assigned Recruiter

//    $("#" + divID).find(".vArecruiter").each(function () {

//        if ($("#listRecruit").is(':empty')) {
//            $("#divRecruit").addClass("ErrorFocus");

//            returnVal = false;
//        }
//        else
//            $("#divRecruit").removeClass("ErrorFocus");

//    });
//    //resource list
//    $("#" + divID).find(".vresources").each(function () {

//        if ($("#listResources").is(':empty')) {
//            $("#divResources").addClass("ErrorFocus");
//            returnVal = false;
//        }
//        else
//            $("#divResources").removeClass("ErrorFocus");

//    });
//    // Interviewer List
//    $("#" + divID).find(".vinterviewer").each(function () {

//        if ($("#listInterviewer").is(':empty')) {
//            $("#divInterviewer").addClass("ErrorFocus");
//            returnVal = false;
//        }
//        else
//            $("#divInterviewer").removeClass("ErrorFocus");

//    });

//    //Email
//    $("#" + divID).find(".vemail").each(function () {

//        if ($(this).val().length > 0) {
//            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
//            if (!filter.test($(this).val())) {

//                $(this).addClass("ErrorFocus");
//                returnMail = false;
//            }
//            else if (filter.test($(this).val()))
//                $(this).removeClass("ErrorFocus");
//        }
//    });

//    //Date
//    $("#" + divID).find(".vdate").each(function () {

//        if ($(this).val().length > 0) {

//            var filter = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
//            if (!filter.test($(this).val())) {
//                $(this).addClass("ErrorFocus");
//                returnDate = false;
//            }
//            else if (filter.test($(this).val()))
//                $(this).removeClass("ErrorFocus");


//        }
//    });
//    //date greater than today
//    $("#" + divID).find(".vdateToday").each(function () {

//        if ($(this).val().length > 0) {
//            var InputDate = new Date($(this).val()).toDateString();

//            if ($(this).val() != "" && (Date.parse(todayDate) > Date.parse(InputDate))) {
//                $(this).addClass("ErrorFocus");
//                returnEDate = false;
//            }

//        }
//    });
//    $("#" + divID).find(".vsdate").each(function () {
//        if ($(this).val() != "") {
//            startDate = new Date($(this).val());
//        }

//    });

//    $("#" + divID).find(".vedate").each(function () {
//        if ($(this).val() != "" && (Date.parse(startDate) > Date.parse($(this).val()))) {
//            //endDate = new Date($(this).val());          
//            $(this).addClass("ErrorFocus");
//            returnEDate = false;
//        }
//        //else if($(this).val() != "" && (Date.parse(startDate) < Date.parse($(this).val())))
//        //$(this).removeClass("ErrorFocus");


//    });
//    $("#" + divID).find(".vrdate").each(function () {
//        if ($(this).val() != "" && (Date.parse(startDate) > Date.parse($(this).val()))) {
//            //endDate = new Date($(this).val());
//            //$(this).focus();
//            $(this).addClass("ErrorFocus");
//            returnDate = false;
//            returnRDate = false;
//        }




//    });

//    //D0B
//    $("#" + divID).find(".vdob").each(function () {

//        if ($(this).val().length > 0) {
//            var filter = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
//            var minDate = Date.parse("01/01/1900");
//            var today = new Date();
//            var DOB = Date.parse($(this).val());

//            if (!filter.test($(this).val().trim()) || (minDate > DOB || DOB > today)) {
//                $(this).addClass("ErrorFocus");
//                returnDob = false;
//            }
//            //else
//            // $(this).removeClass("ErrorFocus");
//            //compare dob and  current date
//        }
//    });

//    //Phone

//    $("#" + divID).find(".vphone").each(function () {

//        if ($(this).val().length > 0) {
//            //var filter = /^[0-9]{9,15}$/;
//            var filter = /^[()0-9 *#+-]+$/;
//            if (!filter.test($(this).val().trim())) {
//                $(this).addClass("ErrorFocus");
//                if (!($(this).hasClass('vfax'))) {
//                    returnPhNo = false;

//                }

//                if (($(this).hasClass('vfax'))) {
//                    returnFax = false;

//                }
//            } else if (filter.test($(this).val().trim()))
//                $(this).removeClass("ErrorFocus");

//        }
//    });

//    //Numeric
//    $("#" + divID).find(".vnumeric").each(function () {

//        if ($(this).val().length > 0) {
//            var filter = /^[0-9]*$/;
//            if (!filter.test($(this).val().trim())) {
//                $(this).addClass("ErrorFocus");
//                returnNumeric = false;
//            }
//            else if (filter.test($(this).val().trim()))
//                $(this).removeClass("ErrorFocus");
//        }
//    });
//    //float Numbers
//    $("#" + divID).find(".vfloat").each(function () {

//        if ($(this).val().length > 0) {
//            var filter = /^[0-9]\d*(\.\d+)?$/;
//            if (!filter.test($(this).val().trim())) {
//                $(this).addClass("ErrorFocus");
//                returnNumeric = false;
//            }
//            else if (filter.test($(this).val().trim()))
//                $(this).removeClass("ErrorFocus");
//        }
//    });

//    //label-Error messages 

//    if (!returnStartEnd) {
//        $('#txtPassIssueDate').addClass("ErrorFocus");
//        $('#txtPassValidityDate').addClass("ErrorFocus");
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("The Passport Validity Date must be greater than Issue Date");
//        return false;
//    }
//    else if (!returnI94) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("The I-94 Validity Date must be greater than Issue Date");
//        return false;
//    }
//    else if (!returnEntryExit) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("The Visa Exit Date must be greater than Entry Date");
//        return false;
//    }
//    else if (!returnFamilyEntryExit) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("The  Family Visa Exit Date must be greater than Entry Date");
//        return false;
//    }
//    else if (!returnVal) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("Please fill all mandatory fields");
//        return false;
//    }
//    else if (returnVal && !returnMail) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("Please Provide a Valid E-mail");
//        return false;
//    }
//    else if (returnVal && !returnDob) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("Please Provide a Valid DoB");
//        return false;
//    }
//    else if (returnVal && !returnPhNo) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("Please Provide a Valid Phone Number");
//        return false;
//    }
//    else if (returnVal && !returnFax) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("Please Provide a Valid Fax Number");
//        return false;
//    }
//    else if (returnVal && !returnDate) {

//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("Please Provide a Valid Date (MM/DD/YYYY)");
//        return false;

//    }
//    else if (returnVal && !returnEDate) {

//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("Please Provide a Date Greater Than The Entered Date");
//        return false;

//    } else if (returnVal && !returnNumeric) {
//        $("#" + label).addClass("lblError");
//        $("#" + label).removeClass("lblMessage");
//        $("#" + label).text("Please Provide a Valid Numeric value");
//        return false;
//    }
//    else if (returnVal) {
//        $("#" + label).text("");
//        $("#" + label).removeClass("lblError");
//        $("#" + label).addClass("lblMessage");
//    }
//    return returnVal;
//}
