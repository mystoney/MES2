using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using MES.module.DAL.ZBTDATADal;

namespace MES.module.BLL
{
    public class ZBTDATABLL
    {
        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZAFPO插入数据库
        /// </summary>
        /// <param name="_ZAFPO">Tmp_ZAFPO表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertZBTDATA(List<Tmp_ZBTDATA> _ZBTDATA)
        {


            ZBTDATADal ZbtdataDal = new ZBTDATADal();
            

            try
            {
                return ZbtdataDal.InsertZBTDATAALL(_ZBTDATA);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }
    }
}
