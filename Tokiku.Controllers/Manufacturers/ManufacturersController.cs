using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ManufacturersController : BaseController
    {
        private TokikuEntities database;

        public ManufacturersController()
        {
            database = new TokikuEntities();
        }

        public ManufacturersViewModel CreateNew()
        {
            return new ManufacturersViewModel();
        }

        /// <summary>
        /// 取得廠商代碼流水號
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public string GetNextProjectSerialNumber(string Code)
        {
            var lastitem = QueryAll().OrderByDescending(s => s.Code).FirstOrDefault();
            if (lastitem != null)
            {
                int numif = 0;
                if (int.TryParse(lastitem.Code, out numif))
                {
                    if (numif <= 99)
                    {
                        Code = (numif + 1).ToString();
                        return Code;
                    }

                }

                Dictionary<int, string> dict = new Dictionary<int, string>();
                dict.Add(0, "0");
                dict.Add(1, "1");
                dict.Add(2, "2");
                dict.Add(3, "3");
                dict.Add(4, "4");
                dict.Add(5, "5");
                dict.Add(6, "6");
                dict.Add(7, "7");
                dict.Add(8, "8");
                dict.Add(9, "9");
                dict.Add(10, "A");
                dict.Add(11, "B");
                dict.Add(12, "C");
                dict.Add(13, "D");
                dict.Add(14, "E");
                dict.Add(15, "F");
                dict.Add(16, "G");
                dict.Add(17, "H");
                dict.Add(18, "I");
                dict.Add(19, "J");
                dict.Add(20, "K");
                dict.Add(21, "L");
                dict.Add(22, "M");
                dict.Add(23, "N");
                dict.Add(24, "O");
                dict.Add(25, "P");
                dict.Add(26, "Q");
                dict.Add(27, "R");
                dict.Add(28, "S");
                dict.Add(29, "T");
                dict.Add(30, "U");
                dict.Add(31, "V");
                dict.Add(32, "W");
                dict.Add(33, "X");
                dict.Add(34, "Y");
                dict.Add(35, "Z");

                string hignchar = lastitem.Code.Substring(0, 1);
                string lowchar = lastitem.Code.Substring(1, 1);

                int lowint = dict.Where(w => w.Value == lowchar).Select(s => s.Key).Single();
                int highint = dict.Where(w => w.Value == hignchar).Select(s => s.Key).Single();

                if (lowint == 35)
                {
                    lowint = 0;
                    highint += 1;
                }
                else
                {
                    lowint += 1;
                }

                Code = dict[highint] + dict[lowint];
            }
            else
            {
                Code = "01";
            }

            return string.Format("{0:##}", Code);
        }

        public IEnumerable SearchByText(string originalSource)
        {
            if (originalSource != null && originalSource.Length > 0)
            {
                return (from p in database.Manufacturers
                        where p.Void == false && p.IsClient == false &&
                        (p.Code.Contains(originalSource) || p.Name.Contains(originalSource) || p.ShortName.Contains(originalSource))
                        orderby p.Code ascending
                        select p).ToList();
            }
            else
            {
                return (from p in database.Manufacturers
                        where p.Void == false && p.IsClient == false
                        orderby p.Code ascending
                        select p).ToList();
            }
        }

        /// <summary>
        /// 查詢單一個體的資料實體。
        /// </summary>
        /// <param name="ProjectId"></param>
        public ManufacturersViewModel QueryModel(Guid ProjectId)
        {
            Manufacturers result = QuerySingle(ProjectId);

            if (result != null)
            {
                ManufacturersViewModel vm = new ManufacturersViewModel();
                vm = BindingFromModel<Manufacturers, ManufacturersViewModel>(result);
                vm.Contracts = new ObservableCollection<ContactsViewModel>(result.Contacts.ToList().ConvertAll(c => BindingFromModel<Contacts, ContactsViewModel>(c)));
                vm.IsEditorMode = false;

                return vm;
            }

            return null;
        }


        /// <summary>
        /// 儲存變更
        /// </summary>
        public void SaveModel(ManufacturersViewModel model)
        {
            try
            {
                if (IsExists(model.Id))
                {
                    Manufacturers result = QuerySingle(model.Id);
                    CopyToModel(result, model);
                    Update(result);
                }
                else
                {
                    Manufacturers newProject = new Manufacturers();
                    CopyToModel(newProject, model);
                    newProject.CreateTime = DateTime.Now;
                    newProject.CreateUserId = model.LoginedUser.UserId;

                    database.Manufacturers.Add(newProject);
                }
                model.IsEditorMode = true;
                model.IsSaved = true;
                model.IsModify = false;
            }
            catch
            {
                throw;
            }

        }


        public void Add(ManufacturersViewModel model)
        {
            var dbm = new Manufacturers();
            CopyToModel(dbm, model);
            database.Manufacturers.Add(dbm);
            database.SaveChanges();
        }

        private Manufacturers QuerySingle(Guid ManufacturersId)
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Id == ManufacturersId && p.Void == false
                             select p;

                if (result.Any())
                {
                    return result.Single();
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ObservableCollection<ManufacturersViewModel> QueryAll()
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Void == false && p.IsClient == false
                             select p;

                return new ObservableCollection<ManufacturersViewModel>(result.ToList().ConvertAll(c => BindingFromModel<Manufacturers, ManufacturersViewModel>(c)));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsExists(Guid ManufacturersId)
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Id == ManufacturersId && p.Void == false
                             select p;

                return result.Any();
            }
            catch
            {

                return false;
            }
        }

        private void Update(Manufacturers updatedProject)
        {
            var original = QuerySingle(updatedProject.Id);
            if (original != null)
            {
                original = updatedProject;
                database.SaveChanges();
            }
        }

        public void Delete(Guid ManufacturersId, Guid UserId)
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Id == ManufacturersId && p.Void == false
                             select p;

                if (result.Any())
                {
                    var data = result.Single();
                    data.Void = true;

                    database.AccessLog.Add(new AccessLog() { ActionCode = 3, CreateTime = DateTime.Now, DataId = ManufacturersId, UserId = UserId });
                    database.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
