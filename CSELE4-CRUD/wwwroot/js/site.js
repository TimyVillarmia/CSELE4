// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#formfile").on("change", function () {
    const [file] = formfile.files
    if (file) {
        ImgPreview.src = URL.createObjectURL(file)
    }
});