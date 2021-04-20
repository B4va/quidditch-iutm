const readClubs = async (req, res) => {
    // todo : données de test à remplacer
    // const championships = await axios.get('http://localhost/championships');
    const clubs = [
        {
            "id": 1,
            "name": "Griffondor",
            "teams": [
                {
                    "id": 1,
                    "name": "Griffondor 2000"
                },
                {
                    "id": 2,
                    "name": "Griffondor 2001"
                },
            ]
        },
        {
            "id": 2,
            "name": "Serpentard",
            "teams": [
                {
                    "id": 3,
                    "name": "Serpentard 2000"
                },
                {
                    "id": 4,
                    "name": "Serpentard 2001"
                },
            ]
        },
    ];
    res.render('clubs', {
        title: 'Clubs',
        clubs: clubs
    });
}

const readClub = async (req, res) => {

}

module.exports = {
    readClubs,
    readClub
}
