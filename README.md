# Quidditch Project - IUTM

> Participants :
> - Kevin JUNCK
> - Loïc STEINMETZ

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

![schéma EA](./img_readme/conception-bdd.png)

**Schéma Relationnel**

*TODO*