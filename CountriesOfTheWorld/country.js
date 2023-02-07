class Country {
    constructor(name, lang, greeting, colors) {
        this.name = name;
        this.lang = lang;
        this.greeting = greeting;
        this.colors = colors;
    }
}

let canada = new Country("Canada", "French and English", "Hello, World, eh?", ["red", "white", "blue"]);
let finland = new Country("Finland", "Finnish", "'Sup", ["blue", "yellow", "red"])
let haiti = new Country("Haiti", "Arabic and Berber", "Sup", ["blue", "yellow", "red"])
let mexico = new Country("Mexico", "Spanish", "Hola mundo!", ["red", "white", "green"]);
let rwanda = new Country("Rwanda", "Arabic and Berber", "Sup", ["blue", "yellow", "red"])
let uganda = new Country("Uganda", "Arabic and Berber", "Sup", ["blue", "yellow", "red"])
let ukraine = new Country("Ukraine", "Arabic and Berber", "Sup", ["blue", "yellow", "red"])
let venezuela = new Country("Venezuela", "Arabic and Berber", "Sup", ["blue", "yellow", "red"])

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
    else if (input === "Mexico") {
        country = mexico;
    }
    else if (input === "Algeria") {
        country = algeria;
    } 

}