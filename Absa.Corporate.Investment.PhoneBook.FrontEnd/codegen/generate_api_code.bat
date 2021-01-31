ECHO OFF

CALL nswag run ABSAPhoneBookApi_Settings.nswag

robocopy /MOV .\ ..\AbsaPhoneBook\src\@api AbsaPhoneBookApi.ts

PAUSE