@echo Post build: %1 %2
@xcopy /y /d "%1..\x64\Debug\GaussianHLL.dll" "%2"
@xcopy /y /d "%1..\x64\Debug\GaussianASM.dll" "%2"
@exit /b %ERRORLEVEL%