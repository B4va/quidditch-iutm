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
	logo bytea,
	points int default 0,
	championship_id serial not null,
	club_id serial not null,
	constraint fk_championship_id
		foreign key (championship_id) references championship(id),
	constraint fk_club_id
		foreign key (club_id) references club(id)
);

create table match (
	id serial primary key not null,
	type int not null,
	home_team serial not null,
	visitor_team serial not null,
	score_home int default 0,
	score_visitor int default 0,
	date_match date not null,
	golden_snitch int,
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
	team_id serial not null,
	constraint fk_team_id
		foreign key (team_id) references team(id)
)

create table event (
	id serial primary key not null,
	time int not null,
	description text,
	player_id serial not null,
	constraint fk_player_id
		foreign key (player_id) references player(id)
);