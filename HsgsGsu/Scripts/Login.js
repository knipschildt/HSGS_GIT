
 var newURL = window.location.protocol + "//" + window.location.host + "/";
$("#btn-soeg").click(function () {
    var dataObj = { DEL: $("#selDEL").val(), HOLD: $("#selHOLD").val(), KursusID: $("#selKURSUS").val() };
    $("#messenger").html('');

    //***Start AJAX call*****
    $.ajax({
        url: newURL + 'QuizListes/Details',
        type: "POST",
        data: JSON.stringify(dataObj),
        datatype: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
           
            if (data.toString()==="") {
                $('#messenger').append("<a href='#' class='list-group-item' style='padding:5px 5px 5px 10px;'><div class=\"alert alert-danger\" role=\"alert\">Ingen gennemførte prøver ved denne søgning.</div></a>");
           
            } else {
                var x = 1;

            $.each(data, function (index, item) {
                $('#messenger').append("<a href='#' class='list-group-item' style='padding:5px 5px 5px 10px;'><table><tr><td width='13%'><span style='font-weight:bold;'>"+ x +"</span></td><td width='75%'>"+item.Navn+"</td><td align='right'><span class='badge badge-default'>" + item.Score + "</span></td><td width='12%' align='right'>" + item.DEL + "</td></tr></table></a>");
                x++;
            });
                   }
        },
        error: function (data) {
            alert("FEJL FEJL - i JSON string efter tryk på btn_soeg");
        },
        complete: function () {
           
        },
        async: true,
        processData: false
    });
    //***END AJAX call*****
});


//********************************************


$("#selHOLD").change(function () {
   
    var dataObj = { DEL: $("#selDEL").val(), HOLD: $("#selHOLD").val(), KursusID: $("#selKURSUS").val() };
    $.ajax({
        url: newURL + 'QuizListes/GetComboDEL',
        type: "POST",
        data: JSON.stringify(dataObj),
        datatype: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            
            var valgt = $("#selDEL").val();
            $("#selDEL").html('');
          
            $('#selDEL').append("<option>Alle DEL</option>");
               $.each(data[1], function (index, item) {
                     $('#selDEL').append("<option>" + item.DEL+"</option>");
               });
               
               for (i = 0; i < document.getElementById("selDEL").length; ++i) {
                   if (document.getElementById("selDEL").options[i].value === valgt) {
                      
                       var element = document.getElementById('selDEL');
                       element.value = valgt;
                   }
               }
        },
        error: function (data) {
            alert("FEJL FEJL - i JSON string efter tryk på HOLD select");
        },
        complete: function () {

        },
        async: true,
        processData: false
    });
  
});

//});
//$('#login').on('hidden.bs.modal', function (e) {
//    $("#messenger").html("");
//});

//$("#sletFil").click(function () {
    

//    var href = { Logo: $("#Logo").val(), CustomerId: $("#CustomerID").val() };

//    $("#visLogo").hide();
//    $("#visfil").show();

//    $.ajax({
//        type: "POST",
//        url: newURL + 'Customer/RemoveFileFromServer',
        
//        data: JSON.stringify(href),
//       contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: successFunc,
//        error: errorFunc
//    });

//    function successFunc(data, status) {
//        $("#Logo").val("");
//    }

//    function errorFunc() {
//        alert('Ingen forbindelse');
//    }
//});



      