using System;
using System.Collections;
using System.Collections.Generic;
using XYS.Lis.Model;
using XYS.Lis.DAL;


namespace XYS.Lis
{
    public class ReportManager
    {
        #region 私有字段
        
        private ReportFormDAL _rfDAL;
        private ReportItemDAL _riDAL;
        private RFGraphDataDAL _graphDAL;
        
        #endregion

        #region 构造函数
        
        public ReportManager()
        {
            this._graphDAL = new RFGraphDataDAL();
            this._rfDAL = new ReportFormDAL();
            this._riDAL = new ReportItemDAL();
        }
        
        #endregion

        #region 公共方法
        //获取lis报告集合
        public  List<LisReport> GetLisReportList(Hashtable equalFields)
        {
            List<LisReport> lrList = new List<LisReport>();
            ReportFormDAL rfdal = new ReportFormDAL();
            List<ReportFormModel> rfmList=rfdal.SearchList(equalFields);
            LisReport lr;
            Hashtable itemEqualFields;
            foreach(ReportFormModel rfm in rfmList)
            {
                lr = new LisReport();
                //报告信息
                lr.ReportInfo = rfm;
                //报告项
                itemEqualFields = GenderItemEqualFields(rfm);
                FillReportItemList(itemEqualFields,lr);
                //其他操作
                ReportOperate(lr);
                lrList.Add(lr);
            }
            return lrList;
        }
        //获得lis报告
        public LisReport GetLisReport(Hashtable equalFields)
        {
            LisReport lr = new LisReport();
            ReportFormDAL rfdal = new ReportFormDAL();
            lr.ReportInfo = rfdal.Search(equalFields);
            GenderItemEqualFields(lr.ReportInfo,lr.SpecItemsTable);
            FillReportItemList(lr.SpecItemsTable, lr);
            ReportOperate(lr);
            return lr;
        }
        public void InitLisReport(LisReport lr,Hashtable equalFields)
        {
            lr.Clear();
            this._rfDAL.Search(equalFields, lr.ReportInfo);
            GenderItemEqualFields(lr.ReportInfo, lr.SpecItemsTable);
            this._riDAL.SearchList(lr.SpecItemsTable, lr.ReportItemList);
            ReportOperate(lr);
        }
        #endregion
        
        #region 私有方法

