const API_SERVICOS = "http://localhost:5179/api/Servicos";

const API_CLIENTES = "http://localhost:5179/api/Clientes";

function mostrarDashboard() {

    document.getElementById("dashboard").style.display = "block";

    document.getElementById("servicos").style.display = "none";

    document.getElementById("clientes").style.display = "none";

    carregarDashboard();
}

function mostrarServicos() {

    document.getElementById("dashboard").style.display = "none";

    document.getElementById("servicos").style.display = "block";

    document.getElementById("clientes").style.display = "none";

    listarServicos();
}

function mostrarClientes() {

    document.getElementById("dashboard").style.display = "none";

    document.getElementById("servicos").style.display = "none";

    document.getElementById("clientes").style.display = "block";

    listarClientes();
}

async function carregarDashboard() {

    const respostaServicos = await fetch(API_SERVICOS);

    const servicos = await respostaServicos.json();

    document.getElementById("total-servicos").innerText =
        servicos.length;

    const respostaClientes = await fetch(API_CLIENTES);

    const clientes = await respostaClientes.json();

    document.getElementById("total-clientes").innerText =
        clientes.length;
}

async function listarServicos() {

    const resposta = await fetch(API_SERVICOS);

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

                <div class="acoes">

                    <button onclick="deletarServico(${servico.id})">
                        Excluir
                    </button>

                </div>

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

    await fetch(API_SERVICOS, {

        method: "POST",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(servico)
    });

    listarServicos();

    limparFormulario();

    carregarDashboard();
}

async function deletarServico(id) {

    await fetch(`${API_SERVICOS}/${id}`, {

        method: "DELETE"
    });

    listarServicos();

    carregarDashboard();
}

async function listarClientes() {

    const resposta = await fetch(API_CLIENTES);

    const clientes = await resposta.json();

    const lista = document.getElementById("lista-clientes");

    lista.innerHTML = "";

    clientes.forEach(cliente => {

        lista.innerHTML += `
            <div class="servico">

                <h3>${cliente.nome}</h3>

                <p>${cliente.email}</p>

            </div>
        `;
    });
}

function limparFormulario() {

    document.getElementById("nome").value = "";

    document.getElementById("descricao").value = "";

    document.getElementById("preco").value = "";

    document.getElementById("duracao").value = "";
}

document
    .getElementById("botao-form")
    .addEventListener("click", cadastrarServico);

carregarDashboard();