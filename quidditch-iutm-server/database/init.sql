-- noinspection SqlNoDataSourceInspectionForFile

-- TABLES

create table championship (
	id serial primary key not null,
	year int not null,
	name char(50) not null
);

create table club (
	id serial primary key not null,
	name char(50) not null
);

create table team (
	id serial primary key not null,
	name char(50) not null,
	logo oid default null,
	championship_id serial not null,
	club_id serial not null,
	constraint fk_championship_id
		foreign key (championship_id) references championship(id),
	constraint fk_club_id
		foreign key (club_id) references club(id)
);

create table match (
	id serial primary key not null,
	status int not null,
	home_team serial not null,
	visitor_team serial not null,
	date_match date not null,
	time_match time not null,
	constraint fk_home_team
		foreign key (home_team) references team(id),
	constraint fk_visitor_team
		foreign key (visitor_team) references team(id)
);

create table player (
	id serial primary key not null,
	firstname char(50) not null,
	lastname char(50) not null,
	date_of_birth date not null,
	number int not null,
	club_id serial not null,
	constraint fk_club_id
		foreign key (club_id) references club(id)
);

create table event (
	id serial primary key not null,
	time int not null,
	description text default null,
	type int not null,
	match_id serial not null,
	player_id serial not null,
	constraint fk_player_id
		foreign key (player_id) references player(id),
    constraint fk_match_id
        foreign key (match_id) references match(id)
);

-- VALEURS

insert into championship (year, name)
values (2020, 'Championnat de Poudelard 2020');
insert into championship (year, name)
values (2021, 'Championnat de Poudelard 2021');

insert into club (name)
values('Gryffondor');
insert into club (name)
values('Poufsouffle');
insert into club (name)
values('Serdaigle');
insert into club (name)
values('Serpentard');

insert into team (name, championship_id, club_id)
values ('Gryffondor2020', 1, 1);
insert into team (name, championship_id, club_id)
values ('Gryffondor2021', 2, 1);
insert into team (name, championship_id, club_id)
values ('Poufsouffle2020', 1, 2);
insert into team (name, championship_id, club_id)
values ('Poufsouffle2021', 2, 2);
insert into team (name, championship_id, club_id)
values ('Serdaigle2020', 1, 3);
insert into team (name, championship_id, club_id)
values ('Serdaigle2021', 2, 3);
insert into team (name, championship_id, club_id)
values ('Serpentard2020', 1, 4);
insert into team (name, championship_id, club_id)
values ('Serpentard2021', 2, 4);

insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Harry', 'Potter', '1994-01-05', 10, 1);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Granger', 'Hermione', '1994-05-17', 4, 1);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Crivey', 'Colin', '1992-08-03', 6, 1);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Oneal', 'Rionach', '1992-12-26', 12, 1);

insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Wolpert', 'Nigel', '1994-01-05', 10, 2);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('McClaggan', 'Remus', '1994-05-17', 4, 2);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Midgen', 'James', '1992-08-03', 6, 2);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Folley', 'Steeve', '1992-12-26', 12, 2);

insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Parvati', 'Peter', '1994-01-05', 10, 3);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Kirke', 'Andrex', '1994-05-17', 4, 3);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Peakes', 'Jeremy', '1992-08-03', 6, 3);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Prewett', 'Molly', '1992-12-26', 12, 3);

insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Vane', 'Christian', '1994-01-05', 10, 4);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Robins', 'Demetra', '1994-05-17', 4, 4);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Spinnet', 'Finn', '1992-08-03', 6, 4);
insert into player (firstname, lastname, date_of_birth, number, club_id)
values ('Fleamont', 'Charlie', '1992-12-26', 12, 4);

-- status : 0 = programmé ; 1 = en cours ; 2 = terminé
-- golden_snitch : 0 = aucune équipe ; 1 = domicile ; 2 = extérieur
insert into match (status, home_team, visitor_team, date_match, time_match)
values (2, 1, 2, '2020-01-01', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (2, 3, 4, '2020-01-15', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (2, 4, 1, '2020-02-01', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (2, 2, 3, '2020-02-15', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (2, 1, 3, '2020-03-01', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (2, 2, 4, '2020-03-15', '16:00:00');

insert into match (status, home_team, visitor_team, date_match, time_match)
values (0, 5, 6, '2021-06-01', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (0, 7, 8, '2021-06-15', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (0, 8, 5, '2021-07-01', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (0, 6, 7, '2021-07-15', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (0, 5, 7, '2021-08-01', '16:00:00');
insert into match (status, home_team, visitor_team, date_match, time_match)
values (0, 6, 8, '2021-08-15', '16:00:00');

-- type : 0 = but ; 1 = vif d'or ; 2 = blessure ; 3 = faute
insert into event (time, type, match_id, player_id)
values (12, 0, 1, 2);
insert into event (time, type, match_id, player_id)
values (32, 0, 1, 4);
insert into event (time, type, match_id, player_id)
values (64, 0, 1, 6);
insert into event (time, type, match_id, player_id)
values (15, 2, 1, 1);

insert into event (time, type, match_id, player_id)
values (40, 0, 2, 9);
insert into event (time, type, match_id, player_id)
values (69, 0, 2, 15);
insert into event (time, type, match_id, player_id)
values (73, 0, 1, 16);

insert into event (time, type, match_id, player_id)
values (12, 0, 3, 3);
insert into event (time, type, match_id, player_id)
values (28, 0, 3, 13);
insert into event (time, type, match_id, player_id)
values (45, 0, 3, 4);
insert into event (time, type, match_id, player_id)
values (67, 0, 3, 1);
insert into event (time, type, match_id, player_id)
values (35, 3, 3, 15);
insert into event (time, type, match_id, player_id)
values (23, 3, 3, 14);

insert into event (time, type, match_id, player_id)
values (12, 0, 4, 5);
insert into event (time, type, match_id, player_id)
values (32, 0, 4, 6);
insert into event (time, type, match_id, player_id)
values (64, 0, 4, 9);
insert into event (time, type, match_id, player_id)
values (15, 2, 4, 5);

insert into event (time, type, match_id, player_id)
values (40, 0, 5, 1);
insert into event (time, type, match_id, player_id)
values (69, 0, 5, 3);
insert into event (time, type, match_id, player_id)
values (73, 0, 5, 10);

insert into event (time, type, match_id, player_id)
values (12, 0, 6, 5);
insert into event (time, type, match_id, player_id)
values (28, 0, 6, 8);
insert into event (time, type, match_id, player_id)
values (45, 0, 6, 6);
insert into event (time, type, match_id, player_id)
values (67, 0, 6, 13);
insert into event (time, type, match_id, player_id)
values (35, 3, 6, 14);
insert into event (time, type, match_id, player_id)
values (23, 3, 6, 15);
