document.addEventListener("DOMContentLoaded", function () {
    $.ajax({
        url: `/ListProduct`,
        type: "GET",
        success: (response) => {
            const jsonData = JSON.parse(response);
            renderizarTabela(jsonData)
        }
    });
});

function renderizarTabela(produtos) {
    const tabelaBody = document.querySelector("#tabelaProdutos tbody");
    tabelaBody.innerHTML = ""; // Limpa o conteúdo antes de inserir

    produtos.forEach(produto => {
        const linha = `
            <tr>
                <td>${produto.marca_comercial[0]}</td>
                <td>${produto.formulacao}</td>
                <td>${produto.tecnica_aplicacao.join(', ') }</td>
                <td>${produto.classificacao_toxicologica}</td>
                <td>${produto.classificacao_ambiental}</td>


            </tr>
        `;
        tabelaBody.innerHTML += linha;
    });
}
