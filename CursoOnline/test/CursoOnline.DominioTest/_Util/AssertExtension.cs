using CursoOnline.Domain._Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ExcecaoDeDominio exception, string mensagem)
        {
            if(exception._mensagensDeErros.Contains(mensagem))
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Esperava a mensagem {mensagem}");
            }
        }
    }
}
