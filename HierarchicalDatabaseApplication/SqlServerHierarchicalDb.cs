using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HierarchicalDb
{
    public class SqlServerHierarchicalDb
    {
        private string connectionString = "";
        private static SqlConnection con = null;
        public SqlServerHierarchicalDb()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ToString();
            if (con == null) con = new SqlConnection();
            if (con.State == ConnectionState.Open) con.Close();
            con.ConnectionString = connectionString;
            con.Open();
        }

        public SqlServerHierarchicalDb(string constr)
        {
            connectionString = constr;
            if (con == null) con = new SqlConnection();
            if (con.State == ConnectionState.Open) con.Close();
            con.ConnectionString = connectionString;
            con.Open();
        }

        public DataSet ExecuteSql(string sql)
        {
            DataSet result = new DataSet();

            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 0;
            using (SqlDataAdapter reader = new SqlDataAdapter(command))
            {
                reader.Fill(result);
            }
            return result;
        }

        public List<TableModel> GetMasterTables()
        {
            List<TableModel> models = new List<TableModel>();
            string sql = "select distinct 1 as LevelID, Parent.name as TableName, Parent.object_id as TbObjID from sys.objects Parent left join sys.foreign_key_columns RefKey ";
            sql += "On RefKey.parent_object_id = Parent.object_id and RefKey.parent_object_id<> RefKey.referenced_object_id and RefKey.constraint_column_id = 1";
            sql += "where RefKey.parent_object_id is null and Parent.type = 'U' and Parent.name <> 'dtproperties' and Parent.name not like '%A' order by Parent.name;";
            DataSet result = new DataSet();

            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 0;
            using (SqlDataAdapter reader = new SqlDataAdapter(command))
            {
                reader.Fill(result);
            }

            if (result.Tables.Count > 0)
            {
                models = (from d in result.Tables[0].AsEnumerable()
                          select new TableModel
                          {
                              LevelID = d.Field<int>("LevelID"),
                              TableName = d.Field<string>("TableName"),
                              TbObjID = d.Field<int>("TbObjID")
                          }).ToList();
            }
            return models;
        }

        public List<HierarchicalModel> GetHierarchicalTables()
        {
            List<HierarchicalModel> allTables = new List<HierarchicalModel>();
            var masterTables = GetMasterTables();
            foreach (var master in masterTables)
            {
                HierarchicalModel tbl = new HierarchicalModel();
                tbl.Table = master;
                tbl.RefTable = GetRefTable(tbl);
                allTables.Add(tbl);
            }

            return allTables;
        }

        public List<HierarchicalModel> GetRefTable(HierarchicalModel parent)
        {
            List<HierarchicalModel> refTables = new List<HierarchicalModel>();
            int levelID = parent.Table.LevelID + 1;
            if (levelID > 20)
            {
                return null;
            }
            string sql = "select    fk.name as ConstraintName,'' as from_schema,o1.Name as from_table,''  as ColumnName,'' as to_schema,o2.Name as to_table     ";
            sql += "from    sys.foreign_keys fk  inner    join sys.objects o1	on        fk.parent_object_id = o1.object_id   ";
            //sql += "inner    join sys.schemas s1    on        o1.schema_id = s1.schema_id    ";
            sql += "inner    join sys.objects o2    on        fk.referenced_object_id = o2.object_id   ";
            //sql += "inner    join sys.schemas s2    on        o2.schema_id = s2.schema_id    ";
            //sql += "inner	 join INFORMATION_SCHEMA.KEY_COLUMN_USAGE col	on	fk.name = col.CONSTRAINT_NAME ";
            sql += "where    not    (o1.name = o2.name) ";
            sql += "and o2.Name='" + parent.Table.TableName + "' ";
            sql += "order by o1.Name ";

            DataSet result = new DataSet();
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 0;
            using (SqlDataAdapter reader = new SqlDataAdapter(command))
            {
                reader.Fill(result);
            }

            if (result.Tables.Count > 0)
            {
                var models = (from d in result.Tables[0].AsEnumerable()
                              select new TableModel
                              {
                                  LevelID = levelID,
                                  TableName = d.Field<string>("from_table"),
                                  ConstraintName = d.Field<string>("ConstraintName"),
                                  ColumnName = d.Field<string>("ColumnName")
                              }).ToList();

                foreach (var model in models)
                {
                    HierarchicalModel tbl = new HierarchicalModel();
                    tbl.Table = model;
                    if (CheckParent(parent.Table.TableName, model.TableName))
                    {
                        tbl.RefTable = GetRefTable(tbl);
                    }
                    refTables.Add(tbl);
                }
            }

            return refTables;
        }

        private bool CheckParent(string parent, string tbl)
        {
            bool chk = true;
            string sql = "select    fk.name as ConstraintName,'' as from_schema,o1.Name as from_table,'' as ColumnName,'' as to_schema,o2.Name as to_table     ";
            sql += "from    sys.foreign_keys fk  inner    join sys.objects o1	on        fk.parent_object_id = o1.object_id   ";
            //sql += "inner    join sys.schemas s1    on        o1.schema_id = s1.schema_id    ";
            sql += "inner    join sys.objects o2    on        fk.referenced_object_id = o2.object_id   ";
            //sql += "inner    join sys.schemas s2    on        o2.schema_id = s2.schema_id    ";
            sql += "where    not    (o1.name = o2.name) ";
            sql += "and o1.Name='" + parent + "'";
            sql += "order by o1.Name ";

            DataSet result = new DataSet();
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 0;
            using (SqlDataAdapter reader = new SqlDataAdapter(command))
            {
                reader.Fill(result);
            }
            sql = "select    fk.name as ConstraintName,'' as from_schema,o1.Name as from_table,'' as ColumnName,'' as to_schema,o2.Name as to_table     ";
            sql += "from    sys.foreign_keys fk  inner    join sys.objects o1	on        fk.parent_object_id = o1.object_id   ";
            //sql += "inner    join sys.schemas s1    on        o1.schema_id = s1.schema_id    ";
            sql += "inner    join sys.objects o2    on        fk.referenced_object_id = o2.object_id   ";
            //sql += "inner    join sys.schemas s2    on        o2.schema_id = s2.schema_id    ";
            sql += "where    not    (o1.name = o2.name) ";
            sql += "and o2.Name='" + tbl + "'";
            sql += "order by o1.Name ";

            DataSet result2 = new DataSet();
            command = new SqlCommand(sql, con);
            command.CommandTimeout = 0;
            using (SqlDataAdapter reader = new SqlDataAdapter(command))
            {
                reader.Fill(result2);
            }

            foreach (DataRow dr in result.Tables[0].Rows)
            {
                if (dr["to_table"].ToString() == tbl)
                {
                    chk = false;
                    break;
                }
                else
                {
                    foreach (DataRow dr2 in result2.Tables[0].Rows)
                    {
                        if (dr["to_table"].ToString() == dr2["from_table"].ToString())
                        {
                            chk = false;
                            break;
                        }
                    }
                    if (!chk)
                    {
                        break;
                    }

                }
            }
            return chk;
        }
    }



    public class HierarchicalModel
    {
        public TableModel Table { get; set; }

        public List<HierarchicalModel> RefTable { get; set; }
    }

    public class TableModel
    {
        public int LevelID { get; set; }
        public string TableName { get; set; }
        public int TbObjID { get; set; }

        public string ConstraintName { get; set; }

        public string ColumnName { get; set; }
    }
}
