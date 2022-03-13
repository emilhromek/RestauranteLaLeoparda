let dropdowntipoMercaderiasInformacion = document.getElementById('tipoMercaderiaInformacion-dropdown');
dropdowntipoMercaderiasInformacion.length = 0;

let defaultOption3 = document.createElement('option');
defaultOption3.text = 'Elegir tipo de mercaderia';

dropdowntipoMercaderiasInformacion.add(defaultOption3);
dropdowntipoMercaderiasInformacion.selectedIndex = 0;

const url3 = 'https://localhost:5001/api/TipoMercaderia';

fetch(url3)
    .then(
        function (response) {
            if (response.status !== 200) {
                console.warn('Looks like there was a problem. Status Code: ' +
                    response.status);
                return;
            }

            // Examine the text in the response
            response.json().then(function (data) {
                let option;

                option = document.createElement('option');
                option.text = 'Todas las mercaderias';
                option.value = 0;
                dropdowntipoMercaderiasInformacion.add(option);

                for (let i = 0; i < data.length; i++) {
                    option = document.createElement('option');
                    option.text = data[i].descripcion;
                    option.value = data[i].id;
                    dropdowntipoMercaderiasInformacion.add(option);
                }
            });
        }
    )
    .catch(function (err) {
        console.error('Fetch Error -', err);
    });