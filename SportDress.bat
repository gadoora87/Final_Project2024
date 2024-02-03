ECHO off
sqlcmd -S localhost -E -i SportDress.sql
ECHO .
ECHO if no errors appear DB was created
PAUSE