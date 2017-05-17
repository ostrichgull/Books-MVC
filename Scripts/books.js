function GetCountryService(serviceUrl) {

    var stateId = $('#StateID').val();

    $.ajax({
        url: serviceUrl,
        type: "GET",
        dataType: "JSON",
        data: { stateId: stateId },
        success: function (countryName) {            
            $("#Country").val(countryName);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.html + ' ' + textStatus + ' ' + errorThrown);
        }
    });

}

function GetStateService(serviceUrl, cityField, stateField, countryField) {

    var cityId = $(cityField).val();

    $.ajax({
        url: serviceUrl,
        type: "GET",
        dataType: "JSON",
        data: { cityId: cityId },
        success: function (state) {
            $(stateField).val(state.Name);
            $(countryField).val(state.Country.Name);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.html + ' ' + textStatus + ' ' + errorThrown);
        }
    });

}

function GetAuthorsService(serviceUrl) {

    var name = $("#PersonID :selected").text();

    $.ajax({
        url: serviceUrl,
        type: "GET",
        dataType: "JSON",
        data: { name: name },
        success: function (authors) {
            $("#Authors").html("");
            $("#Authors").prop('disabled', false);
            $.each(authors, function (i, author) {
                $("#Authors").append(
                    $('<option></option>').val(author.ID).html(author.FirstName));
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.html + ' ' + textStatus + ' ' + errorThrown);
        }
    });
}

function uploadFile(input) {

    if (input.files && input.files[0]) {

        var reader = new FileReader();

        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }

    var filename = $('input[type=file]').val().split('\\').pop();
    $('#filename').val(filename);

}