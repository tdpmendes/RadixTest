use RdxServerDB
select * from deviceevent


SELECT CONCAT(DE.COUNTRY,'.',DE.REGION,'.',DE.DEVICENAME) AS TAG, SUM(CAST(DE.[VALUE] AS INT)) AS TOTAL FROM DEVICEEVENT DE
WHERE DE.VALUETYPE = 'INT'
GROUP BY DE.COUNTRY, DE.REGION, DE.DEVICENAME

select concat(de.Country,'.',de.Region) as Tag, sum(cast(de.[Value] as int)) as Total from DeviceEvent de
where de.ValueType = 'INT'
group by de.Country, de.Region

--exemplo insert
insert into DeviceEvent 
(UnixTimestamp,country,region,deviceName,valueType,value,status)
values
(getDate(),'brasil','sul','sensor03','INT','100',0)