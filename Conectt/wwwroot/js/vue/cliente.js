var cliente = new Vue({
    el: '#appCliente',
    data: {
        nome: null,
        cpf: null,
        dataNascimento: null,
        email: null,
        empresa: null,
        telefoneComercialDdd: null,
        telefoneComercial: null,
        celularDdd: null,
        celular: null
    },
    methods: {
        
    },
    updated: function () {
        $('#dataNascimento').mask('00/00/0000');
    }
});


//$(document).ready(function () {
    
//    //https://igorescobar.github.io/jQuery-Mask-Plugin/
//});