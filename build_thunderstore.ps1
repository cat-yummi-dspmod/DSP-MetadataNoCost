# Thunderstore Package Builder

$ModName = "MetadataNoCost"
$OutputZip = ".\bin\Release\MetadataNoCost.zip"

# Build the project
Write-Host "Building $ModName..." -ForegroundColor Cyan
dotnet build -c Release
if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}
Write-Host "Build successful!" -ForegroundColor Green

Add-Type -AssemblyName System.Drawing
$iconPath = Join-Path $PSScriptRoot "icon.png"
$iconImg = [System.Drawing.Image]::FromFile($iconPath)
if ($iconImg.Width -ne 256 -or $iconImg.Height -ne 256) {
    $bad = "{0}x{1}" -f $iconImg.Width, $iconImg.Height
    $iconImg.Dispose()
    throw "icon.png must be exactly 256x256 PNG (Thunderstore); got $bad."
}
$iconImg.Dispose()
$iconSig = [System.IO.File]::ReadAllBytes($iconPath)[0..3]
if ($iconSig[0] -ne 0x89 -or $iconSig[1] -ne 0x50 -or $iconSig[2] -ne 0x4E -or $iconSig[3] -ne 0x47) {
    throw "icon.png must be PNG format (Thunderstore)."
}

# Create temp directory
$TempDir = ".\thunderstore_package"
if (Test-Path $TempDir) {
    Remove-Item $TempDir -Recurse -Force
}
New-Item -ItemType Directory -Path $TempDir | Out-Null

# Copy files
Copy-Item ".\manifest.json" -Destination $TempDir
Copy-Item ".\README.md" -Destination $TempDir
Copy-Item ".\icon.png" -Destination $TempDir
Copy-Item ".\bin\Release\net472\$ModName.dll" -Destination $TempDir

# Create zip
if (Test-Path $OutputZip) {
    Remove-Item $OutputZip -Force
}

Compress-Archive -Path "$TempDir\*" -DestinationPath $OutputZip -Force

# Cleanup
Remove-Item $TempDir -Recurse -Force

Write-Host "Package created: $OutputZip" -ForegroundColor Green
