using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using MES.module.DAL.ZMTMFILLDal;

namespace MES.module.BLL
{
    public class ZMTMFILLBLL
    {
        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZMTMFILL插入数据库
        /// </summary>
        /// <param name="_ZMTMFILL">Tmp_ZMTMFILL表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertZMTMFILL(List<Tmp_ZMTMFILL> _ZMTMFILL)
        {

            
            ZMTMFILLDal ZmtmfillDal = new ZMTMFILLDal();



            

            try
            {
                return ZmtmfillDal.InsertZMTMFILLALL(_ZMTMFILL);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }
    }
}
