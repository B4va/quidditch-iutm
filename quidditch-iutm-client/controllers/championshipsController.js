const axios = require('axios');

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
    // todo : créer les énumérés + prendre en compte les différentes situations de matchs
    const championshipMatches = {
        id: 1,
        year: 2000,
        name: "Championnat de Poudelard 2000",
        matches: [
            {
                id: 1,
                type: 1,
                date: "01-01-2000 18:00",
                status: 1,
                goldenSnitch: false,
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
            ...
        ]
    }
}

const renderCHampionship = (res, championship) => {
    res.render('championship', {
        title: 'Championnat en cours',
        championshipName: championship.name,
        teams: championship.teams.sort((a, b) => a.points - b.points).reverse(),
        id: championship.id
    });
}

module.exports = {
    readChampionships,
    readLastChampionship,
    readChampionship,
    readChampionshipMatches
}
