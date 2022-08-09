$(document).ready( function(){ 
    CarregarAluno();
    
});

function CarregarAluno(){
  var id = localStorage.getItem('idUsuario');

  var urlServico = 'https://localhost:7058/api/Academia/Aluno/porusuario/' + id ;
  $.get(urlServico, function(retorno,status){
    if (retorno == undefined) {

        alert('Aluno não encontrado!!!');

    }
    else {
        var linha = '';
        linha += "<tr>";
        linha += "<td>" + retorno.alunoMatricula + "</td>";  
        linha += "<td>" + retorno.alunoCpf + "</td>";  
        linha += "<td>" + retorno.alunoNome + "</td>";  
        linha += "<td>" + retorno.alunoSexo + "</td>";   
        linha += "<td>" + retorno.alunoEmail + "</td>";  
        // linha += '<td><button id="btnALTERAR" onclick="AcionarAlteracao('+ retorno.idAluno +');">Alterar</button></td>'; 
        linha += '<td><a href="alteracaopagina.html?usuarioid=' + retorno.idAluno + '">Alterar</a></td>';
        linha += "</tr>";
        
        $("#tblALUNO tbody").append(linha);

    }
});
}