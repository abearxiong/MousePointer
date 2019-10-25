@echo off
reg add "HKCU\Control Panel\Cursors" /ve /t REG_SZ /d red_star /f
reg add "HKCU\Control Panel\Cursors" /v "Arrow" /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\Arrow.ani /f
reg add "HKCU\Control Panel\Cursors" /v Help /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\Help.ani /f
reg add "HKCU\Control Panel\Cursors" /v Hand /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\Hand.ani /f
reg add "HKCU\Control Panel\Cursors" /v AppStarting /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\AppStarting.ani /f
reg add "HKCU\Control Panel\Cursors" /v Wait /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\Wait.ani /f
reg add "HKCU\Control Panel\Cursors" /v NWPen /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\Handwriting.ani /f
reg add "HKCU\Control Panel\Cursors" /v No /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\No.ani /f
reg add "HKCU\Control Panel\Cursors" /v SizeNS /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\SizeNS.ani /f
reg add "HKCU\Control Panel\Cursors" /v SizeWE /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\SizeWE.ani /f
reg add "HKCU\Control Panel\Cursors" /v SizeNWSE /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\SizeNWSE.ani /f
reg add "HKCU\Control Panel\Cursors" /v SizeNESW /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\SizeNESW.ani /f
reg add "HKCU\Control Panel\Cursors" /v SizeAll /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\SizeAll.ani /f
reg add "HKCU\Control Panel\Cursors" /v UpArrow /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\UpArrow.ani /f
reg add "HKCU\Control Panel\Cursors" /v Crosshair /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\cross.ani /f
reg add "HKCU\Control Panel\Cursors" /v IBeam /t REG_EXPAND_SZ /d %SYSTEMROOT%\Cursors\red_star\IBeam.ani /f
CLS
start /min rundll32.exe shell32.dll,Control_RunDLL main.cpl,,1 /f