$(document).ready( function(){ 
    CarregarCursos();
});

function CarregarCursos(){
    var urlServico = "https://localhost:7058/api/Academia/Curso/0/0";

    $.get(urlServico, function (retorno, status) {
        if (retorno.lenght == 0) {
            alert("Erro ao obter os dados.");
        }
        else {
            for (var i = 0; i <retorno.length; i++) {
                var curso = retorno[i];

                var linha = '';
                linha += "<tr>";
                linha += "<td>"+ curso.nomeCurso +"</td>";
                linha += "</tr>";

                $("#tblCursos tbody").append(linha);
            }
        }
    });
}