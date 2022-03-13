function DeleteRow(input) {

    var td = event.target.parentNode;
    var tr = td.parentNode;

    fila = tr.cells;

    var precioTotal = document.getElementById("precioTotal")

    var getPrecio = parseFloat(precioTotal.innerHTML)

    getPrecio = getPrecio - parseFloat(fila[1].innerHTML)

    precioTotal.innerHTML = getPrecio

    tr.parentNode.removeChild(tr);
}