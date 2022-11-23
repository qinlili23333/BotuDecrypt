mkdir ..\v2opt
for %%i in (*) do (
echo Processing %%i
mutool clean -g -gg -ggg -gggg -c -s -z "%%i" "..\v2opt\%%i"
)