const axios = require('axios');
const enums = require('../enums');

const readMatch = async (req, res) => {
    const id = req.params.id;
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
    // const status = await axios.patch(`http://localhost/matches/${id}`);
    res.redirect(`/matches/${id}`);
}

const newMatchEvent = async (req, res) => {

}

const createMatchEvent = async (req, res) => {

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
    newMatchEvent
}
