@echo off
REM Limpiar la pantalla
cls

REM Definir el nombre de la clase principal (el archivo que contiene el método main)
set MAIN_CLASS=TicTacToe

REM Compilar todos los archivos .java en la carpeta actual
echo Compilando archivos Java...
java --version
javac *.java

REM Verificar si la compilación fue exitosa
if %errorlevel% equ 0 (
    echo Compilación exitosa.
    echo Ejecutando la aplicación...
    java %MAIN_CLASS%
) else (
    echo Error durante la compilación. Revisa los mensajes de error.
)

REM Pausar la ejecución para ver los resultados
pause