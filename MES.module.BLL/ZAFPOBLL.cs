using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using MES.module.DAL.ZAFPODal;



namespace MES.module.BLL
{

    /// <summary>
    /// Tmp_ZAFPO的业务逻辑层
    /// </summary>
    public class ZAFPOBLL 
    {
       

        /// <summary>
        /// 将得到的Tmp_ZAFPO表插入数据库
        /// </summary>
        /// <param name="_ZAFPO">得到的Tmp_ZAFPO表</param>
        /// <returns>是否插入成功</returns>
        public bool ZAFPO_Insert(Tmp_ZAFPO _ZAFPO)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 根据AFURN(生产订单号)从数据库中Tmp_ZAFPO表选择出来符合条件的数据
        /// </summary>
        /// <param name="Tmp_ZAFPO">根据些表中的AFURN来选择符合条件的数据</param>
        /// <returns></returns>
        public int ZAFPO_SelectByAFURN(List<Tmp_ZAFPO> Tmp_ZAFPO)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 根据AFURN(生产订单号)从数据库中Tmp_ZAFPO表删除符合条件的数据
        /// </summary>
        /// <param name="Zafpo">根据此表中的AFURN来选择符合条件的数据</param>
        /// <returns></returns>
        public int ZAFPO_DeleteByAFURN(List<Tmp_ZAFPO> Zafpo)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZAFPO插入数据库
        /// </summary>
        /// <param name="_ZAFPO">Tmp_ZAFPO表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertZAFPO(List<Tmp_ZAFPO> _ZAFPO )
        {


            ZAFPODal zafpoDal = new ZAFPODal();



            

            try
            {
                return zafpoDal.InsertZAFPOALL(_ZAFPO);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }



        }


    }
}

