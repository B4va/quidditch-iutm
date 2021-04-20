const readClubs = async (req, res) => {
    // todo : données de test à remplacer
    // const clubs = await axios.get('http://localhost/clubs');
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

module.exports = {
    readClubs
}
