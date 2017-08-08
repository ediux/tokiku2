using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.MVVM;
using Tokiku.ViewModels;
using Tokiku.Entity;

namespace Tokiku.DataServices
{
    public class ManufacturersDataService : DataServiceBase, IManufacturersDataService
    {
        private IUnitOfWork _UnitOfWork;
        private IManufacturersRepository _ManufacturersRepository;

        public ManufacturersDataService(IUnitOfWork UnitOfWork, IManufacturersRepository ManufacturersRepository)
        {
            _UnitOfWork = UnitOfWork;
            _ManufacturersRepository = ManufacturersRepository;
            _ManufacturersRepository.UnitOfWork = _UnitOfWork;
        }

        public Collection<Manufacturers> QueryAll()
        {
            try
            {
                var queryresult = from q in _ManufacturersRepository.All()
                                  where q.Void == false && q.IsClient == false
                                  orderby q.Code ascending
                                  select q;

                return new Collection<Manufacturers>(
                   queryresult.ToList());
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return new Collection<Manufacturers>();
            }
        }

        public Manufacturers QuerySingle(Guid ManufacturersId)
        {
            try
            {

                var queryresult = from q in _ManufacturersRepository.All()
                                  where q.Void == false && q.IsClient == false
                                  && q.Id == ManufacturersId
                                  orderby q.Code ascending
                                  select q;

                return queryresult.SingleOrDefault();
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public Collection<Manufacturers> SearchByText(string filiter)
        {
            try
            {

                if (filiter != null && filiter.Length > 0)
                {
        
                    var queryresult = from q in _ManufacturersRepository.All()
                                      where q.Void == false && q.IsClient == false &&
                                      (q.Name.Contains(filiter) ||
                                    (q.ManufacturersBussinessItems != null && q.ManufacturersBussinessItems.Any(s => s.Name.Contains(filiter)))
                                      || (q.Principal != null && q.Principal.Contains(filiter)))
                                      orderby q.Code ascending
                                      select q;

                    

                    return new Collection<Manufacturers>(queryresult.ToList());

                }
                else
                {
                    return QueryAll();
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return new Collection<Manufacturers>();
            }
        }
    }
}
