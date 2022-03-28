using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamDataBase
{
    public static class InitTables
    {
        public static void loadTables()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Storage.DataBase.getConnect();
            String cmdText = "SELECT TABLE_NAME from INFORMATION_SCHEMA.TABLES;";
            cmd.CommandText = cmdText;

            Storage.DataBase.OpenConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Read");
                Storage.TableNamesList.Add(reader[0].ToString());
            }
            reader.Close();
            Storage.DataBase.CloseConnection();


            foreach (String s in Storage.TableNamesList)
                Console.WriteLine(s);
        }

        public static void newTablesInfoToDataGrid(String tableName, DataGridView dataGridView, int TableNumber)
        {
            int count = countColumns(tableName);
            List<String[]> data = new List<string[]>();

            //получение названий столбцов
            getColumns(Storage.TableColumsNamesDict, count, tableName);
            //  получение строк           
            getRows(data, count, tableName);


            for (int i = 0; i < count; i++)
                dataGridView.Columns.Add(Storage.TableColumsNamesDict[tableName][i], Storage.TableColumsNamesDict[tableName][i]);

            foreach (string[] s in data)
                dataGridView.Rows.Add(s);

            data.Clear();
        }

        public static void tablesInfoToDataGrid(String tableName, DataGridView dataGridView)
        {
            int count = Storage.TableCountColumnsDict[tableName];
            List<String[]> data = new List<string[]>();

            //  получение строк           
            getRows(data, count, tableName);

            for (int i = 0; i < count; i++)
                dataGridView.Columns.Add(Storage.TableColumsNamesDict[tableName][i], Storage.TableColumsNamesDict[tableName][i]);

            foreach (string[] s in data)
                dataGridView.Rows.Add(s);

            data.Clear();
        }

        public static int countColumns(String tableName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Storage.DataBase.getConnect();
            String cmdText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @NAMETABLE";
            cmd.CommandText = cmdText;
            cmd.Parameters.AddWithValue("@NAMETABLE", tableName);

            Storage.DataBase.OpenConnection();

            Int32 countColumn = (Int32)cmd.ExecuteScalar();

            Storage.DataBase.CloseConnection();

            Storage.TableCountColumnsDict.Add(tableName, countColumn);
            return countColumn;
        }

        public static void getColumns(Dictionary<String, string[]> dataDict, int count, String tableName)
        {
            String[] data;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Storage.DataBase.getConnect();

            String cmdText = "select column_name from information_schema.columns WHERE TABLE_NAME = @NAMETABLE";
            cmd.CommandText = cmdText;
            cmd.Parameters.AddWithValue("@NAMETABLE", tableName);


            Storage.DataBase.OpenConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            data = new string[count];
            for (int i = 0; i < count; i++)
            {
                reader.Read();
                data[i] = reader[0].ToString();
            }
            dataDict.Add(tableName, data);
            reader.Close();
            Storage.DataBase.CloseConnection();

        }

        public static void getRows(List<string[]> data, int countColumns, String tableName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Storage.DataBase.getConnect();

            String cmdText = "SELECT * from [" + tableName + "] ";
            cmd.CommandText = cmdText;
            //cmd.Parameters.AddWithValue("@NAMETABLE", tableName);

            Storage.DataBase.OpenConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                data.Add(new string[countColumns]);

                for (int i = 0; i < countColumns; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }
            }

            reader.Close();
            Storage.DataBase.CloseConnection();
        }

        public static void loadTablesColumnInfo()
        {
            String cmdText;
            String[] data;
            String[] default_value;
            int count = 0;
            bool[] Null;
            bool[] uniq;
            bool[] key;
            bool[] auto;


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Storage.DataBase.getConnect();

            foreach (String tableName in Storage.TableNamesList)
            {
                count = Storage.TableCountColumnsDict[tableName];

                cmdText = "SELECT [DATA_TYPE],[IS_NULLABLE],[COLUMN_DEFAULT] from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";

                Console.WriteLine(cmdText.ToString());

                cmd.CommandText = cmdText;
                
                Storage.DataBase.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();

                data = new string[count];
                Null = new bool[count];
                default_value = new string[count];

                for (int i = 0; i < count; i++)
                {
                    reader.Read();
                    data[i] = reader[0].ToString();
                    if (reader[1].ToString().Equals("NO"))
                        Null[i] = true;
                    else
                        Null[i] = false;
                    if (!reader[2].ToString().Equals("NULL"))
                    {
                        default_value[i] = reader[2].ToString();                       
                    }                                                                                                
                    else
                        default_value[i] = "";

                }

                reader.Close();
                Storage.DataBase.CloseConnection();
               
                Storage.TableColumsTypeInfoDict.Add(tableName, data);
                Storage.TableNotNullColumnsDict.Add(tableName, Null);
                Storage.TableColumsDefaultDict.Add(tableName, default_value);

                foreach (String str in data)
                    Console.WriteLine(str);

                data = null;
                Null = null;
                default_value = null;
            }
            

            foreach (var b in Storage.TableNotNullColumnsDict)
                foreach (bool bb in b.Value)
                    Console.WriteLine(bb.ToString());

            foreach (var b in Storage.TableColumsDefaultDict)
                foreach (string bb in b.Value)
                {      
                    Console.WriteLine(bb.ToString());                   
                }
                    
            foreach (String tableName in Storage.TableNamesList)
            {
                count = Storage.TableCountColumnsDict[tableName];

                cmdText = @"SELECT c.column_id, is_identity, is_primary_key
                            FROM sys.indexes AS i
                            INNER JOIN sys.index_columns AS ic 
                            ON i.object_id = ic.object_id AND i.index_id = ic.index_id
                            INNER JOIN sys.columns AS c 
                            ON ic.object_id = c.object_id AND c.column_id = ic.column_id
                            AND i.object_id = OBJECT_ID('"+ tableName + "');";

                Console.WriteLine(cmdText.ToString());

                cmd.CommandText = cmdText;

                Storage.DataBase.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();                

                key = new bool[count];
                uniq = new bool[count];
                auto = new bool[count];

                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString());
                    int temp = int.Parse(reader[0].ToString());
                    if (reader[1].ToString().Equals("True"))
                    {
                        key[temp - 1] = true;
                        auto[temp - 1] = true;
                        uniq[temp - 1] = false;
                    }
                    else if (reader[2].ToString().Equals("True"))
                    {
                        key[temp - 1] = true;
                        auto[temp - 1] = false;
                        uniq[temp - 1] = false;
                    }
                    else
                    {
                        key[temp - 1] = false;
                        auto[temp - 1] = false;
                        uniq[temp - 1] = true;
                    }
                    
                }

                reader.Close();
                Storage.DataBase.CloseConnection();

                Storage.TableKeyColumnsDict.Add(tableName, key);
                Storage.TableAutoIncColumnsDict.Add(tableName, auto);
                Storage.TableUniqColumnsDict.Add(tableName, uniq);
                
                Console.WriteLine(tableName);
                Console.WriteLine("ключ " + Storage.TableKeyColumnsDict[tableName][0].ToString());
                Console.WriteLine("итератор " + Storage.TableAutoIncColumnsDict[tableName][0].ToString());
                Console.WriteLine("уникальный " + Storage.TableUniqColumnsDict[tableName][0].ToString());
            }                   
        }

    }
}
