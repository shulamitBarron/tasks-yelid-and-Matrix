var models = require('./../models/index');
const jws = require('jsonwebtoken');
const index = require('./../models/index');

function addUserRoutes(app) {

    app.post("/register", function (request, response) {
        models.User.findOne({ password: request.body.password }, (err, users) => {
            if (!users) {
                let user = new index.User(request.body);
                user.save((err, res) => {
                    var token = jws.sign(request.body, "no cover me");
                    response.send(token);
                })
            }
           else response.send(404);
        });
    });



    app.post("/login", function (request, response) {
        models.User.findOne({ password: request.body.password }, (err, users) => {
            if (users) {

                var token = jws.sign(request.body, "no cover me");
                response.send(token);

            }
            else response.send(404);
        });
    });
}

module.exports = { addUserRoutes };