        //设置通用报告项
        private void FillReportItemList(Hashtable itemEqualFields, LisReport lr)
        {
            List<ReportItemModel> rimList = GetItemList(itemEqualFields);
            //此处可添加一些过滤
            foreach (ReportItemModel rim in rimList)
            {
                if (!lr.ParItemList.Contains(rim.ParItemNo))
                {
                    lr.ParItemList.Add(rim.ParItemNo);
                }
                lr.ReportItemList.Add(rim);
            }
        }
        //获取通用报告项
        private List<ReportItemModel> GetItemList(Hashtable itemEqualFields)
        {
            ReportItemDAL ridal = new ReportItemDAL();
            return ridal.SearchList(itemEqualFields);
        }
        //获取报告项查询条件集合
        private Hashtable GenderItemEqualFields(ReportFormModel rfm)
        {
            Hashtable ht = new Hashtable();
             ht.Add("receivedate",rfm.ReceiveDate);
            ht.Add("sectionno",rfm.SectionNo);
            ht.Add("testtypeno", rfm.TestTypeNo);
            ht.Add("sampleno", rfm.SampleNo);
            return ht;
        }
       //获取报告项查询条件集合
        private void GenderItemEqualFields(ReportFormModel rfm, Hashtable ht)
        {
            //
            ht.Remove("receivedate");
            ht.Add("receivedate", rfm.ReceiveDate);

            ht.Remove("sectionno");
            ht.Add("sectionno", rfm.SectionNo);

            ht.Remove("testtypeno");
            ht.Add("testtypeno", rfm.TestTypeNo);

            ht.Remove("sampleno");
            ht.Add("sampleno", rfm.SampleNo);
        }
       //报告项处理
        //1.获取特殊检验项、图片项
        //2.设置报告的模板、排序号
        private void ReportOperate(LisReport lr)
        {
            CommonItemsOperate(lr);

            //设置显示序号，打印模板号
            switch (lr.ReportInfo.SectionNo)
            {
          //临检组
                case 2:
                case 27:
                   //包含人工分类
                    if (lr.SpecItemsList.Count > 0)
                    {
                        ManItemsOperate(lr.SpecItemsList, lr.SpecItemsTable);
                    }
                    lr.PrintModelNo = 100;
                    lr.OrderNo = 10;
                    break;
                case 28:
                case 62:
                    if (lr.ParItemList.Contains(90008562))
                    {
                        GraphItemsOperate(lr.SpecItemsTable);
                        //uf1000i尿大张
                        lr.PrintModelNo = 200;
                        lr.OrderNo = 1000;
                    }
                    else
                    {
                        //小张
                        lr.PrintModelNo = 300;
                        switch (lr.ReportInfo.SampleTypeNo)
                        {
                            //尿(尿常规等)
                            case 108:
                                lr.OrderNo = 1000;
                                break;
                            //血(c反应蛋白)
                            case 175:
                                lr.OrderNo = 100;
                                break;
                            //便(便常规等)
                            case 117:
                                lr.OrderNo = 1100;
                                break;
                            //脑脊液()---特殊与生化同属于一个序列
                            case 115:
                                lr.OrderNo = 2000;
                                break;
                            //胸水
                            case 4:
                                break;
                            default:
                                lr.OrderNo = 1999;
                                break;
                        }
                    }
                    break;
          //生化组
                case 17:
                case 23:
                case 29:
                case 34:
                    lr.ReportInfo.Explanation = lr.ReportInfo.FormMemo;
                    lr.PrintModelNo = 400;
                    lr.OrderNo = 2000;
                    break;
          //免疫组
                    //Tecan150  特殊
                case 19:
                    if (lr.SpecItemFlag && lr.ReportInfo.SickTypeNo == 2)
                    {
                        lr.ReportInfo.Remark = "带*为天津市临床检测中心认定的相互认可检验项目";
                    }
                    //更正说明
                    lr.ReportInfo.Explanation = lr.ReportInfo.ZDY5;
                    lr.PrintModelNo = 600;
                    break;
                    //DXI800  大张
                case 20:
                    //更正说明
                    lr.ReportInfo.Explanation = lr.ReportInfo.FormMemo;
                    //必须在程序中排序
                    lr.ReportItemList.Sort();
                    lr.PrintModelNo = 700;
                    break;
                    //spife4000  大张
                case 35:
                    GraphItemsOperate(lr.SpecItemsTable);
                    lr.PrintModelNo = 750;
                    break;
                    //其他
                case 21:
                case 30:
                    lr.ReportInfo.Explanation = lr.ReportInfo.FormMemo;
                    lr.PrintModelNo = 650;
                    break;
                case 5:
                case 25:
                case 33:
                case 63:
                    lr.ReportInfo.Explanation = lr.ReportInfo.ZDY5;
                    lr.PrintModelNo = 650;
                    break;
                //出凝血组
                case 4:
                case 24:
                    lr.PrintModelNo = 800;
                    break;
                //溶血组
                case 18:
                    if (lr.ReportItemList.Count > 18)
                    {
                        //大张
                        lr.PrintModelNo = 1000;
                    }
                    else
                    {
                        //小张
                        lr.PrintModelNo = 1100;
                    }
                    break;
                //分子遗传小组
                case 11:
                    //染色体
                    if (lr.ParItemList.Contains(90009044) || lr.ParItemList.Contains(90009045) || lr.ParItemList.Contains(90009046))
                    {
                        lr.PrintModelNo = 1300;
                        GraphItemsOperate(lr.SpecItemsTable);
                    }
                    //FISH
                    else
                    {
                        lr.PrintModelNo = 1200;
                        GraphItemsOperate(lr.SpecItemsTable);
                    }
                    break;
                //分子生物
                case 6:
                    break;
                //组织配型
                case 45:
                    break;
                default:
                    lr.PrintModelNo = -1;
                    lr.OrderNo = 100000;
                    break;
            }
        }
        //设置免疫TECAN150 相关项
        private void TECAN150Operate(LisReport lr)
        {
        }
        //设置血常规人工分类项
        private void ManItemsOperate(List<ReportItemModel> rimList, Hashtable manItemTable)
        {
            //包含人工分类
            foreach(ReportItemModel rim in rimList)
            {
                switch (rim.ItemNo)
                {
                    case 90009288:
                        manItemTable.Add("Item9288", rim.ItemResult);
                        //rim.SecretGrade = 10;
                        break;
                    case 90009289:
                        manItemTable.Add("Item9289", rim.ItemResult);
                        //rim.SecretGrade = 10;
                        break;
                    case 90009290:
                        manItemTable.Add("Item9290", rim.ItemResult);
                        break;
                    case 90009291:
                        manItemTable.Add("Item9291", rim.ItemResult);
                        //rim.SecretGrade = 10;
                        break;
                    case 90009292:
                        manItemTable.Add("Item9292", rim.ItemResult);
                        //rim.SecretGrade = 10;
                        break;
                    case 90009293:
                        manItemTable.Add("Item9293", rim.ItemResult);
                       // rim.SecretGrade = 10;
                        break;
                    case 90009294:
                        manItemTable.Add("Item9294", rim.ItemResult);
                       // rim.SecretGrade = 10;
                        break;
                    case 90009300:
                        manItemTable.Add("Item9300", rim.ItemResult);
                       // rim.SecretGrade = 10;
                        break;
                    case 90009295:
                        manItemTable.Add("Item9295", rim.ItemResult);
                      //  rim.SecretGrade = 10;
                        break;
                    case 90009296:
                        manItemTable.Add("Item9296", rim.ItemResult);
                       // rim.SecretGrade = 10;
                        break;
                    case 90009297:
                        manItemTable.Add("Item9297", rim.ItemResult);
                        //rim.SecretGrade = 10;
                        break;
                    case 90009301:
                        manItemTable.Add("Item9301", rim.ItemResult);
                        //rim.SecretGrade = 10;
                        break;
                }
            }
        }
        //所有项同一处理
        private void CommonItemsOperate(LisReport lr)
        {
            //foreach (ReportItemModel rim in lr.ReportItemList)
            //{
            //    if (!lr.ParItemList.Contains(rim.ParItemNo))
            //    {
            //        lr.ParItemList.Add(rim.ParItemNo);
            //    }
            //    //
            //}
            for (int i = lr.ReportItemList.Count - 1; i >= 0; i--)
            {
                //设置组合编号集合
                if (!lr.ParItemList.Contains(lr.ReportItemList[i].ParItemNo))
                {
                    lr.ParItemList.Add(lr.ReportItemList[i].ParItemNo);
                }
                //特殊项处理
                switch (lr.ReportItemList[i].ItemNo)
                {
                    //血常规项目
                    case 90009288:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009289:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009290:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009291:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009292:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009293:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009294:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009300:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009295:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009296:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009297:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90009301:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    //免疫项目 Tecan150
                    case 90008462:
                        lr.SpecItemFlag = true;
                        break;
                    //DXI800
                    case 50004360:
                        lr.ReportItemList[i].RefRange = lr.ReportItemList[i].RefRange.Replace(";", Environment.NewLine);
                        break;
                    case 50004370:
                        lr.ReportItemList[i].RefRange = lr.ReportItemList[i].RefRange.Replace(";", Environment.NewLine);
                        break;
                    //染色体
                    case 90008528:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90008797:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90008798:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                    case 90008799:
                        lr.SpecItemsList.Add(lr.ReportItemList[i]);
                        lr.ReportItemList.RemoveAt(i);
                        break;
                }
            }
        }
        //设置报告图片项
        private void GraphItemsOperate(Hashtable graphItemsTable)
        {
            //RFGraphDataDAL rfdal = new RFGraphDataDAL();
           // rfdal.SearchTable(graphItemsTable);
            this._graphDAL.SearchTable(graphItemsTable);
        }
        #endregion
    }
}