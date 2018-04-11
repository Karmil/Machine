// Write your JavaScript code.
$(document).ready(function () {

    var updateSlider = document.getElementById('update');
    var updateSliderValue = document.getElementById('slider-update-value');
    var Quantitesucre = 0;

    noUiSlider.create(updateSlider, {
        range: {
            'min': 0,
            'max': 10
        },
        connect: true,
        start: 0,
        margin: 1,
        step: 1
    });

    updateSlider.noUiSlider.on('update', function (values, handle) {
        console.log(values[0]);
        Quantitesucre = values[0];
       
    });
    $('#SaveCommande').click(function () {
        var idtypeBoisson = $("#IdTypeBoisson").val();
        if (idtypeBoisson == "Sélectionnez votre boisson") {
            alert("Merci de choisir un boisson");
            return;
        }
        var mug = $("#Mug").val();
        $("#load").removeClass('hidden');
        $("#loadPage").addClass('hidden');
        alert("Votre commande est encours de préparation ");
        $.post('api/Machine/Create', { IdTypeBoisson: idtypeBoisson, Mug: mug, Quantite: parseInt(Quantitesucre)},
            function (data) {
                if (data) {
                    alert("Merci de retire votre " + data);
                    $("#loadPage").removeClass('hidden');
                    $("#load").addClass('hidden');
                }
            }
        );

    });
});