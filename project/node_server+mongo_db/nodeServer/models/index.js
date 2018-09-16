const mongoose = require('mongoose');
//const userModel={...require('./user')};
const user = require('./user');
const country = require('./country');

//connect to MongoDB
mongoose.connect("mongodb://localhost:27017/TravelerDB",
    (err) => {
        //if error is empty we connected successfuly
        console.log(err || "We're connected to MongoDB.");
    });

//create Model:
module.exports = {
    User: mongoose.model("User", user.userModel),
    Country: mongoose.model("Country", country.countryModel)
}

