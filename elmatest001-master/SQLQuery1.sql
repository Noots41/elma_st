select op.Name --, AVG(opr.ExetTimeMs)
from OperationResult as opr
left join Operation as op ON op.Id = opr.OperationId
--where opr.ArgumentCount = 1
group by op.Name
having AVG(opr.ExetTimeMs) > 10000000

