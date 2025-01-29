document.addEventListener("DOMContentLoaded", () => {

    const today = new Date();

    // Primeiro dia do mês
    const firstDayDate = new Date(today.getFullYear(), today.getMonth(), 1);

    // Último dia do mês
    const lastDayDate = new Date(today.getFullYear(), today.getMonth() + 1, 0);

    const firstDay = formatDateToISO(firstDayDate)
    const lastDay = formatDateToISO(lastDayDate)



    getClimate(firstDay, lastDay)
})