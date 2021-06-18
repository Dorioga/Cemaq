function actualizar_guia() {
    $(function () {
        $(document).on('click', 'input[type="button"]', function (event) {
            let id = this.id;
            var archivo = ($("#archivo"))[0].files[0];
            var datastring = new FormData();

            datastring.append("id_formato", id);
            datastring.append("file", archivo);

            $.ajax({
                url: '@Url.Action("Actualizar_formato", "Formatos")',
                type: "POST",
                data: datastring,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (typeof (data.Value) != "undefined") {
                        if (data.Value == true) {
                            alert(data.Message);
                            refresh();
                        } else {
                            alert("Error");
                        }
                    }
                },
                error: function (data) {

                }
            });
        });
    });
}