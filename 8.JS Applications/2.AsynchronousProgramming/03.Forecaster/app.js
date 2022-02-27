function attachEvents() {
    document.getElementById('submit').addEventListener('click', async () => {
        let forecastRemove = document.querySelector('div.forecasts');
        let forecastInfoRemove = document.querySelector('div.forecast-info');

        if (forecastRemove || forecastInfoRemove){
            forecastRemove.remove();
            forecastInfoRemove.remove();
        }

        let location = document.getElementById('location').value;
        let forecast = document.getElementById('forecast');

        let condition = {
            Sunny: '&#x2600;',
            'Partly sunny': '&#x26C5;',
            Overcast: '&#x2601;',
            Rain: '&#x2614;',
            Degrees: '&#176;'
        };

        const url = `http://localhost:3030/jsonstore/forecaster/locations`;

        const locationRes = await fetch(url);

        const locationData = await locationRes.json();

        let labels = forecast.querySelectorAll('div.label');

        let code = locationData.find(x => x.name == location);
        
        if (!code) {
            forecast.style.display = 'block';
            
            labels[0].textContent = 'Error';
            labels[1].style.display = 'none';
            
            return;
        }

        code = code.code;

        labels[0].textContent = 'Current conditions';
        labels[1].style.display = 'block'; 

        const condintionUrl = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
        const conditionRes = await fetch(condintionUrl);
        const conditionData = await conditionRes.json();

        const forecastUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
        const forecastRes = await fetch(forecastUrl);
        const forecastData = await forecastRes.json();

        let divToday = document.createElement('div');
        divToday.classList = 'forecasts';

        let spanSymbolToday = document.createElement('span');
        spanSymbolToday.classList = 'condition symbol';
        spanSymbolToday.innerHTML = condition[conditionData.forecast.condition];

        let spanClassToday = document.createElement('span');
        spanClassToday.classList = 'condition';

        let spanLocaitonToday = document.createElement('span');
        spanLocaitonToday.classList = 'forecast-data';
        spanLocaitonToday.textContent = conditionData.name;

        let spanDegreesToday = document.createElement('span');
        spanDegreesToday.classList = 'forecast-data';
        spanDegreesToday.innerHTML = `${conditionData.forecast.low}${condition.Degrees}/${conditionData.forecast.high}${condition.Degrees}`;

        let spanTextToday = document.createElement('span');
        spanTextToday.classList = 'forecast-data';
        spanTextToday.textContent = conditionData.forecast.condition;

        spanClassToday.appendChild(spanLocaitonToday);
        spanClassToday.appendChild(spanDegreesToday);
        spanClassToday.appendChild(spanTextToday);

        divToday.appendChild(spanSymbolToday);
        divToday.appendChild(spanClassToday);

        forecast.style.display = 'block';

        document.getElementById('current').appendChild(divToday);

        let divTomorrow = document.createElement('div');
        divTomorrow.classList = 'forecast-info';

        for (let i = 0; i < 3; i++) {
            let spanClassTomorrow = document.createElement('span');
            spanClassTomorrow.classList = 'upcoming';

            let spanSymbolTomorrow = document.createElement('span');
            spanSymbolTomorrow.classList = 'symbol';
            spanSymbolTomorrow.innerHTML = condition[forecastData.forecast[i].condition];

            let spanDegreesTomorrow = document.createElement('span');
            spanDegreesTomorrow.classList = 'forecast-data';
            spanDegreesTomorrow.innerHTML = `${forecastData.forecast[i].low}${condition.Degrees}/${forecastData.forecast[i].high}${condition.Degrees}`;

            let spanTextTomorrow = document.createElement('span');
            spanTextTomorrow.classList = 'forecast-data';
            spanTextTomorrow.textContent = forecastData.forecast[i].condition;

            spanClassTomorrow.appendChild(spanSymbolTomorrow);
            spanClassTomorrow.appendChild(spanDegreesTomorrow);
            spanClassTomorrow.appendChild(spanTextTomorrow);

            divTomorrow.appendChild(spanClassTomorrow);
        }

        document.getElementById('upcoming').appendChild(divTomorrow);
    })
}

attachEvents();