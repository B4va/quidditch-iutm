const axios = require('axios');
const enums = require('../enums');

const readMatch = async (req, res) => {
    const id = req.params.id;
    // todo : données de test à remplacer
    // const match = await axios.get(`http://localhost/matches/${id}`);
    const match = {
        id: 1,
        status: 1,
        date: "01-01-2000",
        time: 16,
        home: {
            id: 1,
            name: "Griffondor",
            logo: null
        },
        visitor: {
            id: 4,
            name: "Serpentard",
            logo: null
        },
        scoreHome: 1,
        scoreVisitor: 2,
        goldenSnitch: 0,
        events: [
            {
                id: 1,
                time: 6,
                description: "Faute de Serpentard",
                type: 2,
                player: {
                    name: "Drago Malfoy",
                    number: 10
                }
            },
            {
                id: 2,
                time: 11,
                description: "But de Serpentard : 2 points",
                type: 0,
                player: {
                    name: "Drago Malfoy",
                    number: 10
                }
            },
            {
                id: 3,
                time: 13,
                description: "But de Griffondor : 1 points",
                type: 0,
                player: {
                    name: "Harry Potter",
                    number: 8
                }
            },
        ]
    }
    processMatchResult(match);
    res.render('match', {
        title: `${match.home.name} - ${match.visitor.name}`,
        name: `${match.home.name} - ${match.visitor.name}`,
        match: match,
        STATUS: enums.MATCH_STATUS,
        SNITCH: enums.GOLDEN_SNITCH,
        TYPE: enums.EVENT_TYPE
    });
}

const updateMatch = async (req, res) => {
    const id = req.params.id;
    // todo : données de test à remplacer
    // const status = await axios.patch(`http://localhost/matches/${id}`);
    res.redirect(`/matches/${id}`);
}

const newMatchEvent = async (req, res) => {
    const matchId = req.params.id;
    // const players = const status = await axios.get(`http://localhost/matches/${id}/players`)
    const players = [
        {
            id: 1,
            name: "Harry Potter",
            number: 8
        },
        {
            id: 2,
            name: "Drago Malfoy",
            number: 10
        },
        {
            id: 3,
            name: "Hermionne Granger",
            number: 3
        }
    ]
    res.render('newEvent', {
        title: `Nouveau fait de jeu`,
        players: players,
        matchId: matchId,
        TYPE: enums.EVENT_TYPE,
        SNITCH: enums.GOLDEN_SNITCH
    });
}

const createMatchEvent = async (req, res) => {
    const data = req.body;
    data.matchId = req.params.id;
    // todo : requête de test à remplacer
    // const status = await axios.post(`http://localhost/matches/${data.matchId}/event`, JSON.parse(data));
    res.redirect(`/matches/${data.matchId}`);
}

const deleteMatchEvent = async (req, res) => {
    const matchId = req.params.matchId;
    const eventId = req.params.eventId;
    // todo : requête de test à remplacer
    // const status = await axios.delete(`http://localhost/events/${eventId}`);
    res.redirect(`/matches/${matchId}`);
}

const processMatchResult = match => {
    if (match.scoreHome > match.scoreVisitor) {
        match.home.win = true;
        match.visitor.win = false;
    } else if (match.scoreHome < match.scoreVisitor) {
        match.home.win = false;
        match.visitor.win = true;
    } else {
        match.home.win = false;
        match.visitor.win = false;
    }
    if (match.goldenSnitch === enums.GOLDEN_SNITCH.HOME) {
        match.home.win = true;
        match.visitor.win = false;
    } else if (match.goldenSnitch === enums.GOLDEN_SNITCH.VISITOR) {
        match.home.win = false;
        match.visitor.win = true;
    }
}

module.exports = {
    readMatch,
    updateMatch,
    createMatchEvent,
    newMatchEvent,
    deleteMatchEvent
}
