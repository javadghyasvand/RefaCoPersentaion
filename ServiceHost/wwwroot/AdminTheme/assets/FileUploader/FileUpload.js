$('.inputFile').on('change', function (event) {
    const file = event.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            $('#preview').attr('src', e.target.result).show();
        }
        reader.readAsDataURL(file);
    }
});
var src = $('#preview').attr('src');
if (!src || src === "") {
    $('#preview').css("display", "none")
} else {
    $('#preview').css("display", "block")
}




$('.inputFile1').on('change', function (event) {
    const file = event.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            $('#preview1').attr('src', e.target.result).show();
        }
        reader.readAsDataURL(file);
    }
});
var src = $('#preview1').attr('src');
if (!src || src === "") {
    $('#preview1').css("display", "none")
} else {
    $('#preview1').css("display", "block")
}