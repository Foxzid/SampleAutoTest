@echo off
if exist "allure-results" (
    rd /s /q "allure-results"
    mkdir "allure-results"
    echo [OK] Allure results cleared.
)
pause