//
const mongoose = require('mongoose');
const Schema = mongoose.Schema;

// create schema and model
// pass in object with different properties and their data types
const TempSchema = new Schema({
    temp_id: {
        type: Number,
        default: 0
    },
    value: {
        type: Number,
        default: 0
    },
    unit: {
        type: String,
        default: "NaN"
    },  
    connected: {
        type: Boolean,
        default: false
    },
    sensor: {
        type: String,
        default: "NaN"
    },  
    timestamp: {
        type: Date,
        default: Date.now
    },
    date: {
        type: Date,
        default: Date.now
    }
});
// create new collection modelled after UserSchema
// used as model anytime a new user is created
//const Users = mongoose.model('Users', UsersSchema);

// export so you can use in app
module.exports = mongoose.model('Temp', TempSchema);

// ... 
// create a new user in another file
//var newUser = new User({})