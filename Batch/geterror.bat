@echo off
for /d %%i in (E:\UPLOADED\*) do (
for  %%j in (%%i\*.pdf) do (
echo %%j
)
)