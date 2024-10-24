// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
formfile.onchange = evt => {
    const [file] = formfile.files
    if (file) {
        ImgPreview.src = URL.createObjectURL(file)
    }
}

