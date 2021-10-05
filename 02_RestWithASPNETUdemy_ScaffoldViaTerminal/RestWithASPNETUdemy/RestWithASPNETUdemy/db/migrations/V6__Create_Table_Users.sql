CREATE TABLE users
(
	id INT IDENTITY PRIMARY KEY,
	user_name varchar(50) NOT NULL,
	password varchar(130) not null,
	full_name varchar(120) not null,
	refresh_token varchar(500),
	refresh_token_expiry_time datetime
)