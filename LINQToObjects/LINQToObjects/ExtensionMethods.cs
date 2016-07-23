using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToObjects
{
    static class ExtensionMethods
    {
        public static void CopyTo(this object obj, object otherObj)
        {
            var query = from p in obj.GetType().GetProperties()
                        from q in otherObj.GetType().GetProperties()
                        where p.CanRead && q.CanWrite && p.Name == q.Name && p.PropertyType == q.PropertyType && p.GetMethod.IsPublic && q.SetMethod.IsPublic
                        select new
                        {
                            p,
                            q
                        };

            foreach (var v in query)
            {
                v.q.SetValue(otherObj, v.p.GetValue(obj));
            }
        }
    }
}
