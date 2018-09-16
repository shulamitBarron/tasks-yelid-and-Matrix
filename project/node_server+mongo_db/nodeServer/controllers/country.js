var models = require('./../models/index');
const countriesList = require('./../models/countries.json')

function addCountryRoutes(app) {

    // If the db is empty - fill it with the countryList seed
    models.Country.find({}, (err, countries) => {
        if (!countries.length)
            models.Country.insertMany(countriesList, (err, res) => {
                console.log("Insert country list succesed");
            });
    });
    // Get all countries:
    app.get("/countries", function (request, response) {
        models.Country.find({}, (err, countries) => {
            response.send(countries);
        });
    });
}


module.exports = { addCountryRoutes };
