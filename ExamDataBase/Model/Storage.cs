using System;
using System.Collections.Generic;

namespace ExamDataBase
{

    public static class Storage
    {
        public static readonly DataBase DataBase = new DataBase();

        /*
         * Table Data
         */
        private static List<String>                 tableNamesList          =   new List<String>();       
        private static Dictionary<String, string[]> tableColumsTypeInfoDict =   new Dictionary<string, string[]>();
        private static Dictionary<String, string[]> tableColumsNamesDict    =   new Dictionary<string, string[]>();
        private static Dictionary<String, string[]> tableColumsDefaultDict  =   new Dictionary<string, string[]>();
        private static Dictionary<String, bool[]>   tableNotNullColumnsDict =   new Dictionary<string, bool[]>();
        private static Dictionary<String, bool[]>   tableUniqColumnsDict    =   new Dictionary<string, bool[]>();
        private static Dictionary<String, bool[]>   tableKeyColumnsDict     =   new Dictionary<string, bool[]>();
        private static Dictionary<String, bool[]>   tableAutoIncColumnsDict =   new Dictionary<string, bool[]>();
        private static Dictionary<String, int>      tableCountColumnsDict   =   new Dictionary<string, int>();

        /*
         * Form
         */
        private static MenuForm         menuForm;
        private static CreateTableForm  createTableForm;
        private static InsertForm       insertForm;
        private static MyQueryForm      myQueryForm;
        private static UpdateForm       updateForm;
        private static DeleteForm       deleteForm;

        /*
         * Flags
         */
        public static bool AlertInsertQuery = false;
        public static bool AlertCreateTable = false;
        public static bool AlertMyQuery     = false;

        /*
         * Get/Set
         */
        public static List<string> TableNamesList { get => tableNamesList; set => tableNamesList = value; }
        public static MenuForm MenuForm { get => menuForm; set => menuForm = value; }
        public static CreateTableForm CreateTableForm { get => createTableForm; set => createTableForm = value; }
        public static InsertForm InsertQueryForm { get => insertForm; set => insertForm = value; }
        public static MyQueryForm MyQueryForm { get => myQueryForm; set => myQueryForm = value; }
        public static Dictionary<string, string[]> TableColumsTypeInfoDict { get => tableColumsTypeInfoDict; set => tableColumsTypeInfoDict = value; }
        public static Dictionary<string, string[]> TableColumsNamesDict { get => tableColumsNamesDict; set => tableColumsNamesDict = value; }
        public static Dictionary<string, int> TableCountColumnsDict { get => tableCountColumnsDict; set => tableCountColumnsDict = value; }
        public static Dictionary<string, bool[]> TableNotNullColumnsDict { get => tableNotNullColumnsDict; set => tableNotNullColumnsDict = value; }
        public static Dictionary<string, bool[]> TableUniqColumnsDict { get => tableUniqColumnsDict; set => tableUniqColumnsDict = value; }
        public static Dictionary<string, bool[]> TableKeyColumnsDict { get => tableKeyColumnsDict; set => tableKeyColumnsDict = value; }
        public static Dictionary<string, string[]> TableColumsDefaultDict { get => tableColumsDefaultDict; set => tableColumsDefaultDict = value; }
        public static Dictionary<string, bool[]> TableAutoIncColumnsDict { get => tableAutoIncColumnsDict; set => tableAutoIncColumnsDict = value; }
        public static UpdateForm Updateform { get => updateForm; set => updateForm = value; }
        public static DeleteForm DeleteForm { get => deleteForm; set => deleteForm = value; }

        public static void Clear() {
            TableNamesList.Clear();
            TableColumsNamesDict.Clear();
            TableColumsTypeInfoDict.Clear();
            TableCountColumnsDict.Clear();
            TableNotNullColumnsDict.Clear();
            TableKeyColumnsDict.Clear();
            TableUniqColumnsDict.Clear();
            TableColumsDefaultDict.Clear();
            TableAutoIncColumnsDict.Clear();
        }

        internal static List<Column> InitColumns(string tableName)
        {
            List<Column> columnList = new List<Column>();

            for (int i = 0; i < TableCountColumnsDict[tableName]; i++)
            {
                Column newColumn = new Column(
                    tableColumsNamesDict[tableName][i],
                    tableColumsTypeInfoDict[tableName][i],
                    tableKeyColumnsDict[tableName][i],
                    tableAutoIncColumnsDict[tableName][i],
                    tableNotNullColumnsDict[tableName][i],
                    tableColumsDefaultDict[tableName][i],
                    tableUniqColumnsDict[tableName][i]
                    );

                columnList.Add(newColumn);
            }

            return columnList;
        }
    }
}
