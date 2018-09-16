using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Domain._Base
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}
