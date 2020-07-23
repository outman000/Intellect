
using NPOI.XWPF.UserModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dtol.Attribute
{
    public class NPOIClass
    {

        public static string ExcelContentType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        /// <summary>
        /// 任意数据表转化为与之相对应的list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<T> ExcelToList<T>(String filePath, String tag, String tableName) where T : new()
        {
            var package = new ExcelPackage(new System.IO.FileInfo(filePath));
            var workbook = package.Workbook;
            int a = workbook.Worksheets.Count;
            var worksheet = workbook.Worksheets.First();
            return worksheet.ConvertSheetToObjects<T>(tag, tableName).ToList();
        }

        /// <summary>
        /// excel转datatable
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        //public DataTable ConvertSheetToObjects(String filePath)
        //{

        //    DataTable dt = new DataTable();
        //    List<form_forgeigntrade> li = new List<form_forgeigntrade>();
        //    ExcelPackage excel = new ExcelPackage(new System.IO.FileInfo(filePath));
        //    if (excel.Workbook.Worksheets.Count == 0)
        //    {
        //        return null;
        //    }
        //    var sheet = excel.Workbook.Worksheets[1];
        //    var rows = sheet.Dimension.End.Row;

        //    if (sheet == null)
        //    {
        //        return null;
        //    }
        //    foreach (var cell in sheet.Cells[1, 1, 1, sheet.Dimension.End.Column])
        //    {
        //        dt.Columns.Add(cell.Value.ToString());
        //    }

        //    for (var i = 1; i <= rows; i++)
        //    {
        //        var row = sheet.Cells[i, 1, i, sheet.Dimension.End.Column];
        //        dt.Rows.Add(row.Select(cell => cell.Value).ToArray());

        //    }
        //    return dt;
        //}

        /// <summary>
        /// zo
        /// </summary>
        public void ListtoDatabase()
        {

        }


        /// <summary>
        /// List转DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ListToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dataTable = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {

                    //var s = properties[i].GetValue(item);
                    //if (properties[i].GetValue(item) == null|| properties[i].GetValue(item).ToString()=="")
                    //    values[i] = "无";
                    //else
                    values[i] = properties[i].GetValue(item);
                }
                dataTable.Rows.Add(values);
            }

            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    for(int j=0;j<dataTable.Columns.Count; j++)
            //    {
            //        if (dataTable.Rows[i][j] == null)
            //        {
            //            dataTable.Rows[i][j] = "无";
            //        }
            //    }

            //}

            return dataTable;
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dataTable">数据源</param>
        /// <param name="heading">工作簿Worksheet</param>
        /// <param name="showSrNo">//是否显示行编号</param>
        /// <param name="columnsToTake">要导出的列</param>
        /// <returns></returns>
        public byte[] ExportExcel(DataTable dataTable, string heading = "", int temp = 1, bool showSrNo = false, params string[] columnsToTake)
        {
            showSrNo = true;
            byte[] result;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.Add($"{heading}Data");
                int startRowFrom = string.IsNullOrEmpty(heading) ? 1 : 3;  //开始的行
                                                                           //是否显示行编号
                if (showSrNo)
                {
                    DataColumn dataColumn = dataTable.Columns.Add("序号", typeof(int));
                    dataColumn.SetOrdinal(0);
                    int index = 1;
                    foreach (DataRow item in dataTable.Rows)
                    {
                        item[0] = index;
                        index++;
                    }
                }
                //Add Content Into the Excel File
                workSheet.Cells["A" + startRowFrom].LoadFromDataTable(dataTable, true);
                // autofit width of cells with small content  
                int columnIndex = 1;
                foreach (DataColumn item in dataTable.Columns)
                {

                    ExcelRange columnCells = workSheet.Cells[workSheet.Dimension.Start.Row, columnIndex, workSheet.Dimension.End.Row, columnIndex];

                    //int maxLength = columnCells.Max(cell => cell.Value.ToString().Count());
                    //      if (maxLength < 150)
                    //      {
                    workSheet.Column(columnIndex).AutoFit();
                    //}
                    columnIndex++;



                }
                // format header - bold, yellow on black  
                using (ExcelRange r = workSheet.Cells[startRowFrom, 1, startRowFrom, dataTable.Columns.Count])
                {
                    r.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    r.Style.Font.Bold = true;
                    r.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#1fb5ad"));
                }
                // format cells - add borders  
                using (ExcelRange r = workSheet.Cells[startRowFrom + 1, 1, startRowFrom + dataTable.Rows.Count, dataTable.Columns.Count])
                {


                    r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);


                }
                // removed ignored columns  
                for (int i = dataTable.Columns.Count - 1; i >= 0; i--)
                {
                    if (i == 0 && showSrNo)
                    {
                        continue;
                    }
                    if (!columnsToTake.Contains(dataTable.Columns[i].ColumnName))
                    {
                        workSheet.DeleteColumn(i + 1);
                    }

                }
                if (temp == 2)
                {
                    workSheet.Cells["A1"].Value = "地区";
                    workSheet.Cells["B1"].Value = "拜访企业名称";
                    workSheet.Cells["C1"].Value = "企业简介";
                    workSheet.Cells["D1"].Value = "已落户/已在谈项目及情况";
                    workSheet.Cells["E1"].Value = "成熟度";
                    workSheet.Cells["F1"].Value = "请主任拜访对接洽谈的方向";
                    workSheet.Cells["G1"].Value = "拟定时间";
                    workSheet.Cells["H1"].Value = "项目负责人";
                }
                else if (temp == 1)
                {
                    workSheet.Cells["A1"].Value = "序号";
                    workSheet.Cells["B1"].Value = "用户";
                    workSheet.Cells["C1"].Value = "线路";
                    workSheet.Cells["D1"].Value = "站点";
                    workSheet.Cells["E1"].Value = "订单号";
                    workSheet.Cells["F1"].Value = "乘车日期";
                    workSheet.Cells["G1"].Value = "部门";
                    workSheet.Cells["H1"].Value = "金额(元)";
                   
                }
                else
                {
                    workSheet.Cells["B1"].Value = "注册时间";
                    workSheet.Cells["C1"].Value = "注册资本";
                    workSheet.Cells["D1"].Value = "负责人";
                    workSheet.Cells["E1"].Value = "企业名称";
                    workSheet.Cells["F1"].Value = "投资方及项目情况 ";
                    workSheet.Cells["G1"].Value = "主要指标贡献";
                    workSheet.Cells["H1"].Value = "所属产业门类";

                }
                if (!string.IsNullOrEmpty(heading))
                {
                    workSheet.Cells["A1"].Value = heading;
                    workSheet.Cells["A1"].Style.Font.Size = 20;
                    workSheet.InsertColumn(1, 1);
                    workSheet.InsertRow(1, 1);
                    workSheet.Column(1).Width = 5;
                }

                result = package.GetAsByteArray();
            }
            return result;
        }


        //public static void Export()
        //{
        //    string filepath = HttpContext.Server.MapPath("~/simpleTable.docx");
        //    var tt = new { name = "cjc", age = 29 };
        //    using (FileStream stream = File.OpenRead(filepath))
        //    {
        //        XWPFDocument doc = new XWPFDocument(stream);
        //        //遍历段落                  
        //        foreach (var para in doc.Paragraphs)
        //        {
        //            ReplaceKey(para, tt);
        //        }                    //遍历表格      
        //        var tables = doc.Tables;
        //        foreach (var table in tables)
        //        {
        //            foreach (var row in table.Rows)
        //            {
        //                foreach (var cell in row.GetTableCells())
        //                {
        //                    foreach (var para in cell.Paragraphs)
        //                    {
        //                        ReplaceKey(para, tt);
        //                    }
        //                }
        //            }
        //        }

        //        FileStream out1 = new FileStream(HttpContext.Current.Server.MapPath("~/simpleTable" + DateTime.Now.Ticks + ".docx"), FileMode.Create);
        //        doc.Write(out1);
        //        out1.Close();
        //    }
        //}

        private static void ReplaceKey(XWPFParagraph para, object model)
        {
            string text = para.ParagraphText;
            var runs = para.Runs;
            string styleid = para.Style;
            for (int i = 0; i < runs.Count; i++)
            {
                var run = runs[i];
                text = run.ToString();
                Type t = model.GetType();
                PropertyInfo[] pi = t.GetProperties();
                foreach (PropertyInfo p in pi)
                {
                    //$$与模板中$$对应，也可以改成其它符号，比如{$name},务必做到唯一
                    if (text.Contains("$" + p.Name + "$"))
                    {
                        text = text.Replace("$" + p.Name + "$", p.GetValue(model, null).ToString());
                    }
                }
                runs[i].SetText(text, 0);
            }
        }

    }
}

