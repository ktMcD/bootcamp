class Country {
    constructor(name, lang, greeting, colors) {
        this.name = name;
        this.lang = lang;
        this.greeting = greeting;
        this.colors = colors;
    }
}

let canada = new Country("Canada", "French and English", "Hello, World, eh?", ["#EF3340", "#FFFFFF", ""]);
let finland = new Country("Finland", "Finnish", "Hei maailma", ["#002F6C", "#FFFFFF", "#ffffff"])
let haiti = new Country("Haiti", "French and Haitian Creole", "Bonjour le monde", ["#EF3340", "#003DA5", "#ffffff"])
let mexico = new Country("Mexico", "Spanish", "Hola mundo!", ["#006341", "#FFFFFF", "#C8102E"]);
let rwanda = new Country("Rwanda", "Kinyarwanda, French, Swahili, English", "Smuraho isi", ["#0077C8", "#FFD100", "#007749"])
let uganda = new Country("Uganda", "English nad Swahili", "Salamu, Dunia", ["#FFD100", "#EF3340", "#000000"])
let ukraine = new Country("Ukraine", "Arabic and Berber", "Dobryy den’	svit", ["#0057b7", "#ffd700", "#ffffff"])
let venezuela = new Country("Venezuela", "Espanol", "Hola Mundo!", ["#FCE300", "#003DA5", "#EF3340"])

function SwitchCountry() {
    let input = document.querySelector('#CountryList').value;
    let country;

    switch(input)
    {
        case "Canada":
            break;
        case "Finland":
            break;
        case "Haiti":
            break;
        case "Mexico":
            break;
        case "Rwanda":
            break;
        case "Uganda":
            break;
        case "Ukraine":
            break;     
        case "Venezuela":
            break;       
    }

    if (input === "Canada") {
        //set country to usa 
        country = canada;
    }
    else if (input === "Finland") {
        country = finland;
    }
    else if (input === "Haiti") {
        country = haiti;
    } 
    else if (input === "Mexico") {
        country = mexico;
    } 
    else if (input === "Rwanda") {
        country = rwanda;
    } 
    else if (input === "Uganda") {
        country = uganda;
    } 
    else if (input === "Ukraine") {
        country = ukraine;
    } 
    else if (input === "Venezuela") {
        country = venezuela;
    } 
}