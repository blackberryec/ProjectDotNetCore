using System;

namespace TemplateDotNetCore.Infrastucture.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //call save change from db context
        void Commit();
    }
}