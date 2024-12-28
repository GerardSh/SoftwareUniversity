CREATE TABLE Users 
(
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARCHAR(MAX),
	[LastLoginTime] DATETIME,
	[IsDeleted] BIT
)

INSERT INTO Users ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted]) VALUES
	('Username1', 'Password1', 'https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.planetware.com%2Fwpimages%2F2020%2F02%2Ffrance-in-pictures-beautiful-places-to-photograph-eiffel-tower.jpg&imgrefurl=https%3A%2F%2Fwww.planetware.com%2Fpictures%2Ffrance-f.htm&tbnid=YXgcNflll9kS8M&vet=12ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygAegUIARC3AQ..i&docid=0N6qTt3P-PlepM&w=730&h=487&q=pictures&client=firefox-b-d&ved=2ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygAegUIARC3AQ', '2001/01/01 01:01:01 AM', 0),
	('Username2', 'Password2', 'https://www.google.com/imgres?imgurl=https%3A%2F%2Fichef.bbci.co.uk%2Fnews%2F999%2Fcpsprodpb%2F79F2%2Fproduction%2F_123381213_06.jpg&imgrefurl=https%3A%2F%2Fwww.bbc.com%2Fnews%2Fin-pictures-60497480&tbnid=UnMrrsyo3C1oWM&vet=12ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygBegUIARC5AQ..i&docid=mvv72yZTxRGDYM&w=999&h=666&q=pictures&client=firefox-b-d&ved=2ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygBegUIARC5AQ', '2002/02/02 02:02:02 AM', 0),
	('Username3', 'Password3', 'https://www.google.com/imgres?imgurl=https%3A%2F%2Fmedia.istockphoto.com%2Fphotos%2Fvillefranche-on-sea-in-evening-picture-id1145618475%3Fk%3D20%26m%3D1145618475%26s%3D612x612%26w%3D0%26h%3D_mC6OZt_eWENYUAZz3tLCBTU23uvx5beulDEZHFLsxI%3D&imgrefurl=https%3A%2F%2Fwww.istockphoto.com%2Fphotos%2Fnice-france&tbnid=2bI2d2Te4wRpHM&vet=12ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygCegUIARC7AQ..i&docid=r-Fk3AoZUWaRQM&w=612&h=420&q=pictures&client=firefox-b-d&ved=2ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygCegUIARC7AQ', '2003/03/03 03:03:03 AM', 0),
	('Username4', 'Password4', 'https://www.google.com/imgres?imgurl=https%3A%2F%2Fichef.bbci.co.uk%2Fnews%2F999%2Fcpsprodpb%2F15951%2Fproduction%2F_117310488_16.jpg&imgrefurl=https%3A%2F%2Fwww.bbc.co.uk%2Fnews%2Fin-pictures-56211135&tbnid=Hc5jHkS6Vw5sZM&vet=12ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygDegUIARC-AQ..i&docid=aPImLvUOjpk0SM&w=999&h=749&q=pictures&client=firefox-b-d&ved=2ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygDegUIARC-AQ', '2004/04/04 04:04:04 AM', 1),
	('Username5', 'Password5', 'https://www.google.com/imgres?imgurl=https%3A%2F%2Fcdn.pixabay.com%2Fphoto%2F2015%2F04%2F23%2F22%2F00%2Ftree-736885__480.jpg&imgrefurl=https%3A%2F%2Fpixabay.com%2Fimages%2Fsearch%2Fnature%2F&tbnid=DH7p1w2o_fIU8M&vet=12ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygEegUIARDAAQ..i&docid=Ba_eiczVaD9-zM&w=771&h=480&q=pictures&client=firefox-b-d&ved=2ahUKEwiBg77gnaX3AhXJOewKHUXmAIwQMygEegUIARDAAQ', '2005/05/05 05:05:05 AM', 1)