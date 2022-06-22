using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using MES.module.DAL.ZCLSXDal;

namespace MES.module.BLL
{
    public class ZCLSXBLL
    {
        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZCLSX插入数据库
        /// </summary>
        /// <param name="_ZCLSX">Tmp_ZCLSX表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertZCLSX(List<Tmp_ZCLSX> _ZCLSX)
        {


            ZCLSXDal ZclsxDal = new ZCLSXDal();



            
            try
            {
                return ZclsxDal.InsertZCLSXALL(_ZCLSX);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }


        }

    }
}
