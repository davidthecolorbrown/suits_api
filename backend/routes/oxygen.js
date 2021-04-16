// note api
const express = require('express');

// create instance of express router for interpreting routes
const router = express.Router();

// import oxygen database model
const Oxygen = require('../models/oxygens');

// API endpoint - GET list of all heart rates (or only list of heart rates from query)
//http://localhost:3001/api/oxygen
router.get('/oxygen', function(req, res) {
    console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);

    Oxygen.find({}).then(function(oxygens) {
        console.log(oxygens);
        res.send(oxygens);
    });
});

// API endpoint - GET last inserted document 
//http://localhost:3001/api/oxygen/last
router.get('/oxygen/last', function(req, res) {
    console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);
    
    //oxygen.getLastInsertedDocument.find().sort({_id:-1}).limit(1).then(function(oxygens) {
    Oxygen.find().sort({_id:-1}).limit(1).then(function(oxygens) {
        console.log(oxygens);
        res.send(oxygens);
    });;

    // oxygen.find({}).then(function(oxygens) {
    //     console.log(oxygens);
    //     res.send(oxygens);
    // });
});

// API endpoint - GET heart rates within a given date range
//http://localhost:3001/api/oxygen/date_range?date1=str1&date2=str2
router.get('/oxygen/date_range', function(req, res) {
    //console.log(req.query);
    //console.log(req.query.start_date);
    //console.log(req.query.end_date);

    Oxygen.find({}).then(function(oxygens) {
        //console.log(oxygens);
        Oxygen.find({ date: { $gte: req.query.start_date, $lte: req.query.end_date } }).then(function(dates) {
            res.send(dates);
        });
    });
});

// API endpoint - GET a heart rate by _id
router.get('/oxygen/:id', function(req, res) {
    console.log("REQ.PARAMS.ID: " + req.params.id);
    
    // check if this works by finding User's unique _id and checking for update
    Oxygen.findOne({ _id: req.params.id }).then(function(oxygen) {
        // send update back to as response
        res.send(oxygen);
    });
});

// API endpoint - post new oxygen
router.post('/oxygen', function(req, res, next) {
    console.log(req.body)
    Oxygencreate(req.body).then(function(oxygen) {
        res.send(oxygen);
    }).catch(next);
});

// API endpoint - update a oxygen
router.put('/oxygen/:id', function(req, res) {
    console.log(req);
    
    // find user document by id and update with request body
    Oxygen.findOneAndUpdate({ _id: req.params.id }, req.body).then(function() {
        // check if this works by finding User's unique _id and checking for update
        Oxygen.findOne({ _id: req.params.id }).then(function(oxygen) {
            console.log(oxygen);
            // send update back to as response
            res.send(oxygen);
            
        });
    });
});

// API endpoint - delete a oxygen
router.delete('/oxygen/:id', function(req, res) {
    // find user document by id, delete
    Oxygen.findByIdAndRemove({ _id: req.params.id }, req.body).then(function(oxygen) {
        // send update back to as response
        res.send(oxygen);
    });
})

// expoert router object with oxygen endpoint 
module.exports = router;