DELETE FROM [innovator].SUPPORT_INCIDENT_ATTACHMENT 
	WHERE SOURCE_ID in (select id from [innovator].[SUPPORT_INCIDENT] where SUMMARY = 'test_summary') 
GO

DELETE FROM [innovator].SUPPORT_INCIDENT_COMMENT 
	WHERE SOURCE_ID in (select id from [innovator].[SUPPORT_INCIDENT] where SUMMARY = 'test_summary') 
GO

DELETE FROM [innovator].SUPPORT_INCIDENT_RELATED 
	WHERE SOURCE_ID in (select id from [innovator].[SUPPORT_INCIDENT] where SUMMARY = 'test_summary') 
GO

DELETE FROM [innovator].SUPPORT_INCIDENT 
	WHERE SUMMARY = 'test_summary' 
GO