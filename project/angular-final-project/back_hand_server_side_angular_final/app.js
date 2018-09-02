const path = require('path');
const fs = require('fs');
const express = require('express');
// url ממיר מביטים לשם שנשלח
const bodyParser = require("body-parser");
var cors = require('cors');

const app = express();
app.use(cors());
//כל בקשה שנשלחה יוצר מהתשובה 
//JSON אוביקט 
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());// support json encoded bodies
const basePath = path.join(__dirname + "/dist");


app.get(`/`, (req, res) => {
    let linkList = "";
    let resPage = fs.readFileSync("links.html", "utf-8");
    console.log(resPage);
    fs.readdir(basePath, (err, files) => {
        files.forEach((file) => {
            linkList += `<li><a href="/${file}" target="blank">${file}</a></li>`;
        })
        res.send(resPage.replace("placeHolder", linkList));
    });

});


//get -data
//post -data

app.post("/api/addCustomerRegister", (req, res) => {
    //get all list
    let currentList = require("./customer.json");
    //data is valid?
    if (isValid(req.body)) {
        //check if There is already one same customer in this system
        if (!thereIsAlreadyOneSame(req.body)) {//there is not this password & username yet
            currentList.push(req.body);//save data local
            fs.writeFileSync("customer.json", JSON.stringify(currentList));//save data global
            res.status(201).send(JSON.stringify(currentList));
        }
        else {
            res.status(402).send("exit this customer");
        }
    }
    else {
        res.status(401).send("data not valid");
    }
})
//return  [] if there is not this password & username yet
function thereIsAlreadyOneSame(body) {
    let currentCustomer;
    let currentList = require("./customer.json");
    currentCustomer = currentList.filter(element => element["username"] == body.username && element["password"] == body.password);
   console.log(currentCustomer[0]);
    return currentCustomer[0];
}


//get only userName and password 
//return current user or []
app.post("/api/existCurrentCustomerLogin", (req, res) => {
    let customer = thereIsAlreadyOneSame(req.body);
    if (customer)
        res.status(201).send(JSON.stringify(customer));
    else
        res.status(401).send("there is not this data yet");
})
function isValid(sent) {

    // here was validation for feilds:

    // firstName?: string;
    // lastName?: string;
    // username?: string;
    // password?: string;

    // תיבת קלט לשם פרטי ומשפחה
    // לפחות 2 תווים, מקסימום 15 תווים
    // יכול להיות אותיות באנגלית בלבד

    if (!validCaracters(sent.firstName, 3))
        return false;
    if (!validCaracters(sent.lastName, 3))
        return false;
    // תיבת קלט לשם משתמש
    // לפחות 3 תווים, מקסימום 15 תווים
    // יכול להיות אותיות באנגלית בלבד
    if (!validCaracters(sent.userName, 2))
        return false;
    //         תיבת קלט לסיסמה :Password
    // לפחות 5 תווים, מקסימום 10 תווים 

    if (sent.password.length > 10 || sent.password.length < 5) {

        return false;
    }


    return true;
}
function validCaracters(stringCheck, minLength) {

    var regex = new RegExp("^[a-zA-Z ]+$");
    if (stringCheck.length < minLength || stringCheck.length > 15 || !regex.test(stringCheck)) {

        return false;
    }
    return true;
}

const port = process.env.PORT || 3500;
app.listen(port, () => { console.log(`OK`); });

