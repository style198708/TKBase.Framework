using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TKBase.Framework.Dapper.Lambda;

namespace TKBase.Framework.Dapper
{
    public class DP
    {
        public static DapperConfig Config { get; set; }

        /// <summary>
        /// 初始化配置
        /// </summary>
        static DP()
        {
            if (Config == null)
            {

                Config = Configuration.Config.Bind<DapperConfig>("TableConfig.json");
            }
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static LambdaQueryHelper<T> Create<T>() where T : class
        {
            Tuple<DataBaseType, IDbConnection> tuple = GetDataBase<T>();
            if (tuple != null)
            {


                return DapperExtension.Instance(tuple.Item1).LambdaQuery<T>(tuple.Item2, null, null);
            }
            else
            {
                throw new Exception("数据库信息为空！");
            }
        }

        public static IEnumerable<T> GetPage<T>(int page, int pagesize, out long total, string sql) where T : class
        {
            Tuple<DataBaseType, IDbConnection> tuple = GetDataBase<T>();
            return DapperExtension.GetPage<T>(tuple.Item2, page, pagesize, out total, sql);
        }


        /// <summary>
        /// 保存数据 返回当前的ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int SaveEntity<T>(T entity) where T : class
        {
            Tuple<DataBaseType, IDbConnection> tuple = GetDataBase<T>();
            if (tuple != null)
            {
                // DapperExtension.Instance(tuple.Item1).Insert<T>(tuple.Item2, entity, null, null);
                return DapperExtension.Insert(tuple.Item2, entity, null, 0, tuple.Item1);
            }
            else
            {
                throw new Exception("数据库信息为空");
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Update<T>(T entity) where T : class
        {
            Tuple<DataBaseType, IDbConnection> tuple = GetDataBase<T>();
            if (tuple != null)
            {
                return DapperExtension.Update(tuple.Item2, entity, null, 0, tuple.Item1);
            }
            else
            {
                throw new Exception("数据库信息为空");
            }
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static T FindById<T>(object Id) where T : class
        {
            Tuple<DataBaseType, IDbConnection> tuple = GetDataBase<T>();
            if (tuple != null)
            {
                return DapperExtension.Instance(tuple.Item1).Get<T, T>(tuple.Item2, Id, null, null);
            }
            else
            {
                throw new Exception("数据库信息为空！");
            }
        }

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static void SaveEntityList<T>(IEnumerable<T> list) where T : class
        {
            Tuple<DataBaseType, IDbConnection> tuple = GetDataBase<T>();
            if (tuple != null)
            {
                DapperExtension.Instance(tuple.Item1).Insert<T>(tuple.Item2, list, null, null);
            }
            else
            {
                throw new Exception("数据库信息为空！");
            }
        }
        public static void Transaction(TransactionEntity entity, ref string msg)
        {
            if (entity.AddEntity.Count == 0 && entity.UpdateEntity.Count == 0)
            {
                msg = "事务无任务执行操作";
                return;
            }
            Tuple<DataBaseType, IDbConnection> tuple = new Tuple<DataBaseType, IDbConnection>(DataBaseType.MySql, null);
            if (entity.AddEntity.Count > 0)
            {
                tuple = GetDataBase(entity.AddEntity.First().GetType());
            }
            else if (entity.UpdateEntity.Count > 0)
            {
                tuple = GetDataBase(entity.UpdateEntity.First().GetType());
            }

            if (tuple.Item2.State == ConnectionState.Closed)
                tuple.Item2.Open();
            using (var tx = tuple.Item2.BeginTransaction())
            {
                try
                {
                    foreach (dynamic obj in entity.AddEntity)
                        DapperExtension.Instance(tuple.Item1).Insert(tuple.Item2, obj, tx, null);
                    // DapperExtension.Instance(tuple.Item1).Insert(tuple.Item2, entity.AddEntity, tx, null);
                    foreach (dynamic obj in entity.UpdateEntity)
                        DapperExtension.Instance(tuple.Item1).Update(tuple.Item2, obj, tx, null);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    tx.Rollback();
                }
            };
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int DeleteEntity<T>(T entity) where T : class
        {
            Tuple<DataBaseType, IDbConnection> tuple = GetDataBase<T>();
            if (tuple != null)
            {
                return DapperExtension.Instance(tuple.Item1).Delete<T>(tuple.Item2, entity, null, null);
            }
            else
            {
                throw new Exception("数据库信息为空！");
            }
        }

        /// <summary>
        /// 通过Lambl表达式删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static int DeleteEntity<T>(System.Linq.Expressions.Expression<Func<T, bool>> expressions = null) where T : class
        {
            Tuple<DataBaseType, IDbConnection> tuple = GetDataBase<T>();
            if (tuple != null)
            {
                IWhere<T> where = new Where<T>();
                where.And(expressions);
                return DapperExtension.Instance(tuple.Item1).LambdaDelete<T>(tuple.Item2, null, null).Where(where).Execute();
            }
            else
            {
                throw new Exception("数据库信息为空！");
            }
        }

        /// <summary>
        /// 取MySql
        /// </summary>
        /// <param name="constring"></param>
        /// <returns></returns>
        private static IDbConnection GetMySqlConn(string constring)
        {
            return new MySqlConnection(constring);
        }

        /// <summary>
        /// 取MsSql
        /// </summary>
        /// <param name="constring"></param>
        /// <returns></returns>
        private static IDbConnection GetMsSqlConn(string constring)
        {
            return new SqlConnection(constring);
        }

        /// <summary>
        /// 数据连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Tuple<DataBaseType, IDbConnection> GetDataBase<T>() where T : class
        {
            Type type = typeof(T);

            return GetDataBase(type);
        }

        public static Tuple<DataBaseType, IDbConnection> GetDataBase(Type type)
        {
            TableMapping map = type.GetCustomAttributes(typeof(TableMapping), false)[0] as TableMapping;
            TableConfiguration table = Config.TableConfigurations.Where(p => p.Name == map.ConfigName).FirstOrDefault();

            DataBaseType BaseType;
            IDbConnection connection;
            if (table != null)
            {
                switch (table.SqlType)
                {
                    case "MsSql": BaseType = DataBaseType.SqlServer; connection = GetMsSqlConn(table.ConnectString); break;
                    case "MySql": BaseType = DataBaseType.MySql; connection = GetMySqlConn(table.ConnectString); break;
                    default: BaseType = DataBaseType.SqlServer; connection = GetMsSqlConn(table.ConnectString); break;
                }
                return new Tuple<DataBaseType, IDbConnection>(BaseType, connection);
            }
            else
            {
                throw new Exception("实体初始化数据库异常！");
            }
        }
    }
}
