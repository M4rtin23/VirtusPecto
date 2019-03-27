#!/bin/bash
rm '/home/martin/Documentos/Projectos/C#/VirtusPecto/bin/DesktopGL/Any CPU/Debug/VirtusPecto.Desktop.exe'
cd '/home/martin/Documentos/Projectos/C#/VirtusPecto/'
msbuild VirtusPecto.Desktop.csproj
if [ -f '/home/martin/Documentos/Projectos/C#/VirtusPecto/bin/DesktopGL/Any CPU/Debug/VirtusPecto.Desktop.exe' ]
then
mono '/home/martin/Documentos/Projectos/C#/VirtusPecto/bin/DesktopGL/Any CPU/Debug/VirtusPecto.Desktop.exe'
fi

