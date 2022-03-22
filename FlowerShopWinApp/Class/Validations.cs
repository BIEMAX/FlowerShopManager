using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
public static internal Boolean IsEmptyOrNull(Object ValueToCheck)
{
    return (ValueToCheck == null) || (typeof ValueToCheck == 'string' && !String.IsNullOrEmpty(ValueToCheck)) ;
}