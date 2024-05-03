using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.Shared.Abstractions.Entities;

namespace RotaDeViagem.Shared.Extensions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string message) : base(message) { }

        public static void ThrowWhenNullEntity(object entity, string erroMessage)
        {
            if (entity != null)
                return;

            throw new NotFoundException(erroMessage);
        }

        //public static void ThrowWhenNullEntity(IResponse entity, string erroMessage)
        //{
        //    if (entity != null)
        //        return;

        //    throw new NotFoundException(erroMessage);
        //}

        public static void ThrowWhenNullEntity(AuditEntityBase entity, string erroMessage)
        {
            if (entity != null)
                return;

            throw new NotFoundException(erroMessage);
        }

        //public static void ThrowWhenNullEntity(BasicEntityBase entity, string erroMessage)
        //{
        //    if (entity != null)
        //        return;

        //    throw new NotFoundException(erroMessage);
        //}
        public static void ThrowWhenNullOrEmptyList
                (IEnumerable<object> list, string erroMessage)
        {

            if (list != null && list.Count() > 0)
                return;

            throw new NotFoundException(erroMessage);
        }
    }
}


