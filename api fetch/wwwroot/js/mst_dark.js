document.addEventListener("DOMContentLoaded", function() {
    const toggleButton = document.getElementById("toggle");
    const body = document.body;

    toggleButton.addEventListener("click", function() {
        body.classList.toggle("dark-theme");
        body.classList.toggle("light-theme");
    });
});