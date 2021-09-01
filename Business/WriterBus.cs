using Data.Context;
using Data.Models;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class WriterBus
    {
        public List<Writer> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.GetRepository<Writer>().GetAll().ToList();
            }
        }

        public List<Writer> GetAllWithCondiction(string text)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.GetRepository<Writer>().GetAll(x => x.WriterName.Contains(text)).OrderBy(x => x.WriterId).ToList();
            }
        }

        public Writer Get(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return  unitOfWork.GetRepository<Writer>().Get(id);
            }
        }

        public string Add(Writer writer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Writer>().Add(writer);
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "Basariyla Eklendi";
                else
                    return "Eklenemedi";
            }
        }
        public string Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Writer>()
                    .Delete(unitOfWork.GetRepository<Writer>().Get(id));
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "Basariyla Silindi";
                else
                    return "Silinemedi";
            }
        }

        public string Update(Writer writer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Writer>().Update(writer);
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "Basariyla Guncellendi";
                else
                    return "Guncellenemedi";
            }
        }

    }
}
