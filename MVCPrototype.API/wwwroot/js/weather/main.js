const weather_container = $("#weather-list");
const endDate = $("#end-date");
const startDate = $("#start-date");
const ICON_SRC = "/icons";
const toast = new bootstrap.Toast(document.getElementById('errorToast'));


document.addEventListener("DOMContentLoaded", () => {
    const today = new Date();
    const todayLocal = formatDateToISO(today);
    startDate[0].value = todayLocal

    const sixDaysLater = new Date(today);
    sixDaysLater.setDate(today.getDate() + 6);
    const sixDaysLaterISO = formatDateToISO(sixDaysLater)
    endDate[0].value = sixDaysLaterISO

    getClimate()
})

endDate[0].addEventListener("change", e => {
    if (new Date(startDate[0].value) > new Date(endDate[0].value)) {
        toast.show();

        setTimeout(() => {
            toast.hide();
        }, 5000);

        return
    }
    getClimate()
})

startDate[0].addEventListener('keydown', function (event) {
    event.preventDefault();
});

function mountWeatherDisplay(weather_object) {
    let weather = document.createElement("DIV");
    weather.classList.add("weather-display");

    let header = document.createElement("SPAN");
    header.innerText = weather_object.date;
    let footer = document.createElement("SPAN");
    footer.innerText = weather_object.summary;

    let temperature = document.createElement("SPAN");
    temperature.classList.add("weather-temperature");
    temperature.innerText = `${weather_object.temperatureC}`;
    let icon = document.createElement("LABEL");
    icon.appendChild(getIcon(weather_object.summary));

    weather.appendChild(header);
    weather.appendChild(temperature);
    weather.appendChild(icon);
    weather.appendChild(footer);

    return weather;
}

function getIcon(summary) {
    const icon_img = document.createElement("IMG");
    switch (summary) {
        case "Freezing":
            icon_img.src = ICON_SRC + "/snowflake-solid.svg";
            break;
        case "Smog":
            icon_img.src = ICON_SRC + "/smog-solid.svg";
            break;
        case "Sunny":
            icon_img.src = ICON_SRC + "/sun-solid.svg";
            break;
        case "Raining":
            icon_img.src = ICON_SRC + "/rain-solid.svg";
            break;
    }
    return icon_img;
}

function formatDateToISO(date) {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, "0");
    const day = String(date.getDate()).padStart(2, "0");
    return `${year}-${month}-${day}`;
}

function getClimate() {
    $.ajax({
        url: `/Weather/${startDate[0].value}/${endDate[0].value}`,
        type: "GET",
        success: (response) => {
            weather_container.empty();
            for (const weather of response) {
                weather_container[0].appendChild(mountWeatherDisplay(weather));
            }
        }
    });
}