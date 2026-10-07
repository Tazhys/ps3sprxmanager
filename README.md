# EbootExpress

EbootExpress is a Windows desktop app for preparing and uploading PS3 EBOOT and SPRX files over FTP.

## Features

- Stage EBOOT.BIN and SPRX files and review their remote names and destination folders.
- Import a local package, choose which files to stage, and preview readme or instruction text.
- Select MW2, MW3, or BO2 region codes, or detect supported game folders on a connected PS3.
- Use a dark, standard WinForms interface.

## Requirements

- Windows
- .NET Framework 4.8
- A PS3 FTP server that is reachable from your PC

## Build and run

Open `EbootExpress.sln` in Visual Studio, or build from this folder with the .NET SDK:

```powershell
dotnet build .\EbootExpress\EbootExpress.csproj --configuration Release -p:Platform=AnyCPU
```

The executable is created at `EbootExpress\bin\Release\EbootExpress.exe`.

## Basic use

1. Start an FTP server on your PS3 and enter its host, port, and login details in EbootExpress.
2. Choose a game and region code, or use **Detect installed games**. Check the remote folder.
3. Add EBOOT/SPRX files or import a local package. Review the staged files and their destinations.
4. Select **Upload staged files** to send them to the PS3.

FTP is unencrypted. Use a trusted network and avoid sending credentials over networks you do not trust. EbootExpress does not include game files; only use files you are authorized to install.

## Project layout

- `EbootExpress\UI\Forms` — application windows and their WinForms designer files
- `EbootExpress\UI\Controls` and `EbootExpress\UI\Styling` — shared UI components and theme support
- `EbootExpress\Catalogs` — supported game and region codes
- `EbootExpress\Services` — FTP and local package handling
- `EbootExpress\Assets` — application logo and icon

## Credit and license

Created by **Tazhys**. You may use, modify, and redistribute the project under the attribution terms in [`LICENSE`](LICENSE).
