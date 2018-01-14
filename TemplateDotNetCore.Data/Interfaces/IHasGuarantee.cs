using System;

namespace TemplateDotNetCore.Data.Interfaces
{
    public interface IHasGuarantee
    {
        DateTime PurchaseTime { get; set; }

        DateTime ErrorTime { get; set; }

        int Warranty { get; set; }
    }
}