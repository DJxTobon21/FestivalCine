document.addEventListener("DOMContentLoaded", () => {
    const pelicula = document.getElementById("PeliculaId");
    const cantidad = document.getElementById("CantidadBoletos");
    const total = document.getElementById("totalEstimado");
    if (!pelicula || !cantidad || !total) return;

    function actualizar() {
        const opcion = pelicula.options[pelicula.selectedIndex];
        const precio = parseFloat(opcion?.dataset.precio || "0");
        const n = parseInt(cantidad.value || "0", 10);
        const valor = precio * (isNaN(n) ? 0 : n);
        total.textContent = valor.toLocaleString("es-CO", {
            style: "currency",
            currency: "COP",
            maximumFractionDigits: 0
        });
    }

    pelicula.addEventListener("change", actualizar);
    cantidad.addEventListener("input", actualizar);
    actualizar();
});