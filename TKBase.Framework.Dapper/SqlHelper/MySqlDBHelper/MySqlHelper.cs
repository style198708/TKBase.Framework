﻿//////////////////////////////////////////////////////////////////////////////////////////////////
//目的：封装数据库的基本操作
//方法： static MyMySqlConnection GetDataCon　根据数据库名称返回连接　　
//　　　 static MyMySqlTransaction BeginTransaction　开始对应数据库的事务，返回事务实例
//　　　 static int ExecuteNonQuery　执行ＳＱＬ语句或者存储过程 ,不返回参数
//       static DataSet ExecuteDataset 执行ＳＱＬ语句或者存储过程，返回dataset
//       static MySqlDataReader ExecuteReader 执行ＳＱＬ语句或者存储过程，返回MySqlDataReader
//       static object ExecuteScalar 执行ＳＱＬ语句或者存储过程，返回object
//  
/////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

using System.Data.Common;

namespace TKBase.Framework.Dapper.MySqlDBHelper
{
    /// <summary>
    /// 封装数据库的基本操作 
    /// </summary>
    /// <remarks>    
    public class SQLHelper
    {
        #region 私有方法和工具

        //sql
        private static void PrepareCommand(MySqlCommand command, MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, out bool mustCloseConnection, List<IDataParameter> commandParameters, int? commandTimeout = null)
        {
            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            if (commandTimeout != null)
            {
                command.CommandTimeout = Convert.ToInt32(commandTimeout);
            }
            // Set the command type
            command.CommandType = commandType;
            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }



        //通用
        private static void AttachParameters(MySqlCommand command, List<IDataParameter> commandParameters)
        {

            if (commandParameters != null && commandParameters.Count > 0)
            {
                foreach (MySqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        #endregion

        #region transaction 事务处理
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <param name="Iso">指定连接的事务锁定行为</param>
        /// <returns>当前事务</returns>  
        public static IDbTransaction BeginTransaction(MySqlConnection conn, IsolationLevel Iso)
        {
            conn.Open();
            return conn.BeginTransaction(Iso);
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <returns>当前事务</returns>
        public static IDbTransaction BeginTransaction(MySqlConnection conn)
        {
            conn.Open();
            return conn.BeginTransaction();
        }

        /// <summary>
        /// 结束事务，确认操作
        /// </summary>
        /// <param name="Transaction">要结束的事务</param>
        public static void endTransactionCommit(IDbTransaction Transaction)
        {
            using (DbConnection con = (DbConnection)Transaction.Connection)
            {
                Transaction.Commit();
            }
        }

        /// <summary>
        /// 结束事务，回滚操作
        /// </summary>
        /// <param name="Transaction">要结束的事务</param>
        public static void endTransactionRollback(IDbTransaction Transaction)
        {
            using (DbConnection con = (DbConnection)Transaction.Connection)
            {
                Transaction.Rollback();
            }
        }

        #endregion

        #region ExecuteNonQuery


        /// <summary>
        /// 执行ＳＱＬ语句或者存储过程 ,不返回参数,只返回影响行数
        /// </summary>
        /// <param name="connection">要执行ＳＱＬ语句的连接</param>
        /// <param name="commandText">ＳＱＬ语句或者存储过程名</param>
        /// <param name="commandParameters">ＳＱＬ语句或者存储过程参数</param>
        /// <param name="commandType">ＳＱＬ语句类型</param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(MySqlConnection connection, string commandText, List<IDataParameter> commandParameters = null, CommandType commandType = CommandType.Text, int? commandTimeout = null)
        {
            int retval = 0;
            //要检查参数
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, connection, (MySqlTransaction)null, commandType, commandText, out bool mustCloseConnection, commandParameters, commandTimeout);
            retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();
            return retval;
        }


        /// <summary>
        ///  执行ＳＱＬ语句或者存储过程 ,不返回参数,只返回影响行数(通用)
        /// </summary>
        /// <param name="transaction">语句所在的事务</param>
        /// <param name="commandType">ＳＱＬ语句类型</param>
        /// <param name="commandText">ＳＱＬ语句或者存储过程名</param>
        /// <param name="commandParameters">ＳＱＬ语句或者存储过程参数</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(IDbTransaction transaction, string commandText, List<IDataParameter> commandParameters = null, CommandType commandType = CommandType.Text, int? commandTimeout = null)
        {
            //要检查参数  
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, ((MySqlTransaction)transaction).Connection, (MySqlTransaction)transaction, commandType, commandText, out bool mustCloseConnection, commandParameters, commandTimeout);
            int retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return retval;
        }
        #endregion

        #region ExecuteDataset

        /// <summary>
        /// 执行ＳＱＬ语句或者存储过程 ,返回参数dataset
        /// </summary>
        /// <param name="connection">要执行ＳＱＬ语句的连接</param>
        /// <param name="commandText">ＳＱＬ语句或者存储过程名</param>
        /// <param name="commandParameters">ＳＱＬ语句或者存储过程参数</param>
        /// <param name="commandType">ＳＱＬ语句类型</param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>执行结果集</returns>
        public static DataSet ExecuteDataset(MySqlConnection connection, string commandText, List<IDataParameter> commandParameters = null, CommandType commandType = CommandType.Text, int? commandTimeout = null)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, connection, (MySqlTransaction)null, commandType, commandText, out bool mustCloseConnection, commandParameters, commandTimeout);
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                if (mustCloseConnection)
                    connection.Close();
                return ds;
            }
        }

