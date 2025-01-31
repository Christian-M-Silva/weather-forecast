document.addEventListener("DOMContentLoaded", function () {
    $.ajax({
        url: `/ListProduct`,
        type: "GET",
        success: (response) => {
            renderTable(response)
        }
    });
});

function renderTable(products) {
    const tabelaBody = document.querySelector("#tabelaProdutos tbody");
    tabelaBody.innerHTML = "";

    products.forEach(product => {
        const row = `
            <tr>
                <td>${product.marcaComercial[0]}</td>
                <td>${product.formulacao}</td>
                <td>${product.tecnicaAplicacao.join(', ') }</td>
                <td>${product.classificacaoToxicologica}</td>
                <td>${product.classificacaoAmbiental}</td>


            </tr>
        `;
        tabelaBody.innerHTML += row;
    });
}
