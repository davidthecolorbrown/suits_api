// note api
const express = require('express');

// create instance of express router for interpreting routes
const router = express.Router();

// import heart rate database model
const Vital = require('../models/vitals');

// API endpoint - GET list of all heart rates (or only list of heart rates from query)
//http://localhost:3001/api/vital
router.get('/vital', function(req, res) {
    console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);

    Vital.find({}).then(function(vitals) {
        console.log(vitals);
        res.send(vitals);
    });
});

// API endpoint - GET last inserted document 
//http://localhost:3001/api/vital/last
router.get('/vital/last', function(req, res) {
    console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);
    
    Vital.find().sort({_id:-1}).limit(1).then(function(vitals) {
        console.log(vitals);
        res.send(vitals);
    });;
});

// API endpoint - GET heart rates within a given date range
//http://localhost:3001/api/vital/date_range?date1=str1&date2=str2
router.get('/vital/date_range', function(req, res) {
    //console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);

    Vital.find({}).then(function(vitals) {
        //console.log(vitals);
        Vital.find({ date: { $gte: req.query.start_date, $lte: req.query.end_date } }).then(function(dates) {
            res.send(dates);
        });
    });
});

// API endpoint - GET a heart rate by _id
router.get('/vital/:id', function(req, res) {
    console.log("REQ.PARAMS.ID: " + req.params.id);
    
    // check if this works by finding User's unique _id and checking for update
    Vital.findOne({ _id: req.params.id }).then(function(vital) {
        // send update back to as response
        res.send(vital);
    });
});

// API endpoint - post new vital
router.post('/vital', function(req, res, next) {
    console.log(req.body)
    Vital.create(req.body).then(function(vital) {
        res.send(vital);
    }).catch(next);
});

// API endpoint - update a vital
router.put('/vital/:id', function(req, res) {
    console.log(req);
    
    // find user document by id and update with request body
    Vital.findOneAndUpdate({ _id: req.params.id }, req.body).then(function() {
        // check if this works by finding User's unique _id and checking for update
        Vital.findOne({ _id: req.params.id }).then(function(vital) {
            console.log(vital);
            // send update back to as response
            res.send(vital);
            
        });
    });
});

// API endpoint - delete a vital
router.delete('/vital/:id', function(req, res) {
    // find user document by id, delete
    Vital.findByIdAndRemove({ _id: req.params.id }, req.body).then(function(vital) {
        // send update back to as response
        res.send(vital);
    });
})

// expoert router object with vital endpoint 
module.exports = router;