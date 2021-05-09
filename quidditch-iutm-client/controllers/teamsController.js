const enums = require("../enums");

const readTeam = async (req, res) => {
    const id = req.params.id;
    // todo : données de test à remplacer
    // const team = await axios.get(`http://localhost/teams/${id}`);
    const team = {
            id: 1,
            name: "Griffondor 2000",
            matches: [
                // terminé, au score
                {
                    id: 1,
                    status: 2,
                    date: "01-01-2000",
                    time: 16,
                    home: false,
                    opponent: {
                        id: 4,
                        name: "Serpentard",
                        logo: null
                    },
                    scoreHome: 1,
                    scoreVisitor: 2,
                    goldenSnitch: false
                },
                // terminé, vif d'or domicile
                {
                    id: 2,
                    status: 2,
                    date: "01-01-2000",
                    time: 16,
                    home: true,
                    opponent: {
                        id: 4,
                        name: "Serpentard",
                        logo: null
                    },
                    scoreHome: 1,
                    scoreVisitor: 2,
                    goldenSnitch: 1
                },
                // terminé, vif d'or extérieur
                {
                    id: 3,
                    status: 2,
                    date: "01-01-2000",
                    time: 16,
                    home: true,
                    opponent: {
                        id: 4,
                        name: "Serpentard",
                        logo: null
                    },
                    scoreHome: 1,
                    scoreVisitor: 2,
                    goldenSnitch: 2
                },
                // programmé
                {
                    id: 4,
                    status: 0,
                    date: "01-01-2000",
                    time: 16,
                    home: true,
                    opponent: {
                        id: 4,
                        name: "Serpentard",
                        logo: null
                    },
                    scoreHome: 0,
                    scoreVisitor: 0,
                    goldenSnitch: false
                },
                // en cours
                {
                    id: 5,
                    status: 1,
                    date: "01-01-2000",
                    time: 16,
                    home: true,
                    opponent: {
                        id: 4,
                        name: "Serpentard",
                        logo: null
                    },
                    scoreHome: 1,
                    scoreVisitor: 2,
                    goldenSnitch: false
                }
            ]
        }
    team.matches.forEach(m => processMatchResult(m));
    res.render('team', {
        title: team.name,
        matches: team.matches.sort((a, b) => new Date(a.date) - new Date(b.date)).reverse(),
        id: team.id,
        team: team.name,
        STATUS: enums.MATCH_STATUS,
        SNITCH: enums.GOLDEN_SNITCH
    });
}

const processMatchResult = match => {
    if (match.scoreHome > match.scoreVisitor) {
        match.homeTeamWin = true;
        match.visitorTeamWin = false;
    } else if (match.scoreHome < match.scoreVisitor) {
        match.homeTeamWin = false;
        match.visitorTeamWin = true;
    } else {
        match.homeTeamWin = false;
        match.visitorTeamWin = false;
    }
    if (match.goldenSnitch === enums.GOLDEN_SNITCH.HOME) {
        match.homeTeamWin = true;
        match.visitorTeamWin = false;
    } else if (match.goldenSnitch === enums.GOLDEN_SNITCH.VISITOR) {
        match.homeTeamWin = false;
        match.visitorTeamWin = true;
    }
}

module.exports = {
    readTeam
}
