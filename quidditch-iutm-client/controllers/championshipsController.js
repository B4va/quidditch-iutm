const axios = require('axios');

const readChampionships = async (req, res) => {

}

const readLastChampionship = async (req, res) => {
    // todo : données de test à remplacer
    // const championship = await axios.get('http://localhost:80/championships/last');
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
    res.render('championship', {
        title: 'Championnat en cours',
        championshipName: championship.name,
        teams: championship.teams.sort((a, b) => a.points - b.points).reverse(),
        id: championship.id
    });
}

const readChampionship = async (req, res) => {

}

const readChampionshipMatches = async (req, res) => {

}

module.exports = {
    readChampionships,
    readLastChampionship,
    readChampionship,
    readChampionshipMatches
}
