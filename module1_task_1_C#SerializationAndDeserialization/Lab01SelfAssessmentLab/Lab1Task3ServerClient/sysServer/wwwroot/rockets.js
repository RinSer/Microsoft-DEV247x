async function getRockets() {
    var response = await fetch('/api/rockets');
    var rocketsJson = await response.json();
    var rockets = JSON.parse(rocketsJson);
    
    for (var rocket of rockets)
        document.writeln(`${rocket.ID}) ${rocket.Builder} => ${rocket.Target}, Speed: ${rocket.Speed}<br>`);
}

getRockets();