
function Validate(type)
{
    var returnVal = true;
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    var letters = /^[a-zA-Z_ \n]*$/;
    var numericexpression = /^\d+$/;
    //var timeExpression =/^\d{2,}:\d{2}:\d{2}[AM PM]$/;
    var timeExpression = /^(0?[1-9]|1[012])(:[0-5]\d) [APap][mM]$/
    var freq_interval = 0;
    var descrptionRegular = /^[a-zA-Z_.:, \n]*$/;
    var NamewithspaceRegular = /^[a-zA-Z0-9_ \-#()]*$/;
    var packageNameRegular = /^[a-zA-Z0-9_ \-#()]*$/;
    var pacagepath = /^(?:[a-zA-Z]\:|\\\\[\w\s*\_]+\\[\w\s*$]+)\\(?:[\w\s*]+\\)*\w\s*([\w\s*])+\.(dtsx)$/;
    //var pacagepath = /^(?:[a-zA-Z]\:|\\\\[\w\s*\._]+\\[\w\s*.$]+)\\(?:[\w\s*]+\\)*\w\s*([\w\s*.])+$/;
    //var pacagepath = /^([\w\-]+)\.html$/;
    //var pacagepath = /^(?:[a-zA-Z]\:|\\\\[\w\._]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$/;
   // var pacagepath = /^[a-zA-Z]:\\.+\s*/;
    //var pacagepath = /^[a-zA-Z]:\\.+\s.*/;
    //var pacagepath = /^[a-zA-Z]:\\\s.+/;
    if (type == 'emp') {
        $('#pValidateMsg').text('');


        if ($("#txtEmployeeName").val().trim() == '') {
            $("#divNewEmployee").addClass("ErrorFocus");
            returnVal = false;
        }
        else {


            if (!$("#txtEmployeeName").val().match(letters)) {
                $("#divNewEmployee").addClass("ErrorFocus");
                $('#pValidateMsg').text("* Only alphabets are allowed");
                returnVal = false;
            }
            else {
                $("#divNewEmployee").removeClass("ErrorFocus");
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
                $('#pValidateMsg').text("* Password doesn't match");
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
                $('#pValidateMsg').text("* Invalid email id");
                returnVal = false;

            }
            else {
                $("#divEmailId").removeClass("ErrorFocus");
            }
        }

    }

    else if (type == 'support') {
        var Name = $("#txtuserName").val();
        var supportText = $("#txtsupportArea").val();

        if (Name.trim() == '') {
            $("#divUserName").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            if (!Name.match(letters)) {
                $('#lblerror').removeClass("messagesend");
                $('#lblerror').addClass("loginerror");
                $("#divUserName").addClass("ErrorFocus");
                $('#lblerror').text("Only Alphabets are Allowed");

                returnVal = false;
            }
            else {
                $("#divUserName").removeClass("ErrorFocus");
            }
            //$("#divUserName").removeClass("ErrorFocus");
        }





        //if ($("#txtsupportArea").val() == '') {
        //    $("#divTxtArea").addClass("ErrorFocus");
        //    returnVal = false;
        //} else {
        //    $("#divTxtArea").removeClass("ErrorFocus");
        //}
        if (supportText.trim() == '') {
            $("#divTxtArea").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divTxtArea").removeClass("ErrorFocus");
        }


        if ($("#txtEmail").val() == '') {
            $("#divEmailId").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divEmailId").removeClass("ErrorFocus");
            var check = filter.test($("#txtEmail").val());
            if (!filter.test($("#txtEmail").val())) {
                $("#divEmailId").addClass("ErrorFocus");
                $('#lblerror').removeClass("messagesend");
                $('#lblerror').addClass("loginerror");
                $('#lblerror').text("Please enter valid email");
                returnVal = false;
            }
            else {
                $("#divEmailId").removeClass("ErrorFocus");
            }
        }
    }
    else if (type == 'category') {

        var CategoryName = $("#txtCategoryName").val();
        var Category = $("#txtCategory").val();
        if (CategoryName.trim() == '') {
            $("#divCategoryName").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            if (!CategoryName.match(NamewithspaceRegular)) {

                //$('#pValidationMsg').text("Only Alphabets are Allowed");
                $('#pValidationMsg').text("* Only alphanumeric and special characters like _ - # and () are allowed");
                $("#divCategoryName").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                $("#divUserName").removeClass("ErrorFocus");
            }
        }
        if (Category.trim() == '') {
            $("#divCategory").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            if (!Category.match(letters)) {

                $('#pValidationMsg').text("Only Alphabets are Allowed");
                $("#divCategory").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                $("#divUserName").removeClass("ErrorFocus");
            }
        }

    }
    else if (type == 'addPackage') {
        debugger
        if ($("#txtareaDes").val().trim() == '') {
            $("#divDesc").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            if (!$("#txtareaDes").val().match(descrptionRegular)) {
                $("#divDesc").addClass("ErrorFocus");
                $("#txtareaDes").focus();
                $('#packageValidateMsg').text("*  Only alphabets and special characters like . : , are allowed");
                returnVal = false;
            }
            else {
                $("#divDesc").removeClass("ErrorFocus");
            }
        }
        if (!$("#txtareaDestInfo").val().match(letters)) {
            $("#divDestInfo").addClass("ErrorFocus");
            $("#txtareaDestInfo").focus();
            $('#packageValidateMsg').text("* Only alphabets are allowed");
            returnVal = false;
        }
        else {
            $("#divDestInfo").removeClass("ErrorFocus");
        }
        if (!$("#txtSource").val().match(letters)) {
            $("#divSourcetxtarea").addClass("ErrorFocus");
            $("#txtSource").focus();
            $('#packageValidateMsg').text("* Only alphabets are allowed");
            returnVal = false;
        }
        else {
            $("#divSourcetxtarea").removeClass("ErrorFocus");
        }
        if ($("#ddlEmployee option:selected").text() == "please choose...") {
            $("#divddlemployee").addClass("ErrorFocus");

            returnVal = false;
        }
        else {
            $("#divddlemployee").removeClass("ErrorFocus");
        }
        if ($("#ddlCategory option:selected").text() == "please choose...") {
            $("#divddlCategory").addClass("ErrorFocus");

            returnVal = false;
        }
        else {
            $("#divddlCategory").removeClass("ErrorFocus");
        }

        if ($("#txtpackagePath").val().trim() == '') {
            $("#divPackagePath").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            if (!$("#txtpackagePath").val().match(pacagepath)) {
                $("#divPackagePath").addClass("ErrorFocus");
                $("#txtpackagePath").focus();
                alert(" Package path should valid( " + "\\" + " ) & ends with .dtsx extension");
                //$('#packageValidateMsg').text("*");
                returnVal = false;
            }
            else {
                $("#divPackagePath").removeClass("ErrorFocus");
            }
        }
        if ($("#txtpackageName").val().trim() == '') {
            $("#divPackageName").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            if (!$("#txtpackageName").val().match(packageNameRegular)) {
                $("#divPackageName").addClass("ErrorFocus");
                $("#txtpackageName").focus();
                //$('#packageValidateMsg').text("* Only alphanumeric and special  characters like . _  are allowed");
                alert("Only alphanumeric and special characters like _ - # and () are allowed");
              //  $('#packageValidateMsg').text("* Only alphanumeric and special characters like _ - # and () are allowed ");
                returnVal = false;
            }
            else {
                $("#divPackageName").removeClass("ErrorFocus");
            }

        }

    }
    else if (type == 'emailAlert') {
        if ($("#ddlPackagegroup option:selected").text() == "please choose...") {
            $("#divddlPackagegroup").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divddlCategory").removeClass("ErrorFocus");
        }

        if ($("#ddlEmployee option:selected").text() == "please choose...") {
            $("#divddlEmployee").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divddlemployee").removeClass("ErrorFocus");
        }

    }
    else if (type == 'packageConnection') {
        if ($("#ddlPackage option:selected").text() == "Please choose..") {
            $("#divPackage").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divPackage").removeClass("ErrorFocus");
        }
        if ($("#ddlConnection option:selected").text() == "Please choose..") {
            $("#divConnection").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divConnection").removeClass("ErrorFocus");
        }
        if ($("#txtConnetionString").val().trim() == "") {
            $("#divConnectionString").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divConnectionString").removeClass("ErrorFocus");
        }

    }
    else if (type == 'groups') {
        var Name = $("#txtRunName").val();
        var RecoveryCoun = $("#ddlRecoveryCount").val();
        if ($("#ddlRecoveryCount option:selected").text() == "please choose...") {
            $("#divRecoveryCount").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divRecoveryCount").removeClass("ErrorFocus");
        }

        if (Name.trim() == '') {
            $("#divRunName").addClass("ErrorFocus");
            returnVal = false;
        }
        else {

            if (!Name.match(NamewithspaceRegular)) {
                $("#divRunName").addClass("ErrorFocus");
                $('#lblerror').text("* Only alphanumeric and special characters like _ - # and () are allowed");
                returnVal = false;
            }
            else {
                $("#divRunName").removeClass("ErrorFocus");

            }

        }


    }
    else if (type == 'aggregatereport') {
        if ($("#ddlPackageroup option:selected").text() == "please choose...") {
            $("#divPackageroup").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divPackageroup").removeClass("ErrorFocus");
        }
        //if ($("#ddlPackageName option:selected").text() == "please choose...") {
        //    $("#divPackageName").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else {
        //    $("#divPackageName").removeClass("ErrorFocus");
        //}
        //if ($("#ddlAsssignedTo option:selected").text() == "please choose...") {
        //    $("#divAsssignedTo").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else {
        //    $("#divAsssignedTo").removeClass("ErrorFocus");
        //}
        //if ($("#dtStartDate").val() == "") {
        //    $("#divStartDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#divStartDate").removeClass("ErrorFocus");

        //if ($("#dtEndDate").val() == "") {
        //    $("#divEndDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#divEndDate").removeClass("ErrorFocus");
        if ($("#dtStartDate").val() != "" && $("#dtEndDate").val() != "") {
            var arrDate1 = $('#dtStartDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#dtEndDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                $("#pAggregateReport").text("The End Date must be greater than the Start Date");
                $("#divStartDate").addClass("ErrorFocus");
                $("#divEndDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                $("#pAggregateReport").text('');
                $("#divStartDate").removeClass("ErrorFocus");
                $("#divEndDate").removeClass("ErrorFocus");
            }
        }

    }
    else if (type == 'logreport') {
        if ($("#ddlPackageroup option:selected").text() == "please choose...") {
            $("#divPackageroup").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divPackageroup").removeClass("ErrorFocus");
        }
        //if ($("#ddlPackageName option:selected").text() == "please choose...") {
        //    $("#divPackageName").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else {
        //    $("#divPackageName").removeClass("ErrorFocus");
        //}
        //if ($("#ddlPackageStaus option:selected").text() == "please choose...") {
        //    $("#divPackageStatus").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else {
        //    $("#divPackageStatus").removeClass("ErrorFocus");
        //}
        //if ($("#dtStartDate").val() == "") {
        //    $("#divStartDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#divStartDate").removeClass("ErrorFocus");

        //if ($("#dtEndDate").val() == "") {
        //    $("#divEndDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#divEndDate").removeClass("ErrorFocus");
        if ($("#dtStartDate").val() != "" && $("#dtEndDate").val() != "") {
            var arrDate1 = $('#dtStartDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#dtEndDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                $("#pLogreport").text("The End Date must be greater than the Start Date");
                $("#divStartDate").addClass("ErrorFocus");
                $("#divEndDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                $("#pLogreport").text('');
                $("#divStartDate").removeClass("ErrorFocus");
                $("#divEndDate").removeClass("ErrorFocus");
            }
        }
    }
    else if (type == 'errorreport') {
        if ($("#ddlPackageroup option:selected").text() == "please choose...") {
            $("#divPackageroup").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divPackageroup").removeClass("ErrorFocus");
        }
        //if ($("#ddlPackageName option:selected").text() == "please choose...") {
        //    $("#divPackageName").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else {
        //    $("#divPackageName").removeClass("ErrorFocus");
        //}

        //if ($("#dtStartDate").val() == "") {
        //    $("#divStartDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#divStartDate").removeClass("ErrorFocus");

        //if ($("#dtEndDate").val() == "") {
        //    $("#divEndDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#divEndDate").removeClass("ErrorFocus");
        if ($("#dtStartDate").val() != "" && $("#dtEndDate").val() != "") {
            var arrDate1 = $('#dtStartDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#dtEndDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                $("#pErroreport").text("The End Date must be greater than the Start Date");
                $("#divStartDate").addClass("ErrorFocus");
                $("#divEndDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                $("#pErroreport").text('');
                $("#divStartDate").removeClass("ErrorFocus");
                $("#divEndDate").removeClass("ErrorFocus");
            }
        }
    }
    else if (type == 'packagereport') {
        if ($("#ddlPackageName option:selected").text() == "please choose...") {
            $("#divPackageName").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divPackageName").removeClass("ErrorFocus");
        }
        //if ($("#ddlPackageName option:selected").text() == "please choose...") {
        //    $("#divPackageName").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else {
        //    $("#divPackageName").removeClass("ErrorFocus");
        //}

        //if ($("#dtStartDate").val() == "") {
        //    $("#divStartDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#divStartDate").removeClass("ErrorFocus");

        //if ($("#dtEndDate").val() == "") {
        //    $("#divEndDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#divEndDate").removeClass("ErrorFocus");
        if ($("#dtStartDate").val() != "" && $("#dtEndDate").val() != "") {
            var arrDate1 = $('#dtStartDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#dtEndDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                $("#pErroreport").text("The End Date must be greater than the Start Date");
                $("#divStartDate").addClass("ErrorFocus");
                $("#divEndDate").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                $("#pErroreport").text('');
                $("#divStartDate").removeClass("ErrorFocus");
                $("#divEndDate").removeClass("ErrorFocus");
            }
        }
    }
    else if (type == 'taskscheduleweekly')
    {
        var checkBoxvalue = $('#chkActive').is(':checked');
        var checkkActivevalue = checkBoxvalue ? 1 : 0;
        if (checkkActivevalue == 0)
        {
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
       
        if ($("#radioocurevery").prop("checked"))
        {
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
                else if (NumberEveryvalue > 100) {
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
                if (!TextstartTime.match(timeExpression)) {
                    $("#txtstartime").focus();
                    $("#divtstartime").addClass("ErrorFocus");
                    $('#lblerror').text("*Time should be valid with format HH:MM (AM|PM)");
                    returnVal = false;
                }
                else {
                    $("#divtstartime").removeClass("ErrorFocus");

                }
            }  
            var TextendTime = $("#txtendtime").val();
            if ($("#txtendtime").val() == "") {
                $("#divtendtime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!TextendTime.match(timeExpression)) {
                    $("#txtendtime").focus();
                    $("#divtendtime").addClass("ErrorFocus");
                    $('#lblerror').text("*Time should be valid with format HH:MM (AM|PM)");
                    returnVal = false;
                }
                else {
                    $("#divtendtime").removeClass("ErrorFocus");

                }
            }
            if ($("#txtstartime").val() != "" && $("#txtendtime").val() != "")
            {
                var newTexttime = $("#txtstartime").val();
                var newendTexttime = $("#txtendtime").val();
                if (newTexttime == newendTexttime) {
                    $("#txtendtime").focus();
                    $("#lblerror").text("*The job schedule ending time must be after the starting time");
                    $("#divtendtime").addClass("ErrorFocus");
                    returnVal = false;
                }
                else
                {
                    
                }
            }  
        

        }
        var length = $('[name="cbox[]"]:checked').length;
        if (length == 0) {
            $('#lblerror').text("A weekly frequency requires you to select at least one weekday");
            returnVal = false;

        }
        if ($("#radioocursonce").prop("checked")) {
            var TextOccursstartTime = $("#txttime").val();
            if ($("#txttime").val() == "") {
                $("#divtime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!TextOccursstartTime.match(timeExpression)) {
                    $("#divtime").addClass("ErrorFocus");
                    $("#txttime").focus();
                    $('#lblerror').text("*Time should be valid with format HH:MM (AM|PM)");
                    returnVal = false;
                }
                else {
                    $("#divtime").removeClass("ErrorFocus");

                }
            }
            // $("#divtime").removeClass("ErrorFocus");
        }
        var NumberEvery = $("#txtrecurs").val();
        if ($("#txtrecurs").val() == "") {
            $("#divrecurs").addClass("ErrorFocus");
            returnVal = false;
        }
        else
        {
            if (!NumberEvery.match(numericexpression)) {
                $("#divrecurs").addClass("ErrorFocus");
                $("#txtrecurs").focus();
                $('#lblerror').text("* Only numeric values are allowed between 1 and 100");
                returnVal = false;
            }
           else if (NumberEvery > 100) {
                $("#divrecurs").addClass("ErrorFocus");
                $('#lblerror').text("* Only numeric values are allowed between 1 and 100");
                returnVal = false;
            }
            else {

                $("#divrecurs").removeClass("ErrorFocus");

            }
        }
        
        var Name = $("#txtname").val();
        if (Name.trim() == '') {
            $("#divname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {

            if (!Name.match(NamewithspaceRegular)) {
                $("#divname").addClass("ErrorFocus");
                $('#lblerror').text("* Only alphanumeric and special characters like _ - # and () are allowed");
                returnVal = false;
            }
            else {
                $("#divname").removeClass("ErrorFocus");

            }

        }
        if ($("#ddlPackage option:selected").text() == "please choose...") {
            $("#divpname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divpname").removeClass("ErrorFocus");
        }
    }
    else if (type == 'taskschedulemonthly')
    {
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
                else if (NumberEveryvalue > 100) {
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
                if (!TextstartTime.match(timeExpression)) {
                    $("#txtstartime").focus();
                    $("#divtstartime").addClass("ErrorFocus");
                    $('#lblerror').text("*Time should be valid with format HH:MM (AM|PM)");
                    returnVal = false;
                }
                else {
                    $("#divtstartime").removeClass("ErrorFocus");

                }
            }
            var TextendTime = $("#txtendtime").val();
            if ($("#txtendtime").val() == "") {
                $("#divtendtime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!TextendTime.match(timeExpression)) {
                    $("#txtendtime").focus();
                    $("#divtendtime").addClass("ErrorFocus");
                    $('#lblerror').text("*Time should be valid with format HH:MM (AM|PM)");
                    returnVal = false;
                }
                else {
                    $("#divtendtime").removeClass("ErrorFocus");

                }
            }
            if ($("#txtstartime").val() != "" && $("#txtendtime").val() != "") {
                var newTexttime = $("#txtstartime").val();
                var newendTexttime = $("#txtendtime").val();
                if (newTexttime == newendTexttime) {
                    $("#txtendtime").focus();
                    $("#lblerror").text("*The job schedule ending time must be after the starting time");
                    $("#divtendtime").addClass("ErrorFocus");
                    returnVal = false;
                }
                else {

                    //$("#divtendtime").removeClass("ErrorFocus");

                }
            }


        }
        if ($("#radioocursonce").prop("checked")) {
            var TextOccursstartTime = $("#txttime").val();
            if ($("#txttime").val() == "") {
                $("#divtime").addClass("ErrorFocus");
                returnVal = false;
            }
            else {
                if (!TextOccursstartTime.match(timeExpression)) {
                    $("#divtime").addClass("ErrorFocus");
                    $("#txttime").focus();
                    $('#lblerror').text("*Time should be valid with format HH:MM (AM|PM)");
                    returnVal = false;
                }
                else {
                    $("#divtime").removeClass("ErrorFocus");

                }
            }
            // $("#divtime").removeClass("ErrorFocus");
        }



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
                else if (NumberDayEveryvalue > 31) {
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
                else if (NumberMonthsEveryvalue > 99) {
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
                else if (NumbertheMonthvalue > 99) {
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
        var Name = $("#txtname").val();
        if (Name.trim() == '') {
            $("#divname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {

            if (!Name.match(NamewithspaceRegular)) {
                $("#divname").addClass("ErrorFocus");
                $('#lblerror').text("* Only alphanumeric and special characters like _ - # and () are allowed");
                returnVal = false;
            }
            else {
                $("#divname").removeClass("ErrorFocus");

            }

        }

        if ($("#ddlPackage option:selected").text() == "please choose...") {
            $("#divpname").addClass("ErrorFocus");
            returnVal = false;
        }
        else {
            $("#divpname").removeClass("ErrorFocus");
        }
        

    }
    else if (type == 'permission') {
        var permissionText = $("#txtpermisssiontxt").val();
        var RegularExpression = /^[a-zA-Z ,]*$/;
        if (permissionText.trim() == '') {
            $("#divpermissiontxt").addClass("ErrorFocus");
            returnVal = false;

        }
        else {
            if (!permissionText.match(RegularExpression)) {
                $("#divpermissiontxt").addClass("ErrorFocus");
                $('#lblerror').text("* Only alphabets,space character and special characters like , are allowed");
                returnVal = false;

            }
            else {
                $("#divpermissiontxt").removeClass("ErrorFocus");

            }

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
//pagination function
function disableButtons(LastButton, NextButton, FirstButton, PreviousButton, PageCount, CurrentPageId) {
    if (CurrentPageId == PageCount) {
        LastButton.css('pointer-events', 'none');
        NextButton.css('pointer-events', 'none');
    }
    else {
        LastButton.css('pointer-events', 'visible');
        NextButton.css('pointer-events', 'visible');
    }
    if (CurrentPageId == 1) {
        FirstButton.css('pointer-events', 'none');
        PreviousButton.css('pointer-events', 'none');
    }
    else {
        FirstButton.css('pointer-events', 'visible');
        PreviousButton.css('pointer-events', 'visible');
    }
}
function hidePages(PaginationDivId, ActiveClassName, PageNum) {
    PaginationDivId.each(function () {
        $(ActiveClassName + PageNum).hide();
        PageNum = PageNum + 1;
    });
}
function showPages(PaginationDivId, ActiveClassName, PageNum) {
    PaginationDivId.each(function () {
        $(ActiveClassName + PageNum).show();
        PageNum = PageNum + 1;
    });
}
function ShowPreviousPage(Paginationbtn, ClassName, ActiveClass, ActiveClassTwodgt, ActiveClassThreedgt) {
    if (classId == 5 && loopVal > 5) {
        AddAndRemoveClass(loopVal - 1, classId, Paginationbtn, $(ClassName + classId),
            ActiveClass, ActiveClassTwodgt, ActiveClassThreedgt);
        loopVal = loopVal - 5;
        Paginationbtn.each(function () {
            $(this).text(loopVal);
            loopVal = loopVal + 1;
        });
    }
    else
        AddAndRemoveClass(loopVal, (classId - 1), Paginationbtn, $(ClassName + (classId - 1)),
            ActiveClass, ActiveClassTwodgt, ActiveClassThreedgt);
}
function getLoopValAndClassId(ActiveClassName, ActiveClassNameTwodgt, ActiveClassNameThreeDgt) {
    if (ActiveClassName.length != 0 && ActiveClassNameTwodgt.length == 0 && ActiveClassNameThreeDgt.length == 0) {
        classId = parseInt(ActiveClassName.attr("name"));
        loopVal = parseInt(ActiveClassName.text());
    }
    else if (ActiveClassNameTwodgt.length != 0 && ActiveClassName.length == 0 && ActiveClassNameThreeDgt.length == 0) {
        classId = parseInt(ActiveClassNameTwodgt.attr("name"));
        loopVal = parseInt(ActiveClassNameTwodgt.text());
    }
    else {
        classId = parseInt(ActiveClassNameThreeDgt.attr("name"));
        loopVal = parseInt(ActiveClassNameThreeDgt.text());
    }
}
function FirstButonClick(btnClass, paginationNumClass, ActiveClassName, CurrentPageId, ActiveCLassTwodgt, ActiveClassThreedgt) {
    loopVal = CurrentPageId;
    btnClass.each(function () {
        $(this).text(loopVal);
        loopVal = loopVal + 1;
    });
    AddAndRemoveClass(1, 1, btnClass, paginationNumClass, ActiveClassName, ActiveCLassTwodgt, ActiveClassThreedgt)
}
function LastButtonClick(btnClass, paginationNumClass, LastPageId, ActiveClassName, CurrentPageId, ActiveCLassTwodgt, ActiveClassThreedgt) {
    if (CurrentPageId > 5) {
        loopVal = CurrentPageId - 4;
        btnClass.each(function () {
            if (CurrentPageId >= loopVal) {
                $(this).text(loopVal);
                loopVal = loopVal + 1;
            }
        });
        AddAndRemoveClass(CurrentPageId, 5, btnClass, paginationNumClass, ActiveClassName, ActiveCLassTwodgt, ActiveClassThreedgt);
    }
    else {
        loopVal = CurrentPageId - (CurrentPageId - 1);
        btnClass.each(function () {
            if (CurrentPageId >= loopVal) {
                $(this).text(loopVal);
                loopVal = loopVal + 1;
            }
        });
        AddAndRemoveClass(CurrentPageId, CurrentPageId, btnClass, LastPageId, ActiveClassName, ActiveCLassTwodgt, ActiveClassThreedgt);
    }
}
function AddAndRemoveClass(loopVal, classId, btnClass, paginationNumClass, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt) {
    if ((loopVal.toString().length == 1)) {
        btnClass.removeClass(ActiveClassName);
        btnClass.removeClass(ActiveClassTwodgt);
        btnClass.removeClass(ActiveClassThreedgt);
        paginationNumClass.addClass(ActiveClassName);
    }
    else if ((loopVal.toString().length == 2)) {
        btnClass.removeClass(ActiveClassTwodgt);
        btnClass.removeClass(ActiveClassName);
        btnClass.removeClass(ActiveClassThreedgt);
        paginationNumClass.addClass(ActiveClassTwodgt);
    }
    else {
        btnClass.removeClass(ActiveClassTwodgt);
        btnClass.removeClass(ActiveClassName);
        btnClass.removeClass(ActiveClassThreedgt);
        paginationNumClass.addClass(ActiveClassThreedgt);
    }
}
function NextButtonClick(btnClass, paginationNumClass, LastPageId, ActiveClassName, pageCount, ActiveClassTwodgt, ActiveClassThreedgt) {
    var currentText = loopVal;
    if (loopVal >= 4 && classId == 4 && (loopVal + 1) < pageCount) {
        loopVal = loopVal - 2;
        btnClass.each(function () {
            $(this).text(loopVal);
            loopVal = loopVal + 1;
        });
        AddAndRemoveClass(currentText + 1, classId, btnClass, paginationNumClass, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
    }
    else
        AddAndRemoveClass(currentText + 1, classId + 1, btnClass, LastPageId, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
}
function prevButtonClick(btnClass, paginationNumClass, LastPageId, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt, CurrentPageId) {
    var currentText = loopVal;
    if ((classId == 5 || classId > 2 || loopVal == 2) && loopVal >= classId) {
        AddAndRemoveClass(currentText - 1, classId - 1, btnClass, paginationNumClass, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
    }
    else if (classId == 2 && loopVal >= classId) {
        loopVal = loopVal - classId;
        btnClass.each(function () {
            $(this).text(loopVal);
            loopVal = loopVal + 1;
        });
        AddAndRemoveClass(currentText - 1, classId, btnClass, LastPageId, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
    }
    else
        AddAndRemoveClass(currentText - 1, classId - 1, btnClass, paginationNumClass, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
}
function showAndHidePages(PageCount, PageId, paginationBtndiv, className) {
    if (PageCount <= 5) {
        loopVal = 1;
        if (loopVal <= PageCount && PageId <= PageCount) {
            showPages(paginationBtndiv, className, loopVal);
        }
        hidePages(paginationBtndiv, className, (PageCount + 1));
    }
    else {
        showPages(paginationBtndiv, className, loopVal);
    }
}
function LoadEachButton(PaginationBtnName, PaginationBtnClass, ActivaClassSingleDgt, ActiveClassTwoDgt, ActiveClassThreeDgt, PageCount) {
    if (classId == 1) {
        if (loopVal == 1) {
            AddAndRemoveClass(loopVal, classId, PaginationBtnName, $(PaginationBtnClass + classId), ActivaClassSingleDgt,
                ActiveClassTwoDgt, ActiveClassThreeDgt);
        }
        else {
            AddAndRemoveClass(loopVal, classId + 1, PaginationBtnName, $(PaginationBtnClass + (classId + 1)), ActivaClassSingleDgt,
                ActiveClassTwoDgt, ActiveClassThreeDgt);
        }
        loopVal = loopVal - 1;
        PaginationBtnName.each(function () {
            if (loopVal > 0) {
                $(this).text(loopVal);
                loopVal = loopVal + 1;
            }
        });
    }
    else if (classId == 5) {
        if (loopVal == PageCount) {
            AddAndRemoveClass(loopVal, classId, PaginationBtnName, $(PaginationBtnClass + classId), ActivaClassSingleDgt,
                ActiveClassTwoDgt, ActiveClassThreeDgt);
        }
        else {
            AddAndRemoveClass(loopVal, classId - 1, PaginationBtnName, $(PaginationBtnClass + (classId - 1)), ActivaClassSingleDgt,
                ActiveClassTwoDgt, ActiveClassThreeDgt);
        }
        if (loopVal != PageCount) {
            loopVal = loopVal - 3;
            PaginationBtnName.each(function () {
                if (loopVal <= PageCount) {
                    $(this).text(loopVal);
                    loopVal = loopVal + 1;
                }
            });
        }
    }
    else {
        AddAndRemoveClass(loopVal, classId, PaginationBtnName, $(PaginationBtnClass + classId), ActivaClassSingleDgt,
            ActiveClassTwoDgt, ActiveClassThreeDgt);
    }
}
//pagination function ends*/


