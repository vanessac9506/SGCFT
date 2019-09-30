function cadastra_usr() {
    var cpf_cnpj = document.getElementById("cpf_cnpj_cadastro").value;
    var nome = document.getElementById("nome_cadastro").value;
    var senha = document.getElementById("senha_cadastro").value;
    var confirma_senha = document.getElementById("confirma_senha_cadastro").value;
    var email = document.getElementById("email_cadastro").value;

    if (nome == "" || senha == "" || confirma_senha == "" || email == "" || cpf_cnpj =="")
    {
        alert("CAMPOS NAO FORAM PREENCHIDOS!");
        return;
    }
    if (senha != confirma_senha) {
        alert("SENHA INVALIDA");
        document.getElementById("senha_cadastro").value = "";
        document.getElementById("confirma_senha_cadastro").value = "";
        return;
    }
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            if (al.responseText == 1) {
                document.getElementById("cpf_cnpj_cadastro").value = "";
                document.getElementById("nome_cadastro").value = "";
                document.getElementById("senha_cadastro").value = "";
                document.getElementById("confirma_senha_cadastro").value = "";
                document.getElementById("email_cadastro").value = "";

            }
            else
                alert("Falha");
        }
    }
    al.open("GET", "usuario_srv?cpf_cnpj=" + cpf_cnpj + "&nome=" + nome + "&senha=" + senha + "&email=" + email, true);
    al.send();
}

function login() {
    var cpf_cnpj = document.getElementById("cpf_cnpj_login").value;
    var senha = document.getElementById("senha_login").value;
    if (cpf_cnpj == "" || senha == "") {
        alert("DADOS INVALIDOS");
        document.getElementById("cpf_cnpj_login").value = "";
        document.getElementById("senha_login").value = "";
        return;
    }
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            //document.getElementById("principal").innerHTML = al.responseText; como fica ?
        }
    }
    al.open("GET", "usuario_srv?cpf_cnpj=" + cpf_cnpj + "&senha=" + senha, true);
    al.send();
}

function criar_treinamento() {
    var tema = document.getElementById("tema").value;
    var tipo = document.getElementById("tipo").value;
    var id_autor = document.getElementById("id_autor").value;
    var senha = document.getElementById("senha_cadastro").value;
  

    if (tema == "" || tipo == "" || senha == "") {
        alert("CAMPOS NAO FORAM PREENCHIDOS!");
        return;
    }
    if (id_modulo == "") {
        alert("Módulo não criado");
        return;
    }
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            if (al.responseText == 1) {
                document.getElementById("tema").value = "";
                document.getElementById("tipo").value = "";
                document.getElementById("senha").value = "";
            }
            else
                alert("Falha");
        }
    }
    al.open("GET", "usuario_srv?tema=" + tema + "&tipo=" + tipo + "&senha=" + senha + "id_autor=" + id_autor + "id_modulo=" + id_modulo, true);
    al.send();
}

function criar_modulo() {
    var tema = document.getElementById("tema").value;
    var tipo = document.getElementById("tipo").value;
    var id_autor = document.getElementById("id_autor").value;
    var senha = document.getElementById("senha_cadastro").value;
    var id_treinamento = 
	
	
	if (tema == "" || tipo == "" || senha == "") {
        alert("CAMPOS NAO FORAM PREENCHIDOS!");
        return;
    }
    if (id_modulo == "") {
        alert("Módulo não criado");
        return;
    }
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            if (al.responseText == 1) {
                document.getElementById("tema").value = "";
                document.getElementById("tipo").value = "";
                document.getElementById("senha").value = "";
            }
            else
                alert("Falha");
        }
    }
    al.open("GET", "usuario_srv?tema=" + tema + "&tipo=" + tipo + "&senha=" + senha + "id_autor=" + id_autor + "id_modulo=" + id_modulo, true);
    al.send();
}

function cadastrar_pergunta() {

}

function cadastrar_alternativa() {

}

function guardar_resposta() {

}

function criar_quiz() {

}

function acessar_treinamento() {

}

function sair() {
    var op = 3;
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            alert("VOLTE SEMPRE !!");

        }
    }
    al.open("GET", "usuario_srv?op=" + op, true);
    al.send();
}



function upload_video() {
    // como fazer ?
    /*var file = document.getElementById("arquivo");
    var fd = new FormData();
    fd.append("file", file.files[0]);
	
    var up = new XMLHttpRequest();
    up.onreadystatechange = function()
    {
        if(up.readyState == 4)
            document.getElementById("saida").innerHTML = up.responseText;
    }
    up.open("POST", "Arquivo_srv", true);
    up.send(fd);*/

}



function lista_treinamentos_publicos() {
    //var op = 5;
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            document.getElementById("lista_treinamentos_publicos").innerHTML = al.responseText;
        }
    };
    al.open("GET", "Arquivo_srv?op=" + op, true); // como fazer?
    al.send();
}

function lista_treinamentos_privados() {
    //var op = 5;
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            document.getElementById("lista_treinamentos_privados").innerHTML = al.responseText;
        }
    };
    al.open("GET", "Arquivo_srv?op=" + op, true); // como fazer?
    al.send();
}

function lista_treinamentos_restritos() {
    //var op = 5;
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            document.getElementById("lista_treinamentos_restritos").innerHTML = al.responseText;
        }
    };
    al.open("GET", "Arquivo_srv?op=" + op, true); // como fazer?
    al.send();
}

function lista_meus_treinamentos() {
    //var op = 5;
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            document.getElementById("lista_meus_treinamentos").innerHTML = al.responseText;
        }
    };
    al.open("GET", "Arquivo_srv?op=" + op, true); // como fazer?
    al.send();
}




function lista_usuarios() {
    //var op = 5;
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            document.getElementById("lista_usuario").innerHTML = al.responseText;
        }
    }
    al.open("GET", "usuario_srv?op=" + op, true); //como fazer?
    al.send();
}

function pega_id_treinamento(id) {
    document.getElementById("id_treinamento").value = id;
}

function pega_id_usr(id) {
    document.getElementById("id_usr_comp").value = id;
}

function compartilhar() {
    var op = 1;
    var id_treinamento = document.getElementById("id_treinamento").value;
    var id_usr = document.getElementById("id_usr_comp").value;
    var al = new XMLHttpRequest();
    al.onreadystatechange = function () {
        if (al.readyState == 4) {
            if (al.responseText == 1) {
                document.getElementById("id_treinamento").value = "";
                document.getElementById("id_usr_comp").value = "";
                alert("COMPARTILHADO COM SUCESSO!");
            }
            else
                alert("Falha!");
        }

    };
    al.open("GET", "compartilha_srv?op=id_treinamento=" + id_treinamento + "&id_usr=" + id_usr, true);
    al.send();

}