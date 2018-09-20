create table Kisiler
(
Id int identity(1,1) primary key,
Adý nvarchar(50),
Soyad nvarchar(50),
Yas int,
OkulID int,

FOREIGN KEY (OkulID) REFERENCES OkulBlg(Id)

)