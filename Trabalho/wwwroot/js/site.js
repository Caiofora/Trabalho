var mask = {

    //Init
    init: function (o, f) {
        v_obj = o;
        v_fun = f;

        setTimeout("mask.execmasc()", 1);
    },

    //ExecMasc
    execmasc: function () {
        v_obj.value = v_fun(v_obj.value)
    },

    //Num
    num: function (v) {
        v = v.replace(/\D/g, "");

        return v;
    },

}

function SalvarCurriculo(id) {
    swal({
        position: 'center',
        type: 'success',
        title: 'Curriculo Salvo!',
        showConfirmButton: false,
        timer: 2000
    },
        function () {
            location.href = '/Cadastro/Salvar4';
        });
};

function FinalRedirect() {
    location.href = '/Home/Index';
}


function apagarCurriculo(id) {

    swal({
        title: "Tem certeza?",
        text: "O Curriculo será apagado para sempre!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-info",
        confirmButtonText: "Sim",
        cancelButtonText: "Não!",
        closeOnConfirm: false
    },
        function aparecerSimbolo() {
            swal({
                position: 'center',
                type: 'success',
                title: 'Curriculo excluído!',
                showConfirmButton: false,
                timer: 1500
            },
                function () {
                    location.href = '/Home/ExcluirCurriculo?id=' + id;
                });
        });
};

/*function aparecerSimbolo() {
    swal({
        position: 'center',
        icon: 'success',
        title: 'Curriculo excluído!',
        showConfirmButton: false,
        timer: 1500
    },
    function () {
        location.href = '/Home/ExcluirCurriculo?id=' + id;
    });
};*/
