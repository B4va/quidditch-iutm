const axios = require('axios');
const enums = require('../enums');

const readChampionships = async (req, res) => {
    // todo : données de test à remplacer
    // const championships = await axios.get('http://localhost/championships');
    const championships = [
        {
            "id": 1,
            "year": 2000,
            "name": "Championnat de Poudelard 2000"
        },
        {
            "id": 2,
            "year": 2001,
            "name": "Championnat de Poudelard 2001"
        }
    ];
    res.render('championships', {
        title: 'Championnats',
        championships: championships.sort((a, b) => a.year - b.year).reverse()
    });
}

const readLastChampionship = async (req, res) => {
    // todo : données de test à remplacer
    // const championship = await axios.get('http://localhost/championships/last');
    const championship = {
        id: 1,
        year: 2000,
        name: "Championnat de Poudelard 2000",
        teams: [
            {
                id: 1,
                name: "Gryffondor 2000",
                logo: undefined,
                points: 14
            },
            {
                id: 2,
                name: "Poufesouffle 2000",
                logo: undefined,
                points: 8
            },
            {
                id: 3,
                name: "Serdaigle 2000",
                logo: undefined,
                points: 10
            },
            {
                id: 4,
                name: "Serpentard 2000",
                logo: undefined,
                points: 12
            }
        ]
    };
    renderCHampionship(res, championship);
}

const readChampionship = async (req, res) => {
    const id = req.params.id;
    // todo : données de test à remplacer
    // const championship = await axios.get(`http://localhost/championships/${id}`);
    const championship = {
        id: 1,
        year: 2000,
        name: "Championnat de Poudelard 2000",
        teams: [
            {
                id: 1,
                name: "Gryffondor 2000",
                logo: undefined,
                points: 14
            },
            {
                id: 2,
                name: "Poufesouffle 2000",
                logo: undefined,
                points: 8
            },
            {
                id: 3,
                name: "Serdaigle 2000",
                logo: undefined,
                points: 10
            },
            {
                id: 4,
                name: "Serpentard 2000",
                logo: undefined,
                points: 12
            }
        ]
    };
    renderCHampionship(res, championship);
}

const readChampionshipMatches = async (req, res) => {
    const id = req.params.id;
    // todo : données de test à remplacer
    // const championshipMatches = await axios.get(`http://localhost/championships/${id}/matches`);
    const championshipMatches = {
        id: 1,
        year: 2000,
        name: "Championnat de Poudelard 2000",
        matches: [
            // terminé, au score
            {
                id: 1,
                date: "01-01-2000 18:00",
                status: 2,
                goldenSnitch: 0,
                homeTeam: {
                    id: 1,
                    name: "Gryffondor 2000",
                    score: 18
                },
                visitorTeam: {
                    id: 1,
                    name: "Serpentard 2000",
                    score: 12
                }
            },
            // terminé, vif d'or domicile
            {
                id: 2,
                date: "01-01-1999 18:00",
                status: 2,
                goldenSnitch: 1,
                homeTeam: {
                    id: 1,
                    name: "Gryffondor 2000",
                    score: 18
                },
                visitorTeam: {
                    id: 1,
                    name: "Serpentard 2000",
                    score: 12
                }
            },
            // terminé, vif d'or extérieur
            {
                id: 3,
                date: "01-01-1998 18:00",
                status: 2,
                goldenSnitch: 2,
                homeTeam: {
                    id: 1,
                    name: "Gryffondor 2000",
                    score: 18
                },
                visitorTeam: {
                    id: 1,
                    name: "Serpentard 2000",
                    score: 12
                }
            },
            // programmé
            {
                id: 4,
                date: "01-01-1997 18:00",
                status: 0,
                goldenSnitch: 0,
                homeTeam: {
                    id: 1,
                    name: "Gryffondor 2000",
                    score: 0
                },
                visitorTeam: {
                    id: 1,
                    name: "Serpentard 2000",
                    score: 0
                }
            },
            // en cours
            {
                id: 5,
                date: "01-01-1996 18:00",
                status: 1,
                goldenSnitch: 0,
                homeTeam: {
                    id: 1,
                    name: "Gryffondor 2000",
                    score: 15
                },
                visitorTeam: {
                    id: 1,
                    name: "Serpentard 2000",
                    score: 3
                }
            },
        ]
    }
    championshipMatches.matches.forEach(m => processMatchResult(m));
    res.render('matches', {
        title: `${championshipMatches.name} - Matchs`,
        championshipName: championshipMatches.name,
        matches: championshipMatches.matches.sort((a, b) => new Date(a.date) - new Date(b.date)).reverse(),
        id: championshipMatches.id,
        STATUS: enums.MATCH_STATUS,
        SNITCH: enums.GOLDEN_SNITCH
    });
}

const renderCHampionship = (res, championship) => {
    res.render('championship', {
        title: championship.name,
        championshipName: championship.name,
        teams: championship.teams.sort((a, b) => a.points - b.points).reverse(),
        id: championship.id
    });
}

const processMatchResult = match => {
    if (match.homeTeam.score > match.visitorTeam.score) {
        match.homeTeam.win = true;
        match.visitorTeam.win = false;
    } else if (match.homeTeam.score < match.visitorTeam.score) {
        match.homeTeam.win = false;
        match.visitorTeam.win = true;
    } else {
        match.homeTeam.win = false;
        match.visitorTeam.win = false;
    }
    if (match.goldenSnitch === enums.GOLDEN_SNITCH.HOME) {
        match.homeTeam.win = true;
        match.visitorTeam.win = false;
    } else if (match.goldenSnitch === enums.GOLDEN_SNITCH.VISITOR) {
        match.homeTeam.win = false;
        match.visitorTeam.win = true;
    }
}

module.exports = {
    readChampionships,
    readLastChampionship,
    readChampionship,
    readChampionshipMatches
}
