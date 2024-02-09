$(document).ready(function () {
    // Configuración de autocompletado
    $('#nombrePais').autocomplete({
        source: function (request, response) {
            $.getJSON('/Home/AutocompleteSearch', { term: request.term }, function (data) {
                response(data);
            });
        },
        minLength: 2,
        select: function (event, ui) {
            $('#nombrePais').val(ui.item.value);
            buscarIdiomasPorPais(ui.item.value);
        }
    });

    // Manejador de eventos para el botón de búsqueda
    $('#buscarPaisesBtn').on('click', function (e) {
        e.preventDefault();
        buscarIdiomasPorPais($('#nombrePais').val());
    });
});

function buscarIdiomasPorPais(paisNombre) {
    if (!paisNombre) {
        alert('Por favor, ingresa un nombre de país.');
        return;
    }

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
                        <td>${idioma.percentage}</td>
                    </tr>`
                );
            });
        },
        error: function (xhr, status, error) {
            alert('Error: No se pudo obtener la información de los idiomas.');
        }
    });
}
