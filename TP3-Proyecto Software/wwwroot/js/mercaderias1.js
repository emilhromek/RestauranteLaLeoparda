let dropdownFormaEntregaComanda = document.getElementById('formaEntregaComandas-dropdown');
dropdownFormaEntregaComanda.length = 0;

let defaultOption = document.createElement('option');
defaultOption.text = 'Elegir forma de entrega';

dropdownFormaEntregaComanda.add(defaultOption);
dropdownFormaEntregaComanda.selectedIndex = 0;

const url = 'https://localhost:5001/api/FormaEntrega';

fetch(url)
    .then(
        function (response) {
            if (response.status !== 200) {
                console.warn('Looks like there was a problem. Status Code: ' +
                    response.status);
                return;
            }

            response.json().then(function (data) {
                let option;

                for (let i = 0; i < data.length; i++) {
                    option = document.createElement('option');
                    option.text = data[i].descripcion;
                    option.value = data[i].id;
                    dropdownFormaEntregaComanda.add(option);
                }
            });
        }
    )
    .catch(function (err) {
        console.error('Fetch Error -', err);
    });