const API = "http://localhost:5179/api/Servicos";

async function listarServicos() {

    const resposta = await fetch(API);

    const servicos = await resposta.json();

    const lista = document.getElementById("lista-servicos");

    lista.innerHTML = "";

    servicos.forEach(servico => {

        lista.innerHTML += `
            <div class="servico">

                <h3>${servico.nome}</h3>

                <p>${servico.descricao}</p>

                <p>Preço: R$ ${servico.preco}</p>

                <p>Duração: ${servico.duracaoMinutos} min</p>

                <button onclick="deletarServico(${servico.id})">
                    Excluir
                </button>

            </div>
        `;
    });
}

async function cadastrarServico() {

    const servico = {

        nome: document.getElementById("nome").value,

        descricao: document.getElementById("descricao").value,

        preco: parseFloat(document.getElementById("preco").value),

        duracaoMinutos: parseInt(document.getElementById("duracao").value)
    };

    await fetch(API, {

        method: "POST",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(servico)
    });

    listarServicos();
}

async function deletarServico(id) {

    await fetch(`${API}/${id}`, {

        method: "DELETE"
    });

    listarServicos();
}

listarServicos();