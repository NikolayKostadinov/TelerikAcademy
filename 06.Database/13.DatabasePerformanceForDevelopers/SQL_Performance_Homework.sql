CREATE DATABASE LogMessages

USE LogMessages

DROP TABLE LogMessages

CREATE TABLE LogMessages(
LogMessageId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
MessageDate datetime NOT NULL,
MessageText nvarchar(100)
)

DECLARE @Date datetime
DECLARE @Message nvarchar(100)
DECLARE @RowCount int = 1 
WHILE (SELECT COUNT(*) FROM LogMessages) < 10000000
BEGIN
	SET @Date = DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
	SET @Message = 'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +  CONVERT(nvarchar(100), newid())
	INSERT INTO LogMessages (MessageDate, MessageText)
	VALUES(@Date, @Message)
	SET @RowCount = @RowCount + 1
END

WHILE (SELECT COUNT(*) FROM LogMessages) < 10000000
BEGIN
	INSERT INTO LogMessages (MessageDate, MessageText)
	SELECT MessageDate, MessageText FROM LogMessages
END

DROP INDEX MessageDateIndex ON LogMessages

CREATE INDEX MessageDateIndex ON LogMessages(MessageDate) INCLUDE(LogMessageId, MessageText)
GO


CREATE FULLTEXT CATALOG LogMessagesFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF
GO
CREATE FULLTEXT INDEX ON LogMessages(MessageText)
KEY INDEX PK__LogMessa__493393C31A6B79A7
ON LogMessagesFullTextCatalog
WITH CHANGE_TRACKING AUTO
GO
