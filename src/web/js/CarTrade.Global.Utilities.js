/////////////////////////////////////////////////////////////////////////////////////
// This Util JS Lib used for CarTrade website UI rendering
//
///  Ramkumar Krishnan
/// 
/////////////////////////////////////////////////////////////////////////////////////////

(function (window, undefined) {

// Global configurations / Variables //

var apiUrl = 'http://localhost:52858/api/';

var $CARTRADE = function (properties) {
    if (window === this) {
        return new $CARTRADE(properties);
    }
    if (typeof properties === 'string')
        var result = document.querySelectorAll(properties);
    if (result.length > 0) {
        for (var i = 0; i < result.length; i++) {
            this[i] = result[i];
        }
        this.length = result.length;
    }
    return this;
};
$CARTRADE.fn = $CARTRADE.prototype = {
    PaintBrands: function () {
        var divObj = this[0];
        $.ajax({
            url: apiUrl + "brand",
            method: "GET",
            crossOrigin: true,
            async: false,
            headers: { "Accept": "application/json; odata=verbose" },
            beforeSend: function () {
                $(divObj).html('<div class="loading"><img src="img/ajax-loader.gif" alt="Loading..." /></div>');
            },
            success: function (data) {
                var brandHtml='';
                for (var i = 0; i < data.length; i++) {
                    var brandIDBinding = "LoadCars('" + data[i].BrandID + "','" + data[i].BrandName.capitalize() + "')";
                    var createCarFunc = "SetBrand('" + data[i].BrandID + "','" + data[i].BrandName.capitalize() + "')";
                    brandHtml += '<div class="col-md-3"> <div class="thumbnail">';
                    brandHtml += '<img src="' + data[i].BrandLogo + '" class="img-responsive">';
                    brandHtml += '<div class="caption"><h3 style="color:#fff">' + data[i].BrandName.capitalize() + '</h3>';
                    brandHtml += '<p>' + data[i].BrandDescription + '</p>';
                    brandHtml += '<p><a class="btn btn-primary btn-viewCars" href="#contact" onclick="' + brandIDBinding + '" role="button">View Cars</a> <a class="btn btn-primary btn-viewCars" href="#createCarForm" onclick="' + createCarFunc + '" role="button">Add CAR</a></p>';
                    brandHtml += '</div></div></div>';
                }
                $('#brandsList').html(brandHtml);
            },
            error: function (data) {
                $('#brandsList').html('<H4> Problem in Loading Content .No Brands in the data source</h4>');
            }
        });
    },
};
window.LoadCars = function (brandID, brandName)
{
    $('#listOfCarsInBrand').show();
    $('#createCarForm').hide();
    $('#successInfo').hide();
    $.ajax({
        url: apiUrl + "cars/",
        method: "GET",
        crossOrigin: true,
        async: false,
        headers: { "Accept": "application/json; odata=verbose" },
        beforeSend: function () {
            $('#listOfCarsInBrand').html('<div class="loading"><img src="img/ajax-loader.gif" alt="Loading..." /></div>');
        },
        success: function (data) {
            var html = '<h2 class="section-heading">Cars of ' + brandName +'</h2><div class="panel panel-default">';
            html += '<table class="table table-striped table-carTrade"> <thead><tr><th>Model Name</th> <th> Model Year</th> <th> Fuel Type</th>';
            html += '<th> Aspiration</th><th> Body Style </th> <th>Drive Wheels</th><th>Wheel Base</th><th>Length</th><th>Height</th><th>City Milleage</th><th>Price</th><th>Manage</th></tr> <tbody>';
            for (var i = 0; i < data.length; i++) {
                if (data[i].BrandID === parseInt(brandID))
                {
                    var carIDBinding = "DeleteCar('" + data[i].CarID + "','" + data[i].BrandID + "','" + brandName + "')";
                    html += '<tr><td class="table-carHeader">' + data[i].ModelName + '</td><td>' + data[i].ModelYear + '</td><td>' + data[i].FuelType + '</td>';
                    html += '<td>' + data[i].Aspiration + '</td><td>' + data[i].BodyStyle + '</td><td>' + data[i].DriveWheels + '</td>';
                    html += '<td>' + data[i].WheelBase + '</td><td>' + data[i].Length + '</td><td>' + data[i].DriveWheels + '</td>';
                    html += '<td>' + data[i].CityMilleage + '</td><td>' + data[i].Price + '</td><td><a class="btn btn-primary btn-viewCars" href="#contact" onclick="' + carIDBinding + '" role="button">Delete</a></td></tr>';
                }                
            }
            html +='</tbody></table></div>'
            $('#listOfCarsInBrand').html(html);
        },
        error: function (data) {
            $('#listOfCarsInBrand').html('<H4> Problem in Loading Content .No Brands in the data source</h4>');
        }
    });
   
}
window.DeleteCar = function (carID, brandID, brandName)
{
    $.ajax({
        url: apiUrl + "cars/" + carID,
        method: "DELETE",
        crossOrigin: true,
        async: false,
        headers: { "Accept": "application/json; odata=verbose" },
        beforeSend: function () {

        },
        success: function (data) {
            LoadCars(brandID, brandName)
        },
        error: function (data) {
        }
    });
}
window.SetBrand = function (brandID, brandName) {  
    $('#createCarForm').show();
    $('#listOfCarsInBrand').hide();
    $('#registerCarHeading').html('<h2 class="section-heading">Register New Car Variant of <b>' + brandName.toUpperCase() + '</b> </h2><br>');
    document.getElementById("BrandID").value = brandID;
}
window.CreateCar = function (brandID, brandName) {

    document.getElementById("CarID").value = Math.floor(Math.random() * 1000);

    (function ($) {
        function processCarRegistrationForm(e) {
            $.ajax({
                url: apiUrl + 'cars',
                dataType: 'text',
                type: 'post',
                contentType: 'application/x-www-form-urlencoded',
                data: $(this).serialize(),
                success: function (data, textStatus, jQxhr) {
                    $('#successInfo').show();
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });

            e.preventDefault();
        }

        $('#newCarForm').submit(processCarRegistrationForm);
    })(jQuery);
}
String.prototype.capitalize = function () {
    return this.charAt(0).toUpperCase() + this.slice(1);
}
//// Helper Functions - Methods  ////
window.htmlEncode = function (value) {
    //create a in-memory div, set it's inner text(which jQuery automatically encodes)
    //then grab the encoded contents back out.  The div never exists on the page.
    return $('<div/>').text(value).html();
}
window.htmlDecode= function (value) {
    return $('<div/>').html(value).text();
}
var pageName = (function () {
    var a = window.location.href,
        b = a.lastIndexOf("/");
    return a.substr(b + 1);
}());
window.$CARTRADE = $CARTRADE;
})(window);