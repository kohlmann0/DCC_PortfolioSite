CREATE TABLE UserResume
(
	UserResumeID int IDENTITY(1,1) NOT NULL PRIMARY KEY,

	ProfileID int FOREIGN KEY REFERENCES ContactProfile(ProfileID) NOT NULL,
	HtmlUpload varbinary(max) NOT NULL
);

CREATE TABLE ProjectSpotlight
(
	ProjectSpotlightID int IDENTITY(1,1) NOT NULL PRIMARY KEY,

	ProfileID int FOREIGN KEY REFERENCES ContactProfile(ProfileID) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	Technologies varchar(255) NULL,
	DevelopmentTime varchar(255) NULL,
	ProjectDescription varchar(max) NULL,
	RepoLink varchar(max) NULL,
	Image_1 image NULL,
	Image_2 image NULL
);

CREATE TABLE TeamMember
(
	TeamMemberID int IDENTITY(1,1) NOT NULL PRIMARY KEY,

	ProfileID int FOREIGN KEY REFERENCES ContactProfile(ProfileID) NOT NULL,
	ProjectSpotlightID int FOREIGN KEY REFERENCES ProjectSpotlight(ProjectSpotlightID) NOT NULL,
);