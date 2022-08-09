$(document).ready( function(){

    $('#btnConfirmar').click(function() {
        var ema = $('#eml').val();
        var sen = $('#pwd').val();
        AcionarValidacao(ema, sen);
    });
});

function AcionarValidacao(email, senha) {

    if (senha === ''){
        alert('Senha não pode ser nula ou vazia.');
        return;
    }

    var urlServico = 'https://localhost:7058/api/Academia/Usuario/email/' + email + "/senha/" + senha;

    $.get(urlServico, function(retorno,status){
        if (retorno == undefined) {

            alert(' E-mail não encontrado!!!');

        }
        else {
            var codigo = retorno.idUsuario;
            localStorage.setItem('idUsuario',codigo);
            window.location = 'perfilpagina.html';            
        }
    });

}

