DROP TABLE IF EXISTS Hero;

CREATE TABLE IF NOT EXISTS Hero (
	ID Serial,
	PUBLIC_ID UUID DEFAULT,
    API_ID INTEGER NOT NULL,
    NAME VARCHAR(1000) NULL,
	PRIMARY KEY (PUBLIC_ID)
);