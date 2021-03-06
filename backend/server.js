// server.js -- goes in main directory 

// import packages and express router
const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');
const bodyParser = require('body-parser');

// call express to create running app object
const app = express();

// set port and mongoDB url (local or global)
const PORT = 3002;
const MONGODB_URI = "mongodb+srv://admin:admin@cluster0.7yj86.mongodb.net/univ_events?retryWrites=true&w=majority";
//const MONGODB_URI = "mongodb+srv://admin:admin@cluster0.7yj86.mongodb.net/suits?retryWrites=true&w=majority";

// ES6 Promises  -- set global Promise ES6 object equal to Promise
// gets rid of DepreciatedWarning for Promises when running test
mongoose.Promise = global.Promise;

// express blocks cross-origin HTTP requests by default, allow access from other websites/apps
app.use(cors());

// express functions for json parsing, and routing
app.use(express.urlencoded({ extended: true }));


//set up static files
app.use(express.static('public'));

// use HTTP request body parser (middleware)
app.use(bodyParser.json());

// all the api routes ('/api/[filename]/[]')
app.use('/api', require('./routes/api'))
//app.use('/api/e', require('./routes/test'))
//app.use('/api', require('./routes/vitals'))
//app.use('/api', require('./routes/temperature'))
//app.use('/api', require('./routes/heartrate'))
//app.use('/api', require('./routes/oxygen'))

// connect to mongoDB with log messages for successful/unsuccessful connection
mongoose.connect(MONGODB_URI, { useNewUrlParser: true, useFindAndModify: false });
mongoose.connection.once('open', function() {
    console.log('Connected to the Database.');
});
mongoose.connection.on('error', function(error) {
    console.log('Mongoose Connection Error : ' + error);
});

// listen for connects to app at the port listed above
//app.listen(process.env.PORT || PORT, function() {
app.listen(process.env.PORT || PORT, '0.0.0.0', function() {
    //console.log(`Server listening on port ${PORT}.`);
    console.log('Server is started on 0.0.0.0:'+ (process.env.PORT || PORT));
    //console.log('Server is started on 127.0.0.1:'+ (process.env.PORT || PORT));
});