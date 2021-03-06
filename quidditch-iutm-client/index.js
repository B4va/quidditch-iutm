const express = require('express');
const path = require('path');
const ejsLocals = require('ejs-locals');
const bodyParser = require('body-parser');
const championshipsController = require('./controllers/championshipsController');
const teamsController = require('./controllers/teamsController');
const clubsController = require('./controllers/clubsController');
const matchesController = require('./controllers/matchesController');

/**
 * Configuration générale.
 */
const port = process.env.PORT || 3000;
const app = express();
app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, './views'));
app.engine('ejs', ejsLocals);
app.use(bodyParser.json());
app.use(express.urlencoded({extended: true}));
app.use((req, res, next) => {
    next();
    if (req.path !== '/favicon.ico') {
        console.log('----------------------------');
        console.log('Route : ', req.path);
        console.log('Method : ', req.method);
        console.log('Params : ', req.params);
        console.log('Body : ', req.body);
        console.log('----------------------------');
    }
});

/**
 * Lancement du serveur.
 */
app.listen(port, () => console.log(`Serveur lancé sur le port ${port}.`));

/**
 * Routing.
 */

// Home
app.get('/', async (req, res) => await championshipsController.readLastChampionship(req, res));

// Championships
app.get('/championships', async (req, res) => await championshipsController.readChampionships(req, res));
app.get('/championships/:id', async (req, res) => await championshipsController.readChampionship(req, res));
app.get('/last-champ', async (req, res) => await championshipsController.readLastChampionship(req, res));
app.get('/championships/:id/matches', async (req, res) => await championshipsController.readChampionshipMatches(req, res));

// Teams
app.get('/teams/:id', async (req, res) => await teamsController.readTeam(req, res));

// Clubs
app.get('/clubs', async (req, res) => await clubsController.readClubs(req, res));

// Matches
app.get('/matches/:id', async (req, res) => await matchesController.readMatch(req, res));
app.post('/matches/:id', async (req, res) => await matchesController.updateMatch(req, res));
app.get('/matches/:id/event', async (req, res) => await matchesController.newMatchEvent(req, res));
app.post('/matches/:id/event', async (req, res) => await matchesController.createMatchEvent(req, res));
app.get('/matches/:matchId/deleteEvent/:eventId', async (req, res) => await matchesController.deleteMatchEvent(req, res));
