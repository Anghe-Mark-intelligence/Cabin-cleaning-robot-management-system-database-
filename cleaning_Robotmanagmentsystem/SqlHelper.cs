using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WinRobotSystem
{
    public class SqlHelper
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static readonly string connectionString = "Server=.;Database=RobotSystem;User Id=sa;Password=123;";

        /// <summary>
        /// 执行一个不需要返回值的SqlCommand命令
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);
                int val = (int)cmd.ExecuteNonQuery();

                //清空SqlCommand中的参数列表
                cmd.Parameters.Clear();
                return val;
            }
        }


        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public static DataSet QuerySet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                var adapter = new SqlDataAdapter(cmd);
                var data = new DataSet();

                adapter.Fill(data);
                //清空SqlCommand中的参数列表
                cmd.Parameters.Clear();
                return data;
            }
        }

        /// <summary>
        /// 获取datatable
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataTable QueryTable(string cmdText, CommandType cmdType = CommandType.Text, params SqlParameter[] commandParameters)
        {
            DataSet data = QuerySet(cmdType, cmdText, commandParameters);
            if (data != null && data.Tables.Count > 0)
                return data.Tables[0];
            else
                return null;
        }
    }
}
