async function getInfo() {
    let btn = document.getElementById('submit');
    btn.disabled = true;
    
    const stopId = document.getElementById('stopId').value;
    
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    let stopName = document.getElementById('stopName');

    let buses = document.getElementById('buses');

    try {
        buses.innerHTML = '';

        stopName.textContent = 'Loading...'

        const res = await fetch(url);
        
        if (res.status != 200) {
            throw new Error("Bus id is not valid.")
        }
        
        const data = await res.json();

        stopName.textContent = data.name;
        
        Object.entries(data.buses).forEach(b => {
            let li = document.createElement('li');
            li.textContent = `Bus ${b[0]} arrives in ${b[1]} minutes`;
            
            buses.appendChild(li);
        });
    } catch (error){
        stopName.textContent = 'Error';
    }

    btn.disabled = false;
}