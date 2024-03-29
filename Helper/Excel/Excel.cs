﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Helper.Excel
{
    /// <summary>
    /// ExcelHelper
    /// </summary>
    public class ExcelHelper : IDisposable
    {
        #region 声明
        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;
        #endregion

        #region 重载加入表格路径

        /// <summary>
        /// ExcelHelper（fileName）
        /// </summary>
        /// <param name="fileName"></param>
        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        #endregion

        #region 得到EXCEL的工作表中的所有Sheet名

        /// <summary>
        /// 得到EXCEL的工作表中的所有Sheet名
        /// </summary>
        /// <returns></returns>
        public List<string> excel_sheet_list()
        {

            try
            {
                List<string> excel_sheet_list = new List<string>();
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);


                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    string SheetName;
                    SheetName = workbook.GetSheetAt(i).SheetName;
                    excel_sheet_list.Add(SheetName);
                }

                return excel_sheet_list;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region 将DataTable数据导入到excel中

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        #endregion

        #region 将DataSet数据导入到excel中

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="ds">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataSetToExcel(DataSet ds, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                for (int ii = 0; ii < ds.Tables.Count; ii++)
                {
                    if (workbook != null)
                    {
                        sheet = workbook.CreateSheet(ds.Tables[ii].TableName);
                    }
                    else
                    {
                        return -1;
                    }

                    if (isColumnWritten == true) //写入DataTable的列名
                    {
                        IRow row = sheet.CreateRow(0);
                        for (j = 0; j < ds.Tables[ii].Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(ds.Tables[ii].Columns[j].ColumnName);
                        }
                        count = 1;
                    }
                    else
                    {
                        count = 0;
                    }

                    for (i = 0; i < ds.Tables[ii].Rows.Count; ++i)
                    {
                        IRow row = sheet.CreateRow(count);
                        for (j = 0; j < ds.Tables[ii].Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(ds.Tables[ii].Rows[i][j].ToString());
                        }
                        ++count;
                    }
                }

                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        #endregion

        #region 将DataGridView数据导入到excel中

        /// <summary>
        /// 将DataGridView数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataGridViewToExcel(DataGridView data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            int k;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    k = 0;
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {


                        //Console.WriteLine(data.Columns[j].HeaderText);
                        if (data.Columns[j].HeaderText != "" && data.Columns[j].Visible==true)
                        {
                            row.CreateCell(j-k).SetCellValue(data.Columns[j].HeaderText);
                        }
                        else
                        {
                            k++;
                        }
                        
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    k = 0;
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        if (data.Columns[j].HeaderText != "" && data.Columns[j].Visible == true)
                        {
                            if (data.Rows[i].Cells[j].Value == null)
                            {
                                row.CreateCell(j-k).SetCellValue("");
                            }
                            else
                            {
                                row.CreateCell(j-k).SetCellValue(data.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                        else
                        {
                            k++;
                        }
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
           
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
               
            }
        }

        #endregion





        #region 将excel中的数据导入到DataTable中

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;

#if !DEBUG
            try
            {
#endif
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                
                

                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);


                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        Console.WriteLine(i);
                        IRow row = sheet.GetRow(i);
                    
                      
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                        
                        

                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            {
                               // Console.WriteLine(row.GetCell(j).ToString());
                                dataRow[j - row.FirstCellNum] = row.GetCell(j).ToString();
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;

#if !DEBUG
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
                
            }
#endif
        }

#endregion

#region 将excel中的数据导入到DataSet中

        /// <summary>
        /// 将excel中的数据导入到DataSet中
        /// </summary>
        /// <returns></returns>
        public DataSet exceltoDataSet()
        {
            DataSet return_datrset = new DataSet();
            List <string> excel_name_list = new List<string>();
            excel_name_list = excel_sheet_list();

            foreach (string item in excel_name_list)
            {
                DataTable dt = new DataTable();
                dt= ExcelToDataTable(item, true);
                dt.TableName = item;
                return_datrset.Tables.Add(dt);
            }
            return return_datrset;
        }

#endregion

#region Dispose

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }

#endregion

     

   
    }

    /// <summary>
    /// Excel导出导入类
    /// </summary>
    public class Excel_Export
    {

#region DataGridView导出Excel

            /// <summary>
            /// 将ExDataGridView中的数据导出到Excel文件中
            /// </summary>
            /// <param name="gridview">要导出的ExDataGridView</param>
            /// <param name="sheetname">导出的EXCEL的sheet页名称</param>
            /// <returns></returns>
            public static bool DataGridViewToExcel(DataGridView gridview, string sheetname = "sheet1")
            {

                System.Windows.Forms.SaveFileDialog SFD = new System.Windows.Forms.SaveFileDialog();

                string FileName = "";

                if (gridview.Columns.Count == 0)
                {
                    throw new Exception("没有可以导出的数据！");
                }

                SFD.Filter = "2003 Excel文件(*.xls)|*.xls|2007 Excel文件(*.xlsx)|*.xlsx";
                SFD.Title = "导出Excel表";

                if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return false;
                }


                FileName = SFD.FileName.ToString().Trim();


                try
                {
                    //DataTable dt = Helper.Transformation.Transformation.DataConvert.GetDgvToTable(gridview);
                    Helper.Excel.ExcelHelper a = new Helper.Excel.ExcelHelper(FileName);
                    if (a.DataGridViewToExcel(gridview, sheetname, true) == -1)
                    {
                        throw new Exception("导出出错！");
                    }
                    a.Dispose();
                }

                catch (Exception ex)
                {

                    throw new Exception(ex.Message);

                }



                return true;
            }


        /// <summary>
        /// 将Excel文件导出到DataTable
        /// </summary>
        /// <param name="sheetname">导入的EXCEL的sheet页名称</param>
        /// <param name="isFirstRowColumn">Excel的第一行是否是DataTable的列名</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string sheetname = "sheet1", Boolean isFirstRowColumn=true)
        {

            System.Windows.Forms.OpenFileDialog SFD = new System.Windows.Forms.OpenFileDialog();
            DataTable dt = new DataTable();
            string FileName = "";



            SFD.Filter = "Excel文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            SFD.Title = "导入Excel表";

            if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return null;
            }


            FileName = SFD.FileName.ToString().Trim();

#if !DEBUG
            try
            {
#endif
                //DataTable dt = Helper.Transformation.Transformation.DataConvert.GetDgvToTable(gridview);
                Helper.Excel.ExcelHelper a = new Helper.Excel.ExcelHelper(FileName);
              
                dt = a.ExcelToDataTable(sheetname, isFirstRowColumn);

           

                a.Dispose();
#if !DEBUG
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
#endif


            return dt;
        }

#endregion

    }
}




