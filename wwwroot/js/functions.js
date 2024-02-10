$(document).ready(function () {
    $('#nombrePais').autocomplete({
        source: function (request, response) {
            $.getJSON('/Home/AutocompleteSearch', { term: request.term }, function (data) {
                response(data);
            });
        },
        minLength: 2
    });

    // Comentario para indicar un ejemplo de búsqueda
    $('<p class="comentario-busqueda">Por ejemplo: Australia</p>').insertAfter('.search-container');

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
            var labels = [];
            var data = [];
            idiomas.forEach(function (idioma) {
                tbody.append(
                    `<tr>
                        <td>${idioma.languaje}</td>
                        <td>${idioma.isOfficial === 'T' ? 'Sí' : 'No'}</td>
                        <td>${idioma.percentage}%</td>
                    </tr>`
                );
                labels.push(idioma.languaje); 
                data.push(idioma.percentage);
            });
            dibujarGrafico(labels, data);
        },
        error: function (xhr) {
            alert('Error: ' + xhr.statusText);
        }
    });
}



function dibujarGrafico(labels, data) {
    var ctx = document.getElementById('idiomasChart').getContext('2d');
    if (window.miGrafico) {
        window.miGrafico.destroy();
    }
    window.miGrafico = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: '%',
                data: data,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'center',
                },
                title: {
                    display: true,
                    text: 'Representación de idiomas',
                },
            
                // Ajusta el tamaño del gráfico
                maintainAspectRatio: false,
                aspectRatio: 1.2
            }
        }


    });





  
}
