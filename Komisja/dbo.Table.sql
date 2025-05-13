CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY,
    NumerAlbumu NVARCHAR(20) NOT NULL,
    NazwiskoImie NVARCHAR(100) NOT NULL,
    Semestr NVARCHAR(10) NOT NULL,
    Rok NVARCHAR(20) NOT NULL,
    KierunekStopien NVARCHAR(100) NOT NULL,
    Przedmiot NVARCHAR(100) NOT NULL,
    PunktyECTS INT NULL,
    Prowadzacy NVARCHAR(100) NOT NULL,
    Uzasadnienie NVARCHAR(MAX) NULL,
    DataPodpisStudenta DATE NOT NULL,
    Zgoda BIT NOT NULL, -- 1 = Wyrażam zgodę, 0 = Nie wyrażam
    CzlonekKomisji1 NVARCHAR(100) NOT NULL,
    CzlonekKomisji2 NVARCHAR(100) NOT NULL,
    CzlonekKomisji3 NVARCHAR(100) NOT NULL,
    DataDziekan DATE NOT NULL
	
)
