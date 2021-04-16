//
const mongoose = require('mongoose');
const Schema = mongoose.Schema;

// create schema and model
// pass in object with different properties and their data types
const VitalSchema = new Schema({
    heartrate: {
        type: Number,
        default: 0.0
    },
    oxygen: {
        type: Number,
        default: 0.0
    },
    temperature: {
        type: Number,
        default: 0.0
    },   
    timestamp: {
        type: Date,
        default: Date.now
    }
});
// create new collection modelled after UserSchema
// used as model anytime a new user is created
//const Users = mongoose.model('Users', UsersSchema);

// export so you can use in app
module.exports = mongoose.model('Vital', VitalSchema);

// ... 
// create a new user in another file
//var newUser = new User({})