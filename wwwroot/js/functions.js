$(document).ready(function () {
    $('#nombrePais').autocomplete({
        source: function (request, response) {
            $.getJSON('/Home/AutocompleteSearch', { term: request.term }, function (data) {
                response(data);
            });
        },
        minLength: 2
    });

    $('#buscarPaisesBtn').click(function (e) {
        e.preventDefault();
        var paisNombre = $('#nombrePais').val();
        buscarIdiomasPorPais(paisNombre);
    });
});

function buscarIdiomasPorPais(paisNombre) {
    $.ajax({
        url: '/Home/BuscarIdiomasPorPais',
        type: 'POST',
        dataType: 'json',
        data: {
            nombrePais: paisNombre,
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
        },
        success: function (idiomas) {
            var tbody = $('#tablaIdiomas tbody');
            tbody.empty();
            idiomas.forEach(function (idioma) {
                tbody.append(
                    `<tr>
                        <td>${idioma.language}</td>
                        <td>${idioma.isOfficial ? 'Sí' : 'No'}</td>
                        <td>${idioma.percentage}%</td>
                    </tr>`
                );
            });
        },
        error: function (xhr) {
            alert('Error: ' + xhr.statusText);
        }
    });
}
