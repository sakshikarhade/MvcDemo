
$(document).ready(function(){
    GetRegistrationList();
    RedirectDetails();

});
var Savereg = function () {
    debugger;
    var id = $("#HdnName").val();
    var name = $("#txtName").val();
    var mobile_no = $("#txtmobile_no").val();
    var city = $("#city").val();
    var address = $("#txtAddress").val();

    if (name == "") {
        alert("please enter your Name");
    }

    else if (mobile_no == ""){
        alert("please enter your mobile no");
    }

    else if (city == "") {
        alert("please select your city");
    }

    else if  (address == "") {
        alert("please enter your address");
    }

    var model = {
        Id:id,
        Name: name,
        Mobile_no: mobile_no,
        City: city,
        Address: address,
    };  
    $.ajax({
        url: "/Registration/Savereg",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
            GetRegistrationList();
        },
        error: function (response) {
            alert(response.Message);
        }

    });
} 

var GetRegistrationList = function () {
    debugger;
    $.ajax({
        url: "/Registration/GetRegistrationList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            var html = "";
            $("#tblContact tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Srno +
                    "</td><td>" + elementValue.Id +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Mobile_no +
                    "</td><td>" + elementValue.Address +
                    "</td><td>" + elementValue.City +
                    "</td><td><input type='button' value='Delete' class='btn btn-danger'onclick='DeleteRegistration(" + elementValue.Id + ")'/>&nbsp; <input type='button' value='Edit' class='btn btn-success' onclick='GetRegisterbyId(" + elementValue.Id + ")'/>&nbsp<input type='button' value='Redirect Details' class='btn btn-info' onclick='Details(" + elementValue.Id + ")'/></td></tr>";
            });
            $("#tblContact tbody").append(html);
        }
    });
}

var DeleteRegistration = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/Registration/DeleteRegistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            GetRegistrationList();
        },
        error: function (response) {
            alert(response.model);
        }

    });
}

 var GetRegisterbyId = function (Id) {
        debugger;
        model = { Id: Id }
        $.ajax({
            url: "/Registration/GetRegisterbyId ",
            method: "post",
            data: JSON.stringify(model),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#HdnName").val(response.model.Id);
                $("#txtName").val(response.model.Name);
                $("#txtmobile_no").val(response.model.Mobile_no);
                $("#city").val(response.model.City);
                $("#txtAddress").val(response.model.Address);
            }
        });
}

var Details = function (Id) {
    window.location.href = "/Registration/DetailIndex?Id=" + Id;
}

var RedirectDetails = function () {
    var Id = $("#HdnName").val();
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/Registration/GetRegisterbyId ",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#HdnName").text(response.model.Id);
            $("#txtName").text(response.model.Name);
            $("#txtmobile_no").text(response.model.Mobile_no);
            $("#city").text(response.model.City);
            $("#txtAddress").text(response.model.Address);
        }
    });
}