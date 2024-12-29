USE SoftUni

BACKUP DATABASE SoftUni TO DISK = '/var/opt/mssql/backups/softuni-backup.bak'

USE master

ALTER DATABASE SoftUni SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK = '/var/opt/mssql/backups/softuni-backup.bak'

USE SoftUni