        /// <summary>
        /// 执行ＳＱＬ语句或者存储过程 ,返回参数dataset
        /// </summary>
        /// <param name="transaction">语句所在的事务</param>
        /// <param name="commandText">ＳＱＬ语句或者存储过程名</param>
        /// <param name="commandParameters">ＳＱＬ语句或者存储过程参数</param>
        /// <param name="commandType">ＳＱＬ语句类型</param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>执行结果集</returns>
        public static DataSet ExecuteDataset(IDbTransaction transaction, string commandText, List<IDataParameter> commandParameters = null, CommandType commandType = CommandType.Text, int? commandTimeout = null)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, (MySqlConnection)transaction.Connection, (MySqlTransaction)transaction, commandType, commandText, out bool mustCloseConnection, commandParameters, commandTimeout);
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        #endregion

        #region ExecuteReader

        //通用
        private static MySqlDataReader ExecuteReader(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, bool isClose, List<IDataParameter> commandParameters = null, int? commandTimeout = null)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, connection, transaction, commandType, commandText, out bool mustCloseConnection, commandParameters, commandTimeout);
            MySqlDataReader dataReader = null;
            if (isClose)
            {
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                dataReader = cmd.ExecuteReader();
            }
            bool canClear = true;
            foreach (IDataParameter commandParameter in cmd.Parameters)
            {
                if (commandParameter.Direction != ParameterDirection.Input)
                    canClear = false;
            }
            if (canClear)
            {
                cmd.Parameters.Clear();
            }
            return dataReader;
        }


        /// <summary>
        /// 执行ＳＱＬ语句或者存储过程 ,返回参数datareader(通用)
        /// <remarks >
        /// 需要显示关闭连接
        /// </remarks>
        /// </summary>
        /// <param name="connection">要执行ＳＱＬ语句的连接</param>
        /// <param name="commandType">ＳＱＬ语句类型</param>
        /// <param name="commandText">ＳＱＬ语句或者存储过程名</param>
        /// <param name="commandParameters">ＳＱＬ语句或者存储过程参数</param>
        /// <returns>DataReader</returns>
        public static MySqlDataReader ExecuteReader(MySqlConnection connection, string commandText, List<IDataParameter> commandParameters = null, CommandType commandType = CommandType.Text, int? commandTimeout = null)
        {
            bool mustCloseConnection = true;
            return ExecuteReader(connection, (MySqlTransaction)null, commandType, commandText, mustCloseConnection, commandParameters, commandTimeout);
        }


        /// <summary>
        /// 执行ＳＱＬ语句或者存储过程 ,返回参数datareader
        /// <remarks >
        /// 需要显示关闭连接
        /// </remarks>
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <param name="commandType">ＳＱＬ语句类型</param>
        /// <param name="commandText">ＳＱＬ语句或者存储过程名</param>
        /// <param name="commandParameters">ＳＱＬ语句或者存储过程参数</param>
        /// <returns>DataReader</returns>
        public static MySqlDataReader ExecuteReader(IDbTransaction transaction, string commandText, List<IDataParameter> commandParameters = null, CommandType commandType = CommandType.Text, int? commandTimeout = null)
        {
            bool mustCloseConnection = false;
            return ExecuteReader((MySqlConnection)transaction.Connection, (MySqlTransaction)transaction, commandType, commandText, mustCloseConnection, commandParameters, commandTimeout);
        }

        #endregion

        #region ExecuteScalar


        /// <summary>
        /// 执行ＳＱＬ语句或者存储过程 ,返回参数object．第一行，第一列的值(通用)
        /// </summary>
        /// <param name="connection">要执行ＳＱＬ语句的连接</param>
        /// <param name="commandType">ＳＱＬ语句类型</param>
        /// <param name="commandText">ＳＱＬ语句或者存储过程名</param>
        /// <param name="commandParameters">ＳＱＬ语句或者存储过程参数</param>
        /// <returns>执行结果集第一行，第一列的值</returns>　
        public static object ExecuteScalar(MySqlConnection connection, string commandText, List<IDataParameter> commandParameters = null, CommandType commandType = CommandType.Text, int? commandTimeout = null)
        {
            object retval = null;
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, connection, (MySqlTransaction)null, commandType, commandText, out bool mustCloseConnection, commandParameters, commandTimeout);
            retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();
            return retval;
        }



        /// <summary>
        ///  执行ＳＱＬ语句或者存储过程 ,返回参数object．第一行，第一列的值
        /// </summary>
        /// <param name="transaction">语句所在的事务</param>
        /// <param name="commandType">ＳＱＬ语句类型</param>
        /// <param name="commandText">ＳＱＬ语句或者存储过程名</param>
        /// <param name="commandParameters">ＳＱＬ语句或者存储过程参数</param>
        /// <returns>执行结果集第一行，第一列的值</returns>
        public static object ExecuteScalar(IDbTransaction transaction, string commandText, List<IDataParameter> commandParameters = null, CommandType commandType = CommandType.Text, int? commandTimeout = null)
        {
            object retval = null;
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, ((MySqlTransaction)transaction).Connection, (MySqlTransaction)transaction, commandType, commandText, out bool mustCloseConnection, commandParameters, commandTimeout);
            retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return retval;
        }

        #endregion


    }
}

