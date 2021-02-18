using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace AttributeHelperModelXml
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataNamesAttribute : Attribute
    {
        protected List<string> _valueNames { get; set; }

        public List<string> ValueNames
        {
            get
            {
                return _valueNames;
            }
            set
            {
                _valueNames = value;
            }
        }

        public DataNamesAttribute()
        {
            _valueNames = new List<string>();
        }

        public DataNamesAttribute(params string[] valueNames)
        {
            _valueNames = valueNames.ToList();
        }
    }
    public class DataNamesMapper<TEntity> where TEntity : class, new()
    {
        public TEntity MapRow(DataRow row)
        {
            //Step 1 - Get the Column Names
            var columnNames = row.Table.Columns
                .Cast<DataColumn>()
                .Select(x => x.ColumnName)
                .ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                .Where(x =>
                    x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                .ToList();

            //Step 3 - Map the data
            TEntity entity = new TEntity();
            foreach (var prop in properties)
            {
                PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
            }

            return entity;
        }

        public IEnumerable<TEntity> Map(DataTable table)
        {
            //Step 1 - Get the Column Names
            var columnNames = table.Columns.Cast<DataColumn>().Select(x =>
                x.ColumnName).ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                .Where(x =>
                    x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                .ToList();

            //Step 3 - Map the data
            List<TEntity> entities = new List<TEntity>();
            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();
                foreach (var prop in properties)
                {
                    PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
                }
                
                entities.Add(entity);
            }

            return entities;
        }
        /// <summary>
        /// Конвертация из листа в массив классов
        /// </summary>
        /// <param name="listParamEntities">Массив объектов</param>
        /// <returns></returns>
        public TEntity[] ListToClass(List<TEntity> listParamEntities)
        {
            return listParamEntities.ToArray();
        }
    }
}
