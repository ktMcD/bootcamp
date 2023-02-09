class Country {
    constructor(name, lang, greeting, colors, flag) {
        this.name = name;
        this.lang = lang;
        this.greeting = greeting;
        this.colors = colors;
        this.flag = flag;
    }
}

// let nothing = new Country("Select a country", "the country's language", "Hello World", ["#3A3CC5", "#C5C33A", "#ffffff"])
let canada = new Country("Canada", "French and English", "Hello, World, eh?", ["#EF3340", "#FFFFFF", ""], "canada.png");
let finland = new Country("Finland", "Finnish", "Hei maailma", ["#002F6C", "#FFFFFF", "#ffffff"], "finland.png");
let haiti = new Country("Haiti", "French and Haitian Creole", "Bonjour le monde", ["#EF3340", "#003DA5", "#ffffff"], "haiti.png");
let mexico = new Country("Mexico", "Spanish", "Hola mundo!", ["#006341", "#FFFFFF", "#C8102E"], "mexico.png");
let rwanda = new Country("Rwanda", "Kinyarwanda, French, Swahili, English", "Smuraho isi", ["#0077C8", "#FFD100", "#007749"], "rwanda.png");
let uganda = new Country("Uganda", "English and Swahili", "Salamu, Dunia", ["#FFD100", "#EF3340", "#000000"], "uganda.png");
let ukraine = new Country("Ukraine", "Ukrainian", "Dobryy den\'	svit", ["#0057b7", "#ffd700", "#ffffff"], "ukraine.png");
let venezuela = new Country("Venezuela", "Espanol", "Hola Mundo!", ["#FCE300", "#003DA5", "#EF3340"], "venezuela.png");

function SwitchCountry() {
    let input = document.querySelector('#CountryList').value;
    let country;

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
    else {
        country = venezuela;
    } 

    intro = "You selected ";
    
    document.getElementById("CountryName").innerText = intro + country.name;
    document.getElementById("OfficialLanguage").innerText = country.name + "'s official language(s): " + country.lang;
    document.getElementById("HelloWorld").innerText = "Hello world: " + country.greeting;
    document.getElementById("Color1").style.backgroundColor = country.colors[0];
    document.getElementById("Color2").style.backgroundColor = country.colors[1];
    document.getElementById("Color3").style.backgroundColor = country.colors[2];
    document.getElementById("countryFlag").src = country.flag;

    if (country === uganda){
        document.getElementById("Color1").style.color = "#ffffff";
    }
    else {
        document.getElementById("Color1").style.color = "#000000";
    }
    
}

um

//"<img src='MatrixLogos/"+add[3]+"' width='100' height='25'/>";