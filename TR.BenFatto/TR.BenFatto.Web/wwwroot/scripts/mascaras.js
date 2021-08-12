$().ready(function() {
 
    //MASCARA PARA O CAMPO CPF
    $("#txtCPF").mask("999.999.999-99");
    $("#txtCnpj").mask("99.999.999/9999-99");
    

    //MASCARA PARA O CAMPO CEP
    $("#txtCep").mask("99999-999");
    $("#txtCepResp").mask("99999-999");
    

    //MASCARA PARA O CAMPO DATA
    $("#txtDataPagamento").mask("99/99/9999");
    $("#txtDataVencimento").mask("99/99/9999");
    $("#txtDataNascimento").mask("99/99/9999");
    $("#txtDataContrato").mask("99/99/9999");
    $("#txtDataAdesao").mask("99/99/9999");
    $("#txtDataTermino").mask("99/99/9999");
    $("#txtDataPrimeiroPagamento").mask("99/99/9999");
    $("#txtDataPrimeiroVencimento").mask("99/99/9999");
    $("#txtDataInicio").mask("99/99/9999");
    $("#txtDataFim").mask("99/99/9999");
    $("#txtDataInicioAdesao").mask("99/99/9999");
    $("#txtDataFimAdesao").mask("99/99/9999");
    $("#txtDataInicioVisao").mask("99/99/9999");
    $("#txtDataFimVisao").mask("99/99/9999");
    $("#txtDataInicioCustoPrestador").mask("99/99/9999");
    $("#txtDataFimCustoPrestador").mask("99/99/9999");
    $("#txtDataOcorrencia").mask("99/99/9999");
    $("#txtDataColeta").mask("99/99/9999");
    $("#txtDataAplicacao").mask("99/99/9999");
    $("#txtDataProximaAplicacao").mask("99/99/9999");
    $("#txtDataFabricacao").mask("99/99/9999");
    $("#txtDataValidade").mask("99/99/9999");
    $("#txtDataInicioProximaAplicacao").mask("99/99/9999");
    $("#txtDataFimProximaAplicacao").mask("99/99/9999");
    $("#txtDataAtendimento").mask("99/99/9999");
    $("#txtDataNascimentoTutor").mask("99/99/9999");
    $("#txtDataFato").mask("99/99/9999");
    $("#txtDataPrescricao").mask("99/99/9999");
    $("#txtDataSuspensao").mask("99/99/9999");
    $("#txtDataEncerramento").mask("99/99/9999");
    
    
    //MASCARA PARA O CAMPO HORA
    $("#TabContainer1_Geral_txtDGHoraInicio").mask("99:99");
    $("#TabContainer1_Geral_txtDGHoraFim").mask("99:99");
    $("#txtHoraInicio").mask("99:99");
    $("#txtHoraFim").mask("99:99");
    $("#txtHoraAtendimento").mask("99:99");

    //MASCARA PARA OS CAMPOS TELEFONE E CELULAR
    $("#txtTelefoneResidencial").mask("(99)9999-9999");
    $("#txtTelefoneComercial").mask("(99)9999-9999");
    $("#txtTelefone").mask("(99)9999-9999");
    $("#txtCelular").mask("(99)99999-9999");

    /*$("#txtValor").mask("#########,##");*/
    $("#txtValor").inputmask({ alias: "currency" });
});


