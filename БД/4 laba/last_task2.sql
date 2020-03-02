use master
go 
create database GR_Univer
on primary
(
name=N'Gr_Univer_mdf', filename=N'F:\Gr_Unviver_mdf.mdf',
size=5Mb, maxsize=10Mb, filegrowth=1Mb
),
(
name=N'Gr_Univer_ndf', filename=N'F:\Gr_Unviver_ndf.ndf',
size=5Mb, maxsize=10Mb, filegrowth=10%
),
Filegroup G1
(
name=N'Gr_Univer11_ndf', filename=N'F:\Gr_Unviver11_ndf.ndf',
size=10Mb, maxsize=15Mb, filegrowth=1Mb
),
(
name=N'Gr_Univer12_ndf', filename=N'F:\Gr_Unviver12_ndf.ndf',
size=2Mb, maxsize=5Mb, filegrowth=1Mb
),
Filegroup G2
(
name=N'Gr_Univer21_ndf', filename=N'F:\Gr_Unviver21_ndf.ndf',
size=5Mb, maxsize=10Mb, filegrowth=1Mb
),
(
name=N'Gr_Univer22_ndf', filename=N'F:\Gr_Unviver22_ndf.ndf',
size=2Mb, maxsize=5Mb, filegrowth=1Mb
)
log on
(
name=N'Gr_Unviver_ldf', filename=N'F:\Univer_ldf.ldf',
size=5Mb, maxsize=Unlimited,filegrowth=1Mb
)
go