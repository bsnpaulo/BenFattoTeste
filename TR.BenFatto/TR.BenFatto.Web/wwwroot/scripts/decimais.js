

$().ready(function() {


    $("#txtAliquotaIss").maskMoney({ allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
    $("#txtValor").maskMoney({ allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
    $("#txtDesconto").maskMoney({ allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
    $("#txtPorcentagem").maskMoney({ allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });


});

