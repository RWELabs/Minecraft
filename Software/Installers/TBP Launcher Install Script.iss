; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "TBP Launcher"
#define MyAppVersion "230901"
#define MyAppPublisher "RWE Labs"
#define MyAppURL "https://www.crutionix.com/?ref=tbp_launcher"
#define MyAppExeName "TBP Dashboard.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{3DAF25F7-1843-4B07-9D2B-E72236DCE18D}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\Program Files (x86)\RWE Labs\{#MyAppName}
DisableDirPage=no
DisableProgramGroupPage=yes
LicenseFile=C:\Users\rwalpole\Documents\GitHub\QOL-Improvements-for-TBP\Software\Source Code\TBP Launcher\EULA.rtf
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\rwalpole\Documents\GitHub\QOL-Improvements-for-TBP\Software\Installers
OutputBaseFilename=TBPLauncherSetup
SetupIconFile=C:\Users\rwalpole\Documents\GitHub\QOL-Improvements-for-TBP\Software\Source Code\TBP Launcher\TBP Dashboard\MCGC.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallDisplayName=TBP Launcher

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\rwalpole\Documents\GitHub\QOL-Improvements-for-TBP\Software\Source Code\TBP Launcher\TBP Dashboard\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\rwalpole\Documents\GitHub\QOL-Improvements-for-TBP\Software\Source Code\TBP Launcher\TBP Dashboard\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

