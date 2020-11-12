use RdxServerDB

--Create--

Create Database RdxServerDB
--drop table DeviceEvent

CREATE TABLE DeviceEvent ([EventId] int NOT NULL Identity(1,1) PRIMARY KEY,[UnixTimestamp] datetime,[Country] varchar(50),
	[Region] varchar(100),
	[DeviceName] varchar(100),
	[ValueType] varchar(10),
	[Value] varchar(100),
    [Status] int
);

select * from deviceevent
--Create--

--Reports--
SELECT CONCAT(DE.COUNTRY,'.',DE.REGION,'.',DE.DEVICENAME) AS TAG, SUM(CAST(DE.[VALUE] AS INT)) AS TOTAL FROM DEVICEEVENT DE
WHERE DE.VALUETYPE = 'INT'
GROUP BY DE.COUNTRY, DE.REGION, DE.DEVICENAME

select concat(de.Country,'.',de.Region) as Tag, sum(cast(de.[Value] as int)) as Total from DeviceEvent de
where de.ValueType = 'INT'
group by de.Country, de.Region
--Reports--

--exemplo insert
insert into DeviceEvent 
(UnixTimestamp,country,region,deviceName,valueType,value,status)
values
(getDate(),'brasil','sul','sensor01','INT','30',0)