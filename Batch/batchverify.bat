for /d %%i in (E:\UPLOADED\*) do (
node verifypdf.js %%i\optimized
)