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
//get -data
//post -data

//return only current customer

app.post("/api/addCustomerRegister", (req, res) => {
    //get all list
    let currentList = require("./customer.json");
    //data is valid?
    if (isValid(req.body)) {
        //check if There is already one same customer in this system
        if (thereIsAlreadyOneSame(req.body).length==0) {//there is not this password & username yet
            currentList.push(req.body);//save data local
            fs.writeFileSync("customer.json", JSON.stringify(currentList));//save data global
            res.status(201).send(JSON.stringify(req.body));//return only new customer
        }
        else {
            console.log("exit this customer");
            res.status(402).send("exit this customer");
        }
    }
    else {
        console.log("data not valid");
        res.status(401).send("data not valid");
    }
})
//return  [] if there is not this password & username yet
function thereIsAlreadyOneSame(body) {

    let currentCustomer;
    let currentList = require("./customer.json");
    currentList.filter(element => {
        if (element["userName"] == body.userName && element["password"] == body.password) {
            currentCustomer = element;//return only current Customer 
            console.log(body.userName,"---------- ",body.password);
        }
    });
    if (currentCustomer)
        return currentCustomer;
    else return [];
}


//get only userName and password 
//return all data about current user or []
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
    if (!validCaracters(sent.firstName, 2, "^[a-zA-Z ]+$"))
        return false;
    if (!validCaracters(sent.lastName, 2, "^[a-zA-Z ]+$"))
        return false;
    // תיבת קלט לשם משתמש
    // לפחות 3 תווים, מקסימום 15 תווים
    // יכול להיות אותיות באנגלית בלבד
    if (!validCaracters(sent.userName, 3, "^[a-zA-Z ]+$"))
        return false;
    //         תיבת קלט לסיסמה :Password
    // לפחות 5 תווים, מקסימום 10 תווים 
    if (sent.password.length > 10 || sent.password.length < 5) {
        return false;
    }
    return true;
}
function validCaracters(stringCheck, minLength, regExp) {

    var regex = new RegExp(regExp);
    if (stringCheck.length < minLength || stringCheck.length > 15 || !regex.test(stringCheck)) {
        return false;
    }
    return true;
}

const port = process.env.PORT || 3500;
app.listen(port, () => { console.log(`OK`); });

