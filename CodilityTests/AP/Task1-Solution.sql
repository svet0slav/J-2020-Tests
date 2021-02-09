select URGRP.UserName,
    URGRP.NoOfCreatedRoles,
    (select Count(UR2.CreatedBy) FROM UserRole as UR2 WHERE UR2.IsEnabled = true and URGRP.UserName = UPPER(TRIM(BOTH ' ' from UR2.CreatedBy))) as NoOfCreatedAndEnabledRoles,
    (select Count(UR3.Updated) FROM UserRole as UR3 WHERE URGRP.UserName = UPPER(TRIM(BOTH ' ' from UR3.UpdatedBy)) )  as    NoOfUpdatedRoles
    FROM 
        (SELECT UPPER(TRIM(BOTH ' ' from UR.CreatedBy)) as UserName, Count(UR.CreatedBy) as NoOfCreatedRoles
            from UserRole as UR
            where LENGTH(UR.CreatedBy) > 0
            group by UserName) as URGRP