using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "DevemVariaveisTeremMesmoValor")]
        public void DevemVariaveisTeremMesmoValor()
        {

            //Oraganização
            var variavel1 = 1;
            var variavel2 = 5;

            //Ação
            variavel2 = variavel1;


            //Assert
            Assert.Equal(variavel1, variavel2);




        }
    }
}
