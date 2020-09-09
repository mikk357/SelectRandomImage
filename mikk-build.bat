
@RD /q /s bin
@RD /q /s obj
@RD /q /s dist

::dotnet publish^
:: -o dist^
:: -r win-x64^
:: --self-contained=true^
:: -p:PublishReadyToRun=true^
:: -p:PublishSingleFile=true^
:: -p:PublishTrimmed=true

dotnet publish^
 -o dist^
 -r win-x64^
 -p:PublishReadyToRun=true^
 -p:PublishSingleFile=true

@DEL dist\**.pdb