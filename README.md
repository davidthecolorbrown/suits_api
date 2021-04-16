# Project Description
* setup to allow us to access bluetooth datastream remotely and feed that into Hololens 2.

# project structure
* note; 'localhost' corresponds to addr '127.0.0.1'
## frontend: located in './frontend/' and starts frontend server
* url: 'http://localhost:3000/' or 'http://127.0.0.1:3000/'
* port: 3000
## backend: located in './backend/' and starts mongoDB access server
* url: 'http://localhost:3002/' or 'http://127.0.0.1:3002/'
* port: 3000
### calls to api:
#### vitals (aggregate of all vital measurements)
##### GET request urls
* vitals (aggregate of all measurements): 'http://localhost:3002/api/vitals' 
* GET list of LAST vitals measurement: 'http://localhost:3002/api/vitals/last' 
##### POST request urls

#### oxygen saturation
##### GET request urls
* GET list of ALL oxygen saturation measurements: 'http://localhost:3002/api/oxygen' 
* GET list of LAST oxygen saturation measurement: 'http://localhost:3002/api/oxygen/last' 
##### POST request urls

#### heart rate
##### GET request urls
* GET list of ALL heartrate measurements: 'http://localhost:3002/api/heartrate' 
* GET list of LAST heartrate measurement: 'http://localhost:3002/api/heartrate/last' 
##### POST request urls

#### temperature
##### GET request urls
* GET list of ALL temperature measurements: 'http://localhost:3002/api/temp' 
* GET list of LAST temperature measurement: 'http://localhost:3002/api/temp/last' 
##### POST request urls

# setup mern app (NodeJS + Express + React + MySQL OR MongoDB)
## clone github repo 
* open linux/macOS terminal and navigate to directory you want to store project
    ```bash
    cd ./full/path/to/project/dir/
    ```
* get the github repo url for cloning 
    ```bash
    # repo_url: https://github.com/davidthecolorbrown/suits_api.git
    git clone [repo_url] 
    ```
## install node + dependencies for backend
* first install node.js from node website
* then use node package manager (npm) to initialize project and download common dependencies (in terminal for main project directory):
    * mandatory dependencies: express, mongoose (mongodb), cors
    * common dependecies: nodemon, body-parser, bootstrap, node-fetch, moment, mocha, node-cron
    ```bash
    # install dependencies (npm uses package.json to locate dependencies)
    npm install
    # update the dependencies
    npm update 
    ```
## install react dependencies for frontend and set PORT as environment variable
* react dependencies in frontend folder
    ```bash
    # navigate to project's /frontend/ directory
    cd ./frontend/
    # download basic react app dependencies
    npm install react-router-dom axios bootstrap
    ```
* set PORT number as env variable 
    ```bash
    # create .env variable to hold frontend port info (using 8000)
    echo "PORT=8000" > ".env"
    ```
* move out of frontend directory (back to main project directory)
    ```bash
    cd ..
    ```
## create dev branch (if not done so already) for development
* create a new 'dev' branch and push the new branch (locally) to remote github repo
    ```bash
    # make branch
    git branch dev
    # push to github repo url
    git push origin dev
    # switch to branch
    git checkout dev
    ```
## start the backend for reading database 
* start backend by navigating to main project directory
    ```bash
    # use nodemon to restart server on changes to code
    nodemon
    # (optional) can use package manager if nodemon isn't installed
    npm start
    ```
## start frontend locally and load in browser
* browser will automatically load at 'http://localhost:[frontend-PORT]'
    ```bash
    # navigate to frontend directory 
    cd ./frontend/
    # use package manager to load in browser
    npm start
    ```
## TODO: show how to deploy server to heroku
## TODO: show arduino code
## TODO: show how C# code reads bluetooth