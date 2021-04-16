// note api
const express = require('express');

// create instance of express router for interpreting routes
const router = express.Router();

// import heart rate database model
const HeartRate = require('../models/heartrates');

// API endpoint - GET list of all heart rates (or only list of heart rates from query)
//http://localhost:3001/api/heartrate
router.get('/heartrate', function(req, res) {
    console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);

    HeartRate.find({}).then(function(heartrates) {
        console.log(heartrates);
        res.send(heartrates);
    });
});

// API endpoint - GET last inserted document 
//http://localhost:3001/api/heartrate/last
router.get('/heartrate/last', function(req, res) {
    console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);
    
    //HeartRate.getLastInsertedDocument.find().sort({_id:-1}).limit(1).then(function(heartrates) {
    HeartRate.find().sort({_id:-1}).limit(1).then(function(heartrates) {
        console.log(heartrates);
        res.send(heartrates);
    });;

    // HeartRate.find({}).then(function(heartrates) {
    //     console.log(heartrates);
    //     res.send(heartrates);
    // });
});

// API endpoint - GET heart rates within a given date range
//http://localhost:3001/api/heartrate/date_range?date1=str1&date2=str2
router.get('/heartrate/date_range', function(req, res) {
    //console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);

    HeartRate.find({}).then(function(heartrates) {
        //console.log(temps);
        HeartRate.find({ date: { $gte: req.query.start_date, $lte: req.query.end_date } }).then(function(dates) {
            res.send(dates);
        });
    });
});

// API endpoint - GET a heart rate by _id
router.get('/heartrate/:id', function(req, res) {
    console.log("REQ.PARAMS.ID: " + req.params.id);
    
    // check if this works by finding User's unique _id and checking for update
    HeartRate.findOne({ _id: req.params.id }).then(function(heartrate) {
        // send update back to as response
        res.send(heartrate);
    });
});

// API endpoint - post new heartrate
router.post('/heartrate', function(req, res, next) {
    console.log(req.body)
    HeartRate.create(req.body).then(function(heartrate) {
        res.send(heartrate);
    }).catch(next);
});

// API endpoint - update a temp
router.put('/heartrate/:id', function(req, res) {
    console.log(req);
    
    // find user document by id and update with request body
    HeartRate.findOneAndUpdate({ _id: req.params.id }, req.body).then(function() {
        // check if this works by finding User's unique _id and checking for update
        HeartRate.findOne({ _id: req.params.id }).then(function(heartrate) {
            console.log(heartrate);
            // send update back to as response
            res.send(heartrate);
            
        });
    });
});

// API endpoint - delete a temp
router.delete('/heartrate/:id', function(req, res) {
    // find user document by id, delete
    HeartRate.findByIdAndRemove({ _id: req.params.id }, req.body).then(function(heartrate) {
        // send update back to as response
        res.send(heartrate);
    });
})

// expoert router object with temp endpoint 
module.exports = router;