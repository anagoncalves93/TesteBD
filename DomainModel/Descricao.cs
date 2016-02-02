using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Descricao
    {
        private string descricao;
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descricao1
        {
            get { return descricao; }
            set { descricao = value; }
        }
        private string observacao;

        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        public Descricao( string descricao, string observacao)
        {
            //this.id = id;
            this.descricao = descricao;
            this.observacao = observacao;
            
        }

        public Descricao()
        {

        }

        public Descricao(int id)
        {
            
            this.id = id;
        }
    }
}
