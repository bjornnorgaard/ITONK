let express = require("express");
let morgan = require("morgan");
let app = express();

app.use(morgan("dev"))

app.use(function (err, req, res, next) {
    console.log("Error detected!")
});

app.post("/buy", function (req, res) {
    res.send("Buy works!")
});

app.post("/sell", function (req, res) {
    res.send("Sell works!")
});

app.use(function (req, res, next) {
    res.status(404).send("Not found.")
});

app.listen(3000, function () {
    console.log("Listening on port 3000...")
});