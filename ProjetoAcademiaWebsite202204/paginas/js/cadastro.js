$(document).ready(function(){
    $('#btnConfirmar').click(function(){
        CadastrarAluno();
    });

    $('#btnCancelar').click(function(){
        Cancelar();
    });
});

function CadastrarAluno(){

    var cadastrar = {
        idAluno: 0,
        alunoMatricula: 0,
        alunoCpf: "string",
        alunoSexo: "string",
        alunoDataNasc: "2022-08-08T19:37:25",
        idUsuario: 0,
        usuarioAtivo: true,
        nomeUsuario: "string",
        emailUsuario: "string",
        senhaUsuario: "string",
        tipoUsuario: "string",
        idEndereco: 0,
        enderecoCep: 0,
        enderecoIdUf: 0,
        enderecoUf: "string",
        enderecoIdCidade: 0,
        enderecoCidade: "string",
        enderecoBairro: "string",
        enderecoRua: "string",
        enderecoNumero: 0,
        enderecoComplemento: "string"
    }

    cadastrar.nomeUsuario = $('#txtNome').val();
    cadastrar.emailUsuario = $('#txtEmail').val();
    cadastrar.senhaUsuario = $('#txtSenha').val();
    cadastrar.enderecoCep = $('#txtCep').val();
    cadastrar.enderecoUf = $('#txtSigla').val();
    cadastrar.enderecoCidade = $('#txtCidade').val();
    cadastrar.enderecoBairro = $('#txtBairro').val();
    cadastrar.enderecoRua = $('#txtRua').val();
    cadastrar.enderecoNumero = $('#txtNumero').val();
    cadastrar.enderecoComplemento = $('#txtComplemento').val();
    cadastrar.alunoCpf = $('#txtCpf').val();
    cadastrar.alunoSexo = $('#txtSexo').val();
    cadastrar.alunoDataNasc = $('#txtDtNascimento').val();

    var urlServico = 'https://localhost:7058/api/Academia/Cadastro';

    $.ajax({
        url: urlServico,
        type: 'post',
        dataType: 'json',
        data: JSON.stringify(cadastrar),
        dataType: 'application/json;',
        success: function (data) {
            alert('Cadastro feito com sucesso, ' + data.nomeUsuario + '.');
            Cancelar();
        }          
    });
}

function Cancelar(){
    window.location = 'home.html';
}


