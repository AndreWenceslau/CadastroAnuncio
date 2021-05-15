$(document).ready(function () {
    $("#valor-investido").mask('000.000,00', { reverse: true });
    $("#valor-investido").val("");
    $("#data-inicio").mask('00/00/0000');
    $("#data-termino").mask('00/00/0000');
});

$(document).submit(function () {
    $("#valor-investido").val().replace(',', '.');
});