#define Output "Output"
#define MyAppVersion "1.0"
#define License "..\LICENSE"
#define MyAppAssocExt ".djvu"
#define MyAppName "DjvuToPdf"
#define Configuration "Release"
#define MyAppPublisher "Latorul"
#define MyAppAssocName "DJVU to PDF"
#define MyAppExeName "DTP.Domain.exe"
#define SetupIcon "..\src\Resources\DjvuToPdf.ico"
#define MyAppURL "https://github.com/Latorul/DjvuToPdf"
#define SetupFileName "DjvuToPdf_v" + MyAppVersion + "_setup"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt
#define SourceFiles "..\src\DTP.Domain\bin\" + Configuration + "\net7.0-windows"

[Setup]
AppId={{6C9C3248-4BDC-473F-BA79-A5BB498220C2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppPublisher}\{#MyAppName}
ChangesAssociations=yes
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
LicenseFile={#License}
PrivilegesRequiredOverridesAllowed=dialog
OutputDir={#Output}
OutputBaseFilename={#SetupFileName}
SetupIconFile={#SetupIcon}
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Files]
Source: "{#SourceFiles}\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceFiles}\*.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceFiles}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".djvu"; ValueData: ""

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

