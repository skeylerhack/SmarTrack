IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBaocaoMoldingDaily' AND KEYWORD =N'AvarialCycleTime') UPDATE LANGUAGES SET VIETNAM=N'Avarial Cycle Time', ENGLISH=N'Avarial Cycle Time',CHINESE=N'Avarial Cycle Time', VIETNAM_OR=N'Avarial Cycle Time', ENGLISH_OR=N'Avarial Cycle Time' , CHINESE_OR=N'Avarial Cycle Time' WHERE FORM=N'ucBaocaoMoldingDaily' AND KEYWORD=N'AvarialCycleTime' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBaocaoMoldingDaily',N'AvarialCycleTime',N'Avarial Cycle Time',N'Avarial Cycle Time',N'Avarial Cycle Time',N'Avarial Cycle Time',N'Avarial Cycle Time',N'Avarial Cycle Time',N'ECOMAIN')