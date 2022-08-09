$(document).ready( function(){ 
    CarregarAluno();
    
});

function CarregarAluno(){
    //var id = localStorage.getItem('usuarioid', id);
    var id = getUrlVars()["usuarioid"];
    localStorage.setItem('usuarioid', id);
    var urlServico = 'https://localhost:7058/api/Academia/Aluno/' + id ;
    $.get(urlServico, function(retorno,status){
      if (retorno == undefined) {
  
          alert('Perfil aluno não encontrado!!!');
  
      }
      else {
        var aluno = JSON.stringify(retorno);
        localStorage.setItem('aluno', aluno);

        $('#txtMATRICULA').val(retorno.alunoMatricula);
        $('#txtMATRICULA').prop('disabled',true);
        $('#txtCPF').val(retorno.alunoCpf);
        $('#txtCPF').prop('disabled',true);
        $('#txtNOME').val(retorno.alunoNome);
        $('#txtSEXO').val(retorno.alunoSexo);
        $('#txtEMAIL').val(retorno.alunoEmail);
       
  
      }
  });
  }


  function AcionarAlteracao(){
   var temp = localStorage.getItem('aluno');
    var aluno = JSON.parse(temp);
    aluno.alunoMatricula = $('#txtMATRICULA').val();
    aluno.alunoCpf = $('#txtCPF').val();
    aluno.alunoNome = $('#txtNOME').val();
    aluno.alunoSexo = $('#txtSEXO').val();
    aluno.alunoEmail = $('#txtEMAIL').val();
    
    var urlServico = 'https://localhost:7058/api/Academia/Aluno';

    console.log(aluno);
    $.ajax({
        url: urlServico,
        type: 'put',
        dataType: 'json',
        data: JSON.stringify(aluno),
        contentType: 'application/json; charset=utf-8',
        success: function(data, status, xhr){
            console.log(data);
            console.log(status);
            //alert('Aluno alterada com sucesso (Nome: '+ data.alunoNome +').');
            //window.location = 'perfilpagina.html';
        }
    })
    .done(function(){
        alert('Aluno alterada com sucesso (Nome: '+ data.alunoNome +').');
        window.location = 'perfilpagina.html';
    });

}