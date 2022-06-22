using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MES.module.model;
using MES.module.DAL.ZMTMAUFDal;

namespace MES.module.BLL
{
   public class ZMTMAUFBLL
    {
        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZMTMAUF插入数据库
        /// </summary>
        /// <param name="_ZMTMAUF">Tmp_ZMTMAUF表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertZMTMAUF(List<Tmp_ZMTMAUF> _ZMTMAUF)
        {


            ZMTMAUFDal ZmtmaufDal = new ZMTMAUFDal();


            try
            {
                return ZmtmaufDal.InsertZMTMAUFALL(_ZMTMAUF);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            

            

        }
    }
}
