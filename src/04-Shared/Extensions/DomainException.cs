using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.Shared.Abstractions.Entities;
using RotaDeViagem.Shared.Interfaces.IEntities;

namespace RotaDeViagem.Shared.Extensions
{
    public class DomainException : Exception
    {
        public static IEntity Entity { get; set; }
        public static string ContextName { get; set; }
        public DomainException(string message) : base(message) { }

        public static void ThrowWhen(bool invalidRule, string message)
        {
            if (invalidRule)
                throw new DomainException(message);
        }

        public static void ThrowWhenInvalidEntity(AuditEntityBase entity)
        {
            if (entity.Validate())
                return;
            
            throw new DomainException(entity.Errors.ElementAt(0));
        }

        //public static void ThrowWhenInvalidEntity(AuditEntityBase entity)
        //{
        //    if (entity.Validate())
        //        return;

        //    ContextName = "entitywitherror";
        //    Entity = entity;

        //    throw new DomainException(entity.Errors.ElementAt(0));
        //}
        //public static void ThrowWhenInvalidRequest
        //        (CommandRequest request)
        //{

        //    if (!request.Validate())
        //    {
        //        Log.ForContext("request", request).Fatal(request.Errors.ElementAt(0));
        //        throw new DomainException(request.Errors.ElementAt(0));
        //    }
        //}
    }
}
