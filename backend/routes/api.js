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

// expoert router object with temp endpoint 
module.exports = router;