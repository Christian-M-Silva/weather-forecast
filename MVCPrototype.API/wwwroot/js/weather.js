const toast = new bootstrap.Toast(document.getElementById('errorToast'));
const endDate = $("#end-date");
const startDate = $("#start-date");
document.addEventListener("DOMContentLoaded", () => {

    const today = new Date();
    const todayLocal = formatDateToISO(today);
    startDate[0].value = todayLocal

    const sixDaysLater = new Date(today);
    sixDaysLater.setDate(today.getDate() + 6);
    const sixDaysLaterISO = formatDateToISO(sixDaysLater)
    endDate[0].value = sixDaysLaterISO

    getClimate(startDate[0].value, endDate[0].value)
})

endDate[0].addEventListener("change", e => {
    if (new Date(startDate[0].value) > new Date(endDate[0].value)) {
        toast.show();

        setTimeout(() => {
            toast.hide();
        }, 5000);

        return
    }
    getClimate(startDate[0].value, endDate[0].value)
})

startDate[0].addEventListener('keydown', function (event) {
    event.preventDefault();
});

endDate[0].addEventListener('keydown', function (event) {
    event.preventDefault();
});