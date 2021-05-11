$(document).ready(function () {
    $("#valor-investido").mask('000.000,00', { reverse: true });
    $("#valor-investido").val("");
});

$(document).submit(function () {
    $("#valor-investido").val().replace(',', '.');
});