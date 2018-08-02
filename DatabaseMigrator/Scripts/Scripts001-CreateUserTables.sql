BEGIN TRANSACTION;

CREATE TABLE Groups (
	GroupID bigserial NOT NULL,
    Name varchar(256) NULL,
	AddedDate timestamp DEFAULT (NOW() at time zone 'utc'),
    CONSTRAINT PK_Groups_GroupID PRIMARY KEY (GroupID)
);

CREATE TABLE GlobalUsers (
	UserID bigserial NOT NULL,
    Name varchar(256) NULL,
    Address varchar(256) NULL,
    PassportNumber varchar(256) NULL,
    GroupID bigint NULL,
	AddedDate timestamp DEFAULT (NOW() at time zone 'utc'),
    CONSTRAINT PK_GlobalUsers_UserID PRIMARY KEY (UserID),
	CONSTRAINT FK_GlobalUsers_Groups_GroupID FOREIGN KEY (GroupID) REFERENCES Groups (GroupID)
);

CREATE TABLE UserLocations (
	UserLocationID bigserial NOT NULL,
    UserID bigint NOT NULL,
	GroupID bigint NOT NULL,
	AddedDate timestamp DEFAULT (NOW() at time zone 'utc'),
    CONSTRAINT PK_UserLocations_UserID PRIMARY KEY (UserLocationID),
	CONSTRAINT FK_UserLocations_GlobalUsers_UserID FOREIGN KEY (UserID) REFERENCES GlobalUsers (UserID),
	CONSTRAINT FK_UserLocations_Groups_GroupID FOREIGN KEY (GroupID) REFERENCES Groups (GroupID)
);

COMMIT TRANSACTION;