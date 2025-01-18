@echo Post build: %1 %2
@echo.%2%|findstr /C:"Release" >nul 2>&1
if not errorlevel 1 (
	@echo RELEASE MODE
	@xcopy /y /d "%1..\x64\Release\GaussianHLL.dll" "%2"
	@xcopy /y /d "%1..\x64\Release\GaussianASM.dll" "%2"
) else (
	@echo DEBUG MODE
	@xcopy /y /d "%1..\x64\Debug\GaussianHLL.dll" "%2"
	@xcopy /y /d "%1..\x64\Debug\GaussianASM.dll" "%2"
)
@exit /b %ERRORLEVEL%