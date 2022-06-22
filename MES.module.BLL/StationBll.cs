using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES.module.model;

using System.Windows.Forms;
using MES.module.DAL;
using System.Data;

namespace MES.module.BLL
{
    public class StationBll 
    {
        /// <summary>
        /// 初始化查询Station
        /// </summary>
        /// <returns>List<Station></returns>
        public DataTable Station_SelectAll()
        {

            DAL.StationDal.StationDal sd = new DAL.StationDal.StationDal();
            return sd.getStation();
        }

        /// <summary>
        /// 删除工作站
        /// </summary>
        /// <param name="Eton_WorkStation">工作站</param>
        /// <param name="Eton_Line">生产线</param>
        /// <returns>影响行数</returns>
        public int DelOneStation(int Eton_WorkStation, int Eton_Line)
        {
            DAL.StationDal.StationDal sd = new DAL.StationDal.StationDal();
            return sd.DelGrid( Eton_WorkStation,  Eton_Line);
        }




        /// <summary>
        /// 对生产线进行指定操作
        /// </summary>
        /// <param name="Eton_Line">生产线</param>
        /// <param name="LS">进行的操作</param>
        /// <returns></returns>
        public int LineEdit(int Eton_Line,LineState LS)
        {
            DAL.StationDal.StationDal sd = new DAL.StationDal.StationDal();
            int i;
            switch (LS)
                {
                case LineState.停用:
                    i = sd.Stop_line(Eton_Line);
                    break;
                case LineState.启用:
                    i = sd.Start_line(Eton_Line);
                    break;
                case LineState.删除:
                    i= sd.DelAllGrid(Eton_Line);
                    break;
                default:
                    throw new Exception("生产线状态不可识别！");
            }
            return i;
                   

            
        }
        /// <summary>
        /// 获取生产线
        /// </summary>
        /// <returns></returns>
        public DataTable get_line()
        {
            DAL.StationDal.StationDal sd = new DAL.StationDal.StationDal();
            return sd.getLine();
        }

        public DataTable get_Station(string Eton_line)
        {
            DAL.StationDal.StationDal sd = new DAL.StationDal.StationDal();
            return sd.getStation(Eton_line);
        }
        public enum LineState
        {
            删除 = -1,
            停用 = 0,
            启用 = 1,
        };

    }
}
