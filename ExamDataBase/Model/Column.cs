using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataBase
{
    class Column
    {
        private string columnName;      
        private string type;
        private bool key;
        private bool autoInc;
        private bool notNull;
        private object default_value;        
        private bool uniq;

        public string ColumnName { get => columnName; set => columnName = value; }
        public string Type { get => type; set => type = value; }
        public bool Key { get => key; set => key = value; }
        public bool AutoInc { get => autoInc; set => autoInc = value; }
        public bool NotNull { get => notNull; set => notNull = value; }
        public object Default_value { get => default_value; set => default_value = value; }
        public bool Uniq { get => uniq; set => uniq = value; }

        public Column(string columnName, string type, bool key, bool autoInc, bool notNull, object default_value, bool uniq)
        {
            this.ColumnName = columnName;
            this.Type = type;
            this.Key = key;
            this.AutoInc = autoInc;
            this.NotNull = notNull;
            this.Default_value = default_value;
            this.Uniq = uniq;
        }

        public Column()
        {

        }

        public string ToSql()
        {
            StringBuilder cmdText = new StringBuilder();


            cmdText.Append("[");
            cmdText.Append(ColumnName);
            cmdText.Append("]");
            cmdText.Append(" ");
            cmdText.Append(Type);
            if (Key)
                cmdText.Append(" PRIMARY KEY");
            if (Type.Equals("int") & AutoInc)
                cmdText.Append(" IDENTITY(1,1)");
            if (NotNull)
                cmdText.Append(" NOT NULL");
            if (!Default_value.Equals(""))
            {
                switch (Type)
                {
                    case "varchar(100)":
                        {
                            cmdText.Append(" DEFAULT " + "'" + Default_value.ToString() + "'");
                            break;
                        }
                    case "int":
                        {
                            cmdText.Append(" DEFAULT " + Default_value.ToString());
                            break;
                        }
                    case "date":
                        {
                            cmdText.Append(" DEFAULT " + "'" + Default_value.ToString() + "'");
                            break;
                        }
                    case "float":
                        {
                            cmdText.Append(" DEFAULT " + Default_value.ToString());
                            break;
                        }
                }                                    
            }
            if (Uniq & !Key) 
                cmdText.Append(" UNIQUE");
            cmdText.Append(", ");

            return cmdText.ToString();
        }
    }
}
