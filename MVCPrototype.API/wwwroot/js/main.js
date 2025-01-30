const weather_container = $("#weather-list");
const ICON_SRC = "/icons";
//const toast = new bootstrap.Toast(document.getElementById('errorToast'));


function mountWeatherDisplay(weather_object) {
    let weather = document.createElement("DIV");
    weather.classList.add("weather-display");

    let header = document.createElement("SPAN");
    header.innerText = weather_object.formattedDate;

    let dayOfWeek = document.createElement("SPAN");
    dayOfWeek.classList.add("weather-day");
    dayOfWeek.innerText = weather_object.dayOfWeek; 

    let footer = document.createElement("SPAN");
    footer.classList.add("footer");
    footer.innerText = weather_object.summary;

    let temperature = document.createElement("SPAN");
    temperature.classList.add("weather-temperature");
    temperature.innerText = `${weather_object.temperatureC}`;

    let icon = document.createElement("LABEL");
    icon.appendChild(getIcon(weather_object.summary));

    weather.appendChild(header);
    weather.appendChild(dayOfWeek);
    weather.appendChild(temperature);
    weather.appendChild(icon);
    weather.appendChild(footer);

    return weather;
}

function getIcon(summary) {
    const icon_img = document.createElement("IMG");
    switch (summary) {
        case "Frio":
            icon_img.src = ICON_SRC + "/snowflake-solid.svg";
            break;
        case "Névoa":
            icon_img.src = ICON_SRC + "/smog-solid.svg";
            break;
        case "Ensolarado":
            icon_img.src = ICON_SRC + "/sun-solid.svg";
            break;
        case "Chuvoso":
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

function getClimate(initialDate, lastDate) {
    $.ajax({
        url: `/Weather/${initialDate}/${lastDate}`,
        type: "GET",
        success: (response) => {
            weather_container.empty();
            for (const weather of response) {
                weather_container[0].appendChild(mountWeatherDisplay(weather));
            }
        }
    });
}