using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;
using NPOI;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tokiku.Controllers
{
    public class MoldsController : BaseController
    {
        private String sql;

        public Task<ExecuteResultEntity<ICollection<MoldsEnter>>> Query()
        {
            sql = " select LegendMoldReduction, UsePosition, Code, SerialNumber, " +
                         " b.Name as Name1, UnitWeight, SurfaceTreatment, PaintArea, " +
                         " MembraneTreatment, MinimumYield, ProductionIngot, " +
                         " TotalOrderWeight, c.Name as Name2, Comment " +
                    " from Molds a left join materials b on a.Id = b.Id " +
                                 " left join MoldUseStatus c on c.Id = a.MoldUseStatusId ";

            try
            {
                var repo = RepositoryHelper.GetMoldsRepository();
                var queryresult = repo.UnitOfWork.Context.Database.SqlQuery<MoldsEnter>(sql);
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<MoldsEnter>>.CreateResultEntity(
                        new Collection<MoldsEnter>(queryresult.ToList())));

            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<MoldsEnter>>.CreateErrorResultEntity(ex));
            }
        }

        /// <summary>
        /// 傳回主索引鍵欄位的內容值。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected object[] IdentifyPrimaryKey<T>(T entity) where T : class
        {

            ObjectContext objectContext = ((IObjectContextAdapter)database.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            Type entityreflection = typeof(T);

            var pkeys = entityreflection.GetProperties()
                .Join(keyNames, (x) => x.Name, (y) => y, (k, t) => k)
                .Select(s => s.GetValue(entity));

            return pkeys.ToArray();
        }

        public Task<ExecuteResultEntity<ICollection<Molds>>> QueryAsync(Expression<Func<Molds, bool>> filiter)
        {
            try
            {
                var repo = RepositoryHelper.GetMoldsRepository();
                database = repo.UnitOfWork;
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<Molds>>.CreateResultEntity(
                       new Collection<Molds>(repo.Where(filiter).ToList())));
            }
            catch (Exception ex)
            {
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<Molds>>.CreateErrorResultEntity(ex));
            }
        }

        public Task<ExecuteResultEntity<ICollection<MoldUseStatus>>> QueryAsync(Expression<Func<MoldUseStatus, bool>> filiter)
        {
            try
            {
                var repo = RepositoryHelper.GetMoldUseStatusRepository();
                database = repo.UnitOfWork;
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<MoldUseStatus>>.CreateResultEntity(
                       new Collection<MoldUseStatus>(repo.Where(filiter).ToList())));
            }
            catch (Exception ex)
            {
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<MoldUseStatus>>.CreateErrorResultEntity(ex));
            }
        }

        /// <summary>
        /// 用來作為匯入用的儲存方法
        /// </summary>
        /// <param name="entityCollection"></param>
        /// <returns></returns>
        public Task<ExecuteResultEntity> CreateOrUpdateAsync(ICollection<Molds> entityCollection)
        {
            try
            {
                using (var repo = RepositoryHelper.GetMoldsRepository())
                {
                    if (repo == null)
                        return Task.FromResult(ExecuteResultEntity.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(Molds).Name)));

                    database = repo.UnitOfWork;

                    if (entityCollection.Any())
                    {
                        int c = 1;
                        foreach (var entity in entityCollection)
                        {
                            if (repo.Get(entity.Id) != null)
                            {
                                var update_result = Update(entity, c == entityCollection.Count);
                                if (update_result.HasError)
                                {
                                    c++;
                                    continue;
                                }

                            }
                            else
                            {
                                var add_result = Add(entity, c == entityCollection.Count);
                                if (add_result.HasError)
                                {
                                    c++;
                                    continue;
                                }
                            }
                            c++;
                        }
                    }

                    return Task.FromResult(ExecuteResultEntity.CreateResultEntity());

                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity.CreateErrorResultEntity(ex));
            }
        }

        /// <summary>
        /// 加入單一資料列到資料庫。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual ExecuteResultEntity Add(Molds entity, bool isLastRecord = true)
        {
            try
            {

                var repo = RepositoryHelper.GetMoldsRepository(database);
                database = repo.UnitOfWork;
                if (repo == null)
                    return ExecuteResultEntity.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(Molds).Name));

                entity = repo.Add(entity);

                if (isLastRecord)
                {
                    repo.UnitOfWork.Commit();
                    database = repo.UnitOfWork;
                    repo.UnitOfWork.Context.Set<Molds>().Attach(entity);
                    entity = repo.Reload(entity);
                }

                return ExecuteResultEntity.CreateResultEntity();

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual ExecuteResultEntity<Molds> Update(Molds fromModel, bool isLastRecord = true)
        {
            try
            {
                using (var repo = RepositoryHelper.GetMoldsRepository())
                {
                    if (repo == null)
                        return ExecuteResultEntity<Molds>.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(Molds).Name));

                    database = repo.UnitOfWork;

                    Molds findresult = repo.Get(IdentifyPrimaryKey(fromModel));

                    if (findresult != null)
                    {
                        CheckAndUpdateValue(fromModel, findresult);

                        if (isLastRecord)
                        {
                            repo.UnitOfWork.Commit();
                            database = repo.UnitOfWork;
                            findresult = repo.Get(IdentifyPrimaryKey(findresult));
                        }

                        return ExecuteResultEntity<Molds>.CreateResultEntity(findresult);
                    }
                }
                return ExecuteResultEntity<Molds>.CreateErrorResultEntity("Data not found.");
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Molds>.CreateErrorResultEntity(ex);
            }

        }
        /// <summary>
        /// 儲存或更新資料庫
        /// </summary>
        /// <param name="model"></param>
        public virtual ExecuteResultEntity<Molds> CreateOrUpdate(Molds entity)
        {
            try
            {
                using (var repo = RepositoryHelper.GetMoldsRepository())
                {
                    if (repo == null)
                        return ExecuteResultEntity<Molds>.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(Molds).Name));

                    database = repo.UnitOfWork;

                    if (repo.Get(IdentifyPrimaryKey(entity)) != null)
                    {
                        var update_result = Update(entity);

                        if (update_result.HasError)
                        {
                            update_result.Result = entity;
                            return update_result;
                        }

                        return ExecuteResultEntity<Molds>.CreateResultEntity(update_result.Result);
                    }
                    else
                    {
                        var add_result = Add(entity);
                        if (add_result.HasError)
                        {
                            return new ExecuteResultEntity<Molds>()
                            {
                                Errors = add_result.Errors,
                                Result = entity
                            };
                        }

                        return ExecuteResultEntity<Molds>.CreateResultEntity(entity);
                    }

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Molds>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<Molds>> ImportsMoldsFromExecl(string filename)
        {
            try
            {
                Collection<Molds> DestTarget = new Collection<Molds>();
                Dictionary<int, string> ColumnMapping = new Dictionary<int, string>();
                XSSFWorkbook workbook;
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    workbook = new XSSFWorkbook(fs);
                    XSSFSheet xsheet = (XSSFSheet)workbook.GetSheetAt(0);
                    var firstrow = xsheet.GetRow(0);

                    for (int coli = 0; coli < firstrow.LastCellNum; coli++)
                    {
                        ICell HeaderCell = firstrow.GetCell(coli);
                        if (HeaderCell.CellType == CellType.String)
                        {
                            switch (HeaderCell.StringCellValue.ToLowerInvariant())
                            {
                                case "專案名稱":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "MoldsInProjects.Projects.Name");
                                    break;
                                case "開模日期":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "OpenDate");
                                    break;
                                case "圖例":
                                case "圖例               模具縮小圖":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "LegendMoldReduction");
                                    break;
                                case "使用位置":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "UsePosition");
                                    break;
                                case "東菊編號":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "Code");
                                    break;
                                case "廠商":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "Manufacturers.Name");
                                    break;
                                case "廠商編號":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "Manufacturers.Code");
                                    break;
                                case "材質":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "Materials.Name");
                                    break;
                                case "單位重(kg/M)":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "UnitWeight");
                                    break;
                                case "表面處理":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "SurfaceTreatment");
                                    break;
                                case "烤漆面積(㎡)":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "PaintArea");
                                    break;
                                case "皮膜處理(kg)":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "MembraneTreatment");
                                    break;
                                case "最低產量":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "MinimumYield");
                                    break;
                                case "生產錠徑":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "ProductionIngot");
                                    break;
                                case "模具費用":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "");
                                    break;
                                case "訂單總重量":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "TotalOrderWeight");
                                    break;
                                case "模具使用狀況":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "MoldUseStatus.Name");
                                    break;
                                case "備註":
                                    ColumnMapping.Add(HeaderCell.ColumnIndex, "Comment");
                                    break;
                                default:
                                    continue;
                            }
                        }

                    }

                    int ColumnCount = firstrow.LastCellNum; //取得欄位數
                    int RowCount = xsheet.LastRowNum;   //取得資料列數

                    for (int rowi = 1; rowi < RowCount; rowi++)
                    {
                        var datarow = xsheet.GetRow(rowi);

                        Molds fromFileData = new Molds();

                        fromFileData.Id = Guid.NewGuid();
                        fromFileData.CreateTime = DateTime.Now;
                        fromFileData.CreateUser = GetCurrentLoginUser().Result;
                        fromFileData.CreateUserId = fromFileData.CreateUser.UserId;

                        Type dataTypeRef = fromFileData.GetType();
                        for (int coli = 0; coli < ColumnCount; coli++)
                        {
                            ICell cell = datarow.GetCell(coli);

                            switch (cell.CellType)
                            {
                                case CellType.Blank:
                                    continue;
                                case CellType.Boolean:
                                    var prop_bool = dataTypeRef.GetProperty(ColumnMapping[cell.ColumnIndex]);

                                    if (prop_bool != null && prop_bool.PropertyType == typeof(bool))
                                    {
                                        prop_bool.SetValue(fromFileData, cell.BooleanCellValue);
                                    }
                                    break;
                                case CellType.Error:
                                    break;
                                case CellType.Formula:
                                    break;
                                case CellType.Numeric:
                                    var prop_Numeric = dataTypeRef.GetProperty(ColumnMapping[cell.ColumnIndex]);

                                    if (prop_Numeric != null && 
                                        (prop_Numeric.PropertyType == typeof(double)))
                                    {
                                        //prop_bool.SetValue(fromFileData, cell.BooleanCellValue);
                                    }
                                    break;
                                case CellType.String:
                                    break;
                                case CellType.Unknown:
                                    break;
                            }
                        }
                    }

                }

                var repo = RepositoryHelper.GetMoldsRepository();
                database = repo.UnitOfWork;
                Collection<Molds> MoldsSource = new Collection<Molds>(repo.All().ToList());
                return ExecuteResultEntity<ICollection<Molds>>.CreateResultEntity(MoldsSource);
            }
            catch (Exception ex)
            {

                return ExecuteResultEntity<ICollection<Molds>>.CreateErrorResultEntity(ex);
            }
        }

    }
}
