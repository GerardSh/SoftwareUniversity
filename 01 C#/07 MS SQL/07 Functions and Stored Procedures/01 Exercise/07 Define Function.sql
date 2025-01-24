CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(30), @word VARCHAR(30))
RETURNS BIT
AS
BEGIN
   DECLARE @counter INT = 1;
         WHILE (@counter <= LEN(@word))
         BEGIN
		     IF(CHARINDEX(SUBSTRING(@word, @counter, 1), @setOfLetters) = 0)
			 BEGIN 
					RETURN 0;
			 END
             SET @counter += 1;
         END

		 RETURN 1
END