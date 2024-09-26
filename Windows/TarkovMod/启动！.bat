@echo off
setlocal
 
REM Define paths
set "battleyentShortcut=%~dp0battleyent.exe"
set "smiPath=%~dp0smi.exe"
 
REM Step 1: Start battleyent shortcut with administrative privileges
echo Starting battleyent shortcut with administrative privileges...
powershell -Command "Start-Process '%battleyentShortcut%' -Verb runAs"

echo Copying latest dll build
copy /Y ".\MyMod\EscapeFromTarkovCheat\bin\x64\Debug\EscapeFromTarkovCheat.dll" ".\EscapeFromTarkovCheat.dll"
@REM copy /Y ".\StupidSolutions\stupid.solutions\stupid.solutions\bin\Debug\stupid.solutions.dll" ".\stupid.solutions.dll"
echo Done

REM Step 2: Wait for EscapeFromTarkov.exe to start
echo Waiting for EscapeFromTarkov.exe to start...
:WaitForEscapeFromTarkov
tasklist /FI "IMAGENAME eq EscapeFromTarkov.exe" 2>NUL | find /I /N "EscapeFromTarkov.exe" > NUL
if "%ERRORLEVEL%"=="0" (
    echo EscapeFromTarkov.exe has started.
    goto WaitBeforeStoppingService
)
timeout /t 5 /nobreak > NUL
goto WaitForEscapeFromTarkov
 
:WaitBeforeStoppingService
REM Wait 10 seconds before killing the service
echo Waiting for 10 seconds before stopping BEService...
timeout /t 10 /nobreak > NUL
 
REM Kill the BEService
echo Stopping BEService...
net stop "BEService"
 
@REM REM Wait 4 seconds
@REM echo Waiting for 4 seconds...
@REM timeout /t 4 /nobreak > NUL
 
@REM REM Start smi.exe with parameters
@REM echo Starting smi.exe with parameters...
@REM start "" "%smiPath%" inject -p EscapeFromTarkov -a EscapeFromTarkovCheat.dll -n EscapeFromTarkovCheat -c Loader -m Load
 
REM Final wait before closing
echo Script completed. Waiting for 5 seconds before closing...
timeout /t 5 /nobreak > NUL
 
endlocal