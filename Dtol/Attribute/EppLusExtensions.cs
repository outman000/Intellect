using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dtol.Attribute
{
    //下面这段代码比较犀利。可能涉及到泛型，委托,拉姆达表达式，拓展方法，linq,EPPLUS,。可读性差一些，但是是个通用的方法
    public static class EppLusExtensions
    {
        /// <summary>
        /// 获取标签对应excel的Index
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int GetColumnByName(this ExcelWorksheet ws, string columnName)
        {
            if (ws == null) throw new ArgumentNullException(nameof(ws));

            if (ws.Cells["1:1"].FirstOrDefault(c => c.Value.ToString() == columnName) == null)
            {
                return -1;
            }
            //获取所有元素集合吗，扩展first方法，获取处在第一列行中列名叫columnName的列
            return ws.Cells["1:1"].FirstOrDefault(c => c.Value.ToString() == columnName).Start.Column;
        }
        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="worksheet"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ConvertSheetToObjects<T>(this ExcelWorksheet worksheet, String tag, String tableName) where T : new()
        {
            Type type = typeof(ExcelAttribute);
            String a = type.ToString();
            // 参数为自定义属性的泛型委托，返回值为bool
            Func<CustomAttributeData, bool> columnOnly = y => y.AttributeType == typeof(ExcelAttribute);
            //反射T类获取属性.给枚举扩展方法添加方法体。


            var columns = typeof(T)//反射实体类
                                   //获取实体类的所有属性，他返回的一个属性数组，之后通过linq查询这个数组，因为这个数组继承自枚举类，所以支持linq
                .GetProperties()
                //根据条件来查询属性，（x => x.CustomAttributes.Any(columnOnly)）获取存在属性的特性
                .Where(x => x.CustomAttributes.Any(columnOnly))
                .Select(p => new
                {
                    Property = p,
                    Column = p.GetCustomAttributes<ExcelAttribute>().First().ColumnName
                }).ToList();
            //首先获取元素集合，然后和获取
            var rows = worksheet.Cells
                .Select(cell => cell.Start.Row)
                .Distinct()
                .OrderBy(x => x);

            var collection = rows.Skip(1)
                .Select(row =>
                {
                    var tnew = new T();
                    columns.ForEach(col =>
                    {
                        if (col.Column.Equals("ID"))
                        {
                            col.Property.SetValue(tnew, 0);
                            return;
                        }
                        if (col.Column.Equals("表名称"))
                        {
                            col.Property.SetValue(tnew, tableName);
                            return;
                        }
                        if (col.Column.Equals("附件id"))
                        {
                            col.Property.SetValue(tnew, tag);
                            return;
                        }
                        //表里不存在列
                        if (GetColumnByName(worksheet, col.Column) == -1)
                        {
                            return;
                        }
                        //根据列名定位列，然后通过迭代定位行
                        var val = worksheet.Cells[row, GetColumnByName(worksheet, col.Column)];
                        //  var aaaaa = val.GetValue();

                        if (val.Value == null && col.Property.PropertyType == typeof(decimal?))
                        {
                            col.Property.SetValue(tnew, Convert.ToDecimal(0));
                            return;
                        }
                        if (val.Value == null)
                        {
                            col.Property.SetValue(tnew, null);
                            return;
                        }
                        // 如果Person类的对应字段是int
                        if (col.Property.PropertyType == typeof(int))
                        {
                            col.Property.SetValue(tnew, val.GetValue<int>());
                            return;
                        }
                        // 如果Person类的对应字段是double
                        if (col.Property.PropertyType == typeof(double))
                        {
                            col.Property.SetValue(tnew, val.GetValue<double>());
                            return;
                        }
                        // 如果Person类的对应字段是DateTime?
                        if (col.Property.PropertyType == typeof(DateTime?))
                        {
                            col.Property.SetValue(tnew, val.GetValue<DateTime?>());
                            return;
                        }
                        // 如果Person类的对应字段是DateTime
                        if (col.Property.PropertyType == typeof(DateTime))
                        {
                            col.Property.SetValue(tnew, val.GetValue<DateTime>());
                            return;
                        }
                        // 如果Person类的对应字段是bool
                        if (col.Property.PropertyType == typeof(bool))
                        {
                            col.Property.SetValue(tnew, val.GetValue<bool>());
                            return;
                        }
                        // 如果Person类的对应字段是decimal
                        if (col.Property.PropertyType == typeof(decimal?))
                        {
                            col.Property.SetValue(tnew, val.GetValue<decimal?>());
                            return;
                        }
                        col.Property.SetValue(tnew, val.GetValue<string>().Trim());
                    });

                    return tnew;
                });
            return collection;
        }
    }

}
