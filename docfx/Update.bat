@echo off

REM --------------------------------------------------
REM Step 1: Generate API metadata
REM --------------------------------------------------
echo 1. Running: docfx metadata
docfx metadata
IF %ERRORLEVEL% NEQ 0 (
    echo Metadata generation failed ^(code %ERRORLEVEL%^). Exiting.
    pause
    exit /b %ERRORLEVEL%
) ELSE (
    echo Metadata generation completed successfully.
)

REM --------------------------------------------------
REM Step 2: Build the site
REM --------------------------------------------------
echo 2. Running: docfx build
docfx build
IF %ERRORLEVEL% NEQ 0 (
    echo Build failed ^(code %ERRORLEVEL%^). Exiting.
    pause
    exit /b %ERRORLEVEL%
) ELSE (
    echo Build completed successfully.
)

REM --------------------------------------------------
REM Step 3: Serve the site locally
REM --------------------------------------------------
docfx serve _site
IF %ERRORLEVEL% NEQ 0 (
    echo Server terminated with error code %ERRORLEVEL%.
    pause
    exit /b %ERRORLEVEL%
)
pause
