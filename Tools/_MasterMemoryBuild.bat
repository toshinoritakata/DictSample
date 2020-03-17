@echo on

set MMGEN="MasterMemory.Generator\win-x64\MasterMemory.Generator.exe"
set MPC="MessagePackUniversalCodeGenerator\win-x64\mpc.exe"
set NAME_SPACE=CGWORLD
set SCRIPT_PATH="..\Assets\Sample2\Scripts"

del /S /Q %SCRIPT_PATH%\Generated

%MMGEN% -i %SCRIPT_PATH%\Tables -o %SCRIPT_PATH%\Generated -n %NAME_SPACE%
%MPC% -i ..\Assembly-CSharp.csproj -o %SCRIPT_PATH%\Generated\MessagePack.Generated.cs