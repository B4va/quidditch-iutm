# Quidditch Project - IUTM

> Participants :
> - [Kevin JUNCK](https://github.com/novachrono67)
> - [Loïc STEINMETZ](https://github.com/B4va)

Le projet consiste en une API permettant de gérer les résultats des différents championnats de quidditch de l'école de
Poudelard. Il propose également un client web pour pouvoir accéder et gérer ces informations.

## Exécution

```
$ docker-compose up --build -d
```

- L'API est accessible à partir de l'url : `localhost:8080/`
- Le site web client est accessible à partir de l'url : `localhost:3000/`

## Conception

### Architecture générale

Le projet fonctionne sur la base de trois conteneurs **Docker** :

- Une base de données **PostgresSQL**
- Une application serveur, développée en **C#** suivant l'architecture **REST**.
- Une application client, développée en **JavaScript** via **Node**.

![archi](./img_readme/conception-archi.png)

### Base de données

La base de données est configurée et alimentée via le script `database/init.sql`.

**Schéma Entités-Associations :**

![Schéma EA](./img_readme/conception-bdd.png)

**Schéma Relationnel**

° = clé primaire
\# = clé étrangère

```
championship(°id, year, name)
club(°id, name)
team(°id, name, logo, #championship_id, #club_id)
match(°id, status, #home_team, #visitor_team, date_match, time_match)
player(°id, firstname, lastname, date_of_birth, number, #club_id)
event(°id, time, description, type, #match_id, #player_id)
```

### Cas d'utilisation

![Cas d'utilisation](./img_readme/conception-cas-utilisation.png)

## Endpoints API

### Liste globale

```
GET /championships
GET /championships/last
GET /championship/:id
GET /championship/:id/matches
GET teams/:id
GET /clubs
GET /clubs/:id
GET /matches/:id
PATCH /matches/:id
POST /matches/:id/event
DELETE /events/:id
```

### Championnats

```
GET /championships

params url : aucun

résultat : informations sur tous les championnats

[
    {
        "id": 1,
        "year": 2000,
        "name": "Championnat de Poudelard 2000"
    },
    ...
]
```

```
GET /championship/:id

params url :
    - id : identifiant du championnat

résultat : informations détaillées d'un championnat

{
   "id": 1,
   "year": 2000,
   "name": "Championnat de Poudelard 2000"
   "teams": [
       {
           "id": 1,
           "name": Gryffondor 2000,
           "logo": data,
           "points": 8
       },
       ...
   ]
}
```

```
GET /championship/last

params url : aucun

résultat : informations détaillées du dernier championnat

{
   "id": 1,
   "year": 2000,
   "name": "Championnat de Poudelard 2000"
   "teams": [
       {
           "id": 1,
           "name": Gryffondor 2000,
           "logo": data,
           "points": 8
       },
       ...
   ]
}
```

```
GET /championship/:id/matches

params url :
    - id : identifiant du championnat

résultat : informations sur les matchs d'un championnat

{
   "id": 1,
   "year": 2000,
   "name": "Championnat de Poudelard 2000"
   "matches": [
       {
           "id": 1,
           "type": 1,
           "date": "01-01-2000 18:00",
           "status": 1,
           "goldenSnitch": false,
           "homeTeam": {
               "id": 1,
               "name": "Gryffondor 2000",
               "score": 18
           },
           "visitorTeam": {
               "id": 1,
               "name": "Serpentard 2000",
               "score": 12
           }
       },
       ...
   ]
}
```

### Equipes

```
GET teams/:id

params url :
    - id : identifiant de l'équipe

résultat : informations détaillées d'une équipe

{
   "id": 1,
   "name": "Gryffondor 2000",
   "logo": data,
   "club": {
       "id": 1,
       "nom": "Gryffondor"
   },
   "matches": [
       {
           "id": 1,
           "status": 1,
           "date": "01-01-2000",
           "time": "16:00"
           "home": true,
           "opponent": {
               "id": 4,
               "name": "Serpentard",
               "logo": data
           },
           "scoreHome": 1,
           "scoreVisitor": 2,
           "goldenSnitch": true
       },
       ...
   ]
}
```

### Clubs

```
GET /clubs

params url :
    - id : identifiant du club

résultat : informations de l'ensemble des clubs

[
    {
        "id": 1,
        "name": "Griffondor",
        "teams": [
            {
                "id": 1,
                "name": "Griffondor 2000"
            },
            ...
        ]
    },
    ...
]
```

```
GET /clubs/:id

params url : aucun

résultat : informations détaillées d'un club

{
    "id": 1,
    "name": "Griffondor",
    "teams": [
        {
            "id": 1,
            "name": "Griffondor 2000",
            "championship_id": 1
        },
        ...
    ]
}
```

### Matchs

```
GET /matches/:id

params url :
    - id : identifiant du match

résultat : informations détaillées d'un match

{
    "id": 1,
    "status": 1,
    "date": "01-01-2000",
    "time": "16:00"
    "home": {
       "id": 1,
       "name": "Griffondor",
       "logo": data
    },
    "visitor": {
       "id": 4,
       "name": "Serpentard",
       "logo": data
    },
    "scoreHome": 1,
    "scoreVisitor": 2,
    "goldenSnitch": true
    "events": [
        {
            "id": 1,
            "time": 42,
            "description": "Faute de Serpentard",
            "type": 1,
            "player": {
                "name": "Drago Malfoy",
                "number": 10
            }
        },
        ...
    ]
}
```

```
PATCH /matches/:id

params url :
    - id : identifiant du match

résultat : lancement d'un match si pas déjà commencé ; arrêt si match en cours

{
    "id": 1,
    "status": 1
}
```

```
POST /matches/:id/event

params URL :
    - id : identifiant du match

params POST :

{
    "matchId": 1,
    "description": "Faute de Serpentard",
    "type": 1,
    "playerId": 4
}

résultat : création d'un événement associé à un match

{
    "id": 1,
    "time": 42,
    "description": "Faute de Serpentard",
    "type": 1,
    "player": {
        "name": "Drago Malfoy",
        "number": 10
    }
}
```

### Événement

```
DELETE /events/:id

params URL :
    - id : identifiant de l'événement

résultat : suppression d'un événement

{
    "success": true
}
```
