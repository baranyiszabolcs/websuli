create  view szorzasV as 
select 
gyerek,kiadasDatum,feladatTipus,feladatszam
,helyescnt
,ValaszidoSec
,eredmeny
,CAST( JSON_VALUE(feladatJson,'$.Szorzando') as int)   A
,cast (JSON_VALUE(feladatJson,'$.Szorzo')as int   ) B
from Feladatsor s join Feladatok f on f.FeladatsorID=s.FeladatsorID
where feladatTipus ='Szorzas'