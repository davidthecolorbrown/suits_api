// note api
const express = require('express');

// create instance of express router for interpreting routes
const router = express.Router();

// import temp database model
const Temp = require('../models/temps');

// API endpoint - GET list of all temps (or only list of temps from query)
//http://localhost:3001/api/temp
router.get('/temp', function(req, res) {
    //console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);

    Temp.find({}).then(function(temps) {
        console.log(temps);
        res.send(temps);
    });
});

// API endpoint - GET last inserted document 
//http://localhost:3001/api/temp/last
router.get('/temp/last', function(req, res) {
    console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);
    
    //HeartRate.getLastInsertedDocument.find().sort({_id:-1}).limit(1).then(function(heartrates) {
    Temp.find().sort({_id:-1}).limit(1).then(function(temps) {
        console.log(temps);
        res.send(temps);
    });;
});

// API endpoint - GET temps within a given date range
//http://localhost:3001/api/temp/date_range?date1=str1&date2=str2
router.get('/temp/date_range', function(req, res) {
    //console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);

    Temp.find({}).then(function(temps) {
        //console.log(temps);
        Temp.find({ date: { $gte: req.query.start_date, $lte: req.query.end_date } }).then(function(dates) {
            res.send(dates);
        });
    });
});

// API endpoint - GET a temp by _id
router.get('/temp/:id', function(req, res) {
    console.log("REQ.PARAMS.ID: " + req.params.id);
    
    // check if this works by finding User's unique _id and checking for update
    Temp.findOne({ _id: req.params.id }).then(function(temp) {
        // send update back to as response
        res.send(temp);
    });
});

// API endpoint - post new temp
router.post('/temp', function(req, res, next) {
    console.log(req.body)
    Temp.create(req.body).then(function(temp) {
        res.send(temp);
    }).catch(next);
});

// API endpoint - update a temp
router.put('/temp/:id', function(req, res) {
    console.log(req);
    
    // find user document by id and update with request body
    Temp.findOneAndUpdate({ _id: req.params.id }, req.body).then(function() {
        // check if this works by finding User's unique _id and checking for update
        Temp.findOne({ _id: req.params.id }).then(function(temp) {
            console.log(temp);
            // send update back to as response
            res.send(temp);
            
        });
    });
});

// API endpoint - delete a temp
router.delete('/temp/:id', function(req, res) {
    // find user document by id, delete
    Temp.findByIdAndRemove({ _id: req.params.id }, req.body).then(function(temp) {
        // send update back to as response
        res.send(temp);
    });
})

// expoert router object with temp endpoint 
module.exports = router;