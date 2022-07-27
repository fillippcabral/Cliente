using Cliente.Core.Excecoes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cliente.Dominio.BancoDeDados
{
    public static class ExtensoesDeDbContext
    {
        public static void AtualizarESalvar<DbEntity>(this DbContext context, DbEntity entity) where DbEntity : EntidadeDoBancoDeDados
        {
            context.Update(entity);
            context.SaveChanges();

        }

        public static void AdicionarESalvar<DbEntity>(this DbContext context, DbEntity entity) where DbEntity : EntidadeDoBancoDeDados
        {
            context.Add(entity);
            context.SaveChanges();

        }

        public static void Adicionar<DbEntity>(this DbContext context, DbEntity entity) where DbEntity : EntidadeDoBancoDeDados
        {
            context.Add(entity);

        }

        public static IEnumerable<DbEntity> Listar<DbEntity>(this DbContext context, Expression<Func<DbEntity, bool>>? filtro = null) where DbEntity : EntidadeDoBancoDeDados
        {
            if (filtro == null)
                return context.Set<DbEntity>().ToList();

            return context.Set<DbEntity>().Where(filtro).ToList();

        }

        public static IEnumerable<DbEntity> Listar<DbEntity>(this DbContext context, Expression<Func<DbEntity, object>>[] includes, Expression<Func<DbEntity, bool>>? filtro = null) where DbEntity : EntidadeDoBancoDeDados
        {
            if (includes == null || includes.Length == 0)
                throw new ExcecaoDeProgramacao("Uso incorreto do método listar do contexto entity framework. É preciso enviar as cláusulas include.");

            var entity = context.Set<DbEntity>().Include(includes[0]);

            for (int i = 1; i < includes.Length; i++)
                entity = entity.Include(includes[i]);

            if (filtro == null)
                return entity.ToList();

            return entity.Where(filtro).ToList();

        }

        public static DbEntity? ObterPorId<DbEntity>(this DbContext context, Guid id) where DbEntity : EntidadeDoBancoDeDados
        {
            return context.Set<DbEntity>().FirstOrDefault(x => x.Id == id);

        }

        public static DbEntity? ObterPorId<DbEntity>(this DbContext context, Guid id, Expression<Func<DbEntity, object>>[] includes) where DbEntity : EntidadeDoBancoDeDados
        {
            if (includes == null || includes.Length == 0)
                throw new ExcecaoDeProgramacao("Uso incorreto do método obter por id do contexto entity framework. É preciso enviar as cláusulas include.");

            var entity = context.Set<DbEntity>().Include(includes[0]);

            for (int i = 1; i < includes.Length; i++)
                entity = entity.Include(includes[i]);

            return entity.FirstOrDefault(x => x.Id == id);

        }

        public static DbEntity? Obter<DbEntity>(this DbContext context, Expression<Func<DbEntity, bool>> filtro) where DbEntity : EntidadeDoBancoDeDados
        {
            return context.Set<DbEntity>().FirstOrDefault(filtro);

        }

        public static DbEntity? Obter<DbEntity>(this DbContext context, Expression<Func<DbEntity, bool>> filtro, Expression<Func<DbEntity, object>>[] includes) where DbEntity : EntidadeDoBancoDeDados
        {
            if (includes == null || includes.Length == 0)
                throw new ExcecaoDeProgramacao("Uso incorreto do método obter por id do contexto entity framework. É preciso enviar as cláusulas include.");

            var entity = context.Set<DbEntity>().Include(includes[0]);

            for (int i = 1; i < includes.Length; i++)
                entity = entity.Include(includes[i]);

            return entity.FirstOrDefault(filtro);

        }

        public static void RemoverESalvar<DbEntity>(this DbContext context, Guid id) where DbEntity : EntidadeDoBancoDeDados
        {
            var entity = context.ObterPorId<DbEntity>(id);
            if (entity != null)
            {
                context.Remove(entity);
                context.SaveChanges();

            }

        }

        public static void RemoverESalvar<DbEntity>(this DbContext context, DbEntity entity) where DbEntity : EntidadeDoBancoDeDados
        {
            context.Remove(entity);
            context.SaveChanges();

        }

        public static void Remover<DbEntity>(this DbContext context, Guid id) where DbEntity : EntidadeDoBancoDeDados
        {
            var entity = context.ObterPorId<DbEntity>(id);
            if (entity != null)
            {
                context.Remove(entity);

            }

        }

        public static void Remover<DbEntity>(this DbContext context, DbEntity entity) where DbEntity : EntidadeDoBancoDeDados
        {
            context.Remove(entity);

        }

    }
}
