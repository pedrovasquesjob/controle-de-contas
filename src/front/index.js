$.get( "https://localhost:7113/api/Competencia", function( data ) {
    
    var html = "";
    html += "<h4>" + data[0].descricao + " - Total: " + data[0].total + "</h4>";
    html += "<input type='hidden' name='_id' id='_id' value='" + data[0].id + "'>";

    html += "<table class='table'>";
        html += "<thead>";
            html += "<tr>";
                html += "<th>Descrição</th>";
                html += "<th>Valor</th>";
            html += "</tr>";
        html += "</thead>";
        html += "<tbody>";

    $.each(data[0].contas, function(index, e){
            
            if(e.valorProvisorio)
                html += "<tr style='color:red;'>";
            
            if(e.pago)
                html += "<tr style='background-color:blue;'>";

                html += "<td>" + e.descricao + "</td>";
                html += "<td>" + e.valor + "</td>";
            html += "</tr>";
    });

        html += "</tbody>";
    html += "</table>";

    $("#info").html(html);

  });
  