using CursoOnline.Domain._Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dados.Contextos
{
    public class UnityOfWork : IUnityOfWork
    {
        public readonly ApplicationDbContext _context;

        public UnityOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
