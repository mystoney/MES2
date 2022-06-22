using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using MES.module.DAL.ZCADMADal;

namespace MES.module.BLL
{
    public class ZCADMABLL
    {

        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZCADMA插入数据库
        /// </summary>
        /// <param name="_ZCADMA">Tmp_ZCADMA表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertZCADMA(List<Tmp_ZCADMA> _ZCADMA)
        {


            ZCADMADal ZbtdataDal = new ZCADMADal();



            

            try
            {
                return ZbtdataDal.InsertZCADMAALL(_ZCADMA);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }


     
    }
}
