ALTER TABLE Users
Add CONSTRAINT CHK_PasswordIsAtLeastFiveSymbols 
	CHECK(LEN([Password]) >= 5)