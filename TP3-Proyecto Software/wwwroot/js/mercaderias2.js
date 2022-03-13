let dropdownTipoMercaderiaComanda = document.getElementById('tipoMercaderiasComandas-dropdown');
dropdownTipoMercaderiaComanda.length = 0;

let defaultOption2 = document.createElement('option');
defaultOption2.text = 'Elegir tipo de mercaderia';

dropdownTipoMercaderiaComanda.add(defaultOption2);
dropdownTipoMercaderiaComanda.selectedIndex = 0;

const url2 = 'https://localhost:5001/api/TipoMercaderia';

fetch(url2)
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
                dropdownTipoMercaderiaComanda.add(option);

                for (let i = 0; i < data.length; i++) {
                    option = document.createElement('option');
                    option.text = data[i].descripcion;
                    option.value = data[i].id;
                    dropdownTipoMercaderiaComanda.add(option);
                }
            });
        }
    )
    .catch(function (err) {
        console.error('Fetch Error -', err);
    });