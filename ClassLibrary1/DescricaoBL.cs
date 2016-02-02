using DomainModel;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DescricaoBL
    {

        public static List<Descricao> getDescricoes()
        {
            List<Descricao> descricao = new List<Descricao>();
            try
            {
                descricao = DescricaoDA.getDescricao();
            }
            catch (NullReferenceException n)
            {
                throw n;
            }
            catch (Exception e)
            {
                throw e;
            }
            return descricao;
        }

        public static List<Descricao> getDescEspecifico(int id)
        {
            List<Descricao> descricao = new List<Descricao>();
            try
            {
                descricao = DescricaoDA.getDescricaoEsp(id);
            }
            catch (NullReferenceException n)
            {
                throw n;
            }
            catch (Exception e)
            {
                throw e;
            }
            return descricao;
        }

        public static string verificarUpdateDescricao(Descricao desc, int idD)
        {
            string result = null;
            try
            {
                result = DescricaoDA.updateDescricao(desc, idD);
            }
            catch (NullReferenceException n)
            {
                throw n;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public static string verificarAddDescricao(Descricao desc)
        {

            string result = null;
            try
            {
                result = DescricaoDA.addDescricao(desc);
            }
            catch (NullReferenceException n)
            {
                throw n;
            }
            catch (Exception ep)
            {
                throw ep;
            }
            return result;

        }

        public static string verificarDeleteDescricao(Descricao desc, int idD)
        {
            string result = null;
            try
            {
                result = DescricaoDA.deleteDescricao(desc, idD);
            }
            catch (NullReferenceException n)
            {
                throw n;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

    }
}
